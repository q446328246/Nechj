using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryNewList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "CategoryNewList.ascx";

        public CategoryNewList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string showCount { get; set; }

        protected void BindData()
        {
            DataTable categoryNewList =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action())
                    .GetCategoryNewList(showCount);
            if ((categoryNewList != null) && (categoryNewList.Rows.Count > 0))
            {
                RepeaterData.DataSource = categoryNewList.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }
    }
}