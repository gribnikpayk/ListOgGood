using System.Collections.Generic;
using ListOfGoods.CustomControls;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.ViewModels.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.Views.PopUps
{
    public partial class EditImageActions : PopupPage
    {
        private EditImageActionsPopUpViewModel _viewModel;
        private ListFrame _selectedList;
        public EditImageActions(string purchaseName)
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(EditImageActionsPopUpViewModel), "editImageActionsPopUpViewModel") as EditImageActionsPopUpViewModel;
            _viewModel.PurchaseName = purchaseName;
            BindingContext = _viewModel;
            ActionsListView.ItemsSource = new List<object>
            {
                new ListViewItem {Name=CommonNameConstants.GalleryActionName},
                new ListViewItem {Name=CommonNameConstants.CameraActionName},
                new ListViewItem {Name=CommonNameConstants.InternetActionName}
            };
        }

        private async void ActionsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await PopupNavigation.PopAsync(false);
            ListViewItem selectedItem = e.SelectedItem as ListViewItem;
            switch (selectedItem.Name)
            {
                case CommonNameConstants.GalleryActionName:
                    _viewModel.TakePhotoFromGallery.Execute(null);
                    break;
                case CommonNameConstants.CameraActionName:
                    _viewModel.TakePhotoFromCamera.Execute(null);
                    break;
                case CommonNameConstants.InternetActionName:
                    _viewModel.TakePhotoFromInternet.Execute(null);
                    break;
                default:
                    break;
            }
        }
        private class ListViewItem
        {
            public string Name { get; set; }
        }
    }
}
