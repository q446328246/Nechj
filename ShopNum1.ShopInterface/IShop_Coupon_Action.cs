using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Coupon_Action
    {
        int Add(ShopNum1_Shop_Coupon ShopNum1_Shop_Coupon);
        int Delete(string ID);
        DataTable GetCouponInfoById(string guid);
        DataTable GetCouponTitleByAdressCode(string adresscode, string showcount);
        DataTable GetCouponTitleByBrowserCount(string showcount);

        DataTable SearchCoupon(string name, string type, string isshow, string starttime1, string starttime2,
            string endtime1, string endtime2, string memloginid);

        DataSet SearchCouponByCategory(string category, string pagesize, string current_page);
        DataTable SearchCouponByGuid(string guid, string shopid);
        DataTable SearchCouponByMemloginID(string showcount, string memloginid);

        DataSet SearchCouponByMemloginID(string shopid, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount);

        DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize,
            string current_page, string isReturCount);

        DataTable SearchCouponInfo(string name, string type, string isshow, string starttime1, string starttime2,
            string endtime1, string endtime2, string shopid, string adresscode);

        int UpdataDownloadCountByGuid(string guid, string count);
        int UpdateAudit(string field, string value, string guids);
        int UpdateBrowserCount(string guid);
        int UpdateCoupon(ShopNum1_Shop_Coupon ShopNum1_Shop_Coupon);
        
    }
}