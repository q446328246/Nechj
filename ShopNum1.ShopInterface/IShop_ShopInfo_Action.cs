using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ShopInfo_Action
    {
        int AddApplyCateGory(ShopNum1_Shop_ApplyCateGory shopApplyCateGory);
        int DelApplyCatetoryByGuid(string guid, string shopid);
        DataTable GetApplyCatetoryList(string shopid, string state, string audtitetime1, string audtitetime2);
        DataTable GetCateGoryNameBycode(string code);
        DataTable GetCatetoryNamebycode(string code);
        DataTable GetMaxCountByShopRank(string shoprank, string file);
        string GetMemberLoginidByShopid(string shopid);
        DataTable GetMemInfoByShopID(string shopid);
        DataTable GetMemLoginInfo(string memloginid);
        DataTable GetMemSimpleByShopID(string shopid);
        DataTable GetOpenTimeByShopID(string shopid);
        DataTable GetShopCategoryInfoByMemLoginID(string memloginid);
        DataTable GetShopIDAndOpenTimeByMemLoginID(string memloginid);
        DataTable GetShopInfo(string memloginid);
        DataTable GetShopMetaInfo(string memloginid);
        DataTable GetShopNameByMemloginID(string memLoginID);
        DataTable GetShopOpentimeByProductGuid(string ProductGuid);
        DataTable GetShopRank(string memberloginid);
        DataTable GetShopRankByMemLoginID(string MemLoginID);
        DataTable GetShopRankImage(string shopRank);
        DataTable GetShopRankScoreScope();
        DataTable GetShopSimpleByMemID(string memloginid);
        DataTable GetShopUrlByAddressCode(string AddressCode);
        DataTable GetStarGuide(string shopid, int int_0);
        DataSet GetWelcome(string memberloginid);
        string IsAllowToAddProduct(string memloginid, string rankguid, string type);
        DataTable SearchIsAudit(string shopID, string shopName, string legalPerson, string registrationNum);
        int UpdateClickCount(string strShopId);
        int UpdateCompanAudit(string Guid, string CompanIsAudit, string strCompanAuditFailedReason);
        int UpdateCompanyIsAudit(string guid);
        int UpdateLoginDate(string memloginid);
        int UpdateLongLat(string Longitude, string Latitude, string MemberLoginID);
        int UpdateShopCategory(string shopcategory, string memloginid, string brandguid, string brandname);
        int UpdateShopInfo(ShopNum1_ShopInfo companyInfo);
        int UploadingCardPic(ShopNum1_ShopInfo shopNum1_ShopInfo);
    }
}