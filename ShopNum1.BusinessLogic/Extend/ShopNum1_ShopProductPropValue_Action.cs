using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopProductPropValue_Action : IShopNum1_ShopProductPropValue_Action
    {
        public DataTable BindProductProp(string Code)
        {
            string strSql = string.Empty;
            strSql = "SELECT ID,PropName FROM ShopNum1_ShopProductProp";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int DeleteShopPropValue(string strId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            return DatabaseExcetue.RunNonQuery("Delete from ShopNum1_ShopProductPropValue where id=@strId",parms);
        }

        public bool Exists(int ID)
        {
            int num;
            SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
            var builder = new StringBuilder();
            builder.Append("select count(1) from ShopNum1_ShopProductPropValue where ID=@ID ");
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder.ToString());
            sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, ID);
            object objA = sqlDatabase.ExecuteScalar(sqlStringCommand);
            if (Equals(objA, null) || Equals(objA, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(objA.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        public int GetMaxOrderId()
        {
            string str = "select max(OrderID)+1 from ShopNum1_ShopProductPropValue";
            object obj2 = DatabaseExcetue.GetSqlDatabase().ExecuteScalar(CommandType.Text, str);
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                return int.Parse(obj2.ToString());
            }
            return 1;
        }

        public string GetPropValue(string strID)
        {
            return
                DatabaseExcetue.ReturnString("select name from ShopNum1_ShopProductPropValue where id='" + strID + "'");
        }

        public DataTable GetPropValuesByPropID(string string_0)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "SELECT ID,Name,orderid FROM ShopNum1_ShopProductPropValue WHERE PropId={0} order by orderid asc",
                        string_0));
        }

        public DataTable BindProductPropValue(string PropId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@PropId";
            parms[0].Value = PropId;
            string strSql = string.Empty;
            strSql =
                "SELECT ID,Name,PropID FROM ShopNum1_ShopProductPropValue WHERE 1=1 And Id in(select PropValueID from ShopNum1_ShopProRelateProp) ";
            if (PropId != "")
            {
                strSql = strSql + " And  PropId=@PropId";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable dt_SubProp(string strProId, string strPid)
        {
            try
            {
                strPid = (((strPid == "") || (strPid == "0")) || (strPid.Length != 0x24))
                    ? "null"
                    : ("'" + strPid + "'");
                return
                    DatabaseExcetue.ReturnDataTable(
                        "SELECT id,PropId,name,(SELECT top 1 InputValue FROM ShopNum1_ShopProRelateProp WHERE PropValueID=t.id and productguid=" +
                        strPid +
                        ")iv,(SELECT TOP 1 'true' FROM ShopNum1_ShopProRelateProp WHERE PropValueID=t.id and productguid=" +
                        strPid + ")vcheck FROM ShopNum1_ShopProductPropValue t where PropId='" + strProId +
                        "' ORDER BY orderid asc");
            }
            catch
            {
                return
                    DatabaseExcetue.ReturnDataTable(
                        "SELECT id,PropId,name,''iv,''vcheck FROM ShopNum1_ShopProductPropValue t WHERE PropId='" +
                        strProId + "' ORDER BY OrderId ASC");
            }
        }

        public int Update(List<ShopNum1_ShopProductPropValue> ShopProductPropValue)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_ShopProductPropValue set ");
            builder.Append("PropId=@PropId,");
            builder.Append("Name=@Name,");
            builder.Append("OrderID=@OrderID");
            builder.Append(" where ID=@ID ");
            Database sqlDatabase = DatabaseExcetue.GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder.ToString());
            int result = 0;
            foreach (ShopNum1_ShopProductPropValue value2 in ShopProductPropValue)
            {
                sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, value2.ID);
                sqlDatabase.AddInParameter(sqlStringCommand, "PropId", DbType.Int32, value2.PropId);
                sqlDatabase.AddInParameter(sqlStringCommand, "Name", DbType.String, value2.Name);
                sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, value2.OrderID);
                if (!int.TryParse(sqlDatabase.ExecuteScalar(sqlStringCommand).ToString(), out result))
                {
                    result++;
                }
            }
            return result;
        }
    }
}