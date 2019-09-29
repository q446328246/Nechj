using System;

namespace ShopNum1.Common
{
    public static class UnixDateTimeHelper
    {
        private static readonly DateTime _epoch = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime _epochLimit = new DateTime(0x7f6, 1, 0x13, 3, 14, 7, 0, DateTimeKind.Utc);

        public static DateTime ConvertFromUnixTimestamp(int timestamp)
        {
            DateTime time2 = _epoch + TimeSpan.FromSeconds(timestamp);
            return time2.ToLocalTime();
        }

        public static int ConvertToUnixTimestamp(DateTime dateTime)
        {
            TimeSpan span = (dateTime.ToUniversalTime() - _epoch);
            return Convert.ToInt32(Math.Floor(span.TotalSeconds));
        }
    }
}