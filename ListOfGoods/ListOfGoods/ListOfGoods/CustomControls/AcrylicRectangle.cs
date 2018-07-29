using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class AcrylicRectangle : ContentView
    {
        public readonly static BindableProperty TintOpacityProperty
            = BindableProperty.Create("TintOpacity", typeof(double), typeof(AcrylicRectangle), 0.6, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty TintColorProperty
            = BindableProperty.Create("TintColor", typeof(Color), typeof(AcrylicRectangle), Color.Black, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty FallbackColorProperty
            = BindableProperty.Create("FallbackColor", typeof(Color), typeof(AcrylicRectangle), Color.Black, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty BackgroundSourceProperty
            = BindableProperty.Create("BackgroundSource", typeof(AcrylicRectangle.BackgroundSource), typeof(AcrylicRectangle), AcrylicRectangle.BackgroundSource.HostBackdrop, BindingMode.OneWay, null, null, null, null, null);

        public double TintOpacity
        {
            get => (double)base.GetValue(AcrylicRectangle.TintOpacityProperty);
            set
            {
                base.SetValue(AcrylicRectangle.TintOpacityProperty, value);
            }
        }

        public Color TintColor
        {
            get => (Color)base.GetValue(AcrylicRectangle.TintColorProperty);
            set
            {
                base.SetValue(AcrylicRectangle.TintColorProperty, value);
            }
        }

        public Color FallbackColor
        {
            get => (Color)base.GetValue(AcrylicRectangle.FallbackColorProperty);
            set
            {
                base.SetValue(AcrylicRectangle.FallbackColorProperty, value);
            }
        }

        public AcrylicRectangle.BackgroundSource BackSource
        {
            get => (AcrylicRectangle.BackgroundSource)base.GetValue(AcrylicRectangle.BackgroundSourceProperty);
            set
            {
                base.SetValue(AcrylicRectangle.BackgroundSourceProperty, value);
            }
        }

        public enum BackgroundSource
        {
            HostBackdrop,
            Backdrop
        }
    }
}
