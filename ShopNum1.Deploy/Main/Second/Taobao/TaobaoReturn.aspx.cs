using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Common;
using ShopNum1.Second;

namespace ShopNum1.Deploy.Main.Second.Taobao
{
    public partial class TaobaoReturn : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["code"] != null)
            {
                var bussiness = new ShopNum1_SecondTypeBussiness();
                string code = Page.Request.QueryString["code"];
                DataTable model = bussiness.GetModel(6);
                ShopNum1_TaobaoOAuthMessage message =
                    new ShopNum1_TaobaoOAuthClient().GetAccessTokenByAuthorizationCode(
                        model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(), code,
                        "http://" + ConfigurationManager.AppSettings["Domain"] + "/API/Second/Taobao/TaobaoReturn.aspx");
                string str2 = Guid.NewGuid().ToString();
                HttpCookie cookie = null;
                cookie = new HttpCookie("ThirdpartyLoginCheck");
                cookie.Values.Add("Check", str2);
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                HttpContext.Current.Response.AppendCookie(cookie2);
                if (message != null)
                {
                    base.Response.Redirect(
                        string.Concat(new object[]
                            {
                                "~/threelogin.aspx?authorizecode=shopnum1&check=", str2, "&type=5&access_token=",
                                message.Access_token, "&user_id=", message.Taobao_user_id
                            }));
                }
            }
        }
    }
}