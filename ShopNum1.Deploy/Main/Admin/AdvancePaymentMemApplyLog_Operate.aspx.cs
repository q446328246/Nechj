using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentMemApplyLog_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (hiddenGuid.Value != "0")
                {
                    GetEditInfo();
                }
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (DropDownListOperateStatus.SelectedValue == "0")
            {
                MessageBox.Show("请选择到账状态！");
            }
            else
            {
                var action =(ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                if (DropDownListOperateStatus.SelectedValue == "1") //已完成
                {
                    action.ChangeOperateStatus(TextBoxUserMemo.Text.Trim(), 1, hiddenGuid.Value.Replace("'", ""));
                }

                if (DropDownListOperateStatus.SelectedValue == "2")//拒绝申请
                {
                    action.ChangeOperateStatus(TextBoxUserMemo.Text.Trim(), 2, hiddenGuid.Value.Replace("'", ""));
                    decimal num = 0M;
                    string str = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member","  AND  MemLoginID='" + LabelMemLoginIDValue.Text + "'");
                    if (!string.IsNullOrEmpty(str))
                    {
                        num = Convert.ToDecimal(str);
                    }
                    var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = 5,
                            CurrentAdvancePayment = num,
                            OperateMoney = Convert.ToDecimal(LabelOperateMoneyValue.Text),
                            LastOperateMoney = num + Convert.ToDecimal(LabelOperateMoneyValue.Text),
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            Memo = "系统拒绝会员提现申请，返回金币（BV）￥" + LabelOperateMoneyValue.Text.Trim(),
                            MemLoginID = LabelMemLoginIDValue.Text,
                            CreateUser = base.ShopNum1LoginID,
                            CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsDeleted = 0
                        };
                    ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(advancePaymentModifyLog);
                }
                base.Response.Redirect("AdvancePaymentApplyLog_List.aspx");
            }
        }

        protected void GetEditInfo()
        {
            DataTable table =((ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).SearchTx(hiddenGuid.Value.Replace("'", ""));
            
            LabelMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
            LabelMemLoginRealNameValue.Text=table.Rows[0]["RealName"].ToString();
            LabelCurrentAdvancePaymentValue.Text = table.Rows[0]["CurrentAdvancePayment"].ToString();
            LabelDateValue.Text = table.Rows[0]["Date"].ToString();
            HiddenFieldOperateTypeValue.Value = table.Rows[0]["OperateType"].ToString();
        
            if (table.Rows[0]["OperateType"].ToString() == "0")
            {
                LabelOperateTypeValue.Text = "提现";
                Panel1.Visible = true;
                TextBox_Bank.Text = table.Rows[0]["Bank"].ToString();
                TextBoxTrueName.Text = table.Rows[0]["TrueName"].ToString();
                TextBoxAccount.Text = table.Rows[0]["Account"].ToString();
                if (LabelOperateMoneyValue.Text != "")
                {
                    if (Convert.ToDecimal(LabelOperateMoneyValue.Text) >
                        Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text))
                    {
                        ButtonConfirm.Visible = false;
                        DropDownListOperateStatus.Enabled = false;
                    }
                }
                else
                {
                    LabelOperateMoneyValue.Text = "0.00";
                }
            }
            else if (table.Rows[0]["OperateType"].ToString() == "1")
            {
                LabelOperateTypeValue.Text = "充值";
            }
            LabelOperateMoneyValue.Text = table.Rows[0]["OperateMoney"].ToString();
            ActualMoney.Text = table.Rows[0]["ActualMoney"].ToString();
            TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            TextBoxUserMemo.Text = table.Rows[0]["UserMemo"].ToString();
            DropDownListOperateStatus.SelectedValue = table.Rows[0]["OperateStatus"].ToString();
            if ((DropDownListOperateStatus.SelectedValue == "1") || (DropDownListOperateStatus.SelectedValue == "2"))
            {
                ButtonConfirm.Visible = false;
                DropDownListOperateStatus.Enabled = false;
            }
        }
    }
}