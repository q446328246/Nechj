namespace ShopNum1.Second
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;

    public class ShopNum1_AlipayOAuthClient
    {
        private string a = "https://mapi.alipay.com/gateway.do?";
        private string c = "";
        private string d = "";
        private string e = "";
        private Dictionary<string, string> f = new Dictionary<string, string>();
        private ShopNum1_Alipay_function g = new ShopNum1_Alipay_function();

        public ShopNum1_AlipayOAuthClient(ShopNum1_Alipay_config Alipay_config)
        {
            SortedDictionary<string, string> dicArrayPre = new SortedDictionary<string, string>();
            dicArrayPre.Add("service", "alipay.auth.authorize");
            dicArrayPre.Add("target_service", "user.auth.quick.login");
            dicArrayPre.Add("partner", Alipay_config.Partner);
            dicArrayPre.Add("_input_charset", Alipay_config.Input_charset.ToLower());
            dicArrayPre.Add("return_url", Alipay_config.Return_url);
            this.f = this.g.Para_filter(dicArrayPre);
            this.e = this.g.Build_mysign(this.f, Alipay_config.Key.Trim(), Alipay_config.Sign_type.ToUpper(), Alipay_config.Input_charset.ToLower());
        }

        public string Build_Form()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + this.a + "_input_charset=" + this.c + "\" method=\"get\">");
            foreach (KeyValuePair<string, string> pair in this.f)
            {
                builder.Append("<input type=\"hidden\" name=\"" + pair.Key + "\" value=\"" + pair.Value + "\"/>");
            }
            builder.Append("<input type=\"hidden\" name=\"sign\" value=\"" + this.e + "\"/>");
            builder.Append("<input type=\"hidden\" name=\"sign_type\" value=\"" + this.d + "\"/>");
            builder.Append("<input type=\"submit\" value=\"支付宝会员登录\"></form>");
            return builder.ToString();
        }

        public void GetAuthorizationCode1()
        {
            this.f.Add("sign", this.e);
            this.f.Add("sign_type", this.d);
            string str = this.g.Create_linkstring(this.f);
            string url = string.Format(this.a + "{0}", str);
            HttpContext.Current.Response.Redirect(url);
        }

        public string GetAuthorizationUrl()
        {
            this.f.Add("sign", this.e);
            this.f.Add("sign_type", this.d);
            string str = this.g.Create_linkstring(this.f);
            return string.Format(this.a + "{0}", str);
        }
    }
}

