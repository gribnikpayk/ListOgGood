using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Helpers;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels
{
    public class PurchasesViewModel : BaseViewModel
    {
        private string _newPurchase;
        private double _contentWrapperOpacity;
        private bool _autoCompleteIsVisible, _purchasesFrameIsVisible, _alreadyPurchasedFrameIsVisible, _noPurchasesLabelIsVisible;
        private List<AutocompletePurchaseModel> _autocompleteItems;
        private CancellationTokenSource _autoCompleteCancelTokenSource;
        private string _tempAutoCompleteSearchPhrase = string.Empty;

        private List<PurchasesInListModel> _userPurchases;

        private const short _minValueForAutocomplete = 2;

        private IPurchaseService _purchaseService;
        private INavigationService _navigation;
        private IShareService _shareService;
        public int PurchasesListId { get; set; }

        public ICommand AddNewPurchaseCommand => new Command(AddNewPurchaseAsync);
        public ICommand HideAutocompleteCommand => new Command(() =>
        {
            AutoCompleteIsVisible = false;
            NewPurchase = string.Empty;
        });

        public PurchasesViewModel(IPurchaseService purchaseService, INavigationService navigation)
        {
            _purchaseService = purchaseService;
            _navigation = navigation;
            _shareService = DependencyService.Get<IShareService>();
        }

        #region BindableProperties

        public double ContentWrapperOpacity
        {
            set { SetProperty(ref _contentWrapperOpacity, value); }
            get { return AutoCompleteIsVisible ? 0.05 : 1; }
        }
        public bool NoPurchasesLabelIsVisible
        {
            set { SetProperty(ref _noPurchasesLabelIsVisible, value); }
            get { return _noPurchasesLabelIsVisible; }
        }
        public List<AutocompletePurchaseModel> AutocompleteItems
        {
            set { SetProperty(ref _autocompleteItems, value); }
            get { return _autocompleteItems ?? new List<AutocompletePurchaseModel>(); }
        }
        public string NewPurchase
        {
            set
            {
                SetProperty(ref _newPurchase, value);
                var newTokenSource = new CancellationTokenSource();
                _autoCompleteCancelTokenSource?.Cancel();
                SearchTextChanged(newTokenSource.Token);
                _autoCompleteCancelTokenSource?.Dispose();
                _autoCompleteCancelTokenSource = newTokenSource;
            }
            get { return _newPurchase; }
        }

        public bool AutoCompleteIsVisible
        {
            set
            {
                SetProperty(ref _autoCompleteIsVisible, value);
                ContentWrapperOpacity = _autoCompleteIsVisible ? 0.05 : 1;
            }
            get { return _autoCompleteIsVisible; }
        }

        public bool PurchasesFrameIsVisible
        {
            set { SetProperty(ref _purchasesFrameIsVisible, value); }
            get { return _purchasesFrameIsVisible; }
        }

        public bool AlreadyPurchasedFrameIsVisible
        {
            set { SetProperty(ref _alreadyPurchasedFrameIsVisible, value); }
            get { return _alreadyPurchasedFrameIsVisible; }
        }

        #endregion

        public void SetPurchasedStatus(int purchaseId, int listId, bool isAlreadyPurchased)
        {
            Task.Run(() => { _purchaseService.SetPurchasedStatus(purchaseId, listId, isAlreadyPurchased); });
        }
        public async Task<List<PurchasesInListModel>> LoadPurchases()
        {
            IsBusy = true;
            _userPurchases = new List<PurchasesInListModel>();
            await Task.Run(() =>
            {
                _userPurchases = _purchaseService.GetPurchasesByListId(PurchasesListId);
            });
            IsBusy = false;
            return _userPurchases;
        }
        public async Task SelectedAutocompleteItemProcess(AutocompletePurchaseModel purchase)
        {
            AutoCompleteIsVisible = false;
            NewPurchase = purchase.Name;
            _tempAutoCompleteSearchPhrase = NewPurchase; //для того чтобы не было поиска т.к. поиск срабатывает на изменение NewPurchase

            var newPurchaseModel = new NewPurchaseModel
            {
                PurchaseName = purchase.Name,
                ImageSource = purchase.ImageSource,
                PurchasesListId = PurchasesListId,
                PurchaseId = purchase.PurchaseId,
                Category = purchase.Category
            };
            await PopupNavigation.PushAsync(new AddNewPurchasePopUp(newPurchaseModel), false);
        }

        public void Share(string title)
        {
            var body = ShareHelper.CreatePurchasesListBodyForShare(_userPurchases);
            _shareService.Share(title, body);
        }

        public void PopToRoot()
        {
            _navigation.PopToRoot();
        }

        #region privateMethods
        private async void AddNewPurchaseAsync()
        {
            var newPurchaseModel = new NewPurchaseModel
            {
                PurchaseName = NewPurchase,
                ImageSource = null,
                PurchaseId = 0,
                PurchasesListId = PurchasesListId,
                Category = Categories.WithoutСategory
            };
            await PopupNavigation.PushAsync(new AddNewPurchasePopUp(newPurchaseModel), false);
        }
        private void SearchTextChanged(CancellationToken token)
        {
            Task.Delay(50, token).ContinueWith(tsk =>
            {
                NoPurchasesLabelIsVisible = false;
                if (!_autoCompleteCancelTokenSource.IsCancellationRequested && _tempAutoCompleteSearchPhrase != NewPurchase)
                {
                    _tempAutoCompleteSearchPhrase = NewPurchase;
                    if (NewPurchase.Length >= _minValueForAutocomplete)
                    {
                        var autocompleteItems = _purchaseService.FindAutocompletePurchases(NewPurchase);
                        AutoCompleteIsVisible = autocompleteItems.Any();
                        AutocompleteItems = autocompleteItems;
                    }
                    else
                    {
                        AutoCompleteIsVisible = false;
                    }
                }
            });
        }
        #endregion
    }
}
