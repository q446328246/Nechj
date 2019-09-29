using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace ShopNum1.Cache
{
    public class DefaultCacheStrategy : ICacheStrategy
    {
        private static object object_0 = new object();
        protected static volatile System.Web.Caching.Cache webCache = HttpRuntime.Cache;
        protected int _timeOut = 0xe10;

        public static System.Web.Caching.Cache GetWebCacheObj
        {
            get { return webCache; }
        }

        public virtual void AddObject(string objId, object object_1)
        {
            if (((objId != null) && (objId.Length != 0)) && (object_1 != null))
            {
                if (TimeOut == 0x1c20)
                {
                    webCache.Insert(objId, object_1, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High,
                        null);
                }
                else
                {
                    webCache.Insert(objId, object_1, null, DateTime.Now.AddSeconds(TimeOut),
                        System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                }
            }
        }

        public virtual void AddObject(string objId, object object_1, int expire)
        {
            if (((objId != null) && (objId.Length != 0)) && (object_1 != null))
            {
                if (expire == 0)
                {
                    webCache.Insert(objId, object_1, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High,
                        null);
                }
                else
                {
                    webCache.Insert(objId, object_1, null, DateTime.Now.AddSeconds(expire),
                        System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                }
            }
        }

        public virtual void AddObjectWithDepend(string objId, object object_1, string[] dependKey)
        {
            if (((objId != null) && (objId.Length != 0)) && (object_1 != null))
            {
                CacheItemRemovedCallback onRemoveCallback = onRemove;
                var dependencies = new CacheDependency(null, dependKey, DateTime.Now);
                webCache.Insert(objId, object_1, dependencies, DateTime.Now.AddSeconds(TimeOut),
                    System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, onRemoveCallback);
            }
        }

        public virtual void AddObjectWithFileChange(string objId, object object_1, string[] files)
        {
            if (((objId != null) && (objId.Length != 0)) && (object_1 != null))
            {
                CacheItemRemovedCallback onRemoveCallback = onRemove;
                var dependencies = new CacheDependency(files, DateTime.Now);
                webCache.Insert(objId, object_1, dependencies, DateTime.Now.AddSeconds(TimeOut),
                    System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, onRemoveCallback);
            }
        }

        public virtual void FlushAll()
        {
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                webCache.Remove(enumerator.Key.ToString());
            }
        }

        public virtual void RemoveObject(string objId)
        {
            if ((objId != null) && (objId.Length != 0))
            {
                webCache.Remove(objId);
            }
        }

        public virtual object RetrieveObject(string objId)
        {
            if ((objId == null) || (objId.Length == 0))
            {
                return null;
            }
            return webCache.Get(objId);
        }

        public virtual int TimeOut
        {
            get { return ((_timeOut > 0) ? _timeOut : 0xe10); }
            set { _timeOut = (value > 0) ? value : 0xe10; }
        }

        public void onRemove(string string_0, object object_1, CacheItemRemovedReason reason)
        {
        }
    }
}