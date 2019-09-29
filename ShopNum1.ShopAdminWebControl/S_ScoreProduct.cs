using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ScoreProduct : BaseShopWebControl
    {
        private string skinFilename = "S_ScoreProduct.ascx";

        public S_ScoreProduct()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
        }
    }
}