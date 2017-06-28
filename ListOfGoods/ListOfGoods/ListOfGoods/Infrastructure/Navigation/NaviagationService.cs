using System;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.Resourses;
using Xamarin.Forms;

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

        public async Task PopToRootAsync()
        {
            await _navPage.Navigation.PopToRootAsync(false);
        }
    }
}
