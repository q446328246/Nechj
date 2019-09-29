
using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_SellProduct 的摘要说明
    /// </summary>
    public class S_SellProduct : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var shopNum1_ProductCategory_Action =
                (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            //ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            var shopNum1_CategoryType_Action =
                (ShopNum1_CategoryType_Action)LogicFactory.CreateShopNum1_CategoryType_Action();

            var shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
            string strCommon = ShopNum1.Common.Common.ReqStr("type");
            switch (strCommon)
            {
                case "0": //获取商品分类相关操作
                    if (context.Request.QueryString["parentid"] != null)
                    {
                        string strid = context.Request.QueryString["parentid"];
                        DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(
                            Convert.ToInt32(strid), 0);
                        context.Response.Write(GetJson(dataTable));
                    }
                    break;
                case "1":
                    DataTable dt = shopNum1_CategoryType_Action.Select_ProductCategoryType();
                    context.Response.Write(GetJson(dt));
                    break;
                case "2":
                    string strcol = ShopNum1.Common.Common.ReqStr("col");
                    string strvalue = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("vl")).Replace("%2f", "/");
                    string guid = ShopNum1.Common.Common.ReqStr("guid");
                    string shopid = ShopNum1.Common.Common.ReqStr("shopid");
                    switch (strcol)
                    {
                        case "name":
                            ShopNum1.Common.Common.UpdateInfo("name='" + strvalue + "'", "shopnum1_shop_product", " and guid='" + guid + "'");
                            break;
                        case "rep":
                            ShopNum1.Common.Common.UpdateInfo("repertorycount='" + strvalue + "'", "shopnum1_shop_product",
                                              " and guid='" + guid + "'");
                            break;
                        case "price":
                            ShopNum1.Common.Common.UpdateInfo("Score_pv_a='" + strvalue + "',ShopPrice='" + strvalue + "'", "ShopNum1_Shop_ProductPrice",
                                              " and productId='" + guid + "' and shop_category_id='" + shopid + "'");
                            break;
                        default:
                            break;
                    }
                    context.Response.Write("ok");
                    break;
                case "3":
                    shop_Product_Action.DeleteById(ShopNum1.Common.Common.ReqStr("ids"));
                    context.Response.Write("ok");
                    break;
                case "4":
                    shop_Product_Action.UpdateProductSaled(ShopNum1.Common.Common.ReqStr("ids"), ShopNum1.Common.Common.ReqStr("sale"));
                    break;
                case "5": //获取店铺分类相关操作
                    var ProductCategory_Action =
                        (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
                    string strpid = ShopNum1.Common.Common.ReqStr("parentid");
                    if (strpid != null)
                    {
                        DataTable dataTable = ProductCategory_Action.SearchShopType(Convert.ToInt32(strpid), GetMemLoginId());
                        context.Response.Write(GetJson(dataTable));
                    }
                    break;
                default:
                    context.Response.Write("0");
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        //获取登录用户方法
        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
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