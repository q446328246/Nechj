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
    public class VideoCategory : BaseWebControl
    {
        private Repeater RepeaterCategory;
        public int int_0 = 0;
        private string skinFilename = "VideoCategory.ascx";

        public VideoCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            RepeaterCategory.ItemDataBound += RepeaterCategory_ItemDataBound;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action()).Search(0, 0,
                    ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected void RepeaterCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeater = (Repeater) e.Item.FindControl("RepeaterSubCategory");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            DataTable table =
                ((ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action()).Search2(
                    Convert.ToInt32(field.Value), 0);
            if ((table != null) && (table.Rows.Count > 0))
            {
                repeater.DataSource = table.DefaultView;
                repeater.DataBind();
            }
        }
    }
}