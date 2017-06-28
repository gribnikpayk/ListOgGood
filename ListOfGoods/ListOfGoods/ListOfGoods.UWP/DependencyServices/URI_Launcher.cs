using System;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.UWP.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(URI_Launcher))]
namespace ListOfGoods.UWP.DependencyServices
{
    public class URI_Launcher : I_URI_Launcher
    {
        public async Task<bool> LaunchURI(string uriString)
        {
            var uri = new Uri(uriString);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            return success;
        }
    }
}
