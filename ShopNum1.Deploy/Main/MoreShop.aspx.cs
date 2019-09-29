using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Common;
using System.Data;

namespace ShopNum1.Deploy.Main
{
    public partial class MoreShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(CustomerCategory.BTC专区).ToString());
            cookie.Domain = string.Format(".{0}", ShopSettings.siteDiscuzCookieDomain);
            cookie.Path = @"/";
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            ///Shop/Shop/2014/07/29/shop100000027/Default.aspx?shopId=100000027
            var dataSet = new DataSet();
            dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
            string INDEXURL = dataRow["OverrideDomain"].ToString();
            Response.Redirect("http://"+ INDEXURL +"/ShopListSearch.aspx?category=9", true);

            

        }
        
    }
   
}