using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleRelatedProduct : BaseWebControl
    {
        private DataList DataListArticleRelatedProduct;
        protected bool List = true;
        private string skinFilename = "ArticleRelatedProduct.ascx";

        public ArticleRelatedProduct()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DataListArticleRelatedProduct = (DataList) skin.FindControl("DataListArticleRelatedProduct");
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
            new ShopSettings().GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                "ArticleRelatedProductListCount");
        }
    }
}