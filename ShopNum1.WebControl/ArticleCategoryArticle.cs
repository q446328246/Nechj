using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleCategoryArticle : BaseWebControl
    {
        private Label ArticleCategoryName;
        private Repeater RepeaterArticleCategoryArticle;
        public int int_0 = 0;
        private string skinFilename = "ArticleCategroyArticle.ascx";

        public ArticleCategoryArticle()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ArticleCategoryID { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterArticleCategoryArticle = (Repeater) skin.FindControl("RepeaterArticleCategoryArticle");
            ArticleCategoryName = (Label) skin.FindControl("ArticleCategoryName");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).SearchByArticleCategoryID(
                    Convert.ToInt32(ArticleCategoryID), Convert.ToInt32(ShowCount));
            RepeaterArticleCategoryArticle.DataSource = table.DefaultView;
            RepeaterArticleCategoryArticle.DataBind();
            ArticleCategoryName.Text =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).GetNameByID(
                    Convert.ToInt32(ArticleCategoryID));
        }
    }
}