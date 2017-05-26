using ListOfGoods.CustomControls;
using ListOfGoods.UWP.CustomRendererControls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace ListOfGoods.UWP.CustomRendererControls
{
    public class RoundedButtonRenderer:ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.BorderRadius = 5;
            }
        }
    }
}
