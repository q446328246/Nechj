using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Report_Action : IShopNum1_Report_Action
    {
        public DataTable Search(string productCategoryCode, decimal shopPrice1, decimal shopPrice2, decimal marketPrice1,
            decimal marketPrice2)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tRepertoryCount\t  FROM ShopNum1_Shop_Product  WHERE 0=0 ";
            if (productCategoryCode != "-1")
            {
                strSql = strSql + " AND ProductCategoryCode like '" + productCategoryCode + "%'";
            }
            if (shopPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND ShopPrice>=", shopPrice1, " "});
            }
            if (shopPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND shopPrice<=", shopPrice2, " "});
            }
            if (marketPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND MarketPrice>=", marketPrice1, " "});
            }
            if (marketPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND MarketPrice<=", marketPrice2, " "});
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberBuyReport(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tA.MemloginID\t, \tB.Realname\t, \tcount(A.OrderNumber) AS OrderCount, \tsum(AlreadPayPrice) AS AlreadPayPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_member B\t\tWHERE \tB.Memloginid=A.Memloginid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Group by \tA.MemloginID\t, \tB.Realname\t ");
        }

        public DataTable SearchSeeBuyRate(string name, string productCategoryCode1, string productCategoryCode2,
            string productCategoryCode3, string brandGuid, decimal shopPrice1,
            decimal shopPrice2, decimal marketPrice1, decimal marketPrice2)
        {
            string str = string.Empty;
            str =
                "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tClickCount\t,     round(cast(SaleNumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate,    productcategoryname,    brandname    FROM ShopNum1_Shop_Product     WHERE 0=0 AND ClickCount!=0  ";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name like '%" + name + "%'";
            }
            if (productCategoryCode3 != "-1")
            {
                str = str + " AND productCategoryCode like '" + productCategoryCode3.Split(new[] {'/'})[0] + "%'";
            }
            if (productCategoryCode2 != "-1")
            {
                str = str + " AND productCategoryCode like '" + productCategoryCode2.Split(new[] {'/'})[0] + "%'";
            }
            if (productCategoryCode1 != "-1")
            {
                str = str + " AND productCategoryCode like '" + productCategoryCode1.Split(new[] {'/'})[0] + "%'";
            }
            if ((Operator.FormatToEmpty(brandGuid) != string.Empty) && (brandGuid != "-1"))
            {
                str = str + " AND BrandGuid='" + brandGuid + "'";
            }
            if (shopPrice1 != 0M)
            {
                str = string.Concat(new object[] {str, " AND ShopPrice>=", shopPrice1, " "});
            }
            if (shopPrice2 != 0M)
            {
                str = string.Concat(new object[] {str, " AND shopPrice<=", shopPrice2, " "});
            }
            if (marketPrice1 != 0M)
            {
                str = string.Concat(new object[] {str, " AND MarketPrice>=", marketPrice1, " "});
            }
            if (marketPrice2 != 0M)
            {
                str = string.Concat(new object[] {str, " AND MarketPrice<=", marketPrice2, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by SaleNumber desc");
        }

        public DataTable SearchSellDetail(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.Name\t, \tA.OrderNumber\t, \tSum(B.BuyNumber) AS BuyNumber\t, \tA.DispatchTime\t, \tsum(round(cast(B.BuyPrice*B.BuyNumber as   decimal(20,2)),2)) AS BuyPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid  AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2)";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Group By \tB.Name\t\t, \tA.OrderNumber\t, \tA.DispatchTime ");
        }

        public DataTable SearchSellGuideLineMemberBuyRate(string dispatchTime1, string dispatchTime2)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT   round(cast((select count(distinct MemLoginID) from ShopNum1_OrderInfo  where ShipmentStatus=1 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            strSql = strSql +
                     " )*10*0.1   /(select count(*) from ShopNum1_Member) as decimal(20,2)),2) as BuyRate\t, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(distinct MemLoginID) as BuyMemberNumber\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchSellGuideLineMemberOrderMoney(string dispatchTime1, string dispatchTime2)
        {
            string strSql = string.Empty;
            strSql = "SELECT  round(cast((select sum(ShouldPayPrice) from ShopNum1_OrderInfo where ShipmentStatus=1 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            strSql = strSql + ")*10*0.1/   (select Count(OrderNumber) from ShopNum1_OrderInfo where ShipmentStatus=1 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            strSql = strSql +
                     ") as decimal(20,2)),2) as  AverageOrderRate,  Count(OrderNumber) as OrderNum,   sum(ShouldPayPrice)  as AllOrderMoney\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchSellGuideLineMemberOrderNumber(string dispatchTime1, string dispatchTime2)
        {
            string strSql = string.Empty;
            strSql = "SELECT    round(cast((select count(*) from ShopNum1_OrderInfo  where ShipmentStatus=1 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            strSql = strSql +
                     " )*10*0.1 /   (select count(*) from ShopNum1_Member) as decimal(20,2)),2) as AverageMemberOrderRate, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(*) as OrderNum\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop)
        {
            string str = string.Empty;
            if (intTop > 0)
            {
                str = "SELECT    top " + intTop +
                      " \te.Name,\te.ProductGuid,\te.BuyNumber, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Shop_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber   FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            else
            {
                str =
                    "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Shop_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber   FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid )  AS e ON d.Guid = e.ProductGuid order by BuyNumber desc");
        }

        public DataTable SearchSellOrder(string Name, string shopName, string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.ProductName\t,   A.ShopName,sum(A.dispatchprice)dispatchprice, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice) AS BuyPrice,  round(cast(sum(B.BuyPrice)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND A.OderStatus=3 ";
            if (Operator.FormatToEmpty(Name) != string.Empty)
            {
                str = str + " AND b.ProductName like '%" + Operator.FilterString(Name) + "%' ";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                str = str + " AND A.shopName like '%" + Operator.FilterString(shopName) + "%' ";
            }
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                "Group By \tB.ProductName\t, \tRepertoryNumber\t,  A.ShopName,A.dispatchprice  order by buyprice desc");
        }
    }
}