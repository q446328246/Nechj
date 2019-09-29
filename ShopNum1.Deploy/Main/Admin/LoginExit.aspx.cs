using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class LoginExit : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["AdminLoginCookie"] != null)
            {
                Page.Request.Cookies["AdminLoginCookie"].Expires =
                    Convert.ToDateTime(DateTime.Now.AddDays(-5.0).ToString("yyyy-MM-dd HH:mm:ss"));
                Page.Response.Cookies.Add(Page.Request.Cookies["AdminLoginCookie"]);
                base.Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
            }
        }
    }
}