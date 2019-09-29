using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System.Web;
using ShopNum1.Common;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductThreeCategory : BaseWebControl
    {

        string Category = "1";
        private Repeater RepeaterData;
        private string skinFilename = "ProductThreeCategory.ascx";
        private string string_1 = "0";
        private string string_2 = "0";
        private string string_3 = "0";

        
        public ProductThreeCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        

        public string ShowCountOne
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string ShowCountThree
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string ShowCountTwo
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_ProductCategory";
            DataTable table = action.Search(0, 0, string_1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
                 

                
            }
        }
        
        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field2 = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldIsHaveCategory");
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_ProductCategory";
                DataTable table = action.Search(Convert.ToInt32(field2.Value), 0, ShowCountTwo);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table;
                    repeater.DataBind();
                    field.Value = "1";
                }
                else
                {
                    field.Value = "0";
                   
                    
                }
            }
        }
    }
}