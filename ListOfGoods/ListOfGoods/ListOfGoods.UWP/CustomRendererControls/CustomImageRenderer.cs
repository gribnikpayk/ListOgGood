
using System;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

namespace ListOfGoods.UWP.CustomRendererControls
{
    public class CustomImageRenderer:ImageRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null && Control.Clip == null)
            {
                //var min = Math.Min(Element.Width, Element.Height) / 2.0f;
                //if (min <= 0)
                //    return;
                //Control.C = new EllipseGeometry
                //{
                //    Center = new System.Windows.Point(min, min),
                //    RadiusX = min,
                //    RadiusY = min
                //};
            }
        }
    }
}
