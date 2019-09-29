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
    public class ProductConsultListAdd : BaseWebControl
    {
        private Button ButtonConfirm;
        private HtmlTableRow TRVerifyCode;
        private TextBox TextBoxContent;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private string skinFilename = "ProductConsultListAdd.ascx";
        private TextBox textBox_3;

        public ProductConsultListAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected string MemLoginID { get; set; }

        protected string ShopID { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string str3 = Common.Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo",
                    "   AND   ShopID='" + ShopID + "' ");
                if (TextBoxMemLoginID.Text == str3)
                {
                    MessageBox.Show("不能给自己的店铺留言！");
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再留言！");
            }
            else
            {
                TextBoxMemLoginID.ReadOnly = true;
                if (ShopSettings.GetValue("ProductConsultVerifyCode") != "0")
                {
                    if (Page.Session["code"] == null)
                    {
                        MessageBox.Show("验证码有误！");
                        return;
                    }
                    if (textBox_3.Text.Trim().ToUpper() != Page.Session["code"].ToString())
                    {
                        MessageBox.Show("验证码不正确！");
                        return;
                    }
                }
                var action2 = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                string str2 = action2.GetMemberLoginidByShopid(ShopID);
                var productConsult = new ShopNum1_ShopProductConsult
                {
                    Guid = Guid.NewGuid(),
                    ProductGuid = new Guid(Page.Request.QueryString["guid"]),
                    Content = TextBoxContent.Text.Trim(),
                    ConsultPeople = TextBoxMemLoginID.Text.Trim(),
                    Title = TextBoxTitle.Text.Trim()
                };

                if (productConsult.Content.Length>256)
                {
                    productConsult.Content = productConsult.Content.Substring(0, 256);

                }
                if (productConsult.Title.Length>64)
                {
                    productConsult.Title = productConsult.Title.Substring(0, 64);

                }
                
                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    productConsult.MemLoginID = "";
                }
                else
                {
                    productConsult.MemLoginID = MemLoginID;
                }
                productConsult.IsReply = 0;
                productConsult.SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                productConsult.IsDeleted = 0;
                if (ShopSettings.GetValue("ProductConsultISAudit") == "1")
                {
                    productConsult.IsAudit = 0;
                }
                else
                {
                    productConsult.IsAudit = 1;
                }
                productConsult.ShopID = str2;
                productConsult.shop_category_id = CookieCustomerCategory;
                productConsult.IPAddress = Globals.IPAddress;
                var action = (Shop_ProductConsult_Action) LogicFactory.CreateShop_ProductConsult_Action();
                if (action.Add(productConsult) > 0)
                {
                    ClearControl();
                    Page.ClientScript.RegisterStartupScript(base.GetType(), "msg",
                        "<script>alert('恭喜您，留言成功！');window.location.href=window.location.href;</script>",
                        false);
                }
                else
                {
                    MessageBox.Show("留言失败！");
                }
            }
        }

        public void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            TextBoxContent.Text = string.Empty;
            textBox_3.Text = string.Empty;
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            TRVerifyCode = (HtmlTableRow) skin.FindControl("TRVerifyCode");
            textBox_3 = (TextBox) skin.FindControl("TextBoxCode");
            if (ShopSettings.GetValue("ProductConsultVerifyCode") == "0")
            {
                TRVerifyCode.Visible = false;
            }
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            if (!Page.IsPostBack)
            {
            }
            string text1 = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
                TextBoxMemLoginID.Text = MemLoginID;
                TextBoxMemLoginID.Enabled = false;
            }
            else
            {
                TextBoxMemLoginID.Text = "游客";
            }
        }
    }
}