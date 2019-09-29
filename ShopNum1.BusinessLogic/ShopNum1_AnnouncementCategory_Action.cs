using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AnnouncementCategory_Action : IShopNum1_AnnouncementCategory_Action
    {
        public int Add(ShopNum1_AnnouncementCategory AnnouncementCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AnnouncementCategory( \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , Operator.FilterString(AnnouncementCategory.Name), "',  '",
                Operator.FilterString(AnnouncementCategory.Keywords), "',  '",
                Operator.FilterString(AnnouncementCategory.Description), "',  ", AnnouncementCategory.OrderID, ",  "
                , AnnouncementCategory.IsShow, ",  ", AnnouncementCategory.CategoryLevel, ",  ",
                AnnouncementCategory.FatherID, ",  '", AnnouncementCategory.Family,
                "',  '", AnnouncementCategory.CreateUser, "', '", AnnouncementCategory.CreateTime, "',  '",
                AnnouncementCategory.ModifyUser, "' , '", AnnouncementCategory.ModifyTime, "',  ",
                AnnouncementCategory.IsDeleted, ")"
            }));
        }

        public int Delete(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            if (
                DatabaseExcetue.ReturnDataTable(
                    "Select  Title, Guid  from ShopNum1_Announcement where AnnouncementCategoryID IN(@string_0)")
                    .Rows.Count > 0)
            {
                return -1;
            }
            string strSql = "Delete from ShopNum1_AnnouncementCategory where ID in (@string_0)";
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

        public DataTable GetAnnouncementCategory(string FatherId)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@FatherID";
            paraValue[0] = FatherId;
            return DatabaseExcetue.RunProcedureReturnDataTable("ShopNum1_AnnouncementCategory", paraName, paraValue);
        }

        public DataTable GetAnnouncementCategoryMeto(string strID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID, \tName\t, \tKeywords,\tDescription\t FROM ShopNum1_AnnouncementCategory WHERE ID =@strID",parms);
        }

        public DataTable GetEditInfo(string strID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            string strSql =
                "SELECT \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_AnnouncementCategory  Where 0=0";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                strSql = strSql + " AND  ID=@strID ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_AnnouncementCategory") + 1);
        }

        public string GetNameByID(int int_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID\t, \tName\t  FROM ShopNum1_AnnouncementCategory  WHERE 1=1 And ID =@int_0",parms).Rows[0][
                        "Name"].ToString();
        }

        public DataTable Search(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID AS GUID, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory WHERE IsDeleted =@isDeleted ORDER BY OrderID DESC",parms);
        }

        public DataTable Search(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@fatherID";
            parms[1].Value = fatherID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory  WHERE FatherID =@fatherID AND  IsDeleted =@isDeleted"}) + " ORDER BY OrderID DESC",parms);
        }

        public DataTable SearchID(int int_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            
            return
                DatabaseExcetue.ReturnDataTable("select [ID] from ShopNum1_AnnouncementCategory where FatherID=@int_0" ,parms);
        }

        public DataTable SearchShow(int fatherID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@fatherID";
            parms[1].Value = fatherID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory  WHERE IsShow=1 AND FatherID =@fatherID AND  IsDeleted =@isDeleted"
                    }) + " ORDER BY OrderID DESC",parms);
        }

        public int Update(ShopNum1_AnnouncementCategory AnnouncementCategory)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_AnnouncementCategory   SET    [Name]\t='",
                Operator.FilterString(AnnouncementCategory.Name), "', \tKeywords\t='",
                Operator.FilterString(AnnouncementCategory.Keywords), "',\tDescription\t='",
                Operator.FilterString(AnnouncementCategory.Description), "',\tOrderID\t='",
                AnnouncementCategory.OrderID, "',\tIsShow\t=", AnnouncementCategory.IsShow, ",\tCategoryLevel\t=",
                AnnouncementCategory.CategoryLevel, ",\tFatherID\t=", AnnouncementCategory.FatherID, ",\tFamily\t='"
                , AnnouncementCategory.Family,
                "',\tModifyUser='", AnnouncementCategory.ModifyUser, "' ,\tModifyTime\t='",
                AnnouncementCategory.ModifyTime, "', \tIsDeleted =", AnnouncementCategory.IsDeleted, "   WHERE ID=",
                AnnouncementCategory.ID
            }));
        }
    }
}