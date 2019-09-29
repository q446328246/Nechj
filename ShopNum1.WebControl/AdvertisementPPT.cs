using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AdvertisementPPT : BaseWebControl
    {
        private Repeater RepeaterPPT;
        private string skinFilename = "AdvertisementPPTTwo.ascx";

        public AdvertisementPPT()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdID { get; set; }

        public string AdType { get; set; }

        public void BindAd()
        {
            DataTable table =
                ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowADByDivID(
                    AdID, AdType);
            RepeaterPPT.DataSource = table;
            RepeaterPPT.DataBind();
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterPPT = (Repeater) skin.FindControl("RepeaterPPT");
            BindAd();
        }
    }
}