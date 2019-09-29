using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_OrderScore_Action
    {
        int AddMemIntegralLog(string memloginid, string score, string remark);
        int AddOrderScore(ShopNum1_OrderScore orderScore);
        DataTable GetOrderScoreOrder(string orderinfoguid);
        int UpdateIntegral(string memloginid, string shopid, string score);
        int UpdateOrderScoreState(string orderinfoguid, string isfinished);
    }
}