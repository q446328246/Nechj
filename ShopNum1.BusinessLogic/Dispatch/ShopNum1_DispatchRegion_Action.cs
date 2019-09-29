using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_DispatchRegion_Action : IShopNum1_DispatchRegion_Action
    {
        public string TableName { get; set; }

        public int Add(ShopNum1_DispatchRegion dispatchRegion)
        {
            string str = a(dispatchRegion.CategoryLevel.Value, dispatchRegion.FatherID.Value);
            string str2 = string.Empty;
            str2 = ("INSERT INTO " + TableName + "(  Name  ,") +
                   " OrderID  , CategoryLevel  , FatherID  , Family  , Remark  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code   ) VALUES (  '" +
                   Operator.FilterString(dispatchRegion.Name) + "', ";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str2, " ", dispatchRegion.OrderID, ",  ", dispatchRegion.CategoryLevel, ",  ",
                dispatchRegion.FatherID, ",  '", dispatchRegion.Family, "',  '", dispatchRegion.Remark, "',  '",
                dispatchRegion.CreateUser, "', '", dispatchRegion.CreateTime, "',  '",
                dispatchRegion.ModifyUser, "' , '", dispatchRegion.ModifyTime, "',  '", str, "')"
            }));
        }

        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "delete from " + TableName + "  WHERE ID IN (" + guids + ") ";
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

        public int GetDispatchCount(int fatherID, int isDeleted)
        {
            string format = "select count(*) as TotalCount from {0} where 1=1 and FatherID={1}";
            return
                Convert.ToInt32(
                    DatabaseExcetue.ReturnDataTable(string.Format(format, TableName, fatherID)).Rows[0]["TotalCount"]);
        }

        public DataTable GetDispatchRegionByID(string ID)
        {
            string str = string.Empty;
            str = "select ID,Name,";
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                "OrderID,CategoryLevel,FatherID,Family,Remark,CreateUser,CreateTime,ModifyUser,ModifyTime from " +
                                                TableName + " where ID=" + ID);
        }

        public DataTable GetDispatchRegionCode(string code)
        {
            return
                DatabaseExcetue.ReturnDataTable(("select ID,Name,Code from " + TableName) + " WHERE Code in (" + code +
                                                ")");
        }

        public DataTable GetDispatchRegionName()
        {
            return DatabaseExcetue.ReturnDataTable("select ID,Name,Code from " + TableName);
        }

        public DataTable GetDispatchRegionName(string fatherID)
        {
            return
                DatabaseExcetue.ReturnDataTable(("select ID,Name,Code,OrderID,CategoryLevel from " + TableName) +
                                                " WHERE FatherID=" + fatherID);
        }

        public DataTable GetDispatchRegionName(string fatherID, string agentLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(("select ID,Name,Code from " + TableName) + " WHERE FatherID=" +
                                                fatherID);
        }

        public DataTable Search(int IsDeleted)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Guid, Name, OrderID,Memo,CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_DispatchRegion WHERE (IsDeleted = " +
                    IsDeleted + ") Order By OrderID Desc");
        }

        public DataTable SearchtDispatchRegion(int fatherID, int isDeleted)
        {
            var builder = new StringBuilder();
            builder.Append(
                "select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,code from " +
                TableName + " where 1=1 ");
            builder.Append("and FatherID=" + fatherID);
            builder.Append(" ORDER BY OrderID ASC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(string guid, ShopNum1_DispatchRegion dispatchRegion)
        {
            string str = string.Empty;
            str = "UPDATE  " + TableName + " SET  Name  ='" + Operator.FilterString(dispatchRegion.Name) + "',";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str, " OrderID  =", dispatchRegion.OrderID, ", CategoryLevel  ='", dispatchRegion.CategoryLevel,
                "', FatherID  ='", dispatchRegion.FatherID, "', Family  ='", dispatchRegion.Family, "', Remark  ='",
                Operator.FilterString(dispatchRegion.Remark), "', CreateUser  ='", dispatchRegion.CreateUser,
                "', CreateTime  ='", dispatchRegion.CreateTime, "', ModifyUser  ='",
                dispatchRegion.ModifyUser, "', ModifyTime  ='", dispatchRegion.ModifyTime, "'  WHERE id=", guid
            }));
        }

        private string a(int A_0, int A_1)
        {
            string code = "0";
            if (A_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append(string.Concat(new object[] {"select ID,Name,code from ", TableName, " WHERE ID=", A_1}));
                code = DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0]["code"].ToString();
            }
            if (A_0 == 1)
            {
                return GetCfCode();
            }
            if (A_0 == 2)
            {
                return GetCsCode(code);
            }
            if (A_0 == 3)
            {
                return GetCtCode(code);
            }
            return GetCmCode(code);
        }

        public int Add(ShopNum1_DispatchRegion dispatchRegion, string shop)
        {
            string str = a(dispatchRegion.CategoryLevel.Value, dispatchRegion.FatherID.Value);
            string str2 = string.Empty;
            str2 = "INSERT INTO " + TableName +
                   "(  Name  , Keywords  , Description  , IsShow  , OrderID  , CategoryLevel  , FatherID  , Family  , Code  , MemLoginID   ) VALUES (  '" +
                   Operator.FilterString(dispatchRegion.Name) + "', ";
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        str2, " ", dispatchRegion.OrderID, ",  ", dispatchRegion.CategoryLevel, ",  ",
                        dispatchRegion.FatherID, ",  '", dispatchRegion.Family, "',  '", str, "', )"
                    }));
        }

        public string GetCfCode()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + ") = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @code = Code FROM " + TableName + " WHERE LEN(Code)=3 Order BY ID DESC ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCmCode(string code)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(12) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE substring(Code,1,9) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @code = SUBSTRING(Code,10,3) FROM " + TableName +
                           " WHERE SUBSTRING(Code,1,9) = '" + code + "' Order BY ID DESC ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCsCode(string code)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE SUBSTRING(Code,1,3) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append("BEGIN SELECT TOP 1 @code = SUBSTRING(Code,4,3) FROM " + TableName +
                           " WHERE SUBSTRING(Code,1,3) = '" + code + "' Order BY ID DESC ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("IF(LEN(@code) <> 3) ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCtCode(string code)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE substring(Code,1,6) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @code = SUBSTRING(Code,7,3) FROM " + TableName +
                           " WHERE SUBSTRING(Code,1,6) = '" + code + "' Order BY ID DESC ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetDispatchRegionCode(string code, string agentLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(("select ID,Name,Code from " + TableName) + " WHERE Code='" + code + "'");
        }

        public int Update(string guid, ShopNum1_DispatchRegion dispatchRegion, string shop)
        {
            string str = string.Empty;
            str = "UPDATE  " + TableName + " SET  Name  ='" + Operator.FilterString(dispatchRegion.Name) + "',";
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        str, " OrderID  =", dispatchRegion.OrderID, ", CategoryLevel  ='",
                        dispatchRegion.CategoryLevel
                        , "', FatherID  ='", dispatchRegion.FatherID, "', Family  ='", dispatchRegion.Family,
                        "'  WHERE id=", guid
                    }));
        }
    }
}