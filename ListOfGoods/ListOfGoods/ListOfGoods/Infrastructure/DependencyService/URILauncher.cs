using System.Threading.Tasks;

namespace ListOfGoods.Infrastructure.DependencyService
{
    public interface I_URI_Launcher
    {
        Task<bool> LaunchURI(string uri);
    }
}
