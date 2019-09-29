using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopVideoMeta : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ShopVideoMeta.ascx";

        public ShopVideoMeta()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");
            if (!Page.IsPostBack)
            {
            }
            string guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            DataTable videoInfo = ((Shop_Video_Action) LogicFactory.CreateShop_Video_Action()).GetVideoInfo(guid);
            LiteralPageTitle.Text = "\n<title>" + videoInfo.Rows[0]["Title"] + "</title>\n";
            LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + videoInfo.Rows[0]["KeyWords"] + "\">\n";
            LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + videoInfo.Rows[0]["Content"] +
                                          "\">\n";
        }
    }
}