using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_OrderInfo_Action : IShop_OrderInfo_Action
    {
        public int CancelOrder(string guid, string cancelreason, int oderstatus)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@cancelreason";
            paraValue[1] = cancelreason;
            paraName[2] = "@oderstatus";
            paraValue[2] = oderstatus.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_CancelOrder", paraName, paraValue);
        }

        public int DeleteOrderInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteOrderInfo", paraName, paraValue);
        }

        public DataTable GetOrderInfo(string guid, string paymentmemloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@paymentmemloginid";
            paraValue[1] = paymentmemloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string ProductGuid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ProductGuid";
            paraValue[0] = ProductGuid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string ProductGuid, string OderStatus)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ProductGuid";
            paraValue[0] = ProductGuid;
            paraName[1] = "@OderStatus";
            paraValue[1] = OderStatus;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            paraName[1] = "@oderstatus";
            paraValue[1] = oderstatus;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataTable Search(int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT Guid,Name,Memo,Charge,IsPercent  FROM ShopNum1_Payment  WHERE 1=1 and Name!='线下支付' ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By OrderID Desc");
        }

        public DataTable SearchOrderInfoByGuid(string guids)
        {
            string str = string.Empty;
            str =
                "SELECT Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,SellIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guids != "-1")
            {
                str = str + " AND Guid in (" + guids + ")";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable SearchOrderInfoByProductGuid(string productguid)
        {
            string str = string.Empty;
            str = "SELECT MemLoginID  FROM ShopNum1_OrderProduct  WHERE 0=0 ";
            if (productguid != "-1")
            {
                str = str + " AND ProductGuid in ('" + productguid + "')";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string timebegin, string timeend, string PaymentTypeGuid)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@ordernumber";
            paraValue[1] = ordernumber;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@oderstatus";
            paraValue[3] = oderstatus;
            paraName[4] = "@timebegin";
            paraValue[4] = timebegin;
            paraName[5] = "@timeend";
            paraValue[5] = timeend;
            paraName[6] = "@paymentGuid";
            paraValue[6] = PaymentTypeGuid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList", paraName, paraValue);
        }

        public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string ordertype, string timebegin, string timeend, string PaymentTypeGuid)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@ordernumber";
            paraValue[1] = ordernumber;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@oderstatus";
            paraValue[3] = oderstatus;
            paraName[4] = "@timebegin";
            paraValue[4] = timebegin;
            paraName[5] = "@timeend";
            paraValue[5] = timeend;
            paraName[6] = "@paymentGuid";
            paraValue[6] = PaymentTypeGuid;
            paraName[7] = "@ordertype";
            paraValue[7] = ordertype;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList2", paraName, paraValue);
        }

        public DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum)
        {
            string str = "select A.Guid,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,";
            str = str + "A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime," +
                  "B.productname from shopnum1_orderinfo A left join shopnum1_orderproduct B on B.orderinfoguid=a.guid";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "createtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateOrderMessage(string guid, string message, string messagetype)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@message";
            paraValue[1] = message;
            paraName[2] = "@messagetype";
            paraValue[2] = messagetype;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderMessage", paraName, paraValue);
        }

        public DataTable GetOrderInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", paraName, paraValue);
        }

        public int UpdateOrderInfoStatus(string guid, string statusname, string statusvalues)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@statusname";
            paraValue[1] = statusname;
            paraName[2] = "@statusvalues";
            paraValue[2] = statusvalues;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus", paraName, paraValue);
        }
    }
}