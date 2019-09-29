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
    public class ProductIsPanicBuy : BaseWebControl
    {
        private Literal LiteralTitle;
        private Repeater RepeaterData;
        private string skinFilename = "ProductIsCategoryShowDiff.ascx";

        public ProductIsPanicBuy()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProductType { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LiteralTitle = (Literal) skin.FindControl("LiteralTitle");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            var shopNum1_ProuductChecked_Action =
                (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
            DataTable dataTable = shopNum1_ProuductChecked_Action.SearchEspecialProduct(ShowCount, ProductType);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                RepeaterData.DataSource = dataTable;
                RepeaterData.DataBind();
                var htmlGenericControl = (HtmlGenericControl) RepeaterData.Items[0].FindControl("linea1");
                var htmlGenericControl2 = (HtmlGenericControl) RepeaterData.Items[0].FindControl("linea2");
                htmlGenericControl.Style.Remove(HtmlTextWriterStyle.Height);
                htmlGenericControl.Style.Add(HtmlTextWriterStyle.Height, "234px");
                htmlGenericControl2.Style.Remove(HtmlTextWriterStyle.BackgroundColor);
                htmlGenericControl2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#F2F2F2");
            }
            string productType = ProductType;
            switch (productType)
            {
                case "IsShopRecommend":
                    LiteralTitle.Text = "推荐商品";
                    break;
                case "IsSpellBuy":
                    LiteralTitle.Text = "团购商品";
                    break;
                case "IsPanicBuy":
                    LiteralTitle.Text = "抢购商品";
                    break;
                case "IsShopPromotion ":
                    LiteralTitle.Text = "促销商品";
                    break;
                case "IsShopHot":
                    LiteralTitle.Text = "热卖商品";
                    break;
                case "IsShopNew":
                    LiteralTitle.Text = "最新商品";
                    break;
                case "IsShopGood":
                    LiteralTitle.Text = "精品商品";
                    break;
            }
        }
    }
}