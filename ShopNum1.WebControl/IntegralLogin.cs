using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class IntegralLogin : BaseWebControl
    {
        private Image ImagePhoto;
        private Label LabelScore;
        private Button LoginUser;
        private Panel PanelDiv;
        private Panel PanelLogin;
        private string skinFilename = "IntegralLogin.ascx";

        public IntegralLogin()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("/Login.html");
        }

        protected override void InitializeSkin(Control skin)
        {
            ImagePhoto = (Image) skin.FindControl("ImagePhoto");
            PanelDiv = (Panel) skin.FindControl("PanelDiv");
            PanelLogin = (Panel) skin.FindControl("PanelLogin");
            LoginUser = (Button) skin.FindControl("LoginUser");
            LoginUser.Click += LoginUser_Click;
            LabelScore = (Label) skin.FindControl("LabelScore");
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
                PanelLogin.Visible = true;
                PanelDiv.Visible = false;
                var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
                try
                {
                    DataTable scoreByMemLoginID = action.GetScoreByMemLoginID(MemLoginID);
                    DataTable photoByMemLoginID = action.GetPhotoByMemLoginID(MemLoginID);
                    if ((scoreByMemLoginID != null) && (scoreByMemLoginID.Rows.Count > 0))
                    {
                        if (!string.IsNullOrEmpty(scoreByMemLoginID.Rows[0]["Score"].ToString()))
                        {
                            LabelScore.Text = scoreByMemLoginID.Rows[0]["Score"].ToString();
                        }
                        else
                        {
                            LabelScore.Text = "0";
                        }
                    }
                    else
                    {
                        LabelScore.Text = "0";
                    }
                    if ((photoByMemLoginID != null) && (photoByMemLoginID.Rows.Count > 0))
                    {
                        ImagePhoto.ImageUrl = photoByMemLoginID.Rows[0]["Photo"].ToString();
                    }
                }
                catch (Exception)
                {
                    LabelScore.Text = "0";
                }
            }
            else
            {
                PanelLogin.Visible = false;
                PanelDiv.Visible = true;
            }
        }
    }
}