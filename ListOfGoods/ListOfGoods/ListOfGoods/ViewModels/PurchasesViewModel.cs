using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Services.Purchase;

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

        public PurchasesViewModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
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
