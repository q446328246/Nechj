using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MemberRegisterWelcome : BaseWebControl, ICallbackEventHandler
    {
        private Label LabelEmail;
        private LinkButton LinkButtonEmail;
        private LinkButton LinkButtonSend;
        private string skinFilename = "MemberRegisterWelcome.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;

        public MemberRegisterWelcome()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetCallbackResult()
        {
            throw new NotImplementedException();
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            throw new NotImplementedException();
        }

        public void GetUrl(string email)
        {
            int num = Convert.ToInt32(email.LastIndexOf(".")) - Convert.ToInt32(email.LastIndexOf("@"));
            string str = email.Substring(email.LastIndexOf("@") + 1, num - 1);
            DataTable xmlDataTable = GetXmlDataTable();
            if ((xmlDataTable != null) && (xmlDataTable.Rows.Count > 0))
            {
                for (int i = 0; i < xmlDataTable.Rows.Count; i++)
                {
                    if (xmlDataTable.Rows[i]["sign"].ToString() == str)
                    {
                        if (xmlDataTable.Rows[i]["url"].ToString().Contains("http://") ||
                            xmlDataTable.Rows[i]["url"].ToString().Contains("https://"))
                        {
                            LinkButtonEmail.PostBackUrl = xmlDataTable.Rows[i]["url"].ToString();
                        }
                        else
                        {
                            LinkButtonEmail.PostBackUrl = "http://" + xmlDataTable.Rows[i]["url"];
                        }
                    }
                }
            }
        }

        public DataTable GetXmlDataTable()
        {
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath("~/Settings/email.xml"));
            if ((set == null) || (set.Tables.Count == 0))
            {
                return null;
            }
            return set.Tables[0];
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelEmail = (Label) skin.FindControl("LabelEmail");
            LinkButtonEmail = (LinkButton) skin.FindControl("LinkButtonEmail");
            LinkButtonSend = (LinkButton) skin.FindControl("LinkButtonSend");
            LinkButtonSend.Click += LinkButtonSend_Click;
            if ((Page.Request.QueryString["email"] != null) && (Page.Request.QueryString["id"] != null))
            {
                string_1 = Page.Request.QueryString["email"];
                string_2 = Page.Request.QueryString["id"];
                GetUrl(string_1);
            }
        }

        protected void LinkButtonSend_Click(object sender, EventArgs e)
        {
            ShopSettings.GetValue("RegIsEmail");
            string str = ShopSettings.GetValue("RegIsActivationEmail");
            ShopSettings.GetValue("RegIsMMS");
            string str2 = ShopSettings.GetValue("Name");
            if (str == "1")
            {
                string emailkey = Guid.NewGuid().ToString();
                var email = new RegIsActivationEmail
                {
                    Email = string_1,
                    Name = string_2,
                    link =
                        GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + emailkey + "&type=0&userID=" +
                        string_2,
                    ShopName = str2,
                    SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                string s = string.Empty;
                string strTitle = string.Empty;
                string emailTemplentGuid = "27815f7e-8f56-4f6d-afcb-edb099f16f60";
                string emailBody = string.Empty;
                DataTable editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + emailTemplentGuid + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    strTitle = editInfo.Rows[0]["Title"].ToString();
                }
                emailBody = email.ChangeRegister(Page.Server.HtmlDecode(s));
                SendMailForRegister(string_2, string_1, emailkey, "", strTitle, emailTemplentGuid, emailBody);
            }
        }

        public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle,
            string emailTemplentGuid, string emailBody)
        {
            var action = (ShopNum1_MemberEmailExec_Action) LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            var memberEmailExec = new ShopNum1_MemberEmailExec
            {
                ExtireTime = DateTime.Now.AddHours(24.0),
                Email = Email,
                Emailkey = Emailkey,
                Guid = Guid.NewGuid(),
                Isinvalid = 0,
                MemberID = MemLoginID,
                Phone = Phone,
                Type = 0
            };
            if (action.MemberEmailInsert(memberEmailExec) > 0)
            {
                new SendEmail().Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
                MessageBox.Show("发送成功，请前往登录邮箱");
            }
        }
    }
}