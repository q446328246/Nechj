using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ExtendOrderStatistics_Action : IShopNum1_ExtendOrderStatistics_Action
    {
        public int Add()
        {
            return 0;
        }

        public DataTable SearchDispatchModeStatistics()
        {
            var builder = new StringBuilder();
            builder.Append(
                "select DispatchModeName,count(DispatchModeGuid) as DispatchModeCount,(select count(1) from ShopNum1_OrderInfo where PaymentStatus=2) as AllCount");
            builder.Append(
                " from ShopNum1_OrderInfo  where PaymentStatus=2 group by DispatchModeName order by DispatchModeCount desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchPaymentStatistics()
        {
            var builder = new StringBuilder();
            builder.Append(
                "select PaymentName,count(PaymentGuid) as PaymentCount,(select count(1) from ShopNum1_OrderInfo ) as AllCount ");
            builder.Append(" from ShopNum1_OrderInfo   group by PaymentName order by PaymentCount desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }
    }
}