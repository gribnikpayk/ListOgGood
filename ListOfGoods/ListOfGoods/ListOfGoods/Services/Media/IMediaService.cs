using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace ListOfGoods.Services.Media
{
    public interface IMediaService
    {
        Task<MediaFile> TakePhotoFromGalleryAsync();
        Task<MediaFile> TakePhotoFromCameraAsync();
    }
}
