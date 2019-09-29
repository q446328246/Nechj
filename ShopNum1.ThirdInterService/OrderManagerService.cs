using System.ComponentModel;
using System.Data;
using System.Web.Services;
using ShopNum1.ThirdInterBLL;

namespace ShopNum1.OrderService
{
    [WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1),
     ToolboxItem(false)]
    public class OrderManagerService : WebService
    {
        [WebMethod(Description = "检查用户")]
        public int CheckMember(string memLoginId, string password)
        {
            var manager = new MemberManager();
            return manager.CheckMember(memLoginId, password);
        }

        [WebMethod(Description = "返回用户指定时间段的订单总量")]
        public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber,
            string memLoginID, string name, string address, string postalcode, string tel,
            string mobile, string email, string oderStatus, decimal shouldPayPrice1,
            decimal shouldPayPrice2, int isDeleted)
        {
            var manager = new OrderManager();
            return manager.GetCountOrders(shopid, fisttime, lasttime, sign, orderNumber, memLoginID, name, address,
                postalcode, tel, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2,
                isDeleted);
        }

        [WebMethod(Description = "返回用户指定时间段的订单信息")]
        public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
        {
            var manager = new OrderManager();
            return manager.GetNewOrders(shopid, fisttime, lasttime, sign);
        }

        [WebMethod(Description = "返回订单信息")]
        public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address,
            string postalcode, string tel, string mobile, string email, string oderStatus,
            decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1,
            string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
        {
            var manager = new OrderManager();
            return manager.GetOrders(shopid, orderNumber, memLoginID, name, address, postalcode, tel, mobile, email,
                oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted,
                pagesize, currentpage, sign);
        }
    }
}