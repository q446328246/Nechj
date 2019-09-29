using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShopNum1.ThirdInterDAL
{
    public class SqlHelper
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;

        public DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(sql, CommandType.Text, null);
        }

        public DataSet ExecuteDataSet(string sql, CommandType commandType)
        {
            return ExecuteDataSet(sql, commandType, null);
        }

        public DataSet ExecuteDataSet(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    new SqlDataAdapter(command).Fill(dataSet);
                }
            }
            return dataSet;
        }

        public int ExecuteScalar(string sql)
        {
            int num = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    num = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return num;
        }

        public object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }

        public object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            object obj2 = null;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    obj2 = command.ExecuteScalar();
                }
            }
            return obj2;
        }
    }
}