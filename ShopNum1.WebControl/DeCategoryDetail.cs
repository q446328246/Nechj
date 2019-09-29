using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeCategoryDetail : BaseWebControl
    {
        private Repeater RepeaterCategory;
        private string skinFilename = "DeCategoryDetail.ascx";

        public DeCategoryDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string code { get; set; }

        public string ShowCount { get; set; }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).SearchByType(
                    code, ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            BindData();
        }
    }
}