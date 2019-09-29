using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class BrandMore : BaseWebControl
    {
        private Repeater repBrnadMore;
        private string skinFilename = "BrandMore.ascx";

        public BrandMore()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            repBrnadMore = (Repeater) skin.FindControl("repBrnadMore");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table = ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).SearchBrand(ShowCount);
            repBrnadMore.DataSource = table.DefaultView;
            repBrnadMore.DataBind();
        }
    }
}