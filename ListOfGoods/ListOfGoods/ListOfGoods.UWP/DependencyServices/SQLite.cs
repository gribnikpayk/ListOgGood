using System.IO;
using Windows.Storage;
using ListOfGoods.Infrastructure.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(ListOfGoods.UWP.DependencyServices.SQLite))]
namespace ListOfGoods.UWP.DependencyServices
{
    public class SQLite : ISQLite
    {
        public SQLite() { }
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}