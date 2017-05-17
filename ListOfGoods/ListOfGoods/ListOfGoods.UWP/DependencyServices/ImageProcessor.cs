using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using ListOfGoods.Infrastructure.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(ListOfGoods.UWP.DependencyServices.ImageProcessor))]
namespace ListOfGoods.UWP.DependencyServices
{
    public class ImageProcessor : IImageProcessor
    {
        public async Task<string> GetCroppedImagePathAsync(string filePath, string fileName, int requestedMinSide)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                IRandomAccessStream inputstream = fileStream.AsRandomAccessStream();
                var decoder = await BitmapDecoder.CreateAsync(inputstream);
                var originalPixelWidth = decoder.PixelWidth;
                var originalPixelHeight = decoder.PixelHeight;

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile thumbFile = null;
                try
                {
                    thumbFile = await storageFolder.CreateFileAsync($"{fileName}_thumb.jpg", CreationCollisionOption.ReplaceExisting);
                }
                catch (Exception e)
                {
                    thumbFile = await storageFolder.CreateFileAsync($"{fileName}_{Guid.NewGuid()}.jpg", CreationCollisionOption.ReplaceExisting);
                }

                if (thumbFile != null && originalPixelHeight > requestedMinSide && originalPixelWidth > requestedMinSide)
                {
                    using (var resizedStream = await thumbFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        //create encoder based on decoder of the source file
                        var encoder = await BitmapEncoder.CreateForTranscodingAsync(resizedStream, decoder);
                        double widthRatio = (double)requestedMinSide / originalPixelWidth;
                        double heightRatio = (double)requestedMinSide / originalPixelHeight;
                        uint aspectHeight = (uint)requestedMinSide;
                        uint aspectWidth = (uint)requestedMinSide;
                        uint cropX = 0, cropY = 0;
                        var scaledSize = (uint)requestedMinSide;
                        if (originalPixelWidth > originalPixelHeight)
                        {
                            aspectWidth = (uint)(heightRatio * originalPixelWidth);
                            cropX = (aspectWidth - aspectHeight) / 2;
                        }
                        else
                        {
                            aspectHeight = (uint)(widthRatio * originalPixelHeight);
                            cropY = (aspectHeight - aspectWidth) / 2;
                        }
                        //you can adjust interpolation and other options here, so far linear is fine for thumbnails
                        encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
                        encoder.BitmapTransform.ScaledHeight = aspectHeight;
                        encoder.BitmapTransform.ScaledWidth = aspectWidth;
                        encoder.BitmapTransform.Bounds = new BitmapBounds()
                        {
                            Width = scaledSize,
                            Height = scaledSize,
                            X = cropX,
                            Y = cropY,
                        };
                        await encoder.FlushAsync();
                        return thumbFile.Path;
                    }
                }
                else
                {
                    return thumbFile.Path;
                }
            }
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}

