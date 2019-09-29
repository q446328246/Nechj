using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class SupplyListIsNew : BaseWebControl
    {
        private HiddenField HiddenFieldGuid;
        private Repeater RepeaterShow;
        private string skinFilename = "SupplyList.ascx";

        public SupplyListIsNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public string MemLoginID { get; set; }

        public string shopName { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((Shop_SupplyDemand_Action) LogicFactory.CreateShop_SupplyDemand_Action()).Search(MemLoginID, "1");
            RepeaterShow.DataSource = table;
            RepeaterShow.DataBind();
        }

        public static string TradeType(string type)
        {
            if (type == "0")
            {
                return "供";
            }
            return "求";
        }
    }
}