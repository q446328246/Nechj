using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentAlterOperate : PageBase, IRequiresSessionState
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
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                {
                    Guid = Guid.NewGuid()
                };

            if (DropDownListOperateType.SelectedValue == "1")
            {
                advancePaymentModifyLog.OperateType = 1;//充值
            }
            else
            {
                advancePaymentModifyLog.OperateType = 2;//提现
            }
        
            advancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim());
            advancePaymentModifyLog.OperateMoney = Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
            advancePaymentModifyLog.Date = DateTime.Now;
            advancePaymentModifyLog.Memo = TextBoxMemo.Text.Trim();
            
            if (DropDownListOperateType.SelectedValue == "1") //充值
            {
                advancePaymentModifyLog.LastOperateMoney =Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) + Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
                if (string.IsNullOrEmpty(TextBoxMemo.Text))
                {
                    advancePaymentModifyLog.Memo = "系统平台给会员充值￥" + TextBoxOperateMoney.Text.Trim();
                }
            }
            else if (DropDownListOperateType.SelectedValue == "0") //提现
            {
                if (Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) < Convert.ToDecimal(TextBoxOperateMoney.Text.Trim()))
                {
                    MessageBox.Show("当前金币（BV）不足！");
                    return;
                }
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(LabelCurrentAdvancePaymentValue.Text.Trim()) - Convert.ToDecimal(TextBoxOperateMoney.Text.Trim());
             
                if (string.IsNullOrEmpty(TextBoxMemo.Text))
                {
                    advancePaymentModifyLog.Memo = "会员提现金币（BV），系统手动减少金币（BV）￥" + TextBoxOperateMoney.Text.Trim();
                }
            }
            advancePaymentModifyLog.MemLoginID = LabelMemLoginIDValue.Text.Trim();
            advancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
            advancePaymentModifyLog.CreateTime = DateTime.Now;
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return " 后台提现"; //LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "0");
            }
            if (operateType == "1")
            {
                return " 后台充值"; //LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "1");
            }
            if (operateType == "2")
            {
                return " 会员自助提现";// LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "2");
            }
            if (operateType == "3")
            {
                return " 会员自助充值";// LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "3");
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
            DataTable table =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchInfoByGuid(hiddenGuid.Value);
            LabelMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
            LabelRealNameValue.Text = table.Rows[0]["Name"].ToString();
            LabelCurrentAdvancePaymentValue.Text = table.Rows[0]["AdvancePayment"].ToString();
        }
    }
}