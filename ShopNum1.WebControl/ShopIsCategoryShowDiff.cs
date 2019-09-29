using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopIsCategoryShowDiff : BaseWebControl
    {
        private Repeater RepeaterData;
        private HiddenField hiddenField_0;
        private string skinFilename = "ShopIsCategoryShowDiff.ascx";

        public ShopIsCategoryShowDiff()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public string ShowType { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .SearchEspecialShopList(ShowCount, ShowType);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var image = (Image) e.Item.FindControl("ImageReputation");
            hiddenField_0 = (HiddenField) e.Item.FindControl("HiddenFieldReputation");
            DataTable table =
                ((ShopNum1_Reputation_Action) LogicFactory.CreateShopNum1_Reputation_Action()).ShopReputationSearch(
                    hiddenField_0.Value, "0", "1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                image.ImageUrl = "~/" + table.Rows[0]["Pic"];
            }
        }
    }
}