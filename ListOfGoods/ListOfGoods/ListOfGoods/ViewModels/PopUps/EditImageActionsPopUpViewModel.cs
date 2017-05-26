using System;
using System.Windows.Input;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Services.Media;
using ListOfGoods.Views.PopUps;
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
            var photo = await _mediaService.TakePhotoFromGalleryAsync();
            var name = $"{PurchaseName}_{Guid.NewGuid()}";
            var path = await DependencyService.Get<IImageProcessor>().GetCroppedImagePathAsync(photo.Path, name, 50);
            DependencyService.Get<IImageProcessor>().DeleteFile(photo.Path);
        });

        public ICommand TakePhotoFromCamera => new Command(async () =>
        {
            var photo = await _mediaService.TakePhotoFromCameraAsync();
            var name = $"{PurchaseName}_{Guid.NewGuid()}";
            var path = await DependencyService.Get<IImageProcessor>().GetCroppedImagePathAsync(photo.Path, name, 50);
            DependencyService.Get<IImageProcessor>().DeleteFile(photo.Path);
        });

        public ICommand TakePhotoFromInternet => new Command(async () =>
        {
            var deviceWidth = DependencyService.Get<IDisplay>().Width;
            await PopupNavigation.PushAsync(new SearchPicturePopUp(PurchaseName, deviceWidth));
        });

        public EditImageActionsPopUpViewModel(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
    }
}
