using ShopNum1.DataAccess;
using System.Configuration;
using System.Data;
using System.Web;

namespace ShopNum1.Common
{
    public class QLX_NEC_BILI
    {
        public static string GetNECbili()
        {
            DataTable table = new DataTable();
            string strSql = string.Empty;
            strSql = "select *   from QLX_NEC_BiLi";
            table = DatabaseExcetue.ReturnDataTable(strSql);
            string bili = table.Rows[0][0].ToString();
            return bili;

        }
    }
}
