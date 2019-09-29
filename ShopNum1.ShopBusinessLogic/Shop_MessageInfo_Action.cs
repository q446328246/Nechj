using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_MessageInfo_Action : IShop_MessageInfo_Action
    {
        public int Add(ShopNum1_MessageInfo agentMessageInfo, List<string> receiveMemLoginID, string sendMemLoginID,
            string receiveMemType, string sendMemType)
        {
            var sqlList = new List<string>();
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_MessageInfo");
            builder.Append("(Guid,");
            builder.Append("[Title],");
            builder.Append("[CreateTime],");
            builder.Append("[Content], ");
            builder.Append("[Type]) ");
            builder.Append("VALUES ");
            builder.Append("('" + agentMessageInfo.Guid + "',");
            builder.Append("'" + Operator.FilterString(agentMessageInfo.Title) + "',");
            builder.Append("'" + Operator.FilterString(agentMessageInfo.Content) + "',");
            builder.Append(agentMessageInfo.Type + ")");
            sqlList.Add(builder.ToString());
            for (int i = 0; i < receiveMemLoginID.Count; i++)
            {
                builder.Length = 0;
                builder.Append("INSERT INTO ShopNum1_MemberMessage");
                builder.Append("(Guid,");
                builder.Append("MessageInfoGuid,");
                builder.Append("ReceiveMemLoginID,");
                builder.Append("ReceiveMemType,");
                builder.Append("SendMemType,");
                builder.Append("SendMemLoginID ) ");
                builder.Append("VALUES ");
                builder.Append("(newid(),");
                builder.Append("'" + agentMessageInfo.Guid + "',");
                builder.Append("'" + receiveMemLoginID[i] + "',");
                builder.Append(receiveMemType + ",");
                builder.Append(sendMemType + ",");
                builder.Append("'" + sendMemLoginID + "')");
                sqlList.Add(builder.ToString());
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

        public int DeleteReceive(string guids)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_MemberMessage ");
            builder.Append("SET ReceiveIsDeleted = 1 ");
            builder.Append("WHERE Guid IN (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int DeleteSend(string guids)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_MemberMessage ");
            builder.Append("SET SendIsDeleted = 1 ");
            builder.Append("WHERE Guid IN (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public string GetMessageInfoGuid(string memberMessageGuid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT MessageInfoGuid FROM ShopNum1_MemberMessage WHERE Guid = " + memberMessageGuid);
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public void IsRead(string memberMessageGuid)
        {
            var builder = new StringBuilder();
            builder.Append("IF((SELECT COUNT(1) FROM ShopNum1_MemberMessage WHERE Guid = " + memberMessageGuid +
                           ") = 1) BEGIN UPDATE Agent_MemberMessage SET IsRead = 1 WHERE Guid = " + memberMessageGuid +
                           " END");
            DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable SearchReceive(string sendMemLoginID, string isRead, string title, string createTime1,
            string createTime2, string sendMemType, string receiveMemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("b.Title,");
            builder.Append("b.[Content],");
            builder.Append("b.CreateTime,");
            builder.Append("b.Type,");
            builder.Append("c.Name as SendMemberName,");
            builder.Append("a.* ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_MemberMessage AS a,");
            builder.Append("ShopNum1_MessageInfo AS b, ");
            builder.Append("ShopNum1_Member AS c ");
            builder.Append("WHERE ");
            builder.Append("a.SendMemLoginID=c.MemLoginID ");
            builder.Append("And a.MessageInfoGuid = b.Guid ");
            builder.Append("AND ReceiveIsDeleted = 0 ");
            builder.Append("AND ReceiveMemLoginID = '" + receiveMemLoginID + "'");
            if (isRead != "-1")
            {
                builder.Append(" AND IsRead = " + isRead);
            }
            if (!string.IsNullOrEmpty(title))
            {
                builder.Append(" AND b.Title LIKE '%" + Operator.FilterString(title) + "%'");
            }
            if (!string.IsNullOrEmpty(createTime1))
            {
                builder.Append(" AND b.CreateTime >= '" + createTime1 + "'");
            }
            if (!string.IsNullOrEmpty(createTime2))
            {
                builder.Append(" b.AND CreateTime <= '" + createTime2 + "'");
            }
            if (!string.IsNullOrEmpty(sendMemLoginID))
            {
                builder.Append(" AND c.Name LIKE '%" + Operator.FilterString(sendMemLoginID) + "%'");
            }
            if (sendMemType != "-1")
            {
                builder.Append(" AND SendMemType = " + sendMemType);
            }
            builder.Append(" ORDER BY b.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchSend(string receiveMemLoginID, string isRead, string title, string createTime1,
            string createTime2, string receiveMemType, string sendMemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("b.Title,");
            builder.Append("b.[Content],");
            builder.Append("b.CreateTime,");
            builder.Append("[Type], ");
            builder.Append("c.Name as MemberName,");
            builder.Append("a.* ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_MemberMessage AS a,");
            builder.Append("ShopNum1_MessageInfo AS b, ");
            builder.Append("ShopNum1_Member AS c ");
            builder.Append("WHERE ");
            builder.Append("a.MessageInfoGuid = b.Guid ");
            builder.Append("AND a.ReceiveMemLoginID=c.MemLoginID  ");
            builder.Append("AND SendIsDeleted = 0 ");
            builder.Append("AND SendMemLoginID = '" + sendMemLoginID + "'");
            if (isRead != "-1")
            {
                builder.Append(" AND IsRead = " + isRead);
            }
            if ((title != "") && (title != null))
            {
                builder.Append(" AND Title LIKE '%" + title + "%'");
            }
            if ((createTime1 != "") && (createTime1 != null))
            {
                builder.Append(" AND CreateTime >= '" + createTime1 + "'");
            }
            if ((createTime2 != "") && (createTime2 != null))
            {
                builder.Append(" AND CreateTime <= '" + createTime2 + "'");
            }
            if ((receiveMemLoginID != "") && (receiveMemLoginID != null))
            {
                builder.Append(" AND C.Name LIKE '%" + receiveMemLoginID + "%'");
            }
            if (receiveMemType != "-1")
            {
                builder.Append(" AND ReceiveMemType = " + receiveMemType);
            }
            builder.Append(" ORDER BY b.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SelectByGuid(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("b.Title,");
            builder.Append("b.[Content],");
            builder.Append("b.CreateTime,");
            builder.Append("b.Type,");
            builder.Append("c.Name as SendMemberName,");
            builder.Append("a.* ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_MemberMessage AS a,");
            builder.Append("ShopNum1_MessageInfo AS b, ");
            builder.Append("ShopNum1_Member AS c ");
            builder.Append("WHERE ");
            builder.Append("a.SendMemLoginID=c.MemLoginID ");
            builder.Append(" and a.MessageInfoGuid = b.Guid ");
            builder.Append(" AND ");
            builder.Append(" b.Guid = '" + guid + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SelectMemberByGuid(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("ReceiveMemLoginID,");
            builder.Append("ReceiveMemType,");
            builder.Append("SendMemType,");
            builder.Append("SendMemLoginID,");
            builder.Append(
                " (select Name from ShopNum1_Member where ShopNum1_MemberMessage.SendMemLoginID=ShopNum1_Member.MemLoginID) as SendName ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_MemberMessage ");
            builder.Append("WHERE ");
            builder.Append("Guid = " + guid);
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int UpdateReadState(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_MemberMessage ");
            builder.Append("SET IsRead = 1 ");
            builder.Append("WHERE Guid = '" + guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}