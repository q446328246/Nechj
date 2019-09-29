using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;


namespace ShopNum1.Deploy.Api.Main
{
    /// <summary>
    /// V8_2_ProductCategory 的摘要说明
    /// </summary>
    public class V8_2_ProductCategory : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            string strType = ShopNum1.Common.Common.ReqStr("type");
            switch (strType)
            {
                case "index_productType":
                    int fatherid = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pid"));
                    var productCategoryAction =
                        (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                    DataTable dataTable = productCategoryAction.GetTwoOverType(fatherid, "5000");
                    string strJson = GetJson(dataTable, fatherid);
                    context.Response.Write(strJson);
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
        private string GetJson(DataTable dt, int FatherId)
        {
            var sbJson = new StringBuilder();
            DataRow[] drr = null, drr1 = null;
            if (dt.Rows.Count > 0)
            {
                drr = dt.Select("fatherid='" + FatherId + "'");
                sbJson.Append("[");

                for (int v = 0; v < drr.Length; v++)
                {
                    sbJson.Append("{");
                    for (int i = 0; i < drr[v].Table.Columns.Count; i++)
                    {
                        sbJson.Append("\"" + drr[v].Table.Columns[i].ColumnName.ToLower() + "\":\"" +
                                      drr[v][i].ToString().Replace("~/", "/").Replace("\r\n", "").Trim() + "\",");
                    }
                    sbJson.Append("subdata:[");
                    drr1 = dt.Select("fatherid='" + drr[v]["id"] + "'");
                    for (int x = 0; x < drr1.Length; x++)
                    {
                        if (x != drr1.Length - 1)
                            sbJson.Append("{\"name\":\"" + drr1[x]["name"].ToString().Trim() + "\",\"code\":\"" +
                                          drr1[x]["code"] + "\"},");
                        else
                            sbJson.Append("{\"name\":\"" + drr1[x]["name"].ToString().Trim() + "\",\"code\":\"" +
                                          drr1[x]["code"] + "\"}");
                    }
                    sbJson.Append("],");
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            else
            {
                sbJson.Append("0");
            }
            return sbJson.ToString();
        }
    }
}