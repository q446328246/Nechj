using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Meto : BaseWebControl
    {
        private Literal LiteralPageTitle;
        private Literal LiteralPagedescription;
        private Literal LiteralPagekeywords;
        private string skinFilename = "Meto.ascx";
        private string string_1 = "0";

        public Meto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Type
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            LiteralPageTitle = (Literal) skin.FindControl("LiteralPageTitle");
            LiteralPagekeywords = (Literal) skin.FindControl("LiteralPagekeywords");
            LiteralPagedescription = (Literal) skin.FindControl("LiteralPagedescription");

            if (!Page.IsPostBack)
            {
            }

            BindData();
        }

        protected void BindData()
        {
            if (string_1 == "0")
            {
                method_1();
            }
            else
            {
                string physicalPath = Page.Request.PhysicalPath;
                string pageName = physicalPath.Substring(physicalPath.LastIndexOf(@"\") + 1);
                DataTable table = SelectByID(pageName);
                if (table != null)
                {
                    LiteralPageTitle.Text = "\n<title>" + table.Rows[0]["Title"] + string.Empty +
                                            "</title>\n";
                    LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + table.Rows[0]["KeyWords"] +
                                               string.Empty + "\">\n";
                    LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + table.Rows[0]["Description"] +
                                                  string.Empty + "\">\n";
                }
                else
                {
                    method_1();
                }
            }
        }

        protected void method_1()
        {
            LiteralPageTitle.Text = "\n<title>" + ShopSettings.GetValue("Title") + string.Empty +
                                    "</title>\n";
            LiteralPagekeywords.Text = "<meta name=\"keywords\" content=\"" + ShopSettings.GetValue("KeyWords") +
                                       string.Empty + "\">\n";
            LiteralPagedescription.Text = "<meta name=\"description\" content=\"" + ShopSettings.GetValue("Description") +
                                          string.Empty + "\">\n";
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var writer2 = new StringWriter(CultureInfo.InvariantCulture);
            var writer3 = new HtmlTextWriter(writer2);
            LiteralPageTitle.RenderControl(writer3);
            LiteralPagekeywords.RenderControl(writer3);
            LiteralPagedescription.RenderControl(writer3);
            writer.Write(writer2.ToString());
        }

        public DataTable SelectByID(string PageName)
        {
            if (ShopNum1_ExtendSiteMota_Action.MetoTable != null)
            {
                DataRow[] source = ShopNum1_ExtendSiteMota_Action.MetoTable.Select("PageName = '" + PageName + "'");
                if (source.Length > 0)
                {
                    return source.CopyToDataTable();
                }
            }
            return null;
        }
    }
}