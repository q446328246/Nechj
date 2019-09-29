using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentFreezeOperate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                GetMemberInfo();
                BindGrid();
            }
        }

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
                    Date = DateTime.Now,
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
            advancePaymentFreezeLog.CreateTime = DateTime.Now.ToString();
            advancePaymentFreezeLog.IsDeleted = 0;
            var action2 =
                (ShopNum1_AdvancePaymentFreezeLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentFreezeLog_Action();
            if (action2.OperateMoney(advancePaymentFreezeLog, lastAdvancePayment) > 0)
            {
                if (DropDownListOperateType.SelectedValue == "0")
                {
                    var messageInfo = new ShopNum1_MessageInfo
                    {
                        Guid = Guid.NewGuid(),
                        Title = "冻结金币（BV）",
                        Type = "1",
                        Content = "管理员冻结您的金币（BV）金额为：" + TextBoxOperateMoney.Text.Trim() + "元。",
                        MemLoginID = base.ShopNum1LoginID,
                        SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                    var usermessage = new List<string>
                        {
                            LabelMemLoginIDValue.Text
                        };
                    ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                                         usermessage);
                }
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return " 冻结"; //LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "0");
            }
            if (operateType == "1")
            {
                return " 解冻";// LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "1");
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
    }
}