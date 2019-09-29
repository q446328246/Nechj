using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CouponsList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "CouponsList.ascx";

        public CouponsList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public static string check(object Hot, object New)
        {
            string str = "0";
            if (Hot.ToString() == "1")
            {
                return "1";
            }
            if (New.ToString() == "1")
            {
                str = "2";
            }
            return str;
        }

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
            DataTable couponTitleByAdressCode = new ShopNum1_Coupon_Action().GetCouponTitleByAdressCode("-1", ShowCount);
            if ((couponTitleByAdressCode != null) && (couponTitleByAdressCode.Rows.Count > 0))
            {
                RepeaterData.DataSource = couponTitleByAdressCode.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            CouponsDataBind();
        }
    }
}