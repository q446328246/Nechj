using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;


namespace ShopNum1.Deploy.PageHander.Main
{
    /// <summary>
    /// ShopProducts 的摘要说明
    /// </summary>
    public class ShopProducts : IHttpHandler
    {

        private int pageindex = 1; //当前页
        private int pagesize = 4; //页大小
        private string shopid = ""; //关键词
        private string strType = ""; //类型

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            strType = context.Request["type"];
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            shopid = context.Request["shopid"] == null ? "" : context.Request["shopid"];
            pageindex = context.Request["pageindex"] == null ? 1 : Convert.ToInt32(context.Request["pageindex"]);
            pagesize = context.Request["pagesize"] == null ? 4 : Convert.ToInt32(context.Request["pagesize"]);

            if (strType == null)
            {
                return;
            }
            switch (strType.ToLower())
            {
                //搜索商品
                case "shopproduct":
                    context.Response.Write(SearchProduct(shopid, pageindex, pagesize));
                    break;
                //搜索商品总数
                case "shopproductcount":
                    context.Response.Write(SearchProductCount(shopid));
                    break;
                default:
                    break;
            }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        private string SearchProduct(string shopid, int pageindex, int pagesize)
        {
            var sbuilder = new StringBuilder();
            var ProuductChecked_Action =
                (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            DataTable datatable = ProuductChecked_Action.SearchRelatedProduct("-1", shopid, pageindex, pagesize, "0");
            datatable.Columns.Add("ProductDetailUrl", Type.GetType("System.String"));
            foreach (DataRow r in datatable.Rows)
            {
                r["ProductDetailUrl"] = ShopUrlOperate.shopDetailHref(r["Guid"].ToString(), r["MemLoginID"].ToString(),
                                                                      "ProductDetail");
            }
            return datatableToJson(datatable);
        }

        //返回记录总数
        private string SearchProductCount(string shopid)
        {
            var sbuilder = new StringBuilder();
            var ProuductChecked_Action =
                (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            DataTable datatable = ProuductChecked_Action.SearchRelatedProduct("-1", shopid, 1, 1, "1");
            return datatable.Rows[0][0].ToString();
        }

        public string datatableToJson(DataTable dt)
        {
            if (dt != null)
            {
                var str = new StringBuilder();
                str.Append("[");
                int rcount = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (rcount > 0)
                    {
                        str.Append(",");
                    }
                    str.Append("{");
                    int ccount = 0;
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (ccount > 0)
                        {
                            str.Append(",");
                        }
                        str.Append("\"" + c.ColumnName + "\":\"" + r[c] + "\"");
                        ccount++;
                    }
                    str.Append("}");
                    rcount++;
                }
                str.Append("]");
                return str.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}