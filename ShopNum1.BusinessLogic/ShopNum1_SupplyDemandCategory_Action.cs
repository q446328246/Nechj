using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SupplyDemandCategory_Action : IShopNum1_SupplyDemandCategory_Action
    {
        public int Add(ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory)
        {
            string str = method_0(shopNum1_SupplyDemandCategory.CategoryLevel, shopNum1_SupplyDemandCategory.FatherID);
            string str2 = string.Empty;
            str2 =
                "INSERT INTO shopNum1_SupplyDemandCategory(Name ,OrderID, CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Keywords  , Description  , Code  , IsDeleted   ) VALUES (  '" +
                Operator.FilterString(shopNum1_SupplyDemandCategory.Name) + "', ";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str2, " ", shopNum1_SupplyDemandCategory.OrderID, ",  ", shopNum1_SupplyDemandCategory.CategoryLevel
                , ",  ", shopNum1_SupplyDemandCategory.FatherID, ",  '", shopNum1_SupplyDemandCategory.Family,
                "',  '", shopNum1_SupplyDemandCategory.CreateUser, "', '", shopNum1_SupplyDemandCategory.CreateTime,
                "',  '", shopNum1_SupplyDemandCategory.ModifyUser, "' , '",
                shopNum1_SupplyDemandCategory.ModifyTime, "',  '", shopNum1_SupplyDemandCategory.Keywords, "',  '",
                shopNum1_SupplyDemandCategory.Description, "',  '", str, "',  ",
                shopNum1_SupplyDemandCategory.IsDeleted, " )"
            }));
        }

        public DataTable GetSupplyCategoryByID(string ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select ID,Name,OrderID,keywords,IsShow,description,code,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from shopNum1_SupplyDemandCategory where ID=@ID" ,parms);
        }

        public DataTable SearchtSupplyDemandCategory(int fatherID, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append(
                "select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code from shopNum1_SupplyDemandCategory where 1=1 ");
            if (fatherID != -1)
            {
                builder.Append("and FatherID=@fatherID" );
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted");
            }
            builder.Append(" ORDER BY OrderID DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Update(string guid, ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory)
        {
            string str = string.Empty;
            str = "UPDATE  shopNum1_SupplyDemandCategory SET  Name  ='" +
                  Operator.FilterString(shopNum1_SupplyDemandCategory.Name) + "',";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str, " OrderID  =", shopNum1_SupplyDemandCategory.OrderID, ", CategoryLevel  ='",
                shopNum1_SupplyDemandCategory.CategoryLevel, "', FatherID  ='",
                shopNum1_SupplyDemandCategory.FatherID, "', Family  ='", shopNum1_SupplyDemandCategory.Family,
                "', Keywords  ='", shopNum1_SupplyDemandCategory.Keywords, "', Description  ='",
                shopNum1_SupplyDemandCategory.Description, "', CreateUser  ='",
                shopNum1_SupplyDemandCategory.CreateUser, "', CreateTime  ='",
                shopNum1_SupplyDemandCategory.CreateTime, "', ModifyUser  ='",
                shopNum1_SupplyDemandCategory.ModifyUser, "', ModifyTime  ='",
                shopNum1_SupplyDemandCategory.ModifyTime, "', IsDeleted  ='",
                shopNum1_SupplyDemandCategory.IsDeleted, "'  WHERE id=", guid
            }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.RunNonQuery("    DELETE  ShopNum1_SupplyDemandCategory  WHERE  ID IN  (@guids)     ",parms);
        }

        public DataTable GetDataByCode(string Code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            return
                DatabaseExcetue.ReturnDataTable(string.Empty +
                                                "    SELECT * FROM  ShopNum1_SupplyDemandCategory  WHERE   Code =@Code  AND  IsDeleted=0 AND  IsShow=1           ",parms);
        }

        public DataTable GetDataByFatherID(string FatherID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@FatherID";
            parms[0].Value = FatherID;
            return
                DatabaseExcetue.ReturnDataTable(string.Empty +
                                                "    SELECT * FROM  ShopNum1_SupplyDemandCategory  WHERE   FatherID =@FatherID  AND  IsDeleted=0 AND  IsShow=1           ",parms);
        }

        private string method_0(int int_0, int int_1)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_1";
            parms[0].Value = int_1;
            string str = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append("select ID,Name,code from shopNum1_SupplyDemandCategory WHERE ID=@int_1");
                str = DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0]["code"].ToString();
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
            builder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = Max(Code) FROM shopNum1_SupplyDemandCategory WHERE LEN(Code)=3 ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        private string method_2(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,3) = '" +
                           string_0 + "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,3) = '" +
                string_0 + "'  ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("IF(LEN(@code) <> 3) ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_0 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        private string method_3(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE substring(Code,1,6) = '" +
                           string_0 + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,6) = '" +
                string_0 + "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_0 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        private string method_4(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(12) ");
            builder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE substring(Code,1,9) = '" +
                           string_0 + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT @code = Max(SUBSTRING(Code,10,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,9) = '" +
                string_0 + "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + string_0 + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }
    }
}