using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MessageInfo_Action : IShopNum1_MessageInfo_Action
    {
        public int Add(ShopNum1_MessageInfo messageInfo, List<string> usermessage)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,Content,sendtime,IsDeleted  ) VALUES (  '",
                    messageInfo.Guid, "',  '", Operator.FilterString(messageInfo.Title), "',  '", messageInfo.Type,
                    "',  '", Operator.FilterString(messageInfo.Content), "',  '", messageInfo.SendTime, "',  ",
                    messageInfo.IsDeleted, " )"
                });
            sqlList.Add(item);
            if (usermessage.Count > 0)
            {
                for (int i = 0; i < usermessage.Count; i++)
                {
                    item = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '"
                        , Guid.NewGuid(), "',  '", usermessage[i], "',  '", messageInfo.MemLoginID, "',  ", 0,
                        ",  '", messageInfo.SendTime, "',  ", 0, ",  '", messageInfo.Guid, "',  ", 0,
                        ",  ", 0, " )"
                    });
                    sqlList.Add(item);
                }
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

        public int Delete_SysMsg(string strArray)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strArray";
            parms[0].Value = strArray;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_MessageInfo set isdeleted=1 where guid in (@strArray)",parms);
        }

        public int DeleteReceive(string guids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                "delete from ShopNum1_MessageInfo where guid in  (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" +
                guids + "))";
            sqlList.Add(item);
            item = "delete from ShopNum1_UserMessage  WHERE Guid IN (" + guids + ") ";
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

        public int DeleteSend(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            if (
                Convert.ToInt32(
                    DatabaseExcetue.ReturnDataTable(
                        "select count(*) as ItmeCount from ShopNum1_UserMessage where MessageInfoGuid  in (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" +
                        guids + "))").Rows[0]["ItmeCount"].ToString()) > 1)
            {
                item = "delete from ShopNum1_UserMessage where guid in (" + guids + ")";
                sqlList.Add(item);
            }
            else
            {
                item =
                    "delete from ShopNum1_MessageInfo where guid in  (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" +
                    guids + "))";
                sqlList.Add(item);
                item = "delete from ShopNum1_UserMessage where guid in (" + guids + ")";
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

        public DataTable Search(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.SendTime as SendTime,B.Content,A.ReplyContent,A.ReplyTime,B.Type, A.IsRead From  ShopNum1_UserMessage A, ShopNum1_MessageInfo B Where a.MessageInfoGuid=b.GUID  and a.Guid=@guid",parms);
        }
        /// <summary>
        /// 根据ID查询这个人的所有消息
        /// </summary>
        /// <param name="MemloginId"></param>
        /// <param name="StartNumber"></param>
        /// <param name="EndNumber"></param>
        /// <returns></returns>
        public DataTable SelectAllSendByMemberID(string MemloginId, int StartNumber, int EndNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginId";
            parms[0].Value = MemloginId;
            parms[1].ParameterName = "@StartNumber";
            parms[1].Value = StartNumber;
            parms[2].ParameterName = "@EndNumber";
            parms[2].Value = EndNumber;
            return
                DatabaseExcetue.ReturnDataTable(
                    "  select * from (select b.Guid,ReceiveID,b.IsRead,b.SendTime,MessageInfoGuid,b.IsDeleted,Content,Title,ROW_NUMBER() OVER(Order by b.[SendTime] DESC ) AS RowNumber from [ShopNum1_UserMessage] as b left join ShopNum1_MessageInfo as c on c.Guid=b.MessageInfoGuid where b.ReceiveID=@memloginId and b.IsDeleted=0) as a where  RowNumber  BETWEEN @StartNumber and @EndNumber", parms);
        }

        /// <summary>
        /// 根据ID查询这个人的未读消息条数
        /// 
        /// </summary>
        /// <param name="MemloginId"></param>
        /// <param name="StartNumber"></param>
        /// <param name="EndNumber"></param>
        /// <returns></returns>
        public string SelectNoReadSendByMemberID(string MemloginId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginId";
            parms[0].Value = MemloginId;
            
            return
                DatabaseExcetue.ReturnDataTable(
                    "  select count(*) as c from (select b.Guid,ReceiveID,b.IsRead,b.SendTime,MessageInfoGuid,b.IsDeleted,Content,Title,ROW_NUMBER() OVER(Order by b.[SendTime] DESC ) AS RowNumber from [ShopNum1_UserMessage] as b left join ShopNum1_MessageInfo as c on c.Guid=b.MessageInfoGuid where b.ReceiveID=@memloginId and b.IsDeleted=0 and b.IsRead=0) as a ", parms).Rows[0]["c"].ToString();
        }

        /// <summary>
        /// 根据GUID查询消息详细信息
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        public DataTable SelectAllSendDetailByGuid(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid;
   
            return
                DatabaseExcetue.ReturnDataTable(
                    "  select Title,Content,MemLoginID,SendTime from ShopNum1_MessageInfo where Guid=@guid and IsDeleted=0", parms);
        }
        /// <summary>
        /// 根据Guid修改已读状态
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public int UpdateIsReadByGuid(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_UserMessage set IsRead=1 where MessageInfoGuid in (@Guid)", parms);
        }

        /// <summary>
        /// 根据GUID删除消息
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int DeleteSendByGuids(string guids)
        {
            

            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                "update  ShopNum1_MessageInfo set IsDeleted=1 where guid in  (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" +
                guids + "))";
            sqlList.Add(item);
            item = "update  ShopNum1_UserMessage set IsDeleted=1  WHERE Guid in (" + guids + ") ";
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




        public DataTable SearchReceive(string SendID, string ReceiveID, string startDate, string endDate, string title,
            string type, int isRead, int isReply, int isDelete)
        {
            object obj2;
            string str = string.Empty;
            str =
                "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.SendTime,B.Content,B.Type, A.ReplyTime,A.ReplyContent,A.IsRead From  ShopNum1_UserMessage A, ShopNum1_MessageInfo B Where a.MessageInfoGuid=b.GUID";
            if (Operator.FormatToEmpty(SendID) != string.Empty)
            {
                str = str + " AND A.SendID LIKE '%" + Operator.FilterString(SendID) + "%'";
            }
            if (Operator.FormatToEmpty(ReceiveID) != string.Empty)
            {
                str = str + " AND A.ReceiveID LIKE '%" + Operator.FilterString(ReceiveID) + "%'";
            }
            if (Operator.FormatToEmpty(startDate) != string.Empty)
            {
                str = str + " AND A.SendTime>='" + Operator.FilterString(startDate) + "' ";
            }
            if (Operator.FormatToEmpty(endDate) != string.Empty)
            {
                str = str + " AND A.SendTime<='" + Operator.FilterString(endDate) + "' ";
            }
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND B.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (type != "-1")
            {
                str = str + " AND B.Type ='" + Operator.FilterString(type) + "' ";
            }
            if (isRead != -1)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsRead =", isRead, " "});
            }
            if (isReply == 0)
            {
                str = str + " AND A.ReplyTime is null";
            }
            if (isReply == 1)
            {
                str = str + " AND A.ReplyTime is not null";
            }
            if ((isDelete == 0) || (isDelete == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsDeleted =", isDelete, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by A.SendTime Desc ");
        }

        public DataTable SearchSend(string SendID, string ReceiveID, string startDate, string endDate, string title,
            string type, int isRead, int isDelete)
        {
            object obj2;
            string str = string.Empty;
            str =
                "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.sendtime as createtime,B.Content,B.Type, A.ReplyTime, A.ReplyContent, A.IsRead From  ShopNum1_UserMessage A,ShopNum1_MessageInfo B Where  A.MessageInfoGuid=B.GUID";
            if (Operator.FormatToEmpty(SendID) != string.Empty)
            {
                str = str + " AND A.SendID LIKE '%" + Operator.FilterString(SendID) + "%'";
            }
            if (Operator.FormatToEmpty(ReceiveID) != string.Empty)
            {
                str = str + " AND A.ReceiveID LIKE '%" + Operator.FilterString(ReceiveID) + "%'";
            }
            if (Operator.FormatToEmpty(startDate) != string.Empty)
            {
                str = str + " AND B.sendtime>='" + Operator.FilterString(startDate) + "'";
            }
            if (Operator.FormatToEmpty(endDate) != string.Empty)
            {
                str = str + " AND B.sendtime<='" + Operator.FilterString(endDate) + "' ";
            }
            if (title != "")
            {
                str = str + " AND B.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (type != "-1")
            {
                str = str + " AND B.Type ='" + Operator.FilterString(type) + "' ";
            }
            if (isRead != -1)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsRead =", isRead, " "});
            }
            if ((isDelete == 0) || (isDelete == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsDeleted =", isDelete, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by A.SendTime Desc");
        }

        public DataTable SelectSysMsg_Detail(ShopNum1_MessageInfo shopNum1_MessageInfo)
        {
            string str = "SELECT * FROM ShopNum1_MessageInfo where IsDeleted=0 ";
            Guid guid = shopNum1_MessageInfo.Guid;
            if (shopNum1_MessageInfo.Guid != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, " and Guid='", shopNum1_MessageInfo.Guid, "'"});
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by sendtime desc");
        }

        public DataTable SelectSysMsg_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "Guid,isread,sendtime,title";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_MessageInfo";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "sendtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update(ShopNum1_MemberMessage memberMessage)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_UserMessage SET WHERE Guid='" + memberMessage.Guid + "' ");
        }

        public int Update_SysMsgIsRead(string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            return DatabaseExcetue.RunNonQuery("update ShopNum1_MessageInfo set isread=1 where guid=@strGuid",parms);
        }

        public DataTable Get_SysMsgTitle(string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  Title FROM     ShopNum1_MessageInfo     where Guid=@strGuid", parms);
        }

        public DataTable SelectSysUserMsg_List(CommonPageModel commonModel)
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
            paraValue[3] = "ShopNum1_UserMessage";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "SendTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update_SysUserMsgIsRead(string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            return DatabaseExcetue.RunNonQuery("update ShopNum1_UserMessage set IsRead=1 where Guid=@strGuid",parms);
        }
    }
}