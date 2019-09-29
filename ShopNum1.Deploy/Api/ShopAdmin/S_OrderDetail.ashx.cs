
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_OrderDetail 的摘要说明
    /// </summary>
    public class S_OrderDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strType = ShopNum1.Common.Common.ReqStr("type");
            switch (strType)
            {
                case "getlogistic":
                    var shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
                    DataTable dt_logistic = shopNum1_Logistic_Action.Search(1);
                    context.Response.Write(GetJson(dt_logistic));
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   将datatable转换成json数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            var sbJson = new StringBuilder();
            sbJson.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbJson.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
            }
            sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Append("]");
            return sbJson.ToString();
        }
    }
}