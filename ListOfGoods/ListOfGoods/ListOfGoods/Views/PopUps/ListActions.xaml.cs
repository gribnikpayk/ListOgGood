using System.Collections.Generic;
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{
    public partial class ListActions : PopupPage
    {
        private ListActionsPopUpViewModel _viewModel;
        private ListFrame _selectedList;
        public ListActions(ListFrame selectedList)
        {
            InitializeComponent();
            _selectedList = selectedList;
            _viewModel = App.Container.Resolve(typeof(ListActionsPopUpViewModel), "listActionsPopUpViewModel") as ListActionsPopUpViewModel;
            BindingContext = _viewModel;
            ActionsListView.ItemsSource = new List<object>
            {
                new ListViewItem {Name=CommonNameConstants.ShareActionName},
                new ListViewItem {Name=CommonNameConstants.EditActionName},
                new ListViewItem {Name=CommonNameConstants.DeleteActionName}
            };
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await PopupNavigation.PopAllAsync();
            ListViewItem selectedItem = e.SelectedItem as ListViewItem;
            switch (selectedItem.Name)
            {
                case CommonNameConstants.DeleteActionName:
                    _viewModel.DeleteList(_selectedList.ListModel.Id);
                    MessagingCenter.Send<ListActions, int>(this, MessagingCenterConstants.InitLists, _selectedList.ListModel.Id);
                    break;
                case CommonNameConstants.EditActionName:
                    await PopupNavigation.PushAsync(new AddNewPurchaseListPopUp(new ListModel
                    {
                        Id = _selectedList.ListModel.Id,
                        Name = _selectedList.ListModel.Name,
                        CreationDate = _selectedList.ListModel.CreationDate,
                        CountOfPurchases = _selectedList.ListModel.CountOfPurchases,
                        CountOfAlreadyPurchased = _selectedList.ListModel.CountOfAlreadyPurchased
                    }));
                    break;
                case CommonNameConstants.ShareActionName:
                    _viewModel.Share(_selectedList.ListModel);
                    break;
                default:
                    break;


            }
        }

        private class ListViewItem
        {
            public string Name { get; set; }
        }
    }
}
