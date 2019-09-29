using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ExtendOrderStatistics_Action
    {
        int Add();
        DataTable SearchDispatchModeStatistics();
        DataTable SearchPaymentStatistics();
    }
}