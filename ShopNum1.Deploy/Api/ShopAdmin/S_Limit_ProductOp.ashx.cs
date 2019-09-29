using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_Limit_ProductOp 的摘要说明
    /// </summary>
    public class S_Limit_ProductOp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //ProductGuid,Lid,Discount,ShopName,MemloginID
            if (ShopNum1.Common.Common.ReqStr("type") != "")
            {
                var shop_LimtProduct_Action = new Shop_LimtProduct_Action();
                string strId = "";
                switch (ShopNum1.Common.Common.ReqStr("type"))
                {
                    case "addlimitproduct":
                        string strProductGuId = ShopNum1.Common.Common.ReqStr("guid");
                        string strLid = ShopNum1.Common.Common.ReqStr("lid");
                        string strDisCount1 = ShopNum1.Common.Common.ReqStr("discount");
                        string strShopName = ShopNum1.Common.Common.GetNameById("shopname", "ShopNum1_shopinfo",
                                                                " and name='" + GetMemLoginId() + "'");
                        var shopNum1_Limt_Product = new ShopNum1_Limt_Product();
                        shopNum1_Limt_Product.ProductGuid = new Guid(strProductGuId);
                        shopNum1_Limt_Product.Lid = Convert.ToInt32(strLid);
                        shopNum1_Limt_Product.DisCount = Convert.ToDecimal(strDisCount1);
                        shopNum1_Limt_Product.ShopName = strShopName;
                        shopNum1_Limt_Product.MemLoginId = GetMemLoginId();
                        shop_LimtProduct_Action.AddLimitProduct(shopNum1_Limt_Product);
                        context.Response.Write(GetMemLoginId());
                        break;
                    case "del":
                        strId = ShopNum1.Common.Common.ReqStr("Id");
                        shop_LimtProduct_Action.DeleteLimitProduct(strId);
                        context.Response.Write(GetMemLoginId());
                        break;
                    case "cancel":
                        strId = ShopNum1.Common.Common.ReqStr("Id");
                        shop_LimtProduct_Action.UpdateLimitProductStae(strId, "0");
                        context.Response.Write(GetMemLoginId());
                        break;
                    case "updatediscount":
                        strId = ShopNum1.Common.Common.ReqStr("Id");
                        string strDisCount2 = ShopNum1.Common.Common.ReqStr("txtdiscount");
                        shop_LimtProduct_Action.UpdateDisCount(strDisCount2, strId);
                        context.Response.Write(GetMemLoginId());
                        break;
                    case "cancelAct":
                        strId = ShopNum1.Common.Common.ReqStr("Id");
                        var shopNum1_Activity_Action =
                            (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
                        shopNum1_Activity_Action.UpdateActivityState(strId, "2");
                        context.Response.Write(GetMemLoginId());
                        break;
                    case "ptype":
                        var ProductCategory_Action =
                            (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                        context.Response.Write(GetJson(ProductCategory_Action.Select_ProductCategory()));
                        break;
                }
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
                                      dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            return sbJson.ToString();
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
    }
}