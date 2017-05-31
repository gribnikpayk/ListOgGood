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

        public static string ToAutocompleteImagePath(this string fileName)
        {
            return Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone
                ? $"Assets/{fileName}"
                : $"{fileName}";
        }

        public static string ToCategoryIconImageSource(this string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryName = categoryName.Replace(" ", string.Empty);
            }
            return Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone
                ? $"Assets/{categoryName}_icon.png"
                : $"{categoryName}_icon.png";
        }
    }
}
