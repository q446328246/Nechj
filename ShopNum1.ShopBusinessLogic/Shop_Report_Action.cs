using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Report_Action : IShop_Report_Action
    {
        /// <summary>
        ///     取店铺的产品
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ProductSeriesCode"></param>
        /// <param name="SaleNumber1"></param>
        /// <param name="SaleNumber2"></param>
        /// <param name="RepertoryCount1"></param>
        /// <param name="RepertoryCount2"></param>
        /// <param name="productname"></param>
        /// <returns></returns>
        public DataTable Search(string MemLoginID, string ProductSeriesCode, string SaleNumber1, string SaleNumber2,
            string RepertoryCount1, string RepertoryCount2, string productname)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tProductSeriesName,\t\tRepertoryCount\t  FROM ShopNum1_Shop_Product  WHERE MemLoginID='" +
                MemLoginID + "'";
            if (ProductSeriesCode != "-1")
            {
                strSql = strSql + " AND ProductSeriesCode like '" + ProductSeriesCode + "%'";
            }
            if (SaleNumber1 != "-1")
            {
                strSql = strSql + " AND SaleNumber>=" + SaleNumber1 + " ";
            }
            if (SaleNumber2 != "-1")
            {
                strSql = strSql + " AND SaleNumber<=" + SaleNumber2 + " ";
            }
            if (RepertoryCount1 != "-1")
            {
                strSql = strSql + " AND RepertoryCount>=" + RepertoryCount1 + " ";
            }
            if (RepertoryCount2 != "-1")
            {
                strSql = strSql + " AND RepertoryCount<=" + RepertoryCount2 + " ";
            }
            if (productname != "-1")
            {
                strSql = strSql + " AND Name ='" + productname + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchClickCount(string ShopID, string SaleNumber1, string SaleNumber2, string ClickCount1,
            string ClickCount2, string ProductName)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT   Name, ClickCount,  ProductNum,  SaleNumber,  round(cast(salenumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate FROM ShopNum1_Shop_Product  WHERE 0=0 and ClickCount!=0  ";
            if (ShopID != "")
            {
                strSql = strSql + " and MemLoginID='" + ShopID + "'";
            }
            if (SaleNumber1 != "-1")
            {
                strSql = strSql + " and SaleNumber>=" + SaleNumber1;
            }
            if (SaleNumber2 != "-1")
            {
                strSql = strSql + " and SaleNumber<=" + SaleNumber2;
            }
            if (ClickCount1 != "-1")
            {
                strSql = strSql + " and ClickCount>=" + ClickCount1;
            }
            if (ClickCount2 != "-1")
            {
                strSql = strSql + " and ClickCount<=" + ClickCount2;
            }
            if (ProductName != "-1")
            {
                strSql = strSql + " and Name ='" + ProductName + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchShopSellOrder(string MemLoginID, string dispatchTime1, string dispatchTime2,
            string ProductName)
        {
            string str = string.Empty;
            str =
                "SELECT \tB.ProductName\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice) AS BuyPrice,  round(cast(sum(B.BuyPrice)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B  \tWHERE \tB.OrderInfoGuid=A.Guid   AND A.Oderstatus=3    AND A.ShopID='" +
                MemLoginID + "'";
            if (Operator.FormatToEmpty(dispatchTime1) != "")
            {
                str = str + " AND A.confirmtime>='" + Operator.FilterString(dispatchTime1) + "' ";
            }
            if (Operator.FormatToEmpty(dispatchTime2) != "")
            {
                str = str + " AND A.confirmtime<='" + Operator.FilterString(dispatchTime2) + "' ";
            }
            if (Operator.FormatToEmpty(ProductName) != "")
            {
                str = str + " AND B.ProductName ='" + Operator.FilterString(ProductName) + "' ";
            }
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                " Group By \tB.ProductName\t, \tRepertoryNumber\torder by BuyNumber desc ");
        }
    }
}