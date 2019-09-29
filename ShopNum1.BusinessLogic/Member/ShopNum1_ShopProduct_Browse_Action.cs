using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Collections.Generic;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopProduct_Browse_Action : IShopNum1_ShopProduct_Browse_Action
    {
        public int Add(ShopNum1_ShopProduct_Browse ShopProduct_Browse)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "INSERT INTO ShopNum1_ShopProduct_Browse( \tGuid\t, \tProductGuid\t, \tProductImage\t, \tShopPrice\t, \tName\t, \tMemLoginID\t, \tShopID\t, \tBrowseDateTime\t, \tBrowseTimes\t  ) VALUES (  '" +
                    Operator.FilterString(ShopProduct_Browse.Guid) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.ProductGuid) + "',  '" + ShopProduct_Browse.ProductImage +
                    "',  '" + Operator.FilterString(ShopProduct_Browse.ShopPrice) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.Name) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.MemLoginID) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.ShopID) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.BrowseDateTime) + "',  '" +
                    Operator.FilterString(ShopProduct_Browse.BrowseTimes) + "' )");
        }

        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopProduct_Browse WHERE  Guid"+andSql,parms.ToArray());
        }

        public int AddTimes(string ProductGuid, string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ProductGuid";
            parms[0].Value = ProductGuid;
            parms[1].ParameterName = "@MemLoginID";
            parms[1].Value = MemLoginID;
            return
                DatabaseExcetue.RunNonQuery(
                    "   UPDATE   ShopNum1_ShopProduct_Browse SET BrowseTimes=BrowseTimes+1 WHERE ProductGuid=@ProductGuid  AND  MemLoginID=@MemLoginID",parms);
        }

        public bool GetDataByMemLoginID(string ProductGuid, string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ProductGuid";
            parms[0].Value = ProductGuid;
            parms[1].ParameterName = "@MemLoginID";
            parms[1].Value = MemLoginID;
            string strSql = string.Empty;
            strSql = "  SELECT  COUNT(Guid)  FROM  ShopNum1_ShopProduct_Browse  WHERE  ProductGuid=@ProductGuid AND  MemLoginID =@MemLoginID";
            try
            {
                DataTable table = DatabaseExcetue.ReturnDataTable(strSql,parms);
                return (((table != null) && (table.Rows.Count > 0)) &&
                        (Convert.ToInt32(table.Rows[0][0].ToString()) > 0));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable Search(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string str = string.Empty;
            str = "SELECT  *   FROM ShopNum1_ShopProduct_Browse ";
            return
                DatabaseExcetue.ReturnDataTable((str + "    WHERE   MemLoginID=@MemLoginID") +
                                                "ORDER  BY BrowseDateTime DESC  ",parms);
        }

        public DataTable Search(string MemLoginID, int first, int int_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@first";
            parms[1].Value = first;
            parms[2].ParameterName = "@int_0";
            parms[2].Value = int_0;
            object obj2 = string.Empty +
                          "    SELECT *  FROM  ( select Guid,ProductGuid,ProductImage,ShopPrice,Name,MemLoginID,ShopID,      " +
                          "    BrowseDateTime,BrowseTimes,     ROW_NUMBER() over(order by BrowseDateTime DESC ) as rows     ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[]
                    {
                        obj2, "    from ShopNum1_ShopProduct_Browse   where   MemLoginID=@MemLoginID  ) AS B WHERE B.rows>=@first AND B.rows<=@int_0     "
                    }),parms);
        }
    }
}