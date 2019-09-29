using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AriticleIsHotorIsRecommend : BaseWebControl
    {
        private Label Labeltitle;
        private Repeater RepeaterCategory;
        public int int_0 = 0;
        private string skinFilename = "AriticleIsHotorIsRecommend.ascx";

        public AriticleIsHotorIsRecommend()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CateforyID { get; set; }

        public string ISType { get; set; }

        public string LanguageCode { get; set; }

        public string ShowCount { get; set; }

        public string Titel { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LanguageCode = (Page.Request.QueryString["LanguageCode"] == null)
                ? ""
                : Page.Request.QueryString["LanguageCode"];
            Labeltitle = (Label) skin.FindControl("Labeltitle");
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetArticleIsHotorIsRecommend(
                    ShowCount, CateforyID, ISType);
            if (table != null)
            {
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
            if (!string.IsNullOrEmpty(Titel))
            {
                Labeltitle.Text = Titel;
            }
        }
    }
}