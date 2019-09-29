using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ScoreProductCategory_Action : IShopNum1_ScoreProductCategory_Action
    {
        public int Add(ShopNum1_ScoreProductCategory ScoreProductCategory)
        {
            int num = Convert.ToInt32(ScoreProductCategory.CategoryLevel);
            string str = method_0(num, ScoreProductCategory.FatherID);
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO  ShopNum1_ScoreProductCategory  (  Name  , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , IsDeleted  , Code   ) VALUES (  '"
                , ScoreProductCategory.Name, "',  '", ScoreProductCategory.Keywords, "',  '",
                ScoreProductCategory.Description, "',  '", ScoreProductCategory.OrderID, "',  '",
                ScoreProductCategory.IsShow, "',  '", ScoreProductCategory.CategoryLevel, "',  '",
                ScoreProductCategory.FatherID, "',  '", ScoreProductCategory.Family,
                "',  '", ScoreProductCategory.CreateUser, "', '", ScoreProductCategory.CreateTime, "',  '",
                ScoreProductCategory.ModifyUser, "' , '", ScoreProductCategory.ModifyTime, "',  '",
                ScoreProductCategory.IsDeleted, "',  '", str, "'  )"
            }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids.Replace("'", "");
            
            return DatabaseExcetue.RunNonQuery("  delete ShopNum1_ScoreProductCategory  where ID=@guids",parms);
        }

        public DataTable GetDataInfo(int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@IsDeleted";
            parms[0].Value = IsDeleted;
            return
                DatabaseExcetue.ReturnDataTable("   select * from  ShopNum1_ScoreProductCategory  where  IsDeleted=@IsDeleted",parms);
        }

        public int Update(ShopNum1_ScoreProductCategory ScoreProductCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ScoreProductCategory     SET      Name\t='", ScoreProductCategory.Name,
                "', \t    Keywords\t='", ScoreProductCategory.Keywords, "',     Description\t='",
                ScoreProductCategory.Description, "',\t    OrderID\t='", ScoreProductCategory.OrderID,
                "', \tIsShow\t=", ScoreProductCategory.IsShow, ",\t    CategoryLevel\t=",
                ScoreProductCategory.CategoryLevel, ",  \tFatherID\t=", ScoreProductCategory.FatherID,
                ", \tFamily\t='", ScoreProductCategory.Family,
                "', \tModifyUser='", ScoreProductCategory.ModifyUser, "' , \tModifyTime\t='",
                ScoreProductCategory.ModifyTime, "', \t    IsDeleted =", ScoreProductCategory.IsDeleted,
                "      WHERE ID=", ScoreProductCategory.ID
            }));
        }

        public DataTable GetCategory(string fatherID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            string str = string.Empty;
            str = "   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  IsDeleted=0   ";
            if (!string.IsNullOrEmpty(fatherID))
            {
                str = str + "   AND  FatherID=@fatherID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "   ORDER BY  OrderID  ASC      ",parms);
        }

        public string GetCfCode()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ScoreProductCategory) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = Max(Code) FROM   ShopNum1_ScoreProductCategory   WHERE LEN(Code)=3 ");
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
            builder.Append("IF((SELECT COUNT(1) FROM  ShopNum1_ScoreProductCategory   WHERE substring(Code,1,9) = '" +
                           code + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,9) = '" +
                code + "' ");
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
            builder.Append(
                "IF((SELECT COUNT(1) FROM    ShopNum1_ScoreProductCategory     WHERE SUBSTRING(Code,1,3) = '" + code +
                "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,3) = '" +
                code + "'  ");
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
            builder.Append("IF((SELECT COUNT(1) FROM  ShopNum1_ScoreProductCategory   WHERE substring(Code,1,6) = '" +
                           code + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,6) = '" +
                code + "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetDataInfoByCode(string Code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            return
                DatabaseExcetue.ReturnDataTable(
                    "   SELECT  * FROM       ShopNum1_ScoreProductCategory        WHERE   Code=@Code   ",parms);
        }

        public DataTable GetProductCategoryByID(string ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable("   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  ID=@ID   ",parms);
        }

        private string method_0(int int_0, int int_1)
        {
            string code = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append("select ID,Name,Code from  ShopNum1_ScoreProductCategory   WHERE ID=" + int_1);
                code = DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0]["Code"].ToString();
            }
            if (int_0 == 1)
            {
                return GetCfCode();
            }
            if (int_0 == 2)
            {
                return GetCsCode(code);
            }
            if (int_0 == 3)
            {
                return GetCtCode(code);
            }
            return GetCmCode(code);
        }

        public DataTable SearchtProductCategory(int FatherID, int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@FatherID";
            parms[0].Value = FatherID;
            parms[1].ParameterName = "@IsDeleted";
            parms[1].Value = IsDeleted;
            string str = string.Empty;
            str = "   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  IsDeleted=@IsDeleted  ";
            if (FatherID != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, "   AND  FatherID=@FatherID"});
            }
            return DatabaseExcetue.ReturnDataTable(str + "   ORDER BY  OrderID  ASC      ",parms);
        }
    }
}