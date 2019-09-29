using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Coupon_Action
    {
        DataTable GetCouponTitleByAdressCode(string adresscode, string showcount);
        DataTable GetCouponTitleByBrowserCount(string showcount);
        DataSet SearchCouponByCategory(string category, string pagesize, string current_page);

        DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize,
            string current_page, string isReturCount);
    }
}