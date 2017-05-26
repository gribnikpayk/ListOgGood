using ListOfGoods.CustomControls;
using ListOfGoods.UWP.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Thickness = Windows.UI.Xaml.Thickness;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace ListOfGoods.UWP.CustomRendererControls
{
    public class CustomPickerRenderer:PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderThickness = new  Thickness(0);
                Control.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Picker));
            }
        }
    }
}
