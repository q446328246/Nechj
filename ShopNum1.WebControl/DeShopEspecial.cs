using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeShopEspecial : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "DeShopEspecial.ascx";

        public DeShopEspecial()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShopType { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).SearchEspecialShop(
                    ShowCount, ShopType);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}