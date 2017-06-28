using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Infrastructure.Helpers;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Services.Media;
using ListOfGoods.Services.Purchase;
using ListOfGoods.Services.Search;
using ListOfGoods.Views.MasterDetailPage;
using Microsoft.Practices.Unity;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ListOfGoods
{
    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }
        public static SQLiteConnection Database = null;
        public App()
        {
            InitializeComponent();
            var databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("ListOfGoods.db");
            Database = new SQLiteConnection(databasePath);

            ResolveDependency();
            MainPage = new MainPage();
            MainPage.On<Xamarin.Forms.PlatformConfiguration.Windows>().SetToolbarPlacement(ToolbarPlacement.Top);
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
