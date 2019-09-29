using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_Left : BaseMemberWebControl
    {
        private string skinFilename = "M_Left.ascx";

        public M_Left()
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