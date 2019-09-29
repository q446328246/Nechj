using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShopNum1.Common
{
    public class SqlDB
    {
        private readonly SqlConnection conn;

        public SqlDB()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
        }

        public SqlDB(string StrConnection)
        {
            conn = new SqlConnection();
            conn.ConnectionString = StrConnection;
        }

        private void ConnectionClose()
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("关闭数据库失败：" + exception.Message);
            }
        }

        private void ConnectionOpen()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("打开数据库失败：" + exception.Message);
            }
        }

        private SqlCommand CreateCommand(string CommandText, CommandType type, SqlParameter[] ParaList)
        {
            var command = new SqlCommand(CommandText, conn)
                {
                    CommandType = type
                };
            if (ParaList != null)
            {
                for (int i = 0; i < ParaList.Length; i++)
                {
                    command.Parameters.Add(ParaList[i]);
                }
            }
            return command;
        }

        public DataSet ExecuteDataSetByText(string SelectCommand)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(SelectCommand, CommandType.Text, null)).Fill(dataSet);
            return dataSet;
        }

        public DataSet ExecuteDataSetyByProc(string ProcName, SqlParameter[] ParaList)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, ParaList)).Fill(dataSet);
            return dataSet;
        }

        public DataSet ExecuteDataSetyByProc(string ProcName, string[] paraname, string[] paravalue)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(paraname, paravalue)))
                .Fill(dataSet);
            return dataSet;
        }

        public DataSet ExecuteDataSetyByProc(string ProcName, string paraname, string paravalue)
        {
            var strArray = new[] {paraname};
            var strArray2 = new[] {paravalue};
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(strArray, strArray2)))
                .Fill(dataSet);
            return dataSet;
        }

        public DataTable ExecuteDataTableByText(string SelectCommand)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(SelectCommand, CommandType.Text, null)).Fill(dataSet);
            return dataSet.Tables[0];
        }

        public DataTable ExecuteDataTableyByProc(string ProcName, SqlParameter[] ParaList)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, ParaList)).Fill(dataSet);
            return dataSet.Tables[0];
        }

        public DataTable ExecuteDataTableyByProc(string ProcName, string[] paraname, string[] paravalue)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(paraname, paravalue)))
                .Fill(dataSet);
            return dataSet.Tables[0];
        }

        public DataTable ExecuteDataTableyByProc(string ProcName, string paraname, string paravalue)
        {
            var strArray = new[] {paraname};
            var strArray2 = new[] {paravalue};
            var dataSet = new DataSet();
            new SqlDataAdapter(CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(strArray, strArray2)))
                .Fill(dataSet);
            return dataSet.Tables[0];
        }

        public int ExecuteNonQueryByProc(string ProcName, SqlParameter[] ParaList)
        {
            int num = -1;
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, ParaList);
            ConnectionOpen();
            num = command.ExecuteNonQuery();
            ConnectionClose();
            return num;
        }

        public int ExecuteNonQueryByProc(string ProcName, string[] paraname, string[] paravalue)
        {
            int num = -1;
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(paraname, paravalue));
            ConnectionOpen();
            num = command.ExecuteNonQuery();
            ConnectionClose();
            return num;
        }

        public int ExecuteNonQueryByProc(string ProcName, string paraname, string paravalue)
        {
            var strArray = new[] {paraname};
            var strArray2 = new[] {paravalue};
            int num = -1;
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(strArray, strArray2));
            ConnectionOpen();
            num = command.ExecuteNonQuery();
            ConnectionClose();
            return num;
        }

        public int ExecuteNonQueryByText(string CommandText)
        {
            int num = -1;
            SqlCommand command = CreateCommand(CommandText, CommandType.Text, null);
            ConnectionOpen();
            num = command.ExecuteNonQuery();
            ConnectionClose();
            return num;
        }

        public SqlDataReader ExecuteReaderByProc(string ProcName, SqlParameter[] ParaList)
        {
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, ParaList);
            ConnectionOpen();
            return command.ExecuteReader();
        }

        public SqlDataReader ExecuteReaderByProc(string ProcName, string[] paraname, string[] paravalue)
        {
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(paraname, paravalue));
            ConnectionOpen();
            return command.ExecuteReader();
        }

        public SqlDataReader ExecuteReaderByText(string SelectCommand)
        {
            SqlCommand command = CreateCommand(SelectCommand, CommandType.Text, null);
            ConnectionOpen();
            return command.ExecuteReader();
        }

        public object ExecuteScalarByProc(string ProcName, SqlParameter[] ParaList)
        {
            object obj2 = null;
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, ParaList);
            ConnectionOpen();
            obj2 = command.ExecuteScalar();
            ConnectionClose();
            return obj2;
        }

        public object ExecuteScalarByProc(string ProcName, string[] paraname, string[] paravalue)
        {
            object obj2 = null;
            SqlCommand command = CreateCommand(ProcName, CommandType.StoredProcedure, GetParameter(paraname, paravalue));
            ConnectionOpen();
            obj2 = command.ExecuteScalar();
            ConnectionClose();
            return obj2;
        }

        public object ExecuteScalarByText(string SelectCommand)
        {
            object obj2 = null;
            SqlCommand command = CreateCommand(SelectCommand, CommandType.Text, null);
            ConnectionOpen();
            obj2 = command.ExecuteScalar();
            ConnectionClose();
            return obj2;
        }

        public SqlParameter[] GetParameter(string[] paraname, string[] paravalue)
        {
            var parameterArray = new SqlParameter[paraname.Length];
            for (int i = 0; i < paraname.Length; i++)
            {
                parameterArray[i] = new SqlParameter(paraname[i], paravalue[i]);
            }
            return parameterArray;
        }
    }
}