using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryListByCategory : BaseWebControl
    {
        private HtmlAnchor Href;
        private Literal LiteralTitel;
        private Repeater RepeaterSupplyFirst;
        private string skinFilename = "CategoryListByCategory.ascx";

        public CategoryListByCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CategoryCode { get; set; }

        public string ShowCount { get; set; }

        public string Titel { get; set; }

        protected void BindData()
        {
            LiteralTitel.Text = Titel;
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            DataTable table = action.SearchByCategoryIDFrist(CategoryCode);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterSupplyFirst.DataSource = table.DefaultView;
                RepeaterSupplyFirst.DataBind();
                foreach (RepeaterItem item in RepeaterSupplyFirst.Items)
                {
                    var field = (HiddenField) item.FindControl("HiddenFieldGuid");
                    var repeater = (Repeater) item.FindControl("RepeaterData");
                    DataTable table2 = action.SearchByCategoryIDOther(CategoryCode, field.Value, ShowCount);
                    if (table2.Rows.Count > 0)
                    {
                        repeater.DataSource = table2.DefaultView;
                        repeater.DataBind();
                    }
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Href = (HtmlAnchor) skin.FindControl("Href");
            LiteralTitel = (Literal) skin.FindControl("LiteralTitel");
            RepeaterSupplyFirst = (Repeater) skin.FindControl("RepeaterSupplyFirst");
            if (!string.IsNullOrEmpty(CategoryCode))
            {
                Href.HRef = GetPageName.RetUrl("CategoryListSearch", CategoryCode, "code");
            }
            else
            {
                Href.HRef = GetPageName.RetUrl("CategoryListSearch");
            }
            BindData();
        }
    }
}