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
    public class ShopNum1_ProductCategory_Action : IShopNum1_ProductCategory_Action
    {
        private static DataTable dt;

        public static DataTable ProductCategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "SELECT ID,Name,Code,FatherID,OrderID FROM ShopNum1_ProductCategory WHERE IsShow = 1 AND IsDeleted = 0 ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = value; }
        }

        public string TableName { get; set; }

        public int Add(ShopNum1_ProductCategory shopNum1_ProductCategory)
        {
            string str = method_0(shopNum1_ProductCategory.CategoryLevel, shopNum1_ProductCategory.FatherID);
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format(
                        "INSERT INTO ShopNum1_ProductCategory(Name,OrderID,CategoryLevel,FatherID,CreateUser,CreateTime,\r\n            ModifyUser,ModifyTime,Code,IsDeleted,CategoryTypeName,CategoryType)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',\r\n            '{11}')",
                        new object[]
                        {
                            shopNum1_ProductCategory.Name, shopNum1_ProductCategory.OrderID,
                            shopNum1_ProductCategory.CreateUser, shopNum1_ProductCategory.CreateTime,
                            shopNum1_ProductCategory.ModifyUser, shopNum1_ProductCategory.ModifyTime, str,
                            shopNum1_ProductCategory.IsDeleted, shopNum1_ProductCategory.CategoryTypeName,
                            shopNum1_ProductCategory.CategoryType
                        }));
        }

        public int AddList(List<ShopNum1_ProductCategory> list_ProductCategory)
        {
            var sqlList = new List<string>();
            if ((list_ProductCategory != null) && (list_ProductCategory.Count > 0))
            {
                for (int i = 0; i < list_ProductCategory.Count; i++)
                {
                    string str = method_0(list_ProductCategory[i].CategoryLevel, list_ProductCategory[i].FatherID);
                    string item = string.Empty;
                    item = "INSERT INTO ShopNum1_ProductCategory(  Name  ,";
                    item = item +
                           " OrderID  , Keywords  , Description  , CategoryLevel  , FatherID  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted , logoimg,   CategoryType ,  IsShow ,  CategoryTypeName    ) VALUES (  '" +
                           Operator.FilterString(list_ProductCategory[i].Name) + "', ";
                    item = string.Concat(new object[]
                    {
                        item, " ", list_ProductCategory[i].OrderID, ",  '", list_ProductCategory[i].Keywords,
                        "',  '", list_ProductCategory[i].Description, "',  ", list_ProductCategory[i].CategoryLevel,
                        ",  ", list_ProductCategory[i].FatherID, ",  '", list_ProductCategory[i].CreateUser, "', '",
                        list_ProductCategory[i].CreateTime, "',  '",
                        list_ProductCategory[i].ModifyUser, "' , '", list_ProductCategory[i].ModifyTime, "',  '",
                        str, "',  ", list_ProductCategory[i].IsDeleted, ",  '", list_ProductCategory[i].logoimg,
                        " ', '", list_ProductCategory[i].CategoryType, " ', '", list_ProductCategory[i].IsShow,
                        " ', '", list_ProductCategory[i].CategoryTypeName, " ')"
                    }) + "  SELECT  @@IDENTITY AS 'Identity'";
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            if (DatabaseExcetue.CheckExists("select id from ShopNum1_ProductCategory WHERE FATHERID IN(" + guids + ") "))
            {
                return 2;
            }
            if (
                DatabaseExcetue.ReturnDataTable(
                    "select count(*) from ShopNum1_Shop_Product where ProductCategoryCode in(select code from ShopNum1_ProductCategory where id in(" +
                    guids + "))").Rows[0][0].ToString() != "0")
            {
                return 3;
            }
            item = "delete from ShopNum1_ProductCategory  WHERE ID IN (" + guids + ") ";
            sqlList.Add(item);
            DatabaseExcetue.RunTransactionSql(sqlList);
            return 1;
        }

        public int DeleteTypeC(string strID)
        {
            return
                DatabaseExcetue.RunNonQuery(string.Format("delete from  ShopNum1_ProductCategory where id in({0})",
                    strID));
        }

        public DataTable dt_GetScale(string strCode)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strCode";
            parms[0].Value = strCode;
            return
                DatabaseExcetue.ReturnDataTable("select id,Scale,IsOpen from ShopNum1_productcategory where code=@strCode",parms);
        }

        public DataTable GetCategory(string FatherID)
        {
            string str = "SELECT ID,Name,Code,categoryType FROM ShopNum1_ProductCategory where 1=1 ";
            if (FatherID != "0")
            {
                object obj2 = str;
                str =
                    string.Concat(new[]
                    {
                        obj2, " and Code like '", FatherID, "%' and Code!='", FatherID, "' and len(code)=",
                        FatherID.Length + 3
                    });
            }
            else if (FatherID == "0")
            {
                str = str + " and fatherid=0 ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " and IsShow = 1  and isdeleted=0 ORDER BY OrderID asc");
        }

        public DataTable GetCategoryBycount(string FatherID, string ShowCountOne)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@FatherID";
            parms[0].Value = FatherID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT Top  " + ShowCountOne +
                                                "  ID,Name,Code FROM ShopNum1_ProductCategory WHERE FatherID = @FatherID AND IsShow = 1 ORDER BY OrderID DESC",parms);
        }

        public DataTable GetCategoryTypeByCategoryID(string categoryid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@categoryid";
            paraValue[0] = categoryid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategoryTypeByCategoryID", paraName,
                paraValue);
        }

        public DataTable GetProductCategory(string fatherid, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherid;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategory", paraName, paraValue);
        }

        public DataTable GetProductCategoryByID(string ID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            string str = string.Empty;
            str = "select ID,Name,";
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                "OrderID,CategoryTypeName,CategoryType,code,CategoryLevel,FatherID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,Keywords,Description,IsShow,logoimg from ShopNum1_ProductCategory where IsDeleted=0 AND  ID=@ID order by orderid asc",parms);
        }

        public DataTable GetProductCategoryCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryCode", paraName,
                paraValue);
        }

        public DataTable GetProductCategoryCodeByName(string name)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@name";
            parms[0].Value = name;
            return
                DatabaseExcetue.ReturnDataTable("SELECT Code From ShopNum1_ProductCategory WHERE Name= @name  ORDER BY OrderID ASC",parms);
        }

        public DataTable GetProductCategoryMeto(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryMeto", paraName,
                paraValue);
        }

        public DataTable GetProductCategoryName()
        {
            string strSql = string.Empty;
            strSql = "select ID,Name,Code from ShopNum1_ProductCategory order by orderid asc";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetProductCategoryName(string fatherID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            string str = string.Empty;
            str = "select ID,Name,Code from ShopNum1_ProductCategory";
            return DatabaseExcetue.ReturnDataTable(str + " WHERE FatherID=@fatherID" ,parms);
        }

        public DataTable GetTwoOverType(int fatherId, string strTopCount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherId.ToString();
            paraName[1] = "@showCount";
            paraValue[1] = strTopCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetTwoOverType_V82", paraName, paraValue);
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
                        "SELECT top 30 \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tCategoryType\t, \tCategoryTypeName\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ProductCategory  WHERE FatherID =@fatherID AND  IsDeleted =@isDeleted and IsShow=1 ORDER BY OrderID ASC"
                    }),parms);
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
                    "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCategoryType\t, \tCategoryTypeName\t, \tCode\t, \tIsDeleted,logoimg   FROM ShopNum1_ProductCategory  WHERE 1 =1 And IsShow=1  AND  IsDeleted =@isDeleted"
                    
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
                "select ID,Name,OrderID,CategoryLevel,CategoryTypeName,CategoryType,FatherID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code,isshow,(select top 1 id from  ShopNum1_ProductCategory where fatherid=''+t.id+'' and isDeleted='0')v,(select top 1 id from shopnum1_shop_product where productcategorycode like ''+t.code+'%' and isdeleted='0')m  from ShopNum1_ProductCategory as t where 1=1 ");
            if (fatherID != -1)
            {
                builder.Append("and FatherID=@fatherID" );
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                builder.Append(" and isDeleted=@isDeleted" );
            }
            builder.Append(" ORDER BY OrderID asc ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchtTwoProductCategory(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append("select ID,Name,CategoryLevel from ShopNum1_ProductCategory as t where 1=1 ");
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

        public string strVScale(string strProductGuId)
        {
            return
                DatabaseExcetue.ReturnString(
                    "select cast(isnull(Scale,0) as varchar(10))+'|'+cast(isnull(IsOpen,0) as varchar(10)) from ShopNum1_ProductCategory where code in(select substring(productcategoryCode,1,3) from shopnum1_shop_product where guid='" +
                    strProductGuId + "')");
        }

        public int Update(string guid, ShopNum1_ProductCategory shopNum1_ProductCategory)
        {
            string str = string.Empty;
            str = "UPDATE  ShopNum1_ProductCategory SET  Name  ='" +
                  Operator.FilterString(shopNum1_ProductCategory.Name) + "',";
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                str, " OrderID  =", shopNum1_ProductCategory.OrderID, ", CategoryTypeName  ='",
                shopNum1_ProductCategory.CategoryTypeName, "', CategoryType  ='",
                shopNum1_ProductCategory.CategoryType, "', CategoryLevel  ='",
                shopNum1_ProductCategory.CategoryLevel, "', Description  ='", shopNum1_ProductCategory.Description,
                "', Keywords  ='", shopNum1_ProductCategory.Keywords, "', CreateUser  ='",
                shopNum1_ProductCategory.CreateUser, "', CreateTime  ='",
                shopNum1_ProductCategory.CreateTime, "', IsShow  ='", shopNum1_ProductCategory.IsShow,
                "', ModifyUser  ='", shopNum1_ProductCategory.ModifyUser, "', ModifyTime  ='",
                shopNum1_ProductCategory.ModifyTime, "', IsDeleted  ='", shopNum1_ProductCategory.IsDeleted,
                "',  logoimg  ='", shopNum1_ProductCategory.logoimg, "'  WHERE id=", guid
            }));
        }

        public int Update_Scale(string strCode, string strScale, string strIsOpen)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@strCode";
            parms[0].Value = strCode;
            parms[1].ParameterName = "@strScale";
            parms[1].Value = strScale;
            parms[2].ParameterName = "@strIsOpen";
            parms[2].Value = strIsOpen;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_productcategory set Scale=@strScale,IsOpen=@strIsOpen from ShopNum1_productcategory where code=@strCode",parms);
        }

        public int UpdateCatrgoryInfoCategory(ShopNum1_Category shopNum1_Category)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_Category SET  Name  ='", Operator.FilterString(shopNum1_Category.Name),
                        "', Keywords  ='", Operator.FilterString(shopNum1_Category.Keywords), "', Description  ='",
                        Operator.FilterString(shopNum1_Category.Description), "', ModifyUser  ='",
                        Operator.FilterString(shopNum1_Category.ModifyUser), "', ModifyTime  ='",
                        Operator.FilterString(shopNum1_Category.ModifyTime), "', IsShow =", shopNum1_Category.IsShow
                        , ", OrderID=", shopNum1_Category.OrderID, "where ID=", shopNum1_Category.ID
                    }));
        }

        public object Add1(ShopNum1_ProductCategory shopNum1_ProductCategory)
        {
            string str = method_0(shopNum1_ProductCategory.CategoryLevel, shopNum1_ProductCategory.FatherID);
            string str2 = string.Empty;
            str2 = "INSERT INTO ShopNum1_ProductCategory(  Name  ,";
            str2 = str2 +
                   " OrderID  , Keywords  , Description  , CategoryLevel  , FatherID  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted , logoimg,   CategoryType ,  IsShow ,  CategoryTypeName    ) VALUES (  '" +
                   Operator.FilterString(shopNum1_ProductCategory.Name) + "', ";
            return DatabaseExcetue.ReturnObject(string.Concat(new object[]
            {
                str2, " ", shopNum1_ProductCategory.OrderID, ",  '", shopNum1_ProductCategory.Keywords, "',  '",
                shopNum1_ProductCategory.Description, "',  ", shopNum1_ProductCategory.CategoryLevel, ",  ",
                shopNum1_ProductCategory.FatherID, ",  '", shopNum1_ProductCategory.CreateUser, "', '",
                shopNum1_ProductCategory.CreateTime, "',  '",
                shopNum1_ProductCategory.ModifyUser, "' , '", shopNum1_ProductCategory.ModifyTime, "',  '", str,
                "',  ", shopNum1_ProductCategory.IsDeleted, ",  '", shopNum1_ProductCategory.logoimg, " ', '",
                shopNum1_ProductCategory.CategoryType, " ', '", shopNum1_ProductCategory.IsShow, " ', '",
                shopNum1_ProductCategory.CategoryTypeName, " ')"
            }) + "  SELECT  @@IDENTITY AS 'Identity'");
        }

        public string GetCfCode()
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory) = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = Max(Code) FROM ShopNum1_ProductCategory WHERE LEN(Code)=3 ");
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE substring(Code,1,9) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,9) = '" +
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,3) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,3) = '" +
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
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE substring(Code,1,6) = '" + code +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,6) = '" +
                code + "' ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ProductCategory") + 1);
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

        public string GetThreeType(string strId)
        {
            string str2 =
                DatabaseExcetue.ReturnString(
                    "select ([dbo].[fun_GetCategoryType](t.fatherid)+' > '+name)typename from ShopNum1_productcategory t where categorylevel=3  and isdeleted=0 and code='" +
                    strId + "'");
            if (str2 == "")
            {
                string str3 =
                    DatabaseExcetue.ReturnString(
                        "select ([dbo].[fun_GetCategoryType](t.id))typename from ShopNum1_productcategory t where isdeleted=0 and code='" +
                        strId + "'");
                if (str3 == "")
                {
                    return
                        DatabaseExcetue.ReturnString(
                            "select name from ShopNum1_productcategory t where isdeleted=0 and code='" + strId + "'");
                }
                return str3;
            }
            return str2;
        }

        public DataTable GetThreeType(string strKeyword, string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            string strSql =
                "select * from (select name,id,code,categoryType,categorylevel,name typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=1  and id not in(select fatherid from ShopNum1_productcategory)\r\nunion all\r\nselect name,id,code,categoryType,categorylevel,dbo.fun_GetCategoryTypeV8_1(t.id,2)typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=2  and id not in(select fatherid from ShopNum1_productcategory)\r\nunion all\r\nselect name,id,code,categoryType,categorylevel,(dbo.fun_GetCategoryTypeV8_1(t.fatherid,3)+' > '+name)typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=3 ) as tab where 1=1";
            if (!string.IsNullOrEmpty(Operator.FilterString(strKeyword)))
            {
                strSql = strSql + " and typename like '%" + strKeyword + "%'";
            }
            if (!string.IsNullOrEmpty(strId))
            {
                strSql = strSql + " and id=@strId";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int MaxOrderId()
        {
            return DatabaseExcetue.ReturnMaxID("orderid", "ShopNum1_ProductCategory");
        }

        private string method_0(int int_0, int int_1)
        {
            string code = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append("select ID,Name,code from ShopNum1_ProductCategory WHERE ID=" + int_1);
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

        public DataTable Search(string Code, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tCategoryLevel\t FROM ShopNum1_ProductCategory  WHERE  IsDeleted =@isDeleted AND Code=@Code and isshow=1  ORDER BY OrderID ASC"
                    }),parms);
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
                    "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCategoryType\t, \tCategoryTypeName\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =@isDeleted"
                    
                });
            if (!string.IsNullOrEmpty(fatherID.ToString()))
            {
                str = str + " AND FatherID =@fatherID" ;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID ASC",parms);
        }

        public DataTable SearchtTypeId(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            var builder = new StringBuilder();
            builder.Append("select ID from ShopNum1_ProductCategory t where 1=1 ");
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

        public DataTable Select_ProductCategory()
        {
            string strSql =
                "select id,name,code,IsOpen,categorytype from ShopNum1_productcategory where  fatherid=0 and isdeleted=0 order by orderid asc";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(ShopNum1_ProductCategory productCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ProductCategory   SET    [Name]\t='", Operator.FilterString(productCategory.Name),
                "', \tKeywords\t='", Operator.FilterString(productCategory.Keywords), "',\tDescription\t='",
                Operator.FilterString(productCategory.Description), "',\tOrderID\t='", productCategory.OrderID,
                "',\tIsShow\t=", productCategory.IsShow, ",\tCategoryLevel\t=", productCategory.CategoryLevel,
                ",\tFatherID\t=", productCategory.FatherID, ",\tModifyUser='", productCategory.ModifyUser,
                "' ,\tModifyTime\t='", productCategory.ModifyTime, "', \tCategoryTypeName\t='",
                productCategory.CategoryTypeName, "', \tCategoryType\t='", productCategory.CategoryType,
                "', \tIsDeleted =", productCategory.IsDeleted, "   WHERE ID=", productCategory.ID
            }));
        }

        public int UpdateIsshow(string strIsshow, string strId)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_ProductCategory set isshow='{0}' where id='{1}'", strIsshow, strId));
        }

        public int UpdateOrderName(string strID, string strName, string strOrderId)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_ProductCategory set orderid='{0}',name='{1}' where id='{2}'",
                        strOrderId, strName.Replace("%2f", ""), strID));
        }
    }
}