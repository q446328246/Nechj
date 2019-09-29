using System;
using System.Configuration;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Second;

namespace ShopNum1.Deploy.Main.Second.Xinlan
{
    public partial class XinlanReturn : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["code"] != null)
            {
                var bussiness = new ShopNum1_SecondTypeBussiness();
                string code = Page.Request.QueryString["code"];
                DataTable model = bussiness.GetModel(3);
                try
                {
                    ShopNum1_XinLanOAuthMessage message =
                        new ShopNum1_XinlanOAuthClient().GetAccessTokenByAppkeySecret(
                            model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(),
                            "http://" + ConfigurationManager.AppSettings["Domain"] +
                            "/Main/Second/Xinlan/XinlanReturn.aspx", code);
                    if (message != null)
                    {
                        base.Response.Redirect("~/threelogin.aspx?type=3&access_token=" + message.access_token + "&uid=" +
                                               message.uid);
                    }
                }
                catch (ShopNum1_XinlanOAuthException exception)
                {
                    base.Response.Write(exception.error + exception.Message + exception.error_description +
                                        exception.error_code);
                }
            }
            else if (base.Request.QueryString["error_uri"] != null)
            {
                base.Response.Redirect("~/default.aspx");
            }
        }
    }
}