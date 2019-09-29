using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductIsCategoryShow : BaseWebControl
    {
        private Literal LiteralTitle;
        private Repeater RepeaterData;
        private string skinFilename = "ProductIsCategoryShow.ascx";

        public ProductIsCategoryShow()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProductType { get; set; }

        public string ShowCount { get; set; }

        public string Title { get; set; }

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
            }
            if (string.IsNullOrEmpty(Title))
            {
                string productType = ProductType;
                switch (productType)
                {
                    case "IsRecommend":
                        LiteralTitle.Text = "推荐商品";
                        break;
                    case "IsSpellBuy":
                        LiteralTitle.Text = "团购商品";
                        break;
                    case "IsPanicBuy":
                        LiteralTitle.Text = "抢购商品";
                        break;
                    case "IsPromotion":
                        LiteralTitle.Text = "促销商品";
                        break;
                    case "IsHot":
                        LiteralTitle.Text = "热买商品";
                        break;
                    case "IsNew":
                        LiteralTitle.Text = "最新商品";
                        break;
                    case "IsBest":
                        LiteralTitle.Text = "精品商品";
                        break;
                    case "IsShopRecommend":
                        LiteralTitle.Text = "推荐商品";
                        break;
                }
            }
            else
            {
                LiteralTitle.Text = Title;
            }
        }
    }
}