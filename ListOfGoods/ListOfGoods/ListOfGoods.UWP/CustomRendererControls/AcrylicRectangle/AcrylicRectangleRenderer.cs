using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using ListOfGoods.CustomControls;
using ListOfGoods.UWP.CustomRendererControls.AcrylicRectangle;
using ListOfGoods.UWP.Extensions;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(AcrylicRectangle), typeof(AcrylicRectangleRenderer))]
namespace ListOfGoods.UWP.CustomRendererControls.AcrylicRectangle
{
    public class AcrylicRectangleRenderer : ViewRenderer<ListOfGoods.CustomControls.AcrylicRectangle, Rectangle>
    {
        private CustomControls.AcrylicRectangle _control;

        protected override void OnElementChanged(ElementChangedEventArgs<ListOfGoods.CustomControls.AcrylicRectangle> e)
        {
            base.OnElementChanged(e);
            _control = e.NewElement as CustomControls.AcrylicRectangle;

            if (e.NewElement != null)
            {
                CreateControl();
            }
        }

        private void CreateControl()
        {
            SetNativeControl(GetNativeRectangle());
        }



        private Rectangle GetNativeRectangle()
        {
            var rectangle = new Rectangle();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
            {
                Windows.UI.Xaml.Media.AcrylicBrush brush = new Windows.UI.Xaml.Media.AcrylicBrush();
                brush.BackgroundSource = GetBackgroundSource(_control.BackSource);
                brush.TintColor = ColorExtensions.ToUwpColor(_control.TintColor);
                brush.FallbackColor = ColorExtensions.ToUwpColor(_control.FallbackColor);
                brush.TintOpacity = _control.TintOpacity;

                rectangle.Fill = brush;
            }
            else
            {
                SolidColorBrush myBrush = new SolidColorBrush(ColorExtensions.ToUwpColor(_control.TintColor));
                rectangle.Fill = myBrush;
            }

            return rectangle;
        }

        private AcrylicBackgroundSource GetBackgroundSource(
            CustomControls.AcrylicRectangle.BackgroundSource backgroundSource)
        {
            switch (backgroundSource)
            {
                case CustomControls.AcrylicRectangle.BackgroundSource.Backdrop:
                    return Windows.UI.Xaml.Media.AcrylicBackgroundSource.Backdrop;
                case CustomControls.AcrylicRectangle.BackgroundSource.HostBackdrop:
                    return Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
                default:
                    return Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
            }
        }
    }
}
