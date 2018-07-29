using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.DataManagers.Local.Settings;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Services.Search;
using ListOfGoods.Services.Settings;
using ListOfGoods.Views;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels
{
    public class PurchasesListViewModel : BaseViewModel
    {
        private bool _noListsMessageIsVisible;
        private List<ListModel> _purchasesLists;
        private bool _isTableView = true;

        public List<ListModel> PurchasesLists
        {
            get
            {
                return _purchasesLists;
            }
            set
            {
                _purchasesLists = value;
                CommonConstants.AllLists = value;
            }
        }

        public ICommand AddNewList { get; set; }

        private IPurchaseService _purchaseService;
        private INavigationService _navigation;
        private ISearchService _searchService;
        private ISettingsService _settingsService;

        public PurchasesListViewModel(INavigationService navigation,
            IPurchaseService purchaseService,
            ISearchService searchService,
            ISettingsService settingsService)
        {
            _navigation = navigation;
            _purchaseService = purchaseService;
            _searchService = searchService;
            _settingsService = settingsService;
            AddNewList = new Command(async () => { await PopupNavigation.PushAsync(new AddNewPurchaseListPopUp()); });
        }

        public void SetPageState()
        {
            if (PurchasesLists == null || CommonConstants.IsNeedToLoadPurchasesLists) //IsNeedToLoadPurchasesLists устанавливается когда пользователь жмет "back" на странице purchasesView
            {
                CommonConstants.IsNeedToLoadPurchasesLists = false;
                PurchasesLists = _purchaseService.GetAllPurchasesLists();
            }
            if (PurchasesLists.Any())
            {
                NoListsMessageIsVisible = false;
                MessagingCenter.Send<PurchasesListViewModel>(this, MessagingCenterConstants.InitLists);
            }
            else
            {
                NoListsMessageIsVisible = true;
                IsBusy = false;
            }
        }

        public bool NoListsMessageIsVisible
        {
            set { SetProperty(ref _noListsMessageIsVisible, value); }
            get { return _noListsMessageIsVisible; }
        }

        public async Task NavigateToPurchasePage(ListModel model)
        {
            await _navigation.PushAsync(new PurchasesView(model.Id, model.Name));
        }

        public void UpdateSettings(SettingsEntity settingsEntity)
        {
            var storedSettings = _settingsService.GetSettings();
            if (storedSettings != null)
            {
                settingsEntity.Id = storedSettings.Id;
            }
            _settingsService.UpdateSettings(settingsEntity);
        }
    }
}
