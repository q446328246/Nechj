using System.Web;

namespace ShopNum1.Cache
{
    public class FactoryDataCache
    {
        public static object GetCache(string CacheKey)
        {
            return HttpRuntime.Cache[CacheKey];
        }

        public static void SetCache(string CacheKey, object objObject)
        {
            HttpRuntime.Cache.Insert(CacheKey, objObject);
        }
    }
}