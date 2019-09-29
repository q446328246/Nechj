using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopThreeRecommend : BaseWebControl
    {
        private Repeater RepeaterData;
        private HiddenField hiddenField_0;
        private HtmlGenericControl htmlGenericControl_0;
        private string skinFilename = "ShopThreeRecommend.ascx";

        public ShopThreeRecommend()
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
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .SearchEspecialShopList(ShowCount, ShopType);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            htmlGenericControl_0 = (HtmlGenericControl) e.Item.FindControl("spanMemLoginID");
            var image = (Image) e.Item.FindControl("ImageReputation");
            var repeater = e.Item.FindControl("RepeaterProduct") as Repeater;
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SearchProductByMemLoginID(htmlGenericControl_0.InnerText.Trim(), "2");
            if ((table != null) && (table.Rows.Count > 0))
            {
                repeater.DataSource = table.DefaultView;
                repeater.DataBind();
            }
            hiddenField_0 = (HiddenField) e.Item.FindControl("HiddenFieldReputation");
            DataTable table2 =
                ((ShopNum1_Reputation_Action) LogicFactory.CreateShopNum1_Reputation_Action()).ShopReputationSearch(
                    hiddenField_0.Value, "0", "1");
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                image.ImageUrl = "~/" + table2.Rows[0]["Pic"];
            }
        }
    }
}