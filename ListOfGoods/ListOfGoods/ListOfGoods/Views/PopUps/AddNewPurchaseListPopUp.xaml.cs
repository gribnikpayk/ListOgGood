using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;

namespace ListOfGoods.Views.PopUps
{
    public partial class AddNewPurchaseListPopUp : PopupPage
    {
        private AddNewPurchaseListPopUpViewModel _viewModel;
        public AddNewPurchaseListPopUp(ListModel purchasesListModel = null)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(AddNewPurchaseListPopUpViewModel), "addNewPurchaseListPopUpViewModel") as AddNewPurchaseListPopUpViewModel;
            _viewModel.SelectedPurchasesListModel = purchasesListModel;
            _viewModel.ListName = purchasesListModel == null ? string.Empty : purchasesListModel.Name;
            BindingContext = _viewModel;
        }
    }
}
