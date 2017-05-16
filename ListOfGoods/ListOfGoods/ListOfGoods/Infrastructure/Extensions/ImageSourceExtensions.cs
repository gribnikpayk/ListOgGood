﻿using Xamarin.Forms;

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
            var name = fileName.Replace(' ', '_');
            return Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone
                ? $"Assets/{name}.jpg"
                : $"{name}.jpg";
        }
    }
}
