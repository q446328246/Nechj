using System;
using System.Text;
using System.Web.Security;

namespace ShopNum1.Common
{
    public static class MachineKeyCryptography
    {
        public static string Decode(string text)
        {
            return Decode(text, CookieProtection.All);
        }

        public static string Decode(string text, CookieProtection cookieProtection)
        {
            byte[] buffer;
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            try
            {
                buffer = CookieProtectionHelperWrapper.Decode(cookieProtection, text);
            }
            catch (Exception exception)
            {
               throw new InvalidCypherTextException("Unable to decode the text", exception.InnerException);
            }
            if ((buffer == null) || (buffer.Length == 0))
            {
                throw new InvalidCypherTextException("Unable to decode the text");
            }
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

        public static string Encode(string text)
        {
            return Encode(text, CookieProtection.All);
        }

        public static string Encode(string text, CookieProtection cookieProtection)
        {
            if (string.IsNullOrEmpty(text) || (cookieProtection == CookieProtection.None))
            {
                return text;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return CookieProtectionHelperWrapper.Encode(cookieProtection, bytes, bytes.Length);
        }
    }
}