using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopArticleComment_Action : IShopNum1_ShopArticleComment_Action
    {
        public int Add(ShopNum1_ArticleComment articleComment)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ArticleComment( \tGuid\t, \tArticleGuid\t, \tMemLoginID\t, \tTitle\t, \tContent\t, \tSendTime\t, \tIPAddress\t, \tRank, \tIsReply\t, \tIsAudit\t, \tIsDeleted  ) VALUES (  '"
                , articleComment.Guid, "',  '", articleComment.ArticleGuid, "',  '",
                Operator.FilterString(articleComment.MemLoginID), "',  '",
                Operator.FilterString(articleComment.Title), "',  '", Operator.FilterString(articleComment.Content),
                "',  '", articleComment.SendTime, "',  '", articleComment.IPAddress, "',  ", articleComment.Rank,
                ",  ", articleComment.IsReply, ",  ", articleComment.IsAudit, ",  ", articleComment.IsDeleted, ")"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_NewsComment WHERE Guid IN (@guids)",parms);
        }

        public int DeleteShopArticleComment(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteShopArticleComment", paraName, paraValue);
        }

        public DataTable GetMemloginIDByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "select MemLoginID,IsAudit from ShopNum1_Shop_NewsComment where guid in (@guid)",parms);
        }

        public DataTable GetShopArticleCommentByGuid(string articleguid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@articleguid";
            paraValue[0] = articleguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopArticleCommentByGuid", paraName,
                paraValue);
        }

        public DataTable MemberShopArticleComment(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberShopArticleComment", paraName,
                paraValue);
        }

        public DataTable Search(string memLoginID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@memLoginID";
            parms[1].Value = Operator.FilterString(memLoginID);
            string str = string.Empty;
            str =
                "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%@memLoginID%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by A.SendTime Desc",parms);
        }

        public DataTable Search(string articleGuid, int isReply, int isAudit, int count)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@articleGuid";
            parms[0].Value = articleGuid;
            parms[1].ParameterName = "@isReply";
            parms[1].Value = isReply;
            parms[2].ParameterName = "@isAudit";
            parms[2].Value = isAudit;
            string str = string.Empty;
            if (count > 0)
            {
                str = "SELECT top " + count;
            }
            else
            {
                str = "SELECT ";
            }
            str = str +
                  "\tGuid\t, \tMemLoginID\t, \tArticleGuid\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIPAddress\t, \tRank\t, \tIsReply\t, \tIsAudit\t, \tIsDeleted   FROM  ShopNum1_Shop_NewsComment  WHERE IsDeleted = 1";
            if (articleGuid != "-1")
            {
                str = str + " AND ArticleGuid=@articleGuid ";
            }
            if ((isReply == 0) || (isReply == 1))
            {
                str = string.Concat(new object[] { str, " AND IsReply=@isReply " });
            }
            if ((isAudit == 0) || (isAudit == 1))
            {
                str = string.Concat(new object[] { str, " AND IsAudit=@isAudit" });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY SendTime DESC",parms);
        }

        public DataTable Search(string title, string memLoginID, string name, string commentTime1, string commentTime2,
            string replyTime1, string replyTime2, int isReply, int isAudit, string iPAddress,
            string shopID)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid,A.Title,B.Title AS Name,A.Rank,A.Content,A.CommentTime,A.ReplyContent,A.ReplyTime,A.IsDeleted,A.MemLoginID,A.ArticleGuid,A.ShopID,C.ShopName,A.IsAudit,A.IPAddress,A.IsReply  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Shop_News AS B ,ShopNum1_ShopInfo AS C    WHERE A.ArticleGuid = B.Guid AND A.ShopID=C.ShopID ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND B.Title LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if ((isReply == 0) || (isReply == 1))
            {
                str = string.Concat(new object[] {str, " AND A.IsReply=", isReply, " "});
            }
            if (isAudit == -2)
            {
                str = str + " AND A.IsAudit IN (0,2) ";
            }
            if (((isAudit == 0) || (isAudit == 1)) || (isAudit == 2))
            {
                str = string.Concat(new object[] {str, " AND A.IsAudit=", isAudit, " "});
            }
            if (Operator.FormatToEmpty(commentTime1) != string.Empty)
            {
                str = str + " AND A.CommentTime>='" + Operator.FilterString(commentTime1) + "' ";
            }
            if (Operator.FormatToEmpty(commentTime2) != string.Empty)
            {
                str = str + " AND A.CommentTime<='" + Operator.FilterString(commentTime2) + "' ";
            }
            if (Operator.FormatToEmpty(replyTime1) != string.Empty)
            {
                str = str + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
            }
            if (Operator.FormatToEmpty(replyTime2) != string.Empty)
            {
                str = str + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
            }
            if (Operator.FormatToEmpty(iPAddress) != string.Empty)
            {
                str = str + " AND A.IPAddress = '" + Operator.FilterString(iPAddress) + "'";
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.ShopID = '" +
                      Operator.FilterString(shopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "")) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by A.CommentTime Desc");
        }

        public DataTable SearchByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,B.MemLoginID AS ArticleMemLoginID,A.MemLoginID,A.Title,A.Rank,A.CommentTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.ShopID  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Shop_News AS B  WHERE A.ArticleGuid = B.Guid  AND A.Guid=@guid",parms);
        }

        public DataTable SearchShopArticleComment(string memberloginid, string commenttitle, string articletitle,
            string articlememloginid, string isaudit, string createtime1,
            string createtime2)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            paraName[1] = "@commenttitle";
            paraValue[1] = commenttitle;
            paraName[2] = "@articletitle";
            paraValue[2] = articletitle;
            paraName[3] = "@articlememloginid";
            paraValue[3] = articlememloginid;
            paraName[4] = "@isaudit";
            paraValue[4] = isaudit;
            paraName[5] = "@createtime1";
            paraValue[5] = createtime1;
            paraName[6] = "@createtime2";
            paraValue[6] = createtime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopArticleComment", paraName,
                paraValue);
        }

        public int Shop_NewsCommentAdd(ShopNum1_Shop_NewsComment Shop_NewsComment)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_NewsComment( \tGuid\t, \tArticleGuid\t, \tMemLoginID\t, \tTitle\t, \tContent\t, \tCommentTime\t, \tIPAddress\t, \tRank, \tShopID, \tCommentType, \tIsReply\t, \tIsAudit\t, \tIsDeleted  ) VALUES (  '"
                , Shop_NewsComment.Guid, "',  '", Shop_NewsComment.ArticleGuid, "',  '",
                Operator.FilterString(Shop_NewsComment.MemLoginID), "',  '",
                Operator.FilterString(Shop_NewsComment.Title), "',  '",
                Operator.FilterString(Shop_NewsComment.Content), "',  '", Shop_NewsComment.CommentTime, "',  '",
                Shop_NewsComment.IPAddress, "',  ", Shop_NewsComment.Rank,
                ",  ", Shop_NewsComment.ShopID, ",  ", Shop_NewsComment.CommentType, ",  ", Shop_NewsComment.IsReply
                , ",  ", Shop_NewsComment.IsAudit, ",  ", Shop_NewsComment.IsDeleted, ")"
            }));
        }

        public int Update(ShopNum1_ArticleComment articleComment)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_Shop_NewsComment SET   ReplyUser\t='", articleComment.ReplyUser,
                        "', \tReplyTime\t='", articleComment.ReplyTime, "',\tReplyContent\t='",
                        articleComment.ReplyContent, "',\tIsReply\t=", articleComment.IsReply, "  WHERE Guid='",
                        articleComment.Guid, "'"
                    }));
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
                    string.Concat(new object[] { "UPDATE ShopNum1_Shop_NewsComment SET  IsAudit\t=@isAudit WHERE Guid in (@guids)" }),parms);
        }

        public int UpdateAuditNew(string guids, int isAudit)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[] { "UPDATE ShopNum1_Shop_NewsComment SET  IsAudit\t=@isAudit WHERE Guid in (@guids)" }),parms);
        }
    }
}