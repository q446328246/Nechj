using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_City_Action : IShopNum1_City_Action
    {
        public string TableName = "ShopNum1_City";

        public int Add(ShopNum1_City city)
        {
            string codeBylevel = GetCodeBylevel(Convert.ToInt32(city.CategoryLevel), city.FatherID);
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_City( \tCityName \t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , Operator.FilterString(city.CityName), "',  '", Operator.FilterString(city.ShortName), "',  ",
                city.CategoryLevel, ",  ", city.FatherID, ",  ", city.OrderID, ",  '",
                Operator.FilterString(city.Letter), "',  ", city.IsHot, ",  ", city.IsShow,
                ",  '", codeBylevel, "',  '", city.CreateUser, "', '", city.CreateTime, "',  '", city.ModifyUser,
                "' , '", city.ModifyTime, "',  ", 0, ")"
            }));
        }

        public DataTable CheckIsChilds(string Field, string TableName, string ID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT " + Field + " FROM " + TableName + "  WHERE fatherid='" + ID +
                                                "' UNION all  SELECT  " + Field + " FROM  " + TableName +
                                                "  WHERE fatherid in (SELECT ID FROM " + TableName +
                                                "  WHERE fatherid=@ID)",parms);
        }

        public int Delete(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            string strSql = "Delete from ShopNum1_City where ID in (@string_0)";
            try
            {
                DatabaseExcetue.RunNonQuery(strSql,parms);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetCategoryByParam(string param)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    ("select CityName, ID from ShopNum1_City,ShopNum1_Product where ShopNum1_City.IsShow = 1 and  fatherID in( select ID from ShopNum1_City where fatherID = 0) and " +
                     param +
                     "= 1 and ShopNum1_City.ID = ShopNum1_Product.ProductCategoryID Group by ShopNum1_City.CityName, ShopNum1_City.ID") +
                    "  ORDER BY OrderID ASC");
        }

        public string GetCfCode()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @AddressCode varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + ") = 0) ");
            builder.Append("SET @AddressCode = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @AddressCode = AddressCode FROM " + TableName +
                           " WHERE LEN(AddressCode)=3 Order BY ID DESC ");
            builder.Append("SET @AddressCode = @AddressCode + 1 ");
            builder.Append("WHILE (LEN(@AddressCode) < 3) ");
            builder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
            builder.Append("SELECT @AddressCode");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCmCode(string AddressCode)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @AddressCode varchar(12) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE substring(AddressCode,1,9) = '" +
                           AddressCode + "') = 0) ");
            builder.Append("SET @AddressCode = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,10,3) FROM " + TableName +
                           " WHERE SUBSTRING(AddressCode,1,9) = '" + AddressCode + "' Order BY ID DESC ");
            builder.Append("SET @AddressCode = @AddressCode + 1 ");
            builder.Append("WHILE (LEN(@AddressCode) < 3) ");
            builder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
            builder.Append("SELECT '" + AddressCode + "' + @AddressCode");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCodeBylevel(int level, int fatherID)
        {
            string addressCode = "0";
            if (level != 1)
            {
                var builder = new StringBuilder();
                builder.Append(
                    string.Concat(new object[]
                    {"select ID,CityName,AddressCode from ", TableName, " WHERE ID=", fatherID}));
                addressCode = DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0]["AddressCode"].ToString();
            }
            if (level == 1)
            {
                return GetCfCode();
            }
            if (level == 2)
            {
                return GetCsCode(addressCode);
            }
            if (level == 3)
            {
                return GetCtCode(addressCode);
            }
            return GetCmCode(addressCode);
        }

        public string GetCsCode(string AddressCode)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @AddressCode varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE SUBSTRING(AddressCode,1,3) = '" +
                           AddressCode + "') = 0) ");
            builder.Append("SET @AddressCode = '001' ELSE ");
            builder.Append("BEGIN SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,4,3) FROM " + TableName +
                           " WHERE SUBSTRING(AddressCode,1,3) = '" + AddressCode + "' Order BY ID DESC ");
            builder.Append("SET @AddressCode = @AddressCode + 1 ");
            builder.Append("IF(LEN(@AddressCode) <> 3) ");
            builder.Append("WHILE (LEN(@AddressCode) < 3) ");
            builder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
            builder.Append("SELECT '" + AddressCode + "' + @AddressCode");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCtCode(string AddressCode)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @AddressCode varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM " + TableName + " WHERE substring(AddressCode,1,6) = '" +
                           AddressCode + "') = 0) ");
            builder.Append("SET @AddressCode = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,7,3) FROM " + TableName +
                           " WHERE SUBSTRING(AddressCode,1,6) = '" + AddressCode + "' Order BY ID DESC ");
            builder.Append("SET @AddressCode = @AddressCode + 1 ");
            builder.Append("WHILE (LEN(@AddressCode) < 3) ");
            builder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
            builder.Append("SELECT '" + AddressCode + "' + @AddressCode");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetDispatchRegionName(string AddressCode)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@AddressCode";
            parms[0].Value = AddressCode;
            return
                DatabaseExcetue.ReturnDataTable(
                    ("SELECT distinct   \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City   WHERE 1=1 and IsShow=1 and IsDeleted=0  and AddressCode=@AddressCode") + "  ORDER BY OrderID ASC",parms);
        }

        public string GetNameByID(int int_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 And ID =@int_0",parms);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0]["CityName"].ToString();
            }
            return "";
        }

        public DataTable GetProductCategoryMeto(string strID)
        {
            string str = string.Empty;
            str =
                "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 and  IsShow=1  ";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                str = str + "And ID =" + Operator.FilterString(strID);
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY OrderID ASC");
        }

        public DataTable GetTableByID(int int_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 And ID =@int_0" + "  ORDER BY OrderID ASC",parms);
        }

        public DataTable IsHost(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            string str = string.Empty;
            str =
                "SELECT ID,CityName FROM ShopNum1_City WHERE ID IN (SELECT ID FROM ShopNum1_City WHERE 1=1 and  IsDeleted=0 and CategoryLevel=1 and IsShow=1 and IsHot=1)";
            return DatabaseExcetue.ReturnDataTable((str + "  and id=@string_0" ) + "  ORDER BY OrderID ASC",parms);
        }

        public DataTable Search(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City WHERE IsDeleted @isDeleted"+ " ORDER BY OrderID ASC",parms);
        }

        public DataTable Search(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  FatherID =@fatherID AND  IsDeleted =@isDeleted"+ " ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable Search(int fatherID, int isDeleted, int count)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            
            string str = string.Empty;
            if (count > 0)
            {
                str = "SELECT top " + count;
            }
            else
            {
                str = "SELECT ";
            }
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "\t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  IsShow=1 AND FatherID =@fatherID AND  IsDeleted =@isDeleted ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable Search2(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  IsShow = 1 AND FatherID =@fatherID AND  IsDeleted =@isDeleted  ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable Search2(string showCount, int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT  Top ", showCount,
                        "\tID\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City  WHERE  IsShow = 1 AND FatherID =@fatherID AND  IsDeleted =@isDeleted  ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable SearchCityByLetter(string Letter)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Letter";
            parms[0].Value = Letter;
            return
                DatabaseExcetue.ReturnDataTable(
                    ("SELECT distinct   \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City   WHERE 1=1 and IsShow=1 and IsDeleted=0 and CategoryLevel=1 and Letter=@Letter") + "  ORDER BY OrderID ASC", parms);
        }

        public DataTable SearchCityLetter()
        {
            string str = string.Empty;
            str =
                "SELECT distinct   \tLetter\t  FROM ShopNum1_City  WHERE 1=1 and IsShow=1 and IsDeleted=0 and CategoryLevel=1 ";
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY Letter ASC");
        }

        public DataTable SearchHotCity(string showCount)
        {
            return
                DatabaseExcetue.ReturnDataTable(("SELECT top " + showCount +
                                                 "\t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 and  IsDeleted=0 and CategoryLevel=1 and IsShow=1 and IsHot=1") +
                                                "  ORDER BY OrderID ASC");
        }

        public DataTable SearchInfoByID(string strID)
        {
            string str = string.Empty;
            str =
                "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 ";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                str = str + "And ID =" + Operator.FilterString(strID);
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY OrderID ASC");
        }

        public int Update(ShopNum1_City city)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_City   SET    CityName\t='", Operator.FilterString(city.CityName),
                "',    ShortName\t='", Operator.FilterString(city.ShortName), "', \tCategoryLevel\t=",
                city.CategoryLevel, ",\tFatherID\t=", city.FatherID, ",\tOrderID\t=", city.OrderID, ",\tLetter='",
                city.Letter, "' ,\tIsHot\t=", city.IsHot, ",\tIsShow\t=", city.IsShow,
                ",\tAddressCode='", city.AddressCode, "' ,\tModifyUser='", city.ModifyUser, "' ,\tModifyTime\t='",
                city.ModifyTime, "', \tIsDeleted =", city.IsDeleted, "   WHERE ID=", city.ID
            }));
        }

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_City") + 1);
        }
    }
}