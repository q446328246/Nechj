using System;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopClickreport : PageBase, IRequiresSessionState
    {
        protected const string ShopClick_Report = "ShopClick_Report.aspx";

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出店铺访问量排行Html数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopClickreport.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("ShopClick_Report.aspx?Type=html&hname=" + txtshophost.Text + "&sname=" +
                                   txtshopname.Text + "&DispatchTime1=" + TextBoxStartDate.Text + "&DispatchTime2=" +
                                   TextBoxEndDate.Text);
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出店铺访问量排行Excel数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopClickreport.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("ShopClick_Report.aspx?Type=xls&hname=" + txtshophost.Text + "&sname=" +
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