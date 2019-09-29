using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class LookMap : BaseWebControl
    {
        private string skinFilename = "LookMap.ascx";

        public LookMap()
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