using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ListOfGoods.Infrastructure.Constants;
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

        public bool ImageIconIsSeleted { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditImageCommand => new Command(ShowEditImagePopUpAsync);

        public AddNewPurchasePopUpViewModel()
        {
            SelectedIndexCategory = 0;
            SelectedIndexMesurement = 3;
        }

        public int SelectedIndexCategory
        {
            set { SetProperty(ref _selectedIndexCategory, value); }
            get { return _selectedIndexCategory; }
        }

        public int SelectedIndexMesurement
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
    }
}
