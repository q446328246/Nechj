using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopCategoryCount : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopCategoryCount.ascx";
        private string string_1 = "0";

        public ShopCategoryCount()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCountOne
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable shopCategoryCount =
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetShopCategoryCount(
                    string_1);
            if ((shopCategoryCount != null) && (shopCategoryCount.Rows.Count > 0))
            {
                RepeaterData.DataSource = shopCategoryCount;
                RepeaterData.DataBind();
            }
        }
    }
}