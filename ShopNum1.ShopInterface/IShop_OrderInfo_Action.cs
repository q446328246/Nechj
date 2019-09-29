using System.Data;

namespace ShopNum1.ShopInterface
{
    public interface IShop_OrderInfo_Action
    {
        int CancelOrder(string guid, string cancelreason, int oderstatus);
        int DeleteOrderInfo(string guid);
        DataTable GetOrderInfo(string guid, string paymentmemloginid);
        DataSet getProductOrderRecord(string guid);
        DataSet getProductOrderRecord(string guid, string OderStatus);
        DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid);
        DataTable Search(int isDeleted);
        DataTable SearchOrderInfoByGuid(string guids);
        DataTable SearchOrderInfoByProductGuid(string productguid);

        DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string timebegin, string timeend, string PaymentTypeGuid);

        DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string ordertype, string timebegin, string timeend, string PaymentTypeGuid);

        DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum);
        int UpdateOrderMessage(string guid, string message, string messagetype);
    }
}