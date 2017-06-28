using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.Infrastructure.Models;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Views;
using Xamarin.Forms;

namespace ListOfGoods.ViewModels.MasterDetailPage
{
    public class MasterPageViewModel : BaseViewModel
    {
        private List<MasterPageItemModel> _allLists;
        private INavigationService _navigation;
        private IStoreServicesFeedback _feedbackService;
        private I_URI_Launcher _uriLauncher;
        private IShareService _shareService;

        public MasterPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            _feedbackService = DependencyService.Get<IStoreServicesFeedback>();
            _uriLauncher = DependencyService.Get<I_URI_Launcher>();
            _shareService = DependencyService.Get<IShareService>();
        }

        public void OpenPage(int listId, string title)
        {
            _navigation.PushAsync(new PurchasesView(listId, title));
        }

        public async Task SendFeedback()
        {
            var feedbackServiceIsSupported = _feedbackService.StoreServicesFeedbackIsSupported();
            if (feedbackServiceIsSupported)
            {
                await _feedbackService.LaunchFeedbackAsync();
            }
            else
            {
                await _uriLauncher.LaunchURI(CommonConstants.ProductReviewAddressInStore);
            }
        }

        public void Share()
        {
            _shareService.Share(CommonConstants.ApplicationName,CommonConstants.ApplicationDescription);
        }

        public void AboutUs()
        {
            _navigation.PushAsync(new AboutUs());
        }

        public List<MasterPageItemModel> AllLists
        {
            set { SetProperty(ref _allLists, value); }
            get { return _allLists; }
        }
    }
}
