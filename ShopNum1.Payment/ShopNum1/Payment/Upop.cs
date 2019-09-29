using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using ShopNum1.Common;
using com.unionpay.upop.sdk;

namespace ShopNum1.Payment
{
    public class Upop
    {
        public bool GoToUpopUrl(string strProductName, string strOrderId, string strPrice, string frontEndUrl,
                                string backEndUrl, out string url, out Encoding charset)
        {
            bool result;
            try
            {
                UPOPSrv.LoadConf(HttpContext.Current.Server.MapPath("./WebConfig/conf.xml.config").Replace("Main", ""));
                var dictionary = new Dictionary<string, string>();
                //Random random = new Random();
                //DateTime.Now.ToString("yyyyMMddHHmmss") + (random.Next(900) + 100).ToString().Trim();
                string str = string.Empty;
                if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                    HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                    str = httpCookie.Values["MemLoginID"];
                }
                dictionary["transType"] = "01";
                dictionary["commodityUrl"] = "http://emall.chinapay.com/product?name=jelybuy";
                dictionary["commodityName"] = "商品支付";
                dictionary["commodityUnitPrice"] = "11000";
                dictionary["commodityQuantity"] = "1";
                dictionary["orderNumber"] = strOrderId;
                dictionary["orderAmount"] = strPrice;
                dictionary["orderCurrency"] = "156";
                dictionary["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                dictionary["customerIp"] = "172.17.136.34";
                dictionary["frontEndUrl"] = frontEndUrl + "?sendmoney=" + str;
                dictionary["backEndUrl"] = backEndUrl + "?sendmoney=" + str;
                var frontPaySrv = new FrontPaySrv(dictionary);
                charset = frontPaySrv.Charset;
                url = frontPaySrv.CreateHtml();
                result = true;
            }
            catch
            {
                url = "";
                charset = Encoding.ASCII;
                result = false;
            }
            return result;
        }

        public bool GoToUpopUrl(string strshopId, string strProductName, string strOrderId, string strPrice,
                                string frontEndUrl, string backEndUrl, out string url, out Encoding charset)
        {
            bool result;
            try
            {
                UPOPSrv.LoadConf(HttpContext.Current.Server.MapPath("./App_Data/conf.xml.config").Replace("Main", ""));
                var dictionary = new Dictionary<string, string>();
                //Random random = new Random();
                //DateTime.Now.ToString("yyyyMMddHHmmss") + (random.Next(900) + 100).ToString().Trim();
                dictionary["transType"] = "01";
                dictionary["commodityUrl"] = "http://emall.chinapay.com/product?name=商品";
                dictionary["commodityName"] = "商品支付";
                dictionary["commodityUnitPrice"] = "11000";
                dictionary["commodityQuantity"] = "1";
                dictionary["orderNumber"] = strOrderId;
                dictionary["orderAmount"] = strPrice;
                dictionary["orderCurrency"] = "156";
                dictionary["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                dictionary["customerIp"] = "172.17.136.34";
                dictionary["frontEndUrl"] = frontEndUrl + "?sendmoney=" + strshopId;
                dictionary["backEndUrl"] = backEndUrl + "?sendmoney=" + strshopId;
                var frontPaySrv = new FrontPaySrv(dictionary);
                charset = frontPaySrv.Charset;
                url = frontPaySrv.CreateHtml();
                result = true;
            }
            catch
            {
                url = "";
                charset = Encoding.ASCII;
                result = false;
            }
            return result;
        }
    }
}