using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ProductBooking_Action
    {
        int AddProductBooking(ShopNum1_Shop_ProductBooking productBooking);
        int DeleteProductBooking(string guid);
        DataTable GetProductBooking(string guid);
        DataTable SelectProductBookingList(string shopid, string name, string isaudit, string productname);
        int UpdateProductBooking(string guid);
    }
}