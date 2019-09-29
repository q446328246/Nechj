using System;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentPreTransfer_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_PreTransfer_Action) LogicFactory.CreateShopNum1_PreTransfer_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentPreTransfer_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReportAll_Click(object sender, EventArgs e)
        {
            if (Num1GridViewShow.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "导出转账记录数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentPreTransfer_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };

                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "3");
                cookie.Values.Add("Guids", "-1");
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private HttpCookie method_5()
        {
            string text = TextBoxOrderNumber.Text;
            string str2 = TextBoxSMemLoginID.Text;
            string str3 = TextBoxGetMemLoginID.Text;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            string str6 = DropdownListSOperateType.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("OrderNumber", text);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("ToMemLoginID", str3);
            cookie.Values.Add("State", "0");
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            cookie.Values.Add("OperateType", str6);
            return cookie;
        }
    }
}