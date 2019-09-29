using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class MemberRegisterSuccess : BaseUserControl
    {

        private string string_1 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

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
                        LabelUserName.Text = cookie2.Values["MemLoginID"];
                        LabelUserNo.Text = cookie2.Values["MemLoginNO"];
                    }
                }
            }
        }
    }
}