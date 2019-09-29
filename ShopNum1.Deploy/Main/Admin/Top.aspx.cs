using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Top : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && (Page.Request.Cookies["AdminLoginCookie"] == null))
            {
                base.Response.Write("<script>window.top.location.href='Login.aspx'</script>");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string str = TextBoxSearch.Text;
            if (TextBoxSearch.Text != null)
            {
                Page.Response.Redirect("SearchFeature.aspx?name=" + str);
            }
        }
    }
}