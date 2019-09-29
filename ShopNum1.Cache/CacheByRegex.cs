using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopNum1.Cache
{
    public class CacheByRegex
    {
        private static readonly System.Web.Caching.Cache cache_0 = HttpContext.Current.Cache;
        private static readonly List<string> list_0 = new List<string>();

        public static void Remove(string string_0, bool match)
        {
            if (!match)
            {
                cache_0.Remove(string_0);
            }
            else
            {
                var class2 = new Class0
                {
                    regex_0 =
                        new Regex(string_0,
                            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase)
                };
                foreach (string str in list_0.FindAll(class2.method_0))
                {
                    cache_0.Remove(str);
                }
            }
        }

        public static void Set(string string_0, object value)
        {
            smethod_0(string_0);
            cache_0.Insert(string_0, value);
        }

        private static void smethod_0(string string_0)
        {
            var class2 = new Class1
            {
                string_0 = string_0
            };
            if (!list_0.Exists(class2.method_0))
            {
                list_0.Add(class2.string_0);
            }
        }


        private sealed class Class0
        {
            public Regex regex_0;

            public bool method_0(string string_0)
            {
                return regex_0.IsMatch(string_0);
            }
        }


        private sealed class Class1
        {
            public string string_0;

            public bool method_0(string string_1)
            {
                return (string_1 == string_0);
            }
        }
    }
}