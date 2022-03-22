using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        private static string emptyDateTimeStr = "00:00:00";

        public static string GetRemaningDateStr(this DateTime ExpireDate)
        {
            if (ExpireDate == DateTime.MinValue)
                return emptyDateTimeStr;

            TimeSpan ts = ExpireDate.Subtract(DateTime.Now);

            return ts.TotalSeconds >= 0 ? ts.ToString(@"hh\:mm\:ss") : emptyDateTimeStr;
        }

        public static string ToCustomDateString(this DateTime DateTime)
        {
            return  DateTime.ToString("dd.MM.yyyy");
        }

        public static string ToCustomTimeString(this DateTime DateTime)
        {
            return DateTime.ToString("HH:mm");
        }

        public static string ToCustomDateTimeString(this DateTime DateTime)
        {
            return $"{DateTime.ToCustomDateString()} {DateTime.ToCustomTimeString()}";
        }

        public static bool IsNull(this DateTime DateTime)
        {
            return DateTime == DateTime.MinValue;
        }

        public static bool IsNull(this DateTime? DateTime)
        {
            return !DateTime.HasValue || IsNull(DateTime);
        }
    }
}
