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
    public class ProductTwoCategory : BaseWebControl
    {
        private HiddenField HiddenFieldCategoryCode;
        private Repeater RepeaterData;
        private int int_0 = 6;
        private int int_1 = 6;

        private string skinFilename = "ProductTwoCategory.ascx";

        public ProductTwoCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int FlowersCategoryID { get; set; }

        public int ProductOneCategory { get; set; }

        public int ShowCountOne
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public int ShowCountThree { get; set; }

        public int ShowCountTwo
        {
            get { return int_1; }
            set { int_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            if ((Page.Request.QueryString["guid"] == null) || (Page.Request.QueryString["guid"] == "-1"))
            {
                ProductOneCategory = FlowersCategoryID;
            }
            else
            {
                ProductOneCategory = Convert.ToInt32(Page.Request.QueryString["guid"]);
            }
            HiddenFieldCategoryCode = (HiddenField) skin.FindControl("HiddenFieldCategoryCode");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
            HiddenFieldCategoryCode.Value = (Page.Request.QueryString["guid"] == null)
                ? "-1"
                : Page.Request.QueryString["guid"];
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                    ProductOneCategory, 0, int_0.ToString());
            RepeaterData.DataSource = table.DefaultView;
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                DataTable table =
                    ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                        Convert.ToInt32(field.Value), 0, int_1.ToString());
                repeater.DataSource = table.DefaultView;
                repeater.DataBind();
            }
        }
    }
}