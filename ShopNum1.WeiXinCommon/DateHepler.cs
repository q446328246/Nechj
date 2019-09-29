using System;

namespace ShopNum1.WeiXinCommon
{
    public class DateHepler
    {
        public static int ConvertDateTimeInt(DateTime time)
        {
            DateTime time2 = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7b2, 1, 1));
            TimeSpan span = (time - time2);
            return (int) span.TotalSeconds;
        }

        public static DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7b2, 1, 1));
            long ticks = long.Parse(timeStamp + "0000000");
            var span = new TimeSpan(ticks);
            return time.Add(span);
        }
    }
}