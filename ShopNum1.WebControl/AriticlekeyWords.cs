using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AriticlekeyWords : BaseWebControl
    {
        private Repeater RepeaterShow;
        public int int_0 = 0;
        private string skinFilename = "AriticlekeyWords.ascx";

        public AriticlekeyWords()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CateforyID { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            if (CateforyID != null)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataTable childCategory =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetChildCategory(ShowCount,
                    CateforyID);
            if (childCategory != null)
            {
                RepeaterShow.DataSource = childCategory.DefaultView;
                RepeaterShow.DataBind();
            }
        }
    }
}