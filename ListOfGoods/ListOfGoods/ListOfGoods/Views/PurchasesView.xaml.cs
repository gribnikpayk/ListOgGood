using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels;
using Xamarin.Forms;

namespace ListOfGoods.Views
{
    public partial class PurchasesView : ContentPage
    {
        private PurchasesViewModel _viewModel;
        public PurchasesView()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(PurchasesViewModel), "purchasesViewModel") as PurchasesViewModel;
            BindingContext = _viewModel;
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AutocompletePurchaseModel;
            if (item != null)
            {
                _viewModel.SelectedAutocompleteItemProcess(item);
            }
            (sender as ListView).SelectedItem = null;
        }
    }
}
