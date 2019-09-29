using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopWeiXinApiConfig : BaseShopWebControl
    {
        private string skinFilename = "W_ShopWeiXinApiConfig.ascx";
        private TextBox txt_appid;
        private TextBox txt_appsecret;
        private TextBox txt_token;
        private TextBox txt_tokenurl;

        public W_ShopWeiXinApiConfig()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_tokenurl = (TextBox) skin.FindControl("txt_tokenurl");
            txt_token = (TextBox) skin.FindControl("txt_token");
            txt_appid = (TextBox) skin.FindControl("txt_appid");
            txt_appsecret = (TextBox) skin.FindControl("txt_appsecret");
            IShopNum1_Weixin_ShopWeiXinConfig_Active active = new ShopNum1_Weixin_ShopWeiXinConfig_Active();
            DataTable weixinConfig = active.GetWeixinConfig(base.MemLoginID);
            if (weixinConfig.Rows.Count != 0)
            {
                txt_tokenurl.Text = weixinConfig.Rows[0]["TokenURL"].ToString();
                txt_token.Text = weixinConfig.Rows[0]["Token"].ToString();
                txt_appid.Text = weixinConfig.Rows[0]["AppId"].ToString();
                txt_appsecret.Text = weixinConfig.Rows[0]["AppSecret"].ToString();
            }
            if (string.IsNullOrEmpty(txt_tokenurl.Text))
            {
                txt_tokenurl.Text = Guid.NewGuid().ToString().Replace("-", "");
            }
            if (string.IsNullOrEmpty(txt_token.Text))
            {
                txt_token.Text = Guid.NewGuid().ToString().Replace("-", "");
            }
            txt_tokenurl.Text = string.Format("http://{0}/api/shopadmin/api_weixin.ashx?shopowner={1}",
                HttpContext.Current.Request.Url.Host, txt_tokenurl.Text);
        }
    }
}