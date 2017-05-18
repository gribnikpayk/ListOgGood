using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using ListOfGoods.CustomControls;
using ListOfGoods.UWP.CustomRendererControls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ListOfGoods.UWP.CustomRendererControls
{
    public class CustomEntryRenderer:EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.BorderThickness = new Thickness(0);
            }
        }
    }
}
