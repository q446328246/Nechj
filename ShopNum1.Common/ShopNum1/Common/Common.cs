using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using ShopNum1.DataAccess;
using System.Data.Common;

namespace ShopNum1.Common
{
    public static class Common
    {
        public static bool CheckImgType(string[] strArry, string strExt)
        {
            for (int i = 0; i < strArry.Length; i++)
            {
                if (strArry[i] == strExt)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckInertSql(string str)
        {
            string[] strArray = ConfigurationManager.AppSettings["SQLChar"].Split(new[] {'|'});
            bool flag = false;
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((str.Trim().ToLower().IndexOf(strArray[i].ToLower()) != -1) ||
                    str.Trim().ToLower().StartsWith(strArray[i].Trim()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static string cut(object obj, int len)
        {
            if (obj.ToString().Length >= len)
            {
                return obj.ToString().Substring(0, len);
            }
            return obj.ToString();
        }

        public static object Deserialize(string str)
        {
            object obj2;
            try
            {
                var serializationStream = new MemoryStream(Convert.FromBase64String(str));
                obj2 = new BinaryFormatter().Deserialize(serializationStream);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj2;
        }

        public static string GetCopyright()
        {
            //var check = new ControlCheck();
            //HttpContext current = HttpContext.Current;
            //string domain = ConfigurationManager.AppSettings["DoMain"].Trim();
            //if ((check.CheckCopyright(domain) == 2) || (ShopSettings.GetValue("Power") == "shopnum1"))
            //{
            //    return "";
            //}
            //return " Powered by 唐江国际";
            return "";
        }

        public static string GetNameById(string strColumn, string strTab, string strCondition)
        {
            return DatabaseExcetue.ReturnString("select " + strColumn + " from " + strTab + " where 1=1 " + strCondition);
        }
        public static DataTable GetScore_hv(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("select Score_hv from shopnum1_member where 1=1 and memloginid =@memloginID" , parms);
        }

        public static DataTable GetTableById(string strColumn, string strTab, string strCondition)
        {
            return
                DatabaseExcetue.ReturnDataTable("select " + strColumn + " from " + strTab + " where 1=1 " + strCondition);
        }

        public static string ReqStr(string str)
        {
            if (HttpContext.Current.Request.QueryString[str] != null)
            {
                return cut(Operator.FilterStringUrl(HttpContext.Current.Request.QueryString[str]), 200);
            }
            return "";
        }


         public static string ReqPostStr(string str)
        {
            if (HttpContext.Current.Request.Params[str] != null)
            {
                return cut(Operator.FilterStringUrl(HttpContext.Current.Request.Params[str]), 200);
            }
            return "";
        }

        

        public static bool ReturnExist(string strcolumnName, string strtableName, string strcondition)
        {
            try
            {
                string strSql = "select " + strcolumnName + " from " + strtableName + " where 1=1 " + strcondition;
                return ((DatabaseExcetue.ReturnString(strSql) != "0") && (DatabaseExcetue.ReturnString(strSql) != ""));
            }
            catch
            {
                return false;
            }
        }

        public static int ReturnMaxID(string columnName, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, tableName);
        }

        public static int ReturnMaxID(string columnName, string ShopID, string ShopIDValue, string tableName)
        {
            return DatabaseExcetue.ReturnMaxID(columnName, ShopID, ShopIDValue, tableName);
        }

        public static string Serialize(object obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                var serializationStream = new MemoryStream();
                formatter.Serialize(serializationStream, obj);
                byte[] inArray = serializationStream.ToArray();
                return Convert.ToBase64String(inArray, 0, inArray.Length);
            }
            catch
            {
                return "";
            }
        }

        public static string SetShopCommentTxt(string strScore)
        {
            string str2 = strScore;
            switch (str2)
            {
                case null:
                    break;

                case "5":
                    return "<img src='/ImgUpload/gds_dp.png' alt='好评'/>";

                default:
                    if (!(str2 == "3"))
                    {
                        if (str2 == "1")
                        {
                            return "<img src='/ImgUpload/gds_dp2.png' alt='差评'/>";
                        }
                    }
                    else
                    {
                        return "<img src='/ImgUpload/gds_dp1.png' alt='中评'/>";
                    }
                    break;
            }
            return "<img src='/ImgUpload/gds_dp2.png' alt='差评'/>";
        }

        public static int UpdateInfo(string strColumn, string strTab, string strCondition)
        {
            return DatabaseExcetue.RunNonQuery("update " + strTab + " set " + strColumn + " where 1=1 " + strCondition);
        }
    }
}