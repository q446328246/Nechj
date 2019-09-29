using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;


namespace ShopNum1.Deploy.Api.Shop
{
    /// <summary>
    /// pcoment 的摘要说明
    /// </summary>
    public class pcoment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            string strPageSize = "20";
            string strCurrentPage = ShopNum1.Common.Common.ReqStr("currentpage") == "" ? "1" : ShopNum1.Common.Common.ReqStr("currentpage");
            string strShopId = ShopNum1.Common.Common.ReqStr("shopid");
            string strGuId = ShopNum1.Common.Common.ReqStr("guid");
            string strSign = ShopNum1.Common.Common.ReqStr("sign");
            string strCtype = ShopNum1.Common.Common.ReqStr("ctype");
            string strshowtype = ShopNum1.Common.Common.ReqStr("showtype");
            if (strshowtype == "undefined")
                strshowtype = "2";
            string strCondition = "";
            if (strSign == "vj" && strShopId != "" & strGuId != "")
            {
                switch (strCtype)
                {
                    case "good":
                        strCondition = " and commenttype='5'";
                        break;
                    case "normal":
                        strCondition = " and commenttype='3'";
                        break;
                    case "bad":
                        strCondition = " and commenttype='1'";
                        break;
                    case "addcomment":
                        strCondition = " and continuecomment!=''";
                        break;
                }
                var ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
                DataTable dt = ProductComment_Action.SelectShopDetailComment(strPageSize, strCurrentPage, strCondition, "2",
                                                                             strShopId, strshowtype, strGuId);
                context.Response.Write(GetJson(dt));
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