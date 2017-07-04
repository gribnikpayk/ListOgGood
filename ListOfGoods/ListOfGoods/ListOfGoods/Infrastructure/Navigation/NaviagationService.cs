using System;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.Resourses;
using ListOfGoods.Views.MasterDetailPage;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Page = Xamarin.Forms.Page;

namespace ListOfGoods.Infrastructure.Navigation
{
    public class NaviagationService : INavigationService
    {
        private static NavigationPage _navPage;
        public static NavigationPage CreateNavigationPage(Type pageType)
        {
            _navPage = new NavigationPage((Page)Activator.CreateInstance(pageType))
            {
                BarBackgroundColor = ColorResourses.Green,
                HeightRequest = 50,
                BarTextColor = ColorResourses.White
            };
            return _navPage;
        }

        public async Task PushAsync(Page page)
        {
            await _navPage.Navigation.PushAsync(page, false);
        }

        public void PopToRoot()
        {
            App.Current.MainPage = new MainPage();
            App.Current.MainPage.On<Xamarin.Forms.PlatformConfiguration.Windows>().SetToolbarPlacement(ToolbarPlacement.Top);
            GC.Collect();
        }
    }
}
