using System;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using Xamarin.Forms;

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
    }
}
