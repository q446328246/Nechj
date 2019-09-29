using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AriticleChrildCategory : BaseWebControl
    {
        private Repeater RepeaterCategory;
        public int int_0 = 0;
        private string skinFilename = "AriticleChrildCategory.ascx";

        public AriticleChrildCategory()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataRow[] source = ShopNum1_ArticleCategory_Action.ArticleCategoryTable.Select("FatherID=0");
            if ((source != null) && (source.Length > 0))
            {
                RepeaterCategory.DataSource = source.CopyToDataTable();
                RepeaterCategory.DataBind();
            }
        }
    }
}