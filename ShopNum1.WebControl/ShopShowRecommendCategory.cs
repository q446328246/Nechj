using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopShowRecommendCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private int int_0;
        private int int_1;
        private string skinFilename = "ShopShowRecommendCategory.ascx";

        public ShopShowRecommendCategory()
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
            DataRow[] dataRows = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=0");
            if ((dataRows != null) && (dataRows.Length > 0))
            {
                RepeaterData.DataSource = Top(dataRows, int_0);
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                DataRow[] dataRows = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=" + field.Value);
                if ((dataRows != null) && (dataRows.Length > 0))
                {
                    repeater.DataSource = Top(dataRows, int_1);
                    repeater.DataBind();
                    repeater.Items[repeater.Items.Count - 1].FindControl("LiteralLine").Visible = false;
                }
            }
        }

        public DataTable Top(DataRow[] dataRows, int count)
        {
            // This item is obfuscated and can not be translated.
            var source = new DataRow[count];
            if (count <= 0)
            {
                return null;
            }
            int index = 0;
            Label_0012:
            if (count > dataRows.Length)
            {
            }
            if (index < dataRows.Length)
            {
                source[index] = dataRows[index];
                index++;
                goto Label_0012;
            }
            return source.CopyToDataTable();
        }
    }
}