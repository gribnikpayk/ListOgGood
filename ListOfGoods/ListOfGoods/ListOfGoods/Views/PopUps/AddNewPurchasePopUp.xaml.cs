using System;
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
            _viewModel.ImageIconIsSeleted = newPurchaseModel.ImageSource != null;
            _viewModel.PurchaseIconSource = newPurchaseModel.ImageSource;

            BindingContext = _viewModel;
        }

        private void Picker_OnCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_viewModel.ImageIconIsSeleted)
            {
                var picker = sender as Picker;
                if (picker != null)
                {
                    _viewModel.PurchaseIconSource = (picker.SelectedItem as string).ToCategoryIconImageSource();
                }
            }
        }
    }
}
