using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OrderInfo_Action
    {
        DataTable GetOrderLastInfoShopName(string strMemloginId);
        int UpdateOrderPriceQD(string ordernumber);
        int UpdateOrderPriceSQ(string ordernumber);
        int UpdateOrderPvbHv(string strOrderNumber, string strMemloginId, string strHv, string strPvb);
        DataTable SelectOrderOfAll(string OrderNo);
        int UpdatePTScore_pv_b(string ordernumber);
        int Add(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct);
        int Add(List<ShopNum1_OrderInfo> listoderinfo, List<ShopNum1_OrderProduct> listOrderProduct);
        int AddOrder(ShopNum1_OrderInfo orderInfo);
        int AddOrderCode(ShopNum1_MemberActivate MemberActivate);
        int AddOtherOrderInfo(ShopNum1_Shop_OtherOrderInfo shopNum1_Shop_OtherOrderInfo);
        int BackNormalProudctRepertoryCount(string productguid, string buycount);
        int BackSpecificationProudctRepertoryCount(string productguid, string detail, string buycount);
        int BackUsedFavourTicket(string usercode, string memberloginid);
        int CancelOrder(string guid, string cancelreason, int oderstatus);
        DataSet CheckOrderState(string ordernumber, string memloginid);
        DataSet CheckTradeState(string TradeID, string memloginid);
        string ComputeInvoicePrice(string invoiceTax);
        string ComputeOderPrice(string orderPrice);
        string ComputeShouldPayPrice(string shouldPayPrice);
        int Delete(string guid);
        int DeleteOrderInfo(string guid);
        int DeleteOrderInfoByAdminOrdernum(string ordernum, int Type, string memloginId);
        int DeleteOrderInfoByOrdernum(string ordernum, int Type, string memloginId);
        DataTable GetAllStatus(string guid);
        string GetCode(string strOrderGuId);
        DataTable GetCode(string member, int isinvalid, string code);
        DataTable GetCommentInfoAndSaleNumber(string guid, string shopid, string datatime);
        DataTable GetGroupPriceTotalByOrderInfoGuid(string orderinfoguid);
        DataTable GetLifeOrderCount(string strMemLoginID);
        DataTable GetMemberBuyProductCount(string strmemberLoginID, string productguid);
        DataTable GetOrderCountByGuid(string guid);
        DataTable GetOrderCountByOrderNumber(string orderNumber);
        DataSet GetOrderDetail(string strOrderGuId, string strMemloginId, string strOrderType, string strIsShop);
        DataTable GetOrderGuidAndTypeByOrderNum(string string_0);
        DataTable GetOrderGuidByOrderNumberAndMemloginid(string ordernumber, string memloginid);
        DataTable GetOrderGuIdByTradeId(string strTradeid);
        DataTable GetOrderGuidByTradeIDAndMemloginid(string tradeid, string memloginid);
        int GetOrderIdentifyCodeIsEqual(string strOrderNumber, string strIdentifyCode);
        DataTable GetOrderInfo(string guid, string paymentmemloginid);
        DataTable GetOrderInfoAndProductInfo(string guid);
        DataTable GetOrderInfoByCode(string strMemLoginID, string strCode);
        DataTable GetOrderInfoByGuid(string guid);
        DataTable GetOrderInfoByGuidShop(string guid, string shopid);
        DataTable GetOrderInfoByMemloginID(string memloginid);
        string GetOrderNumberByGuid(string guid);
        DataTable GetOrderProductGuidAndByNumber(string orderNumber);
        DataTable GetOrderStatusAndNumberByGuid(string guids);
        DataTable GetOtherOrderInfoByTradeID(string tradeid, string memloginid);
        string GetPayMentMemLoginIDByOrderGuid(string orderguid);
        DataTable GetProductGuidAndBuyNum(string orderGuid);
        DataTable GetProductInfoAndOrderProductInfo(string guid, string shopid);
        DataSet getProductOrderRecord(string guid);
        DataSet getProductOrderRecord(string guid, string OderStatus);
        DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid);
        DataTable GetProductTypeByOrderGuid(string guid);
        DataTable GetRestoreOrderByMemLoginID(string memLoginID);
        string GetShopIDByOrderGuid(string orderguid);
        int MemberDelete(string guids, string filedName, string filedvalue);
        DataTable OrderInfoApplyCheck(string guid);
        DataSet OrderInfoGetSimpleByTradeID(string tradeid, string memloginid);
        
        int OrderInfoLogistics(string guid, string islogistics, string logisticscompany, string logisticscompanycode,
            string shipmentnumber);

        DataTable Search(int isDeleted);
        DataTable Search(string guid);

        DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
            string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2,
            string createTime1, string createTime2, int isDeleted, string shopID, string shopName,
            string orderStatus, string orderType);

        DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
            string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2,
            string createTime1, string createTime2, int isDeleted, string shopID, string shopName,
            string orderStatus, string orderType, string paymentStatus, string shipmentStatus);

        DataTable Search1(string guid);
        DataTable SearchAddressByGuid(string guid);
        DataTable SearchByMemLoginID(string memLoginID, int type);

        DataTable SearchByMemLoginID(string productname, string orderstatus, string ordernumber, string timestart,
            string timeend, string shopid, string memLoginID, int type);

        DataTable SearchNewOrderByMemLoginID(string memloginID, string showcount);
        DataTable SearchOrder(string orderNumber);
        DataTable SearchOrderInfo(string orderNumber);
        DataTable SearchOrderInfoByGuid(string guids);
        DataTable SearchOrderInfoByGuid(string guids, string OrderType);
        string SearchOrderInfoByOrderId(string strorderId, string strcolumn);
        DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType);
        DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType, string strCondition);
        DataTable SearchOrderInfoByProductGuid(string productguid);

        DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string timebegin, string timeend, string PaymentTypeGuid);

        DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string ordertype, string timebegin, string timeend, string PaymentTypeGuid);

        DataTable SearchOrderPayInfo(string guid);
        DataTable SearchOrderPayInfo(string guid, string memLoginID);
        DataTable SearchOrderProductByOrderGuid(string orderguid);
        DataTable SearchOrderShouldPrice(string guid);
        DataTable SearchOrderSimpleProduct(string guid);
        DataTable SearchOrderSimpleProduct(string guid, string shopid);
        DataTable SearchOtherByGuid(string guid);
        DataTable SearchPriceByGuid(string guid);
        DataSet SearchProductOrderRecord(string productguid, string memloginid,int category);
        DataTable SearchShipmentStatus1(string dispatchTime);
        DataTable SearchStatus(string guid);
        DataTable SelectList(string strcondition);

        DataTable SelectList(string pagesize, string currentpage, string condition, string resultnum,
            string strOrderColumn, string strSortV);

        DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum,
            string strProName);

        DataTable SearchOrderInfos(string personname, string startdate, string enddate);

        DataTable SearchCusOrder(string startdate, string enddate);

        DataTable SeachStoreOrder(string startdate, string enddate);

        
        int SetOderStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime confirmTime);

        int SetOderStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice,
            decimal shouldPayPrice, string shipmentNumber);

        int SetOderStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice,
            decimal shouldPayPrice, string shipmentNumber);

        int SetOderStatus4(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice,
            decimal shouldPayPrice, string shipmentNumber);

        int SetPaymentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice,
            decimal shouldPayPrice);

        int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime,
            decimal alreadPayPrice, decimal shouldPayPrice);

        int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime,
            decimal alreadPayPrice, decimal shouldPayPrice, string strTrade_no);

        int SetShipmentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, string shipmentNumber);

        int SetShipmentStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime dispatchTime,
            string shipmentNumber);

        int SetShipmentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus);
        int SetShipmentStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus);
        int SetWaitBuyerPay(string strOderStatus, string ShipmentStatus, string PaymentStatus, string strGuid);
        DataSet SingleTradePayMent(string OrderNumber, string memloginid);
        int UpdataOrderInfoIsMinus(ShopNum1_OrderInfo shopNum1_OrderInfo);

        int UpdataOrderInfoIsMinus(string IsMinus, string DispatchType, string ShouldPayPrice, string Guid,
            string DispatchPrice);

        int UpdataReceivedDays(string orderguid, string shopid, string ismember, string days);
        int UpdateAddress(ShopNum1_OrderInfo orderInfo, string orderguid);

        int UpdateAddressByGuid(string guid, string name, string email, string address, string postalcode,
            string string_0, string mobile);

        int UpdateByConfirmPay(string strordernum, string strname);
        int UpdateCancelOrderInfo(string strCanDate);
        int UpdateDelete(string guid);

        int UpdateDispatchInfo(string guid, string dispatchModeGuid, string dispatchModeName, string dispatchPrice,
            string insurePrice, string regionCode);

        int UpdateFeePriceByGuid(string dispatchprice, string ispercent, string guid, string IsMinus);
        int UpdateOrderMessage(string guid, string message, string messagetype);
        int UpdateOrderPrice(string strOrderNumber, string strMemloginId, string strNewPrice);

        int UpdateOrderPrice(string guid, string productPrice, string dispatchPrice, string insurePrice,
            string paymentPrice, string packPrice, string blessCardPrice, string alreadPayPrice,
            string surplusPrice, string useScore, string scorePrice, string invoiceTax, string discount,
            string shouldPayPrice);

        int UpdateOrderState(string strOrderGuId, string MemlogInId, string strOrderState, string strShipState,
            string strPayState, string strRefundState, string strIsShop);

        int UpdateOtherInfo(string guid, string blessCardPrice, string blessCardGuid, string blessCardName,
            string blessCardContent, string invoiceType, string invoic, string invoiceTitle,
            string invoiceContent, string clientToSellerMsg, string outOfStockOperate,
            string sellerToClientMsg);

        int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice);
        int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice, int ispercent);
        int UpdatePostFee(string postFee, string orderguid);

        int UpdateProduct(string guid, string productPrice, string shopSettingPath,
            List<ShopNum1_OrderProduct> listOrderProduct);

        int UpdateSaleNumAndRepertCtByOrderGuid(string OrderGuid);
        int UserDelete(string guids);
    }
}