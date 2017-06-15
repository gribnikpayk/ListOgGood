using System.Linq;
using System.Threading.Tasks;
using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels;
using ListOfGoods.ViewModels.PopUps;
using ListOfGoods.Views.PopUps;
using Xamarin.Forms;

namespace ListOfGoods.Views
{
    public partial class PurchasesView : ContentPage
    {
        private PurchasesViewModel _viewModel;
        private readonly int _translation_x = 1000;
        private readonly int _translation_y = 0;
        private readonly uint _speed = 250;

        public PurchasesView(int purchasesListId)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(PurchasesViewModel), "purchasesViewModel") as PurchasesViewModel;
            BindingContext = _viewModel;
            _viewModel.PurchasesListId = purchasesListId;
        }

        #region Appearing_Disapearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitPage();
            MessagingCenter.Subscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.DeleteAction, DeletePurchase);
            MessagingCenter.Subscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.MarkAsPurchased, MarkAsPurchased);
            MessagingCenter.Subscribe<PurchaseGrid, PurchaseGrid>(this, MessagingCenterConstants.MarkAsPurchased,
                (sender, grid) =>
                {
                    MarkAsPurchased(sender, grid);
                    _viewModel.MarkAsPurchased(grid.UsersPurchase.PurchaseId, grid.UsersPurchase.PurchasesListId);
                });
            MessagingCenter.Subscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.BackToList, BackPurchaseToList);
            MessagingCenter.Subscribe<EditPurchasePopUpViewModel, EditPurchasePostActionModel>(this, MessagingCenterConstants.EditAction, EditPurchase);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.DeleteAction);
            MessagingCenter.Unsubscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.MarkAsPurchased);
            MessagingCenter.Unsubscribe<PurchaseGrid, PurchaseGrid>(this, MessagingCenterConstants.MarkAsPurchased);
            MessagingCenter.Unsubscribe<PurchaseActionsPopUp, PurchaseGrid>(this, MessagingCenterConstants.BackToList);
            MessagingCenter.Unsubscribe<EditPurchasePopUpViewModel, EditPurchasePostActionModel>(this, MessagingCenterConstants.EditAction);
        }
        #endregion

        #region privateMethods

        private void DeletePurchase(object sender, PurchaseGrid grid)
        {
            var wrapper = GetWrapperForPurchaseGrid(grid);
            if (wrapper != null)
            {
                wrapper.Children.Remove(grid);
                wrapper.IsVisible = wrapper.Children.Count(control => control is PurchaseGrid) > 0;
            }
        }

        private async void EditPurchase(object sender, EditPurchasePostActionModel editPurchasePostActionModel)
        {
            var old_wrapper = GetWrapperForPurchaseGrid(editPurchasePostActionModel.InitialPurchaseGrid);
            var new_wrapper = GetWrapperForPurchaseGrid(editPurchasePostActionModel.NewPurchaseGrid);
            if (old_wrapper != null && new_wrapper != null)
            {
                await editPurchasePostActionModel.InitialPurchaseGrid.FadeTo(0, _speed);
                old_wrapper.Children.Remove(editPurchasePostActionModel.InitialPurchaseGrid);
                old_wrapper.IsVisible = old_wrapper.Children.Count(control => control is PurchaseGrid) > 0;

                editPurchasePostActionModel.NewPurchaseGrid.Opacity = 0;
                new_wrapper.Children.Add(editPurchasePostActionModel.NewPurchaseGrid);
                new_wrapper.IsVisible = true;
                await editPurchasePostActionModel.NewPurchaseGrid.FadeTo(1, _speed);
            }
        }

        private async void MarkAsPurchased(object sender, PurchaseGrid grid)
        {
            var wrapper = GetWrapperForPurchaseGrid(grid);
            if (wrapper != null)
            {
                await grid.FadeTo(0, _speed);
                wrapper.Children.Remove(grid);
                wrapper.IsVisible = wrapper.Children.Count(control => control is PurchaseGrid) > 0;
                grid.UsersPurchase.IsAlreadyPurchased = true;
                grid.Opacity = 0;
                IsAlreadyPurchasedWrapper.Children.Add(grid);
                IsAlreadyPurchasedWrapper.IsVisible = true;
                await grid.FadeTo(1, _speed);
            }
        }

        private async void BackPurchaseToList(object sender, PurchaseGrid grid)
        {
            var wrapper = GetWrapperForPurchaseGrid((Categories)grid.UsersPurchase.CategoryType);
            if (wrapper != null)
            {
                await grid.FadeTo(0, _speed);
                IsAlreadyPurchasedWrapper.Children.Remove(grid);
                grid.UsersPurchase.IsAlreadyPurchased = false;
                grid.Opacity = 0;
                wrapper.Children.Add(grid);
                wrapper.IsVisible = true;
                await grid.FadeTo(1, _speed);
            }
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

        private void InitPage()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var purchases = await _viewModel.LoadPurchases();
                foreach (var purchase in purchases)
                {
                    var control = new PurchaseGrid(purchase.Purchase, purchase.UsersPurchaseEntity);
                    AddPurchaseGridToPage(control);
                }
            });
        }

        private void AddPurchaseGridToPage(PurchaseGrid grid)
        {
            if (grid.UsersPurchase.IsAlreadyPurchased)
            {
                _viewModel.AlreadyPurchasedFrameIsVisible = true;
                IsAlreadyPurchasedWrapper.Children.Add(grid);
            }
            else
            {
                _viewModel.PurchasesFrameIsVisible = true;
                StackLayout wrapper = GetWrapperForPurchaseGrid(grid);
                if (wrapper != null)
                {
                    wrapper.IsVisible = true;
                    wrapper.Children.Add(grid);
                }
            }
        }

        private StackLayout GetWrapperForPurchaseGrid(PurchaseGrid grid)
        {
            if (grid.UsersPurchase.IsAlreadyPurchased)
            {
                return IsAlreadyPurchasedWrapper;
            }
            else
            {
                StackLayout wrapper = null;
                switch (grid.UsersPurchase.CategoryType)
                {
                    case (int)Categories.Bakery:
                        return BakeryCategoryWrapper;
                    case (int)Categories.WithoutСategory:
                        return WithoutСategoryCategoryWrapper;
                    case (int)Categories.Chicken:
                        return ChickenCategoryWrapper;
                    case (int)Categories.Cosmetics:
                        return CosmeticsCategoryWrapper;
                    case (int)Categories.Dairy:
                        return DairyCategoryWrapper;
                    case (int)Categories.Drinks:
                        return DrinksCategoryWrapper;
                    case (int)Categories.Fish:
                        return FishCategoryWrapper;
                    case (int)Categories.Fruit:
                        return FruitCategoryWrapper;
                    case (int)Categories.Meat:
                        return MeatCategoryWrapper;
                    case (int)Categories.Vegetables:
                        return VegetablesCategoryWrapper;
                    case (int)Categories.Other:
                        return OtherCategoryWrapper;
                }
            }
            return null;
        }
        private StackLayout GetWrapperForPurchaseGrid(Categories category)
        {
            StackLayout wrapper = null;
            switch (category)
            {
                case Categories.Bakery:
                    return BakeryCategoryWrapper;
                case Categories.WithoutСategory:
                    return WithoutСategoryCategoryWrapper;
                case Categories.Chicken:
                    return ChickenCategoryWrapper;
                case Categories.Cosmetics:
                    return CosmeticsCategoryWrapper;
                case Categories.Dairy:
                    return DairyCategoryWrapper;
                case Categories.Drinks:
                    return DrinksCategoryWrapper;
                case Categories.Fish:
                    return FishCategoryWrapper;
                case Categories.Fruit:
                    return FruitCategoryWrapper;
                case Categories.Meat:
                    return MeatCategoryWrapper;
                case Categories.Vegetables:
                    return VegetablesCategoryWrapper;
                case Categories.Other:
                    return OtherCategoryWrapper;
            }
            return wrapper;
        }
    }
    #endregion
}
