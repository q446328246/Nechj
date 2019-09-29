using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ImageCategory_Action : IShopNum1_ImageCategory_Action
    {
        public int Delete(string string_0)
        {
            var sqlList = new List<string>();
            if (DatabaseExcetue.CheckExists("Select count(*)  from ShopNum1_ImageCategory  where fatherid=" + string_0))
            {
                return 2;
            }
            if (DatabaseExcetue.CheckExists("Select count(*) from ShopNum1_Image where ImageCategoryID=" + string_0))
            {
                return -1;
            }
            string item = "Delete from ShopNum1_ImageCategory where ID in(" + string_0 + ")";
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

        public int DeleteType(string strId)
        {
            var sqlList = new List<string>();
            string item = "Delete from ShopNum1_ImageCategory where ID in(" + strId + ") and id!='1'";
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

        public DataTable ImageCategoryGetAllByFatherID(string fatherid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ImageCategoryGetAllByFatherID", paraName,
                paraValue);
        }

        public int Insert(string name, string description, string categoryLevel, string fatherID, string family,
            string user)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_ImageCategory(");
            builder.Append("ID,");
            builder.Append("Name,");
            builder.Append("Description,");
            builder.Append("CategoryLevel,");
            builder.Append("FatherID,");
            builder.Append("Family,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime)");
            builder.Append(" VALUES(");
            builder.Append("'" + GetMaxID() + "',");
            builder.Append("'" + Operator.FilterString(name) + "',");
            builder.Append("'" + Operator.FilterString(description) + "',");
            builder.Append(categoryLevel + ",");
            builder.Append(fatherID + ",");
            builder.Append("'" + Operator.FilterString(family) + "',");
            builder.Append("'" + user + "',");
            builder.Append("getdate(),");
            builder.Append("'" + user + "',");
            builder.Append("getdate())");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(int fatherid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@fatherid";
            parms[0].Value = fatherid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT ID,Name,CategoryLevel,FatherID,Family FROM ShopNum1_ImageCategory WHERE FatherID=@fatherid"+" ORDER BY CreateTime DESC",parms);
        }

        public DataTable SearchInfoByID(string strID)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tID\t, \tName\t, \tDescription\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t  FROM ShopNum1_ImageCategory  WHERE 1=1 ";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                strSql = strSql + "And ID =" + Operator.FilterString(strID);
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(string strid, string name, string description, string categoryLevel, string fatherID,
            string family, string user)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ImageCategory");
            builder.Append(" SET ");
            builder.Append("Name = '" + Operator.FilterString(name) + "',");
            builder.Append("Description = '" + Operator.FilterString(description) + "',");
            builder.Append("CategoryLevel = " + categoryLevel + ",");
            builder.Append("FatherID = " + fatherID + ",");
            builder.Append("Family = '" + family + "',");
            builder.Append("ModifyUser = '" + user + "',");
            builder.Append("ModifyTime = getdate()");
            builder.Append(" WHERE ");
            builder.Append(" ID = '" + strid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable GetIdByName(string name, string fatherID)
        {
            string format = string.Empty;
            format = "SELECT \tID\t, \tName FROM ShopNum1_ImageCategory  WHERE Name='{0}' AND FatherID={1} ";
            return DatabaseExcetue.ReturnDataTable(string.Format(format, name, fatherID));
        }

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ImageCategory") + 1);
        }
    }
}