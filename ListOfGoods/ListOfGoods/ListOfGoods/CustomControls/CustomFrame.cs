using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class CustomFrame : ContentView
    {

        public readonly static BindableProperty BorderRadiusProperty = BindableProperty.Create("BorderRadius", typeof(int), typeof(CustomFrame), 5, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty OutlineColorProperty = BindableProperty.Create("OutlineColor", typeof(Color), typeof(CustomFrame), Color.Default, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty InlineColorProperty = BindableProperty.Create("InlineColor", typeof(Color), typeof(CustomFrame), Color.Default, BindingMode.OneWay, null, null, null, null, null);

        public readonly static BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(int), typeof(CustomFrame), 2, BindingMode.OneWay, null, null, null, null, null);

        public int BorderWidth
        {
            get
            {
                return (int)base.GetValue(CustomFrame.BorderWidthProperty);
            }
            set
            {
                base.SetValue(CustomFrame.BorderWidthProperty, value);
            }
        }

        public Color OutlineColor
        {
            get
            {
                return (Color)base.GetValue(CustomFrame.OutlineColorProperty);
            }
            set
            {
                base.SetValue(CustomFrame.OutlineColorProperty, value);
            }
        }

        public Color InlineColor
        {
            get
            {
                return (Color)base.GetValue(CustomFrame.InlineColorProperty);
            }
            set
            {
                base.SetValue(CustomFrame.InlineColorProperty, value);
            }
        }

        public int BorderRadius
        {
            get
            {
                return (int)base.GetValue(CustomFrame.BorderRadiusProperty);
            }
            set
            {
                base.SetValue(CustomFrame.BorderRadiusProperty, value);
            }
        }

        public CustomFrame()
        {
            base.Padding = new Size(20, 20);
        }
    }
}