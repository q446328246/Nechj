using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleByCategoryIdInOrder : BaseWebControl
    {
        private Repeater RepeaterArticleFirst;
        private string skinFilename = "ArticleByCategoryIdInOrder.ascx";

        public ArticleByCategoryIdInOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ArticleCategoryID { get; set; }

        public int ShowCount { get; set; }

        public string Sort { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterArticleFirst = (Repeater) skin.FindControl("RepeaterArticleFirst");
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            DataTable table = action.SearchByCategoryIDFrist(ArticleCategoryID);
            if (table.Rows.Count > 0)
            {
                RepeaterArticleFirst.DataSource = table.DefaultView;
                RepeaterArticleFirst.DataBind();
                foreach (RepeaterItem item in RepeaterArticleFirst.Items)
                {
                    var field = (HiddenField) item.FindControl("HiddenFieldGuid");
                    var repeater = (Repeater) item.FindControl("RepeaterArticleNew");
                    DataTable table2 = action.SearchByCategoryIDOther(ArticleCategoryID, field.Value,
                        ShowCount.ToString());
                    if (table2.Rows.Count > 0)
                    {
                        repeater.DataSource = table2.DefaultView;
                        repeater.DataBind();
                    }
                }
            }
        }
    }
}