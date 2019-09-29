using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class FreezeAdvancePaymentLog_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            decimal lastAdvancePayment = 0M;
            var advancePaymentFreezeLog = new ShopNum1_AdvancePaymentFreezeLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = Convert.ToInt32(DropDownListOperateType.SelectedValue),
                    CurrentAdvancePayment = Convert.ToDecimal(LabelLockAdvancePayment.Text.Trim()),
                    OperateMoney = Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = TextBoxMemo.Text.Trim()
                };
            if (DropDownListOperateType.SelectedValue == "1")
            {
                if (Convert.ToDecimal(LabelLockAdvancePayment.Text.Trim()) <
                    Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()))
                {
                    MessageBox.Show("当前冻结金币（BV）不足！");
                    return;
                }
                advancePaymentFreezeLog.LastOperateMoney = Convert.ToDecimal(LabelLockAdvancePayment.Text.Trim()) -
                                                           Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
                lastAdvancePayment = Convert.ToDecimal(LabelAdvancePayment.Text) +
                                     Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
            }
            else if (DropDownListOperateType.SelectedValue == "0")
            {
                if (Convert.ToDecimal(LabelAdvancePayment.Text.Trim()) <
                    Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()))
                {
                    MessageBox.Show("当前金币（BV）不足！");
                    return;
                }
                advancePaymentFreezeLog.LastOperateMoney = Convert.ToDecimal(LabelLockAdvancePayment.Text.Trim()) +
                                                           Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
                lastAdvancePayment = Convert.ToDecimal(LabelAdvancePayment.Text) -
                                     Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
            }
            advancePaymentFreezeLog.MemLoginID = LabelMemLoginIDValue.Text.Trim();
            advancePaymentFreezeLog.CreateUser = base.ShopNum1LoginID;
            advancePaymentFreezeLog.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            advancePaymentFreezeLog.IsDeleted = 0;
            var action =
                (ShopNum1_AdvancePaymentFreezeLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentFreezeLog_Action();
            if (action.OperateMoney(advancePaymentFreezeLog, lastAdvancePayment) > 0)
            {
                MessageShow.ShowMessage("OperateYes");
                MessageShow.Visible = true;
                GetMemberInfo();
                BindGrid();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "冻结金币（BV）" + LabelMemLoginIDValue.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "FreezeAdvancePaymentLog_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                ClearControl();
            }
            else
            {
                MessageShow.ShowMessage("OperateNo");
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
                        Record = "导出金币（BV）解/冻日志数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "FreezeAdvancePaymentLog_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "5");
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

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return " 冻结";// LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "0");
            }
            if (operateType == "1")
            {
                return " 解冻";//LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "1");
            }
            return "";
        }

        protected void ClearControl()
        {
            TextBoxMemo.Text = string.Empty;
            TextBoxOperateMoney.Text = string.Empty;
        }

        protected void GetMemberInfo()
        {
            try
            {
                DataTable table =
                    ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchInfoByGuid(
                        hiddenGuid.Value);
                LabelMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
                LabelRealNameValue.Text = table.Rows[0]["Name"].ToString();
                LabelLockAdvancePayment.Text = table.Rows[0]["LockAdvancePayment"].ToString();
                LabelAdvancePayment.Text = table.Rows[0]["AdvancePayment"].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private HttpCookie method_5()
        {
            string text = TextMemLoginIDValue.Text;
            string selectedValue = DropdownListSOperateType.SelectedValue;
            string str3 = TextBoxSDate1.Text;
            string str4 = TextBoxSDate2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("OrderNumber", "");
            cookie.Values.Add("MemLoginID", text);
            cookie.Values.Add("OperType", selectedValue);
            cookie.Values.Add("State", "");
            cookie.Values.Add("Sdate", str3);
            cookie.Values.Add("Edate", str4);
            return cookie;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                BindGrid();
            }
        }
    }
}