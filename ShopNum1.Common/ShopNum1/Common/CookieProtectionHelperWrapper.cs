using System;
using System.Reflection;
using System.Web;
using System.Web.Security;

namespace ShopNum1.Common
{
    public static class CookieProtectionHelperWrapper
    {
        private static readonly MethodInfo _decode;
        private static readonly MethodInfo _encode;

        static CookieProtectionHelperWrapper()
        {
            Assembly assembly = typeof (HttpContext).Assembly;
            if (assembly == null)
            {
                throw new InvalidOperationException("Unable to load System.Web.");
            }
            Type type = assembly.GetType("System.Web.Security.CookieProtectionHelper");
            if (type == null)
            {
                throw new InvalidOperationException(
                    "Unable to get the internal class System.Web.Security.CookieProtectionHelper.");
            }
            _encode = type.GetMethod("Encode", BindingFlags.NonPublic | BindingFlags.Static);
            _decode = type.GetMethod("Decode", BindingFlags.NonPublic | BindingFlags.Static);
            if ((_encode == null) || (_decode == null))
            {
                throw new InvalidOperationException("Unable to get the methods to invoke.");
            }
        }

        public static byte[] Decode(CookieProtection cookieProtection, string data)
        {
            return (byte[]) _decode.Invoke(null, new object[] {cookieProtection, data});
        }

        public static string Encode(CookieProtection cookieProtection, byte[] buf, int count)
        {
            return (string) _encode.Invoke(null, new object[] {cookieProtection, buf, count});
        }
    }
}