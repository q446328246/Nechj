using System;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderProductReport : PageBase, IRequiresSessionState
    {
        protected const string strOrderProductReport = "OrderProduct_Report.aspx";

        protected void ButtonHtml_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出商品销售明细Html数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "OrderProductReport.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("OrderProduct_Report.aspx?Type=html&pname=" + txtProductName.Text + "&oname=" +
                                   txtOrderNumber.Text.ToString() + "&DispatchTime1=" + TextBoxStartDate.Text.ToString() +
                                   "&DispatchTime2=" + TextBoxEndDate.Text.ToString() + "&ShopName=" +
                                   TextBoxShopName.Text.ToString());
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出商品销售明细Excel数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "OrderProductReport.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("OrderProduct_Report.aspx?Type=xls&pname=" + txtProductName.Text + "&oname=" +
                                   txtOrderNumber.Text.ToString() + "&DispatchTime1=" + TextBoxStartDate.Text.ToString() +
                                   "&DispatchTime2=" + TextBoxEndDate.Text.ToString() + "&ShopName=" +
                                   TextBoxShopName.Text.ToString());
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Num1GridViewShow.DataBind();
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