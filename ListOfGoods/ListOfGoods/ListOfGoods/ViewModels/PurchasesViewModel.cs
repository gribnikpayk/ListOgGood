using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Services.Media;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels
{
    public class PurchasesViewModel : BaseViewModel
    {
        private string _newPurchase;
        private bool _autoCompleteIsVisible;
        private List<AutocompletePurchaseModel> _autocompleteItems;
        private CancellationTokenSource _autoCompleteCancelTokenSource;
        private string _tempAutoCompleteSearchPhrase = string.Empty;

        private const short _minValueForAutocomplete = 2;

        private IPurchaseService _purchaseService;
        private IMediaService _mediaService;

        private ImageSource _test;
        
        public ICommand AddNewPurchaseCommand => new Command(AddNewPurchaseAsync);

        public PurchasesViewModel(IPurchaseService purchaseService, IMediaService mediaService)
        {
            _purchaseService = purchaseService;
            _mediaService = mediaService;
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
            set { SetProperty(ref _autoCompleteIsVisible, value); }
            get { return _autoCompleteIsVisible; }
        }

        public async Task SelectedAutocompleteItemProcess(AutocompletePurchaseModel purchase)
        {
            AutoCompleteIsVisible = false;
            NewPurchase = purchase.Name;
            var newPurchaseModel = new NewPurchaseModel
            {
                PurchaseName = purchase.Name,
                ImageSource = purchase.ImageSource
            };
            await PopupNavigation.PushAsync(new AddNewPurchasePopUp(newPurchaseModel));
        }

        private async void AddNewPurchaseAsync()
        {
            var newPurchaseModel = new NewPurchaseModel
            {
                PurchaseName = NewPurchase,
                ImageSource = null
            };
            await PopupNavigation.PushAsync(new AddNewPurchasePopUp(newPurchaseModel));
        }
        private void SearchTextChanged(CancellationToken token)
        {
            Task.Delay(50, token).ContinueWith(tsk =>
            {
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
    }
}
