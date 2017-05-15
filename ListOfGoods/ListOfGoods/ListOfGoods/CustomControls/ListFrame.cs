using System;
using System.Threading.Tasks;
using ListOfGoods.DataManagers.Local.Purchase;
using ListOfGoods.Infrastructure.Animations;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.Extensions;
using ListOfGoods.Infrastructure.Navigation;
using ListOfGoods.Infrastructure.Resourses;
using ListOfGoods.Views;
using ListOfGoods.Views.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class ListFrame : CustomFrame
    {
        private static readonly short _gridHeight = 30;
        private static readonly double _mediumFontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        private static readonly double _smallFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ListFrame(PurchasesListEntity listEntity)
        {
            Id = listEntity.Id;
            Name = listEntity.Name;
            CreationDate = listEntity.CreationDate;

            InlineColor = ColorResourses.FrameBackground;
            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(_gridHeight, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(_gridHeight, GridUnitType.Absolute)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(8,GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };
            var lbl_name = new Label
            {
                TextColor = Color.White,
                Text = listEntity.Name,
                FontSize = _mediumFontSize
            };
            var lbl_date = new Label
            {
                TextColor = ColorResourses.TextColorWithOpacity,
                Text = listEntity.CreationDate.ToStringFormat(),
                FontSize = _smallFontSize
            };
            var lbl_counter = new Label
            {
                TextColor = ColorResourses.TextColorWithOpacity,
                Text = "0/2",
                FontSize = _smallFontSize,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };
            var img_actions = new Image
            {
                Source = "more_icon.png".ToPlatformImagePath(),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };
            img_actions.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    Task.Run(() => { img_actions.ScaleEffect(); });
                    await PopupNavigation.PushAsync(new ListActions(this));
                })
            });
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    this.ScaleEffect();
                    MessagingCenter.Send<ListFrame, int>(this, MessagingCenterConstants.NavigateTo, Id);
                })
            });

            grid.Children.Add(lbl_name, 0, 0);
            grid.Children.Add(lbl_counter, 2, 0);
            grid.Children.Add(img_actions, 3, 0);
            grid.Children.Add(lbl_date, 0, 1);

            Grid.SetRowSpan(lbl_counter, 2);
            Grid.SetRowSpan(img_actions, 2);

            Content = grid;
        }
    }
}
