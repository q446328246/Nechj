using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopInfoList_Action
    {
        int Add(ShopNum1_ShopInfo shopNum1_ShopInfo);
        int CheckShopName(string name);
        DataTable CheckShopURLIsRepeat(string shopurl);
        int Delete(string guids);
        int Delete(string guid, string memLoginID);
        int DeleteShopCategoryApply(string guids);
        DataTable GetAllShopInfoByGuid(string guid);
        DataTable GetEditInfo(string memberLoginId);
        DataTable GetEnsureImagePathBymemberLoginID(string memberLoginID);
        DataTable GetMemberInfoByGuid(string guid);
        string GetMemberType(string memLoginID);
        DataTable GetNewShopInfoByShowCount(string ShowCount);
        string GetOpenTime(string memLoginID);
        DataTable GetOpenTimeByShopID(string shopid);

        DataTable GetShopCategoryApplyInfo(string ShopName, string memberLoginID, string ShopCategoryCode,
            string IsAudit, string StartTime, string EndTime);

        DataTable GetShopCategoryInfoByGuid(string guid);
        int GetShopCountByCode(string code);
        string GetShopGuid(string memLoginID);
        string GetShopid(string memLoginID);
        DataTable GetShopIDByMemLoginID(string MemLoginID);
        int GetShopIdMax();
        DataTable GetShopInfoByGuid(string guid);
        DataTable GetShopOpentimeByMemLoginID(string MemLoginID);
        string GetShopPayMentType(string memloginid);
        DataTable GetShopRankByMemLoginID(string MemLoginID);
        DataTable GetShopUrlByAddressCode(string AddressCode);
        string GetShopURLByAddressCode(string addressCode);
        string GetShopURLByShopID(string shopid);
        int InsertShopNav(string shopid);
        int RegistShopMember(ShopNum1_ShopInfo shopNum1_ShopInfo);
        DataTable Search(string memberLoginID);

        DataTable Search(string ShopName, string Name, string memberLoginID, string type, string addressCode,
            string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit,
            string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit,
            string startTime, string endTime);

        DataTable SearchEspecialShop(string pagesize, string field);
        DataTable SearchEspecialShopList(string pagesize, string field);

        DataTable SearchInfoList(string ShopName, string Name, string memberLoginID, string type, string addressCode,
            string Ishot, string IsVisits, string IsRecommend, string IsExpires,
            string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution,
            string shopensure, string IsAudit, string startTime, string endTime);

        DataTable SearchNewsShopList(string pagesize);
        DataTable SearchShopAmount(string startdate, string enddate);
        DataTable SearchShopClickCount(string shophost, string shopname, string startdate, string enddate);

        DataSet SearchShopList(string pageindex, string pagesize, string regioncode, string shopcategoryid, string name,
            string memberloginid);

        DataSet SearchShopList(string addresscode, string ShopCategoryID, string ordername, string soft, string shopName,
            string memberid, string perpagenum, string current_page, string isreturcount);

        DataTable SearchShopSalesClickCount(string shophost, string shopname, string startdate, string enddate);
        int UpdataShopCategoryApplyIsAudit(string guids, string isAudit);
        int UpdataShopURLByGuid(string guid, string shopurl);
        int Update(string guid, ShopNum1_ShopInfo shopNum1_ShopInfo);
        int Update(string guid, string string_0, string field);
        void UpdateDate(string guid, string time);
        int UpdateMemberType(string guids, int memberType);

        int UpdateShopCategoryAndBrandByGuids(string guids, string ShopCategoryName, string ShopCategoryCode,
            string BrandName, string BrandGuid);

        int UpdateShopInfo(ShopNum1_ShopInfo shopNum1_ShopInfo);
        int UpdateShopInfoDetail(ShopNum1_ShopInfo shopNum1_ShopInfo);
        int UpdateShopReputationByMemLoginID(string MemLoginID, int score);
        int UpdateShopState(string guid, string field, string string_0);
    }
}