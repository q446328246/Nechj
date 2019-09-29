using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductListForCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductListForCategory.ascx";
        private string string_1 = "0";
        private string string_2 = "0";

        public ProductListForCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CategoryID
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string ShowCountProduct
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable productByCategoryID = new DataTable();
            switch (CategoryID)
            {
                case "HOT":
                    productByCategoryID = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetProductByBTC("IsSalesBTC", string_1);
                    break;
                case "NEW":
                    productByCategoryID = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetProductByBTC("IsNewBTC", string_1);
                    break;
                case "Tercel":
                    productByCategoryID = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetProductByBTC("IsTercelBTC", string_1);
                    break;
                default:
                    productByCategoryID =
                ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .GetProductByCategoryID(CategoryID, string_1, TJShopInfo.shopId);
                    break;
            }
             
            if ((productByCategoryID != null) && (productByCategoryID.Rows.Count > 0))
            {
                RepeaterData.DataSource = productByCategoryID;
                RepeaterData.DataBind();
            }
        }
    }
}