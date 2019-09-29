using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OrdeComplaints_Action : IShopNum1_OrdeComplaints_Action
    {
        public int AddOrderComplaints(string orderguid, string complaintsnum, string orderid, string shopid,
            string memloginid, string reporttype, string evidence)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@orderguid";
            paraValue[0] = orderguid;
            paraName[1] = "@complaintsnum";
            paraValue[1] = complaintsnum;
            paraName[2] = "@orderid";
            paraValue[2] = orderid;
            paraName[3] = "@shopid";
            paraValue[3] = shopid;
            paraName[4] = "@memloginid";
            paraValue[4] = memloginid;
            paraName[5] = "@reporttype";
            paraValue[5] = reporttype;
            paraName[6] = "@evidence";
            paraValue[6] = evidence;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddOrderComplaints", paraName, paraValue);
        }

        public int CancelComplaints(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_OrdeComplaints SET ");
            builder.Append("ProcessingState=4,");
            builder.Append("ProcessingResult='取消投诉', ");
            builder.Append("ProcessingResult='" + DateTime.Now + "' ");
            builder.Append(" WHERE Guid=" + guid);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int ComplaintsResult(string guid, string resultes)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_OrdeComplaints SET ");
            builder.Append("ProcessingState=3,");
            builder.Append("ProcessingResult='" + Operator.FilterString(resultes) + "', ");
            builder.Append("ProcessingTime='" +
                           Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "' ");
            builder.Append(" WHERE Guid=" + guid);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string string_0)
        {
            return DatabaseExcetue.RunNonQuery(("delete from  ShopNum1_OrderComplaint where ID IN (" + string_0 + ")"));
        }

        public int UpdateOder(string orderid)
        {
            return DatabaseExcetue.RunNonQuery(("update ShopNum1_Order_Refuse set Status=1 where OrderID in(" + orderid + ")"));
        }

        public DataTable GetOrderComplaints(string ComplaintShop, string type)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("ID,");
            builder.Append("OrderID,");
            builder.Append("ComplaintTime,");
            builder.Append("OrderGuid,");
            builder.Append("MemLoginID,");
            builder.Append("ProcessingTime,");
            builder.Append("ProcessingStatus,");
            builder.Append("ProcessingResults,");
            builder.Append("ComplaintType,");
            builder.Append("Evidence,");
            builder.Append("CustomerMessage,");
            builder.Append(" ComplaintContent, ");
            builder.Append("ComplaintShop ");
            builder.Append("FROM ShopNum1_OrderComplaint WHERE 1=1");
            if (Operator.FormatToEmpty(ComplaintShop) != null)
            {
                builder.Append(" AND ComplaintShop LIKE '%" + ComplaintShop + "%'");
            }
            if (type != "-1")
            {
                builder.Append(" AND ComplaintType ='" + type + "'");
            }
            builder.Append(" ORDER BY ComplaintTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetOrderComplaintsDetails(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderComplaintsDetails", paraName,
                paraValue);
        }

        public DataTable Search(string memloginid, string type, string state)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@type";
            paraValue[0] = type;
            paraName[1] = "@state";
            paraValue[1] = state;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchOrderComplaints", paraName, paraValue);
        }

        public int addReply(ShopNum1_OrderComplaint OrderComplaint)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE   ShopNum1_OrderComplaint      SET ");
            builder.Append("ProcessingTime='" +
                           Convert.ToDateTime(OrderComplaint.ProcessingTime).ToString("yyyy-MM-dd HH:mm:ss") + "',");
            builder.Append("ProcessingResults='" + Operator.FilterString(OrderComplaint.ProcessingResults) + "', ");
            builder.Append("ProcessingStatus='" + OrderComplaint.ProcessingStatus + "',");
            builder.Append("OperateUser='" + OrderComplaint.OperateUser + "' ");
            builder.Append(" WHERE ID='" + OrderComplaint.ID + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}