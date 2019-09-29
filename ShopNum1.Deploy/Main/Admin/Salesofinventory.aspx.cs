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
    public partial class Salesofinventory : PageBase, IRequiresSessionState
    {
        protected const string Salesofinventory_Report = "Salesofinventory_Report.aspx";
        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出销量Html数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "Salesofinventory.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("Salesofinventory_Report.aspx?Type=html&productid=" + productid.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
            {
                Record = "导出销量详情Excel数据",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "Salesofinventory.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            base.Response.Redirect("Salesofinventory_Report.aspx?Type=xls&productid=" + productid.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
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