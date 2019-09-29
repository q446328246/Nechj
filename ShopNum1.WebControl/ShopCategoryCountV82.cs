using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopCategoryCountV82 : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopCategoryCountV82.ascx";
        private string string_1 = "0";

        public ShopCategoryCountV82()
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

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable weiXinShopCategoryCount =
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action())
                    .GetWeiXinShopCategoryCount(string_1);
            if ((weiXinShopCategoryCount != null) && (weiXinShopCategoryCount.Rows.Count > 0))
            {
                RepeaterData.DataSource = weiXinShopCategoryCount;
                RepeaterData.DataBind();
            }
        }
    }
}