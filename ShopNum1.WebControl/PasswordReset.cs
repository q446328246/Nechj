using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PasswordReset : BaseWebControl
    {
        private Button ButtonFindPwdSubmit;
        private HiddenField HdFieldMobile;
        private HiddenField HiddenFieldMemID;
        private HiddenField HiddenFieldType;
        private Panel PanelNO;
        private Panel PanelOK;
        private TextBox TextBoxPwd;
        private TextBox TextBoxPwd2;
        private string skinFilename = "PasswordReset.ascx";

        public PasswordReset()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void ButtonFindPwdSubmit_Click(object sender, EventArgs e)
        {
            if ((Page.Request.QueryString["type"] == null) || (Page.Request.QueryString["key"] == null))
            {
                if (HiddenFieldType.Value == "5")
                {
                    string str = string.Empty;
                    var random = new Random();
                    for (int i = 0; i < 7; i++)
                    {
                        str = str + random.Next(0, 9);
                    }
                    var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                    if (
                        action.UpdatePwd(HiddenFieldMemID.Value.Trim(), Encryption.GetMd5Hash(TextBoxPwd.Text.Trim())) ==
                        1)
                    {
                        action.DeleteMemberActivate(HdFieldMobile.Value);
                        HiddenFieldType.Value = "4";
                    }
                    else
                    {
                        PanelNO.Visible = true;
                        PanelOK.Visible = false;
                    }
                }
                else if (ShopSettings.IsOverrideUrl)
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
                string str2 = TextBoxPwd.Text.Trim();
                LogicFactory.CreateShopNum1_Member_Action();
                IShopNum1_MemberPwd_Action action2 = LogicFactory.CreateShopNum1_MemberPwd_Action();
                string str3 = string.Empty;
                string input = string.Empty;
                input = str2;
                var pwd = new ShopNum1_MemberPwd
                {
                    MemberID = str3
                };
                pwd.Pwd = Encryption.GetMd5Hash(input);
                pwd.pwdkey =
                    Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss") +
                                                new Random().Next()).Substring(0, 8);
                pwd.type = 0;
                pwd.extireTime = Convert.ToDateTime(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                pwd.Email = str3;
                action2.UpdatePwd(Page.Request.QueryString["key"], Page.Request.QueryString["type"],
                    Encryption.GetMd5Hash(input));
                if (
                    action2.ShopNum1MemberPwdExec(Page.Request.QueryString["key"], Page.Request.QueryString["type"])
                        .Rows[0]["Result"].ToString() == "1")
                {
                    HiddenFieldType.Value = "4";
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
            TextBoxPwd = (TextBox) skin.FindControl("TextBoxPwd");
            TextBoxPwd2 = (TextBox) skin.FindControl("TextBoxPwd2");
            HiddenFieldType = (HiddenField) skin.FindControl("HiddenFieldType");
            HiddenFieldMemID = (HiddenField) skin.FindControl("HiddenFieldMemID");
            HdFieldMobile = skin.FindControl("HdFieldMobile") as HiddenField;
            ButtonFindPwdSubmit = (Button) skin.FindControl("ButtonFindPwdSubmit");
            ButtonFindPwdSubmit.Click += ButtonFindPwdSubmit_Click;
            if (!Page.IsPostBack &&
                ((Page.Request.QueryString["key"] != null) && (Page.Request.QueryString["type"] != null)))
            {
                YZemail();
                HiddenFieldType.Value = "0";
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
                HiddenFieldType.Value = "1";
            }
            else
            {
                HiddenFieldType.Value = "0";
            }
        }
    }
}