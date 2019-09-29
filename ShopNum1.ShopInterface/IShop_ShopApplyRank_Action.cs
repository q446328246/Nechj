using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ShopApplyRank_Action
    {
        DataTable Add(ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank);
        int Check(string ID, string isaudit);
        DataTable CheckIsApply(string guid, string memloginID);
        int CheckIsPayMentByID(string string_0);
        int Delete(string ID);
        DataTable GetShopRankApply(string memLoginID, int isAudit);
        DataTable GetShopRankByGuid(string guid);
        DataTable ShopRankPayInfoByGuid(string guid);
        int UpdataShopRank(string ID);
        int UpdataShopRankPayMentByID(string string_0, string PayMentType, string PayMentName);
        int UpdataShopRankPayStatusByID(string string_0);
    }
}