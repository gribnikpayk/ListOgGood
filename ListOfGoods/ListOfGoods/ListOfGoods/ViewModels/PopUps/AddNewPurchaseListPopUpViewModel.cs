using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Services.Purchase;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchaseListPopUpViewModel : BaseViewModel
    {
        private string _listName, _buttonName;
        private bool _errorMessageIsVisible;
        public ICommand AddNewListCommand { get; set; }
        private IPurchaseService _purchaseService;

        public ListModel SelectedPurchasesListModel { get; set; }

        public AddNewPurchaseListPopUpViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
            AddNewListCommand = new Command(AddNewList);
        }

        public string ButtonName
        {
            set { SetProperty(ref _buttonName, value); }
            get { return SelectedPurchasesListModel == null ? "Create" : "OK"; }
        }
        public bool ErrorMessageIsVisible
        {
            set { SetProperty(ref _errorMessageIsVisible, value); }
            get { return _errorMessageIsVisible; }
        }
        public string ListName
        {
            set { SetProperty(ref _listName, value); }
            get { return _listName; }
        }
        private void AddNewList()
        {
            if (string.IsNullOrEmpty(ListName))
            {
                ErrorMessageIsVisible = true;
            }
            else
            {
                ErrorMessageIsVisible = false;
                if (SelectedPurchasesListModel == null)
                {
                    var newList = new PurchasesListEntity
                    {
                        Name = ListName,
                        CreationDate = DateTime.Now
                    };
                    _purchaseService.SavePurchasesList(newList);
                    MessagingCenter.Send<AddNewPurchaseListPopUpViewModel, ListModel>(this,
                    MessagingCenterConstants.NewListWasCreated, new ListModel {Id = newList.Id,CreationDate = newList.CreationDate, Name = newList.Name});
                }
                else
                {
                    SelectedPurchasesListModel.Name = ListName;
                    var updatedEntity = new PurchasesListEntity
                    {
                        Id = SelectedPurchasesListModel.Id,
                        Name = SelectedPurchasesListModel.Name,
                        CreationDate = SelectedPurchasesListModel.CreationDate
                    };
                    _purchaseService.SavePurchasesList(updatedEntity);
                    MessagingCenter.Send<AddNewPurchaseListPopUpViewModel, ListModel>(this,
                    MessagingCenterConstants.NewListWasCreated, SelectedPurchasesListModel);
                }

                Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.PopAllAsync(); });

            }
        }
    }
}
