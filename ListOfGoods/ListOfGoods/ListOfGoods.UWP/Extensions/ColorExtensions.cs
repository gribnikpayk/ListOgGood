using System;

namespace ListOfGoods.UWP.Extensions
{
    public static class ColorExtensions
    {
        public static Windows.UI.Color ToUwpColor(Xamarin.Forms.Color color)
        {
            return Windows.UI.Color.FromArgb(((byte)(color.A * 255)), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }

        public static Windows.UI.Color ToUwpColor(this string hexString)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"[#]([0-9]|[a-f]|[A-F]){6}\b"))
                throw new ArgumentException();

            //remove the # at the front
            hexString = hexString.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hexString.Length == 8)
            {
                a = byte.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hexString.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hexString.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hexString.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Windows.UI.Color.FromArgb(a, r, g, b);
        }
    }
}
