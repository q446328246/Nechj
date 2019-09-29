using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_Left : BaseMemberWebControl
    {
        private string skinFilename = "A_Left.cs";

        public A_Left()
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