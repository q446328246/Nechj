using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopSearchNofind : BaseWebControl
    {
        private Label LabelProtectSearch;
        private string skinFilename = "ShopSearchNofind.ascx";

        public ShopSearchNofind()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProtectName { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LabelProtectSearch = (Label) skin.FindControl("LabelProtectSearch");
            ProtectName = Common.Common.ReqStr("search");
            LabelProtectSearch.Text = ProtectName.Trim();
        }
    }
}