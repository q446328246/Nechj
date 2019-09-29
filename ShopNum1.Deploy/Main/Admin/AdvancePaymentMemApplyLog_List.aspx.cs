using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentMemApplyLog_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                string str = (base.Request.QueryString["operateStatus"] == null)? "-1": base.Request.QueryString["operateStatus"];
             
                if (str == "1")
                {
                    DropdownListSOperateStatus.SelectedValue = "0";
                }
                else
                {
                    DropdownListSOperateStatus.SelectedValue = "-1";
                }

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
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentMemApplyLog_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentMemApplyLog_List.aspx",
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

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("AdvancePaymentApplyLog_Operate.aspx?guid='" + CheckGuid.Value + "'");
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
                        Record = "导出会员充值数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentMemApplyLog_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "1");
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

        public string ChangeOperateStatus(string operateStatus)
        {
            if (operateStatus == "0")
            {
                return " 未确认"; //LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
            }
            if (operateStatus == "1")
            {
                return " 已完成";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
            }
            return "已拒绝";
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return "提现";
            }
            if (operateType == "1")
            {
                return "充值";
            }
            return "";
        }

        private HttpCookie method_5()
        {
            string text = TextBoxOrderNumber.Text;
            string str2 = TextBoxSMemLoginID.Text;
            string selectedValue = DropdownListSOperateStatus.SelectedValue;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            string ModifySTime = TextBoxModifyTime1.Text;
            string ModifyEtime = TextBoxModifyTime2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("OrderNumber", text);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            cookie.Values.Add("ModifySdate", ModifySTime);
            cookie.Values.Add("ModifyEdate", ModifyEtime);
            return cookie;
        }
    }
}