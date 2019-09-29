using System;
using System.Text.RegularExpressions;

namespace ShopNum1.Common
{
    public class TypeConverter
    {
        public static DateTime ObjectToDateTime(object obj)
        {
            return StrToDateTime(obj.ToString());
        }

        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StrToDateTime(obj.ToString(), defValue);
        }

        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0f);
        }

        public static float ObjectToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
            {
                return StrToInt(expression.ToString(), defValue);
            }
            return defValue;
        }

        public static int[] StringToIntArray(string idList)
        {
            return StringToIntArray(idList, -1);
        }

        public static int[] StringToIntArray(string idList, int defValue)
        {
            if (string.IsNullOrEmpty(idList))
            {
                return null;
            }
            string[] strArray = Utils.SplitString(idList, ",");
            var numArray2 = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                numArray2[i] = StrToInt(strArray[i], defValue);
            }
            return numArray2;
        }

        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                return StrToBool(expression, defValue);
            }
            return defValue;
        }

        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(expression, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }

        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            DateTime time;
            if (!string.IsNullOrEmpty(str) && DateTime.TryParse(str, out time))
            {
                return time;
            }
            return defValue;
        }

        public static float StrToFloat(string strValue)
        {
            if (strValue == null)
            {
                return 0f;
            }
            return StrToFloat(strValue, 0f);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
            {
                return defValue;
            }
            float result = defValue;
            if ((strValue != null) && Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                float.TryParse(strValue, out result);
            }
            return result;
        }

        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        public static int StrToInt(string str, int defValue)
        {
            int num2;
            if (
                !((!string.IsNullOrEmpty(str) && (str.Trim().Length < 11)) &&
                  Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$")))
            {
                return defValue;
            }
            if (int.TryParse(str, out num2))
            {
                return num2;
            }
            return Convert.ToInt32(StrToFloat(str, defValue));
        }
    }
}