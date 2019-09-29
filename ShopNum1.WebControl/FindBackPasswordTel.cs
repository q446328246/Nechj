using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class FindBackPasswordTel : BaseWebControl, ICallbackEventHandler
    {
        private Button button_0;
        private string skinFilename = "FindBackPasswordTel.ascx";
        private string string_1;
        private TextBox textBox_0;

        public FindBackPasswordTel()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetCallbackResult()
        {
            string[] strArray = string_1.Split(new[] {'|'});
            if (strArray.Length == 2)
            {
                return (string) base.GetType().GetMethod(strArray[0]).Invoke(this, new object[] {strArray[1]});
            }
            return (string) base.GetType().GetMethod(strArray[0]).Invoke(this, new object[] {strArray[1], strArray[2]});
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string_1 = eventArgument;
        }

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            DataTable table = ExistMobiles(textBox_0.Text.Trim());
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("手机号码不存在!");
            }
            else
            {
                string memLoginID = table.Rows[0]["MemLoginID"].ToString();
                string str3 = SetNewPwd(memLoginID);
                string content = "亲爱的" + memLoginID + ",您的多用户登录密码是：" + str3 + ",请立即修改密码,本条短信请勿回复！";
                string sendObjectMMS = "亲爱的" + memLoginID + ",您的多用户登录密码是： ******* ,请立即修改密码,本条短信请勿回复！";
                string retmsg = "";
                new SMS().Send(textBox_0.Text.Trim(), content + "【唐江宝宝】", out retmsg);
                InsertData(memLoginID + "-" + textBox_0.Text.Trim(), sendObjectMMS);
                if (retmsg == "发送成功")
                {
                    if (ShopSettings.IsOverrideUrl)
                    {
                        Page.Response.Redirect("~/FindPasswordFinalTel.html?tel=" + textBox_0.Text.Trim());
                    }
                    else
                    {
                        Page.Response.Redirect("~/FindPasswordFinalTel.aspx?tel=" + textBox_0.Text.Trim());
                    }
                }
            }
        }

        public string ExistMobile(string Mobile)
        {
            return LogicFactory.CreateShopNum1_Member_Action().CheckMemMobileByMobile1(Mobile).ToString();
        }

        public DataTable ExistMobiles(string Mobile)
        {
            DataTable table = LogicFactory.CreateShopNum1_Member_Action().CheckMemMobileByMobile(Mobile);
            if (table != null)
            {
                return table;
            }
            return null;
        }

        protected override void InitializeSkin(Control skin)
        {
            textBox_0 = (TextBox) skin.FindControl("TextBoxMobile");
            button_0 = (Button) skin.FindControl("ButtonConfirm");
            button_0.Click += ButtonConfirm_Click;
            string script = "function existmobile(inputcontrol) {\n";
            script = ((((script + "var context = document.getElementById(\"spanMobile\");\n") +
                        "var arg = \"ExistMobile|\" + inputcontrol.value;\n" + @"var reg = /^(1[3|5|7|8][0-9])\d{8}$/") +
                       "\n if(inputcontrol.value != \"\") {\n" +
                       "if(reg.test(inputcontrol.value)) {context.innerHTML = \"数据查询中..\";") +
                      Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerMobileData", "context") +
                      "; }\n") + "else { context.innerHTML = \"手机格式不正确\";}\n}\n" +
                     "else { context.innerHTML = \"手机号码不能为空\";}\n}\n";
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "checkemobile", script, true);
            if (!Page.IsPostBack)
            {
            }
        }

        public void InsertData(string sendObject, string sendObjectMMS)
        {
            var mMSGroupSend = new ShopNum1_MMSGroupSend
            {
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Guid = Guid.NewGuid(),
                IsTime = 0,
                MMSGuid = new Guid("464595bb-4e2a-4240-9b5e-03871e8b1409"),
                MMSTitle = "重设(找回)密码",
                SendObject = sendObject,
                SendObjectMMS = sendObjectMMS,
                State = 0,
                TimeSendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            LogicFactory.CreateShopNum1_MMSGroupSend_Action().Add(mMSGroupSend);
        }

        public string SetNewPwd(string MemLoginID)
        {
            string input = string.Empty;
            var random = new Random();
            for (int i = 0; i < 7; i++)
            {
                input = input + random.Next(0, 9);
            }
            ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).UpdatePwd(MemLoginID,
                Encryption.GetMd5Hash(input));
            return input;
        }
    }
}