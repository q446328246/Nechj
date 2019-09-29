using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Vedio_List_Action : IShopNum1_Vedio_List_Action
    {
        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_Shop_Video  WHERE [Guid] IN (" + guids + ") ";
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

        public DataTable GetVedioAll(string commentTitle, string VedioName, string VedioMemLoginID, string isAudit,
            string createTime1, string createTime2, string memLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("a.Title,");
            builder.Append("b.Title as Name,");
            builder.Append("a.VideoGuid,");
            builder.Append("a.MemLoginID,");
            builder.Append("a.ShopID,");
            builder.Append("a.IsAudit,");
            builder.Append("a.CommentTime");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_VideoComment AS a,");
            builder.Append("ShopNum1_Shop_Video AS b");
            builder.Append(" WHERE a.VideoGuid=b.Guid");
            if (Operator.FormatToEmpty(commentTitle) != "-1")
            {
                builder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
            }
            if (Operator.FormatToEmpty(VedioName) != "-1")
            {
                builder.Append(" AND b.Title LIKE '%" + Operator.FilterString(VedioName) + "%'");
            }
            if (Operator.FormatToEmpty(VedioMemLoginID) != "-1")
            {
                builder.Append(" AND b.ShopID = '" + Operator.FilterString(VedioMemLoginID) + "'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                builder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
            }
            if (Operator.FormatToEmpty(createTime1) != "-1")
            {
                builder.Append(" AND a.CommentTime>='" + createTime1 + "' ");
            }
            if (Operator.FormatToEmpty(createTime2) != "-1")
            {
                builder.Append(" AND a.CommentTime<='" + createTime2 + "' ");
            }
            builder.Append(" ORDER BY CommentTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable Search(string title, string memLoginID, string commentTime1, string commentTime2, int isAudit)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid,A.Title,A.ImgAdd,A.VideoAdd,A.CategoryGuid,A.KeyWords,A.Content,A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime,A.OrderID,B.name,A.IsRecommend,A.ShopID,A.IsAudit,A.MemLoginID  FROM ShopNum1_Shop_Video AS A,ShopNum1_Shop_VideoCategory AS B  WHERE A.CategoryGuid=B.Guid ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (isAudit == -2)
            {
                str = str + " AND A.IsAudit IN (0,2) ";
            }
            else if (isAudit == -3)
            {
                str = str + " AND A.IsAudit IN (1,2,3) ";
            }
            else if ((((isAudit == 0) || (isAudit == 1)) || (isAudit == 2)) || (isAudit == 3))
            {
                str = string.Concat(new object[] {str, " AND A.IsAudit=", isAudit, " "});
            }
            if (Operator.FormatToEmpty(commentTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(commentTime1) + "' ";
            }
            if (Operator.FormatToEmpty(commentTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(commentTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by A.OrderID Desc");
        }

        public int UpdateAudit(string guids, int isAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[] { "UPDATE ShopNum1_Shop_Video SET  IsAudit\t=@isAudit WHERE Guid in (@guids)" }), parms);
        }

        public DataTable GetTitleByGuid(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.ReturnDataTable("    SELECT     Title  FROM   ShopNum1_Video   WHERE  Guid  =@guids", parms);
        }
    }
}