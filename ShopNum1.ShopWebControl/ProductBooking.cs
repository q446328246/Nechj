using System;
using System.Data;
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
    public class ProductBooking : BaseWebControl
    {
        private Button ButtonConfirm;
        private TextBox TextBoxAddress;
        private TextBox TextBoxEmail;
        private TextBox TextBoxMobile;
        private TextBox TextBoxName;
        private TextBox TextBoxPostalcode;
        private TextBox TextBoxRank;
        private TextBox TextBoxSendDate;
        private TextBox TextBoxTel;
        private HtmlInputReset inputReset;
        private string skinFilename = "ProductBooking.ascx";
        private string string_1;

        public ProductBooking()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string MemLoginID { get; set; }

        public string ProductName { get; set; }

        public string ShopID { get; set; }

        public string ShopName { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var productBooking = new ShopNum1_Shop_ProductBooking
            {
                Name = TextBoxName.Text.Trim(),
                ProductGuid = Guid,
                ProductName = ProductName,
                Email = TextBoxEmail.Text.Trim(),
                Address = TextBoxAddress.Text.Trim(),
                Postalcode = TextBoxPostalcode.Text.Trim(),
                Tel = TextBoxTel.Text.Trim(),
                Mobile = TextBoxMobile.Text.Trim(),
                SendDate = Convert.ToDateTime(TextBoxSendDate.Text.Trim()),
                Rank = TextBoxRank.Text.Trim(),
                IsAudit = 0,
                MemLoginID = MemLoginID,
                ShopID = ShopID
            };
            var action = (Shop_ProductBooking_Action) LogicFactory.CreateShop_ProductBooking_Action();
            if (action.AddProductBooking(productBooking) > 0)
            {
                MessageBox.Show("预约成功");
                ClearControl();
            }
            else
            {
                MessageBox.Show("预约失败！");
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxPostalcode.Text = string.Empty;
            TextBoxTel.Text = string.Empty;
            TextBoxMobile.Text = string.Empty;
            TextBoxSendDate.Text = string.Empty;
            TextBoxRank.Text = string.Empty;
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                GetUrl.RedirectLogin();
            }
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            Guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            ProductName = (Page.Request.QueryString["productName"] == null)
                ? "0"
                : Page.Request.QueryString["productName"];
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = (cookie2.Values["MemLoginID"] == null) ? "" : cookie2.Values["MemLoginID"];
                string_1 = (cookie2.Values["Name"] == null) ? "" : cookie2.Values["Name"];
            }
            DataTable shopInfo = ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopInfo(ShopID);
            try
            {
                ShopName = shopInfo.Rows[0]["ShopName"].ToString();
            }
            catch
            {
            }
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            TextBoxEmail = (TextBox) skin.FindControl("TextBoxEmail");
            TextBoxAddress = (TextBox) skin.FindControl("TextBoxAddress");
            TextBoxPostalcode = (TextBox) skin.FindControl("TextBoxPostalcode");
            TextBoxTel = (TextBox) skin.FindControl("TextBoxTel");
            TextBoxMobile = (TextBox) skin.FindControl("TextBoxMobile");
            TextBoxRank = (TextBox) skin.FindControl("TextBoxRank");
            TextBoxSendDate = (TextBox) skin.FindControl("TextBoxSendDate");
            inputReset = (HtmlInputReset) skin.FindControl("inputReset");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
        }
    }
}