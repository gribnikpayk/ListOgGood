
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.ViewModels.MasterDetailPage;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.Views.MasterDetailPage
{
    public partial class MainPage : Xamarin.Forms.MasterDetailPage
    {
        private MasterPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(MasterPageViewModel), "masterPageViewModel") as MasterPageViewModel;
            BindingContext = _viewModel;
            SetMenuPanel();
            IsPresentedChanged += (sender, args) => { SetMenuPanel(); };
            Detail = NaviagationService.CreateNavigationPage(typeof(PurchasesListView));
            MasterBehavior = MasterBehavior.Popover;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItemModel)e.SelectedItem;
            (sender as ListView).SelectedItem = null;
            if (item != null)
            {
                if (item.Title == CommonNameConstants.AllListsTitle)
                {
                    Detail = NaviagationService.CreateNavigationPage(typeof(PurchasesListView));
                }
                else
                {
                    _viewModel.OpenPage(item.ListId, item.Title);
                }
                IsPresented = false;
            }

        }
        private void SetMenuPanel()
        {
            var lists = CommonConstants.AllLists != null
                ? CommonConstants.AllLists.Select(x => new MasterPageItemModel { ListId = x.Id, Title = x.Name }).ToList()
                : new List<MasterPageItemModel>();
            lists.Insert(0, new MasterPageItemModel { Title = CommonNameConstants.AllListsTitle });
            _viewModel.AllLists = lists;
        }

        #region OnTapped

        private void CreateNewList_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
            PopupNavigation.PushAsync(new AddNewPurchaseListPopUp(), false);
            IsPresented = false;
        }
        #endregion

        private void Feedback_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
            _viewModel.SendFeedback();
        }

        private void Share_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
           _viewModel.Share();
        }

        private void AboutUs_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
            IsPresented = false;
            _viewModel.AboutUs();
        }
    }
}
