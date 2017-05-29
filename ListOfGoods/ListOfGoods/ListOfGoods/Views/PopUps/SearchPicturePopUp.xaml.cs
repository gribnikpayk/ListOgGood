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
            MessagingCenter.Subscribe<SearchPicturePopUpViewModel, SearchPictureResultsControl>(this, MessagingCenterConstants.SearchControlIsReady, DrawSearchPicControl);
            MessagingCenter.Subscribe<SearchPicturePopUpViewModel>(this, MessagingCenterConstants.RemoveSearchControl, ClearSearchPicControl);
            MessagingCenter.Subscribe<SearchPictureResultsControl, string>(this, MessagingCenterConstants.PictureSelected, SelectPictureProcess);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SearchPicturePopUpViewModel, SearchPictureResultsControl>(this, MessagingCenterConstants.SearchControlIsReady);
            MessagingCenter.Unsubscribe<SearchPicturePopUpViewModel>(this, MessagingCenterConstants.RemoveSearchControl);
            MessagingCenter.Unsubscribe<SearchPictureResultsControl, string>(this, MessagingCenterConstants.PictureSelected);
        }

        #region privateMethods
        private void DrawSearchPicControl(SearchPicturePopUpViewModel sender, SearchPictureResultsControl control)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ContentWrapper.Children.Add(control);
            });
        }

        private void ClearSearchPicControl(SearchPicturePopUpViewModel sender)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ContentWrapper.Children.Clear();
            });
        }

        private async void SelectPictureProcess(object sender, string args)
        {
            await _viewModel.ImageProcess(args);
        }
        #endregion
    }
}
