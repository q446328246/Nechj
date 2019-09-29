using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopNewsMeta : BaseWebControl
    {
        //private Literal LiteralPageTitle;
        //private Literal LiteralPagedescription;
        //private Literal LiteralPagekeywords;
        private string skinFilename = "ShopNewsMeta.ascx";

        public ShopNewsMeta()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
        }
    }
}