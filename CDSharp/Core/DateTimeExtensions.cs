using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;


namespace BMW.Models
{
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this HtmlHelper helper, DateTime source)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(source, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
        }

        public static string ToLocalTimeStr(this HtmlHelper helper, DateTime source)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(source, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")).ToString("HH:mm");
        }

        public static string ToLocalTimeStr(this DateTime helper)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(helper, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")).ToString("HH:mm");
        }
    }
}
