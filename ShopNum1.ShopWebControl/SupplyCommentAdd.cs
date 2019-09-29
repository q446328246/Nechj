using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class SupplyCommentAdd : BaseWebControl
    {
        private Button ButtonConfrim;
        private Image CheckImage;
        private Label LabelMemLoginID;
        private LinkButton LinkButtonLogin;
        private Panel PanelAdd;
        private Panel PanelOut;
        private TextBox TextBoxCode;
        private TextBox TextBoxContent;
        private TextBox TextBoxTitle;
        private LinkButton linkButtonConfrim;
        private string skinFilename = "MessageBoardAdd.ascx";
        private string string_1 = string.Empty;
        private string string_2;

        public SupplyCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public string MemLoginID { get; set; }

        public static string ShopID { get; set; }

        public string shopName { get; set; }

        public string StrGuid { get; set; }

        public void ButtonConfrim_Click(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Common.GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
                // cookie2.Values["MemberType"];
                if (Page.Session["code"] != null)
                {
                    if (TextBoxCode.Text.ToUpper() == Page.Session["code"].ToString())
                    {
                        var supplyDemandComment = new ShopNum1_SupplyDemandComment
                        {
                            Guid = Guid.NewGuid(),
                            Title = TextBoxTitle.Text,
                            Content = TextBoxContent.Text,
                            CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsAudit = 1,
                            CreateMerber = MemLoginID,
                            AssociateMemberID = MemberLoginID,
                            CreateIP = Page.Request.UserHostAddress
                        };
                        supplyDemandComment.SupplyDemandGuid = new Guid(StrGuid).ToString();
                        var action = (Shop_SupplyDemand_Action) LogicFactory.CreateShop_SupplyDemand_Action();
                        if (action.SupplyDemandCommentAdd(supplyDemandComment) > 0)
                        {
                            MessageBox.Show("留言成功！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("验证码错误！");
                    }
                }
                else
                {
                    MessageBox.Show("验证码不正确！");
                }
            }
        }

        public static string GetUrl(string pageName)
        {
            return ("http://shop" + ShopID + ConfigurationManager.AppSettings["Domain"] + pageName);
        }

        protected override void InitializeSkin(Control skin)
        {
            StrGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            PanelAdd = (Panel) skin.FindControl("PanelAdd");
            PanelOut = (Panel) skin.FindControl("PanelOut");
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
                string_2 = cookie2.Values["Name"];
                PanelAdd.Visible = true;
                PanelOut.Visible = false;
            }
            else
            {
                PanelAdd.Visible = false;
                PanelOut.Visible = true;
            }
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            CheckImage = (Image) skin.FindControl("CheckImage");
            ButtonConfrim = (Button) skin.FindControl("ButtonConfrim");
            linkButtonConfrim = (LinkButton) skin.FindControl("LinkButtonRegister");
            linkButtonConfrim.Click += linkButtonConfrim_Click;
            LinkButtonLogin = (LinkButton) skin.FindControl("LinkButtonLogin");
            LinkButtonLogin.Click += LinkButtonLogin_Click;
            if (MemberLoginID != null)
            {
                LabelMemLoginID.Text = MemberLoginID;
            }
            ButtonConfrim.Click += ButtonConfrim_Click;
            if (!Page.IsPostBack)
            {
            }
        }

        protected void linkButtonConfrim_Click(object sender, EventArgs e)
        {
            string str = "http://" + ConfigurationManager.AppSettings["Domain"] + "MemberRegister.html";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg",
                "location.href='" + str + "?goback=" +
                Page.Server.UrlEncode(Page.Request.Url.AbsoluteUri) + "';", true);
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            string str = "http://" + ConfigurationManager.AppSettings["Domain"] + "Login.html";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg",
                "location.href='" + str + "?goback=" +
                Page.Server.UrlEncode(Page.Request.Url.AbsoluteUri) + "';", true);
        }
    }
}