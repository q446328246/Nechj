using System;
using System.Configuration;
using System.Web;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Head : BaseMemberControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    LabelMemberID.Text = base.MemLoginID;
                    ImageShopLogo.ImageUrl = ShopSettings.GetValue("MemberLogo");
                    if (base.MemLoginID.ToUpper() == "C0000001")
                    {
                        lim.Visible = true;
                        limm.Visible = true;
                    }
                    else 
                    {
                        lim.Visible = false;
                        limm.Visible = false;
                    }
                }
                catch (Exception)
                {
                }
                GetDataInfo();
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

        protected void ButtonOut_Click(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                cookie.Values.Clear();
                cookie.Expires = Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
                cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                Page.Response.Cookies.Add(cookie);
                Page.Response.Redirect(GetSiteDomain() + "/default.aspx");
            }
        }

        public static string GetSiteDomain()
        {
            return ("http://" + ShopSettings.siteDomain);
        }
    }
}