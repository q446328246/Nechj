using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DefaultAdminCheck : BaseWebControl
    {
        private string skinFilename = "DefaultAdminCheck";

        public DefaultAdminCheck()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["AdminLoginCookie"] == null)
            {
                Page.Response.Write(
                    "<script type=\"text/javascript\">window.location.href='/Main/admin/login.aspx';</script>");
            }
        }
    }
}