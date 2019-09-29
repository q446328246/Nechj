using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class MessageBoardAdd : BaseWebControl
    {
        private Button ButtonConfrim;
        private Image CheckImage;
        private Label LabelMemLoginID;
        private LinkButton LinkButtonLogin;
        private Panel PanelAdd;
        private Panel PanelOut;
        private RadioButtonList RadioButtonListmessageType;
        private TextBox TextBoxCode;
        private TextBox TextBoxContent;
        private TextBox TextBoxTitle;
        private HtmlTableRow VerifyCode;
        private LinkButton linkButtonConfrim;
        private string skinFilename = "MessageBoardAdd.ascx";
        private string string_1;

        public MessageBoardAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public string ShopID { get; set; }

        public string shopName { get; set; }

        public void ButtonConfrim_Click(object sender, EventArgs e)
        {
            var messageBoard = new ShopNum1_Shop_MessageBoard();
            if (ShopSettings.GetValue("ShopMessageCondition") == "1")
            {
                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    Common.GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再评论！");
                    return;
                }
                messageBoard.MemLoginID = MemberLoginID;
            }
            else
            {
                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    Common.GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再留言！");
                    return;
                }
                messageBoard.MemLoginID = MemberLoginID;
            }
            if (string_1 != MemberLoginID)
            {
                if (ShopSettings.GetValue("ShopMessageVerifyCode") == "1")
                {
                    if (Page.Session["code"] == null)
                    {
                        MessageBox.Show("验证码有误！");
                        return;
                    }
                    if (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString())
                    {
                        MessageBox.Show("验证码不正确！");
                        return;
                    }
                }
                messageBoard.Guid = Guid.NewGuid();
                messageBoard.MessageType = Convert.ToInt32(RadioButtonListmessageType.SelectedValue);
                messageBoard.Title = TextBoxTitle.Text;
                messageBoard.Content = TextBoxContent.Text;
                messageBoard.SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                messageBoard.IsReply = 0;
                messageBoard.IsShow = 1;
                messageBoard.ReplyUser = string_1;
                messageBoard.shop_category_id = CookieCustomerCategory;
                var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
                if (action.AddMemMessageBoard(messageBoard) > 0)
                {
                    MessageBox.Show("留言成功！");
                    Page.Response.Redirect(
                        string.Concat(new object[] { "http://", Page.Request.Url.Host, "/ShopMessageBoard.aspx?type=" + messageBoard.MessageType + "&category=" + CookieCustomerCategory }));
                }
                else
                {
                    MessageBox.Show("留言失败！");
                }
            }
            else
            {
                MessageBox.Show("不能给自己店铺留言！");
            }
        }

        public static string GetUrl(string pageName)
        {
            return ("http://" + ShopSettings.siteDomain + pageName);
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
            }
            PanelAdd = (Panel) skin.FindControl("PanelAdd");
            PanelOut = (Panel) skin.FindControl("PanelOut");
            if (ShopSettings.GetValue("ShopMessageCondition") == "1")
            {
                if (Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    PanelAdd.Visible = true;
                    PanelOut.Visible = false;
                }
                else
                {
                    PanelAdd.Visible = false;
                    PanelOut.Visible = true;
                }
            }
            else
            {
                PanelAdd.Visible = true;
                PanelOut.Visible = false;
            }
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string_1 = action.GetMemberLoginidByShopid(ShopID);
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            CheckImage = (Image) skin.FindControl("CheckImage");
            ButtonConfrim = (Button) skin.FindControl("ButtonConfrim");
            RadioButtonListmessageType = (RadioButtonList) skin.FindControl("RadioButtonListmessageType");
            linkButtonConfrim = (LinkButton) skin.FindControl("LinkButtonRegister");
            linkButtonConfrim.Click += linkButtonConfrim_Click;
            LinkButtonLogin = (LinkButton) skin.FindControl("LinkButtonLogin");
            LinkButtonLogin.Click += LinkButtonLogin_Click;
            VerifyCode = (HtmlTableRow) skin.FindControl("VerifyCode");
            if (MemberLoginID != null)
            {
                LabelMemLoginID.Text = MemberLoginID;
            }
            BindData();
            ButtonConfrim.Click += ButtonConfrim_Click;
            if (ShopSettings.GetValue("ShopMessageVerifyCode") == "1")
            {
                VerifyCode.Visible = true;
            }
            else
            {
                VerifyCode.Visible = false;
            }
        }

        protected void linkButtonConfrim_Click(object sender, EventArgs e)
        {
            string str = "http://" + ShopSettings.siteDomain + "/MemberRegister" +
                         (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg",
                "location.href='" + str + "?goback=" +
                Page.Server.UrlEncode(Page.Request.Url.AbsoluteUri) + "';", true);
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            string str = "http://" + ShopSettings.siteDomain + "/Login" +
                         (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg",
                "location.href='" + str + "?goback=" +
                Page.Server.UrlEncode(Page.Request.Url.AbsoluteUri) + "';", true);
        }

        protected void BindData()
        {
            var item = new ListItem
            {
                Text = "询问",
                Value = "0"
            };
            RadioButtonListmessageType.Items.Add(item);
            var item2 = new ListItem
            {
                Text = "求购",
                Value = "1"
            };
            RadioButtonListmessageType.Items.Add(item2);
            var item3 = new ListItem
            {
                Text = "售后",
                Value = "2"
            };
            RadioButtonListmessageType.Items.Add(item3);
            var item4 = new ListItem
            {
                Text = "其它",
                Value = "3"
            };
            RadioButtonListmessageType.Items.Add(item4);
            RadioButtonListmessageType.Items[0].Selected = true;
        }
    }
}