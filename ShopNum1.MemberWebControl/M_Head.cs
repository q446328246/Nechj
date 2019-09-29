using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_Head : BaseMemberWebControl
    {
        private LinkButton ButtonOut;
        private Image ImageShopLogo;
        private Label LabelGouWuChe;
        private Label LabelMemberID;
        private Label LabelMsg;
        private string skinFilename = "M_Head.ascx";

        public M_Head()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetDataInfo()
        {
            LabelMsg.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_UserMessage",
                " and IsDeleted=0 and IsRead=0  AND  ReceiveID='" +
                base.MemLoginID +
                "' ");
            LabelGouWuChe.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Cart",
                "  AND   MemLoginId='" + base.MemLoginID +
                "' and productguid in(select guid from shopnum1_shop_product where issaled=1 and issell=1 and isaudit=1)  ");
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonOut = (LinkButton) skin.FindControl("ButtonOut");
            LabelMemberID = (Label) skin.FindControl("LabelMemberID");
            LabelMemberID.Text = base.MemLoginID;
            ButtonOut.Click += ButtonOut_Click;
            LabelMsg = (Label) skin.FindControl("LabelMsg");
            LabelGouWuChe = (Label) skin.FindControl("LabelGouWuChe");
            ImageShopLogo = (Image) skin.FindControl("ImageShopLogo");
            try
            {
                ImageShopLogo.ImageUrl = ShopSettings.GetValue("MemberLogo");
            }
            catch (Exception)
            {
            }
            GetDataInfo();
        }

        private void ButtonOut_Click(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                cookie.Values.Clear();
                cookie.Expires = Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
                cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                Page.Response.Cookies.Add(cookie);
                Page.Response.Redirect("/default.aspx");
            }
        }
    }
}