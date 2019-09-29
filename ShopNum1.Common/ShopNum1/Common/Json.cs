using System.Data;
using System.Text;

namespace ShopNum1.Common
{
    public class Json
    {
        public static string GetJson(DataTable dt)
        {
            var builder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                builder.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    builder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        builder.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" +
                                       dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("},");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("]");
            }
            return builder.ToString();
        }
    }
}