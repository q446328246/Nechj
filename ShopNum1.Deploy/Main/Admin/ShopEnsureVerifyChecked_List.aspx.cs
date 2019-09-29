using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopEnsureVerifyChecked_List : PageBase, IRequiresSessionState
    {
        private readonly string string_11 = string.Empty;
        private string string_10 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BandDropdownIsAudit();
            }
        }

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
        {
            return new ShopNum1_EmailGroupSend
                {
                    Guid = Guid.NewGuid(),
                    EmailTitle = string_11,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b"),
                    SendObjectEmail = sconts,
                    SendObject = memLoginID + "-" + email,
                    State = state
                };
        }

        public int BackMoney(string checkGuid)
        {
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            DataTable ensureMoney = action.GetEnsureMoney(new Guid(checkGuid.Replace("'", "")));
            string changeAdvancPayment = ensureMoney.Rows[0]["EnsureMoney"].ToString();
            string memLoginID = ensureMoney.Rows[0]["MemberLoginID"].ToString();
            var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable advancePayment = action2.GetAdvancePayment(memLoginID);
            decimal num = Convert.ToDecimal(advancePayment.Rows[0]["AdvancePayment"].ToString());
            string email = advancePayment.Rows[0]["Email"].ToString();
            if (action.CheckIsPayMentByID(checkGuid.Replace("'", "")) > 0)
            {
                action2.UpdtateMemberAdvancePayment(memLoginID, changeAdvancPayment);
                var action3 = new ShopNum1_AdvancePaymentModifyLog_Action();
                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                    {
                        MemLoginID = memLoginID,
                        OperateType = 5,
                        OperateMoney = Convert.ToDecimal(changeAdvancPayment),
                        CurrentAdvancePayment = num,
                        Guid = Guid.NewGuid(),
                        CreateUser = base.ShopNum1LoginID,
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0,
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Memo = "系统退还保障金",
                        LastOperateMoney = Convert.ToDecimal(num + changeAdvancPayment),
                        UserMemo = ""
                    };
                action3.OperateMoney(advancePaymentModifyLog);
                if ((email != null) || (email != ""))
                {
                    try
                    {
                        SendEmail(email, memLoginID, advancePaymentModifyLog.OperateMoney,
                                  advancePaymentModifyLog.LastOperateMoney);
                    }
                    catch
                    {
                    }
                }
                return 1;
            }
            MessageShow.Visible = true;
            MessageShow.ShowMessage("店铺会员未支付服务保障金");
            return 0;
        }

        public void BandDropdownIsAudit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            if (action.UpdataIsAuditByGuid(CheckGuid.Value, 1) > 0)
            {
                BindGrid();
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateYes");
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo1");
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            if (action.UpdataIsAuditByGuid(CheckGuid.Value, 2) > 0)
            {
                if (BackMoney(CheckGuid.Value) == 1)
                {
                    BindGrid();
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("UpdateYes");
                    action.DelShopEnsureList(CheckGuid.Value);
                }
                else
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("店铺会员未支付");
                }
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("审核失败");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            if (action.DelShopEnsureList("'" + CheckGuid.Value.Replace("'", "") + "'") > 0)
            {
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
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            var button = (LinkButton) sender;
            string guid = "'" + button.CommandArgument + "'";
            if (action.DelShopEnsureList(guid) > 0)
            {
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GetEmailSetting()
        {
            string_4 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
            string_5 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
            string_7 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
            string_6 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
            string_8 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
            string_9 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
            string_10 = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
        }

        protected string IsAudit(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }



        public int SendEmail(string email, string memloginid, decimal backMoney, decimal AddPayMentMoney)
        {
            ShopNum1_EmailGroupSend send;
            int num = 0;
            LogicFactory.CreateShopNum1_Member_Action();
            GetEmailSetting();
            var mail = new NetMail();
            mail.MailDomain=string_5;
            mail.Mailserverport=Convert.ToInt32(string_7.Trim());
            mail.Username=string_6;
            mail.Password=string_8;
            mail.Html=true;
            var action = new ShopNum1_Email_Action();
            mail.AddRecipient(email);
            string s = string.Empty;
            if (backMoney > 0M)
            {
                s =
                    string.Concat(new object[]
                        {"尊敬的", memloginid, "用户，由于系统原因，你的保障金审核不通过,现退还你的保障金", backMoney, "现你的金币（BV）金额为", AddPayMentMoney});
            }
            else
            {
                s = string.Concat(new object[] {"尊敬的", memloginid, "用户，由于系统原因，你的保障金审核不通过现你的金币（BV）金额为", AddPayMentMoney});
            }
            mail.Subject="系统通知";
            mail.Body=HttpContext.Current.Server.HtmlDecode(s);
            mail.From=string_9;
            if (!mail.Send())
            {
                send = Add(memloginid, email, 0, mail.Body);
                action.AddEmailGroupSend(send);
                return num;
            }
            send = Add(memloginid, email, 2, mail.Body);
            action.AddEmailGroupSend(send);
            return 1;
        }
    }
}