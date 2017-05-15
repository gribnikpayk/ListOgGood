using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchaseListPopUpViewModel : BaseViewModel
    {
        private string _listName, _buttonName;
        private bool _errorMessageIsVisible;
        public ICommand AddNewListCommand { get; set; }
        private IPurchasesListRepository _purchasesListRepository;

        public PurchasesListEntity SelectedPurchasesListEntity { get; set; }

        public AddNewPurchaseListPopUpViewModel(IPurchasesListRepository purchasesListRepository)
        {
            _purchasesListRepository = purchasesListRepository;
            AddNewListCommand = new Command(AddNewList);
        }

        public string ButtonName
        {
            set { SetProperty(ref _buttonName, value); }
            get { return SelectedPurchasesListEntity == null ? "Create" : "OK"; }
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
                if (SelectedPurchasesListEntity == null)
                {
                    var newList = new PurchasesListEntity
                    {
                        Name = ListName,
                        CreationDate = DateTime.Now
                    };
                    _purchasesListRepository.Create(newList);
                    MessagingCenter.Send<AddNewPurchaseListPopUpViewModel, PurchasesListEntity>(this,
                    MessagingCenterConstants.NewListWasCreated, newList);
                }
                else
                {
                    SelectedPurchasesListEntity.Name = ListName;
                    _purchasesListRepository.Update(SelectedPurchasesListEntity);
                    MessagingCenter.Send<AddNewPurchaseListPopUpViewModel, PurchasesListEntity>(this,
                    MessagingCenterConstants.NewListWasCreated, SelectedPurchasesListEntity);
                }

                Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.PopAllAsync(); });

            }
        }
    }
}
