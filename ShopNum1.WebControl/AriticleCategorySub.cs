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
    public class AriticleCategorySub : BaseWebControl
    {
        private Repeater RepeaterCategory;
        public int int_0 = 0;
        private string skinFilename = "AriticleCategorySub.ascx";

        public AriticleCategorySub()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

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
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            string str = string.Empty;
            if (Page.Request["ID"] != null)
            {
                str = Page.Request["ID"];
                DataTable table = action.SearchShow(Convert.ToInt32(str), 0);
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected void RepeaterCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeater = (Repeater) e.Item.FindControl("RepeaterSubCategory");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            DataTable table =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).SearchShow(
                    Convert.ToInt32(field.Value), 0);
            repeater.DataSource = table.DefaultView;
            repeater.DataBind();
        }
    }
}