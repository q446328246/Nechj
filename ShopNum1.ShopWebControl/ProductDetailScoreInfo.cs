using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductDetailScoreInfo : BaseWebControl
    {
        private Repeater RepeaterProductDetail;
        private string skinFilename = "ProductDetailScoreInfo.ascx";

        public ProductDetailScoreInfo()
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
            RepeaterProductDetail = (Repeater) skin.FindControl("RepeaterProductDetail");
            if (!Page.IsPostBack)
            {
            }
            string str = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (str != "0")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_Shop_ScoreProduct_Action) Factory.LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action())
                    .GetDataShopWeb(1, 0, 1, Page.Request.QueryString["guid"]);
            if (table.Rows.Count > 0)
            {
                RepeaterProductDetail.DataSource = table.DefaultView;
                RepeaterProductDetail.DataBind();
            }
        }
    }
}