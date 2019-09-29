using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DomainCopyright : BaseWebControl
    {
        private Label labelButtomInfo;
        private string skinFilename = "DomainCopyright.ascx";

        public DomainCopyright()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            labelButtomInfo = (Label) skin.FindControl("labelButtomInfo");
            if (!Page.IsPostBack)
            {
            }
            labelButtomInfo.Text = Page.Server.HtmlDecode(ShopSettings.GetValue("ButtomInfo"));
        }
    }
}