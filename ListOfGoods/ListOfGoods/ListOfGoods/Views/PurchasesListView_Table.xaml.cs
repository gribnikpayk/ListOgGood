using System.Linq;
using System.Threading.Tasks;
using ListOfGoods.CustomControls;
using ListOfGoods.DataManagers.Local.Settings;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.ViewModels;
using ListOfGoods.ViewModels.PopUps;
using ListOfGoods.Views.PopUps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListOfGoods.Views
{
    public partial class PurchasesListView_Table : ContentPage
    {
        private PurchasesListViewModel _viewModel;
        public PurchasesListView_Table()
        {
            InitializeComponent();

            _viewModel = App.Container.Resolve(typeof(PurchasesListViewModel), "purchasesListViewModel") as PurchasesListViewModel;
            _viewModel.IsBusy = true;
            BindingContext = _viewModel;

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Add a new list",
                Icon = "addIcon_2.png".ToPlatformImagePath(),
                Command = _viewModel.AddNewList
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Сhange view",
                Icon = "listViewIcon.png".ToPlatformImagePath(),
                Command = new Command(() => { _viewModel.UpdateSettings(new SettingsEntity { IsTableView = false }); })
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AddNewPurchaseListPopUpViewModel, ListModel>(this, MessagingCenterConstants.NewListWasCreated,
                (e, list) =>
                {
                    if (_viewModel.PurchasesLists.All(x => x.Id != list.Id))
                    {
                        _viewModel.PurchasesLists.Add(list);
                    }
                    else
                    {
                        UpdateFrame(list);
                    }
                    _viewModel.SetPageState();
                });
            MessagingCenter.Subscribe<PurchasesListViewModel>(this, MessagingCenterConstants.InitLists, InitPage);
            MessagingCenter.Subscribe<ListActions, int>(this, MessagingCenterConstants.InitLists, (sender, args) =>
            {
                var entity = _viewModel.PurchasesLists.FirstOrDefault(x => x.Id == args);
                _viewModel.PurchasesLists.Remove(entity);
                InitPage(sender);
            });
            MessagingCenter.Subscribe<ListFrame, ListModel>(this, MessagingCenterConstants.NavigateTo, async (sender, listModel) =>
            {
                await _viewModel.NavigateToPurchasePage(listModel);
            });
            Task.Run(() => { _viewModel.SetPageState(); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AddNewPurchaseListPopUpViewModel, ListModel>(this, MessagingCenterConstants.NewListWasCreated);
            MessagingCenter.Unsubscribe<PurchasesListViewModel>(this, MessagingCenterConstants.InitLists);
            MessagingCenter.Unsubscribe<ListActions, int>(this, MessagingCenterConstants.InitLists);
            MessagingCenter.Unsubscribe<ListFrame, ListModel>(this, MessagingCenterConstants.NavigateTo);
        }

        private void InitPage(object sender)
        {
            if (CommonConstants.IsNeedToClearChildrenOnLayout)
            {
                ClearFrames();
                CommonConstants.IsNeedToClearChildrenOnLayout = false;
            }
            var renderedFrames = ContentWrapper.Children.Where(x => (x as ListFrame) != null);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (renderedFrames.Count() > _viewModel.PurchasesLists.Count) //списки были удалены, нужно обновить страницу
                {
                    RemoveDeletedFrames();
                }
                else
                {
                    AddFrames();
                }
                _viewModel.IsBusy = false;
            });
        }

        private async void RemoveDeletedFrames()
        {
            var purchasesListsIds = _viewModel.PurchasesLists.Select(x => x.Id);
            var deletedFrames = ContentWrapper.Children.Where(x => (x is ListFrame) && !purchasesListsIds.Contains((x as ListFrame).ListModel.Id)).ToList();
            foreach (var deletedFrame in deletedFrames)
            {
                deletedFrame.FadeTo(0, 100);
                await deletedFrame.TranslateTo(0, 100);
                ContentWrapper.Children.Remove(deletedFrame);
            }
        }

        private void AddFrames()
        {
            var frames = _viewModel.PurchasesLists.Select(x => x.ToListFrame());
            foreach (var listFrame in frames)
            {
                if (!ContentWrapper.Children.Any(x => (x as ListFrame) != null && (x as ListFrame).ListModel.Id == listFrame.ListModel.Id))
                {
                    //listFrame.Opacity = 0;
                    //listFrame.TranslationY = -150;
                    ContentWrapper.Children.Add(listFrame);
                    //listFrame.ItemAddToListAffect();
                }
            }
        }

        private async void UpdateFrame(ListModel listEntity)
        {
            var targetFrame = ContentWrapper.Children.FirstOrDefault(x => (x is ListFrame) && (x as ListFrame).ListModel.Id == listEntity.Id);
            var targetIndex = ContentWrapper.Children.IndexOf(targetFrame);
            var updatedFrame = new ListFrame(listEntity);
            updatedFrame.Opacity = 0;
            updatedFrame.TranslationY = -150;
            Device.BeginInvokeOnMainThread(() =>
            {
                ContentWrapper.Children.Insert(targetIndex, updatedFrame);
            });
            updatedFrame.ItemAddToListAffect();
            targetFrame.FadeTo(0, 100);
            await targetFrame.TranslateTo(0, 100);
            ContentWrapper.Children.Remove(targetFrame);
        }

        private void ClearFrames()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ContentWrapper.Children.Clear();
            });
        }
    }
}