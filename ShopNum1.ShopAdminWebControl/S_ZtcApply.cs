using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ZtcApply : BaseMemberWebControl
    {
        private DropDownList DropDownListProductSeriesCode1;
        private string skinFilename = "S_ZtcApply.ascx";

        public S_ZtcApply()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DropDownListProductSeriesCode1 = (DropDownList) skin.FindControl("DropDownListProductSeriesCode1");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            action.TableName = "ShopNum1_Shop_ProductCategory";
            DataTable shopProductCategoryCode = action.GetShopProductCategoryCode("0", base.MemLoginID);
            DropDownListProductSeriesCode1.Items.Clear();
            DropDownListProductSeriesCode1.Items.Add(new ListItem("-请选择-", "-1"));
            for (int i = 0; i < shopProductCategoryCode.Rows.Count; i++)
            {
                DropDownListProductSeriesCode1.Items.Add(new ListItem(
                    shopProductCategoryCode.Rows[i]["Name"].ToString(),
                    shopProductCategoryCode.Rows[i]["ID"] + "/" +
                    shopProductCategoryCode.Rows[i]["Code"]));
            }
        }
    }
}