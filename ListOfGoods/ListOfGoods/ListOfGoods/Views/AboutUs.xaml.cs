using System;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Views.MasterDetailPage;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace ListOfGoods.Views
{
    public partial class AboutUs : ContentPage
    {
        private I_URI_Launcher _uriLauncher;
        public AboutUs()
        {
            InitializeComponent();
            _uriLauncher = DependencyService.Get<I_URI_Launcher>();
        }

        private void MoreCurrentApp_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
            _uriLauncher.LaunchURI(CommonConstants.ProductDetailAddressInStore);
        }

        private void MoreToFacts_OnTapped(object sender, EventArgs e)
        {
            (sender as View).ScaleEffect();
            _uriLauncher.LaunchURI(CommonConstants.TopFactsDetailAddressInStore);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            App.Current.MainPage.On<Xamarin.Forms.PlatformConfiguration.Windows>().SetToolbarPlacement(ToolbarPlacement.Top);
            return false;
        }
    }
}
