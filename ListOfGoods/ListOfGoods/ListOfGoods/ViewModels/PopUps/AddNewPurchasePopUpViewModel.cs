using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchasePopUpViewModel : BaseViewModel
    {
        private string _newPurchase, _quantity, _price, _selectedCategory, _selectedMesurement;
        private ImageSource _purchaseIconSource;
        private int _selectedIndexCategory, _selectedIndexMesurement;
        private List<string> _categorySource, _mesurementSource;

        public string PurchaseIconImagePath { get; set; }
        public bool ImageIconIsCustom { get; set; }
        public ICommand AddCommand => new Command(AddPurchase);
        public ICommand EditImageCommand => new Command(ShowEditImagePopUpAsync);

        private IPurchaseService _purchaseService;

        public AddNewPurchasePopUpViewModel(IPurchaseService purchaseService)
        {
            SelectedIndexCategory = 0;
            SelectedIndexOfMesurement = 3;
            _purchaseService = purchaseService;
        }

        public int SelectedIndexCategory
        {
            set { SetProperty(ref _selectedIndexCategory, value); }
            get { return _selectedIndexCategory; }
        }

        public int SelectedIndexOfMesurement
        {
            set { SetProperty(ref _selectedIndexMesurement, value); }
            get { return _selectedIndexMesurement; }
        }
        public string NewPurchase
        {
            set { SetProperty(ref _newPurchase, value); }
            get { return _newPurchase; }
        }

        public List<string> CategorySource
        {
            set { SetProperty(ref _categorySource, value); }
            get { return CommonNameConstants.CategoriesDictionary.Select(x => x.Value).ToList(); }
        }
        public string SelectedCategory
        {
            set { SetProperty(ref _selectedCategory, value); }
            get { return _selectedCategory; }
        }

        public string SelectedMesurement
        {
            set { SetProperty(ref _selectedMesurement, value); }
            get { return _selectedMesurement; }
        }

        public List<string> MesurementSource
        {
            set { SetProperty(ref _mesurementSource, value); }
            get { return CommonNameConstants.MeasurementsDictionary.Select(x => x.Value).ToList(); }
        }
        public ImageSource PurchaseIconSource
        {
            set { SetProperty(ref _purchaseIconSource, value); }
            get { return _purchaseIconSource; }
        }

        public string Quantity
        {
            set { SetProperty(ref _quantity, value); }
            get { return _quantity; }
        }

        public string Price
        {
            set { SetProperty(ref _price, value); }
            get { return _price; }
        }

        private async void ShowEditImagePopUpAsync()
        {
            await PopupNavigation.PushAsync(new EditImageActions(NewPurchase));
        }

        private void AddPurchase()
        {
            Task.Run(() =>
            {
                var DB_Purchase = _purchaseService.FindPurchaseByName(NewPurchase);
                var newPurchase = new PurchaseEntity
                {
                    Name = NewPurchase,
                    IsCustomProduct = ImageIconIsCustom, //продукт считается кастомным если для него выбрана пользовательская иконка
                    Id = DB_Purchase?.Id ?? 0,
                    ImagePath = ImageIconIsCustom ? PurchaseIconImagePath : string.Empty
                };
                _purchaseService.SavePurchase(newPurchase); //добавить / обновить продукт в общую базу товаров 
            });
        }
    }
}
