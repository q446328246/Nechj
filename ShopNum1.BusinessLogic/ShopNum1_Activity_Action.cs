﻿using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.SqlClient;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Activity_Action : IShopNum1_Activity_Action
    {
        public int AddActivity(ShopNum1_Product_Activity ShopNum1_Activity)
        {
            string str =
                "INSERT INTO ShopNum1_Product_Activity(name,starttime,endtime,finaltime,type,pic,Discount,limitProduct,memloginId,shopName";
            if (ShopNum1_Activity.State.ToString() != "")
            {
                str = str + ",state";
            }
            object obj2 = str + ")";
            obj2 =
                string.Concat(new[]
                {
                    obj2, "VALUES('", ShopNum1_Activity.Name, "','", ShopNum1_Activity.StartTime, "','",
                    ShopNum1_Activity.EndTime, "','", ShopNum1_Activity.FinalTime, "',"
                });
            string str2 =
                string.Concat(new[]
                {
                    obj2, "'", ShopNum1_Activity.Type, "','", ShopNum1_Activity.Pic, "','",
                    ShopNum1_Activity.Discount,
                    "','", ShopNum1_Activity.LimitProduct, "',"
                });
            str = str2 + "'" + ShopNum1_Activity.MemloginId + "','" + ShopNum1_Activity.ShopName + "'";
            if (ShopNum1_Activity.State.ToString() != "")
            {
                str = str + ",0";
            }
            return DatabaseExcetue.RunNonQuery(str + ");");
        }

        public int AddThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO [ShopNum1_ThemeActivity] ");
            builder.Append(" ([Guid] ");
            builder.Append(" ,[ThemeTitle] ");
            builder.Append(" ,[StartDate] ");
            builder.Append(" ,[EndDate] ");
            builder.Append(" ,[ThemeImage] ");
            builder.Append(" ,[ThemeDescription] ");
            builder.Append(" ,[ThemeStatus] ");
            builder.Append(" ,[OrderID] ");
            builder.Append(" ,[CreateUser] ");
            builder.Append(" ,[CreateTime]) ");
            builder.Append(" VALUES ");
            builder.Append(" ('" + shopNum1_ThemeActivity.Guid + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.ThemeTitle + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.StartDate + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.EndDate + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.ThemeImage + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.ThemeDescription + "' ");
            builder.Append(" ," + shopNum1_ThemeActivity.ThemeStatus + " ");
            builder.Append(" ," + shopNum1_ThemeActivity.OrderID + " ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.CreateUser + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivity.CreateTime + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int AddThemeProduct(ShopNum1_ThemeActivityProduct shopNum1_ThemeActivityProduct)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO [ShopNum1_ThemeActivityProduct] ");
            builder.Append(" ([Guid] ");
            builder.Append(" ,[ThemeGuid] ");
            builder.Append(" ,[ProductGuid] ");
            builder.Append(" ,[ProductName] ");
            builder.Append(" ,[ProductImage] ");
            builder.Append(" ,[ProductPrice] ");
            builder.Append(" ,[ShopName] ");
            builder.Append(" ,[MemloginID] ");
            builder.Append(" ,[IsAudit] ");
            builder.Append(" ,[CreateTime]) ");
            builder.Append("  VALUES ");
            builder.Append(" ('" + shopNum1_ThemeActivityProduct.Guid + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ThemeGuid + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductGuid + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductName + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductImage + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductPrice + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.ShopName + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.MemloginID + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.IsAudit + "' ");
            builder.Append(" ,'" + shopNum1_ThemeActivityProduct.CreateTime + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int CloseActivity(string strId)
        {
            DbParameter[] para = new DbParameter[1];
            para[0].ParameterName = "@strId";
            para[0].Value = strId;

            return DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Product_Activity SET State='2' WHERE Id=@strId", para);
        }

        public int DeleteActivity(string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;


            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Product_Activity WHERE Id in(@strId)", parms);
        }

        public int DeleteThemeActivty(string guid)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "DELETE FROM [ShopNum1_ThemeActivity] WHERE Guid in (" + guid + ")";
            sqlList.Add(item);
            item = "Delete from ShopNum1_ThemeActivityProduct where ThemeGuid in (" + guid + ")";
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

        public int DeleteThemeActivtyProduct(string Guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("Delete from ShopNum1_ThemeActivityProduct where Guid in (@Guid)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        public DataTable GetActivityById(string strMemloginId, string strLid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@strMemloginId";
            parms[0].Value = strMemloginId;
            parms[1].ParameterName = "@strLid";
            parms[1].Value = strLid;
            string str2 =
                "select name,starttime s,endtime e,state,discount,memloginid,limitProduct,\r\n(select count(*) from ShopNum1_Limt_Product where lid=t.id)pc from ShopNum1_Product_Activity as t where type=2 ";
            return
                DatabaseExcetue.ReturnDataTable(str2 + " and memloginid=@strMemloginId and id=@strLid", parms);
        }

        public DataTable GetGroupActivityById(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = string_0.Replace("'","");
            string str = "select name,starttime,endtime from ShopNum1_Product_Activity where type=1 ";
            return DatabaseExcetue.ReturnDataTable(str + "and id=@Guid", parms);
        }

        public DataTable GetProductActivity()
        {
            string strSql =
                "select id,name, CONVERT(varchar(100),starttime, 102)s,CONVERT(varchar(100),endtime, 102)e from ShopNum1_Product_Activity where state!=2 and endtime>getdate() and finaltime>getdate() and type=1";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetThemeActivty()
        {
            var builder = new StringBuilder();
            builder.Append(
                "select  Guid,ThemeTitle, CONVERT(varchar(100),startdate, 102)s,CONVERT(varchar(100),enddate, 102)e from ShopNum1_ThemeActivity where ThemeStatus!=2 and enddate>getdate() ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetThemeActivtyByGuid(string Guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("select * from ShopNum1_ThemeActivity where Guid=@Guid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(), parms);
        }

        public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "id,name,starttime,endtime,finaltime,state,type,Discount,memloginId,shopName";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Product_Activity";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "starttime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectProductByThemeGuid(string themeGuid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@themeGuid";
            parms[0].Value = themeGuid;
            var builder = new StringBuilder();
            builder.Append("select * from ShopNum1_ThemeActivityProduct where ThemeGuid =@themeGuid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(), parms);
        }

        public DataTable SelectShopThemeActivty(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "Count(B.Guid)as ct ,A.Guid,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.StartDate,A.EndDate";
            paraName[3] = "@tablename";
            paraValue[3] =
                "dbo.ShopNum1_ThemeActivity A left join ShopNum1_ThemeActivityProduct B on A.Guid=B.ThemeGuid";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "A.CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectThemeActivty(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "Guid,ThemeTitle,StartDate,EndDate,ThemeImage,ThemeDescription,ThemeStatus,OrderID,CreateUser,CreateTime";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ThemeActivity";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectThemeActivtyProduct(string pagesize, string currentpage, string condition,
            string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "Guid,ThemeGuid,ProductGuid,ProductName,ProductImage,ProductPrice,ShopName,MemloginId,IsAudit,CreateTime";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ThemeActivityProduct";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectThemeProductByGuid(string pagesize, string currentpage, string condition,
            string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "A.Guid,A.ThemeTitle,A.ThemeImage,A.ThemeDesCription,A.ThemeStatus,B.ProductGuid,B.ProductName,B.ProductImage,B.ProductPrice,B.CreateTime,MemloginId,A.EndDate";
            paraName[3] = "@tablename";
            paraValue[3] =
                " dbo.ShopNum1_ThemeActivity A left join dbo.ShopNum1_ThemeActivityProduct B on A.Guid=B.ThemeGuid";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "B.CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdateActivity(ShopNum1_Product_Activity ShopNum1_Activity)
        {
            string str = "UPDATE ShopNum1_Product_Activity SET name='" + ShopNum1_Activity.Name + "',";
            if (!string.IsNullOrEmpty(ShopNum1_Activity.Pic))
            {
                str = str + "pic='" + ShopNum1_Activity.Pic + "',";
            }
            object obj2 = str;
            obj2 = string.Concat(new[] {obj2, "starttime='", ShopNum1_Activity.StartTime, "',"});
            obj2 = string.Concat(new[] {obj2, "endtime='", ShopNum1_Activity.EndTime, "',"});
            str = string.Concat(new[] {obj2, "finaltime='", ShopNum1_Activity.FinalTime, "',"});
            if (!string.IsNullOrEmpty(ShopNum1_Activity.Discount.ToString()))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "discount='", ShopNum1_Activity.Discount, "',"});
            }
            obj2 = str;
            obj2 = string.Concat(new[] {obj2, "type='", ShopNum1_Activity.Type, "'"});
            return DatabaseExcetue.RunNonQuery(string.Concat(new[] {obj2, " where id='", ShopNum1_Activity.Id, "'"}));
        }

        public int UpdateActivityState(string strId, string strState)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            parms[1].ParameterName = "@strState";
            parms[1].Value = strState;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Product_Activity SET State=@strState where id=@strId",parms);
        }

        public int UpdateThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE [ShopNum1_ThemeActivity] ");
            builder.Append(" SET ");
            builder.Append(" [ThemeTitle] = '" + shopNum1_ThemeActivity.ThemeTitle + "' ");
            builder.Append(" ,[StartDate] = '" + shopNum1_ThemeActivity.StartDate + "' ");
            builder.Append(" ,[EndDate] = '" + shopNum1_ThemeActivity.EndDate + "' ");
            builder.Append(" ,[ThemeImage] = '" + shopNum1_ThemeActivity.ThemeImage + "' ");
            builder.Append(" ,[ThemeDescription] = '" + shopNum1_ThemeActivity.ThemeDescription + "' ");
            builder.Append(" ,[ThemeStatus] = " + shopNum1_ThemeActivity.ThemeStatus + " ");
            builder.Append(" ,[OrderID] = " + shopNum1_ThemeActivity.OrderID + " ");
            builder.Append(" ,[CreateUser] = '" + shopNum1_ThemeActivity.CreateUser + "' ");
            builder.Append(" ,[CreateTime] = '" + shopNum1_ThemeActivity.CreateTime + "' ");
            builder.Append(" WHERE [Guid] = '" + shopNum1_ThemeActivity.Guid + "' ");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateThemeProductByThemeGuid(string ThemeGuid, string IsAudit)
        {

                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ThemeGuid";
            parms[0].Value = ThemeGuid;

            parms[1].ParameterName = "@IsAudit";
            parms[1].Value = IsAudit;

            var builder = new StringBuilder();
            builder.Append("Update ShopNum1_ThemeActivityProduct set IsAudit=@IsAudit where ThemeGuid=@ThemeGuid");

            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        public int UpdateThemeProductIsAudit(string Guid, string IsAudit)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");

            parms[1].ParameterName = "@IsAudit";
            parms[1].Value = IsAudit;
            var builder = new StringBuilder();
            builder.Append("Update ShopNum1_ThemeActivityProduct set IsAudit=@IsAudit where Guid=@Guid");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }
    }
}