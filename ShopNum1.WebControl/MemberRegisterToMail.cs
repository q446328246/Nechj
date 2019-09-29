using System;
using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MemberRegisterToMail : BaseWebControl, ICallbackEventHandler
    {
        private string skinFilename = "MemberRegisterToMail.ascx";

        public MemberRegisterToMail()
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

        protected override void InitializeSkin(Control skin)
        {
            if (!Page.IsPostBack)
            {
                YZemail();
            }
            if (((Page.Request.QueryString["code"] != null) && (Page.Request.QueryString["userID"] != null)) &&
                (Page.Request.QueryString["email"] != null))
            {
                method_0(Page.Request.QueryString["code"], Page.Request.QueryString["userID"],
                    Page.Request.QueryString["email"]);
            }
        }

        protected void method_0(string string_1, string string_2, string string_3)
        {
            var action = (ShopNum1_MemberEmailExec_Action) LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            if (action.MemberEmailExec(string_1, "0") > 0)
            {
                if (ShopSettings.GetValue("RegIsEmail") == "1")
                {
                    string newValue = ShopSettings.GetValue("Name");
                    string emailTemplentGuid = "4a12724c-5154-4928-b867-d5bd180e80e6";
                    string emailBody = string.Empty;
                    string strTitle = string.Empty;
                    DataTable editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + emailTemplentGuid + "'", 0);
                    if (editInfo.Rows.Count > 0)
                    {
                        emailBody = editInfo.Rows[0]["Remark"].ToString();
                        strTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    emailBody =
                        emailBody.Replace("{$Name}", string_2)
                            .Replace("{$ShopName}", newValue)
                            .Replace("{$SendTime}", DateTime.Now.ToString());
                    SendMailForRegister(string_2, string_3, Guid.NewGuid().ToString(), "", strTitle, emailTemplentGuid,
                        emailBody);
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    "window.location.href='" +
                    GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                    "?type=1'", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    "window.location.href='" +
                    GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                    "?type=0'", true);
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
            }
        }

        public void YZemail()
        {
            var action = (ShopNum1_MemberEmailExec_Action) LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            if (action.CheckLink(Page.Request.QueryString["code"], Page.Request.QueryString["type"]).Rows.Count <= 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    "window.location.href='" +
                    GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                    "?type=0'", true);
            }
        }
    }
}