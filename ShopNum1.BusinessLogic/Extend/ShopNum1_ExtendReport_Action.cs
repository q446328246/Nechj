using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ExtendReport_Action : IShopNum1_ExtendReport_Action
    {
        public int Add()
        {
            return 0;
        }

        public DataTable GetCategoryByParam(string param)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select ShopNum1_ProductCategory.[Name], ShopNum1_ProductCategory.ID from ShopNum1_ProductCategory,ShopNum1_Product where fatherID in( select ID from ShopNum1_ProductCategory where fatherID = 0) and " +
                    param +
                    "= 1 and ShopNum1_ProductCategory.ID = ShopNum1_Product.ProductCategoryID Group by ShopNum1_ProductCategory.[Name], ShopNum1_ProductCategory.ID");
        }

        public DataTable Search(int productCategoryID, string brandGuid, decimal shopPrice1, decimal shopPrice2,
            decimal costPrice1, decimal costPrice2, decimal marketPrice1, decimal marketPrice2)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tName\t, \tRepertoryNumber\t, \tSaleNumber,\t\tRepertoryCount\t  FROM ShopNum1_Product  WHERE 0=0 ";
            if (productCategoryID != -1)
            {
                strSql = strSql + " AND ProductCategoryID=" + productCategoryID;
            }
            if ((Operator.FormatToEmpty(brandGuid) != string.Empty) && (brandGuid != "-1"))
            {
                strSql = strSql + " AND BrandGuid='" + brandGuid + "'";
            }
            if (shopPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND ShopPrice>=", shopPrice1, " "});
            }
            if (shopPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND shopPrice<=", shopPrice2, " "});
            }
            if (costPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND CostPrice>=", costPrice1, " "});
            }
            if (costPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND CostPrice<=", costPrice2, " "});
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

        public DataTable SearchAgentMemberBuyReport(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tA.MemloginID\t, \tB.Realname\t, \tcount(A.OrderNumber) AS OrderCount, \tsum(AlreadPayPrice) AS AlreadPayPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_member B\t\tWHERE 0=0\tAND B.Memloginid=A.Memloginid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
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

        public DataTable SearchAgentSellDetail(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.Name\t, \tA.OrderNumber\t, \tSum(B.BuyNumber) AS BuyNumber\t, \tA.DispatchTime\t, \tsum(round(cast(B.BuyPrice*B.BuyNumber as   decimal(20,2)),2)) AS BuyPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE 0=0\tAND B.OrderInfoGuid=A.Guid  AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2)";
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

        public DataTable SearchAgentSellOrder(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.Name\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice*B.BuyNumber) AS BuyPrice,  round(cast(sum(B.BuyPrice*B.BuyNumber)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND A.ShipmentStatus=1 AND  0=0   ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + "  AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "'  ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + "  AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "'  ";
            }
            return
                DatabaseExcetue.ReturnDataTable(str + "   Group By \tB.Name\t, \tRepertoryNumber\t" +
                                                " ORDER BY BuyPrice DESC");
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

        public DataTable SearchSeeBuyRate(int productCategoryID, string brandGuid, decimal shopPrice1,
            decimal shopPrice2, decimal costPrice1, decimal costPrice2,
            decimal marketPrice1, decimal marketPrice2)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tName\t, \tRepertoryNumber\t, \tSaleNumber,\t\tClickCount\t,     round(cast(SaleNumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate    FROM ShopNum1_Product     WHERE 0=0 AND ClickCount!=0";
            if (productCategoryID != -1)
            {
                strSql = strSql + " AND ProductCategoryID=" + productCategoryID;
            }
            if ((Operator.FormatToEmpty(brandGuid) != string.Empty) && (brandGuid != "-1"))
            {
                strSql = strSql + " AND BrandGuid='" + brandGuid + "'";
            }
            if (shopPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND ShopPrice>=", shopPrice1, " "});
            }
            if (shopPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND shopPrice<=", shopPrice2, " "});
            }
            if (costPrice1 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND CostPrice>=", costPrice1, " "});
            }
            if (costPrice2 != 0M)
            {
                strSql = string.Concat(new object[] {strSql, " AND CostPrice<=", costPrice2, " "});
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
                     " )*10*0.1 /   (select count(*) from ShopNum1_Member) as decimal(20,2)),2) as AverageMemberOrderRate, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(*) as OrderNum\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2  ";
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

        public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.Name\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice*B.BuyNumber) AS BuyPrice,  round(cast(sum(B.BuyPrice*B.BuyNumber)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Group By \tB.Name\t, \tRepertoryNumber\t ");
        }

        public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop)
        {
            string str = string.Empty;
            if (intTop > 0)
            {
                str = "SELECT    top " + intTop +
                      " \te.Name,\te.ProductGuid,\te.BuyNumber, \td.ShopPrice, \te.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            else
            {
                str =
                    "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \td.ShopPrice, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
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
                DatabaseExcetue.ReturnDataTable((str +
                                                 " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid ) AS e") +
                                                "  ON d.Guid = e.ProductGuid " + "  Order by BuyNumber desc");
        }

        public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop, string isNew,
            string isHot, string isRecommend, string isBest)
        {
            string str = string.Empty;
            if (intTop > 0)
            {
                str = "SELECT    top " + intTop +
                      " \te.Name,\te.ProductGuid,\te.BuyNumber, \tShopPrice, \tMarketPrice, \te.BuyPrice,  d.OriginalImge, \td.SmallImage\t, \td.ThumbImage\t\tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            else
            {
                str =
                    "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \tShopPrice, \tMarketPrice, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
            {
                str = str + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
            {
                str = str + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            str = str + " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid ) AS e" +
                  "  ON d.Guid = e.ProductGuid ";
            if (isBest != "-1")
            {
                str = str + "  AND d.IsBest=1";
            }
            if (isHot != "-1")
            {
                str = str + "  AND d.IsHot=1";
            }
            if (isNew != "-1")
            {
                str = str + "  AND d.IsNew=1";
            }
            if (isRecommend != "-1")
            {
                str = str + "  AND d.IsRecommend=1";
            }
            return DatabaseExcetue.ReturnDataTable(str + "  Order by BuyNumber desc");
        }

        public DataTable SearchSellOrders(string dispatchTime1, string dispatchTime2, int intTop)
        {
            string str = string.Empty;
            if (intTop > 0)
            {
                str = "SELECT    top " + intTop +
                      " \te.Name,\te.ProductGuid,\te.BuyNumber, \te.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
            }
            else
            {
                str =
                    "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
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
                                                " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid )  AS e ON d.Guid = e.ProductGuid WHERE 1=1 " +
                                                "  order by BuyNumber desc");
        }

        public DataTable SearchSellProduct(int intTop, int ProductCategoryID)
        {
            string str = string.Empty;
            if (intTop > 0)
            {
                str = "SELECT    top " + intTop +
                      " \td.Name,\td.Guid,  a.BuyNumber, \td.ShopPrice, \td.MarketPrice, \ta.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t,\td.OriginalImge\t,\td.ProductCategoryID\t,\ti.Name AS CategoryName\t,\tb.ShipmentStatus\t,\ta.ProductGuid\t,\ta.OrderInfoGuid\t,  b.Guid ,\ti.ID\t\tfrom \tShopNum1_Product AS d ,ShopNum1_ProductCategory AS i,ShopNum1_OrderProduct  AS a,ShopNum1_OrderInfo AS b\tWHERE   b.ShipmentStatus = 1 AND d.ProductCategoryID = i.ID AND b.Guid = a.OrderInfoGuid AND d.Guid = a.ProductGuid";
            }
            else
            {
                str = "SELECT    top " + intTop +
                      " \td.Name,\td.Guid,  a.BuyNumber, \td.ShopPrice, \td.MarketPrice, \ta.BuyPrice, \td.SmallImage, \td.OriginalImge\t,\td.ThumbImage\t,\td.ProductCategoryID\t,\ti.Name AS CategoryName\t,\tb.ShipmentStatus\t,\ta.ProductGuid\t,\ta.OrderInfoGuid\t,  b.Guid ,\ti.ID\t\tfrom \tShopNum1_Product AS d ,ShopNum1_ProductCategory AS i,ShopNum1_OrderProduct  AS a,ShopNum1_OrderInfo AS b\tWHERE   b.ShipmentStatus = 1 AND d.ProductCategoryID = i.ID AND b.Guid = a.OrderInfoGuid AND d.Guid = a.ProductGuid";
            }
            if (ProductCategoryID != -1)
            {
                str = str + "  AND d.ProductCategoryID = " + ProductCategoryID;
            }
            return DatabaseExcetue.ReturnDataTable(str + "  Order by a.BuyNumber desc");
        }
    }
}