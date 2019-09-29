using System;
using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_ThemeProductOperate 的摘要说明
    /// </summary>
    public class S_ThemeProductOperate : IHttpHandler
    {

        private readonly Shop_PackAge_Action PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();

        public void ProcessRequest(HttpContext context)
        {
            if (ShopNum1.Common.Common.ReqStr("type") != "")
            {
                var shop_ProductCategory_Action =
                    (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
                switch (ShopNum1.Common.Common.ReqStr("type"))
                {
                    case "getthemeactivity":
                        var GroupProduct =
                            (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
                        DataTable dtv = GroupProduct.GetThemeActivty();
                        context.Response.Write(Json.GetJson(dtv));
                        break;
                    case "getshoptype":
                        DataTable dt = shop_ProductCategory_Action.Search_Import(ShopNum1.Common.Common.ReqStr("id"), GetMemLoginId());
                        context.Response.Write(Json.GetJson(dt));
                        break;
                    case "getproduct":
                        string strcode = ShopNum1.Common.Common.ReqStr("code");
                        string strKey = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("keyword"));
                        string ThemeGuid = ShopNum1.Common.Common.ReqStr("ThemeGuid").Trim();
                        DataTable dtProduct = GetData(context, strKey, strcode, ShopNum1.Common.Common.ReqStr("pageid"), "1", ThemeGuid);
                        string strCount =
                            GetData(context, strKey, strcode, ShopNum1.Common.Common.ReqStr("pageid"), "0", ThemeGuid).Rows[0][0].ToString();
                        double pageC = Math.Ceiling(Convert.ToInt32(strCount) / Convert.ToDouble(5));

                        context.Response.Write(pageC.ToString() + "|" + Json.GetJson(dtProduct));
                        //context.Response.Write(GetProduct(strcode, strKey, GetMemLoginId()));
                        break;
                    case "getinfobyId":
                        string strGuid = ShopNum1.Common.Common.ReqStr("guid");
                        var groupProduct = new Shop_GroupProduct_Action();
                        DataTable dts = groupProduct.GetProductById(strGuid, GetMemLoginId());
                        context.Response.Write(dts.Rows[0]["shopprice"] + "," + dts.Rows[0]["repertorycount"] + "," +
                                               dts.Rows[0]["name"]);
                        break;
                }
            }
            if (context.Request.Form.Count > 0)
            {
                string strThemeGuid = context.Request.Form["ThemeGuid"].Trim();
                string strValues = context.Request.Form["strValues"];
                strValues = strValues.Replace("*", "/");
                strValues = strValues.TrimEnd('|');
                string[] strArry = strValues.Split('|');
                var activity_Action =
                    (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
                for (int i = 0; i < strArry.Length; i++)
                {
                    var themeActivityProduct = new ShopNum1_ThemeActivityProduct();
                    themeActivityProduct.Guid = Guid.NewGuid();
                    themeActivityProduct.ThemeGuid = strThemeGuid;
                    themeActivityProduct.ProductGuid = strArry[i].Split(',')[0];
                    themeActivityProduct.ProductName = strArry[i].Split(',')[1];
                    themeActivityProduct.ProductImage = strArry[i].Split(',')[2];
                    themeActivityProduct.ProductPrice = Convert.ToDecimal(strArry[i].Split(',')[3]);
                    themeActivityProduct.ShopName = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                                                                       " and memloginid='" + GetMemLoginId() + "'");
                    themeActivityProduct.MemloginID = GetMemLoginId();
                    themeActivityProduct.IsAudit = "0";
                    themeActivityProduct.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    activity_Action.AddThemeProduct(themeActivityProduct);
                }
                context.Response.Write("OK");
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

        public string GetProduct(string code, string textName, string MemLoginID)
        {
            var groupProduct = new Shop_GroupProduct_Action();
            DataTable dt = groupProduct.GetProduct(50, code, textName, MemLoginID);
            double pageC = Math.Ceiling(Convert.ToInt32(dt.Rows.Count) / Convert.ToDouble(5));
            return Json.GetJson(dt);
        }

        private DataTable GetData(HttpContext context, string strName, string strProCode, string strPageId,
                                  string strResultNum, string ThemeGuid)
        {
            //排除该主题已添加的商品
            var activity_Action = (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
            //DataTable dtproduct = activity_Action.SelectProductByThemeGuid(ThemeGuid);
            //string listProductGuid = string.Empty;
            //if (null != dtproduct && dtproduct.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtproduct.Rows.Count; i++)
            //    {
            //        if (i != dtproduct.Rows.Count - 1)
            //            listProductGuid += "'" + dtproduct.Rows[i]["ProductGuid"] + "'" + ",";
            //        else
            //            listProductGuid += "'" + dtproduct.Rows[i]["ProductGuid"] + "'";
            //    }
            //}

            try
            {
                int.Parse(strProCode);
            }
            catch
            {
                return null;
            }
            string strPageSize = "5";
            string strCurrentPage = strPageId;
            //string strCondit = " and issaled=1 and issell=1 and isaudit=1 and guid not in(SELECT productguid FROM ShopNum1_PackAgeRalate ) and isreal!=0";
            string strCondit = " and memloginId='" + GetMemLoginId() +
                               "' and issell=1 and isdeleted=0 and isaudit=1 and issaled=1 ";
            if (strName != "")
                strCondit += " and name like '%" + strName + "%'";
            if (strProCode != "0")
                strCondit += " and ProductSeriesCode like '" + strProCode + "%'";
            //排除已选择的商品
            if (!string.IsNullOrEmpty(ThemeGuid))
            {
                strCondit += " and Guid not in(SELECT ProductGuid FROM ShopNum1_ThemeActivityProduct where ThemeGuid='" +
                             ThemeGuid + "')";
            }
            string strSortValue = "desc";
            string strOrderColumn = "saletime";
            string strColumn = "Guid,Id,name,shopprice,Repertorycount,originalimage,ProductSeriesCode,memloginId";
            string strTabName = "shopnum1_shop_product";
            return PackAge_Action.SelectPackAgeProduct(strPageSize, strCurrentPage, strCondit, strResultNum, strSortValue,
                                                       strOrderColumn, strColumn, strTabName);
        }
    }
}