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
    public class ShopNum1_Email_Action : IShopNum1_Email_Action
    {
        public int Add(ShopNum1_Email email)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Email( Guid, TypeName, Title, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted  ) VALUES (  '"
                , email.Guid, "',  '", Operator.FilterString(email.TypeName), "',  '",
                Operator.FilterString(email.Title), "',  '", Operator.FilterString(email.Remark), "',  '",
                Operator.FilterString(email.Description), "',  '", email.CreateUser, "', '",
                Convert.ToDateTime(email.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "',  '", email.ModifyUser,
                "' , '", Convert.ToDateTime(email.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"), "',  ",
                email.IsDeleted, " )"
            }));
        }

        public int AddEmailGroupSend(ShopNum1_EmailGroupSend emailGroupSend)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_EmailGroupSend(  Guid,  SendObject,  SendObjectEmail,  EmailTitle,  State,  EmailGuid,  CreateTime  ) VALUES (  '"
                        , emailGroupSend.Guid, "',  '", emailGroupSend.SendObject, "',  '",
                        emailGroupSend.SendObjectEmail, "',  '", Operator.FilterString(emailGroupSend.EmailTitle),
                        "',  ", emailGroupSend.State, ",  '", emailGroupSend.EmailGuid, "',  '",
                        Convert.ToDateTime(emailGroupSend.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "' )"
                    }));
        }

        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Email WHERE  Guid"+andSql,parms.ToArray());
        }

        public int Deleted(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_EmailGroupSend WHERE  Guid"+andSql,parms.ToArray()  );
        }

        public int DeleteMemberGroup(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_MemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_MemberGroup  WHERE  Guid IN (" + guids + ")";
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

        public int Email_Group_Add(ShopNum1_MemberGroup memberGroup, List<string> EmailmemberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '"
                , memberGroup.Guid, "', '", memberGroup.Name, "', '", memberGroup.Description, "', '",
                memberGroup.CreateUser, "', '",
                Convert.ToDateTime(memberGroup.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "', '",
                memberGroup.ModifyUser, "', '",
                Convert.ToDateTime(memberGroup.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"), "', ",
                memberGroup.IsDeleted,
                ")"
            });
            sqlList.Add(item);
            if (EmailmemberAssignGroup.Count > 0)
            {
                for (int i = 0; i < EmailmemberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", EmailmemberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.CreateUser, "', '",
                            Convert.ToDateTime(memberGroup.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "')"
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

        public DataTable GetEditInfo(string guid, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "select Guid,TypeName,Title,Remark,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_Email where Guid=@guids" ;
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetEmailGroupSendInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;
            strSql =
                "select  A.SendObjectEmail,  A.SendObject,  A.EmailTitle, B.Remark  from ShopNum1_EmailGroupSend A,ShopNum1_Email B where A.EmailGuid=B.Guid";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND A.Guid =@guids ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_Email where  1=1";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(string title, string typename, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            string str = string.Empty;
            str =
                "SELECT \tA.Guid\t, \tA.Title\t, \tA.Remark\t, \tA.Description\t, \tA.CreateUser\t, \tA.CreateTime\t, \tA.ModifyUser\t, \tA.ModifyTime\t, \tA.IsDeleted\t   FROM ShopNum1_Email A WHERE 0=0 ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
            }
            if (!(Operator.FormatToEmpty(typename) != "-1"))
            {
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by A.ModifyTime desc",parms);
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT Guid\t, MemLoginID\t, AdvancePayment,Email,LoginTime,Name,Score  FROM ShopNum1_Member    WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID = '" + Operator.FilterString(memLoginID) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchEmailContent(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_Email where  1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "-1"))
            {
                strSql = strSql + " AND Guid = '" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchEmailGroupSend(string emailtitle, string strtime1, string strtime2,
            string sendObjectEmail, int state, int istime)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tSendObject\t, \tSendObjectEmail\t, \tEmailTitle\t, \tState\t, \tCreateTime\t, \tTimeSendTime\t, \tEmailGuid,\t \tIsTime    FROM ShopNum1_EmailGroupSend where  1=1";
            if (Operator.FormatToEmpty(emailtitle) != string.Empty)
            {
                str = str + " AND EmailTitle like '%" + Operator.FilterString(emailtitle) + "%'";
            }
            if (Operator.FormatToEmpty(strtime1) != string.Empty)
            {
                str = str + " AND CreateTime>='" + Operator.FilterString(strtime1) + "' ";
            }
            if (Operator.FormatToEmpty(strtime2) != string.Empty)
            {
                str = str + " AND CreateTime<='" + Operator.FilterString(strtime2) + "' ";
            }
            if (Operator.FormatToEmpty(sendObjectEmail) != string.Empty)
            {
                str = str + " AND SendObject like  '%" + Operator.FilterString(sendObjectEmail) + "%'";
            }
            if (((state == 0) || (state == 1)) || (state == 2))
            {
                str = string.Concat(new object[] {str, " AND State =", state, " "});
            }
            if (istime == 0)
            {
                str = string.Concat(new object[] {str, " AND IsTime =", istime, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc");
        }

        public DataTable SearchEmailMemberAssignGroup(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, B.Tel, A.MemberGroupGuid  FROM ShopNum1_MemberAssignGroup A,  ShopNum1_Member B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid = '" +
                    guid + "'");
        }

        public DataTable SearchMemberGroup(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MemberGroup  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                str = string.Concat(new object[] { str, " AND IsDeleted =@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc",parms);
        }

        public DataTable SearchMemberGroup(string guid)
        {
            string strSql = string.Empty;
            string str2 = guid.Replace("'", "");
            strSql = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MemberGroup  where 1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "0"))
            {
                strSql = strSql + " AND Guid = '" + str2 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(ShopNum1_EmailGroupSend emailGroupSend)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "Update  ShopNum1_EmailGroupSend  set  State=", emailGroupSend.State, "  WHERE  Guid ='",
                        emailGroupSend.Guid, " '"
                    }));
        }

        public int Update(string guid, ShopNum1_Email email)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Email SET  TypeName='" +
                                            Operator.FilterString(email.TypeName) + "', Title='" +
                                            Operator.FilterString(email.Title) + "', Remark='" +
                                            Operator.FilterString(email.Remark) + "', Description='" +
                                            Operator.FilterString(email.Description) + "', ModifyUser='" +
                                            email.ModifyUser + "', ModifyTime='" +
                                            Convert.ToDateTime(email.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss") +
                                            "'WHERE Guid=@guid",parms);
        }

        public int UpdateEmailMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_MemberGroup SET  Name ='", memberGroup.Name, "', Description ='",
                    memberGroup.Description, "', CreateUser ='", memberGroup.ModifyUser, "', CreateTime ='",
                    Convert.ToDateTime(memberGroup.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"), "'WHERE Guid='",
                    memberGroup.Guid, "'"
                });
            sqlList.Add(item);
            item = "Delete from ShopNum1_MemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.ModifyUser, "', '",
                            Convert.ToDateTime(memberGroup.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"), "')"
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