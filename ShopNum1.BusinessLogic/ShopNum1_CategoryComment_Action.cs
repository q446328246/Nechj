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
    public class ShopNum1_CategoryComment_Action : IShopNum1_CategoryComment_Action
    {
        public int Add(ShopNum1_CategoryComment categoryComment)
        {
            string strProcedureName = "Pro_ShopNum1_AddCategoryComment";
            var paraName = new[]
            {
                "@Title", "@Content", "@CreateTime", "@CreateMember", "@CreateIP", "@CategoryInfoGuid",
                "@AssociatedMemberID", "@IsAudit"
            };
            var paraValue = new[]
            {
                categoryComment.Title, categoryComment.Content, Convert.ToString(categoryComment.CreateTime),
                categoryComment.CreateMember, categoryComment.CreateIP,
                Convert.ToString(categoryComment.CategoryInfoGuid), categoryComment.AssociatedMemberID,
                categoryComment.IsAudit.ToString()
            };
            return DatabaseExcetue.RunProcedure(strProcedureName, paraName, paraValue);
        }

        public int CategoryCommentReply(string guid, string content)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_CategoryComment SET Reply='" +
                                            Operator.FormatToEmpty(content) + "' WHERE Guid=@guid",parms);
        }

        public int DeleteCategoryComment(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_CategoryComment  WHERE [Guid] IN (" + guids + ") ";
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

        public DataTable GetCateGoryAssociatedMemberID(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCateGoryAssociatedMemberID", paraName,
                paraValue);
        }

        public DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid,
            string createMember, string isAudit, string createTime1,
            string createTime2)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("a.Title,");
            builder.Append("a.CreateMember,");
            builder.Append("a.CreateTime,");
            builder.Append("b.Guid as id,");
            builder.Append("a.IsAudit");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_CategoryComment AS a,");
            builder.Append("ShopNum1_CategoryInfo AS b");
            builder.Append(" WHERE a.CategoryInfoGuid=b.Guid");
            if (Operator.FormatToEmpty(commentTitle) != string.Empty)
            {
                builder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
            }
            if (Operator.FormatToEmpty(CategoryTitle) != string.Empty)
            {
                builder.Append(" AND b.Title LIKE '%" + Operator.FilterString(CategoryTitle) + "%'");
            }
            if (Operator.FormatToEmpty(CategoryInfoGuid) != string.Empty)
            {
                builder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(CategoryInfoGuid) + "%'");
            }
            if (Operator.FormatToEmpty(createMember) != string.Empty)
            {
                builder.Append(" AND a.CreateMember LIKE '%" + Operator.FilterString(createMember) + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND a.IsAudit in(0,2)");
                }
                else
                {
                    builder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
                }
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                builder.Append(" AND a.CreateTime>='" + createTime1 + "' ");
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                builder.Append(" AND a.CreateTime<='" + createTime2 + "' ");
            }
            builder.Append(" ORDER BY a.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid,
            string createMember, string isAudit, string createTime1,
            string createTime2, string CreateMember)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("a.Title,");
            builder.Append("a.CreateMember,");
            builder.Append("a.CreateTime,");
            builder.Append("a.IsAudit");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_CategoryComment AS a,");
            builder.Append("ShopNum1_CategoryInfo AS b");
            builder.Append(" WHERE a.CategoryInfoGuid=b.Guid");
            builder.Append(" AND a.CreateMember='" + CreateMember + "'");
            if (Operator.FormatToEmpty(commentTitle) != string.Empty)
            {
                builder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
            }
            if (Operator.FormatToEmpty(CategoryTitle) != string.Empty)
            {
                builder.Append(" AND b.Title LIKE '%" + Operator.FilterString(CategoryTitle) + "%'");
            }
            if (Operator.FormatToEmpty(CategoryInfoGuid) != string.Empty)
            {
                builder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(CategoryInfoGuid) + "%'");
            }
            if (Operator.FormatToEmpty(createMember) != string.Empty)
            {
                builder.Append(" AND a.CreateMember LIKE '%" + Operator.FilterString(createMember) + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                builder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                builder.Append(" AND a.CreateTime>='" + createTime1 + "' ");
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                builder.Append(" AND a.CreateTime<='" + createTime2 + "' ");
            }
            builder.Append(" ORDER BY a.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetCategoryCommentByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.*,B.[Content] AS CategoryInfo FROM ShopNum1_CategoryComment AS A,dbo.ShopNum1_CategoryInfo AS B WHERE A.CategoryInfoGuid=B.Guid AND A.Guid=@guid",parms);
        }

        public string GetCategoryGuid(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("CategoryInfoGuid");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_CategoryComment");
            builder.Append(" WHERE ");
            builder.Append("[Guid] =" + guid);
            return DatabaseExcetue.ReturnString(builder.ToString());
        }

        public DataTable GetCommentList(string guid)
        {
            string strProcedureName = "Pro_ShopNum1_CategoryCommentList";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
        }

        public DataSet GetCommentList(string perpagenum, string current_page, string guid, string ordername,
            string isreturcount)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] = " A.Guid,A.Title,A.[Content],A.CreateTime,A.CreateMember,A.CreateIP ,A.Reply ";
            paraName[3] = "@ordername";
            paraValue[3] = "";
            paraName[4] = "@guid";
            paraValue[4] = guid;
            paraName[5] = "@isreturcount";
            paraValue[5] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_MemberCategoryComment1", paraName, paraValue);
        }

        public DataTable MemberCategoryComment(string memberloginid, string commenttitle, string categorytitle,
            string CategoryInfoMerberID, string isaudit, string createtime1,
            string createtime2)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            paraName[1] = "@commenttitle";
            paraValue[1] = commenttitle;
            paraName[2] = "@categorytitle";
            paraValue[2] = categorytitle;
            paraName[3] = "@categoryInfoMerberID";
            paraValue[3] = CategoryInfoMerberID;
            paraName[4] = "@isaudit";
            paraValue[4] = isaudit;
            paraName[5] = "@createtime1";
            paraValue[5] = createtime1;
            paraName[6] = "@createtime2";
            paraValue[6] = createtime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberCategoryComment", paraName, paraValue);
        }

        public int UpdateCategoryCommentAudit(string guids, string state)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_CategoryComment");
            builder.Append(" SET ");
            builder.Append("IsAudit = " + state);
            builder.Append(" WHERE ");
            builder.Append("[Guid] in (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}