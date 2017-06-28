using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Services.Media;
using ListOfGoods.Views.PopUps;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class EditImageActionsPopUpViewModel : BaseViewModel
    {
        private IMediaService _mediaService;

        public string PurchaseName { get; set; }

        public ICommand TakePhotoFromGallery => new Command(async () =>
        {
            MediaFile photo = null;
            try
            {
                photo = await _mediaService.TakePhotoFromGalleryAsync();

            }
            catch (Exception ex)
            {
                photo = null;
            }
            await ImageProcessor(photo);
        });

        public ICommand TakePhotoFromCamera => new Command(async () =>
        {
            MediaFile photo = null;
            try
            {
                photo = await _mediaService.TakePhotoFromCameraAsync();
            }
            catch (Exception ex)
            {
                photo = null;
            }
            await ImageProcessor(photo);
        });

        public ICommand TakePhotoFromInternet => new Command(async () =>
        {
            var deviceWidth = DependencyService.Get<IDisplay>().Width;
            await PopupNavigation.PushAsync(new SearchPicturePopUp(PurchaseName, deviceWidth), false);
        });

        public EditImageActionsPopUpViewModel(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        private async Task ImageProcessor(MediaFile file)
        {
            if (file != null)
            {
                var name = $"{PurchaseName}_{Guid.NewGuid()}";
                string path = string.Empty;
                try
                {
                    path = await DependencyService.Get<IImageProcessor>().GetCroppedImagePathAsync(file.Path, name, 50);
                    DependencyService.Get<IImageProcessor>().DeleteFile(file.Path);
                }
                catch (Exception ex)
                {
                    path = string.Empty;
                }
                MessagingCenter.Send<EditImageActionsPopUpViewModel, string>(this,
                    MessagingCenterConstants.PictureSelected, path);
            }
            else
            {
                MessagingCenter.Send<EditImageActionsPopUpViewModel, string>(this,
                    MessagingCenterConstants.PictureSelected, string.Empty);
            }
        }
    }
}
