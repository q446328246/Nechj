using System;
using System.Web;
using System.Text;
using ShopNum1.ShopBusinessLogic;
using System.Data;
using System.Text.RegularExpressions;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// autosearch 的摘要说明
    /// </summary>
    public class autosearch : IHttpHandler
    {

        string strType = "";//类型
        string strKeyword = "";//关键词
        public void ProcessRequest(HttpContext context)
        {
            strType = context.Request.Form["type"];
            strKeyword = context.Request.Form["keyword"];
            if (strType == null)
            {
                context.Response.Write("0");
            }
            switch (strType.ToLower())
            {
                //搜索商品
                case "searchproduct":
                    context.Response.Write(SearchProduct(strKeyword));
                    break;
                //搜索店铺
                case "searchshop":
                    context.Response.Write(SearchShop(strKeyword));
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="strkeyword"></param>
        /// <returns></returns>
        private string SearchProduct(string strkeyword)
        {
            string strType = "0";
            Regex r = new Regex("[a-zA-Z]+");
            if (r.IsMatch(strkeyword))
                strType = "1";
            Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
            DataTable dataTable_ProName = product_action.AutoSearchProductName(strKeyword, strType);
            if (dataTable_ProName.Rows.Count > 0)
            {
                return GetJson(dataTable_ProName);
            }
            else
            {
                dataTable_ProName = product_action.AutoSearchProductName(strKeyword, "2");
                if (dataTable_ProName.Rows.Count > 0)
                {
                    return GetJson(dataTable_ProName);
                }
                else
                {
                    return "0";
                }
            }
        }
        /// <summary>
        /// 查询店铺
        /// </summary>
        /// <param name="strkeyword"></param>
        /// <returns></returns>
        private string SearchShop(string strkeyword)
        {
            string strType = "0";
            Regex r = new Regex("[a-zA-Z]+");
            if (r.IsMatch(strkeyword))
                strType = "1";
            Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
            DataTable dataTable_ShopName = product_action.AutoSearchShopName(strKeyword, strType);
            if (dataTable_ShopName.Rows.Count > 0)
            {
                return GetJson(dataTable_ShopName);
            }
            else
            {
                dataTable_ShopName = product_action.AutoSearchShopName(strKeyword, "2");
                if (dataTable_ShopName.Rows.Count > 0)
                {
                    return GetJson(dataTable_ShopName);
                }
                else
                {
                    return "0";
                }
            }
        }
        /// <summary>
        /// 获取JSON
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            StringBuilder sbJson = new StringBuilder();
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}