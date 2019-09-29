using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Refund_Action
    {
        int Add(ShopNum1_Refund shopNum1_Refund);
        int AdminUpdateRefundStatus(string string_0, string status, string content, string CreateUser);
        bool CheckIsRefundApply(string memloginid, string orderid, string productguid);
        int Delete(string string_0);
        int DeleteRefundByOrId(string strOrderId);
        DataTable GetOnPassRefund(string shopid, string orderingoGuid, string productguid);
        DataTable GetOrderRefundInfo(int int_0);
        string GetOrderStatus(string orderguid);
        DataTable GetProductPriceAndMemLoginID(string shopid, string orderingoGuid, string productguid);
        DataTable GetProductPriceAndShopID(string memloginid, string orderingoGuid, string productguid);
        DataTable GetRefund(string orderingoGuid);
        DataTable GetRefundList(int ID);
        DataTable GetRefundList(string memloginid, string orderid, string productguid);
        DataTable GetRefundListByShopID(string shopID, string orderid, string productguid);
        DataTable GetRefundStatus(string shopid, string orderguid, string productguid);
        string IsCheckRefund(string orderingoGuid);

        int RefundUpdateAdvancePaymentMem(string memloginid, string shopid, decimal payprice, string orderguid,
            string productguid, int status);

        DataTable Search(string orderID, string ModifyUser, string ShopID, string MemLoginID, string ShouldPayPrice1,
            string ShouldPayPrice2, string OrderCreateTime1, string OrderCreateTime2, string isAdmin);

        DataTable SelectRefundInfo(string strId, string strMeloginId, string strIsShop);
        DataTable SelectRefundList(string pagesize, string currentpage, string condition, string resultnum);
        int ShopOnPassRefund(ShopNum1_Refund shopNum1_Refund);
        int Update(ShopNum1_Refund shopNum1_Refund);
        int UpdateProductGroupPrice(string ProductGuid, string OrderInfoGuid, string MemLoginID, string ShopID);
        int UpdateRefundStatus(string MemloginId, string onPassreason, string productguid, string status);

        int UpdateRefundStatus(string orderingoGuid, string productguid, string status, string adressName,
            string adressValue);

        int UpdateRefundStatusIsAdmin(string orderingoGuid, string productguid, string status);
    }
}