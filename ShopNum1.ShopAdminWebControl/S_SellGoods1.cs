
using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_SellGoods1 : BaseShopWebControl
    {
        public static DataTable dt_ParentType = null;
        private string skinFilename = "S_SellGoods1.ascx";

        public S_SellGoods1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            dt_ParentType =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                    .Select_ProductCategory();
        }
    }
}