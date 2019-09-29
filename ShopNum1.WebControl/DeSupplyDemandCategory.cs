using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeSupplyDemandCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private int int_0 = 5;
        private int int_1 = 5;
        private string skinFilename = "DeSupplyDemandCategory.ascx";

        public DeSupplyDemandCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCountOne
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public int ShowCountTwo
        {
            get { return int_1; }
            set { int_1 = value; }
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
            action.TableName = "ShopNum1_SupplyDemandCategory";
            DataTable category = action.GetCategory("0");
            RepeaterData.DataSource = (ShowCountOne == 0) ? category : Top(category, int_0);
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_SupplyDemandCategory";
                DataTable category = action.GetCategory(field.Value);
                if (category.Rows.Count > 0)
                {
                    repeater.DataSource = (ShowCountTwo == 0) ? category : Top(category, int_1);
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