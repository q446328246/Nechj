using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Logo : BaseWebControl
    {
        private HtmlImage ImageOriginalImge;
        private HtmlAnchor logoLink;
        private string skinFilename = "Logo.ascx";

        public Logo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ImageOriginalImge = (HtmlImage) skin.FindControl("ImageOriginalImge");
            logoLink = (HtmlAnchor) skin.FindControl("logoLink");
            if (!Page.IsPostBack)
            {
            }
            string relativeUrl = ShopSettings.GetValue("Logo");
            ImageOriginalImge.Src = Page.ResolveUrl(relativeUrl);
            logoLink.HRef = ShopSettings.GetValue("Link");
        }
    }
}