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
    public class DeBrandList : BaseWebControl
    {
        private Repeater RepeaterBrand;
        private string skinFilename = "DeBrandList.ascx";

        public DeBrandList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterBrand = (Repeater) skin.FindControl("RepeaterBrand");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action();
            string pagesize = ShopSettings.GetValue("DefaultRecommendBrandCount");
            DataTable table = action.SearchBrand(pagesize);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterBrand.DataSource = table.DefaultView;
                RepeaterBrand.DataBind();
            }
        }
    }
}