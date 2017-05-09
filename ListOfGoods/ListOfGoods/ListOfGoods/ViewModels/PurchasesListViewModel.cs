using System.Windows.Input;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels
{
    public class PurchasesListViewModel:BaseViewModel
    {
        private bool _noListsMessageIsVisible;
        public ICommand AddNewList { get; set; }

        public PurchasesListViewModel()
        {
            AddNewList = new Command(()=> {});
        }

        public bool NoListsMessageIsVisible
        {
            set { SetProperty(ref _noListsMessageIsVisible, value); }
            get { return _noListsMessageIsVisible; }
        }
    }
}
