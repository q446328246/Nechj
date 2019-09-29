using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using ShopNum1.Common;

namespace ShopNum1.Payment
{
    public class Dinpay
    {
        public bool CreateUrl(string input_charset, string interface_version, string merchant_code, string notify_url, string order_amount, string order_no, string order_time, string sign_type, string product_code, string product_desc, string product_name, string product_num, string return_url, string service_type, string show_url, string extend_param, string extra_return_param, string bank_code, string client_ip, string redo_flag, out string url1)
        {
            bool result = true;
            try
            {

                string signSrc = ShopSettings.dinpayurl;
                //string signSrc = "http://test.tj88.com/PayReturn/Dinpay/MerDinpayUTF-8.aspx?";
                //组织订单信息

                signSrc = signSrc + "bank_code=" + bank_code + "&";


                signSrc = signSrc + "client_ip=" + client_ip + "&";


                signSrc = signSrc + "extend_param=" + extend_param + "&";

                signSrc = signSrc + "extra_return_param=" + extra_return_param + "&";

                signSrc = signSrc + "input_charset=" + input_charset + "&";

                signSrc = signSrc + "interface_version=" + interface_version + "&";

                signSrc = signSrc + "merchant_code=" + merchant_code + "&";

                signSrc = signSrc + "notify_url=" + notify_url + "&";

                signSrc = signSrc + "order_amount=" + order_amount + "&";

                signSrc = signSrc + "order_no=" + order_no + "&";

                signSrc = signSrc + "order_time=" + order_time + "&";

                signSrc = signSrc + "sign_type=" + sign_type + "&";

                signSrc = signSrc + "product_code=" + product_code + "&";

                signSrc = signSrc + "product_desc=" + product_desc + "&";

                signSrc = signSrc + "product_name=" + product_name + "&";

                signSrc = signSrc + "product_num=" + product_num + "&";

                signSrc = signSrc + "redo_flag=" + redo_flag + "&";

                signSrc = signSrc + "return_url=" + return_url + "&";

                signSrc = signSrc + "service_type=" + service_type + "&";

                signSrc = signSrc + "show_url=" + show_url;



                url1 = signSrc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
