using System;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ChangeAdvancePaymentLog_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = Convert.ToInt32(DropDownListOperateType.SelectedValue),
                    CurrentAdvancePayment = Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()),
                    OperateMoney = Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = TextBoxMemo.Text.Trim()
                };

            if (DropDownListOperateType.SelectedValue == "1") //充值
            {
                advancePaymentModifyLog.LastOperateMoney =
                    Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) +
                    Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
            }
            else if (DropDownListOperateType.SelectedValue == "0")//提现
            {
                if (Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) < Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()))
                {
                    MessageBox.Show("当前金币（BV）不足！");
                    return;
                }
                advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) - Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
            }
            advancePaymentModifyLog.MemLoginID = LabelMemLoginIDValue.Text.Trim();
            advancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
            advancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            advancePaymentModifyLog.IsDeleted = 0;
            var action = (ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            if (action.OperateMoney(advancePaymentModifyLog) > 0)
            {
                MessageShow.ShowMessage("OperateYes");
                MessageShow.Visible = true;
                GetMemberInfo();
                BindGrid();
                
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "变更金币（BV）" + LabelMemLoginIDValue.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ChangeAdvancePaymentLog_List.aspx",
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
                        Record = "导出金币（BV）变更日志数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ChangeAdvancePaymentLog_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };

                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "4");
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
            if (operateType == "1")
            {
                return "充值";
            }
            if (operateType == "2")
            {
                return "提现";
            }
            if (operateType == "3")
            {
                return "消费";
            }
            if (operateType == "4")
            {
                return "收入";
            }
            if (operateType == "5")
            {
                return "系统";
            }
            if (operateType == "6")
            {
                return "转账";
            }
            if (operateType == "7")
            {
                return "积分消费";
            }
            if (operateType == "8")
            {
                return "积分获得";
            }
            if (operateType == "9")
            {
                return "红包消费";
            }
            if (operateType == "10")
            {
                return "红包获得";
            }
            if (operateType == "11")
            {
                return "重消积分消费";
            }
            if (operateType == "12")
            {
                return "重消积分获得";
            }
            if (operateType == "13")
            {
                return "店铺收入、提现";
            }
            if (operateType == "14")
            {
                return "重消币消费";
            }
            if (operateType == "15")
            {
                return "重消币获得";
            }
            if (operateType == "16")
            {
                return "C积分消费";
            }
            if (operateType == "17")
            {
                return "C积分获得";
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

        public string MoneyAddOrDel(object obj1, object obj2)
        {
            string str = Convert.ToString((Convert.ToDecimal(obj2) - Convert.ToDecimal(obj1)));
            if (Convert.ToDecimal(obj1) > Convert.ToDecimal(obj2))
            {
                return ("<font color=red>" + str + "</font>");
            }
            return ("<font color=green>+" + str + "</font>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                GetMemberInfo();
                BindGrid();
            }
        }
    }
}