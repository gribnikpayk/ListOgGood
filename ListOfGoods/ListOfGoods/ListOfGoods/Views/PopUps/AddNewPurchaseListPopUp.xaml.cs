using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;

namespace ListOfGoods.Views.PopUps
{
    public partial class AddNewPurchaseListPopUp : PopupPage
    {
        private AddNewPurchaseListPopUpViewModel _viewModel;
        public AddNewPurchaseListPopUp(PurchasesListEntity purchasesListEntity = null)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(AddNewPurchaseListPopUpViewModel), "addNewPurchaseListPopUpViewModel") as AddNewPurchaseListPopUpViewModel;
            _viewModel.SelectedPurchasesListEntity = purchasesListEntity;
            _viewModel.ListName = purchasesListEntity == null ? string.Empty : purchasesListEntity.Name;
            BindingContext = _viewModel;
        }
    }
}
