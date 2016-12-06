using System;
using System.Text.RegularExpressions;

namespace FyUtils {
    public static class RegexUtils {
        private const string RegexEmail = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        private const string RegexUrl = @"[a-zA-z]+://[^\s]*";
        private const string RegexDate = @"^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:[0-1][1-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$";
        private const string RegexTime = @"^(?:[0-1][0-9]|2[0-3]):([0-5][0-9])$";

        public static bool IsEmail(string email) {
            return IsMatch(email, RegexEmail);
        }

        public static bool IsUrl(string url) {
            return IsMatch(url, RegexUrl);
        }

        public static bool IsDate(string date) {
            return IsMatch(date, RegexDate);
        }

        public static bool IsTime(string time) {
            return IsMatch(time, RegexTime);
        }

        private static bool IsMatch(string input, string pattern) {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
