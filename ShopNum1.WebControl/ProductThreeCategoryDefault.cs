using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductThreeCategoryDefault : BaseWebControl
    {
        private readonly ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action =
            ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action());

        private Repeater RepeaterCategoryOne;
        public int int_0 = 0;

        private string skinFilename = "ProductThreeCategoryDefault.ascx";
        private string string_1 = "16";
        private string string_2 = "6";
        private string string_3 = "10";

        public ProductThreeCategoryDefault()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowOneCount
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string ShowThreeCount
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string ShowTwoCount
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterCategoryOne = (Repeater) skin.FindControl("RepeaterCategoryOne");
            RepeaterCategoryOne.ItemDataBound += RepeaterCategoryOne_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable table = shopNum1_ProductCategory_Action.Search(0, 0, string_1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterCategoryOne.DataSource = table.DefaultView;
                RepeaterCategoryOne.DataBind();
            }
        }

        protected void method_1(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterCategory3");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCheck");
                var field2 = (HiddenField) e.Item.FindControl("HiddenFieldCategory2");
                DataTable table = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(field2.Value), 0, string_2);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table.DefaultView;
                    repeater.DataBind();
                }
                else
                {
                    field.Value = "0";
                }
            }
        }

        protected void RepeaterCategoryOne_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterCategory2");
                repeater.ItemDataBound += method_1;
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCategory1");
                DataTable table = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(field.Value), 0, string_2);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table.DefaultView;
                    repeater.DataBind();
                }
            }
        }
    }
}