using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductEspecialSeach : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductEspecialSeach.ascx";

        public ProductEspecialSeach()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProductType { get; set; }

        public string ShowCount { get; set; }

        public string Title { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SearchEspecialProduct(ShowCount, ProductType);
            if (table.Rows.Count > 0)
            {
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }
    }
}