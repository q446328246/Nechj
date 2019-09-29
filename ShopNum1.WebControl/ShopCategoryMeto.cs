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
    public class ShopCategoryMeto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "ShopCategoryMeto.ascx";

        public ShopCategoryMeto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int Type { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");
            if (!Page.IsPostBack)
            {
            }
            var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
            string code = (Page.Request.QueryString["code"] == null) ? "0" : Page.Request.QueryString["code"];
            if (code != "0")
            {
                DataTable shopCategoryMeto = action.GetShopCategoryMeto(code);
                if (shopCategoryMeto.Rows.Count > 0)
                {
                    LiteralPageTitle.Text = "\n<title>" + shopCategoryMeto.Rows[0]["Name"] +
                                            string.Empty +
                                            "</title>\n";
                    if (shopCategoryMeto.Rows[0]["Keywords"].ToString() != string.Empty)
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   shopCategoryMeto.Rows[0]["Keywords"] +
                                                   string.Empty + "\">\n";
                    }
                    else
                    {
                        LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"" +
                                                   shopCategoryMeto.Rows[0]["Name"] +
                                                   string.Empty + "\">\n";
                    }
                    if (shopCategoryMeto.Rows[0]["Description"].ToString() != string.Empty)
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      shopCategoryMeto.Rows[0]["Description"] + "\">\n";
                    }
                    else
                    {
                        LiteralPagedescription.Text = "<meta name=\"description\" content=\"" +
                                                      shopCategoryMeto.Rows[0]["Name"] +
                                                      string.Empty + "\">\n";
                    }
                }
            }
            else
            {
                LiteralPageTitle.Text = "\n<title>店铺" + string.Empty + "</title>\n";
                LiteralPagekeywords.Text = "<meta name=\"Keywords\" content=\"店铺" + string.Empty +
                                           "\">\n";
                LiteralPagedescription.Text = "<meta name=\"description\" content=\"店铺" + string.Empty +
                                              "\">\n";
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