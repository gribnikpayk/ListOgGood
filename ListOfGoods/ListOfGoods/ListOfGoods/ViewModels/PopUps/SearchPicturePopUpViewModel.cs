using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Services.Search;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class SearchPicturePopUpViewModel : BaseViewModel
    {
        private string _pictureName;
        private SearchService _searchService;
        private bool _noResultsMessageIsVisible;

        public double DeviceWidth;

        public ICommand SearchCommand { get; set; }

        public SearchPicturePopUpViewModel(SearchService searchService)
        {
            _searchService = searchService;
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
            var pictures = await _searchService.SearchImagesAsync(PictureName);
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
    }
}
