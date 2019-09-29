using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace ShopNum1.Cache
{
    public class CacheHelper
    {
        private static readonly System.Web.Caching.Cache cache_0;
        public static readonly int DayFactor = 0x4380;
        public static readonly int HourFactor = 720;
        private static int int_0 = 5;
        public static readonly int MinuteFactor = 12;
        public static readonly double SecondFactor = 0.2;
        private static readonly string string_0 = "ShopNum1Cache";

        static CacheHelper()
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                cache_0 = current.Cache;
            }
            else
            {
                cache_0 = HttpRuntime.Cache;
            }
        }

        private CacheHelper()
        {
        }

        public static void Clear()
        {
            IDictionaryEnumerator enumerator = cache_0.GetEnumerator();
            var list = new ArrayList();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key);
            }
            foreach (string str in list)
            {
                cache_0.Remove(str);
            }
        }

        public static object Get(string string_1)
        {
            return cache_0[string_0 + string_1];
        }

        public static void Insert(string string_1, object object_0)
        {
            Insert(string_1, object_0, null, 1);
        }

        public static void Insert(string string_1, object object_0, int seconds)
        {
            Insert(string_1, object_0, null, seconds);
        }

        public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0)
        {
            Insert(string_1, object_0, cacheDependency_0, MinuteFactor*3);
        }

        public static void Insert(string string_1, object object_0, int seconds, CacheItemPriority priority)
        {
            Insert(string_1, object_0, null, seconds, priority);
        }

        public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0, int seconds)
        {
            Insert(string_1, object_0, cacheDependency_0, seconds, CacheItemPriority.Normal);
        }

        public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0, int seconds,
            CacheItemPriority priority)
        {
            if (object_0 != null)
            {
                cache_0.Insert(string_0 + string_1, object_0, cacheDependency_0,
                    DateTime.Now.AddSeconds((int_0*seconds)), TimeSpan.Zero, priority, null);
            }
        }

        public static void Remove(string string_1)
        {
            cache_0.Remove(string_0 + string_1);
        }

        public static void RemoveByPattern(string pattern)
        {
            IDictionaryEnumerator enumerator = cache_0.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(string_0 + enumerator.Key))
                {
                    cache_0.Remove(string_0 + enumerator.Key);
                }
            }
        }

        public static void ReSetFactor(int cacheFactor)
        {
            int_0 = cacheFactor;
        }
    }
}