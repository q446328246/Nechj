using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ExitProduct : BaseShopWebControl
    {
        private string skinFilename = "S_ExitProduct.ascx";

        public S_ExitProduct()
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
            }
        }
    }
}