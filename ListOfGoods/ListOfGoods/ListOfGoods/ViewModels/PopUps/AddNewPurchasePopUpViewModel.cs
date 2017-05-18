using System.Windows.Input;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.PopUps
{
    public class AddNewPurchasePopUpViewModel:BaseViewModel
    {
        private string _newPurchase, _quantity, _price;
        private ImageSource _purchaseIconSource;

        public ICommand AddCommand { get; set; }

        public string NewPurchase
        {
            set { SetProperty(ref _newPurchase, value); }
            get { return _newPurchase; }
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
