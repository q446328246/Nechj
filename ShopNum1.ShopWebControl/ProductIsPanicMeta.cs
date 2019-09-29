using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductIsPanicMeta : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ProductIsPanicMeta.ascx";

        public ProductIsPanicMeta()
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
            var action2 = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            string guid = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            DataTable panicInfoMeta = action2.GetPanicInfoMeta(MemLoginID, guid);
            if (panicInfoMeta.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["Title"].ToString()))
                {
                    LiteralPageTitle.Text = "\n<title>" + panicInfoMeta.Rows[0]["Title"] + "</title>\n";
                }
                else
                {
                    LiteralPageTitle.Text = "\n<title>" + panicInfoMeta.Rows[0]["Title"] + "</title>\n";
                }
                if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["KeyWords"].ToString()))
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + panicInfoMeta.Rows[0]["KeyWords"] +
                                               "\">\n";
                }
                else
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + panicInfoMeta.Rows[0]["Title"] +
                                               "\">\n";
                }
                if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["Description"].ToString()))
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                  panicInfoMeta.Rows[0]["Description"] +
                                                  "\">\n";
                }
                else
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                  panicInfoMeta.Rows[0]["Title"] + "\">\n";
                }
            }
        }
    }
}