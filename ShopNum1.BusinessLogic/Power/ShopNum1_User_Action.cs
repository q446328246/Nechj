﻿using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_User_Action : IShopNum1_User_Action
    {
        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="strGrouplList"></param>
        /// <returns></returns>
        public int Add(ShopNum1_User user, List<string> strGrouplList)
        {
            var sqlList = new List<string>();
            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_User( Guid,  LoginId, Pwd, RealName, Sex, DeptGuid, IsSuperAdmin, Age,WorkNumber, Email, Telephone, IsForbid, LoginTimes, LastLoginIP, LastLoginTime, LastModifyPasswordTime, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted,   PeopleType ) VALUES (  '"
                , user.Guid, "',  '", Operator.FilterString(user.LoginId), "',  '", Operator.FilterString(user.Pwd),
                "',  '", Operator.FilterString(user.RealName), "',  ", user.Sex, ",  '", user.DeptGuid, "',  0,  ",
                user.Age, ",  '", Operator.FilterString(user.WorkNumber),
                "',  '", Operator.FilterString(user.Email), "',  '", Operator.FilterString(user.Telephone), "',  ",
                user.IsForbid, ",  ", user.LoginTimes, ",  '", user.LastLoginTime, "',  '",
                Operator.FilterString(user.LastLoginIP), "',  '", user.LastModifyPasswordTime, "',  '",
                user.CreateUser,
                "', '", user.CreateTime, "',  '", user.ModifyUser, "' , '", user.ModifyTime, "',  '", user.IsDeleted
                , "',  ", user.PeopleType, ")"
            });
            sqlList.Add(item);
            for (int i = 0; i < strGrouplList.Count; i++)
            {
                string str2 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                        , strGrouplList[i], "',  '", user.Guid, "',  '", user.CreateUser, "', '", user.CreateTime,
                        "',  '", user.ModifyUser, "' , '", user.ModifyTime, "',  ", user.IsDeleted, ")"
                    });
                sqlList.Add(str2);
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

        /// <summary>
        ///     添加用户及对应用户组
        /// </summary>
        /// <param name="user"></param>
        /// <param name="GroupUser"></param>
        /// <param name="strGrouplList"></param>
        /// <returns></returns>
        public int Add(ShopNum1_User user, ShopNum1_GroupUser GroupUser, List<string> strGrouplList)
        {
            var sqlList = new List<string>();
            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_User( Guid,  LoginId, Pwd, RealName, Sex, DeptGuid, IsSuperAdmin, Age,WorkNumber, Email, Telephone, IsForbid, LoginTimes, LastLoginIP, LastLoginTime, LastModifyPasswordTime, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted,   PeopleType ) VALUES (  '"
                , user.Guid, "',  '", Operator.FilterString(user.LoginId), "',  '", Operator.FilterString(user.Pwd),
                "',  '", Operator.FilterString(user.RealName), "',  ", user.Sex, ",  '", user.DeptGuid, "',  0,  ",
                user.Age, ",  '", Operator.FilterString(user.WorkNumber),
                "',  '", Operator.FilterString(user.Email), "',  '", Operator.FilterString(user.Telephone), "',  ",
                user.IsForbid, ",  ", user.LoginTimes, ",  '", user.LastLoginTime, "',  '",
                Operator.FilterString(user.LastLoginIP), "',  '", user.LastModifyPasswordTime, "',  '",
                user.CreateUser,
                "', '", user.CreateTime, "',  '", user.ModifyUser, "' , '", user.ModifyTime, "',  '", user.IsDeleted
                , "',  ", user.PeopleType, ")"
            });
            sqlList.Add(item);
            string str2 =
                string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                    , GroupUser.GroupGuid, "',  '", user.Guid, "',  '", user.CreateUser, "', '", user.CreateTime,
                    "',  '", user.ModifyUser, "' , '", user.ModifyTime, "',  ", user.IsDeleted, ")"
                });
            sqlList.Add(str2);
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

        /// <summary>
        ///     登录验证
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="string_0"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public int CheckLogin(string loginID, string pwd, int isDeleted)
        {
            int count = 0;
            string strSql = string.Empty;
            strSql = "SELECT Guid, LoginId,Pwd,RealName, IsDeleted, IsForbid,DeptGuid FROM ShopNum1_User WHERE 0=0";
            if (loginID != string.Empty)
            {
                strSql = strSql + " AND LoginID='" + Operator.FilterString(loginID) + "'";
            }
            if (pwd != string.Empty)
            {
                strSql = strSql + " AND Pwd='" + Operator.FilterString(pwd) + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=", isDeleted, " "});
            }
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return 0;
            }
            count = table.Rows.Count;
            if (count > 0)
            {
                if (table.Rows[0]["IsForbid"].ToString() == "1")
                {
                    count = -1;
                    return -1;
                }
                return count;
            }
            return count;
        }

        /// <summary>
        ///     删除用户组下所有用户
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int Delete(string guids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "DELETE FROM ShopNum1_GroupUser WHERE UserGuid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_User WHERE Guid IN (" + guids + ")";
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

        /// <summary>
        ///     查询部门内的用户
        /// </summary>
        /// <param name="deptGuid"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        public DataTable GetUserByDept(string deptGuid, int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@deptGuid";
            parms[0].Value = deptGuid;
            parms[1].ParameterName = "@IsDeleted";
            parms[1].Value = IsDeleted;
            
            string strSql = string.Empty;
            strSql = "SELECT Guid, LoginId, RealName, IsDeleted, DeptGuid FROM ShopNum1_User WHERE 0=0";
            if (deptGuid != string.Empty)
            {
                strSql = strSql + " AND DeptGuid=@deptGuid";
            }
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@IsDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        /// <summary>
        ///     根据用户ID查找用户
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        public DataTable GetUserByGuid(string guid, int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@IsDeleted";
            parms[1].Value = IsDeleted;
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid, A.LoginId, A.Pwd, A.RealName, A.Sex, A.Age, A.WorkNumber, A.Email, A.Telephone, A.IsForbid, A.LoginTimes, A.LastLoginTime, A.LastLoginIP, A.LastModifyPasswordTime,  A.CreateUser, A.CreateTime, A.ModifyUser, A.ModifyTime, A.IsDeleted, A.DeptGuid,B.GroupGuid FROM ShopNum1_User AS A LEFT JOIN ShopNum1_GroupUser AS B ON  A.Guid=B.UserGuid WHERE 0=0";
            if (guid != string.Empty)
            {
                strSql = strSql + " AND A.Guid=@guid";
            }
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND A.IsDeleted=@IsDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        /// <summary>
        ///     根据用户登录ID查询用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        public DataTable GetUserByLoginID(string loginID, int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@loginID";
            parms[0].Value = loginID;
            parms[1].ParameterName = "@IsDeleted";
            parms[1].Value = IsDeleted;
            string strSql = string.Empty;
            strSql = "SELECT Guid, LoginId, RealName, IsDeleted, DeptGuid, PeopleType FROM ShopNum1_User WHERE 0=0";
            if (loginID != string.Empty)
            {
                strSql = strSql + " AND LoginID=@loginID";
            }
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@IsDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        /// <summary>
        ///     根据用户名、部门查询用户
        /// </summary>
        /// <param name="realName"></param>
        /// <param name="deptGuid"></param>
        /// <param name="isForbid"></param>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        public DataTable Search(string realName, string deptGuid, int isForbid, int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@realName";
            parms[0].Value = Operator.FilterString(realName);
            parms[1].ParameterName = "@deptGuid";
            parms[1].Value = deptGuid;
            parms[2].ParameterName = "@isForbid";
            parms[2].Value = isForbid;
            parms[3].ParameterName = "@IsDeleted";
            parms[3].Value = IsDeleted;
            string str = string.Empty;
            str =
                "SELECT A.Guid, A.LoginId, A.Pwd, A.RealName, A.Sex, A.DeptGuid, A.Age, A.WorkNumber, A.Email, A.Telephone, A.IsForbid, A.LoginTimes, A.LastLoginTime, A.LastLoginIP,  A.LastModifyPasswordTime, A.CreateUser, A.CreateTime, A.ModifyUser, A.ModifyTime, A.IsDeleted, B.Name AS DeptName  FROM ShopNum1_User AS A LEFT JOIN ShopNum1_Dept  AS B ON  A.DeptGuid=B.Guid WHERE 0=0 ";
            if (((realName != string.Empty) && (realName != "")) && (realName != null))
            {
                str = str + " AND A.loginid Like '%@realName%'";
            }
            if ((deptGuid != string.Empty) && (deptGuid != "-1"))
            {
                str = str + " AND A.DeptGuid=@deptGuid";
            }
            if ((isForbid == 0) || (isForbid == 1))
            {
                str = string.Concat(new object[] {str, " AND A.IsForbid=@isForbid"});
            }
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND A.IsDeleted=@IsDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by A.CreateTime Desc",parms);
        }

        /// <summary>
        ///     查找系统管理员
        /// </summary>
        /// <returns></returns>
        public string SearchSupperAdminName()
        {
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchSupperAdminName");
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0]["LoginId"].ToString();
            }
            return "";
        }

        /// <summary>
        ///     更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="strGrouplList"></param>
        /// <returns></returns>
        public int Update(ShopNum1_User user, List<string> strGrouplList)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (user.Pwd != null)
            {
                item = string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_User SET  Pwd='", Operator.FilterString(user.Pwd), "', RealName='",
                    Operator.FilterString(user.RealName), "', Sex=", user.Sex, ", DeptGuid='", user.DeptGuid,
                    "', Age=", user.Age, ", WorkNumber='", Operator.FilterString(user.WorkNumber), "', Email='",
                    Operator.FilterString(user.Email), "', Telephone='", Operator.FilterString(user.Telephone),
                    "', IsForbid=", user.IsForbid, ", ModifyUser='", user.ModifyUser, "', LastModifyPasswordTime='",
                    user.LastModifyPasswordTime, "', ModifyTime='", user.ModifyTime, "', PeopleType='",
                    user.PeopleType, "'WHERE Guid='", user.Guid, "'"
                });
            }
            else
            {
                item = string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_User SET  RealName='", Operator.FilterString(user.RealName), "', Sex=",
                    user.Sex, ", DeptGuid='", user.DeptGuid, "', Age=", user.Age, ", WorkNumber='",
                    Operator.FilterString(user.WorkNumber), "', Email='", Operator.FilterString(user.Email),
                    "', Telephone='", Operator.FilterString(user.Telephone), "', IsForbid=", user.IsForbid,
                    ", ModifyUser='", user.ModifyUser, "', ModifyTime='", user.ModifyTime, "', PeopleType='",
                    user.PeopleType, "'WHERE Guid='", user.Guid, "'"
                });
            }
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_GroupUser WHERE  UserGuid='" + user.Guid + "'";
            sqlList.Add(item);
            for (int i = 0; i < strGrouplList.Count; i++)
            {
                string str2 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                        , strGrouplList[i], "',  '", user.Guid, "',  '", user.ModifyUser, "', '", user.ModifyTime,
                        "',  '", user.ModifyUser, "' , '", user.ModifyTime, "',  ", user.IsDeleted, ")"
                    });
                sqlList.Add(str2);
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

        /// <summary>
        ///     更新用户登录信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateLoginInfo(ShopNum1_User user)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_User SET LoginTimes=LoginTimes+1, LastLoginTime='", user.LastLoginTime,
                        "', LastLoginIP='", user.LastLoginIP, "'WHERE LoginId='", user.LoginId, "'"
                    }));
        }

        /// <summary>
        ///     更新用户密码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string name, string oldPwd, string newPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@name";
            parms[0].Value = name;
            parms[1].ParameterName = "@oldPwd";
            parms[1].Value = oldPwd;
            parms[2].ParameterName = "@newPwd";
            parms[2].Value = newPwd;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_User set Pwd=@newPwd,LastModifyPasswordTime='" +
                                            DateTime.Now + "'  where Pwd=@oldPwd and LoginId=@name",parms);
        }
    }
}