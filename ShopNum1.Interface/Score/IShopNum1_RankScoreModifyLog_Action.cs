using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_RankScoreModifyLog_Action
    {
        string GetMemberRankGuidByCostMoney(decimal costMoney);
        string GetMemberRankGuidByRankScore(int rankScore);
        string GetMemberRankGuidByTradeCount(int tradeCount);
        int OperateScore(ShopNum1_RankScoreModifyLog rankScoreModifyLog);
        DataTable Search(string memLoginID, int isDeleted);
        DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted);
    }
}