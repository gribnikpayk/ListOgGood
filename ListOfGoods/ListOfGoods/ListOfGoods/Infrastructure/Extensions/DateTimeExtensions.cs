

using System;

namespace ListOfGoods.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToStringFormat(this DateTime date)
        {
            return date.ToString("d");
        }
    }
}
