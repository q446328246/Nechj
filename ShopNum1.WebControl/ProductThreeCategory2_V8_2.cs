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
    public class ProductThreeCategory2_V8_2 : BaseWebControl
    {
        private Repeater RepeaterCategory;
        public int int_0 = 0;
        private Repeater repeater_1;
        private string skinFilename = "ProductThreeCategory2_V8_2.ascx";
        private string string_1 = "100";
        private string string_2 = "100";
        private string string_3 = "100";
        private string string_4 = "100";

        public ProductThreeCategory2_V8_2()
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
            get { return string_4; }
            set { string_4 = value; }
        }

        public string ShowTwoCount
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string ShowTwoRightCount
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            RepeaterCategory.ItemDataBound += RepeaterCategory_ItemDataBound;
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(0, 0,
                    ShowOneCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected void RepeaterCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            repeater_1 = (Repeater) e.Item.FindControl("RepeaterCategoryTwo");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            DataTable table =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                    Convert.ToInt32(field.Value), 0, string_2);
            if ((table != null) && (table.Rows.Count > 0))
            {
                repeater_1.DataSource = table.DefaultView;
                repeater_1.DataBind();
            }
        }
    }
}