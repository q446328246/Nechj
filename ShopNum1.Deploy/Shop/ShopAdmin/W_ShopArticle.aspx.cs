using System;
using System.Web.UI;
using ShopNum1.WeiXinBusinessLogic;

public partial class Shop_ShopAdmin_W_ShopArticle : Page
{
    public string Article = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string articleid = Page.Request["id"] ?? string.Empty;

            var shopnum1_weixin_replyrulecontent_active = new ShopNum1_Weixin_ReplyRuleContent_Active();

            Article = shopnum1_weixin_replyrulecontent_active.Get_Article(articleid);
        }
    }
}