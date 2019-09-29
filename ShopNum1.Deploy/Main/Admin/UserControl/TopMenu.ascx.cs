using System;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin.UserControl
{
    public partial class TopMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LinkButtonIsExite_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Request.Cookies.Remove("LoginCookie");
            base.Response.Write("<script>window.top.location.href='../ServiceAdmin/Login.aspx';</script>");
        }
    }
}