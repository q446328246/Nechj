using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryListNew : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "CategoryListNew.ascx";

        public CategoryListNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        public void BindData()
        {
            DataTable categoryNewList =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action())
                    .GetCategoryNewList(ShowCount.ToString());
            RepeaterShow.DataSource = categoryNewList;
            RepeaterShow.DataBind();
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }
    }
}