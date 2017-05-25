using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{
    public partial class SearchPicturePopUp : PopupPage
    {
        private SearchPicturePopUpViewModel _viewModel;
        public SearchPicturePopUp(string pictureName, double deviceWidth)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(SearchPicturePopUpViewModel), "searchPicturePopUpViewModel") as SearchPicturePopUpViewModel;
            BindingContext = _viewModel;
            _viewModel.PictureName = pictureName;
            _viewModel.DeviceWidth = deviceWidth;
            _viewModel.SearchAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<SearchPicturePopUpViewModel,SearchPictureResultsControl>(this,MessagingCenterConstants.SearchControlIsReady,
                (sender, control) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ContentWrapper.Children.Add(control);
                    });
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SearchPicturePopUpViewModel, SearchPictureResultsControl>(this, MessagingCenterConstants.SearchControlIsReady);
        }
    }
}
