using System;
namespace FyUtils {
    public class TimeUtils {
        private const string DefaultFormat = "yyyy-MM-dd HH:mm:ss";

        private static DateTime UnixTime {
            get {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }

        public static long CurrentTimestamp {
            get {
                return GetTimestampFromDateTime(DateTime.UtcNow);
            }
        }

        public static DateTime GetDateTimeFromTimestamp(long timestamp) {
            return UnixTime.AddSeconds(timestamp);
        }

        public static long GetTimestampFromDateTime(DateTime dateTime) {
            return Convert.ToInt64((dateTime - UnixTime).TotalSeconds);
        }

        public static string GetStringFromTimestamp(long timestamp, string format = DefaultFormat) {
            return GetStringFromDateTime(GetDateTimeFromTimestamp(timestamp), format);
        }

        public static string GetStringFromDateTime(DateTime dateTime, string format = DefaultFormat) {
            return dateTime.ToString(format);
        }

        public static bool IsToday(long timestamp) {
            return IsSameDay(CurrentTimestamp, timestamp);
        }

        public static bool IsToday(DateTime dateTime) {
            return IsSameDay(DateTime.UtcNow, dateTime);
        }

        public static bool IsSameDay(long timestamp1, long timestamp2) {
            DateTime dateTime1 = GetDateTimeFromTimestamp(timestamp1);
            DateTime dateTime2 = GetDateTimeFromTimestamp(timestamp2);

            return IsSameDay(dateTime1, dateTime2);
        }

        public static bool IsSameDay(DateTime dateTime1, DateTime dateTime2) {
            return (dateTime1.DayOfYear == dateTime2.DayOfYear && dateTime1.Year == dateTime2.Year);
        }

        public static bool IsLeapYear(long timestamp) {
            return IsLeapYear(GetDateTimeFromTimestamp(timestamp));
        }

        public static bool IsLeapYear(DateTime dateTime) {
            return (dateTime.Year % 4 == 0 && dateTime.Year % 100 != 0) || dateTime.Year % 400 == 0;
        }
    }
}
