using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Second;

namespace ShopNum1.Deploy.Main.Second.Alipay
{
    public partial class AlipayReturn : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> requestGet = GetRequestGet();
            var _config = new ShopNum1_Alipay_config();
            string partner = _config.Partner;
            string key = _config.Key;
            string str3 = _config.Input_charset;
            string str4 = _config.Sign_type;
            string transport = _config.Transport;
            if (requestGet.Count > 0)
            {
                var _notify = new ShopNum1_Alipay_notify(requestGet, base.Request.QueryString["notify_id"], partner, key,
                                                         str3, str4, transport);
                string responseTxt = _notify.ResponseTxt;
                string str7 = base.Request.QueryString["sign"];
                string mysign = _notify.Mysign;
                if ((responseTxt == "true") && (str7 == mysign))
                {
                    string str9 = base.Request.QueryString["user_id"];
                    base.Response.Redirect("~/threelogin.aspx?type=4&user_id=" + str9);
                }
            }
        }

        public SortedDictionary<string, string> GetRequestGet()
        {
            int index = 0;
            var dictionary = new SortedDictionary<string, string>();
            string[] allKeys = base.Request.QueryString.AllKeys;
            for (index = 0; index < allKeys.Length; index++)
            {
                dictionary.Add(allKeys[index], base.Request.QueryString[allKeys[index]]);
            }
            return dictionary;
        }
    }
}