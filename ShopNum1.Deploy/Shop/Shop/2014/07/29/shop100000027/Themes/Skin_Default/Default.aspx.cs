using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Common.ShopNum1.Common;
using System.Data;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Shop.Shop._2014._07._29.shop100000027.Themes.Skin_Default
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tag = Page.Request.QueryString["category"];
            if (tag == null && tag == "") 
            {
                tag = CustomerCategory.大唐专区.ToString();
                HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(tag).ToString());
                cookie.Domain = ".t.com";
                cookie.Path = @"/";
                cookie.Expires = DateTime.Now.AddDays(1);
                Page.Response.Cookies.Add(cookie);
            }
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
                    MemRankGuid = MemberLevel.NORMAL_MEMBER_ID;
                }
                //根据会员等级的Guid以及可看属性获得专区板块ID字符串
                DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "1");
                if (linkCategory.Rows.Count > 0)
                {
                    MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
                }
                if (!string.IsNullOrEmpty(MemLinkCategory))
                {
                    //字符串中不包含浏览专区的tag值，说明没有权限查阅，跳回首页
                    if (!MemLinkCategory.Contains(tag))
                    {
                        Response.Redirect("http://www.t.com", true);
                    }
                }
                else
                {
                    Response.Redirect("http://www.t.com", true);
                }
            }
            else
            {
                Response.Redirect("http://www.t.com", true);
            }

        }
    }
}