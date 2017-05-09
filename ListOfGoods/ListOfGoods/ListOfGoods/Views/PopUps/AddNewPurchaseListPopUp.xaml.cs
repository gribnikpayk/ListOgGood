using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;

namespace ListOfGoods.Views.PopUps
{
    public partial class AddNewPurchaseListPopUp : PopupPage
    {
        private AddNewPurchaseListPopUpViewModel _viewModel;
        public AddNewPurchaseListPopUp()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(AddNewPurchaseListPopUpViewModel), "addNewPurchaseListPopUpViewModel") as AddNewPurchaseListPopUpViewModel;
            BindingContext = _viewModel;
        }
    }
}
