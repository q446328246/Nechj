using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PasswordReminderUrl : BaseWebControl
    {
        private Panel PanelNO;
        private Panel PanelOK;
        private string skinFilename = "PasswordReminderUrl.ascx";

        public PasswordReminderUrl()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if ((Page.Request.QueryString["type"] == null) || (Page.Request.QueryString["key"] == null))
            {
                if (ShopSettings.IsOverrideUrl)
                {
                    Page.Response.Redirect("~/Login" + ShopSettings.overrideUrlName);
                }
                else
                {
                    Page.Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                string str = Page.Request.Form["TextBoxPwd"];
                LogicFactory.CreateShopNum1_Member_Action();
                IShopNum1_MemberPwd_Action action = LogicFactory.CreateShopNum1_MemberPwd_Action();
                string str2 = string.Empty;
                string input = string.Empty;
                input = str;
                var pwd = new ShopNum1_MemberPwd
                {
                    MemberID = str2
                };
                pwd.Pwd = Encryption.GetMd5Hash(input);
                pwd.pwdkey =
                    Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss") +
                                                new Random().Next()).Substring(0, 8);
                pwd.type = 0;
                pwd.extireTime = Convert.ToDateTime(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                pwd.Email = str2;
                action.UpdatePwd(Page.Request.QueryString["key"], Page.Request.QueryString["type"],
                    Encryption.GetMd5Hash(input));
                if (
                    action.ShopNum1MemberPwdExec(Page.Request.QueryString["key"], Page.Request.QueryString["type"]).Rows
                        [0]["Result"].ToString() == "1")
                {
                    if (ShopSettings.IsOverrideUrl)
                    {
                        Page.Response.Redirect("~/FindPasswordSuccess.html");
                    }
                    else
                    {
                        Page.Response.Redirect("~/FindPasswordSuccess.aspx");
                    }
                }
                else
                {
                    PanelNO.Visible = true;
                    PanelOK.Visible = false;
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelOK = (Panel) skin.FindControl("PanelOK");
            PanelNO = (Panel) skin.FindControl("PanelNO");
            if (!Page.IsPostBack &&
                ((Page.Request.QueryString["key"] != null) && (Page.Request.QueryString["type"] != null)))
            {
                YZemail();
            }
            if (Page.IsPostBack && (Page.Request.Form["__EmailEVENTTARGET"] == "ButtonFindPwdSubmit"))
            {
                ButtonConfirm_Click(null, null);
            }
        }

        public void YZemail()
        {
            if (
                LogicFactory.CreateShopNum1_MemberPwd_Action()
                    .CheckLink(Page.Request.QueryString["key"], Page.Request.QueryString["type"])
                    .Rows.Count <= 0)
            {
                PanelNO.Visible = true;
                PanelOK.Visible = false;
            }
        }
    }
}