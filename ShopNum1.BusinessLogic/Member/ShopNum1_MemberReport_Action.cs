using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberReport_Action : IShopNum1_MemberReport_Action
    {
        public int Add(ShopNum1_MemberReport MemberReport)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "INSERT INTO ShopNum1_MemberReport( \tProductUrl\t, \tReportType\t, \tReportShop\t, \tEvidence\t, \tEvidenceImage\t, \tReportTime\t, \tMemLoginID\t  ) VALUES (  '" +
                    MemberReport.ProductUrl + "',  '" + MemberReport.ReportType + "',  '" + MemberReport.ReportShop +
                    "',  '" + MemberReport.Evidence + "',  '" + MemberReport.EvidenceImage + "',  '" +
                    Convert.ToDateTime(MemberReport.ReportTime).ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                    MemberReport.MemLoginID + "' )");
        }

        public DataTable CheckIsComplainByID(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckIsComplainByID", paraName, paraValue);
        }

        public DataTable GetReportDetailByID(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetReportDetailByID", paraName, paraValue);
        }

        public DataTable GetReportListByReportShop(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetReportListByReportShop", paraName, paraValue);
        }

        public DataTable Search(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string str = string.Empty;
            str =
                "SELECT \tID\t, \tReportShop\t, \tReportType\t, \tReportTime\t   FROM ShopNum1_MemberReport   WHERE  0=0";
            if (memLoginID != string.Empty)
            {
                str = str + " AND MemLoginID=@memLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by ReportTime Desc",parms);
        }

        public DataTable Search(string memLoginID, string type)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
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
            if (string.IsNullOrEmpty(memLoginID))
            {
                builder.Append(" AND MemLoginID LIKE '%@memLoginID%'");
            }
            if (type != "-1")
            {
                builder.Append(" AND ReportType =@type");
            }
            builder.Append(" ORDER BY ReportTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchReport(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            string strSql = string.Empty;
            strSql = "SELECT  *  FROM ShopNum1_MemberReport   WHERE  0=0";
            if (string_0 != string.Empty)
            {
                strSql = strSql + " AND ID=@string_0";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public bool SearchReportName(string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@name";
            parms[0].Value = name;
            string strSql = string.Empty;
            strSql = "SELECT  count(*) AS NUM  FROM ShopNum1_ShopInfo   WHERE  0=0";
            if (name != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@name";
            }
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql,parms);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (int.Parse(table.Rows[0]["NUM"].ToString()) != 1)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool SearchReportProduct(string product, string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@product";
            parms[0].Value = product;
            parms[1].ParameterName = "@name";
            parms[1].Value = name;
            string strSql = string.Empty;
            strSql = "SELECT  Guid  FROM ShopNum1_Shop_Product   WHERE  0=0";
            if (product != string.Empty)
            {
                strSql = strSql + " AND Guid=@product";
            }
            if (name != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@name";
            }
            return (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0);
        }

        public int UpdateComplainInfoByID(string string_0, string complainimage, string complaintcontent)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            paraName[1] = "@complainimage";
            paraValue[1] = complainimage;
            paraName[2] = "@complaintcontent";
            paraValue[2] = complaintcontent;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateComplainInfoByID", paraName, paraValue);
        }

        public int addReply(ShopNum1_MemberReport MemberReport)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_MemberReport  SET ");
            builder.Append("ProcessingTime='" + MemberReport.ProcessingTime + "',");
            builder.Append("ProcessingResults='" + Operator.FilterString(MemberReport.ProcessingResults) + "',");
            builder.Append("ProcessingStatus='" + Operator.FilterString(MemberReport.ProcessingStatus) + "',");
            builder.Append("OperateUser='" + Operator.FilterString(MemberReport.OperateUser) + "' ");
            builder.Append("WHERE ID=" + MemberReport.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string string_0)
        {
            return DatabaseExcetue.RunNonQuery("   DELETE  ShopNum1_MemberReport  WHERE  ID IN (" + string_0 + ")   ");
        }

        public DataTable GetComplaintsManagement(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            var builder = new StringBuilder();
            builder.Append("SELECT  ");
            builder.Append("ID, ");
            builder.Append("ShopProductID, ");
            builder.Append("ProductUrl, ");
            builder.Append("ReportShop, ");
            builder.Append("MemLoginID, ");
            builder.Append("ReportType, ");
            builder.Append("Evidence, ");
            builder.Append("EvidenceImage, ");
            builder.Append("ComplaintContent, ");
            builder.Append("ComplaintImage, ");
            builder.Append("ComplaintTime, ");
            builder.Append("ReportTime, ");
            builder.Append("CustomerMessage, ");
            builder.Append("ProcessingTime, ");
            builder.Append("ProcessingStatus, ");
            builder.Append("ProcessingResults ");
            builder.Append("FROM ShopNum1_MemberReport ");
            builder.Append(" WHERE ID =@guid");
            builder.Append(" ORDER BY ReportTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_MemberReport";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ReportTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdateProcessingStatus(string string_0, int ProcessingStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            parms[1].ParameterName = "@ProcessingStatus";
            parms[1].Value = ProcessingStatus;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "   UPDATE   ShopNum1_MemberReport  SET   ProcessingStatus=@ProcessingStatus     WHERE  ID =@string_0"
                    }),parms);
        }
    }
}