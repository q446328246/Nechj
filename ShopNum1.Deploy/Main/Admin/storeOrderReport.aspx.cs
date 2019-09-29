using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class storeOrderReport : PageBase, IRequiresSessionState
    {
        protected const string storeOrder_Report = "storeOrder_Report.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

        }
        
        protected void ButtonReportStore_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出取代进货Excel数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "storeOrder_Report.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("storeOrder_Report.aspx?Type=xls&flag=1" + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        protected void ButtonReportPro_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出发货统计Excel数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "storeOrder_Report.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("storeOrder_Report.aspx?Type=xls&flag=2" + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                    TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出发货单Excel数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "storeOrder_Report.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("storeOrder_Report.aspx?Type=xls&flag=3" + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                    TextBoxEndDate.Text);

        }
    }
}