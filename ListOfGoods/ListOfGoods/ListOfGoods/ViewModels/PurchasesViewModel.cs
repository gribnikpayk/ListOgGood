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

        public ICommand TakePhotoFromGallery => new Command(async () =>
        {
            var s = await _mediaService.TakePhotoFromGalleryAsync();
            var path = await DependencyService.Get<IImageProcessor>().GetCroppedImagePathAsync(s, "test", 50);
            Test = ImageSource.FromFile(path);
        });

        public ICommand TakePhotoFromCamera => new Command(async () =>
        {
            var s = await _mediaService.TakePhotoFromCameraAsync();
            var path = await DependencyService.Get<IImageProcessor>().GetCroppedImagePathAsync(s, "test", 50);
            Test = ImageSource.FromFile(path);
            //var bytes = ReadFully(stream);
            //Test = ImageSource.FromStream(() => new MemoryStream(bytes));
            var ss = s;
            //BitmapIma
        });

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }

        }

        public PurchasesViewModel(IPurchaseService purchaseService, IMediaService mediaService)
        {
            _purchaseService = purchaseService;
            _mediaService = mediaService;
        }

        public ImageSource Test
        {
            set { SetProperty(ref _test, value); }
            get { return _test; }
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
