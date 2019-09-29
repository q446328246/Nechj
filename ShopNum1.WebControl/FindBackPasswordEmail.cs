using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class FindBackPasswordEmail : BaseWebControl, ICallbackEventHandler
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = "FindBackPasswordEmail.ascx";
        private string string_9;

        public FindBackPasswordEmail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_8;
            }
        }

        public string GetCallbackResult()
        {
            string[] strArray = string_9.Split(new[] {'|'});
            return (string) base.GetType().GetMethod(strArray[0]).Invoke(this, new object[] {strArray[1]});
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string_9 = eventArgument;
        }

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
        {
            return new ShopNum1_EmailGroupSend
            {
                Guid = Guid.NewGuid(),
                EmailTitle = string_7,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b"),
                SendObjectEmail = sconts,
                SendObject = memLoginID + "-" + email,
                State = state
            };
        }

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            Page.Server.HtmlDecode(ShopSettings.GetValue("Name"));
            string email = Page.Request.Form["TextBoxEmail"];
            string text1 = Page.Request.Form["TextBoxPwd"];
            IShopNum1_Member_Action action = LogicFactory.CreateShopNum1_Member_Action();
            IShopNum1_MemberPwd_Action action2 = LogicFactory.CreateShopNum1_MemberPwd_Action();
            DataTable table = action.MemberFindPwdPro(email);
            if (((table != null) && (table.Rows.Count != 0)) && (table.Rows.Count > 0))
            {
                ShopNum1_EmailGroupSend send;
                GetEmailSetting();
                var mail = new NetMail
                {
                    MailDomain = string_1,
                    Mailserverport = Convert.ToInt32(string_3.Trim()),
                    Username = string_2,
                    Password = string_4,
                    Html = true
                };
                string memLoginID = string.Empty;
                memLoginID = table.Rows[0]["MemLoginID"].ToString();
                var memberPwd = new ShopNum1_MemberPwd
                {
                    MemberID = memLoginID
                };
                memberPwd.Pwd = "";
                memberPwd.pwdkey =
                    Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss") +
                                                new Random().Next()).Substring(0, 8);
                memberPwd.type = 0;
                memberPwd.extireTime = Convert.ToDateTime(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                memberPwd.Email = email;
                action2.MemberPwdInsert(memberPwd);
                mail.AddRecipient(email);
                var reset = new PasswordEmailReset();
                string str4 = ShopSettings.IsOverrideUrl
                    ? ("FindPasswordOperate" + ShopSettings.overrideUrlName)
                    : "FindPasswordOperate.aspx";
                reset.ChangePwdUrl = "http://" + ConfigurationManager.AppSettings["DoMain"] + "/" + str4 +
                                     "?type=0&key=" + memberPwd.pwdkey;
                reset.ShopName = ShopSettings.GetValue("Name");
                reset.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                reset.ExtireTime = memberPwd.extireTime.ToString();
                reset.MemloginID = memLoginID;
                reset.Hour = "24";
                string s = string.Empty;
                var action3 = new ShopNum1_Email_Action();
                DataTable editInfo = action3.GetEditInfo("'9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    string_7 = editInfo.Rows[0]["Title"].ToString();
                }
                mail.Subject = string_7;
                mail.Body = reset.ChangePasswordEmailReset(Page.Server.HtmlDecode(s));
                mail.From = string_5;
                if (!mail.Send())
                {
                    send = Add(memLoginID, email, 0, mail.Body);
                    if (action3.AddEmailGroupSend(send) > 0)
                    {
                        MessageBox.Show("Send Email Error");
                    }
                }
                else
                {
                    send = Add(memLoginID, email, 2, mail.Body);
                    int num = action3.AddEmailGroupSend(send);
                    if (ShopSettings.IsOverrideUrl)
                    {
                        Page.Response.Redirect("~/FindPasswordFinal.html?email=" + email + "&type=findPwd");
                    }
                    else
                    {
                        Page.Response.Redirect("~/FindPasswordFinal.aspx?email=" + email + "&type=findPwd");
                    }
                }
            }
        }

        public string ExistEmail(string email)
        {
            if (LogicFactory.CreateShopNum1_Member_Action().CheckmemEmail(email) > 0)
            {
                return "1";
            }
            return "0";
        }

        protected void GetEmailSetting()
        {
            string_0 = Page.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
            string_1 = Page.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
            string_3 = Page.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
            string_2 = Page.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
            string_4 = Page.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
            string_5 = Page.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
            string_6 = Page.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
        }

        protected override void InitializeSkin(Control skin)
        {
            string script = "function existemail(inputcontrol) {\n";
            script = ((((script + "var context = document.getElementById(\"spanEmail\");\n" +
                         "var arg = \"ExistEmail|\" + inputcontrol.value;\n") + "if(inputcontrol.value != \"\") {\n" +
                        "var reg = new RegExp(\"\\\\w+([-+.']\\\\w+)*@\\\\w+([-.]\\\\w+)*\\\\.\\\\w+([-.]\\\\w+)*\");\n") +
                       "if(reg.test(inputcontrol.value)) {\n" + "context.innerHTML = \"数据查询中..\"; ") +
                      Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context") + "; }\n") +
                     "else { context.innerHTML = \"电子邮箱格式不正确\"; }\n}\n" +
                     "else { context.innerHTML = \"电子邮箱不能为空\"; }\n}\n";
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "checkEmail", script, true);
            if (Page.IsPostBack && (Page.Request.Form["__EVENTTARGET"] == "ButtonFindPwdSubmit"))
            {
                ButtonConfirm_Click(null, null);
            }
        }
    }
}