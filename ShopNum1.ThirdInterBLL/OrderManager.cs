using System.Data;
using ShopNum1.ThirdInterDAL;

namespace ShopNum1.ThirdInterBLL
{
    public class OrderManager
    {
        public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber,
            string memLoginID, string name, string address, string postalcode, string tel,
            string mobile, string email, string oderStatus, decimal shouldPayPrice1,
            decimal shouldPayPrice2, int isDeleted)
        {
            var service = new OrderService();
            return service.GetCountOrders(shopid, fisttime, lasttime, sign, orderNumber, memLoginID, name, address,
                postalcode, tel, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2,
                isDeleted);
        }

        public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
        {
            var service = new OrderService();
            return service.GetNewOrders(shopid, fisttime, lasttime, sign);
        }

        public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address,
            string postalcode, string tel, string mobile, string email, string oderStatus,
            decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1,
            string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
        {
            var service = new OrderService();
            return service.GetOrders(shopid, orderNumber, memLoginID, name, address, postalcode, tel, mobile, email,
                oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted,
                pagesize, currentpage, sign);
        }
    }
}