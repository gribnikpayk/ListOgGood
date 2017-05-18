using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ListOfGoods.Infrastructure.Constants;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchasePopUpViewModel : BaseViewModel
    {
        private string _newPurchase, _quantity, _price, _selectedCategory, _selectedMesurement;
        private ImageSource _purchaseIconSource;
        private List<string> _categorySource, _mesurementSource;
        public ICommand AddCommand { get; set; }

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
    }
}
