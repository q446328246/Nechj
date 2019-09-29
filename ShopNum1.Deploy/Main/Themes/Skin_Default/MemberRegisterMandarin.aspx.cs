using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default
{
    public partial class MemberRegisterMandarin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.Request.QueryString["recommendid"].ToString() != "" || Page.Request.QueryString["recommendid"].ToString() != null)
            //{
            //    LinkButtonLoginOut_Click(null, null);
            //    Response.Redirect("~/MemberRegisterMandarin.aspx?recommendid=" + Page.Request.QueryString["recommendid"].ToString());
            //}
            
        }
        private void LinkButtonLoginOut_Click(object sender, EventArgs e)
        {

            //本地清除cookie
            if (Page.Request.Cookies["category"] != null)
            {
                HttpCookie shopnum1Cookie = Page.Request.Cookies["category"];
                shopnum1Cookie.Values.Clear();
                shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
                shopnum1Cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                Page.Response.Cookies.Add(shopnum1Cookie);
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {

                HttpCookie shopnum1Cookie = Page.Request.Cookies["MemberLoginCookie"];
                shopnum1Cookie.Values.Clear();
                shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
                shopnum1Cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                Page.Response.Cookies.Add(shopnum1Cookie);
            }
            if (Page.Request.Cookies["dnt"] != null)
            {

                HttpCookie shopnum1Cookie = Page.Request.Cookies["dnt"];
                shopnum1Cookie.Values.Clear();
                shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
                shopnum1Cookie.Domain = ConfigurationManager.AppSettings["DiscuzCookieDomain"].ToString();
                Page.Response.Cookies.Add(shopnum1Cookie);
            }

             
        }
    }
}