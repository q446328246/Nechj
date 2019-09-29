using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopIsNewShowDiff : BaseWebControl
    {
        private Repeater RepeaterData;
        private HiddenField hiddenField_0;
        private string skinFilename = "ShopIsNewShowDiff.ascx";

        public ShopIsNewShowDiff()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable newShopInfoByShowCount =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetNewShopInfoByShowCount(ShowCount);
            if ((newShopInfoByShowCount != null) && (newShopInfoByShowCount.Rows.Count > 0))
            {
                RepeaterData.DataSource = newShopInfoByShowCount.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var image = (Image) e.Item.FindControl("ImageReputation");
            hiddenField_0 = (HiddenField) e.Item.FindControl("HiddenFieldReputation");
            DataTable table =
                ((Shop_Reputation_Action) ShopFactory.LogicFactory.CreateShop_Reputation_Action()).ShopReputationSearch(
                    hiddenField_0.Value, "0", "1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                image.ImageUrl = "~/" + table.Rows[0]["Pic"];
            }
        }
    }
}