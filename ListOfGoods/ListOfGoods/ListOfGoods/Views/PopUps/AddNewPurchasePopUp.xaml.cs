using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{
    public partial class AddNewPurchasePopUp : PopupPage
    {
        private AddNewPurchasePopUpViewModel _viewModel;
        public AddNewPurchasePopUp(NewPurchaseModel newPurchaseModel)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(AddNewPurchasePopUpViewModel), "addNewPurchasePopUpViewModel") as AddNewPurchasePopUpViewModel;
            _viewModel.NewPurchase = newPurchaseModel.PurchaseName;
            _viewModel.PurchaseIconSource = newPurchaseModel.ImageSource != null
                ? newPurchaseModel.ImageSource
                : ImageSource.FromFile("new_purchase_Icon.png".ToPlatformImagePath());
            BindingContext = _viewModel;
        }
    }
}
