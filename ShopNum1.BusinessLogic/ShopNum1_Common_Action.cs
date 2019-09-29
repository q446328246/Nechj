using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Common_Action : IShopNum1_Common_Action
    {
        public DataTable CommonGetPageContent(string perpagenum, string current_page, string tablename,
            string columnnames, string ordername, string searchname, int sdesc)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@tablename";
            paraValue[2] = tablename;
            paraName[3] = "@columnnames";
            paraValue[3] = (columnnames == "-1") ? "*" : columnnames;
            paraName[4] = "@ordername";
            paraValue[4] = ordername;
            paraName[5] = "@searchname";
            paraValue[5] = (searchname == "-1") ? "1=1" : searchname;
            paraName[6] = "@sdesc";
            paraValue[6] = (sdesc == 1) ? "desc" : "asc";
            paraName[7] = "@isreturcount";
            paraValue[7] = "0";
            return DatabaseExcetue.ReturnDataTable("Pro_CommonPage", paraName, paraValue);
        }

        public DataSet CommonGetPageCount(string perpagenum, string tablename, string searchname)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@tablename";
            paraValue[1] = tablename;
            paraName[2] = "@searchname";
            paraValue[2] = (searchname == "-1") ? "1=1" : searchname;
            paraName[3] = "@isreturcount";
            paraValue[3] = "1";
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPage", paraName, paraValue);
        }

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

        public int Insert(string strTab, string strColumn, string strInsertValue)
        {
            return
                DatabaseExcetue.RunNonQuery("INSERT INTO " + strTab + " (" + strColumn + ")VALUES(" + strInsertValue +
                                            ")");
        }

        public int DeleteAllFromTables(string tables)
        {
            string[] strArray = tables.Split(new[] {';'});
            new List<string>();
            var builder = new StringBuilder();
            foreach (string str in strArray)
            {
                string str2 = "truncate table " + str + ";";
                builder.Append(str2);
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                try
                {
                    DatabaseExcetue.RunNonQuery(builder.ToString());
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        public static int ReturnMaxID(string columnName, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, tableName);
        }

        public static int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, shopID, shopIDValue, tableName);
        }
    }
}