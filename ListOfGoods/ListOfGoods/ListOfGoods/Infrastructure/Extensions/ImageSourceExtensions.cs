using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Extensions
{
    public static class ImageSourceExtensions
    {
        public static string ToPlatformImagePath(this string path)
        {
            return Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone
                ? $"Assets/{path}"
                : path;
        }
    }
}
