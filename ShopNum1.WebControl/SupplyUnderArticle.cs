using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyUnderArticle : BaseWebControl
    {
        private Repeater RepeaterArticleFirst;
        private string skinFilename = "SupplyUnderArticle.ascx";

        public SupplyUnderArticle()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ArticleCategoryID { get; set; }

        public int ShowCount { get; set; }

        public string Sort { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterArticleFirst = (Repeater) skin.FindControl("RepeaterArticleFirst");
        }
    }
}