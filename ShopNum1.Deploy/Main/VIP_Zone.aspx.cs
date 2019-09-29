using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Common;
using System.Data;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main
{
    public partial class VIP_Zone : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tag = Page.Request.QueryString["tag"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);
            if (!string.IsNullOrEmpty(tag))
            {
                string MemRankGuid = null;
                string MemLinkCategory = null;
                //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
                if (cookie2 != null)
                {
                    MemRankGuid = cookie2.Values["MemRankGuid"];
                }
                else
                {
                    MemRankGuid = "A6DA75AD-E1AC-4DF8-99AD-980294A16581";
                }
                //根据会员等级的Guid以及可看属性获得专区板块ID字符串
                DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, 1 + "");
                if (linkCategory.Rows.Count > 0)
                {
                    MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
                }
                if (!string.IsNullOrEmpty(MemLinkCategory))
                {
                    //字符串中不包含浏览专区的tag值，说明没有权限查阅，跳回首页
                    if (!MemLinkCategory.Contains(tag))
                    {
                        Response.Redirect(string.Format("http://{0}", ShopSettings.siteDomain), true);
                    }
                }
                else
                {
                    Response.Redirect(string.Format("http://{0}", ShopSettings.siteDomain), true);
                }
            }
            else
            {
                Response.Redirect(string.Format("http://{0}", ShopSettings.siteDomain), true);
            }
            HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(CustomerCategory.VIP专区).ToString());
            cookie.Domain = string.Format(".{0}", ShopSettings.siteDiscuzCookieDomain);
            cookie.Path = @"/";
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            ///Shop/Shop/2014/07/29/shop100000027/Default.aspx?shopId=100000027
            Response.Redirect(string.Format("http://shop100000027.{0}{1}", ShopSettings.siteDiscuzCookieDomain,"?category=2"), true);
        }
    }
}