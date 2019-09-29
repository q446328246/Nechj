using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ComplaintsManagement_Action : IShopNum1_ComplaintsManagement_Action
    {
        public int AddComplaintsManagement(string productguid, string shopid, string memloginid, string reporttype,
            string evidence, string remark)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@reporttype";
            paraValue[3] = reporttype;
            paraName[4] = "@evidence";
            paraValue[4] = evidence;
            paraName[5] = "@remark";
            paraValue[5] = remark;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddComplaintsManagement", paraName, paraValue);
        }

        public int ComplaintsResult(string guid, string resultes)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_ComplaintsManagement SET ");
            builder.Append("ProcessingState=1,");
            builder.Append("ProcessingResult='" + Operator.FilterString(resultes) + "' ");
            builder.Append(" WHERE Guid=" + guid);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string guid)
        {
            var sqlList = new List<string>();
            string item = "delete form  dbo.ShopNum1_ComplaintsManagement where guid in(" + guid + ")";
            string str2 = "delete form  dbo.ShopNum1_ComplaintsReply where ComplaintsManagementGuid in(" + guid + ")";
            sqlList.Add(item);
            sqlList.Add(str2);
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

        public int DeleteReport(string ID)
        {
            var sqlList = new List<string>();
            string item = "delete from  ShopNum1_MemberReport where ID IN (" + ID + ")";
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

        public DataTable GetComplaintsManagement(string memloginid, string type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@type";
            paraValue[1] = type;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetComplaintsManagement", paraName,
                paraValue);
        }

        public DataSet GetComplaintsManagementDetail(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetComplaintsManagementDetail", paraName,
                paraValue);
        }

        public DataTable GetProductNamebyguid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductNamebyguid", paraName, paraValue);
        }

        public DataTable GetShopNum1_ComplaintsReply(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("ReplayContent,");
            builder.Append("RepalyTime ");
            builder.Append("FROM ShopNum1_ComplaintsReply ");
            builder.Append(" WHERE ComplaintsManagementGuid =" + guid);
            builder.Append(" ORDER BY RepalyTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable Search(string memLoginID, string type)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("ID,");
            builder.Append("ShopProductID,");
            builder.Append("ReportShop,");
            builder.Append("MemLoginID,");
            builder.Append("ReportType,");
            builder.Append("Evidence,");
            builder.Append("ComplaintContent,");
            builder.Append("ReportTime,");
            builder.Append("CustomerMessage,");
            builder.Append("ProcessingTime,");
            builder.Append("ProcessingStatus,");
            builder.Append("ProcessingResults ");
            builder.Append("FROM ShopNum1_MemberReport WHERE 1=1");
            if (!string.IsNullOrEmpty(memLoginID))
            {
                builder.Append(" AND MemLoginID LIKE '%" + memLoginID + "%'");
            }
            if (type != "-1")
            {
                builder.Append(" AND ReportType ='" + type + " ' ");
            }
            builder.Append(" ORDER BY ReportTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }
    }
}