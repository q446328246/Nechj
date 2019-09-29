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
    public class ShopNum1_ShopUserRecommend_Action:IShopNum1_ShopUserRecommend_Action
    {

        public int Add(ShopNum1_ShopUserRecommend ShopUserRecommend)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_ShopUserRecommend(Guid,MemLoginID,ProductId,Remark,LastSettlementDate) VALUES ('"
                    , ShopUserRecommend.Guid, "',  '", ShopUserRecommend.MemLoginID, "',  '", ShopUserRecommend.ProductId, "',  '", ShopUserRecommend.Remark, "', '", ShopUserRecommend.LastSettlementDate, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        public DataTable Search(string memLoginID)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
                string strSql = string.Empty;
                
                strSql =
                    "    SELECT  [Mid],[Mname] ,[MMessage] ,[Mcreate],[MisShow],mobile FROM [KCEMessage] left join [ShopNum1_Member] on [Mname]=MemLoginID where MisShow=1";
                if (Operator.FormatToEmpty(memLoginID) != string.Empty)
                {
                    strSql = strSql + " and Mname =@memLoginID";
                }
                strSql = strSql + " order by [Mcreate]  desc";
            
                return DatabaseExcetue.ReturnDataTable(strSql,parms);
            
        }
        public DataTable SelectProdectIDBymenberId(string ProdectID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ProdectID";
            parms[0].Value = ProdectID;
         return DatabaseExcetue.ReturnDataTable("select ProductID from ShopNum1_ShopUserRecommendBindProduct where MemLoginID=@ProdectID",parms);
        }

        public DataTable SelectMoneyByTime(int ID,DateTime StartTime,DateTime OverTime )
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            parms[1].ParameterName = "@StartTime";
            parms[1].Value = StartTime;
            parms[2].ParameterName = "@OverTime";
            parms[2].Value = OverTime;
            return DatabaseExcetue.ReturnDataTable("select ShopNum1_OrderProduct.BuyNumber,ShopNum1_OrderProduct.BuyPrice from ShopNum1_OrderProduct left join ShopNum1_Shop_Product on ShopNum1_OrderProduct.ProductGuid=ShopNum1_Shop_Product.guid left join ShopNum1_OrderInfo on ShopNum1_OrderInfo.guid=ShopNum1_OrderProduct.OrderInfoGuid where ShopNum1_OrderInfo.ShipmentStatus=2 and ShopNum1_Shop_Product.id=@ID and ShopNum1_OrderInfo.CreateTime between @StartTime and @OverTime",parms);
        }

        public DataTable SelectMoneyByMerberTable(string memberID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memberID";
            parms[0].Value = memberID;
        return DatabaseExcetue.ReturnDataTable("select AdvancePayment from  ShopNum1_Member where MemLoginID=@memberID");
        }
        public int UpdateMoneyByMerberTable(string memberID, decimal money)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memberID";
            parms[0].Value = memberID;
            parms[1].ParameterName = "@money";
            parms[1].Value = money;
            DatabaseExcetue.RunNonQuery("update ShopNum1_Member set AdvancePayment=@money where MemLoginID=@memberID",parms);
            return 1;
                
        }

        public DataTable SelectTimeByMenberId(string memberId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memberId";
            parms[0].Value = memberId;
            return DatabaseExcetue.ReturnDataTable("select LastSettlementDate from ShopNum1_ShopUserRecommendBindProduct where MemLoginID=@memberId",parms);
        }


        public DataTable SearchBindProduct(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;


            string strSql = string.Empty;

            strSql =
                "select a.Guid,a.MemLoginID,a.LastSettlementDate,a.ProduactBindDate,a.ProductId,b.Name from ShopNum1_ShopUserRecommendBindProduct as a left join ShopNum1_Shop_Product as b on b.Id=a.ProductId where a.IsDeleted=1 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " and a.MemLoginID=@memLoginID";
            }

            return DatabaseExcetue.ReturnDataTable(strSql,parms);

        }

        public DataTable SearchProductID(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'", "");


            string strSql = string.Empty;

            strSql =
                "select * from ShopNum1_ShopUserRecommend ";
            if (Operator.FormatToEmpty(Guid) != string.Empty)
            {
                strSql = strSql + " where Guid=@Guid";
            }

            return DatabaseExcetue.ReturnDataTable(strSql,parms);

        }

        public DataTable SearchProduct(string ProductName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ProductName";
            parms[0].Value = ProductName;

            string strSql = string.Empty;

            strSql =
                "select Id,Name,ShopName from ShopNum1_Shop_Product ";
            if (Operator.FormatToEmpty(ProductName) != string.Empty)
            {
                strSql = strSql + " where Name LIKE '%@ProductName%'";
            }

            return DatabaseExcetue.ReturnDataTable(strSql,parms);

        }

        public DataTable SearchMember(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;

            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum1_ShopUserRecommend where MemLoginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Delete(string RecommendGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@RecommendGuid";
            parms[0].Value = RecommendGuid;
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopUserRecommend WHERE  Guid =@RecommendGuid",parms);
            int Row = Convert.ToInt32(table.Rows[0][0]);
            if (Row > 0)
            {
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopUserRecommend  WHERE  Guid =@RecommendGuid",parms);
                return 1;


            }
            return -1;
        }

        public int SearchAddBindProduct(string peoductid, string memloginid, ShopNum1_ShopUserRecommendBindProduct ShopUserRecommendBindProduct,string datetime)
        {
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopUserRecommendBindProduct WHERE  MemLoginID ='" + memloginid + "' and ProductID='" + peoductid+"'");
            int Row = Convert.ToInt32(table.Rows[0][0]);
            if (Row > 0)
            {
                DataTable table1 =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  IsDeleted FROM ShopNum1_ShopUserRecommendBindProduct WHERE  MemLoginID ='" + memloginid + "' and ProductID='" + peoductid+"'");
                int Row1 = Convert.ToInt32(table1.Rows[0][0]);
                if (Row1 == 0)
                {

                    DatabaseExcetue.RunNonQuery("update  ShopNum1_ShopUserRecommendBindProduct set IsDeleted=1,ProduactBindDate=CONVERT(DATETIME, '"+datetime+"', 121)  WHERE  MemLoginID ='" + memloginid + "' and ProductID='" + peoductid + "'");
                    return 1;
                }
                if (Row1 == 1)
                {
                    return -1;
                }


            }
            
                string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_ShopUserRecommendBindProduct(Guid,MemLoginID,ProductId,LastSettlementDate,ProduactBindDate,IsDeleted) VALUES ('"
                    , ShopUserRecommendBindProduct.Guid, "',  '", ShopUserRecommendBindProduct.MemLoginID, "',  '", ShopUserRecommendBindProduct.ProductId, "',  '", ShopUserRecommendBindProduct.LastSettlementDate, "', '", ShopUserRecommendBindProduct.ProduactBindDate, "',",ShopUserRecommendBindProduct.IsDeleted,")"
                });

                return DatabaseExcetue.RunNonQuery(sqlQuery);
            
            
        }




        public int DeleteBindProduct(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'", "");
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopUserRecommendBindProduct WHERE  Guid =@Guid",parms);
            int Row = Convert.ToInt32(table.Rows[0][0]);
            if (Row > 0)
            {
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopUserRecommendBindProduct  WHERE  Guid =@Guid",parms);
                return 1;


            }
            return -1;
        }
        public int DeleteBindProductone(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'", "");
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopUserRecommendBindProduct WHERE  Guid =@Guid",parms);
            int Row = Convert.ToInt32(table.Rows[0][0]);
            if (Row > 0)
            {
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopUserRecommendBindProduct  WHERE  Guid =@Guid",parms);
                return 1;


            }
            return -1;
        }


        public int UpdateBindProductDate(string memloginid, string datetime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@datetime";
            parms[1].Value = datetime;


            DatabaseExcetue.RunNonQuery("update  ShopNum1_ShopUserRecommendBindProduct set LastSettlementDate=CONVERT(DATETIME, @datetime, 121)  WHERE  MemLoginID =@memloginid  and IsDeleted=1",parms);
                    return 1;
               



        }
    }
}
