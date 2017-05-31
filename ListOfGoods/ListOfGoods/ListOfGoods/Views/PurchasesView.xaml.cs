using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels;
using Xamarin.Forms;

namespace ListOfGoods.Views
{
    public partial class PurchasesView : ContentPage
    {
        private PurchasesViewModel _viewModel;
        public PurchasesView(int purchasesListId)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(PurchasesViewModel), "purchasesViewModel") as PurchasesViewModel;
            BindingContext = _viewModel;
            _viewModel.PurchasesListId = purchasesListId;
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AutocompletePurchaseModel;
            (sender as ListView).SelectedItem = null;
            if (item != null)
            {
                await _viewModel.SelectedAutocompleteItemProcess(item);
            }
        }
    }
}
