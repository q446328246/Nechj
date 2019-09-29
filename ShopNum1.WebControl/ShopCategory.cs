using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopCategory.ascx";

        public ShopCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCountOne { get; set; }

        public int ShowCountThree { get; set; }

        public int ShowCountTwo { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            method_1();
        }

        protected void method_0(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldFID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterthreeChild");
                DataRow[] source = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=" + field.Value);
                if ((source != null) && (source.Length > 0))
                {
                    repeater.DataSource = source.CopyToDataTable();
                    repeater.DataBind();
                    repeater.Items[repeater.Items.Count - 1].FindControl("LiteralLine").Visible = false;
                }
            }
        }

        protected void method_1()
        {
            DataRow[] source = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=0");
            if ((source != null) && (source.Length > 0))
            {
                RepeaterData.DataSource = source.CopyToDataTable();
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                repeater.ItemDataBound += method_0;
                DataRow[] source = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=" + field.Value);
                if ((source != null) && (source.Length > 0))
                {
                    repeater.DataSource = source.CopyToDataTable();
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