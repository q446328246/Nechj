using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Refund_Action : IShopNum1_Refund_Action
    {
        public int Add(ShopNum1_Refund shopNum1_Refund)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_Refund(");
            builder.Append(
                "OrderID,ProductGuid,RefundID,ApplyTime,RefundType,RefundStatus,RefundMoney,RefundContent,RefundReason,RefundImg,MemLoginID,ShopID,IsReceive,LogisticName,LogisticNumber ");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + shopNum1_Refund.OrderID + "',");
            builder.Append("'" + shopNum1_Refund.ProductGuid + "',");
            builder.Append("'" + shopNum1_Refund.RefundID + "',");
            builder.Append("'" + shopNum1_Refund.ApplyTime + "',");
            builder.Append(shopNum1_Refund.RefundType + ",");
            builder.Append(shopNum1_Refund.RefundStatus + ",");
            builder.Append(shopNum1_Refund.RefundMoney + ",");
            builder.Append("'" + shopNum1_Refund.RefundContent + "',");
            builder.Append("'" + shopNum1_Refund.RefundReason + "',");
            builder.Append("'" + shopNum1_Refund.RefundImg + "',");
            builder.Append("'" + shopNum1_Refund.MemLoginID + "',");
            builder.Append("'" + shopNum1_Refund.ShopID + "',");
            builder.Append(" " + shopNum1_Refund.IsReceive + ", ");
            builder.Append("'" + shopNum1_Refund.LogisticName + "',");
            builder.Append("'" + shopNum1_Refund.LogisticNumber + "'");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int AdminUpdateRefundStatus(string string_0, string status, string content, string CreateUser)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            parms[1].ParameterName = "@status";
            parms[1].Value = status;
            parms[2].ParameterName = "@content";
            parms[2].Value = content;
            parms[3].ParameterName = "@CreateUser";
            parms[3].Value = CreateUser;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Refund SET RefundStatus=@status, AdminContent=@conten, ModifyUser=@CreateUser WHERE ID=@string_0",parms);
        }

        public bool CheckIsRefundApply(string memloginid, string orderid, string productguid)
        {
            
            if (
                int.Parse(
                    DatabaseExcetue.ReturnString("SELECT COUNT(*) FROM ShopNum1_Refund WHERE MemLoginID='" + memloginid +
                                                 "' and OrderID='" + orderid + "' and ProductGuid='" + productguid + "'")) >
                0)
            {
                return false;
            }
            return true;
        }

        public int Delete(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_Refund ");
            builder.Append(" where ID IN(@string_0)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public int DeleteRefundByOrId(string strOrderId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strOrderId";
            parms[0].Value = strOrderId;
            
            return DatabaseExcetue.RunNonQuery("DELETE FROM shopnum1_refund WHERE orderid=@strOrderId",parms);
        }

        public DataTable GetOnPassRefund(string shopid, string orderingoGuid, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@shopid";
            parms[0].Value = shopid;
            parms[0].ParameterName = "@orderingoGuid";
            parms[0].Value = orderingoGuid;
            parms[0].ParameterName = "@productguid";
            parms[0].Value = productguid;
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(" RefundStatus,OnPassReason,OnPassImg,ModifyTime,AddressName ");
            builder.Append(" from ShopNum1_Refund WHERE ShopID=@shopid and OrderID=@orderingoGuid and ProductGuid=@productguid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetOrderRefundInfo(int int_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT C.OrderNumber,A.[Name],B.OrderID,B.ModifyUser,B.RefundID,B.MemLoginID,B.ShopID,B.RefundMoney,B.ApplyTime,B.RefundType,B.RefundReason,B.IsReceive,B.RefundContent,B.RefundImg,B.AddressName,B.OnPassReason,B.OnPassImg,C.CreateTime,C.ShipmentStatus FROM ShopNum1_OrderProduct AS A,ShopNum1_Refund AS B, ShopNum1_OrderInfo AS C WHERE A.OrderInfoGuid=B.OrderID AND A.ProductGuid=B.ProductGuid AND A.OrderInfoGuid=C.Guid AND B.ID=@int_0",parms);
        }

        public string GetOrderStatus(string orderguid)
        {
            return
                DatabaseExcetue.ReturnString("SELECT OderStatus FROM ShopNum1_OrderInfo WHERE Guid='" + orderguid + "'");
        }

        public DataTable GetProductPriceAndMemLoginID(string shopid, string orderingoGuid, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@shopid";
            parms[0].Value = shopid;
            parms[1].ParameterName = "@orderingoGuid";
            parms[1].Value = orderingoGuid;
            parms[2].ParameterName = "@productguid";
            parms[2].Value = productguid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT RefundMoney ,MemLoginID FROM ShopNum1_Refund WHERE ShopID=@shopid and OrderID=@orderingoGuid and ProductGuid=@productguid",parms);
        }

        public DataTable GetProductPriceAndShopID(string memloginid, string orderingoGuid, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@orderingoGuid";
            parms[1].Value = orderingoGuid;
            parms[2].ParameterName = "@productguid";
            parms[2].Value = productguid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT BuyPrice*BuyNumber AS TotalPrice ,ShopID,Name FROM ShopNum1_OrderProduct WHERE MemLoginID=@memloginid and OrderInfoGuid=@orderingoGuid and ProductGuid=@productguid",parms);
        }

        public DataTable GetRefund(string orderingoGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderingoGuid";
            parms[0].Value = orderingoGuid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select RefundMoney,refundstatus,ReFundContent,OnPassReason,RefundImg,OnPassImg,ProductGuid,RefundType from ShopNum1_Refund where 1=1 and orderid=@orderingoGuid",parms);
        }

        public DataTable GetRefundList(int ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(
                " ID,OrderID,ProductGuid,RefundID,ApplyTime,RefundType,RefundStatus,RefundMoney,RefundContent,RefundReason,OnPassReason,ModifyTime,RefundImg,OnPassImg,IsAdmin,AdminContent,AddressName,AddressValue,MemLoginID,ShopID,IsReceive ");
            builder.Append(" from ShopNum1_Refund ");
            if (ID != -1)
            {
                builder.Append(" where ID=@ID");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetRefundList(string memloginid, string orderid, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@orderid";
            parms[1].Value = orderid;
            parms[2].ParameterName = "@productguid";
            parms[2].Value = productguid;
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(
                " A.ID,A.OrderID,A.ProductGuid,A.RefundID,A.ApplyTime,A.RefundType,A.RefundStatus,A.RefundMoney,A.RefundContent,A.RefundReason,A.OnPassReason,A.ModifyTime,A.RefundImg,A.OnPassImg,A.IsAdmin,A.AdminContent,A.AddressName,A.AddressValue,A.MemLoginID,A.ShopID,A.IsReceive,B.Name AS ProductName ");
            builder.Append(
                " from ShopNum1_Refund AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid where 0=0");
            if (memloginid != "-1")
            {
                builder.Append(" and A.MemLoginID=@memloginid");
            }
            if (orderid != "-1")
            {
                builder.Append(" and A.OrderID=@orderid");
            }
            if (productguid != "-1")
            {
                builder.Append(" and A.ProductGuid=@productguid");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetRefundListByShopID(string shopID, string orderid, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@shopID";
            parms[0].Value = shopID;
            parms[1].ParameterName = "@orderid";
            parms[1].Value = orderid;
            parms[2].ParameterName = "@productguid";
            parms[2].Value = productguid;
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(
                " A.ID,A.OrderID,A.ProductGuid,A.RefundID,A.ApplyTime,A.RefundType,A.RefundStatus,A.RefundMoney,A.RefundContent,A.RefundReason,A.OnPassReason,A.ModifyTime,A.RefundImg,A.OnPassImg,A.IsAdmin,A.AdminContent,A.AddressName,A.AddressValue,A.MemLoginID,A.ShopID,A.IsReceive,B.Name AS ProductName ");
            builder.Append(
                " from ShopNum1_Refund AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid where 0=0");
            if (shopID != "-1")
            {
                builder.Append(" and A.ShopID=@shopID");
            }
            if (orderid != "-1")
            {
                builder.Append(" and A.OrderID=@orderid");
            }
            if (productguid != "-1")
            {
                builder.Append(" and A.ProductGuid=@productguid");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetRefundStatus(string shopid, string orderguid, string productguid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@orderguid";
            paraValue[1] = orderguid;
            paraName[2] = "@productguid";
            paraValue[2] = productguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetRefundStatus", paraName, paraValue);
        }

        public string IsCheckRefund(string orderingoGuid)
        {
            return
                DatabaseExcetue.ReturnString("select refundstatus from ShopNum1_Refund where 1=1 and orderid='" +
                                             orderingoGuid + "'");
        }
        //修改后强行后台退款
        public int RefundUpdateAdvancePaymentMem_two(string memloginid, string shopid, string orderguid,
            string productguid, int status)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Refund SET RefundStatus=", status, " WHERE OrderID='", orderguid,
                    "' AND ProductGuid='", productguid, "' AND ShopID='", shopid, "'"
                });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int RefundUpdateAdvancePaymentMem(string memloginid, string shopid, decimal payprice, string orderguid,
            string productguid, int status)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+", payprice, " WHERE MemLoginID='",
                    memloginid, "'"
                });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Refund SET RefundStatus=", status, " WHERE OrderID='", orderguid,
                    "' AND ProductGuid='", productguid, "' AND ShopID='", shopid, "'"
                });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable Search(string orderID, string ModifyUser, string ShopID, string MemLoginID,
            string ShouldPayPrice1, string ShouldPayPrice2, string OrderCreateTime1,
            string OrderCreateTime2, string isAdmin)
        {
            string str = string.Empty;
            str =
                "SELECT A.ID,A.MemLoginID,A.ShopID,A.ModifyUser,A.RefundMoney,A.IsAdmin,A.RefundStatus,A.RefundType,A.IsReceive,B.OrderNumber,B.CreateTime,B.ProductPrice FROM ShopNum1_Refund AS A,ShopNum1_OrderInfo AS B WHERE A.OrderID=B.Guid ";
            if (Operator.FilterString(orderID) != "-1")
            {
                str = str + " AND B.OrderNumber='" + orderID + "'";
            }
            if (Operator.FilterString(ModifyUser) != "-1")
            {
                str = str + " AND A.ModifyUser='" + ModifyUser + "'";
            }
            if (Operator.FilterString(ShopID) != "-1")
            {
                str = str + " AND A.ShopID='" + ShopID + "'";
            }
            if (Operator.FilterString(MemLoginID) != "-1")
            {
                str = str + " AND A.MemLoginID='" + MemLoginID + "'";
            }
            if (Operator.FilterString(ShouldPayPrice1) != "-1")
            {
                str = str + " AND A.RefundMoney>='" + ShouldPayPrice1 + "'";
            }
            if (Operator.FilterString(ShouldPayPrice2) != "-1")
            {
                str = str + " AND A.RefundMoney<='" + ShouldPayPrice2 + "'";
            }
            if (Operator.FilterString(OrderCreateTime1) != "-1")
            {
                str = str + " AND B.CreateTime>='" + OrderCreateTime1 + "'";
            }
            if (Operator.FilterString(OrderCreateTime2) != "-1")
            {
                str = str + " AND B.CreateTime<='" + OrderCreateTime2 + "'";
            }
            if (Operator.FilterString(isAdmin) != "-1")
            {
                str = str + " AND A.IsAdmin=" + isAdmin + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.ApplyTime DESC");
        }

        public DataTable SelectRefundInfo(string strId, string strMeloginId, string strIsShop)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@Id";
            paraValue[0] = strId;
            paraName[1] = "@MeloginId";
            paraValue[1] = strMeloginId;
            paraName[2] = "@IsShop";
            paraValue[2] = strIsShop;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderRefundInfo", paraName, paraValue);
        }

        public DataTable SelectRefundList(string pagesize, string currentpage, string condition, string resultnum)
        {
            string str =
                "select A.*,b.ordernumber,b.shouldpayprice,b.paymentname from shopnum1_refund A \r\ninner join shopnum1_orderinfo B ON B.guid=a.orderid ";
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
            paraValue[5] = "applytime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int ShopOnPassRefund(ShopNum1_Refund shopNum1_Refund)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_Refund set ");
            builder.Append("OnPassImg='" + shopNum1_Refund.OnPassImg + "',");
            builder.Append("OnPassReason='" + shopNum1_Refund.OnPassReason + "',");
            builder.Append("ModifyTime='" + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") + "',");
            builder.Append("RefundStatus=" + shopNum1_Refund.RefundStatus + " ");
            builder.Append(
                string.Concat(new object[]
                {
                    " where OrderID='", shopNum1_Refund.OrderID, "' AND ProductGuid='", shopNum1_Refund.ProductGuid,
                    "'"
                }));
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Update(ShopNum1_Refund shopNum1_Refund)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_Refund set ");
            builder.Append("RefundStatus=" + shopNum1_Refund.RefundStatus + ",");
            builder.Append("RefundMoney=" + shopNum1_Refund.RefundMoney + ",");
            builder.Append("RefundContent='" + shopNum1_Refund.RefundContent + "',");
            builder.Append("LogisticName='" + shopNum1_Refund.LogisticName + "',");
            builder.Append("LogisticNumber='" + shopNum1_Refund.LogisticNumber + "',");
            builder.Append("RefundReason='" + shopNum1_Refund.RefundReason + "',");
            builder.Append("IsReceive=" + shopNum1_Refund.IsReceive + ",");
            builder.Append("RefundImg='" + shopNum1_Refund.RefundImg + "' ");
            builder.Append(
                string.Concat(new object[]
                {
                    " where OrderID='", shopNum1_Refund.OrderID, "' AND ProductGuid='", shopNum1_Refund.ProductGuid,
                    "'"
                }));
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateProductGroupPrice(string ProductGuid, string OrderInfoGuid, string MemLoginID, string ShopID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@ProductGuid";
            parms[0].Value = ProductGuid;
            parms[1].ParameterName = "@OrderInfoGuid";
            parms[1].Value = OrderInfoGuid;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            parms[3].ParameterName = "@ShopID";
            parms[3].Value = ShopID;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_OrderProduct SET GroupPrice=0.00 WHERE ProductGuid=@ProductGuid AND OrderInfoGuid=@OrderInfoGuid AND MemLoginID=@MemLoginID AND ShopID=@ShopID",parms);
        }

        public int UpdateRefundStatus(string MemloginId, string onPassreason, string productguid, string status)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemloginId";
            parms[0].Value = MemloginId;
            parms[1].ParameterName = "@onPassreason";
            parms[1].Value = onPassreason;
            parms[2].ParameterName = "@productguid";
            parms[2].Value = productguid;
            parms[3].ParameterName = "@status";
            parms[3].Value = status;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Refund SET RefundStatus=@status,onPassreason=@onPassreason,ModifyTime='" +
                                            DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") +
                                            "' WHERE  ProductGuid=@productguid and shopID=@MemloginId",parms);
        }

        public int UpdateRefundStatus(string orderingoGuid, string productguid, string status, string adressName,
            string adressValue)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@orderingoGuid";
            parms[0].Value = orderingoGuid;
            parms[1].ParameterName = "@productguid";
            parms[1].Value = productguid;
            parms[2].ParameterName = "@status";
            parms[2].Value = status;
            parms[3].ParameterName = "@adressName";
            parms[3].Value = adressName;
            parms[4].ParameterName = "@adressValue";
            parms[4].Value = adressValue;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Refund SET RefundStatus=@status, AddressName=@adressName,AddressValue=@adressValue,ModifyTime='" +
                                            DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") +
                                            "' WHERE OrderID=@orderingoGuid AND ProductGuid=@productguid",parms);
        }

        public int UpdateRefundStatusIsAdmin(string orderingoGuid, string productguid, string status)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@orderingoGuid";
            parms[0].Value = orderingoGuid;
            parms[1].ParameterName = "@productguid";
            parms[1].Value = productguid;
            parms[2].ParameterName = "@status";
            parms[2].Value = status;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Refund SET IsAdmin=@status WHERE OrderID=@orderingoGuid AND ProductGuid=@productguid",parms);
        }
    }
}