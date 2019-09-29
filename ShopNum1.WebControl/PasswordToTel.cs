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
    public class PasswordToTel : BaseWebControl
    {
        private Button ButtonReturnSend;
        private LinkButton LinkButtonTel;
        private string skinFilename = "PasswordToTel.ascx";
        private string string_1;
        private string string_2;

        public PasswordToTel()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonReturnSend_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["tel"] != null)
            {
                string_2 = Page.Request.QueryString["tel"];
            }
            DataTable table = ExistMobiles(string_2);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("手机号码不存在!");
            }
            else
            {
                string memLoginID = table.Rows[0]["MemLoginID"].ToString();
                string str3 = SetNewPwd(memLoginID);
                string content = "亲爱的" + memLoginID + ",您的多用户登录密码是：" + str3 + ",请立即修改密码,本条短信请勿回复！";
                string retmsg = "";
                new SMS().Send(string_2, content + "【唐江宝宝】", out retmsg);
                InsertData(memLoginID + "-" + string_2, content);
                if (retmsg == "发送成功")
                {
                    if (ShopSettings.IsOverrideUrl)
                    {
                        Page.Response.Redirect("~/FindPasswordFinalTel.html?tel=" + string_2);
                    }
                    else
                    {
                        Page.Response.Redirect("~/FindPasswordFinalTel.aspx?tel=" + string_2);
                    }
                }
            }
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
            LinkButtonTel = (LinkButton) skin.FindControl("LinkButtonTel");
            ButtonReturnSend = (Button) skin.FindControl("ButtonReturnSend");
            ButtonReturnSend.Click += ButtonReturnSend_Click;
            if (!Page.IsPostBack)
            {
                LinkButtonTel.PostBackUrl = GetPageName.RetDomainUrl("index");
                if (Page.Request.QueryString["tel"] != null)
                {
                    if (Page.Request.QueryString["tel"] == "")
                    {
                        if (ShopSettings.IsOverrideUrl)
                        {
                            Page.Response.Redirect("~/PasswordToTelErr.html");
                        }
                        else
                        {
                            Page.Response.Redirect("~/PasswordToTelErr.aspx");
                        }
                    }
                    string_1 = Page.Request.QueryString["tel"];
                    DataTable table = ExistMobiles(Page.Request.QueryString["tel"]);
                    if ((table == null) || (table.Rows.Count <= 0))
                    {
                        if (ShopSettings.IsOverrideUrl)
                        {
                            Page.Response.Redirect("~/PasswordToTelErr.html");
                        }
                        else
                        {
                            Page.Response.Redirect("~/PasswordToTelErr.aspx");
                        }
                    }
                }
                else if (ShopSettings.IsOverrideUrl)
                {
                    Page.Response.Redirect("~/PasswordToTelErr.html");
                }
                else
                {
                    Page.Response.Redirect("~/PasswordToTelErr.aspx");
                }
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