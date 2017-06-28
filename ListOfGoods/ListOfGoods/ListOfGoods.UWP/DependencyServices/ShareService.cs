using System;
using Windows.ApplicationModel.DataTransfer;
using ListOfGoods.Infrastructure.DependencyService;
using ListOfGoods.UWP.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(ShareService))]
namespace ListOfGoods.UWP.DependencyServices
{
    public class ShareService : IShareService
    {
        private DataTransferManager _dataTransferManager = null;
        private string _title, _description, _url;
        public void Share(string title, string description, string url = "")
        {
            Init();
            _title = title;
            _description = description;
            _url = url;
            DataTransferManager.ShowShareUI();
        }

        private void Init()
        {
            if (_dataTransferManager == null)
            {
                _dataTransferManager = DataTransferManager.GetForCurrentView();
                _dataTransferManager.DataRequested += dataTransferManager_DataRequested;
            }
        }
        private void dataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataPackage dataPackage = args.Request.Data;
            dataPackage.Properties.Title = _title;
            dataPackage.SetText(_description);
        }
    }
}

