using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class NewSaleOrder : BaseWebControl
    {
        private Repeater RepNewSaleOrder;
        private string skinFilename = "NewSaleOrder.ascx";

        public NewSaleOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string TopSaleNum { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepNewSaleOrder = (Repeater) skin.FindControl("RepNewSaleOrder");
            if (!Page.IsPostBack)
            {
                RepNewSaleOrder.DataSource =
                    ((ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action()).GetNewSaleOrder(
                        TopSaleNum);
                RepNewSaleOrder.DataBind();
            }
        }
    }
}