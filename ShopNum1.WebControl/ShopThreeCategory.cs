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
    public class ShopThreeCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopThreeCategory.ascx";
        private string string_1 = "0";
        private string string_2 = "0";
        private string string_3 = "0";

        public ShopThreeCategory()
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
            method_1();
        }

        protected void method_0(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldFID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterthreeChild");
                DataTable table =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).Search(
                        Convert.ToInt32(field.Value), 0, ShowCountThree);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table;
                    repeater.DataBind();
                    repeater.Items[repeater.Items.Count - 1].FindControl("LiteralLine").Visible = false;
                }
            }
        }

        protected void method_1()
        {
            DataTable table =
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).Search(0, 0, string_1);
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
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCID");
                var repeater = (Repeater) e.Item.FindControl("RepeaterChild");
                repeater.ItemDataBound += method_0;
                DataTable table =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).Search(
                        Convert.ToInt32(field.Value), 0, ShowCountTwo);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table;
                    repeater.DataBind();
                }
            }
        }
    }
}