using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductIsPanicBuyList : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "ProductIsPanicBuyList.ascx";

        public ProductIsPanicBuyList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        protected string productGuid { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            productGuid = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        public static string IsBegin(object begin, object object_0)
        {
            if (DateTime.Parse(begin.ToString()) > DateTime.Now)
            {
                return begin.ToString();
            }
            return object_0.ToString();
        }

        protected void BindData()
        {
            if (ShowCount < 1)
            {
                ShowCount = 10;
            }
            DataTable table =
                ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action()).GetPanicBuyList(MemLoginID,
                    ShowCount.ToString(),
                    productGuid);
            RepeaterShow.DataSource = table;
            RepeaterShow.DataBind();
        }

        public static string SetNoNull(object value)
        {
            if (value.ToString() == "")
            {
                return "0";
            }
            return value.ToString();
        }
    }
}