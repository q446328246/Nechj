using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.ThirdInterDAL
{
    public class OrderService
    {
        public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber,
            string memLoginID, string name, string address, string postalcode, string tel,
            string mobile, string email, string oderStatus, decimal shouldPayPrice1,
            decimal shouldPayPrice2, int isDeleted)
        {
            string strText = shopid + fisttime + lasttime;
            if (MD5Encrypt(strText) == sign)
            {
                var builder = new StringBuilder();
                builder.Append("Select count(*) from shopNum1_orderinfo as a where shopid=");
                builder.Append("'" + shopid + "'");
                builder.Append(" And a.createtime>'" + fisttime + "'");
                builder.Append(" And a.createtime<'" + lasttime + "'");
                string str3 = null;
                if ((str3 = GetNomalString(orderNumber)) != string.Empty)
                {
                    builder.Append(" AND a.OrderNumber LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(memLoginID)) != string.Empty)
                {
                    builder.Append(" AND a.MemLoginID LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(name)) != string.Empty)
                {
                    builder.Append(" AND a.Name LIKE '%" + name + "%'");
                }
                if ((str3 = GetNomalString(address)) != string.Empty)
                {
                    builder.Append(" AND a.Address LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(postalcode)) != string.Empty)
                {
                    builder.Append("AND  a.Postalcode LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(tel)) != string.Empty)
                {
                    builder.Append(" AND a.Tel LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(mobile)) != string.Empty)
                {
                    builder.Append(" AND a.Mobile LIKE '%" + str3 + "%'");
                }
                if ((str3 = GetNomalString(email)) != string.Empty)
                {
                    builder.Append(" AND a.Email LIKE '%" + str3 + "%'");
                }
                if (oderStatus != "-1")
                {
                    builder.Append(" AND a.OderStatus=" + oderStatus);
                }
                if (shouldPayPrice1 != 0M)
                {
                    builder.Append(" AND a.ShouldPayPrice>=" + shouldPayPrice1 + " ");
                }
                if (shouldPayPrice2 != 0M)
                {
                    builder.Append(" AND a.ShouldPayPrice<=" + shouldPayPrice2 + " ");
                }
                if ((isDeleted == 0) || (isDeleted == 1))
                {
                    builder.Append(" AND a.IsDeleted=" + isDeleted + " ");
                }
                var helper = new SqlHelper();
                return helper.ExecuteScalar(builder.ToString());
            }
            return 0;
        }

        public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
        {
            string strText = shopid + fisttime + lasttime;
            if (MD5Encrypt(strText) == sign)
            {
                var builder = new StringBuilder();
                builder.Append(
                    "SELECT a.Guid,a.MemLoginID,a.OderStatus,a.PaymentStatus,a.ShipmentStatus,a.refundStatus,a.OrderNumber,c.ProductName,a.IsBuyComment,a.ISSellComment,a.IsMemdelay FROM ShopNum1_OrderInfo as a inner join shopNum1_OrderProduct as c on a.Guid=c.OrderInfoGuid inner join ShopNum1_OrderOperateLog as b on b.OrderInfoGuid=a.guid where a.shopid='");
                builder.Append(shopid);
                builder.Append(
                    "' And (select top 1 b.OperateDateTime from ShopNum1_OrderOperateLog order by b.OperateDateTime desc) > '");
                builder.Append(fisttime);
                builder.Append(
                    "' and (select top 1 b.OperateDateTime from ShopNum1_OrderOperateLog order by b.OperateDateTime desc) <'");
                builder.Append(lasttime);
                builder.Append("'");
                var helper = new SqlHelper();
                return helper.ExecuteDataSet(builder.ToString()).Tables[0];
            }
            return null;
        }

        public string GetNomalString(string str)
        {
            return str.Trim();
        }

        public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address,
            string postalcode, string tel, string mobile, string email, string oderStatus,
            decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1,
            string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
        {
            string strText = shopid + orderNumber + memLoginID;
            if (MD5Encrypt(strText) == sign)
            {
                string sql = SearchStr(shopid, orderNumber, memLoginID, name, address, postalcode, tel, mobile, email,
                    oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted,
                    pagesize, currentpage);
                var helper = new SqlHelper();
                return helper.ExecuteDataSet(sql).Tables[0];
            }
            return null;
        }

        public string MD5Encrypt(string strText)
        {
            byte[] bytes = Encoding.Default.GetBytes(strText);
            MD5 md = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "");
        }

        public string SearchStr(string shopid, string orderNumber, string memLoginID, string name, string address,
            string postalcode, string tel, string mobile, string email, string oderStatus,
            decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2,
            int isDeleted, int pagesize, int currentpage)
        {
            int num;
            int num2;
            if (currentpage == 1)
            {
                num = 1;
                num2 = pagesize;
            }
            else
            {
                num = ((currentpage - 1)*pagesize) + 1;
                num2 = currentpage*pagesize;
            }
            var builder = new StringBuilder();
            builder.Append("  SELECT OrderNumber,MemLoginID, (case OderStatus");
            builder.Append(" when 0 then '未确认'");
            builder.Append(" when 1  then '已确认'");
            builder.Append(" when 2   then '已取消'");
            builder.Append(" when 3  then '无效'");
            builder.Append(" when 4  then '退货'");
            builder.Append(" end");
            builder.Append(" ) AS OderStatusa,");
            builder.Append(" (case PaymentStatus");
            builder.Append(" when 0 then'未付款'");
            builder.Append(" when 1 then'付款中'");
            builder.Append(" when 2  then'已付款'");
            builder.Append(" end");
            builder.Append(" ) AS PaymentStatusa ,");
            builder.Append(" (case ShipmentStatus");
            builder.Append(" when 0 then '未发货'");
            builder.Append(" when 1 then '已发货'");
            builder.Append(" when 2 then '已收货'");
            builder.Append(" end");
            builder.Append(
                " )as ShipmentStatus,paymentname,ProductPrice,ShouldPayPrice,Name,Email,Address,postalcode,tel,mobile,createtime");
            builder.Append(" FROM (");
            builder.Append(
                " Select row_number() over (order by createtime) as rowId,a.MemLoginID,OderStatus,PaymentStatus ,ShipmentStatus ,a.OrderNumber,a.Name,a.Email,a.Address,a.Postalcode,a.Tel,a.Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentName,OutOfStockOperate,PackName,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,PayMemo,InvoiceType,InvoiceTax,Discount,a.IsDeleted ");
            builder.Append(" From ShopNum1_OrderInfo as a ");
            builder.Append(" WHERE a.ShopID='" + shopid + "'");
            string str = null;
            if ((str = GetNomalString(orderNumber)) != string.Empty)
            {
                builder.Append(" AND OrderNumber LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(memLoginID)) != string.Empty)
            {
                builder.Append(" AND MemLoginID LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(name)) != string.Empty)
            {
                builder.Append(" AND a.Name LIKE '%" + name + "%'");
            }
            if ((str = GetNomalString(address)) != string.Empty)
            {
                builder.Append(" AND Address LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(postalcode)) != string.Empty)
            {
                builder.Append("AND  Postalcode LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(tel)) != string.Empty)
            {
                builder.Append(" AND Tel LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(mobile)) != string.Empty)
            {
                builder.Append(" AND Mobile LIKE '%" + str + "%'");
            }
            if ((str = GetNomalString(email)) != string.Empty)
            {
                builder.Append(" AND Email LIKE '%" + str + "%'");
            }
            if (oderStatus != "-1")
            {
                builder.Append(" AND OderStatus=" + oderStatus);
            }
            if ((str = GetNomalString(createTime1)) != string.Empty)
            {
                builder.Append(" AND CreateTime>='" + str + "'");
            }
            if ((str = GetNomalString(createTime2)) != string.Empty)
            {
                builder.Append(" AND CreateTime<='" + str + "' ");
            }
            if (shouldPayPrice1 != 0M)
            {
                builder.Append(" AND ShouldPayPrice>=" + shouldPayPrice1 + " ");
            }
            if (shouldPayPrice2 != 0M)
            {
                builder.Append(" AND ShouldPayPrice<=" + shouldPayPrice2 + " ");
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" AND IsDeleted=" + isDeleted + " ");
            }
            builder.Append(" ) as t");
            builder.Append(string.Concat(new object[] {" where rowId between ", num, " and ", num2, " "}));
            return builder.ToString();
        }
    }
}