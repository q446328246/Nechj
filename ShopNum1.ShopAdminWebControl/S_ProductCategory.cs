using System.Data;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ProductCategory : BaseShopWebControl
    {
        public static DataTable dt_ProdcutCategory = null;
        private string skinFilename = "S_ProductCategory.ascx";

        public S_ProductCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (!Page.IsPostBack)
            {
                dt_ProdcutCategory = new Shop_ProductCategory_Action().Search(0, base.MemLoginID);
            }
        }
    }
}