using ListOfGoods.Services.Search;

namespace ListOfGoods.ViewModels.PopUps
{
    public class SearchPicturePopUpViewModel:BaseViewModel
    {
        private string _pictureName;
        private SearchService _searchService;

        public SearchPicturePopUpViewModel(SearchService searchService)
        {
            _searchService = searchService;
        }

        public string PictureName
        {
            set { SetProperty(ref _pictureName, value); }
            get { return _pictureName; }
        }
    }
}
