using System.Linq;
using AngleSharp.Dom.Css;
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

        private Label _count, _priceDescription, _name;
        private Image _icon;
        private Grid _grid;
        public PurchaseGrid(PurchaseEntity purchase, UsersPurchaseEntity usersPurchase)
        {
            Purchase = purchase;
            UsersPurchase = usersPurchase;
            _grid = this;

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

            _icon = new Image
            {
                IsOpaque = false,
                WidthRequest = 50,
                HeightRequest = 50,
                VerticalOptions = LayoutOptions.Center,
                Source = purchase.IsCustomImage ? purchase.ImagePath : purchase.ImagePath.ToPlatformImagePath()
            };
            _count = string.IsNullOrEmpty(usersPurchase.Quantity)
                ? null
                : new Label
                {
                    Text = $"{usersPurchase.Quantity} {CommonNameConstants.MeasurementsDictionary.FirstOrDefault(x => (int)x.Key == usersPurchase.MesurementType).Value}",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End
                };
            _priceDescription = string.IsNullOrEmpty(usersPurchase.Price)
                ? null
                : new Label
                {
                    Text = $"{usersPurchase.Price} {CommonNameConstants.CurrencyDictionary.FirstOrDefault(x => (int)x.Key == usersPurchase.CurrencyType).Value}",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start
                };
            _name = new Label
            {
                Text = purchase.Name,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            var moreIcon = new Image
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

            Children.Add(_icon, 0, 0);
            SetRowSpan(_icon, 2);
            Children.Add(_name, 1, 0);
            SetRowSpan(_name, 2);
            Children.Add(moreIcon, 3, 0);
            SetRowSpan(moreIcon, 2);
            if (_count != null)
            {
                Children.Add(_count, 2, 0);
            }
            if (_priceDescription != null)
            {
                Children.Add(_priceDescription, 2, 1);
            }
            LabelColor = UsersPurchase.IsAlreadyPurchased ? ColorResourses.TextColorPurchasedName : Color.White;
            IconOpacity = UsersPurchase.IsAlreadyPurchased ? 0.8 : 1;
            BackgroundColorOfGrid = UsersPurchase.IsAlreadyPurchased ? ColorResourses.BackgroundPurchased : ColorResourses.Grey;
        }


        #region LabelColor
        private Color _labelColor;
        public Color LabelColor
        {
            get { return _labelColor; }
            set
            {
                _labelColor = value;
                LabelColorChanged(value);
            }
        }

        private void LabelColorChanged(Color newValue)
        {
            if (_count != null)
            {
                _count.TextColor = newValue;
            }
            if (_priceDescription != null)
            {
                _priceDescription.TextColor = newValue;
            }
            _name.TextColor = newValue;
        }
        #endregion

        #region IconOpacity

        private double _iconOpacity;
        public double IconOpacity
        {
            get { return _iconOpacity; }
            set
            {
                _iconOpacity = value;
                _icon.Opacity = value;
            }
        }

        #endregion

        #region BackgroundColorOfGrid
        private Color _backgroundColorOfGrid;
        public Color BackgroundColorOfGrid
        {
            get { return _backgroundColorOfGrid; }
            set
            {
                _backgroundColorOfGrid = value;
                _grid.BackgroundColor = value;
            }
        }
        #endregion
    }
}
