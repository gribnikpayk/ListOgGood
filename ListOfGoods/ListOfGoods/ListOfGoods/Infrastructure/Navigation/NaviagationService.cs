using System;
using ListOfGoods.Infrastructure.Resourses;
using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Navigation
{
    public class NaviagationService
    {
        public static NavigationPage CreateNavigationPage(Type pageType)
        {
            return new NavigationPage((Page)Activator.CreateInstance(pageType))
            {
                BarBackgroundColor = ColorResourses.Grey,
                HeightRequest = 50,
                BarTextColor = Color.White
            };
        }
    }
}
