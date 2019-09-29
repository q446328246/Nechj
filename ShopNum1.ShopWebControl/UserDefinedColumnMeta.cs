using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class UserDefinedColumnMeta : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "UserDefinedColumnMeta.ascx";

        public UserDefinedColumnMeta()
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
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            DataTable table =
                ((Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action())
                    .MetaGetUserDefinedColumn(MemLoginID,
                        Page.Request.Url.AbsolutePath.Split(new[] {'/'})[7].Split(new[] {'.'})[0]);
            if (table.Rows.Count > 0)
            {
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath("~/Agent/Agent/" + table.Rows[0]["AgentLoginID"] + "/Agent_Settings.xml"));
                DataRow row = set.Tables["Setting"].Rows[0];
                if (table.Rows[0]["Title"].ToString() != string.Empty)
                {
                    LiteralPageTitle.Text = "\n<title>" + table.Rows[0]["Title"] + "</title>\n";
                }
                else
                {
                    LiteralPageTitle.Text = "\n<title>" + table.Rows[0]["Title"] + "</title>\n";
                }
                if (row["KeyWords"].ToString() != string.Empty)
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + row["KeyWords"] + "\">\n";
                }
                else
                {
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + row["Title"] + "\">\n";
                }
                if (row["Description"].ToString() != string.Empty)
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + row["Description"] + "\">\n";
                }
                else
                {
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + row["Title"] + "\">\n";
                }
            }
        }
    }
}