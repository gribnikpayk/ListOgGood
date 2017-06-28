using System.Threading.Tasks;

namespace ListOfGoods.Infrastructure.DependencyService
{
    public interface IStoreServicesFeedback
    {
        bool StoreServicesFeedbackIsSupported();
        Task LaunchFeedbackAsync();
    }
}
