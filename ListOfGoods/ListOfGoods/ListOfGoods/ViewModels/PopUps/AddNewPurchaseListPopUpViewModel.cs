using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchaseListPopUpViewModel : BaseViewModel
    {
        private string _listName;
        private bool _errorMessageIsVisible;
        public ICommand AddNewListCommand { get; set; }
        private IPurchasesListRepository _purchasesListRepository;

        public AddNewPurchaseListPopUpViewModel(IPurchasesListRepository purchasesListRepository)
        {
            _purchasesListRepository = purchasesListRepository;
            AddNewListCommand = new Command(AddNewList);
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
                var newList = new PurchasesListEntity
                {
                    Name = ListName
                };
                var newListId = _purchasesListRepository.Create(newList);
                newList.Id = newListId;

                Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.PopAllAsync(); });
                MessagingCenter.Send<AddNewPurchaseListPopUpViewModel, PurchasesListEntity>(this,
                    MessagingCenterConstants.NewListWasCreated, newList);
            }
        }
    }
}
