using System;
using System.Threading.Tasks;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.UWP.DependencyServices;
using Microsoft.Services.Store.Engagement;
using Xamarin.Forms;

[assembly: Dependency(typeof(StoreServicesFeedback))]
namespace ListOfGoods.UWP.DependencyServices
{
    public class StoreServicesFeedback : IStoreServicesFeedback
    {
        public async Task LaunchFeedbackAsync()
        {
            var feedback = StoreServicesFeedbackLauncher.GetDefault();
            await feedback.LaunchAsync();
        }

        public bool StoreServicesFeedbackIsSupported()
        {
            return StoreServicesFeedbackLauncher.IsSupported();
        }
    }
}
