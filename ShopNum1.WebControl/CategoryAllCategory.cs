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
    public class CategoryAllCategory : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "CategoryAllCategory.ascx";

        public CategoryAllCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string ShowCountOne { get; set; }

        public string ShowCountTwo { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            Guid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("guid");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).Search(0, 0,
                    ShowCountOne);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterData2");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
                DataTable table =
                    ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).Search(
                        Convert.ToInt32(field.Value), 0, ShowCountTwo);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    repeater.DataSource = table.DefaultView;
                    repeater.DataBind();
                }
            }
        }
    }
}