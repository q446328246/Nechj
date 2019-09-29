using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyDemandMeto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "SupplyDemandMeto.ascx";

        public SupplyDemandMeto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");
            if (!Page.IsPostBack)
            {
            }
            var action = (Shop_SupplyDemand_Action) LogicFactory.CreateShop_SupplyDemand_Action();
            string guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (guid != "0")
            {
                DataTable supplyDemandMeto = action.GetSupplyDemandMeto(guid);
                if (supplyDemandMeto.Rows.Count > 0)
                {
                    LiteralPageTitle.Text = "\n<title>" + supplyDemandMeto.Rows[0]["Title"] +
                                            string.Empty +
                                            "</title>\n";
                    if (supplyDemandMeto.Rows[0]["Keywords"].ToString() != string.Empty)
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   supplyDemandMeto.Rows[0]["Keywords"] +
                                                   string.Empty + "\">\n";
                    }
                    else
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   supplyDemandMeto.Rows[0]["Title"] +
                                                   string.Empty + "\">\n";
                    }
                    if (supplyDemandMeto.Rows[0]["Description"].ToString() != string.Empty)
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      supplyDemandMeto.Rows[0]["Description"] + "\">\n";
                    }
                    else
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      supplyDemandMeto.Rows[0]["Title"] +
                                                      string.Empty + "\">\n";
                    }
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var writer2 = new StringWriter();
            var writer3 = new HtmlTextWriter(writer2);
            LiteralPageTitle.RenderControl(writer3);
            LiteralPagekeywords.RenderControl(writer3);
            LiteralPagedescription.RenderControl(writer3);
            writer.Write(writer2.ToString());
        }
    }
}