using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentApplyLog_List : PageBase, IRequiresSessionState
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
                (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            if (action.ChangeOperateStatusPL(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "批量审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentApplyLog_List.aspx",
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
        //protected void ButtonDelete_Click(object sender, EventArgs e)
        //{
        //    var action =
        //        (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
        //    if (action.Delete(CheckGuid.Value) > 0)
        //    {
        //        var operateLog = new ShopNum1_OperateLog
        //        {
        //            Record = "删除成功",
        //            OperatorID = base.ShopNum1LoginID,
        //            IP = Globals.IPAddress,
        //            PageName = "AdvancePaymentApplyLog_List.aspx",
        //            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        //        };
        //        base.OperateLog(operateLog);
        //        BindGrid();
        //        MessageShow.ShowMessage("DelYes");
        //        MessageShow.Visible = true;
        //    }
        //    else
        //    {
        //        MessageShow.ShowMessage("DelNo");
        //        MessageShow.Visible = true;
        //    }
        //}

        protected void ButtonExamineBylink_Click(object sender, EventArgs e)
        {
                string UserMemo = "";
                LinkButton btn = (LinkButton)sender;
                string guid = btn.CommandArgument;
                var action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                action.ChangeOperateStatus(UserMemo.Trim(), 1, guid.Replace("'", ""));
                this.Num1GridViewShow.DataBind();
            
        }

        protected void ButtonRefuseBylink_Click(object sender, EventArgs e)
        {
            string UserMemo = "";
            LinkButton btn = (LinkButton)sender;
            string guid = btn.CommandArgument;
            var action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            DataTable table = ((ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).SearchTx(guid.Replace("'", ""));
            action.ChangeOperateStatus(UserMemo.Trim(), 2, guid.Replace("'", ""));
            string LabelMemLoginIDValue = table.Rows[0]["MemLoginID"].ToString(); ;
            string LabelOperateMoneyValue = table.Rows[0]["OperateMoney"].ToString();
            string LabelMemLoginRealNameValue = table.Rows[0]["RealName"].ToString();
            string LabelCurrentAdvancePaymentValue = table.Rows[0]["CurrentAdvancePayment"].ToString();
            string LabelDateValue = table.Rows[0]["Date"].ToString();
            string HiddenFieldOperateTypeValue = table.Rows[0]["OperateType"].ToString();

            decimal num = 0M;
            string str = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  AND  MemLoginID='" + LabelMemLoginIDValue + "'");
            if (!string.IsNullOrEmpty(str))
            {
                num = Convert.ToDecimal(str);
            }
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = 5,
                CurrentAdvancePayment = num,
                OperateMoney = Convert.ToDecimal(LabelOperateMoneyValue),
                LastOperateMoney = num + Convert.ToDecimal(LabelOperateMoneyValue),
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Memo = "系统拒绝会员提现申请，返回金币（BV）￥" + LabelOperateMoneyValue.Trim(),
                MemLoginID = LabelMemLoginIDValue,
                CreateUser = base.ShopNum1LoginID,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(advancePaymentModifyLog);
            this.Num1GridViewShow.DataBind();
        }


        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //base.Response.Redirect("AdvancePaymentApplyLog_Operate.aspx?guid='" + CheckGuid.Value + "'");
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
                        Record = "导出提现审核数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AdvancePaymentApplyLog_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "2");
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
                return " 未确认";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
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
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("OrderNumber", text);
            cookie.Values.Add("MemLoginID", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            return cookie;
        }
    }
}