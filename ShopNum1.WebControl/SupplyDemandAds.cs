using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyDemandAds : BaseWebControl
    {
        private HtmlImage ImgAdv;
        private Repeater RepeaterContent;
        private string skinFilename = "SupplyDemandAds.ascx";

        public SupplyDemandAds()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdvID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterContent = (Repeater) skin.FindControl("RepeaterContent");
            if (!Page.IsPostBack)
            {
                DataTable table =
                    ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowADByDivID(
                        AdvID);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    ImgAdv = (HtmlImage) skin.FindControl("ImgAdv");
                    ImgAdv.Src = Page.ResolveUrl("/" + table.Rows[0]["content"]);
                    RepeaterContent.DataSource = table.DefaultView;
                    RepeaterContent.DataBind();
                }
            }
        }
    }
}