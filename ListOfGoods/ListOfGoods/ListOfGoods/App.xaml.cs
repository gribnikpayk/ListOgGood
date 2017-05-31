using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Helpers;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Services.Media;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Services.Search;
using ListOfGoods.Views.MasterDetailPage;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace ListOfGoods
{
    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }
        public App()
        {
            InitializeComponent();
            ResolveDependency();
            MainPage = new MainPage();
        }

        private static void ResolveDependency()
        {
            Container = new UnityContainer();
            Container.RegisterType<INavigationService, NaviagationService>();
            Container.RegisterType<IPurchaseRepository, PurchaseRepository>();
            Container.RegisterType<IPurchasesListRepository, PurchasesListRepository>();
            Container.RegisterType<IUsersPurchaseRepository, UsersPurchaseRepository>();
            Container.RegisterType<IPurchaseService, PurchaseService>();
            Container.RegisterType<IMediaService, MediaService>();
            Container.RegisterType<ISearchService, SearchService>();
            var deploymentHelper = Container.Resolve<LocalDbDeploymentHelper>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
