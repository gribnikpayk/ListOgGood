using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Services.Media;
using ListOfGoods.Services.Search;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class SearchPicturePopUpViewModel : BaseViewModel
    {
        private string _pictureName;
        private ISearchService _searchService;
        private IImageProcessor _imageProcess;
        private bool _noResultsMessageIsVisible;

        public double DeviceWidth;

        public ICommand SearchCommand { get; set; }

        public SearchPicturePopUpViewModel(ISearchService searchService)
        {
            _searchService = searchService;
            _imageProcess = DependencyService.Get<IImageProcessor>();
            SearchCommand = new Command(SearchAsync);
        }

        public string PictureName
        {
            set { SetProperty(ref _pictureName, value); }
            get { return _pictureName; }
        }

        public bool NoResultsMessageIsVisible
        {
            set { SetProperty(ref _noResultsMessageIsVisible, value); }
            get { return _noResultsMessageIsVisible; }
        }

        public async void SearchAsync()
        {
            IsBusy = true;
            NoResultsMessageIsVisible = false;
            MessagingCenter.Send<SearchPicturePopUpViewModel>(this, MessagingCenterConstants.RemoveSearchControl);

            var pictures = new List<string>();
            try
            {
                pictures = await _searchService.SearchImagesAsync(PictureName);
            }
            catch (Exception e){}
            
            if (pictures.Any())
            {
                await Task.Run(() =>
                {
                    var picturesControl = new SearchPictureResultsControl(pictures, DeviceWidth);
                    MessagingCenter.Send<SearchPicturePopUpViewModel, SearchPictureResultsControl>(this, MessagingCenterConstants.SearchControlIsReady, picturesControl);
                });
            }
            NoResultsMessageIsVisible = !pictures.Any();
            IsBusy = false;
        }

        public async Task ImageProcess(string filePath)
        {
            IsBusy = true;
            try
            {
                var name = $"{PictureName}_{Guid.NewGuid()}";
                var uploadedImagePath = await _imageProcess.CreateFileFromURIPath(filePath);
                var path = await _imageProcess.GetCroppedImagePathAsync(uploadedImagePath, name, 50);
                _imageProcess.DeleteFile(uploadedImagePath);
                MessagingCenter.Send<SearchPicturePopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected, path);
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<SearchPicturePopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected, string.Empty);
            }
            await PopupNavigation.PopAsync();
        }
    }
}
