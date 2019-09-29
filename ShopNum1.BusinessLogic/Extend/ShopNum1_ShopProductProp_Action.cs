using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopProductProp_Action : IShopNum1_ShopProductProp_Action
    {
        public int Delete(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_ShopProductProp ");
            builder.Append(" where ID IN(" + string_0 + ") ");
            SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder.ToString());
            int num = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            int num2 =
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopProductPropValue WHERE PropId IN(" + string_0 +
                                            ")");
            return (num + num2);
        }

        public bool Exists(int ID)
        {
            int num;
            var builder = new StringBuilder();
            builder.Append("select count(1) from ShopNum1_ShopProductProp where ID=@ID ");
            SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
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
            string strSql = "select max(id) from ShopNum1_ShopProductProp";
            object obj2 = DatabaseExcetue.ReturnObject(strSql);
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                return int.Parse(obj2.ToString());
            }
            return 1;
        }

        public DataTable GetSearchListPropByCode(string Code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productcode";
            paraValue[0] = Code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetSearchListPropByCode", paraName, paraValue);
        }

        public DataTable Search_Type_Prop(string strId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    " select ID,PropName,[dbo].[fun_Propstr](id) propDetail,(select typeid from ShopNum1_TypeProp where typeid='" +
                    strId + "' and propid=t.id)ischeck FROM ShopNum1_ShopProductProp as t where 1=1 ");
        }

        public DataTable SelectProByProductGuid(string strGuid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select PropName,ID,showType from ShopNum1_ShopProductProp where id in (select propid from ShopNum1_ShopProRelateProp where productguid='" +
                    strGuid + "') order by orderid asc");
        }

        public int Add(ShopNum1_ShopProductProp model, List<ShopNum1_ShopProductPropValue> shopProductPropValues)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_ShopProductProp(");
            builder.Append("PropName,ShowType,IsImport,Content,OrderID)");
            builder.Append(" values (");
            builder.Append("@PropName,@ShowType,@IsImport,@Content,@OrderID)");
            SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder.ToString());
            sqlDatabase.AddInParameter(sqlStringCommand, "PropName", DbType.String, model.PropName);
            sqlDatabase.AddInParameter(sqlStringCommand, "ShowType", DbType.Byte, model.ShowType);
            sqlDatabase.AddInParameter(sqlStringCommand, "IsImport", DbType.Boolean, model.IsImport);
            sqlDatabase.AddInParameter(sqlStringCommand, "Content", DbType.String, model.Content);
            sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, model.OrderID);
            if (sqlDatabase.ExecuteNonQuery(sqlStringCommand) <= 0)
            {
                return 0;
            }
            if (shopProductPropValues.Count == 0)
            {
                return 1;
            }
            int maxOrderId = GetMaxOrderId();
            var builder2 = new StringBuilder();
            builder2.Append("insert into ShopNum1_ShopProductPropValue(");
            builder2.Append("PropId,Name,OrderID)");
            builder2.Append(" values (");
            builder2.Append("@PropId,@Name,@OrderID)");
            builder2.Append(";select @@IDENTITY");
            int result = 0;
            foreach (ShopNum1_ShopProductPropValue value2 in shopProductPropValues)
            {
                sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder2.ToString());
                sqlDatabase.AddInParameter(sqlStringCommand, "PropId", DbType.Int32, maxOrderId);
                sqlDatabase.AddInParameter(sqlStringCommand, "Name", DbType.String, value2.Name);
                sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, value2.OrderID);
                if (!int.TryParse(sqlDatabase.ExecuteScalar(sqlStringCommand).ToString(), out result))
                {
                    result++;
                }
            }
            return result;
        }

        public ShopNum1_ShopProductProp GetPropModelByID(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("select ID,PropName,ShowType,IsImport,Content,OrderID from ShopNum1_ShopProductProp ");
            builder.Append(" where ID=@ID ");
            SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(builder.ToString());
            sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, ID);
            ShopNum1_ShopProductProp prop = null;
            using (IDataReader reader = sqlDatabase.ExecuteReader(sqlStringCommand))
            {
                if (reader.Read())
                {
                    prop = ReaderBind(reader);
                }
            }
            return prop;
        }

        public ShopNum1_ShopProductProp ReaderBind(IDataReader dataReader)
        {
            var prop = new ShopNum1_ShopProductProp();
            object obj2 = dataReader["ID"];
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                prop.ID = (int) obj2;
            }
            prop.PropName = dataReader["PropName"].ToString();
            obj2 = dataReader["ShowType"];
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                prop.ShowType = (byte) obj2;
            }
            obj2 = dataReader["IsImport"];
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                prop.IsImport = (bool) obj2;
            }
            prop.Content = dataReader["Content"].ToString();
            obj2 = dataReader["OrderID"];
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                prop.OrderID = (int) obj2;
            }
            return prop;
        }

        public DataTable dt_GetPro(string strID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT ID,PropName,showType FROM ShopNum1_ShopProductProp where id in(select propid from ShopNum1_TypeProp where typeid='" +
                    strID + "')");
        }

        public DataTable GetPropByProductCategory()
        {
            string strSql =
                " select ID,PropName,ShowType,IsImport,Content,OrderID,[dbo].[fun_Propstr](id) propDetail FROM ShopNum1_ShopProductProp  where 1=1 ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(ShopNum1_ShopProductProp PropModel, List<ShopNum1_ShopProductPropValue> shopProductPropValues)
        {
            string format = string.Empty;
            string str2 = string.Empty;
            var sqlList = new List<string>();
            format =
                "update ShopNum1_ShopProductProp set\r\n            PropName='{0}',Content='{1}',ShowType={2},OrderID={3} where id={4}";
            format = string.Format(format,
                new object[]
                {
                    PropModel.PropName, PropModel.Content, PropModel.ShowType, PropModel.OrderID,
                    PropModel.ID.ToString()
                });
            sqlList.Add(format);
            if (PropModel.ShowType == Convert.ToByte(4))
            {
                sqlList.Add("delete from ShopNum1_ShopProductPropValue where propid='" + PropModel.ID + "'");
            }
            if ((shopProductPropValues != null) && (shopProductPropValues.Count > 0))
            {
                for (int i = 0; i < shopProductPropValues.Count; i++)
                {
                    if (shopProductPropValues[i].ID == 0)
                    {
                        str2 = "insert into ShopNum1_ShopProductPropValue(PropId,Name,orderid) values({0},'{1}','{2}')";
                        str2 = string.Format(str2, shopProductPropValues[i].PropId, shopProductPropValues[i].Name,
                            shopProductPropValues[i].OrderID);
                    }
                    else
                    {
                        str2 = "update ShopNum1_ShopProductPropValue set orderid='{0}', Name='{1}' where id={2}";
                        str2 = string.Format(str2, shopProductPropValues[i].OrderID, shopProductPropValues[i].Name,
                            shopProductPropValues[i].ID);
                    }
                    sqlList.Add(str2);
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