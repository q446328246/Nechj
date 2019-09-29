using System;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PaymentStatistics_List : PageBase, IRequiresSessionState
    {
        protected const string PaymentStatistics_Report = "PaymentStatistics_Report.aspx";
        public static int int_0 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            int_0 = 1;
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出支付方式Html数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "PaymentStatistics_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("PaymentStatistics_Report.aspx?Type=html");
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出支付方式Excel数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "PaymentStatistics_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("PaymentStatistics_Report.aspx?Type=xls");
        }


    }
}