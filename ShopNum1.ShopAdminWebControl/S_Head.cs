using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Head : BaseMemberWebControl
    {
        private LinkButton ButtonOut;
        private Image ImageShopLogo;
        private Label LabelGouWuChe;
        private Label LabelMemberID;
        private Label LabelMsg;
        private string skinFilename = "S_Head.ascx";

        public S_Head()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetDataInfo()
        {
            LabelMsg.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_MemberMessage",
                " and IsDeleted=0 and IsRead=0  AND  Reloginid='" +
                base.MemLoginID +
                "' ");
            LabelGouWuChe.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Cart",
                "  AND   MemLoginId='" + base.MemLoginID +
                "' and productguid in(select guid from shopnum1_shop_product where issaled=1 and issell=1 and isaudit=1)");
        }

        protected override void InitializeSkin(Control skin)
        {
            ImageShopLogo = (Image) skin.FindControl("ImageShopLogo");
            LabelMemberID = (Label) skin.FindControl("LabelMemberID");
            ButtonOut = (LinkButton) skin.FindControl("ButtonOut");
            ButtonOut.Click += ButtonOut_Click;
            LabelMemberID.Text = base.MemLoginID;
            LabelMsg = (Label) skin.FindControl("LabelMsg");
            LabelGouWuChe = (Label) skin.FindControl("LabelGouWuChe");
            try
            {
                ImageShopLogo.ImageUrl = ShopSettings.GetValue("MemberLogo");
            }
            catch (Exception)
            {
            }
            if (!Page.IsPostBack)
            {
                GetDataInfo();
            }
        }

        protected void ButtonOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            cookie.Values.Clear();
            cookie.Expires = Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
            cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
            Page.Response.Cookies.Add(cookie);
            Page.Response.Redirect(GetSiteDomain() + "/default.aspx");
        }

        public static string GetSiteDomain()
        {
            return ("http://" + ShopSettings.siteDomain);
        }
    }
}