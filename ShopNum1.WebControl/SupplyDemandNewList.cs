using System.Data;
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
    public class SupplyDemandNewList : BaseWebControl
    {
        private HtmlAnchor Href;
        private Repeater RepeaterData;
        private string skinFilename = "SupplyDemandNewList.ascx";

        public SupplyDemandNewList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string showCount { get; set; }

        protected void BindData()
        {
            DataTable supplyDemandNewList =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .GetSupplyDemandNewList(showCount);
            if ((supplyDemandNewList != null) && (supplyDemandNewList.Rows.Count > 0))
            {
                RepeaterData.DataSource = supplyDemandNewList.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Href = (HtmlAnchor) skin.FindControl("Href");
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Href.HRef = GetPageName.RetUrl("Login");
            }
            else
            {
                Href.HRef = GetPageName.RetUrl("index");
            }
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }
    }
}