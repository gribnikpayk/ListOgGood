using FFImageLoading.Forms;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Enums;
using ListOfGoods.Infrastructure.Extensions;
using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class PurchaseGrid : Grid
    {
        public bool IsAlreadyPurchased { get; set; }
        public int Id { get; set; }
        public Categories Category { get; set; }
        public PurchaseGrid(PurchaseEntity purchase)
        {
            Category = (Categories) purchase.CategoryType;
            Id = purchase.Id;
            IsAlreadyPurchased = purchase.IsAlreadyPurchased;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition {Width = 50},
                new ColumnDefinition {Width = GridLength.Auto},
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
            var count = string.IsNullOrEmpty(purchase.QuantityDescription)
                ? null
                : new Label
                {
                    Text = purchase.QuantityDescription,
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End
                };
            var priceDescription = string.IsNullOrEmpty(purchase.PriceDescription)
                ? null
                : new Label
                {
                    Text = purchase.PriceDescription,
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
                HeightRequest = 30
            };
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
