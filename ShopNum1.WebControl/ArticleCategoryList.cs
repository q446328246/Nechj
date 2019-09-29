using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleCategoryList : BaseWebControl
    {
        private Repeater RepeaterData;
        private DataList RepeaterDataTitle;
        private string skinFilename = "ArticleCategoryList.ascx";

        public ArticleCategoryList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ArticleCategoryID { get; set; }

        public string FatherID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData("4");
        }

        protected void BindData(string string_3)
        {
            RepeaterData.DataSource =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action())
                    .GetArticleCategory(string_3);
            RepeaterData.DataBind();
        }

        protected void method_1(string string_3)
        {
            RepeaterDataTitle.DataSource =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action())
                    .GetArticleCategory(string_3);
            RepeaterDataTitle.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterDataTitle = (DataList) e.Item.FindControl("RepeaterDataTitle");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            method_1(field.Value);
        }
    }
}