using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopAmountReport : PageBase, IRequiresSessionState
    {
        protected const string strShopAmountReport = "ShopAmount_Report.aspx";

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopAmount_Report.aspx?Type=html&DispatchTime1=" + TextBoxStartDate.Text +
                                   "&DispatchTime2=" + TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopAmount_Report.aspx?Type=xls&DispatchTime1=" + TextBoxStartDate.Text +
                                   "&DispatchTime2=" + TextBoxEndDate.Text);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
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