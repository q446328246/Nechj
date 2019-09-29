using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleSearchNofind : BaseWebControl
    {
        private Label LabelProtectSearch;
        private string skinFilename = "ArticleSearchNofind.ascx";

        public ArticleSearchNofind()
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
            ProtectName = (Page.Request.QueryString["search"] == null) ? "" : Page.Request.QueryString["search"];
            LabelProtectSearch.Text = ProtectName.Trim();
        }
    }
}