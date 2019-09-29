using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShopNum1.Encryption;

namespace ShopNum1.DataAccess
{
    public class DatabaseExcetue
    {
        private static string string_0 = string.Empty;
        private static string string_1 = string.Empty;

        public static void BuildDBParameter(SqlDatabase sqlDatabase_0, DbCommand dbCommand, params DbParameter[] parms)
        {
            foreach (DbParameter parameter in parms)
            {
                sqlDatabase_0.AddInParameter(dbCommand, parameter.ParameterName, parameter.DbType, parameter.Value);
            }
        }

        public static bool CheckExists(string strSql)
        {
            int num;
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            object objA = sqlDatabase.ExecuteScalar(sqlStringCommand);

            if (!Equals(objA, null) && !Equals(objA, DBNull.Value))
            {
                num = int.Parse(objA.ToString());
            }
            else
            {
                num = 0;
            }

            if (num == 0)
            {
                return false;
            }

            return true;
        }

        public static bool CheckExists(string strSql, params DbParameter[] parms)
        {
            int num;
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            object objA = sqlDatabase.ExecuteScalar(sqlStringCommand);
            if (!Equals(objA, null) && !Equals(objA, DBNull.Value))
            {
                num = int.Parse(objA.ToString());
            }
            else
            {
                num = 0;
            }

            if (num == 0)
            {
                return false;
            }

            return true;
        }

        public static bool CheckExists(string strSql, string[] paraName, string[] paraValue)
        {
            int num;
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DbParameter[] parms = smethod_0(sqlStringCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            object objA = sqlDatabase.ExecuteScalar(sqlStringCommand);
            if (!Equals(objA, null) && !Equals(objA, DBNull.Value))
            {
                num = int.Parse(objA.ToString());
            }
            else
            {
                num = 0;
            }

            if (num == 0)
            {
                return false;
            }

            return true;
        }

        public static string GetConnstring()
        {
            if ((string_0 == string.Empty) || (string_1 == string.Empty))
            {
                string_0 = ConfigurationManager.AppSettings["IsConnectionEncrypt"];
                if (string_0 == "1")
                {
                    string_1 =
                        DESEncrypt.Decrypt(
                            ConfigurationManager.ConnectionStrings["ConnectionEncryptString"].ConnectionString);
                }
                else
                {
                    string_1 = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                }
            }
            return string_1;
        }
        public static string GetConnstringtwo()
        {
            if ((string_0 == string.Empty) || (string_1 == string.Empty))
            {
                string_0 = ConfigurationManager.AppSettings["IsConnectionEncrypt"];
                if (string_0 == "1")
                {
                    string_1 =
                        DESEncrypt.Decrypt(
                            ConfigurationManager.ConnectionStrings["ConnectionEncryptString"].ConnectionString);
                }
                else
                {
                    string_1 = ConfigurationManager.ConnectionStrings["Connection Stringtwo"].ConnectionString;
                }
            }
            return string_1;
        }

        public static SqlDatabase GetSqlDatabasetwo()
        {
            return new SqlDatabase(GetConnstringtwo());
        }

        public static SqlDatabase GetSqlDatabase()
        {
            return new SqlDatabase(GetConnstring());
        }

        public static DataSet ReturnDataSet(string strSql)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            try
            {
                return sqlDatabase.ExecuteDataSet(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            return null;
        }

        public static DataTable ReturnDataTable(string strSql)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            return table;
        }

        public static DataTable ReturnDataTable(string strSql, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DbParameter[] parms = smethod_0(sqlStringCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            return table;
        }

        public static DataTable ReturnDataTable(string strSql, params DbParameter[] parms)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            return table;
        }


        public static int ReturnMaxID(string FieldName, string TableName)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand =
                sqlDatabase.GetSqlStringCommand("SELECT MAX([" + FieldName + "]) FROM " + TableName);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            if ((table.Rows.Count >= 1) && (table.Rows[0][0].ToString() != ""))
            {
                return int.Parse(table.Rows[0][0].ToString());
            }
            return 0;
        }

        public static int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand =
                sqlDatabase.GetSqlStringCommand("SELECT MAX([" + columnName + "]) FROM " + tableName);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            if ((table.Rows.Count >= 1) && (table.Rows[0][0].ToString() != ""))
            {
                return int.Parse(table.Rows[0][0].ToString());
            }
            return 0;
        }

        public static object ReturnObject(string strSql)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            return sqlDatabase.ExecuteScalar(sqlStringCommand);
        }
        

        public static object ReturnObject(string strSql, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DbParameter[] parms = smethod_0(sqlStringCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            return sqlDatabase.ExecuteScalar(sqlStringCommand);
        }

        public static object ReturnObject(string strSql, params DbParameter[] parms)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            return sqlDatabase.ExecuteScalar(sqlStringCommand);
        }

        public static object ReturnProcedureString(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, storedProcCommand, parms);
            return sqlDatabase.ExecuteScalar(storedProcCommand);
        }

        public static string ReturnString(string strSql)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DataTable table = null;
            try
            {
                table = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
            }
            catch (Exception exception)
            {
                smethod_2(exception);
            }
            if ((table != null) && (table.Rows.Count != 0))
            {
                return table.Rows[0][0].ToString();
            }
            return "";
        }

        public static int RunNonQuery(string strSql)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            try
            {
                return sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
                return 1;
            }
        }

        public static int RunNonQuery(string strSql, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            DbParameter[] parms = smethod_0(sqlStringCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            try
            {
                return sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
                return 0;
            }
        }

        public static int RunNonQuery(string strSql, params DbParameter[] parms)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            try
            {
                return sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
                return 0;
            }
        }

        public static int RunProcedure(string strProcedureName)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            return sqlDatabase.ExecuteNonQuery(storedProcCommand);
        }

        public static SqlDataReader RunProcedure(string strProcedureName, IDataParameter[] parameters)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName, parameters);
            return (SqlDataReader) sqlDatabase.ExecuteReader(storedProcCommand);
        }

        public static int RunProcedure(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, storedProcCommand, parms);
            return sqlDatabase.ExecuteNonQuery(storedProcCommand);
        }

        public static int RunProcedureGetInt(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);

            BuildDBParameter(sqlDatabase, storedProcCommand, parms);

            DbParameter returnParms = new SqlParameter();
            returnParms.ParameterName = "@return";
            returnParms.Direction = ParameterDirection.ReturnValue;

            storedProcCommand.Parameters.Add(returnParms);

            sqlDatabase.ExecuteNonQuery(storedProcCommand);

            return Convert.ToInt32(returnParms.Value);
        
        }
        public static decimal RunProcedureGetDecimal(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);

            BuildDBParameter(sqlDatabase, storedProcCommand, parms);

            DbParameter returnParms = new SqlParameter();
            returnParms.ParameterName = "@return";
            returnParms.Direction = ParameterDirection.ReturnValue;

            storedProcCommand.Parameters.Add(returnParms);

            sqlDatabase.ExecuteNonQuery(storedProcCommand);
            decimal aa = Convert.ToDecimal(returnParms.ParameterName.ToString());
            return aa;

        }

        public static int RunProcedureGetIntttwo(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);

            BuildDBParameter(sqlDatabase, storedProcCommand, parms);

            DbParameter returnParms = new SqlParameter();
            returnParms.ParameterName = "@return";
            returnParms.Direction = ParameterDirection.ReturnValue;

            storedProcCommand.Parameters.Add(returnParms);

            sqlDatabase.ExecuteNonQuery(storedProcCommand);

            return Convert.ToInt32(returnParms.Value);

        }

        public static int RunProcedure(string strProcedureName, string paraName, string paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter parameter = smethod_1(storedProcCommand, paraName, paraValue);
            sqlDatabase.AddInParameter(storedProcCommand, parameter.ParameterName, parameter.DbType, parameter.Value);
            return sqlDatabase.ExecuteNonQuery(storedProcCommand);
        }

        public static int RunProcedureGetReturn(string strProcedureName, string paraName, string paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter parameter = smethod_1(storedProcCommand, paraName, paraValue);
            sqlDatabase.AddInParameter(storedProcCommand, parameter.ParameterName, parameter.DbType, parameter.Value);
            return sqlDatabase.ExecuteNonQuery(storedProcCommand);
        }

        public static object RunProcedure(string strProcedureName, DbParameter[] inParameters, DbParameter outParameter,
            int rowsAffected)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            BuildDBParameter(sqlDatabase, storedProcCommand, inParameters);
            sqlDatabase.AddOutParameter(storedProcCommand, outParameter.ParameterName, outParameter.DbType,
                outParameter.Size);
            rowsAffected = sqlDatabase.ExecuteNonQuery(storedProcCommand);
            return sqlDatabase.GetParameterValue(storedProcCommand, "@" + outParameter.ParameterName);
        }

        public static DataSet RunProcedureReturnDataSet(string strProcedureName, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, storedProcCommand, parms);
            return sqlDatabase.ExecuteDataSet(storedProcCommand);
        }

        public static DataTable RunProcedureReturnDataTable(string strProcedureName)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            return sqlDatabase.ExecuteDataSet(storedProcCommand).Tables[0];
        }

        public static DataTable RunProcedureReturnDataTable(string strProcedureName, string paraName, string paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter parameter = smethod_1(storedProcCommand, paraName, paraValue);
            sqlDatabase.AddInParameter(storedProcCommand, parameter.ParameterName, parameter.DbType, parameter.Value);
            return sqlDatabase.ExecuteDataSet(storedProcCommand).Tables[0];
        }

        public static DataTable RunProcedureReturnDataTable(string strProcedureName, string[] paraName,
            string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
            DbParameter[] parms = smethod_0(storedProcCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, storedProcCommand, parms);
            return sqlDatabase.ExecuteDataSet(storedProcCommand).Tables[0];
        }

        public static int RunSqlByTime(string strSql, int time)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            sqlStringCommand.CommandTimeout = time;
            try
            {
                return sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
                return 1;
            }
        }

        public static int RunSqlByTime(string strSql, int time, string[] paraName, string[] paraValue)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
            sqlStringCommand.CommandTimeout = time;
            DbParameter[] parms = smethod_0(sqlStringCommand, paraName, paraValue);
            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
            try
            {
                return sqlDatabase.ExecuteNonQuery(sqlStringCommand);
            }
            catch (Exception exception)
            {
                smethod_2(exception);
                return 1;
            }
        }

        public static void RunTransactionSql(ArrayList sqlList)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            using (DbConnection connection = sqlDatabase.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        string str = sqlList[i].ToString();
                        if (str.Trim().Length > 1)
                        {
                            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(str);
                            sqlDatabase.ExecuteNonQuery(sqlStringCommand);
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    smethod_2(exception);
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void RunTransactionSql(List<string> sqlList)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            using (DbConnection connection = sqlDatabase.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (string str in sqlList)
                    {
                        DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(str);
                        sqlDatabase.ExecuteNonQuery(sqlStringCommand);
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    smethod_2(exception);
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public static void RunTransactionSqlGZ(List<string> sqlList, params DbParameter[] parms)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            using (DbConnection connection = sqlDatabase.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (string str in sqlList)
                    {
                        DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(str);
                        BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
                        sqlDatabase.ExecuteNonQuery(sqlStringCommand);
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    smethod_2(exception);
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public static void RunTransactionSql(Hashtable sqlList)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            using (DbConnection connection = sqlDatabase.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (DictionaryEntry entry in sqlList)
                    {
                        string str = entry.Key.ToString();
                        var parms = (DbParameter[]) entry.Value;
                        if (str.Trim().Length > 1)
                        {
                            DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(str);
                            BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
                            sqlDatabase.ExecuteNonQuery(sqlStringCommand);
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    smethod_2(exception);
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void RunTransactionSql(DataTable sqlList)
        {
            SqlDatabase sqlDatabase = GetSqlDatabase();
            using (DbConnection connection = sqlDatabase.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlList.Rows.Count; i++)
                    {
                        DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(sqlList.Rows[i][0].ToString());
                        sqlDatabase.ExecuteNonQuery(sqlStringCommand);
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    smethod_2(exception);
                    transaction.Rollback();
                }
            }
        }

        private static DbParameter[] smethod_0(DbCommand dbCommand_0, string[] string_2, string[] string_3)
        {
            var parameterArray = DatabaseExcetue.CreateParameter(string_2.Length);
            for (int i = 0; i < string_2.Length; i++)
            {
                DbParameter parameter = dbCommand_0.CreateParameter();
                parameter.ParameterName = string_2[i];
                parameter.Value = string_3[i];
                parameterArray[i] = parameter;
            }
            return parameterArray;
        }

        private static DbParameter smethod_1(DbCommand dbCommand_0, string string_2, string string_3)
        {
            DbParameter parameter = dbCommand_0.CreateParameter();
            parameter.ParameterName = string_2;
            parameter.Value = string_3;
            return parameter;
        }

        private static void smethod_2(Exception exception_0)
        {
            Exception exception = exception_0;
            string str = HttpContext.Current.Request.Url.ToString();
            string source = exception.Source;
            string message = exception.Message;
            string stackTrace = exception.StackTrace;
            string str5 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            smethod_3(
                "http://www.T.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&OffendingUrl=" +
                str + "&ErrorSouce= " + source + " &Message=" + message + "&StackTrace= " + stackTrace + "&MainDomain=" +
                str5);
        }

        private static string smethod_3(string string_2)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_2);
            try
            {
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static DbParameter[] CreateParameter(int num)
        {
            List<SqlParameter>  parameters = new List<SqlParameter>();

            for (int i = 0; i < num; i ++)
            {
                parameters.Add(new SqlParameter());
            }
            return parameters.ToArray();
        }

        public static string GetGuidsSql(string cartGuID, List<DbParameter> parms)
        {
            DbParameter parm ;
            string[] guid = cartGuID.Replace("'","").Split(',');
            string andSql =string.Empty;
            for (int i = 0; i < guid.Length; i++)
            {
                parm = new SqlParameter();
                parm.ParameterName = "@guid" + i;
                parm.Value = guid[i];

                andSql += "@guid" + i + ",";
                parms.Add(parm);

            }

            return andSql.Remove(andSql.Length - 1, 1);
        }
    }


}