using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PageAddressHelp : BaseWebControl
    {
        private Literal PageAddress;
        private string skinFilename = "PageAddress.ascx";

        public PageAddressHelp()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guids { get; set; }

        public void Bind()
        {
            var builder = new StringBuilder();
            var control = new HtmlAnchor
            {
                InnerText = "首页",
                HRef = "http://" + Page.Request.Url.Host + "/"
            };
            builder.Append(RenderControl(control));
            if (Guids == "0")
            {
                control.InnerText = "系统分类";
                control.HRef = GetPageName.RetUrl("HelpList");
                builder.Append("&nbsp;&gt;&nbsp;" + RenderControl(control));
            }
            else
            {
                DataTable helpCategoryPageAddress =
                    ((ShopNum1_PageAddress_Action) LogicFactory.CreateShopNum1_PageAddress_Action())
                        .GetHelpCategoryPageAddress(Guids);
                for (int i = 0; i < helpCategoryPageAddress.Rows.Count; i++)
                {
                    control.InnerText = helpCategoryPageAddress.Rows[i]["Name"].ToString();
                    control.HRef = GetPageName.RetUrl("HelpList", helpCategoryPageAddress.Rows[i]["guid"].ToString());
                    builder.Append("&nbsp;&gt;&nbsp;" + RenderControl(control));
                }
            }
            PageAddress.Text = builder.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            Guids = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            PageAddress = (Literal) skin.FindControl("PageAddress");
            if (!Page.IsPostBack)
            {
            }
            Bind();
        }

        public static string RenderControl(Control control)
        {
            var writer = new StringWriter(CultureInfo.InvariantCulture);
            var writer2 = new HtmlTextWriter(writer);
            control.RenderControl(writer2);
            writer2.Flush();
            writer2.Close();
            return writer.ToString();
        }
    }
}