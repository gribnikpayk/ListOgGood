using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Services.Purchase;
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
            Container.RegisterType<IPurchaseRepository, PurchaseRepository>();
            Container.RegisterType<IPurchasesListRepository, PurchasesListRepository>();
            Container.RegisterType<IPurchaseService, PurchaseService>();
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
