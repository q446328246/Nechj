using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PreventIp_Action : IShopNum1_PreventIp_Action
    {
        public bool CheckedUser(string userIP, string Type)
        {
            bool flag = true;
            foreach (DataRow row in method_0(Type).Rows)
            {
                if ((DateTime.Parse(row["StartTime"].ToString()) <= DateTime.Now) &&
                    (DateTime.Now <= DateTime.Parse(row["EndTime"].ToString())))
                {
                    long num = DoGetIPValue(userIP);
                    if ((DoGetIPValue(row["StartIp"].ToString()) <= num) &&
                        (num <= DoGetIPValue(row["EndIp"].ToString())))
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }

        public int Delete(string guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("delete ShopNum1_PreventIp where guid='" + guid.Replace("'", "") + "'", new object[0]));
        }

        public DataTable GetEditInfo(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp where guid='" +
                    guid.Replace("'", "") + "'");
        }

        public int Insert(ShopNum1_PreventIp shopNum1_PreventIp)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_PreventIp (Guid,StartIp,EndIp,Memo,LockPeople,StartTime,EndTime,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted ) values ('"
                , shopNum1_PreventIp.Guid, "','", shopNum1_PreventIp.StartIp, "','", shopNum1_PreventIp.EndIp, "','"
                , shopNum1_PreventIp.Memo, "','", shopNum1_PreventIp.LockPeople, "','", shopNum1_PreventIp.StartTime
                , "','", shopNum1_PreventIp.EndTime, "','", shopNum1_PreventIp.CreateUser,
                "','", shopNum1_PreventIp.CreateTime, "','", shopNum1_PreventIp.ModifyUser, "','",
                shopNum1_PreventIp.ModifyTime, "','", shopNum1_PreventIp.IsDeleted, "' )"
            }));
        }

        public DataTable Search()
        {
            string strSql =
                "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(ShopNum1_PreventIp shopNum1_PreventIp)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE ShopNum1_PreventIp SET StartIp='", shopNum1_PreventIp.StartIp, "',EndIp='",
                shopNum1_PreventIp.EndIp, "',Memo='", shopNum1_PreventIp.Memo, "',LockPeople='",
                shopNum1_PreventIp.LockPeople, "',StartTime='", shopNum1_PreventIp.StartTime, "',EndTime='",
                shopNum1_PreventIp.EndTime, "',ModifyUser='", shopNum1_PreventIp.ModifyUser, "',ModifyTime='",
                shopNum1_PreventIp.ModifyTime,
                "'WHERE GUID='", shopNum1_PreventIp.Guid, "'"
            }));
        }

        public long DoGetIPValue(string IP)
        {
            string[] strArray = IP.Split(new[] {'.'});
            string str = string.Empty;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length == 1)
                {
                    str = str + "00" + strArray[i];
                }
                if (strArray[i].Length == 2)
                {
                    str = str + "0" + strArray[i];
                }
                if (strArray[i].Length == 3)
                {
                    str = str + strArray[i];
                }
            }
            return Convert.ToInt64(str);
        }

        private DataTable method_0(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp where LockPeople=@string_0",parms);
        }
    }
}