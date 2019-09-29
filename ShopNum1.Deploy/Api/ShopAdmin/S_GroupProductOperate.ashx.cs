using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_GroupProductOperate 的摘要说明
    /// </summary>
    public class S_GroupProductOperate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (ShopNum1.Common.Common.ReqStr("type") != "")
            {
                var shop_ProductCategory_Action =
                    (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
                switch (ShopNum1.Common.Common.ReqStr("type"))
                {
                    case "getactivity":
                        var GroupProduct =
                            (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
                        DataTable dtv = GroupProduct.GetProductActivity();
                        context.Response.Write(Json.GetJson(dtv));
                        break;
                    case "getshoptype":
                        DataTable dt = shop_ProductCategory_Action.Search_Import(ShopNum1.Common.Common.ReqStr("id"), GetMemLoginId());
                        context.Response.Write(Json.GetJson(dt));
                        break;
                    case "getproduct":
                        string strcode = ShopNum1.Common.Common.ReqStr("code");
                        string strKey = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("keyword"));
                        context.Response.Write(GetProduct(strcode, strKey, GetMemLoginId()));
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
            return Json.GetJson(dt);
        }
    }
}