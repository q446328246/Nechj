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
    public class PageAddressProductCategory : BaseWebControl
    {
        private Literal PageAddress;
        private string skinFilename = "PageAddress.ascx";

        public PageAddressProductCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProductCategoryID { get; set; }

        public void Bind()
        {
            var builder = new StringBuilder();
            var control = new HtmlAnchor
            {
                InnerText = "首页",
                HRef = "http://" + Page.Request.Url.Host + "/"
            };
            builder.Append(RenderControl(control));
            DataTable productCategoryPageAddress =
                ((ShopNum1_PageAddress_Action) LogicFactory.CreateShopNum1_PageAddress_Action())
                    .GetProductCategoryPageAddress(ProductCategoryID);
            for (int i = 0; i < productCategoryPageAddress.Rows.Count; i++)
            {
                control.InnerText = productCategoryPageAddress.Rows[i]["Name"].ToString();
                control.HRef = GetPageName.RetUrl("ProductListCategory",
                    productCategoryPageAddress.Rows[i]["ID"].ToString(),
                    "ProductCategoryID");
                builder.Append("&nbsp;&gt;&nbsp;" + RenderControl(control));
            }
            PageAddress.Text = builder.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            ProductCategoryID = (Page.Request.QueryString["ProductCategoryID"] == null)
                ? "0"
                : Page.Request.QueryString["ProductCategoryID"];
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