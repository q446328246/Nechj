using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class BrandMeto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "BrandMeto.ascx";

        public BrandMeto()
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
            var action = (ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action();
            string guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (guid != "0")
            {
                DataTable brandMeto = action.GetBrandMeto(guid);
                if (brandMeto.Rows.Count > 0)
                {
                    LiteralPageTitle.Text = "\n<title>" + brandMeto.Rows[0]["Name"] + string.Empty +
                                            "</title>\n";
                    if (brandMeto.Rows[0]["Keywords"].ToString() != string.Empty)
                    {
                        LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + brandMeto.Rows[0]["Keywords"] +
                                                   string.Empty + "\">\n";
                    }
                    else
                    {
                        LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + brandMeto.Rows[0]["Name"] +
                                                   string.Empty + "\">\n";
                    }
                    if (brandMeto.Rows[0]["Description"].ToString() != string.Empty)
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      brandMeto.Rows[0]["Description"] +
                                                      string.Empty + "\">\n";
                    }
                    else
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      brandMeto.Rows[0]["Name"] +
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