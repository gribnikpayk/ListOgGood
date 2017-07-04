using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Navigation
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        void PopToRoot();
    }
}
