using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CategoryAdPayMent_Action
    {
        int Add(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent);
        int Delete(string string_0);

        DataTable GetBuyCategoryAdByMemloginId(string memloginid, string advertisementname, string categorytype,
            string categoryid, string categorycode);

        DataTable GetCategoryAdInfo(string memloginid, string advertisementid);
        DataTable GetEndTime(string categoryType, string categroyID, string categoryCode);
        DataTable GetEndTimeByAdID(string AdvertisementID);
        DataSet PayCategoryAdPrice(string tradeid, string memloginid);
        DataTable Search(string name);
        DataTable SearchAdInfo(string categoryid, string categorytype);
        DataTable SearchAdInfo(string categoryid, string categorycode, string categorytype);

        DataTable SearchBuyAdInfo(string isAudit, string categoryid, string categorycode, string categorytype,
            string MemloginID, string isPayMent, string AdvertisementName, string IsEffective);

        int Updata(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent);

        int Updata(string ImageName, string AdvertisementLike, string AdvertisementTitle, string PayMentType,
            string PayMentName, string ID, string MemloginID);

        int UpdataCategoryAdInfo(string memloginid, string adID, string isAudit, string FailCause);
        int UpdateIsEffective(string time);
    }
}