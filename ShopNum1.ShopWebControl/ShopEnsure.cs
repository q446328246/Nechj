using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopEnsure : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopEnsure.ascx";

        public ShopEnsure()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable shopapplyEnsure =
                ((Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action()).GetShopapplyEnsure(MemLoginID);
            RepeaterData.DataSource = shopapplyEnsure;
            RepeaterData.DataBind();
        }

        public static string ReturnImageUrl(object object_0)
        {
            string newValue = "http://" + MemLoginID + ConfigurationManager.AppSettings["Domain"];
            return object_0.ToString().Replace("~/", newValue);
        }
    }
}