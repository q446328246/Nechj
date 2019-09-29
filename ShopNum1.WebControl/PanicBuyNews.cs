using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PanicBuyNews : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "PanicBuyNews.ascx";

        public PanicBuyNews()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ArticleCategoryID { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            PanicBuyDataBind();
        }

        protected void PanicBuyDataBind()
        {
            try
            {
                int.Parse(ShowCount);
            }
            catch
            {
                ShowCount = "10";
            }
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).SearchByArticleCategoryID(
                    int.Parse(ArticleCategoryID), int.Parse(ShowCount));
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}