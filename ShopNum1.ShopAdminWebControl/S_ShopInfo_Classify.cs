using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopInfo_Classify : BaseShopWebControl
    {
        private string skinFilename = "S_ShopInfo_Classify.ascx";

        public S_ShopInfo_Classify()
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