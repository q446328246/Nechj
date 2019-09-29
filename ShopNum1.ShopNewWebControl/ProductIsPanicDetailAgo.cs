using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class ProductIsPanicDetailAgo : BaseWebControl
    {
        private Image Image1;
        private Repeater RepeaterData;
        private string skinFilename = string.Empty;
        private string string_1 = "ProductIsPanicDetailAgo.ascx";
        private string string_2;

        public ProductIsPanicDetailAgo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }

        public string MemberLoginID { get; set; }

        public string MemberType { get; set; }

        public static string MemLoginID { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            string_2 = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(MemLoginID);
            MemberType = memLoginInfo.Rows[0]["MemberType"].ToString();
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            Image1 = (Image) skin.FindControl("Image1");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
        }
    }
}