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
    public class ShopNum1_ShopCategory_Action : IShopNum1_ShopCategory_Action
    {
        private static DataTable dt;

        public static DataTable ShopCategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "select ID,Name,Code,IsRecommend,OrderID,FatherID from ShopNum1_ShopCategory where IsDeleted=0 and IsShow=1 ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = null; }
        }

        public int Add(ShopNum1_ShopCategory shopCategory)
        {
            ShopCategoryTable = null;
            string str = method_0(shopCategory.CategoryLevel, shopCategory.FatherID);
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ShopCategory(  Name  , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted   ) VALUES (  '"
                , Operator.FilterString(shopCategory.Name), "',  '", Operator.FilterString(shopCategory.Keywords),
                "',  '", Operator.FilterString(shopCategory.Description), "',  ", shopCategory.OrderID, ",  ",
                shopCategory.IsShow, ",  ", shopCategory.CategoryLevel, ",  ", shopCategory.FatherID, ",  '",
                shopCategory.Family,
                "',  '", shopCategory.CreateUser, "', '", shopCategory.CreateTime, "',  '", shopCategory.ModifyUser,
                "' , '", shopCategory.ModifyTime, "',  '", str, "',  ", shopCategory.IsDeleted, " )"
            }));
        }

        public int Delete(string guids)
        {
            ShopCategoryTable = null;
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "delete from ShopNum1_ShopCategory  WHERE ID IN (" + guids + ") ";
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

        public DataTable GetList(string categoryID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@categoryID";
            parms[0].Value = categoryID;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[ID],");
            builder.Append("[Name],");
            builder.Append("[Code]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_ShopCategory");
            builder.Append(" WHERE FatherID=@categoryID  AND  IsDeleted=0   ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetShopCategoryByID(string ID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select ID,Name,Keywords,Description,OrderID,IsShow,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_ShopCategory where ID=@ID",parms);
        }

        public DataTable GetShopCategoryCount(string showcount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ShowCount";
            paraValue[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CategoryCount", paraName, paraValue);
        }

        public DataTable GetShopCategoryMeto(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategoryMeto", paraName, paraValue);
        }

        public DataTable GetShopCategoryName()
        {
            string strSql = string.Empty;
            strSql = "select ID,Name,Code from ShopNum1_ShopCategory ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetWeiXinShopCategoryCount(string showcount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ShowCount";
            paraValue[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopWx_CategoryCountV82", paraName, paraValue);
        }

        public DataTable Search(int fatherID, int isDeleted, string showCount)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            
            string str = string.Empty;
            str =
                string.Concat(new object[]
                {
                    "SELECT  TOP ", showCount,
                    "\tID\t,  Name  , Code , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , IsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =@isDeleted"
                    
                });
            if (!string.IsNullOrEmpty(fatherID.ToString()))
            {
                str = str + " AND FatherID =@fatherID";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID ASC",parms);
        }

        public DataTable SearchShopCategory(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append(
                "select ID,Name,Keywords,Description,OrderID,IsShow,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_ShopCategory where 1=1 and CategoryLevel<3 ");
            builder.Append("and FatherID=@fatherID" );
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted" );
            }
            builder.Append(" ORDER BY OrderID DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Update(string guid, ShopNum1_ShopCategory shopCategory)
        {
            ShopCategoryTable = null;
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ShopCategory SET  Name  ='", Operator.FilterString(shopCategory.Name),
                "', Keywords  ='", Operator.FilterString(shopCategory.Keywords), "', Description  ='",
                Operator.FilterString(shopCategory.Description), "', OrderID  =", shopCategory.OrderID,
                ", IsShow  ='", shopCategory.IsShow, "', CategoryLevel  ='", shopCategory.CategoryLevel,
                "', FatherID  ='", shopCategory.FatherID, "', Family  ='", shopCategory.Family,
                "', CreateUser  ='", shopCategory.CreateUser, "', CreateTime  ='", shopCategory.CreateTime,
                "', ModifyUser  ='", shopCategory.ModifyUser, "', ModifyTime  ='", shopCategory.ModifyTime,
                "', IsDeleted  ='", shopCategory.IsDeleted, "' WHERE id=", guid
            }));
        }

        public int DeleteTypeC(string strID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            return DatabaseExcetue.RunNonQuery(string.Format("delete from ShopNum1_ShopCategory where id=@strID", parms));
        }

        public DataTable GetByCode(string Code)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            return
                DatabaseExcetue.ReturnDataTable(((string.Empty + "  SELECT * FROM  ShopNum1_ShopCategory  ") +
                                                 "  WHERE    Code=@Code       "),parms);
        }

        public string GetCfCode()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = Max(Code) FROM ShopNum1_ShopCategory WHERE LEN(Code)=3 ");
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE substring(Code,1,9) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,9) = '" +
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,3) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,3) = '" +
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE substring(Code,1,6) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,6) = '" +
                code + "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetShopIsCategoryByCategoryID(string ShopCategoryID, string showcount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showcount);
            builder.Append(" [Guid],[Name],ShopName,ShopUrl,Banner,ShopID ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_ShopInfo");
            builder.Append(" WHERE 0=0");
            if (Operator.FormatToEmpty(ShopCategoryID) != string.Empty)
            {
                builder.Append(" AND ShopCategoryID  like  '" + ShopCategoryID + "%'");
            }
            builder.Append(" ORDER BY ShopID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int MaxOrderId()
        {
            return DatabaseExcetue.ReturnMaxID("orderid", "ShopNum1_ShopCategory");
        }

        private string method_0(int int_0, int int_1)
        {
            string code = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append("select ID,Name,code from ShopNum1_ShopCategory WHERE ID=" + int_1);
                code = DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0]["code"].ToString();
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

        public DataTable SearchShopIsCategoryID(int fatherID, int isDeleted, string showCount)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string str = string.Empty;
            str =
                string.Concat(new object[]
                {
                    "SELECT  TOP ", showCount,
                    "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =@isDeleted"
                    
                });
            if (!string.IsNullOrEmpty(fatherID.ToString()))
            {
                str = str + " AND FatherID =@fatherID" ;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID ASC",parms);
        }

        public DataTable SearchtProductCategory(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append(
                "select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code,isshow,(select top 1 id from  ShopNum1_ShopCategory where fatherid=''+t.id+'' and isDeleted='0')v,(select TOP 1 id from ShopNum1_ShopInfo where shopcategoryid=''+t.id+'')m from ShopNum1_ShopCategory t where 1=1 ");
            if (fatherID != -1)
            {
                builder.Append("and FatherID=@fatherID" );
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted" );
            }
            builder.Append(" ORDER BY OrderID DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchtTypeId(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append("select ID from ShopNum1_ShopCategory t where 1=1 ");
            if (fatherID != -1)
            {
                builder.Append("and FatherID=@fatherID" );
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted" );
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int UpdateIsshow(string strIsshow, string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strIsshow";
            parms[0].Value = strIsshow;
            parms[1].ParameterName = "@strId";
            parms[1].Value = strId;
            return
                DatabaseExcetue.RunNonQuery(string.Format(
                    "update ShopNum1_ShopCategory set isshow=@strIsshow where id=@strId", parms));
        }

        public int UpdateOrderName(string strID, string strName, string strOrderId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            parms[1].ParameterName = "@strName";
            parms[1].Value = strName;
            parms[2].ParameterName = "@strOrderId";
            parms[2].Value = strOrderId;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_ShopCategory set orderid=@strOrderId,name=@strName where id=@strID", parms));
        }
    }
}