using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class Foot : BaseWebControl
    {
        private string skinFilename = "Foot.ascx";

        public Foot()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string guid { get; set; }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
        }
    }
}