using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CouponsIsHot : BaseWebControl
    {
        private Repeater RepeaterDate;
        private string skinFilename = "CouponsIsHot.ascx";

        public CouponsIsHot()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected void CouponsDataBind()
        {
            try
            {
                int.Parse(ShowCount);
            }
            catch
            {
                ShowCount = "10";
            }
            DataTable couponTitleByBrowserCount =
                ((ShopNum1_Coupon_Action) LogicFactory.CreateShopNum1_Coupon_Action()).GetCouponTitleByBrowserCount(
                    ShowCount);
            if ((couponTitleByBrowserCount != null) && (couponTitleByBrowserCount.Rows.Count > 0))
            {
                RepeaterDate.DataSource = couponTitleByBrowserCount.DefaultView;
                RepeaterDate.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterDate = (Repeater) skin.FindControl("RepeaterDate");
            CouponsDataBind();
        }
    }
}