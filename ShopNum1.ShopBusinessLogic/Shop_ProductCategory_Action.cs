using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ProductCategory_Action : IShop_ProductCategory_Action
    {
        public string TableName { get; set; }

        public int Add(ShopNum1_Shop_ProductCategory shop_ProductCategory)
        {
            string str = method_0(shop_ProductCategory.CategoryLevel, shop_ProductCategory.FatherID,
                shop_ProductCategory.MemLoginID);
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_ProductCategory(Name,Keywords,Description,IsShow,OrderID,CategoryLevel,FatherID,Code,MemLoginID) VALUES (  '"
                , shop_ProductCategory.Name, "',  '", shop_ProductCategory.Keywords, "',  '",
                shop_ProductCategory.Description, "',  '", shop_ProductCategory.IsShow, "', '",
                shop_ProductCategory.OrderID, "', ", shop_ProductCategory.CategoryLevel, ",  ",
                shop_ProductCategory.FatherID, ",  '", str,
                "',  '", shop_ProductCategory.MemLoginID, " ')"
            }));
        }

        public DataTable GetCategory(string code, string codelen, string agentloginid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@codelen";
            paraValue[1] = codelen;
            paraName[2] = "@agentloginid";
            paraValue[2] = agentloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategory", paraName, paraValue);
        }

        public DataTable GetCategoryProc(string fatherID, string idname, string idvalue,int category)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherID;
            paraName[1] = "@tablename";
            paraValue[1] = TableName;
            paraName[2] = "@idname";
            paraValue[2] = idname;
            paraName[3] = "@idvalue";
            paraValue[3] = idvalue;
            paraName[4] = "@category";
            paraValue[4] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategory", paraName, paraValue);
        }

        public int GetMaxID(string MemloginId)
        {
            try
            {
                return
                    Convert.ToInt32(
                        DatabaseExcetue.ReturnString(
                            "select max(orderid)+1 from ShopNum1_Shop_ProductCategory where memloginid='" + MemloginId +
                            "'"));
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetProductCategoryCode(string fatherID)
        {
            string str = string.Empty;
            str = "select ID,Name,Code from ShopNum1_Shop_ProductCategory ";
            return DatabaseExcetue.ReturnDataTable(str + " WHERE FatherID=" + fatherID);
        }

        public DataTable GetProductCategoryCodeProc(string code, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductCategoryCode", paraName, paraValue);
        }

        public DataTable GetShopAgentID(string memberLoginID)
        {
            return null;
        }

        public DataTable GetShopMetaBycategory(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaBycategory", paraName, paraValue);
        }

        public DataTable GetShopProductCategoryCode(string fatherID, string memLoginID)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherID;
            paraName[1] = "@tablename";
            paraValue[1] = "ShopNum1_Shop_ProductCategory";
            paraName[2] = "@memloginid";
            paraValue[2] = memLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProductCategoryCode", paraName,
                paraValue);
        }

        public DataTable Search(int fatherID, string memLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "select id,name,keywords,description,orderid,isshow,categorylevel,code,(select top 1 id from  ShopNum1_Shop_ProductCategory where fatherid=''+t.id+'')v,(select top 1 id from ShopNum1_Shop_ProductCategory where code like ''+t.code+'%')m  from ShopNum1_Shop_ProductCategory as t where fatherid='"
                        , fatherID, "' and memloginid='", memLoginID, "' ORDER BY OrderID desc"
                    }));
        }

        public DataTable Search_Import(string FatherID, string MemloginId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select id,name,code from ShopNum1_Shop_ProductCategory as t where fatherid='" + FatherID +
                    "' and memloginid='" + MemloginId + "' ORDER BY OrderID ASC");
        }

        public DataTable SearchShopType(int fatherID, string memLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "select id,name,code from ShopNum1_Shop_ProductCategory as t where fatherid='", fatherID,
                        "' and memloginid='", memLoginID, "' ORDER BY OrderID ASC"
                    }));
        }

        public DataTable SetCategoryCode(string code, string strMemloginId)
        {
            string str = "select name,code from ShopNum1_Shop_ProductCategory where 1=1 ";
            if (code == "0")
            {
                str = str + " and fatherId=0 ";
            }
            else
            {
                str = str + " and Code like '" + code + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " and MemloginId='" + strMemloginId + "'");
        }

        public int Update(ShopNum1_Shop_ProductCategory shop_ProductCateGory)
        {
            string str = string.Empty;
            object obj2 = (("UPDATE  ShopNum1_Shop_ProductCategory SET " + " Name  ='" + shop_ProductCateGory.Name +
                            "',") + " Keywords  ='" + shop_ProductCateGory.Keywords + "',") + " Description  ='" +
                          shop_ProductCateGory.Description + "',";
            str = string.Concat(new[] {obj2, " isshow  ='", shop_ProductCateGory.IsShow, "',"});
            if (shop_ProductCateGory.FatherID.ToString() != "0")
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " FatherID  ='", shop_ProductCateGory.FatherID, "',"});
            }
            return
                DatabaseExcetue.RunNonQuery((str + " OrderID  =" + shop_ProductCateGory.OrderID) + " WHERE id=" +
                                            shop_ProductCateGory.ID);
        }

        public int Update1(string guid, ShopNum1_Shop_ProductCategory agent_ProductCateGory)
        {
            return 0;
        }

        public int DeleteProductCategoryCode(string string_1, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@id";
            paraValue[0] = string_1;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteProductCategoryCode", paraName, paraValue);
        }

        public int DeleteRecId(string strID)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_ProductCategory WHERE ID IN (" + strID + ")");
        }

        public int DeleteType(string strId)
        {
            return
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_ProductCategory WHERE Id='" + strId +
                                            "';DELETE FROM ShopNum1_Shop_ProductCategory where fatherid='" + strId + "'");
        }

        public string GetCfCode(string MemloginId)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory Where MemloginId='" + MemloginId +
                           "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append("SELECT  @code = max(Code) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" +
                           MemloginId + "' And LEN(Code)=3 ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCmCode(string code, string MemloginId)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(12) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" + MemloginId +
                           "' And substring(Code,1,9) = '" + code + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code =max(SUBSTRING(Code,10,3)) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" +
                MemloginId + "' And  SUBSTRING(Code,1,9) = '" + code + "'   ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCsCode(string code, string MemloginId)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory  WHERE MemloginId='" + MemloginId +
                           "' And  SUBSTRING(Code,1,3) = '" + code + "') = 0) ");
            builder.Append("SET @code = '001' ELSE ");
            builder.Append(
                "BEGIN SELECT  @code =max(SUBSTRING(Code,4,3)) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" +
                MemloginId + "' And  SUBSTRING(Code,1,3) = '" + code + "'  ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("IF(LEN(@code) <> 3) ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetCtCode(string code, string MemloginId)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @code varchar(10) ");
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" + MemloginId +
                           "' And  substring(Code,1,6) = '" + code + "') = 0) ");
            builder.Append("SET @code = '001' ");
            builder.Append("ELSE BEGIN ");
            builder.Append(
                "SELECT  @code = max(SUBSTRING(Code,7,3)) FROM ShopNum1_Shop_ProductCategory WHERE MemloginId='" +
                MemloginId + "' And  SUBSTRING(Code,1,6) = '" + code + "'  ");
            builder.Append("SET @code = @code + 1 ");
            builder.Append("WHILE (LEN(@code) < 3) ");
            builder.Append("BEGIN SET @code = '0' + @code END END ");
            builder.Append("SELECT '" + code + "' + @code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetProductCategoryInfoByCode(string string_1, string memberid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@id";
            paraValue[0] = string_1;
            paraName[1] = "@memberid";
            paraValue[1] = memberid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductCategoryInfoByCode", paraName,
                paraValue);
        }

        private string method_0(int int_0, int int_1, string string_1)
        {
            string code = "0";
            if (int_0 != 1)
            {
                var builder = new StringBuilder();
                builder.Append(
                    string.Concat(new object[]
                    {
                        "select code from ShopNum1_Shop_ProductCategory WHERE memloginid='", string_1, "' And ID=",
                        int_1
                    }));
                code = DatabaseExcetue.ReturnString(builder.ToString());
            }
            if (int_0 == 1)
            {
                return GetCfCode(string_1);
            }
            if (int_0 == 2)
            {
                return GetCsCode(code, string_1);
            }
            if (int_0 == 3)
            {
                return GetCtCode(code, string_1);
            }
            return GetCmCode(code, string_1);
        }

        public int UpdateIsshow(string strIsshow, string strId)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_Shop_ProductCategory set isshow='{0}' where id='{1}'", strIsshow,
                        strId));
        }

        public int UpdateOrderName(string strID, string strName, string strOrderId)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_Shop_ProductCategory set orderid='{0}',name='{1}' where id='{2}'",
                        strOrderId, strName, strID));
        }
    }
}