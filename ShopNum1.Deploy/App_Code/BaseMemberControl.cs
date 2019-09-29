using System;
using System.Threading;
using System.Web;
using ShopNum1.Common;

namespace ShopNum1.Deploy.App_Code
{
    public class BaseMemberControl : System.Web.UI.UserControl
    {
        public string MemLoginID = string.Empty;

        protected override void OnLoad(EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
                CurrentLoad(e);
            }
            else
            {
                GetUrl.RedirectLogin();
            }
        }

        private void CurrentLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
            }
            catch (ThreadAbortException ex)
            {
                Console.Write(ex.ToString());
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}