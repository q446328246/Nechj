using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopWebControl;


namespace ShopNum1.Deploy.Api.Shop
{
    /// <summary>
    /// pcoment 的摘要说明
    /// </summary>
    public class ShopProduct : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            
            string guid = ShopNum1.Common.Common.ReqStr("guid") ;
            string productid = ShopNum1.Common.Common.ReqStr("productid");
            string buynum = ShopNum1.Common.Common.ReqStr("buynum");
            string color = ShopNum1.Common.Common.ReqStr("color");
            string size = ShopNum1.Common.Common.ReqStr("size");
            string type = ShopNum1.Common.Common.ReqStr("type");
            
            ProductListIsHot_two product = new ProductListIsHot_two();

            try{

             string c=   product.BuyProduct(guid, productid, buynum, color, size, context,type).ToString();
             context.Response.Write(c);
            }
            catch 
            {
                context.Response.Write("0");
                return;
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
            if (dt.Rows.Count > 0)
            {
                sbJson.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbJson.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" +
                                      dt.Rows[i][j].ToString()
                                                   .Replace("~/", "/")
                                                   .Replace("\r\n", "")
                                                   .Replace("\n", "")
                                                   .Trim() + "\",");
                    }
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