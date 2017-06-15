using System.Collections.Generic;
using System.Linq;
using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{
    public partial class PurchaseActionsPopUp : PopupPage
    {
        private PurchaseActionsPopUpViewModel _viewModel;
        private PurchaseGrid _grid;
        public PurchaseActionsPopUp(PurchaseGrid grid)
        {
            InitializeComponent();
            _grid = grid;
            _viewModel = App.Container.Resolve(typeof(PurchaseActionsPopUpViewModel), "purchaseActionsPopUpViewModel") as PurchaseActionsPopUpViewModel;
            BindingContext = _viewModel;
            ActionsListView.ItemsSource = new List<object>
            {
                new ListViewItem {Name = CommonNameConstants.EditActionName},
                new ListViewItem {Name = CommonNameConstants.DeleteActionName},
                new ListViewItem {
                    Name = grid.UsersPurchase.IsAlreadyPurchased
                        ? CommonNameConstants.BackToTheList
                        : CommonNameConstants.MarkAsPurchased
                }
            };
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await PopupNavigation.PopAllAsync();
            ListViewItem selectedItem = e.SelectedItem as ListViewItem;
            switch (selectedItem.Name)
            {
                case CommonNameConstants.DeleteActionName:
                    _viewModel.DeletePurchase(_grid.UsersPurchase.PurchaseId, _grid.UsersPurchase.PurchasesListId);
                    MessagingCenter.Send<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.DeleteAction, _grid);
                    break;
                case CommonNameConstants.EditActionName:
                    await PopupNavigation.PushAsync(new EditPurchasePopUp(GetEditPurchaseModel(), _grid));
                    break;
                case CommonNameConstants.MarkAsPurchased:
                    _viewModel.MarkAsPurchased(_grid.UsersPurchase.PurchaseId, _grid.UsersPurchase.PurchasesListId);
                    MessagingCenter.Send<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.MarkAsPurchased, _grid);
                    break;
                case CommonNameConstants.BackToTheList:
                    _viewModel.BackToTheList(_grid.UsersPurchase.PurchaseId, _grid.UsersPurchase.PurchasesListId);
                    MessagingCenter.Send<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.BackToList, _grid);
                    break;
                default:
                    break;

            }
        }

        private EditPurchaseModel GetEditPurchaseModel()
        {
            var model = new EditPurchaseModel
            {
                NewPurchase = _grid.Purchase.Name,
                ImageIconIsCustom = _grid.Purchase.IsCustomImage,
                PurchasesId = _grid.UsersPurchase.PurchaseId,
                PurchaseIconImagePath = _grid.Purchase.ImagePath,
                SelectedCategory = CommonNameConstants.CategoriesDictionary.FirstOrDefault(x => (int)x.Key == _grid.UsersPurchase.CategoryType).Value,
                Id = _grid.UsersPurchase.Id,
                PurchasesListId = _grid.UsersPurchase.PurchasesListId,
                Quantity = _grid.UsersPurchase.Quantity,
                SelectedMesurement = CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => (int)x.Key == _grid.UsersPurchase.MesurementType).Value,
                Price = _grid.UsersPurchase.Price,
                SelectedIndexOfMesurement = _grid.UsersPurchase.MesurementType,
                SelectedIndexCategory = _grid.UsersPurchase.CategoryType,
                SelectedCurrency = CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => (int)x.Key == _grid.UsersPurchase.CategoryType).Value,
                SelectedIndexCurrency = _grid.UsersPurchase.CurrencyType
            };
            return model;
        }
        private class ListViewItem
        {
            public string Name { get; set; }
        }
    }
}
