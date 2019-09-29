using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class userOrderReport : PageBase, IRequiresSessionState
    {
        protected const string userOrder_Report = "userOrder_Report.aspx";
        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出订单详情Html数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "userOrderReport.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("userOrder_Report.aspx?Type=html&personname=" + txtperson.Text +  "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出订单详情Excel数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "userOrderReport.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("userOrder_Report.aspx?Type=xls&personname=" + txtperson.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
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