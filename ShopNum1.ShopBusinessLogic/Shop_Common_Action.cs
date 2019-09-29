using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Common_Action : IShop_Common_Action
    {
        public string ComputeDiscountPrice(string discount)
        {
            return
                Convert.ToString(
                    Math.Round(
                        Convert.ToDecimal(
                            DatabaseExcetue.ReturnDataTable("SELECT " + discount + " AS Discount").Rows[0]["Discount"]
                                .ToString()), 2));
        }

        public string ComputeDispatchPrice(string formula)
        {
            return
                Convert.ToString(
                    Math.Round(
                        Convert.ToDecimal(
                            DatabaseExcetue.ReturnDataTable("SELECT " + formula + " AS DispatchPrice").Rows[0][
                                "DispatchPrice"].ToString()), 2));
        }

        public string ComputeInvoicePrice(string invoiceTax)
        {
            return
                Convert.ToString(
                    Math.Round(
                        Convert.ToDecimal(
                            DatabaseExcetue.ReturnDataTable("SELECT " + invoiceTax + " AS InvoiceTax").Rows[0][
                                "InvoiceTax"].ToString()), 2));
        }

        public string ComputeOderPrice(string orderPrice)
        {
            return
                Convert.ToString(
                    Math.Round(
                        Convert.ToDecimal(
                            DatabaseExcetue.ReturnDataTable("SELECT " + orderPrice + " AS OrderPrice").Rows[0][
                                "OrderPrice"].ToString()), 2));
        }

        public int ReturnMaxID(string columnName, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, tableName);
        }

        public int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, shopID, shopIDValue, tableName);
        }

        public int ReturnMaxIDByMemLoginID(string MemLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT Max(OrderID) AS NUM FROM ShopNum1_shop_ProductCategory WHERE MemLoginID = '" + MemLoginID +
                     "' ";
            DataTable table = null;
            try
            {
                table = DatabaseExcetue.ReturnDataTable(strSql);
            }
            catch (Exception exception)
            {
                ErrorShow.Show("Error_" + exception.Message);
                throw exception;
            }
            if ((table.Rows[0]["NUM"].ToString() != "") && (table.Rows.Count > 0))
            {
                return int.Parse(table.Rows[0]["NUM"].ToString());
            }
            return 0;
        }

        public static string GetShopImgPath(string memlogid)
        {
            DataTable memLoginInfo = new Shop_ShopInfo_Action().GetMemLoginInfo(memlogid);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            return ("/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") + "/shop" + str + "/");
        }

        public static string GetShopPath(string memLoginID)
        {
            DataTable shopIDAndOpenTimeByMemLoginID =
                new Shop_ShopInfo_Action().GetShopIDAndOpenTimeByMemLoginID(memLoginID);
            if ((shopIDAndOpenTimeByMemLoginID != null) && (shopIDAndOpenTimeByMemLoginID.Rows.Count > 0))
            {
                string str2 = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
                string str3 =
                    DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                return ("~/Shop/Shop/" + str3.Replace("-", "/") + "/shop" + str2 + "/");
            }
            return "";
        }
    }
}