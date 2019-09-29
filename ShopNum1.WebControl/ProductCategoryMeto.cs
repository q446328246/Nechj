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
    public class ProductCategoryMeto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ProductCategoryMeto.ascx";

        public ProductCategoryMeto()
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

            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            string code = (Page.Request.QueryString["code"] == null) ? "0" : Page.Request.QueryString["code"];
            if (code != "0")
            {
                DataTable productCategoryMeto = action.GetProductCategoryMeto(code);
                if (productCategoryMeto.Rows.Count > 0)
                {
                    LiteralPageTitle.Text = "\n<title>" + productCategoryMeto.Rows[0]["Name"] +
                                            string.Empty +
                                            "</title>\n";
                    if (productCategoryMeto.Rows[0]["Keywords"].ToString() != string.Empty)
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   productCategoryMeto.Rows[0]["Keywords"] +
                                                   string.Empty + "\">\n";
                    }
                    else
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   productCategoryMeto.Rows[0]["Name"] +
                                                   string.Empty + "\">\n";
                    }
                    if (productCategoryMeto.Rows[0]["Description"].ToString() != string.Empty)
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      productCategoryMeto.Rows[0]["Description"] + "\">\n";
                    }
                    else
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      productCategoryMeto.Rows[0]["Name"] +
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