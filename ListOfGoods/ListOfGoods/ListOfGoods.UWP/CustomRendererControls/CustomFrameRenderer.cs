using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ListOfGoods.CustomControls;
using ListOfGoods.UWP.CustomRendererControls;
using Xamarin.Forms.Platform.UWP;
using Color = Xamarin.Forms.Color;


[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace ListOfGoods.UWP.CustomRendererControls
{
    public class CustomFrameRenderer : ViewRenderer<CustomFrame, Border>
    {

        private CustomFrame _control;
        public CustomFrameRenderer()
        {
            base.AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomFrame> e)
        {
            base.OnElementChanged(e);
            _control = e.NewElement as CustomFrame;
            var border = new Border { Background = new SolidColorBrush(ToMediaColor(_control.InlineColor)) };

            base.SetNativeControl(border);
            this.PackChild();

            this.UpdateBorder(_control.BorderWidth, _control.BorderRadius);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Content")
            {
                this.PackChild();
                return;
            }
            if (e.PropertyName == CustomFrame.OutlineColorProperty.PropertyName || e.PropertyName == CustomFrame.BorderWidthProperty.PropertyName)
            {
                this.UpdateBorder(_control.BorderWidth, _control.BorderRadius);
            }
        }

        private void PackChild()
        {
            if (base.Element.Content == null)
            {
                return;
            }
            Platform.SetRenderer(base.Element.Content, Platform.CreateRenderer(base.Element.Content));
            UIElement containerElement = Platform.GetRenderer(base.Element.Content).ContainerElement;
            base.Control.Child = containerElement;
        }

        private void UpdateBorder(int borderWidth, int borderRadius)
        {
            base.Control.CornerRadius = new CornerRadius(borderRadius);
            if (base.Element.OutlineColor == Color.Default)
            {
                Xamarin.Forms.Color borderColor = new Xamarin.Forms.Color(0, 0, 0, 0);
                base.Control.BorderBrush = ToBrush(borderColor);
                return;
            }
            base.Control.BorderBrush = ToBrush(Element.OutlineColor);
            base.Control.BorderThickness = new Thickness(borderWidth);
        }

        public static Brush ToBrush(Xamarin.Forms.Color color)
        {
            return new SolidColorBrush(ToMediaColor(color));
        }

        public static Windows.UI.Color ToMediaColor(Xamarin.Forms.Color color)
        {
            return Windows.UI.Color.FromArgb(((byte)(color.A * 255)), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
}