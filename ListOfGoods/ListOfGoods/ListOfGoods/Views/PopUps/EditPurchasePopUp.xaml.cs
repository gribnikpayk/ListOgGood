using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{

    public partial class EditPurchasePopUp : PopupPage
    {
        private EditPurchasePopUpViewModel _viewModel;
        public EditPurchasePopUp(EditPurchaseModel model)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(EditPurchasePopUpViewModel), "editPurchasePopUpViewModel") as EditPurchasePopUpViewModel;
            MapViewModels(_viewModel, model);
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<EditImageActionsPopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected, SetPurchaseImage);
            MessagingCenter.Subscribe<SearchPicturePopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected, SetPurchaseImage);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<EditImageActionsPopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected);
            MessagingCenter.Unsubscribe<SearchPicturePopUpViewModel, string>(this, MessagingCenterConstants.PictureSelected);
        }

        private void SetPurchaseImage(object sender, string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                _viewModel.PurchaseIconImagePath = path;
                _viewModel.PurchaseIconSource = path;
                _viewModel.ImageIconIsCustom = true;
            }
            else
            {
                _viewModel.PurchaseIconImagePath = string.Empty;
                _viewModel.ImageIconIsCustom = false;
                _viewModel.PurchaseIconSource = _viewModel.SelectedCategory.ToCategoryIconImageSource();
            }
        }

        private void MapViewModels(EditPurchasePopUpViewModel viewModel, EditPurchaseModel source)
        {
            viewModel.PurchaseIconImagePath = source.PurchaseIconImagePath;
            viewModel.ImageIconIsCustom = source.ImageIconIsCustom;
            viewModel.PurchasesListId = source.PurchasesListId;
            viewModel.PurchasesId = source.PurchasesId;
            viewModel.SelectedIndexCategory = source.SelectedIndexCategory;
            viewModel.SelectedIndexOfMesurement = source.SelectedIndexOfMesurement;
            viewModel.NewPurchase = source.NewPurchase;
            viewModel.SelectedCategory = source.SelectedCategory;
            viewModel.SelectedMesurement = source.SelectedMesurement;
            viewModel.Quantity = source.Quantity;
            viewModel.Price = source.Price;
            viewModel.Id = source.Id;
            viewModel.SelectedCurrency = source.SelectedCurrency;
            viewModel.SelectedIndexCurrency = source.SelectedIndexCurrency;
            viewModel.PurchaseIconSource = ImageSource.FromFile(source.ImageIconIsCustom 
                ? source.PurchaseIconImagePath
                : source.PurchaseIconImagePath.ToPlatformImagePath());
        }
    }
}
