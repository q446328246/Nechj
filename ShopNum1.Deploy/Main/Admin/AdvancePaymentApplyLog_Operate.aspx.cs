using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentApplyLog_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                HiddenFieldOperateTypeValue.Value = (base.Request.QueryString["Type"] == null)? "0": base.Request.QueryString["Type"];
                if (hiddenGuid.Value != "0")
                {
                    GetEditInfo();
                    if (HiddenFieldOperateTypeValue.Value == "1")
                    {
                        Label2.Text = "充值确认";
                    }
                    else if (HiddenFieldOperateTypeValue.Value == "1")
                    {
                        Label2.Text = "提现审核";
                    }
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var action = (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
             
                if (DropDownListOperateStatus.SelectedValue == "1")
                {
                    var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog{Guid = Guid.NewGuid()};

                    if (HiddenFieldOperateTypeValue.Value == "0")
                    {
                        advancePaymentModifyLog.OperateType = 0;
                    }
                    else if (HiddenFieldOperateTypeValue.Value == "1")
                    {
                        advancePaymentModifyLog.OperateType = 1;
                    }
          
                    advancePaymentModifyLog.CurrentAdvancePayment =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim());
                    advancePaymentModifyLog.OperateMoney = Convert.ToDecimal(LabelOperateMoneyValue.Text.Trim());
                    advancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    advancePaymentModifyLog.Memo = TextBoxUserMemo.Text.Trim();
                 
                    if (DropDownListOperateStatus.SelectedValue == "1")
                    {
                        if (HiddenFieldOperateTypeValue.Value == "0")
                        {
                            advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim());
                        }
                        else if (HiddenFieldOperateTypeValue.Value == "1")
                        {
                            advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) +Convert.ToDecimal(LabelOperateMoneyValue.Text.Trim());
                        }
                    }
                    else if (HiddenFieldOperateTypeValue.Value == "0")
                    {
                        advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) +Convert.ToDecimal(LabelOperateMoneyValue.Text.Trim());
                    }
                    else if (HiddenFieldOperateTypeValue.Value == "1")
                    {
                        advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim());
                    }

                    advancePaymentModifyLog.MemLoginID = LabelMemLoginIDValue.Text.Trim();
                    advancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
                    advancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    advancePaymentModifyLog.IsDeleted = 0;
            
                    if (action.Update_Update(hiddenGuid.Value.Replace("'", ""), LabelMemLoginIDValue.Text,HiddenFieldOperateTypeValue.Value,Convert.ToDecimal(LabelOperateMoneyValue.Text.Trim()),Convert.ToInt32(DropDownListOperateStatus.SelectedValue),TextBoxUserMemo.Text.Trim(), advancePaymentModifyLog, base.ShopNum1LoginID) >0)
                    {
                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "充值审核" + LabelMemLoginIDValue.Text + "成功",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "AdvancePaymentApplyLog_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };

                        base.OperateLog(operateLog);
                        base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
                    }
                    else
                    {
                        MessageShow.ShowMessage("AddNo");
                        MessageShow.Visible = true;
                    }
                }
                else if (DropDownListOperateStatus.SelectedValue == "2")
                {
                    action.ChangeLogStatusNew(2, hiddenGuid.Value.Replace("'", ""), TextBoxUserMemo.Text.Trim());

                    base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
                }
                else
                {
                    MessageBox.Show("请选择操作！");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void GetEditInfo()
        {
            DataTable table =((ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).Search(hiddenGuid.Value.Replace("'", ""));

            
            LabelMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
            DataTable table1 = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(table.Rows[0]["MemLoginID"].ToString());
            LabelCurrentAdvancePaymentValue.Text = table1.Rows[0]["AdvancePayment"].ToString();
            LabelDateValue.Text = table.Rows[0]["Date"].ToString();
            HiddenFieldOperateTypeValue.Value = table.Rows[0]["OperateType"].ToString();
       
            if (table.Rows[0]["OperateType"].ToString() == "0")
            {
                LabelOperateTypeValue.Text = "提现";
                Panel1.Visible = true;
                TextBox_Bank.Text = table.Rows[0]["Bank"].ToString();
                TextBoxTrueName.Text = table.Rows[0]["TrueName"].ToString();
                TextBoxAccount.Text = table.Rows[0]["Account"].ToString();
            }
            else if (table.Rows[0]["OperateType"].ToString() == "1")
            {
                LabelOperateTypeValue.Text = "充值";
            }
       
            LabelOperateMoneyValue.Text = table.Rows[0]["OperateMoney"].ToString();
            TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            TextBoxUserMemo.Text = table.Rows[0]["UserMemo"].ToString();
            DropDownListOperateStatus.SelectedValue = table.Rows[0]["OperateStatus"].ToString();
            LabelPaymentName.Text = table.Rows[0]["PaymentName"].ToString();

            LabelBankCardValue.Text = table.Rows[0]["BankCard"].ToString();
            LabelUserNameValue.Text = table.Rows[0]["GetBamkCard"].ToString();
            LabelGetBamkCardValue.Text = table.Rows[0]["UserName"].ToString();
        
            if ((DropDownListOperateStatus.SelectedValue == "1") || (DropDownListOperateStatus.SelectedValue == "2"))
            {
                ButtonConfirm.Visible = false;
                DropDownListOperateStatus.Enabled = false;
                TextBoxUserMemo.Enabled = false;
            }
        }

        protected void ResetGoBack_Click(object sender, EventArgs e)
        {
            if (HiddenFieldOperateTypeValue.Value == "1")
            {
                base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
            }
            else if (HiddenFieldOperateTypeValue.Value == "0")
            {
                base.Response.Redirect("AdvancePaymentApplyLog_List.aspx");
            }
        }
    }
}