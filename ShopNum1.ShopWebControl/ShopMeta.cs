using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopMeta : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ShopMeta.ascx";

        public ShopMeta()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public static string ShopID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            string str = action.GetShopNameByShopid(ShopID);
            DataTable shopMetaInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopMetaInfo(MemLoginID);
            if (shopMetaInfo.Rows.Count > 0)
            {
                var set = new DataSet();
                set.ReadXml(
                    Page.Server.MapPath("~/Agent/Agent/" + shopMetaInfo.Rows[0]["AgentLoginID"] + "/Agent_Settings.xml"));
                DataRow row = set.Tables["Setting"].Rows[0];
                if (shopMetaInfo.Rows[0]["Title"].ToString() != string.Empty)
                {
                    LiteralPageTitle.Text = "\n<title>" + str + "  " + shopMetaInfo.Rows[0]["Title"] + "</title>\n";
                }
                else
                {
                    LiteralPageTitle.Text = "\n<title>" + str + "   " + shopMetaInfo.Rows[0]["Title"] + "</title>\n";
                }
                if (row["KeyWords"].ToString() != string.Empty)
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + str + "  " + row["KeyWords"] +
                                               "\">\n";
                }
                else
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + str + "  " + row["Title"] +
                                               "\">\n";
                }
                if (row["Description"].ToString() != string.Empty)
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + str + "  " +
                                                  row["Description"] + "\">\n";
                }
                else
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + str + "  " + row["Title"] +
                                                  "\">\n";
                }
            }
        }
    }
}