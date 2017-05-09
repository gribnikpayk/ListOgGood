
using System;
using System.Collections.Generic;
using ListOfGoods.Infrastructure.Navigation;
using Xamarin.Forms;

namespace ListOfGoods.Views.MasterDetailPage
{
    public partial class MainPage : Xamarin.Forms.MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>
            {
                new MasterPageItem {Title = "Сонник", Icon = "dreamBook_menuIcon.png", TargetType = typeof(PurchasesListView)}
            };
            navigationDrawerList.ItemsSource = menuList;
            Detail = NaviagationService.CreateNavigationPage(typeof(PurchasesListView));
            MasterBehavior = MasterBehavior.Popover;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = NaviagationService.CreateNavigationPage(page);
            IsPresented = false;
        }
    }
}
