using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.ViewModels;
using ListOfGoods.ViewModels.PopUps;
using Xamarin.Forms;

namespace ListOfGoods.Views
{
    public partial class PurchasesListView : ContentPage
    {
        private PurchasesListViewModel _viewModel;
        public PurchasesListView()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(PurchasesListViewModel), "purchasesListViewModel") as PurchasesListViewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AddNewPurchaseListPopUpViewModel, PurchasesListEntity>(this, MessagingCenterConstants.NewListWasCreated,
                (e, list) =>
                {
                    _viewModel.PurchasesLists.Add(list);
                    _viewModel.SetPageState();
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AddNewPurchaseListPopUpViewModel, PurchasesListEntity>(this, MessagingCenterConstants.NewListWasCreated);
        }
    }
}
