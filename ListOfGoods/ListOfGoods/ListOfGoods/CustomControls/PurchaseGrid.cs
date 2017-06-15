using System.Linq;
using FFImageLoading.Forms;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Resourses;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class PurchaseGrid : Grid
    {
        public PurchaseEntity Purchase { get; set; }
        public UsersPurchaseEntity UsersPurchase { get; set; }
        public PurchaseGrid(PurchaseEntity purchase, UsersPurchaseEntity usersPurchase)
        {
            BackgroundColor = ColorResourses.Grey;
            Purchase = purchase;
            UsersPurchase = usersPurchase;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition {Width = 50},
                new ColumnDefinition {Width = GridLength.Star},
                new ColumnDefinition {Width = 80},
                new ColumnDefinition {Width = 50}
            };
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition {Height = 30},
                new RowDefinition {Height = 30}
            };

            var icon = new CachedImage
            {
                IsOpaque = false,
                WidthRequest = 50,
                HeightRequest = 50,
                VerticalOptions = LayoutOptions.Center,
                Source = purchase.IsCustomImage ? purchase.ImagePath : purchase.ImagePath.ToPlatformImagePath()
            };
            var count = string.IsNullOrEmpty(usersPurchase.Quantity)
                ? null
                : new Label
                {
                    Text = $"{usersPurchase.Quantity} {CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => (int)x.Key == usersPurchase.MesurementType).Value}",
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End
                };
            var priceDescription = string.IsNullOrEmpty(usersPurchase.Price)
                ? null
                : new Label
                {
                    Text = $"{usersPurchase.Price} {CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => (int)x.Key == usersPurchase.CurrencyType).Value}",
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start
                };
            var name = new Label
            {
                Text = purchase.Name,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            var moreIcon = new CachedImage
            {
                Source = "more_icon.png".ToPlatformImagePath(),
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 30,
                HeightRequest = 30,
            };
            moreIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    moreIcon.ScaleEffect();
                    await PopupNavigation.PushAsync(new PurchaseActionsPopUp(this));
                })
            });

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    MessagingCenter.Send<PurchaseGrid, PurchaseGrid>(this, UsersPurchase.IsAlreadyPurchased
                            ? MessagingCenterConstants.BackToList
                            : MessagingCenterConstants.MarkAsPurchased, this);
                })
            });

            Children.Add(icon, 0, 0);
            SetRowSpan(icon, 2);
            Children.Add(name, 1, 0);
            SetRowSpan(name, 2);
            Children.Add(moreIcon, 3, 0);
            SetRowSpan(moreIcon, 2);
            if (count != null)
            {
                Children.Add(count, 2, 0);
            }
            if (priceDescription != null)
            {
                Children.Add(priceDescription, 2, 1);
            }
        }
    }
}
