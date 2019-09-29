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
    public class ShopNum1_Dept_Action : IShopNum1_Dept_Action
    {
        /// <summary>
        ///     新增部门
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public int Add(ShopNum1_Dept dept)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Dept( Guid,  Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , dept.Guid, "',  '", Operator.FilterString(dept.Name), "',  '",
                Operator.FilterString(dept.ShortName), "',  '", dept.CreateUser, "', '", dept.CreateTime, "',  '",
                dept.ModifyUser, "' , '", dept.ModifyTime, "',  ", dept.IsDeleted,
                ")"
            }));
        }

        /// <summary>
        ///     新增加部门，并配置用户部门属性
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="userguids"></param>
        /// <returns></returns>
        public int Add(ShopNum1_Dept dept, string userguids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Dept( Guid,  Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , dept.Guid, "',  '", Operator.FilterString(dept.Name), "',  '",
                Operator.FilterString(dept.ShortName), "',  '", dept.CreateUser, "', '", dept.CreateTime, "',  '",
                dept.ModifyUser, "' , '", dept.ModifyTime, "',  ", dept.IsDeleted,
                ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {"UPDATE ShopNum1_User SET        DeptGuid = '", dept.Guid, "' WHERE Guid IN (", userguids, ")"});
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
        ///     删除部门，并部门用户属性至空
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int Delete(string guids)
        {
            
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[]
                {"UPDATE ShopNum1_User SET        DeptGuid = '", Guid.Empty, "' WHERE DeptGuid IN (", guids, ")"});
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_Dept WHERE Guid IN (" + guids + ")";
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
        ///     查询所有部门
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable Search(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Dept WHERE (IsDeleted =@isDeleted) Order by CreateTime Desc",parms);
        }

        /// <summary>
        ///     按部门ID查询
        /// </summary>
        /// <param name="deptGuid"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable Search(string deptGuid, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@deptGuid";
            parms[0].Value = deptGuid;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Dept WHERE 0=0";
            if ((deptGuid != string.Empty) && (deptGuid != "-1"))
            {
                strSql = strSql + " AND Guid=@deptGuid";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        /// <summary>
        ///     更新用户所在部门
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="strUserList"></param>
        /// <returns></returns>
        public int Update(ShopNum1_Dept dept, List<string> strUserList)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_Dept SET  Name='", Operator.FilterString(dept.Name), "', ShortName='",
                    Operator.FilterString(dept.ShortName), "', ModifyUser='", dept.ModifyUser, "', ModifyTime='",
                    dept.ModifyTime, "' WHERE Guid='", dept.Guid, "'"
                });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_User SET DeptGuid='", Guid.Empty, "', ModifyUser='", dept.ModifyUser,
                    "', ModifyTime='", dept.ModifyTime, "' WHERE  DeptGuid='", dept.Guid, "'"
                });
            sqlList.Add(item);
            for (int i = 0; i < strUserList.Count; i++)
            {
                string str2 = string.Empty;
                str2 =
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_User SET DeptGuid='", dept.Guid, "', ModifyUser='", dept.ModifyUser,
                        "', ModifyTime='", dept.ModifyTime, "' WHERE  Guid='", strUserList[i], "'"
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
    }
}