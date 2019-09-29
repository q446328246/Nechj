using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Region_Action : IShopNum1_Region_Action
    {
        public string TableName { get; set; }

        public int Add(ShopNum1_Region shopNum1_Region)
        {
            string str = method_0(shopNum1_Region.CategoryLevel, shopNum1_Region.FatherID);
            string str2 = string.Empty;
            str2 =
                "INSERT INTO ShopNum1_Region(Name ,OrderID, CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted   ) VALUES (  '" +
                Operator.FilterString(shopNum1_Region.Name) + "', ";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str2, " ", shopNum1_Region.OrderID, ",  ", shopNum1_Region.CategoryLevel, ",  ",
                shopNum1_Region.FatherID, ",  '", shopNum1_Region.Family, "',  '", shopNum1_Region.CreateUser,
                "', '", shopNum1_Region.CreateTime, "',  '", shopNum1_Region.ModifyUser, "' , '",
                shopNum1_Region.ModifyTime, "',  '", str, "',  ", shopNum1_Region.IsDeleted, " )"
            }));
        }

        public DataTable GetRegionCategoryByID(string ID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select ID,Name,OrderID,code,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_Region where ID=@ID",parms);
        }

        public DataTable SearchByCategoryLevel(string lever, string showcount)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@lever";
            parms[0].Value = lever;
            string str = "SELECT ";
            if (!string.IsNullOrEmpty(showcount))
            {
                str = str + " TOP " + showcount;
            }
            str = str + " ID,NAME,CODE FROM ShopNum1_Region WHERE 1=1 AND IsDeleted=0  ";
            if (!string.IsNullOrEmpty(lever.Replace("'", "")))
            {
                str = str + " AND CategoryLevel=@lever" ;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID ASC ",parms);
        }

        public DataTable SearchtRegionCategory(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append(
                "select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code from ShopNum1_Region where 1=1 ");
            if (fatherID != -1)
            {
                builder.Append("and FatherID=@fatherID" );
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted" );
            }
            builder.Append(" ORDER BY OrderID ASC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Update(string guid, ShopNum1_Region shopNum1_Region)
        {
            string str = string.Empty;
            str = "UPDATE  ShopNum1_Region SET  Name  ='" + Operator.FilterString(shopNum1_Region.Name) + "',";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str, " OrderID  =", shopNum1_Region.OrderID, ", CategoryLevel  ='", shopNum1_Region.CategoryLevel,
                "', FatherID  ='", shopNum1_Region.FatherID, "', Family  ='", shopNum1_Region.Family,
                "', CreateUser  ='", shopNum1_Region.CreateUser, "', CreateTime  ='", shopNum1_Region.CreateTime,
                "', ModifyUser  ='", shopNum1_Region.ModifyUser, "', ModifyTime  ='",
                shopNum1_Region.ModifyTime, "', IsDeleted  ='", shopNum1_Region.IsDeleted, "'  WHERE id=", guid
            }));
        }

        public DataTable GetRegionByCode(string Code)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            return DatabaseExcetue.ReturnDataTable("select *  from ShopNum1_Region where Code=@Code",parms);
        }

        private string method_0(int int_0, int int_1)
        {
            string str = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append("select ID,Name,code from ShopNum1_Region WHERE ID=" + int_1);
                str = DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0]["code"].ToString();
            }
            if (int_0 == 1)
            {
                return method_1();
            }
            if (int_0 == 2)
            {
                return method_2(str);
            }
            if (int_0 == 3)
            {
                return method_3(str);
            }
            return method_4(str);
        }

        private string method_1()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = Max(Code) FROM ShopNum1_Region WHERE LEN(Code)=3 ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        private string method_2(string string_1)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_1";
            parms[0].Value = string_1;
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,3) = @string_1) = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,3) = '" +
                string_1 + "'  ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("IF(LEN(@code) <> 3) ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_1 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0][0].ToString();
        }

        private string method_3(string string_1)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE substring(Code,1,6) = '" + string_1 +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,6) = '" + string_1 +
                "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_1 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        private string method_4(string string_1)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_1";
            parms[0].Value = string_1;
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(12) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE substring(Code,1,9) = @string_1) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,9) = @string_1 ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_1 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0][0].ToString();
        }
    }
}