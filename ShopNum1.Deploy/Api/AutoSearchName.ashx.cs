using System;
using System.Data;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// AutoSearchName 的摘要说明
    /// </summary>
    public class AutoSearchName : IHttpHandler
    {

        private string strKeyword = ""; //关键词
        private string strType = ""; //类型

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            strType = context.Request["type"];
            strKeyword = context.Request["keyword"] == null ? "" : context.Request["keyword"];
            if (strType == null)
            {
                return;
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

                ////搜索供求
                //case "searchsupply":
                //    context.Response.Write(SearchSupply(strKeyword));
                //    break;
                default:
                    break;
            }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        ///   搜索商品
        /// </summary>
        /// <param name="strKeyword">关键词</param>
        /// <returns></returns>
        private string SearchProduct(string strKeyword)
        {
            var product_action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
            DataTable dataTable_ProName = product_action.AutoSearchProductName(strKeyword);

            string str_data = string.Empty;
            if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
            {
                str_data += "<li> \"" + strKeyword + "\" <span>在宝贝分类下搜</span>索</li>";

                for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
                {
                    str_data += " <li onclick=\"javascript:test(1,this)\">" + dataTable_ProName.Rows[i]["Name"] + "</li>";
                }
            }
            else
            {
            }
            return str_data;
        }


        /// <summary>
        ///   搜索店铺
        /// </summary>
        /// <param name="strKeyword">关键词</param>
        /// <returns></returns>
        private string SearchShop(string strKeyword)
        {
            var product_action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
            DataTable dataTable_ProName = product_action.AutoSearchShopName(strKeyword);

            string str_data = string.Empty;
            if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
            {
                str_data += "<li> \"" + strKeyword + "\" <span>在店铺分类下搜</span>索</li>";

                for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
                {
                    str_data += " <li onclick=\"javascript:test(2,this)\">" + dataTable_ProName.Rows[i]["ShopName"] +
                                "</li>";
                }
            }
            else
            {
            }
            return str_data;
        }


        ///// <summary>
        ///// 搜索供求
        ///// </summary>
        ///// <param name="strKeyword">关键词</param>
        ///// <returns></returns>
        //private string SearchSupply(string strKeyword)
        //{
        //    Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
        //    DataTable dataTable_ProName = product_action.AutoSearchSupplyName(strKeyword);

        //    string str_data = string.Empty;
        //    if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
        //    {
        //        str_data += "<li> \"" + strKeyword + "\" <span>在供求分类下搜</span>索</li>";

        //        for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
        //        {
        //            str_data += " <li onclick=\"javascript:test(3,this)\">" + dataTable_ProName.Rows[i]["Title"].ToString() + "</li>";
        //        }
        //    }
        //    else
        //    {

        //    }
        //    return str_data;
        //}
    }
}