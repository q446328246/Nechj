using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private int int_1;
        private string skinFilename = "ProductCategory.ascx";

        public ProductCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCountOne { get; set; }

        public int ShowCountThree { get; set; }

        public int ShowCountTwo
        {
            get { return int_1; }
            set { int_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            action.TableName = "ShopNum1_shop_ProductCategory";
            DataTable table = action.GetCategoryProc("0", "MemLoginID", MemLoginID,CookieCustomerCategory);
            RepeaterData.DataSource = table;
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
                action.TableName = "ShopNum1_Shop_ProductCategory";
                DataTable table = action.GetCategoryProc(field.Value, "MemLoginID", MemLoginID, CookieCustomerCategory);
                if (table.Rows.Count > 0)
                {
                    repeater.DataSource = (int_1 == 0) ? table : Top(table, int_1);
                    repeater.DataBind();
                }
            }
        }

        public DataTable Top(DataTable dt, int count)
        {
            int num3 = (dt.Rows.Count > count) ? count : dt.Rows.Count;
            DataTable table = dt.Clone();
            for (int i = 0; i < num3; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row[j] = dt.Rows[i][j].ToString();
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}