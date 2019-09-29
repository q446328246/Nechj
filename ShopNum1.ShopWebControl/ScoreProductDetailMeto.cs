using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ScoreProductDetailMeto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ScoreProductDetailMeto.ascx";

        public ScoreProductDetailMeto()
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
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");
            string str = Common.Common.GetNameById("Name", "ShopNum1_Shop_ScoreProduct",
                "   AND  Guid='" + Page.Request.QueryString["guid"] + "'");
            string str2 = Common.Common.GetNameById("Meto_Keywords", "ShopNum1_Shop_ScoreProduct",
                "   AND  Guid='" + Page.Request.QueryString["guid"] + "'");
            string str3 = Common.Common.GetNameById("Meto_Description", "ShopNum1_Shop_ScoreProduct",
                "   AND  Guid='" + Page.Request.QueryString["guid"] + "'");
            LiteralPageTitle.Text = "\n<title>" + str + "_" + ShopSettings.GetValue("Title") +
                                    Common.Common.GetCopyright() +
                                    "</title>\n";
            if (!string.IsNullOrEmpty(str2))
            {
                LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + str2 + Common.Common.GetCopyright() +
                                           "\">\n";
            }
            else
            {
                LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + str + Common.Common.GetCopyright() +
                                           "\">\n";
            }
            if (!string.IsNullOrEmpty(str3))
            {
                LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + str3 +
                                              Common.Common.GetCopyright() + "\">\n";
            }
            else
            {
                LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + str +
                                              Common.Common.GetCopyright() + "\">\n";
            }
        }
    }
}