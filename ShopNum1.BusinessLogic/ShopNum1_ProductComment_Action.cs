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
    public class ShopNum1_ProductComment_Action : IShopNum1_ProductComment_Action
    {
        public int Add(ShopNum1_Shop_ProductComment productcomment)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_ProductComment( Guid,CommentType,Speed,Comment,CommentTime,IsDelete,ProductGuid,ProductName,Title,ShopID,MemLoginID,OrderGuid,Attitude,Character,IsAudit ) VALUES ( '"
                , productcomment.Guid, "',", productcomment.CommentType, ",", productcomment.Speed, ",'",
                Operator.FilterString(productcomment.Comment), "','", productcomment.CommentTime, "',",
                productcomment.IsDelete, ",'", productcomment.ProductGuid, "','",
                Operator.FilterString(productcomment.ProductName),
                "','", productcomment.ShopID, "','", productcomment.MemLoginID, "','", productcomment.OrderGuid,
                "', ", productcomment.Attitude, ", ", productcomment.Character, ",", productcomment.IsAudit, ")"
            }));
        }

        public int Add(List<ShopNum1_Shop_ProductComment> listProductComment)
        {
            var sqlList = new List<string>();
            for (int i = 0; i < listProductComment.Count; i++)
            {
                string item = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Shop_ProductComment( Guid,CommentType,Speed,Comment,CommentTime,IsDelete,ProductGuid,ProductName,ProductPrice,Shoploginid,ShopName,ShopID,MemLoginID,OrderGuid,Attitude,Character,IsAudit,shop_category_id ) VALUES ( '"
                    , listProductComment[i].Guid, "',", listProductComment[i].CommentType, ",",
                    listProductComment[i].Speed, ",'", Operator.FilterString(listProductComment[i].Comment), "','",
                    listProductComment[i].CommentTime, "',", listProductComment[i].IsDelete, ",'",
                    listProductComment[i].ProductGuid, "','",
                    Operator.FilterString(listProductComment[i].ProductName),
                    "','", listProductComment[i].ProductPrice, "','", listProductComment[i].ShopLoginId, "','",
                    listProductComment[i].ShopName, "','", listProductComment[i].ShopID, "','",
                    listProductComment[i].MemLoginID, "','", listProductComment[i].OrderGuid, "', ",
                    listProductComment[i].Attitude, ", ", listProductComment[i].Character,
                    ",", listProductComment[i].IsAudit,",",listProductComment[i].shop_category_id, ")"
                });
                sqlList.Add(item);
            }
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

        public DataTable CheckIsComment(string orderguid, string menlogin)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@orderguid";
            parms[0].Value = orderguid;
            parms[1].ParameterName = "@menlogin";
            parms[1].Value = menlogin;
            string str = string.Empty;
            str = "SELECT Guid,CONTINUECOMMENT  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
            return
                DatabaseExcetue.ReturnDataTable((str + " AND OrderGuid in (@orderguid)") +
                                                " AND MemLoginID in (@menlogin)",parms);
        }

        public int DeleteProduct(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "delete from ShopNum1_Shop_ProductComment  WHERE [Guid] IN (" + guids + ") ";
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

        public int DeleteProductComment(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Shop_ProductComment set IsDelete=1  WHERE [Guid] IN (@guids) ",parms);
        }

        public DataTable GetCommentTypeByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT CommentType,IsAudit,ShopID,MemLoginID,ShopLoginId FROM ShopNum1_Shop_ProductComment WHERE Guid IN (@guid)",parms);
        }

        public DataTable GetProductAll(string ProductName, string ShopID, string createMember, string isaudit,
            string createTime1, string createTime2)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("b.Name,");
            builder.Append("b.ProductState,");
            builder.Append("a.ProductGuid,");
            builder.Append("a.MemLoginID,");
            builder.Append("a.ShopID,");
            builder.Append("a.ShopName,");
            builder.Append("a.shopid AS Shopids,");
            builder.Append("a.CommentTime,");
            builder.Append("a.IsAudit");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_ProductComment AS a,");
            builder.Append("ShopNum1_Shop_Product AS b");
            builder.Append(" WHERE a.ProductGuid=b.Guid ");
            if (Operator.FormatToEmpty(ProductName) != string.Empty)
            {
                builder.Append(" AND b.Name LIKE '%" + Operator.FilterString(ProductName) + "%'");
            }
            if (Operator.FormatToEmpty(ShopID) != string.Empty)
            {
                builder.Append(" AND a.ShopName like '%" + ShopID + "%'");
            }
            if (Operator.FormatToEmpty(createMember) != string.Empty)
            {
                builder.Append(" AND a.MemLoginID LIKE '%" + Operator.FilterString(createMember) + "%'");
            }
            if (isaudit != "1")
            {
                builder.Append(" AND a.IsAudit IN(0,2) ");
            }
            else
            {
                builder.Append(" AND a.IsAudit=1 ");
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                builder.Append(" AND a.CommentTime>='" + createTime1 + "' ");
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                builder.Append(" AND a.CommentTime<='" + createTime2 + "' ");
            }
            builder.Append(" ORDER BY a.CommentTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductAll(string ProductName, string ProductGuid, string createMember, string isAudit,
            string createTime1, string createTime2, string memLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("b.Name,");
            builder.Append("a.MemLoginID,");
            builder.Append("a.SendTime,");
            builder.Append("a.IsAudit");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_ProductComment AS a,");
            builder.Append("ShopNum1_Shop_Product AS b");
            builder.Append(" WHERE a.ProductGuid=b.Guid");
            builder.Append(" AND a.MemLoginID='" + memLoginID + "'");
            if (Operator.FormatToEmpty(ProductName) != string.Empty)
            {
                builder.Append(" AND b.Name LIKE '%" + Operator.FilterString(ProductName) + "%'");
            }
            if (Operator.FormatToEmpty(ProductGuid) != string.Empty)
            {
                builder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(ProductGuid) + "%'");
            }
            if (Operator.FormatToEmpty(createMember) != string.Empty)
            {
                builder.Append(" AND a.MemLoginID LIKE '%" + Operator.FilterString(createMember) + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                builder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                builder.Append(" AND a.SendTime>='" + createTime1 + "' ");
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                builder.Append(" AND a.SendTime<='" + createTime2 + "' ");
            }
            builder.Append(" ORDER BY a.SendTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductCommentMemberID(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append(" SELECT ");
            builder.Append(" MemLoginID");
            builder.Append(" FROM ");
            builder.Append("ShopNum1Multi_ProductComment");
            builder.Append(" WHERE guid=@guid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public string GetShopIDByName(string name)
        {
            return DatabaseExcetue.ReturnString(" select ShopID from ShopNum1_ShopInfo where MemLoginID='" + name + "'");
        }

        public DataTable MemberProductComment(string memloginid, string commenttitle, string productname, string shopID,
            string isaudit, string createtime1, string createtime2)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@commenttitle";
            paraValue[1] = commenttitle;
            paraName[2] = "@productname";
            paraValue[2] = productname;
            paraName[3] = "@shopid";
            paraValue[3] = shopID;
            paraName[4] = "@isaudit";
            paraValue[4] = isaudit;
            paraName[5] = "@createtime1";
            paraValue[5] = createtime1;
            paraName[6] = "@createtime2";
            paraValue[6] = createtime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberProductComment", paraName, paraValue);
        }

        public DataTable Search(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql = "SELECT *  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = strSql + " AND Guid in (@guid)";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Search(string orderguid, string menlogin)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@orderguid";
            parms[0].Value = orderguid;
            parms[1].ParameterName = "@menlogin";
            parms[1].Value = menlogin;
            string strSql = string.Empty;
            strSql = "SELECT Guid  FROM ShopNum1_Shop_ProductComment  WHERE 0=0 ";
            if (orderguid != "-1")
            {
                strSql = strSql + " AND OrderGuid in (@orderguid)";
            }
            if (menlogin != "")
            {
                strSql = strSql + " AND MemLoginID in (@menlogin)";
            }
            if (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public DataTable ShopProductComment(string shopid, string commenttitle, string productname, string productguid,
            string createmember, string isaudit, string createtime1, string createtime2)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@commenttitle";
            paraValue[1] = commenttitle;
            paraName[2] = "@productname";
            paraValue[2] = productname;
            paraName[3] = "@productguid";
            paraValue[3] = productguid;
            paraName[4] = "@createmember";
            paraValue[4] = createmember;
            paraName[5] = "@isaudit";
            paraValue[5] = isaudit;
            paraName[6] = "@createtime1";
            paraValue[6] = createtime1;
            paraName[7] = "@createtime2";
            paraValue[7] = createtime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopProductComment", paraName, paraValue);
        }

        public DataTable ShopProductCommentList(string shopid, string commenttitle, string productname, string isreply,
            string createmember, string isaudit, string createtime1,
            string createtime2)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@commenttitle";
            paraValue[1] = commenttitle;
            paraName[2] = "@productname";
            paraValue[2] = productname;
            paraName[3] = "@isreply";
            paraValue[3] = isreply;
            paraName[4] = "@createmember";
            paraValue[4] = createmember;
            paraName[5] = "@isaudit";
            paraValue[5] = isaudit;
            paraName[6] = "@createtime1";
            paraValue[6] = createtime1;
            paraName[7] = "@createtime2";
            paraValue[7] = createtime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopProductCommentList", paraName,
                paraValue);
        }

        public int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(4);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@reply";
            parms[1].Value = reply;
            parms[2].ParameterName = "@replytime";
            parms[2].Value = replytime;
            parms[3].ParameterName = "@BuyerAttitude";
            parms[3].Value = BuyerAttitude;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Shop_ProductComment set Reply=@reply,ReplyTime=@replytime,BuyerAttitude=@BuyerAttitude WHERE [Guid] IN (@guid) ",parms);
        }

        public int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude,
            bool IsContinueComment)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(4);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@reply";
            parms[1].Value = reply;
            parms[2].ParameterName = "@replytime";
            parms[2].Value = replytime;
            parms[3].ParameterName = "@BuyerAttitude";
            parms[3].Value = BuyerAttitude;

            string strSql = string.Empty;
            if (IsContinueComment)
            {
                strSql = "update ShopNum1_Shop_ProductComment set ContinueReply=@reply,ContinueReplyTime=@replytime,ContinueState=2 WHERE Guid = @guid ";
            }
            else
            {
                strSql = "update ShopNum1_Shop_ProductComment set Reply=@reply,ReplyTime=@replytime,BuyerAttitude=@BuyerAttitude WHERE Guid = @guid ";
            }
            return DatabaseExcetue.RunNonQuery(strSql,parms);
        }

        public int UpdateProductAudit(string guids, string state)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            parms[1].ParameterName = "@state";
            parms[1].Value = state;
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_Shop_ProductComment");
            builder.Append(" SET ");
            builder.Append("IsAudit =@state " );
            builder.Append(" WHERE ");
            builder.Append("[Guid] in (@guids)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public int UpdateProductComment(string guid, string content)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
           
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_Shop_ProductComment SET ContinueComment='", Operator.FilterString(content),
                        "',ContinueTime='", DateTime.Now, "',ContinueState=1 WHERE Guid=@guid"
                    }),parms);
        }
    }
}