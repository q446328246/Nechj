using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleRelatedArticle : BaseWebControl
    {
        private DataList DataListArticleRelatedArticle;
        private string skinFilename = "ArticleRelatedArticle.ascx";

        public ArticleRelatedArticle()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DataListArticleRelatedArticle = (DataList) skin.FindControl("DataListArticleRelatedArticle");
            string str = "0";
            if (!Page.IsPostBack)
            {
            }
            str = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (str != "0")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            string str =
                new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                    "ArticleRelatedArticleListCount");
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).SearchArticleRelatedArticle(
                    Page.Request.QueryString["guid"], Convert.ToInt32(str));
            DataListArticleRelatedArticle.DataSource = table.DefaultView;
            DataListArticleRelatedArticle.DataBind();
        }
    }
}