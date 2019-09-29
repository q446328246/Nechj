using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeSupplyDemandMessage : BaseWebControl
    {
        private Repeater RepeaterBrand;
        private string skinFilename = "DeSupplyDemandMessage.ascx";

        public DeSupplyDemandMessage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string code { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterBrand = (Repeater) skin.FindControl("RepeaterBrand");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetTitleByCodeTrade(0, code, ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterBrand.DataSource = table.DefaultView;
                RepeaterBrand.DataBind();
            }
        }
    }
}