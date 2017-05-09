using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels
{
    public class PurchasesListViewModel:BaseViewModel
    {
        private bool _noListsMessageIsVisible;
        public List<PurchasesListEntity> PurchasesLists { get; set; }
        public ICommand AddNewList { get; set; }

        private IPurchaseService _purchaseService;
        
        public PurchasesListViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
            AddNewList = new Command(async ()=> { await PopupNavigation.PushAsync(new AddNewPurchaseListPopUp()); });
            Task.Run(() =>
            {
                PurchasesLists = _purchaseService.GetAllPurchasesLists();
                Device.BeginInvokeOnMainThread(SetPageState);
            });
        }

        public void SetPageState()
        {
            if (PurchasesLists.Any())
            {
                NoListsMessageIsVisible = false;
            }
            else
            {
                NoListsMessageIsVisible = true;
            }
        }

        public bool NoListsMessageIsVisible
        {
            set { SetProperty(ref _noListsMessageIsVisible, value); }
            get { return _noListsMessageIsVisible; }
        }
    }
}
