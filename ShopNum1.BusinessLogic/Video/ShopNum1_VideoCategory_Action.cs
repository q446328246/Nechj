using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_VideoCategory_Action : IShopNum1_VideoCategory_Action
    {
        public int Add(ShopNum1_VideoCategory productCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_VideoCategory( \t[ID]\t, \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted, \tBackgroundImage, \tIsDownload  ) VALUES (  "
                , productCategory.ID, ",  '", Operator.FilterString(productCategory.Name), "',  '",
                Operator.FilterString(productCategory.Keywords), "',  '",
                Operator.FilterString(productCategory.Description), "',  ", productCategory.OrderID, ",  ",
                productCategory.IsShow, ",  ", productCategory.CategoryLevel, ",  ", productCategory.FatherID,
                ",  '", productCategory.Family, "',  '", productCategory.CreateUser, "', '",
                productCategory.CreateTime, "',  '", productCategory.ModifyUser, "' , '", productCategory.ModifyTime
                , "',  ", productCategory.IsDeleted, ", '", productCategory.BackgroundImage, "',  ", 0,
                ")"
            }));
        }

        public int Delete(string string_0)
        {
           
            var sqlList = new List<string>();
            string item = string.Empty;
            if (
                int.Parse(
                    DatabaseExcetue.ReturnString("select count(guid)  from ShopNum1_Video where CategoryID in (" +
                                                 string_0 + ")")) > 0)
            {
                return -1;
            }
            if (
                int.Parse(
                    DatabaseExcetue.ReturnString("select count(1) from ShopNum1_VideoCategory where FatherID in (" +
                                                 string_0 + ")")) > 0)
            {
                return -2;
            }
            item = "Delete from ShopNum1_VideoCategory where ID in (" + string_0 + ")";
            sqlList.Add(item);
            item = "delete from  dbo.ShopNum1_Video where CategoryID in (" + string_0 + ")";
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

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_VideoCategory") + 1);
        }

        public DataTable Search(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory WHERE IsDeleted =@isDeleted  ORDER BY OrderID ASC",parms);
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
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE FatherID =@fatherID AND  IsDeleted =@isDeleted ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable Search(int fatherID, int isDeleted, int count)
        {
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
                        str,
                        "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE IsShow=1 AND FatherID ="
                        , fatherID, " AND  IsDeleted =", isDeleted, " ORDER BY OrderID ASC"
                    }));
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
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE  IsShow = 1 AND FatherID =@fatherID AND  IsDeleted =@isDeleted  ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable SearchInfoByID(string strID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strID";
            parms[0].Value = Operator.FilterString(strID);
            string str = string.Empty;
            str =
                "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tBackgroundImage\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE 1=1 ";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                str = str + "And ID =@strID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY OrderID ASC",parms);
        }

        public int Update(ShopNum1_VideoCategory productCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_VideoCategory   SET    [Name]\t='", Operator.FilterString(productCategory.Name),
                "', \tKeywords\t='", Operator.FilterString(productCategory.Keywords), "',\tDescription\t='",
                Operator.FilterString(productCategory.Description), "',\tOrderID\t='", productCategory.OrderID,
                "',\tIsShow\t=", productCategory.IsShow, ",\tCategoryLevel\t=", productCategory.CategoryLevel,
                ",\tFatherID\t=", productCategory.FatherID, ",\tFamily\t='", productCategory.Family,
                "',\tModifyUser='", productCategory.ModifyUser, "' ,\tModifyTime\t='", productCategory.ModifyTime,
                "', \tIsDeleted =", productCategory.IsDeleted, ",\tBackgroundImage\t='",
                productCategory.BackgroundImage, "',  IsDownload=", 0, "   WHERE ID=", productCategory.ID
            }));
        }
    }
}