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
    public class ShopNum1_MMS_Action : IShopNum1_MMS_Action
    {
        public int Add(ShopNum1_MMS email)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMS( Guid, TypeName, Title, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , email.Guid, "',  '", Operator.FilterString(email.TypeName), "',  '",
                Operator.FilterString(email.Title), "',  '", email.Remark, "',  '",
                Operator.FilterString(email.Description), "',  '", email.CreateUser, "', '", email.CreateTime,
                "',  '", email.ModifyUser,
                "' , '", email.ModifyTime, "',  ", email.IsDeleted, ")"
            }));
        }

        public int Add(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMSMemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '"
                , memberGroup.Guid, "', '", memberGroup.Name, "', '", memberGroup.Description, "', '",
                memberGroup.CreateUser, "', '", memberGroup.CreateTime, "', '", memberGroup.ModifyUser, "', '",
                memberGroup.ModifyTime, "', ", memberGroup.IsDeleted,
                ")"
            });
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MMSMemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.CreateUser, "', '", memberGroup.CreateTime, "')"
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

        public int AddMMSGroupSend(ShopNum1_MMSGroupSend MMSGroupSend)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMSGroupSend( Guid, SendObject, SendObjectMMS, MMSTitle, State, CreateTime, IsTime, TimeSendTime, MMSGuid  ) VALUES (  '"
                , MMSGroupSend.Guid, "',  '", Operator.FilterString(MMSGroupSend.SendObject), "',  '",
                Operator.FilterString(MMSGroupSend.SendObjectMMS), "',  '",
                Operator.FilterString(MMSGroupSend.MMSTitle), "',  '", Operator.FilterString(MMSGroupSend.State),
                "',  '", MMSGroupSend.CreateTime, "', '", MMSGroupSend.IsTime, "',  '", MMSGroupSend.TimeSendTime,
                "' , '", MMSGroupSend.MMSGuid, "' )"
            });
            sqlList.Add(item);
            string str2 = Guid.NewGuid().ToString();
            item =
                "INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,MemLoginID,Content,sendtime,OperateUser,IsDeleted  ) VALUES (  '" +
                str2 + "',  '" + Operator.FilterString(MMSGroupSend.MMSTitle) + "',  '1',  '" +
                MMSGroupSend.SendObject.Split(new[] {'-'})[0] + "',  '" +
                Operator.FilterString(MMSGroupSend.SendObjectMMS) + "',  '" + DateTime.Now +
                "' , 'admin' , '0')";
            sqlList.Add(item);
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '"
                , Guid.NewGuid(), "',  '", MMSGroupSend.SendObject.Split(new[] {'-'})[0], "',  'admin',  ", 0,
                ",  '", DateTime.Now.ToString(), "',  ", 0, ",  '", str2, "',  ", 0, ",  ", 0,
                " )"
            });
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

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MMS WHERE  Guid in (@guids)",parms);
        }

        public int Deleted(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MMSGroupSend WHERE  Guid in (@guids)",parms);
        }

        public int DeleteMemberGroup(string guids)
        {

            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_MMSMemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_MMSMemberGroup  WHERE  Guid IN (" + guids + ")";
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

        public DataTable GetEditInfo(string guid, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "select Guid,TypeName,Title,Remark,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMS where Guid=@guid";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetMMSGroupSendInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            
            return
                DatabaseExcetue.ReturnDataTable(
                    "select SendObjectMMS,MMSTitle,sendobjectmms,SendObject from ShopNum1_MMSGroupSend where guid=@guid",parms);
        }

        public DataTable Search(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_MMS where  1=1";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(string title, string typename, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT \tA.Guid\t, \tA.Title\t, \tA.Remark\t, \tA.Description\t, \tA.CreateUser\t, \tA.CreateTime\t, \tA.ModifyUser\t, \tA.ModifyTime\t, \tA.IsDeleted\t   FROM ShopNum1_MMS A  WHERE 0=0 ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND A.IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by A.CreateTime Desc");
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = Operator.FilterString(memLoginID);
            string strSql = string.Empty;
            strSql =
                "SELECT Guid\t, MemLoginID\t, AdvancePayment,Email,LoginTime,Name,Score  FROM ShopNum1_Member    WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID = @memLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchMemberAssignGroup(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, B.Tel, A.MemberGroupGuid  FROM ShopNum1_MMSMemberAssignGroup A,  ShopNum1_Member B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid =@guid",parms);
        }

        public DataTable SearchMemberGroup(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MMSMemberGroup  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                str = string.Concat(new object[] {str, " AND IsDeleted =@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc",parms);
        }

        public DataTable SearchMemberGroup(string guid)
        {
            string strSql = string.Empty;
            string str2 = guid.Replace("'", "");
            strSql = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MMSMemberGroup  where 1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "0"))
            {
                strSql = strSql + " AND Guid = '" + str2 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMMSContent(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = Operator.FilterString(guid);
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_MMS where  1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "-1"))
            {
                strSql = strSql + " AND Guid =@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchMMSGroupSend(string mmstitle, string strtime1, string strtime2, string sendObjectMMS,
            int state, int istime)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tSendObject\t, \tSendObjectMMS\t, \tMMSTitle\t, \tState\t, \tCreateTime\t, \tTimeSendTime\t, \tMMSGuid,\t \tIsTime\t   FROM ShopNum1_MMSGroupSend where  1=1";
            if (Operator.FormatToEmpty(mmstitle) != string.Empty)
            {
                str = str + " AND MMSTitle like '%" + Operator.FilterString(mmstitle) + "%'";
            }
            if (Operator.FormatToEmpty(strtime1) != string.Empty)
            {
                str = str + " AND CreateTime>='" + Operator.FilterString(strtime1) + "' ";
            }
            if (Operator.FormatToEmpty(strtime2) != string.Empty)
            {
                str = str + " AND CreateTime<='" + Operator.FilterString(strtime2) + "' ";
            }
            if (Operator.FormatToEmpty(sendObjectMMS) != string.Empty)
            {
                str = str + " AND SendObject like  '%" + Operator.FilterString(sendObjectMMS) + "%'";
            }
            if (((istime == 0) || (istime == 1)) || (istime == 2))
            {
                str = string.Concat(new object[] {str, " AND State =", state, " "});
            }
            if (istime == 0)
            {
                str = string.Concat(new object[] {str, " AND IsTime =", istime, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc");
        }

        public int Update(ShopNum1_MMSGroupSend mMSGroupSend)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "Update  ShopNum1_MMSGroupSend  set  State=", mMSGroupSend.State,
                        "  FROM ShopNum1_MMSGroupSend WHERE  Guid ='", mMSGroupSend.Guid, " '"
                    }));
        }

        public int Update(string guid, ShopNum1_MMS email)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MMS SET  TypeName='", Operator.FilterString(email.TypeName), "', Title='",
                        Operator.FilterString(email.Title), "', Remark='", email.Remark, "', Description='",
                        Operator.FilterString(email.Description), "', ModifyUser='", email.ModifyUser,
                        "', ModifyTime='", email.ModifyTime, "'WHERE Guid=", guid
                    }));
        }

        public int UpdateMemberAssignGroup(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_MMSMemberGroup SET  Name ='", memberGroup.Name, "', Description ='",
                    memberGroup.Description, "', CreateUser ='", memberGroup.ModifyUser, "', CreateTime ='",
                    memberGroup.ModifyTime, "'WHERE Guid='", memberGroup.Guid, "'"
                });
            sqlList.Add(item);
            item = "Delete from ShopNum1_MMSMemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MMSMemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.ModifyUser, "', '", memberGroup.ModifyTime, "')"
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
    }
}