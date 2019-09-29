using System;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopSales : PageBase, IRequiresSessionState
    {
        protected const string ShopClick_Report = "ShopSales_Report.aspx";


        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出店铺销售额Html数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopSales.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("ShopSales_Report.aspx?Type=html&shophost=" + txtshophost.Text + "&shopname=" +
                                   txtshopname.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出店铺销售额Excel数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopSales.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("ShopSales_Report.aspx?Type=xls&shophost=" + txtshophost.Text + "&shopname=" +
                                   txtshopname.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Num1GridViewShow_SelectedIndexChanged(object sender, EventArgs e)
        {
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