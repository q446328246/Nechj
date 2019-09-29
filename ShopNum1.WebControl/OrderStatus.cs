using System.Web.UI;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class OrderStatus
    {
        public static string ChangeOrderStatus(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "等待买家付款";

                case "1":
                    return "等待卖家发货";

                case "2":
                    return "等待买家确认收货";

                case "3":
                    return "交易成功";

                case "4":
                    return "系统关闭订单";

                case "5":
                    return "卖家关闭订单";

                case "6":
                    return "买家关闭订单";
            }
            return "非法状态";
        }
    }
}