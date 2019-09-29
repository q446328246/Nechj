using System.Collections.Generic;
using System.Web;

namespace ShopNum1.Cache
{
    public class CacheByTag
    {
        private static readonly System.Web.Caching.Cache cache_0 = HttpContext.Current.Cache;

        public static object Get(string string_0)
        {
            string_0 = smethod_0(string_0);
            object obj2 = cache_0.Get(string_0);
            if (obj2 == null)
            {
            }
            return obj2;
        }

        public static void Remove(string string_0)
        {
            string_0 = smethod_0(string_0);
            cache_0.Remove(string_0);
        }

        public static void RemoveByTags(string[] tags)
        {
            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = "tags/" + tags[i];
            }
            var list = new List<string>();
            foreach (string str in tags)
            {
                object obj2 = Get(str);
                if (obj2 != null)
                {
                    list = (List<string>) obj2;
                    foreach (string str2 in list)
                    {
                        Remove(str2);
                    }
                }
                Remove(str);
            }
        }

        public static void Set(string string_0, object value)
        {
            string_0 = smethod_0(string_0);
            cache_0.Insert(string_0, value);
        }

        public static void Set(string string_0, object value, string[] tags)
        {
            if (tags.Length == 0)
            {
                Set(string_0, value);
            }
            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = "tags/" + tags[i];
            }
            var list = new List<string>();
            foreach (string str in tags)
            {
                object obj2 = Get(str);
                if (obj2 != null)
                {
                    list = (List<string>) obj2;
                }
                list.Add(string_0);
                Set(str, list);
            }
            Set(string_0, value);
        }

        private static string smethod_0(string string_0)
        {
            return ("project_name/" + string_0);
        }
    }
}