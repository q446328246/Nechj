using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopActualAuthentication_Audit : PageBase, IRequiresSessionState
    {
        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonOperate1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopActualAuthentication_Detai.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
            }
        }
    }
}