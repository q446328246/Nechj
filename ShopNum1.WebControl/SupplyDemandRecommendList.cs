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
    public class SupplyDemandRecommendList : BaseWebControl
    {
        private HtmlAnchor Href;
        private Repeater RepeaterData;
        private string skinFilename = "SupplyDemandRecommendList.ascx";

        public SupplyDemandRecommendList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string showCount { get; set; }

        public string TradeType { get; set; }

        protected void BindData()
        {
            DataTable supplyDemandRecommendList =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetSupplyDemandRecommendList(showCount, TradeType);
            if ((supplyDemandRecommendList != null) && (supplyDemandRecommendList.Rows.Count > 0))
            {
                RepeaterData.DataSource = supplyDemandRecommendList.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Href = (HtmlAnchor) skin.FindControl("Href");
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Href.HRef = "~/Login.html";
            }
            else
            {
                Href.HRef = "~/index.html";
            }
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }
    }
}