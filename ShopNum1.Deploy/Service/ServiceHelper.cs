using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.IO;
using System.Xml;

namespace ShopNum1.Deploy.Service
{
    public class ServiceHelper
    {
        public static string M_json(DataTable selectGoods)
        {

            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{"); 
            //jsonBuilder.Append(moneyAndDv.TableName.ToString());  
            jsonBuilder.Append("[");//转换成多个model的形式
            for (int i = 0; i < selectGoods.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < selectGoods.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(selectGoods.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(selectGoods.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        public static string M_SingleJson(DataRow selectRow)
        {

            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{"); 
            //jsonBuilder.Append(moneyAndDv.TableName.ToString());  

                jsonBuilder.Append("{");
                for (int j = 0; j < selectRow.Table.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(selectRow.Table.Columns[j]);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(selectRow[j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 转换对象为JSON格式数据
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>字符格式的JSON数据</returns>
        public static string GetJSON<T>(object obj)
        {
            string result = String.Empty;
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    serializer.WriteObject(ms, obj);
                    result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string GetJSON_two<T>(object obj, List<Type> knownTypes)
        {
            string result = String.Empty;
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T), knownTypes);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    serializer.WriteObject(ms, obj);
                    result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public static void AddColumnAndStringValue(DataTable table, string columnName, string cValue)
        {

            table.Columns.Add(columnName);
           
            foreach (DataRow row in table.Rows)
            {
                row[columnName] = cValue;
            }
        }

        public static void AddColumnAndIntValue(DataTable table, string columnName, int cValue)
        {
            DataColumn column = new DataColumn(columnName, typeof(int));
            table.Columns.Add(column);

            foreach (DataRow row in table.Rows)
            {
                row[columnName] = cValue;
            }
        }

        public static string FormatParam(string param)
        {
            return param.Replace(@"\/", "/").Replace(@"\\/", "/");
        }

        public static string UserAuthentication(string memberloginID, string pwd, string date)
        {
            DataTable SelectMeberAuthentication = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberAll(memberloginID, Common.Encryption.GetMd5Hash(pwd));
            if (Convert.ToDateTime(date) > System.DateTime.Now)
            {
                if (SelectMeberAuthentication.Rows.Count>0)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
                
            }
            else
            {
                return "0";
            }
        }

        public static string UserAuthentication1(string Mobile, string pwd, string date)
        {
            DataTable SelectMeberAuthentication = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberAll1(Mobile, Common.Encryption.GetMd5Hash(pwd));
            if (Convert.ToDateTime(date) > System.DateTime.Now)
            {
                if (SelectMeberAuthentication.Rows.Count > 0)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }

            }
            else
            {
                return "0";
            }
        }


        public static string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.UTF8);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();


                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        } 
    }
}