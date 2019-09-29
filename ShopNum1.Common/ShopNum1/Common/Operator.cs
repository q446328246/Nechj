using System;
using System.Text.RegularExpressions;

namespace ShopNum1.Common
{
    public static class Operator
    {
        public static bool CheckDouble(object Expression)
        {
            return ((Expression != null) && Regex.IsMatch(Expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$"));
        }

        public static bool CheckNumeric(object Expression)
        {
            if (Expression != null)
            {
                string input = Expression.ToString();
                if ((((input.Length > 0) && (input.Length <= 11)) && Regex.IsMatch(input, "^[-]?[0-9]*[.]?[0-9]*$")) &&
                    (((input.Length < 10) || ((input.Length == 10) && (input[0] == '1'))) ||
                     (((input.Length == 11) && (input[0] == '-')) && (input[1] == '1'))))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckNumericArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string str in strNumber)
            {
                if (!CheckNumeric(str))
                {
                    return false;
                }
            }
            return true;
        }

        public static int FilterInt(object strInput)
        {
            string str = "";
            try
            {
                if (strInput == null)
                {
                    str = "";
                }
                else
                {
                    str = strInput.ToString().Replace("'", "''");
                }
            }
            catch
            {
                str = "";
            }
            return Convert.ToInt32(str);
        }

        public static string FilterString(object strInput)
        {
            try
            {
                if (strInput == null)
                {
                    return "";
                }
                return
                    Regex.Replace(
                        Regex.Replace(
                            Regex.Replace(
                                Regex.Replace(
                                    Regex.Replace(
                                        Regex.Replace(
                                            Regex.Replace(
                                                Regex.Replace(
                                                    Regex.Replace(
                                                        Regex.Replace(
                                                            Regex.Replace(
                                                                Regex.Replace(
                                                                    Regex.Replace(
                                                                        Regex.Replace(
                                                                            Regex.Replace(
                                                                                Regex.Replace(
                                                                                    Regex.Replace(
                                                                                        Regex.Replace(
                                                                                            Regex.Replace(
                                                                                                Regex.Replace(
                                                                                                    Regex.Replace(
                                                                                                        Regex.Replace(
                                                                                                            Regex
                                                                                                                .Replace
                                                                                                                (Regex
                                                                                                                     .Replace
                                                                                                                     (Regex
                                                                                                                          .Replace
                                                                                                                          (Regex
                                                                                                                               .Replace
                                                                                                                               (strInput
                                                                                                                                    .ToString
                                                                                                                                    (),
                                                                                                                                "<script[^>]*?>.*?</script>",
                                                                                                                                "",
                                                                                                                                RegexOptions
                                                                                                                                    .IgnoreCase),
                                                                                                                           "<(.[^>]*)>",
                                                                                                                           "",
                                                                                                                           RegexOptions
                                                                                                                               .IgnoreCase),
                                                                                                                      "-->",
                                                                                                                      "",
                                                                                                                      RegexOptions
                                                                                                                          .IgnoreCase),
                                                                                                                 "<!--.*",
                                                                                                                 "",
                                                                                                                 RegexOptions
                                                                                                                     .IgnoreCase),
                                                                                                            "<", "",
                                                                                                            RegexOptions
                                                                                                                .IgnoreCase),
                                                                                                        ">", "",
                                                                                                        RegexOptions
                                                                                                            .IgnoreCase),
                                                                                                    "&(quot|#34);", "\"",
                                                                                                    RegexOptions
                                                                                                        .IgnoreCase),
                                                                                                "&(amp|#38);", "&",
                                                                                                RegexOptions.IgnoreCase),
                                                                                            "&(lt|#60);", "<",
                                                                                            RegexOptions.IgnoreCase),
                                                                                        "&(gt|#62);", ">",
                                                                                        RegexOptions.IgnoreCase),
                                                                                    "&(iexcl|#161);", "\x00a1",
                                                                                    RegexOptions.IgnoreCase),
                                                                                "&(cent|#162);", "\x00a2",
                                                                                RegexOptions.IgnoreCase),
                                                                            "&(pound|#163);", "\x00a3",
                                                                            RegexOptions.IgnoreCase), "&(copy|#169);",
                                                                        "\x00a9", RegexOptions.IgnoreCase), @"&#(\d+);",
                                                                    "", RegexOptions.IgnoreCase), "xp_cmdshell", "",
                                                                RegexOptions.IgnoreCase), "insert", "",
                                                            RegexOptions.IgnoreCase), "delete from", "",
                                                        RegexOptions.IgnoreCase), "count''", "", RegexOptions.IgnoreCase),
                                                "drop table", "", RegexOptions.IgnoreCase), "truncate", "",
                                            RegexOptions.IgnoreCase), "asc", "", RegexOptions.IgnoreCase), "char", "",
                                    RegexOptions.IgnoreCase), "xp_cmdshell", "", RegexOptions.IgnoreCase), "exec master",
                            "", RegexOptions.IgnoreCase), "net localgroup administrators", "", RegexOptions.IgnoreCase);
            }
            catch
            {
                return "";
            }
        }

        public static string FilterStringUrl(object strInput)
        {
            try
            {
                if (strInput == null)
                {
                    return "";
                }
                return
                    Regex.Replace(
                        Regex.Replace(
                            Regex.Replace(
                                Regex.Replace(
                                    Regex.Replace(
                                        Regex.Replace(
                                            Regex.Replace(
                                                Regex.Replace(
                                                    Regex.Replace(
                                                        Regex.Replace(
                                                            Regex.Replace(
                                                                Regex.Replace(
                                                                    Regex.Replace(
                                                                        Regex.Replace(
                                                                            Regex.Replace(
                                                                                Regex.Replace(
                                                                                    Regex.Replace(
                                                                                        Regex.Replace(
                                                                                            Regex.Replace(
                                                                                                Regex.Replace(
                                                                                                    Regex.Replace(
                                                                                                        Regex.Replace(
                                                                                                            Regex
                                                                                                                .Replace
                                                                                                                (Regex
                                                                                                                     .Replace
                                                                                                                     (Regex
                                                                                                                          .Replace
                                                                                                                          (Regex
                                                                                                                               .Replace
                                                                                                                               (strInput
                                                                                                                                    .ToString
                                                                                                                                    (),
                                                                                                                                "<script[^>]*?>.*?</script>",
                                                                                                                                "",
                                                                                                                                RegexOptions
                                                                                                                                    .IgnoreCase),
                                                                                                                           "<(.[^>]*)>",
                                                                                                                           "",
                                                                                                                           RegexOptions
                                                                                                                               .IgnoreCase),
                                                                                                                      "-->",
                                                                                                                      "",
                                                                                                                      RegexOptions
                                                                                                                          .IgnoreCase),
                                                                                                                 "<!--.*",
                                                                                                                 "",
                                                                                                                 RegexOptions
                                                                                                                     .IgnoreCase),
                                                                                                            "<", "",
                                                                                                            RegexOptions
                                                                                                                .IgnoreCase),
                                                                                                        ">", "",
                                                                                                        RegexOptions
                                                                                                            .IgnoreCase),
                                                                                                    "&(quot|#34);", "\"",
                                                                                                    RegexOptions
                                                                                                        .IgnoreCase),
                                                                                                "&(amp|#38);", "&",
                                                                                                RegexOptions.IgnoreCase),
                                                                                            "&(lt|#60);", "<",
                                                                                            RegexOptions.IgnoreCase),
                                                                                        "&(gt|#62);", ">",
                                                                                        RegexOptions.IgnoreCase),
                                                                                    "&(iexcl|#161);", "\x00a1",
                                                                                    RegexOptions.IgnoreCase),
                                                                                "&(cent|#162);", "\x00a2",
                                                                                RegexOptions.IgnoreCase),
                                                                            "&(pound|#163);", "\x00a3",
                                                                            RegexOptions.IgnoreCase), "&(copy|#169);",
                                                                        "\x00a9", RegexOptions.IgnoreCase), @"&#(\d+);",
                                                                    "", RegexOptions.IgnoreCase), "xp_cmdshell", "",
                                                                RegexOptions.IgnoreCase), "insert", "",
                                                            RegexOptions.IgnoreCase), "delete from", "",
                                                        RegexOptions.IgnoreCase), "count''", "", RegexOptions.IgnoreCase),
                                                "drop table", "", RegexOptions.IgnoreCase), "truncate", "",
                                            RegexOptions.IgnoreCase), "", "", RegexOptions.IgnoreCase), "char", "",
                                    RegexOptions.IgnoreCase), "xp_cmdshell", "", RegexOptions.IgnoreCase), "exec master",
                            "", RegexOptions.IgnoreCase), "net localgroup administrators", "", RegexOptions.IgnoreCase)
                         .Replace("/", "%2f")
                         .Replace("'", "");
            }
            catch
            {
                return "";
            }
        }

        public static string FormatToEmpty(string str)
        {
            if (str == "")
            {
                str = string.Empty;
                return str;
            }
            if (str == null)
            {
                str = string.Empty;
                return str;
            }
            if (str == "&nbsp;")
            {
                str = string.Empty;
            }
            return str;
        }

        public static string Left(string str, int length)
        {
            if (length >= str.Length)
            {
                return str;
            }
            return str.Substring(0, length);
        }

        public static string OperteString(string opstring, int leng)
        {
            if (opstring.Length >= leng)
            {
                return opstring.Substring(0, leng);
            }
            return opstring;
        }

        public static string Right(string original, int length)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original", "Right cannot be evaluated on a null string.");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Length must not be negative.");
            }
            if ((original.Length == 0) || (length == 0))
            {
                return string.Empty;
            }
            if (length >= original.Length)
            {
                return original;
            }
            return original.Substring(original.Length - length);
        }

        public static bool StringToBool(object Expression, bool defValue)
        {
            if (Expression != null)
            {
                if (string.Compare(Expression.ToString(), "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(Expression.ToString(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static float StringToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            float num2 = defValue;
            if ((strValue != null) && Regex.IsMatch(strValue.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                num2 = Convert.ToSingle(strValue);
            }
            return num2;
        }

        public static int StringToInt(object Expression, int defValue)
        {
            if (Expression != null)
            {
                string input = Expression.ToString();
                if ((((input.Length > 0) && (input.Length <= 11)) && Regex.IsMatch(input, "^[-]?[0-9]*$")) &&
                    (((input.Length < 10) || ((input.Length == 10) && (input[0] == '1'))) ||
                     (((input.Length == 11) && (input[0] == '-')) && (input[1] == '1'))))
                {
                    return Convert.ToInt32(input);
                }
            }
            return defValue;
        }
    }
}