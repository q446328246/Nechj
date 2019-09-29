using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Order_Action
    {
        DataTable SearchOrderProduct(string startdate, string enddate);
    }
}