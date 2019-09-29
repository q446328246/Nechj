using System;
using System.Configuration;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Second;

namespace ShopNum1.Deploy.Main.Second.Baidu
{
    public partial class BaiduReturn : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["code"] != null)
            {
                var bussiness = new ShopNum1_SecondTypeBussiness();
                string code = Page.Request.QueryString["code"];
                DataTable model = bussiness.GetModel(2);
                ShopNum1_BaiduOAuthMessage message =
                    new ShopNum1_BaiduOAuthClient().GetAccessTokenByAuthorizationCode(
                        model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(), code,
                        "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Baidu/BaiduReturn.aspx");
                if (message != null)
                {
                    base.Response.Redirect("~/threelogin.aspx?type=2&access_token=" + message.Access_token);
                }
            }
        }
    }
}