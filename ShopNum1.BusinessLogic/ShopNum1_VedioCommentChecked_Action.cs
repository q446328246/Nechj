using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_VedioCommentChecked_Action : IShopNum1_VedioCommentChecked_Action
    {
        public int Add(ShopNum1_Shop_Video shop_Video)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_Video( \tGuid\t, \tTitle\t, \tImgAdd\t, \tVideoAdd\t, \tCategoryGuid\t, \tKeyWords\t, \tContent\t, \tOrderID, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsRecommend\t, \tShopID\t, \tMemLoginID\t, \tIsAudit  ) VALUES (  '"
                , shop_Video.Guid, "',  '", shop_Video.Title, "',  '", Operator.FilterString(shop_Video.ImgAdd),
                "',  '", Operator.FilterString(shop_Video.VideoAdd), "',  '",
                Operator.FilterString(shop_Video.CategoryGuid), "',  '", shop_Video.KeyWords, "',  '",
                shop_Video.Content, "',  ", shop_Video.OrderID,
                ",  ", shop_Video.CreateUser, ",  ", shop_Video.CreateTime, ",  ", shop_Video.ModifyUser, ",  ",
                shop_Video.ModifyTime, ",  ", shop_Video.IsRecommend, ",  ", shop_Video.ShopID, ", )"
            }));
        }

        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_Shop_VideoComment  WHERE [Guid] IN (" + guids + ") ";
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

        public int DeleteShopVideoComment(string guid)
        {
            return 0;
        }

        public DataTable GetMemLoginIDByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "select MemLoginID,isAudit from ShopNum1_Shop_VideoComment where guid in (@guid)",parms);
        }

        public DataTable GetShopVideoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.CreateTime,A.Title,A.ImgAdd,A.VideoAdd,A.KeyWords,A.MemLoginID,B.Name FROM ShopNum1_Shop_Video AS A,ShopNum1_Shop_VideoCategory AS B WHERE A.CategoryGuid=B.Guid AND A.Guid=@guid",parms);
        }

        public DataTable MemberShopVideoComment(string memloginid)
        {
            return null;
        }

        public DataTable Search(string memLoginID, int isDeleted)
        {
            return null;
        }

        public DataTable Search(string articleGuid, int isReply, int isAudit, int count)
        {
            return null;
        }

        public DataTable Search(string Title, string memLoginID, string name, string CommentTime1, string CommentTime2,
            string replyTime1, string replyTime2, int isReply, int isAudit, string ipAddress,
            string ShopID)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid,A.Title,A.CommentType,A.Comment,A.CommentTime,A.Reply,A.ReplyTime,A.IsDelete,A.IPAddress,A.VideoGuid,B.Title AS Name,A.ShopID,C.ShopName,A.IsReply,A.MemLoginID,A.IsAudit  FROM ShopNum1_Shop_VideoComment AS A,ShopNum1_Shop_Video AS B,ShopNum1_ShopInfo AS C   WHERE A.VideoGuid=B.Guid AND A.ShopID=C.ShopID ";
            if (Operator.FormatToEmpty(Title) != string.Empty)
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(Title) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
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
                str = str + " AND A.IsAudit IN(0,2) ";
            }
            if (((isAudit == 0) || (isAudit == 1)) || (isAudit == 2))
            {
                str = string.Concat(new object[] {str, " AND A.IsAudit=", isAudit, " "});
            }
            if (Operator.FormatToEmpty(CommentTime1) != string.Empty)
            {
                str = str + " AND A.CommentTime>='" + Operator.FilterString(CommentTime1) + "' ";
            }
            if (Operator.FormatToEmpty(CommentTime2) != string.Empty)
            {
                str = str + " AND A.CommentTime<='" + Operator.FilterString(CommentTime2) + "' ";
            }
            if (Operator.FormatToEmpty(replyTime1) != string.Empty)
            {
                str = str + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
            }
            if (Operator.FormatToEmpty(replyTime2) != string.Empty)
            {
                str = str + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
            }
            if (Operator.FormatToEmpty(ipAddress) != string.Empty)
            {
                str = str + " AND A.IPAddress = '" + Operator.FilterString(ipAddress) + "'";
            }
            if (Operator.FormatToEmpty(ShopID) != string.Empty)
            {
                str = str + " AND A.ShopID = '" + ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "") + "'";
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
                    "SELECT A.Guid,A.Title,A.CommentType,A.Comment,A.CommentTime,A.Reply,A.ReplyTime,A.IsDelete,A.IPAddress,B.Title AS Name,A.ShopID,A.IsReply,A.MemLoginID,A.IsAudit  FROM ShopNum1_Shop_VideoComment AS A,ShopNum1_Shop_Video AS B  WHERE A.VideoGuid=B.Guid  AND A.Guid=@guid",parms);
        }

        public int Update(ShopNum1_Shop_Video shop_Video)
        {
            return 0;
        }

        public int UpdateAudit(string guids, int isAudit)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@isAudit";
            parm.Value = isAudit;
            parms.Add(parm);

           
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_Shop_VideoComment");
            builder.Append(" SET ");
            builder.Append("isAudit = @isAudit" );
            builder.Append(" WHERE ");
            builder.Append("[Guid]"+andSql);
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms.ToArray());
        }

        public int DeleteVideoComment(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_VideoComment  WHERE [Guid] IN (@guids) ",parms);
        }

        public DataTable GetVideoCommentDetailByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable((string.Empty +
                                                 "   SELECT A.*,B.Title  AS  VideoTitle   FROM ShopNum1_VideoComment AS A LEFT JOIN ShopNum1_Video AS B     " +
                                                 "   ON A.VideoGuid=B.Guid    ") + "   WHERE A.Guid=@guid     ",parms);
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
            paraValue[2] = " *  ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_VideoComment";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}