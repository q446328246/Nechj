using System.Web;
using System.Web.Security;

namespace ShopNum1.Common
{
    public static class HttpSecureCookie
    {
        public static HttpCookie CloneCookie(HttpCookie cookie)
        {
            return new HttpCookie(cookie.Name, cookie.Value)
                {
                    Domain = cookie.Domain,
                    Expires = cookie.Expires,
                    HttpOnly = cookie.HttpOnly,
                    Path = cookie.Path,
                    Secure = cookie.Secure
                };
        }

        public static HttpCookie Decode(HttpCookie cookie)
        {
            if (cookie == null)
            {
                return null;
            }
            return Decode(cookie, CookieProtection.All);
        }

        public static HttpCookie Decode(HttpCookie cookie, CookieProtection cookieProtection)
        {
            if (cookie == null)
            {
                return null;
            }
            HttpCookie cookie3 = CloneCookie(cookie);
            cookie3.Value = MachineKeyCryptography.Decode(cookie.Value, cookieProtection);
            return cookie3;
        }

        public static HttpCookie Encode(HttpCookie cookie)
        {
            return Encode(cookie, CookieProtection.All);
        }

        public static HttpCookie Encode(HttpCookie cookie, CookieProtection cookieProtection)
        {
            HttpCookie cookie2 = CloneCookie(cookie);
            cookie2.Value = MachineKeyCryptography.Encode(cookie.Value, cookieProtection);
            return cookie2;
        }
    }
}