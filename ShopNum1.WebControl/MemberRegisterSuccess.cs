using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MemberRegisterSuccess : BaseWebControl, ICallbackEventHandler
    {
        private Label LabelUserName;
        private LinkButton LinkButtonLogin;
        private Panel PanelMobile;
        private Panel PanelNO;
        private Panel PanelSan;
        private Panel PanelYes;
        private string skinFilename = "MemberRegisterSuccess.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;

        public MemberRegisterSuccess()
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
            LinkButtonLogin = (LinkButton) skin.FindControl("LinkButtonLogin");
            PanelYes = (Panel) skin.FindControl("PanelYes");
            PanelNO = (Panel) skin.FindControl("PanelNO");
            PanelSan = (Panel) skin.FindControl("PanelSan");
            PanelMobile = (Panel) skin.FindControl("PanelMobile");
            LabelUserName = (Label) skin.FindControl("LabelUserName");
            if (!Page.IsPostBack)
            {
                LinkButtonLogin.PostBackUrl = GetPageName.RetDomainUrl("Login");
                if (Page.Request.QueryString["type"] != null)
                {
                    string_1 = Page.Request.QueryString["type"];
                    if (string_1 == "1")
                    {
                        PanelYes.Visible = true;
                        PanelNO.Visible = false;
                        PanelSan.Visible = false;
                        PanelMobile.Visible = false;
                    }
                    else if (string_1 == "0")
                    {
                        PanelYes.Visible = false;
                        PanelNO.Visible = true;
                        PanelSan.Visible = false;
                    }
                    else if ((string_1 == "2") && (Page.Request.QueryString["MemLoginID"] != null))
                    {
                        if (Page.Request.Cookies["MemberLoginCookie"] == null)
                        {
                            Page.Response.Write(
                                "<script>window.top.location.target= '_blank '; window.top.location.href='" +
                                GetPageName.RetUrl("Login") + "' </script>");
                        }
                        PanelYes.Visible = false;
                        PanelNO.Visible = false;
                        PanelSan.Visible = true;
                        PanelMobile.Visible = false;
                        HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                        string_2 = cookie2.Values["MemLoginID"];
                        LabelUserName.Text = cookie2.Values["MemLoginID"];
                    }
                }
            }
        }
    }
}