using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_WelcomeProduct : BaseMemberWebControl
    {
        private string skinFilename = "M_WelcomeProduct.ascx";

        public M_WelcomeProduct()
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