using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductListCollectRanking : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductListCollectRanking.ascx";

        public ProductListCollectRanking()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            string s = ShopSettings.GetValue("SellOrderCount");
            try
            {
                int.Parse(s);
            }
            catch
            {
                s = "10";
            }
            DataTable collectRankingProduct = action.GetCollectRankingProduct(s, MemLoginID,CookieCustomerCategory);
            RepeaterData.DataSource = collectRankingProduct;
            RepeaterData.DataBind();
        }
    }
}