using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductSubCategory : BaseWebControl
    {
        private Repeater RepeaterDataWenzi;
        private Literal literal_0;
        private string skinFilename = "ProductSubCategory.ascx";
        private string string_1 = "0";

        public ProductSubCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int CategoryID { get; set; }

        public string NewCategoryID { get; set; }

        public string ShowCount
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterDataWenzi = (Repeater) skin.FindControl("RepeaterDataWenzi");
            literal_0 = (Literal) skin.FindControl("moreView_1");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_ProductCategory";
            DataTable table = action.Search(CategoryID, 0, string_1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterDataWenzi.DataSource = table;
                RepeaterDataWenzi.DataBind();
            }
            literal_0.Text = "<a href=\"http://" + ShopSettings.siteDomain + "/Search_productlist.aspx?category=1&code=" +
                             NewCategoryID + "\" target=\"_blank\" class=\"fmore\">更多</a>";
        }
    }
}