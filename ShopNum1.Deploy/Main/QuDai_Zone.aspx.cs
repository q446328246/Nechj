using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Common;
namespace ShopNum1.Deploy.Main
{
    public partial class QuDai_Zone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(CustomerCategory.区代社区).ToString());
            cookie.Domain = ShopSettings.siteDiscuzCookieDomain;
            cookie.Path = @"/";
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            ///Shop/Shop/2014/07/29/shop100000027/Default.aspx?shopId=100000027
            
                Response.Redirect(string.Format("http://shop100000027.{0}{1}{2}", ShopSettings.siteDiscuzCookieDomain,"/Default_two.aspx", "?category=8"), true);
        }
    }
}