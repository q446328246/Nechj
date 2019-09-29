using System;
using System.Text;
using System.Web;
using System.Web.Security;
using ShopNum1.Payment.ABCPay;
using ShopNum1.Payment.CCBPay;
using UdpaySecurity;

namespace ShopNum1.Payment
{
    public class Pay
    { 
        /// <summary>
        /// 财付通中介支付
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool TenpayMedPay(PayInfo payInfo, out string url)
        {
            return new TenpayMed
                {
                    Key = payInfo.Key,
                    Chnid = payInfo.PlatSupplierID,
                    Seller = payInfo.SellerID,
                    Mch_name = payInfo.ProductName,
                    Mch_desc = payInfo.Description,
                    Mch_price = Convert.ToInt32(payInfo.ProductPrice),
                    Mch_type = Convert.ToInt32(payInfo.ProductType),
                    Transport_desc = payInfo.TransportType,
                    Transport_fee = Convert.ToInt32(payInfo.TransportPrice),
                    Mch_vno = payInfo.OrderNumber,
                    Total_fee = Convert.ToInt32(payInfo.ShouldPayPrice),
                    Mch_returl = payInfo.Notify_url,
                    Show_url = payInfo.Return_url,
                    Attach = payInfo.Attach
                }.GetPayUrl(out url);
        }

        /// <summary>
        /// 财付通 即时到帐支付接口 
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool TenpayPay(PayInfo payInfo, out string url)
        {
            var tenpay = new Tenpay();
            tenpay.Key = payInfo.Key;
            tenpay.Bargainor_id = payInfo.PlatSupplierID;
            tenpay.Sp_billno = payInfo.OrderNumber;
            tenpay.Transaction_id = tenpay.Bargainor_id + DateTime.Now.ToString("yyyyMMddHHmmss") +
                                    TenpayUtil.BuildRandomStr(4);
            tenpay.Return_url = payInfo.Return_url;
            tenpay.Desc = tenpay.Transaction_id;
            tenpay.Total_fee = Convert.ToInt64(payInfo.ShouldPayPrice);
            return tenpay.GetPayUrl(out url);
        }

        /// <summary>
        /// 财付通支付网关商户
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool Tenpay_DualPay(PayInfo payInfo, out string url)
        {
            var tenpay_Dual = new Tenpay_Dual(HttpContext.Current);
            string platSupplierID = payInfo.PlatSupplierID;
            string key = payInfo.Key;
            DateTime.Now.ToString("yyyyMMdd");
            string orderNumber = payInfo.OrderNumber;
            tenpay_Dual.setKey(key);
            tenpay_Dual.setGateUrl("https://gw.tenpay.com/gateway/pay.htm");
            tenpay_Dual.setParameter("partner", platSupplierID); //商户号
            tenpay_Dual.setParameter("out_trade_no", orderNumber); //商户订单号
            tenpay_Dual.setParameter("total_fee", payInfo.ShouldPayPrice); //总金额
            tenpay_Dual.setParameter("return_url", payInfo.Return_url); //返回 URL
            tenpay_Dual.setParameter("notify_url", payInfo.Notify_url);//通知URL
            tenpay_Dual.setParameter("body", payInfo.Body); //商品描述
            tenpay_Dual.setParameter("bank_type", "DEFAULT"); //银行类型 银行类型，默认为“DEFAULT”－财付通支付中心。银行直连编码及额度请与技术支持联系
            tenpay_Dual.setParameter("spbill_create_ip", HttpContext.Current.Request.UserHostAddress);
            tenpay_Dual.setParameter("fee_type", "1");
            tenpay_Dual.setParameter("subject", payInfo.ProductName);
            tenpay_Dual.setParameter("sign_type", "MD5");
            tenpay_Dual.setParameter("service_version", "1.0");
            tenpay_Dual.setParameter("input_charset", "GBK");
            tenpay_Dual.setParameter("sign_key_index", "1");
            tenpay_Dual.setParameter("attach", "");
            tenpay_Dual.setParameter("product_fee", "0");
            tenpay_Dual.setParameter("transport_fee", "0");
            tenpay_Dual.setParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            tenpay_Dual.setParameter("time_expire", "");
            tenpay_Dual.setParameter("buyer_id", "");
            tenpay_Dual.setParameter("goods_tag", "");
            tenpay_Dual.setParameter("trade_mode", "1");
            tenpay_Dual.setParameter("transport_desc", "");
            tenpay_Dual.setParameter("trans_type", payInfo.ProductType);
            tenpay_Dual.setParameter("agentid", "");
            tenpay_Dual.setParameter("agent_type", "");
            tenpay_Dual.setParameter("seller_id", "");
            url = tenpay_Dual.getRequestURL();
            return !string.IsNullOrEmpty(url);
        }

        /// <summary>
        /// 担保交易
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool AlipayPay(PayInfo payInfo, out string url)
        {
            string orderNumber = payInfo.OrderNumber;
            var alipay = new Alipay();
            return alipay.CreatUrl("https://www.alipay.com/cooperate/gateway.do?", "create_partner_trade_by_buyer",
                                   payInfo.PlatSupplierID, "MD5", orderNumber, payInfo.ProductName, payInfo.Description,
                                   payInfo.SiglePrice, payInfo.Show_url, payInfo.SellerID, payInfo.Key,
                                   payInfo.Return_url, "utf-8", payInfo.Notify_url, payInfo.Logistics_type,
                                   payInfo.Logistics_fee, payInfo.Logistics_payment, payInfo.Quantity, out url);
        }

        /// <summary>
        /// 支付宝担保交易
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool AlipayPayGB(PayInfo payInfo, out string url)
        {
            string text = DateTime.Now.ToString("g");
            text = text.Replace("-", "");
            text = text.Replace(":", "");
            text = text.Replace(" ", "");
            var alipayGB = new AlipayGB();
            return alipayGB.CreatUrl(payInfo.Gateway, "create_partner_trade_by_buyer", payInfo.PlatSupplierID, "MD5",
                                     text, payInfo.ProductName, payInfo.Description, payInfo.SiglePrice,
                                     "www.alipay.com", payInfo.SellerID, payInfo.Key, "Alipay_Return.aspx", "gb2312",
                                     "Alipay_Notify.aspx", "POST", "0", "BUYER_PAY", payInfo.Quantity,
                                     payInfo.Payment_type, out url);
        }

        /// <summary>
        /// 标准双接口
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool AlipayPay2(PayInfo payInfo, out string url)
        {
            string orderNumber = payInfo.OrderNumber;
            string gateway = "https://www.alipay.com/cooperate/gateway.do?";
            string service = "trade_create_by_buyer";
            string platSupplierID = payInfo.PlatSupplierID;
            string sign_type = "MD5";
            string productName = payInfo.ProductName;
            string body = payInfo.Body;
            string payment_type = "1";
            string siglePrice = payInfo.SiglePrice;
            string quantity = payInfo.Quantity;
            string show_url = payInfo.Show_url;
            string seller_email = payInfo.Seller_email;
            string key = payInfo.Key;
            string return_url = payInfo.Return_url;
            string notify_url = payInfo.Notify_url;
            string input_charset = "utf-8";
            string logistics_type = payInfo.Logistics_type;
            string logistics_fee = payInfo.Logistics_fee;
            string logistics_payment = payInfo.Logistics_payment;
            string logistics_type_ = payInfo.Logistics_type_1;
            string logistics_fee_ = payInfo.Logistics_fee_1;
            string logistics_payment_ = payInfo.Logistics_payment_1;
            var alipay = new Alipay2();
            return alipay.CreatUrl(gateway, service, platSupplierID, sign_type, orderNumber, productName, body,
                                   payment_type, siglePrice, show_url, seller_email, key, return_url, input_charset,
                                   notify_url, logistics_type, logistics_fee, logistics_payment, logistics_type_,
                                   logistics_fee_, logistics_payment_, quantity, out url);
        }

        /// <summary>
        ///  标准双接口交易
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool AlipayPay2GB(PayInfo payInfo, out string url)
        {
            string text = DateTime.Now.ToString("g");
            text = text.Replace("-", "");
            text = text.Replace(":", "");
            text = text.Replace(" ", "");
            string gateway = "https://www.alipay.com/cooperate/gateway.do?";
            string service = "trade_create_by_buyer";
            string platSupplierID = payInfo.PlatSupplierID;
            string sign_type = "MD5";
            string productName = payInfo.ProductName;
            string body = payInfo.Body;
            string quantity = payInfo.Quantity;
            string siglePrice = payInfo.SiglePrice;
            string show_url = "www.alipay.com";
            string seller_email = payInfo.Seller_email;
            string key = payInfo.Key;
            string return_url = payInfo.Return_url;
            string notify_url = payInfo.Notify_url;
            string logistics_type = "EMS";
            string transportPrice = payInfo.TransportPrice;
            string logistics_payment = "SELLER_PAY";
            string logistics_type_ = "EXPRESS";
            string logistics_fee_ = payInfo.Logistics_fee_1;
            string logistics_payment_ = "SELLER_PAY";
            string payment_type = "1";
            var alipay2GB = new Alipay2GB();
            return alipay2GB.CreatUrl(gateway, service, platSupplierID, sign_type, text, productName, body, quantity,
                                      siglePrice, show_url, seller_email, key, return_url, notify_url, logistics_type,
                                      transportPrice, logistics_payment, logistics_type_, logistics_fee_,
                                      logistics_payment_, payment_type, out url);
        }

        /// <summary>
        /// 即时到帐交易
        /// </summary>
        /// <param name="payInfo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool AlipayPay3(PayInfo payInfo, out string url)
        {
            string platSupplierID = payInfo.PlatSupplierID;
            string key = payInfo.Key;
            string seller_email = payInfo.Seller_email;
            string input_charset = "utf-8";
            string notify_url = payInfo.Notify_url;
            string return_url = payInfo.Return_url;
            string show_url = payInfo.Show_url;
            string sign_type = "MD5";
            string a = "0";
            string orderNumber = payInfo.OrderNumber;
            string productName = payInfo.ProductName;
            string body = payInfo.Body;
            string shouldPayPrice = payInfo.ShouldPayPrice;
            string paymethod = "bankPay";
            string defaultbank = "CMB";
            string encrypt_key = "";
            string exter_invoke_ip = "";
            if (a == "1")
            {
                encrypt_key = Alipay3.Query_timestamp(platSupplierID);
                exter_invoke_ip = "";
            }
            string extra_common_param = "";
            string buyer_email = "";
            string royalty_type = "";
            string royalty_parameters = "";
            string it_b_pay = "";
            var alipay = new Alipay3();
            return alipay.CreatUrl(platSupplierID, seller_email, return_url, notify_url, show_url, orderNumber,
                                   productName, body, shouldPayPrice, paymethod, defaultbank, encrypt_key,
                                   exter_invoke_ip, extra_common_param, buyer_email, royalty_type, royalty_parameters,
                                   it_b_pay, key, input_charset, sign_type, out url);
        }

        public bool YeepayPay(PayInfo payInfo, out string url)
        {
            var yeepay = new Yeepay();
            return yeepay.CreateBuyUrl(payInfo.SellerID, payInfo.Key, payInfo.OrderNumber, payInfo.ProductPrice, "CNY",
                                       payInfo.ProductName, payInfo.ProductType, payInfo.Description, payInfo.Return_url,
                                       "0", payInfo.SellerRemark, "", "1", out url);
        }

        public bool YeepayPaySZX(PayInfo payInfo, out string url, out string formid)
        {
            YeepaySZX yeepaySZX = new YeepaySZX();
            return yeepaySZX.CreateUrl(payInfo.SellerID, payInfo.Key, payInfo.OrderNumber, payInfo.ProductPrice, "CNY",
                                       payInfo.ProductName, payInfo.ProductType, payInfo.Description, payInfo.Return_url,
                                       "0", payInfo.SellerRemark, "", "1", payInfo.FormID, out url, out formid);
        }

        public bool XpayPay(PayInfo payInfo, out string url)
        {
            Xpay xpay = new Xpay();
            return xpay.CreateUrl("http://pay.xpay.cn/testpay.aspx", payInfo.Key, payInfo.SellerID, payInfo.OrderNumber,
                                  payInfo.ProductName, payInfo.ProductType, Convert.ToDecimal(payInfo.ProductPrice),
                                  "bank", "gb2312", "http://pay.xpay.cn/TestSuccess.aspx", "2.0", payInfo.Description,
                                  "sell", "", "", out url);
        }

        public bool Dinpay(PayInfo payInfo, out string url)
        {
            Dinpay Dinpay = new Dinpay();
            return Dinpay.CreateUrl(payInfo.input_charset, payInfo.interface_version, payInfo.merchant_code, payInfo.Notify_url, payInfo.order_amount, payInfo.order_no, payInfo.order_time, payInfo.SignType, payInfo.product_code, payInfo.product_desc, payInfo.ProductName, payInfo.product_num, payInfo.Return_url, payInfo.service_type, payInfo.Show_url, payInfo.extend_param, payInfo.extra_return_param, payInfo.bank_code, payInfo.client_ip, payInfo.redo_flag, out url);
        }

        public bool AllBuyPay(PayInfo payInfo, out string url)
        {
            var allbuy = new Allbuy();
            return allbuy.Createurl(payInfo.SellerID, payInfo.OrderNumber, payInfo.ProductPrice, payInfo.CreateTime,
                                    payInfo.Description, payInfo.Return_url, out url);
        }

        public bool NPSPay(PayInfo payInfo, out string url, out string sigestinfo)
        {
            var nps = new Nps();
            return nps.Createurl(payInfo.SellerID, payInfo.OrderNumber, payInfo.ProductPrice, "1", "null", "1",
                                 payInfo.BuyerID, payInfo.ClientAddress, payInfo.ClientPostalcode, payInfo.ClientTel,
                                 payInfo.ClientEmail, payInfo.Name, payInfo.Address, payInfo.Postalcode, payInfo.Tel,
                                 payInfo.Email, payInfo.Description, payInfo.CreateTime, payInfo.State,
                                 payInfo.Digestinfo, payInfo.Key, out url, out sigestinfo);
        }

        public bool Deliverypay()
        {
            return true;
        }

        public bool BankTransfer()
        {
            return true;
        }

        public bool PreDeposits()
        {
            return true;
        }

        public bool PayPalPay(PayInfo payInfo, out string url)
        {
            var payPal = new PayPal();
            return payPal.CreateUrl("https://www.paypal.com/xclick/business", payInfo.SellerID, payInfo.ProductName,
                                    payInfo.OrderNumber, Convert.ToDecimal(payInfo.ProductPrice), "", "", "", "", "CNY",
                                    payInfo.ReturnSuccessfulUrl, payInfo.ReturnErrorUrl, out url);
        }

        public string wanghuitong(PayInfo payInfo)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("txCode=TP006");
            stringBuilder.Append("&merchantId=" + payInfo.MerchantId);
            stringBuilder.Append("&transDateTime=20081217123159");
            stringBuilder.Append("&orderId=" + payInfo.OrderNumber);
            stringBuilder.Append("&curCode=156");
            stringBuilder.Append("&amount=" + ThreeDES.ThreeDES.Encrypt3DES(payInfo.ProductPrice, payInfo.DesKey));
            stringBuilder.Append("&merURL=" + payInfo.MerURL);
            stringBuilder.Append("&transType=ZX01");
            stringBuilder.Append("&info1=" + payInfo.Info1);
            stringBuilder.Append("&info2=" + payInfo.Info2);
            UdpayRsa.SignKeyParams.MPK = payInfo.MPK;
            UdpayRsa.SignKeyParams.Wht_n = payInfo.Wht_n;
            UdpayRsa.SignKeyParams.Wht_e = payInfo.Wht_e;
            UdpayRsa.LoadSignKey();
            string str = UdpayRsa.GenerateSigature(stringBuilder.ToString());
            stringBuilder.Append("&sign=" + str);
            return payInfo.PostUrl + "?" + stringBuilder;
        }

        public string huanxun(PayInfo payInfo)
        {
            string postUrl = payInfo.PostUrl;
            string mer_code = payInfo.Mer_code;
            string mer_key = payInfo.Mer_key;
            string orderNumber = payInfo.OrderNumber;
            string text = Convert.ToString(Math.Round(decimal.Parse(payInfo.ProductPrice), 2));
            string billDate = payInfo.BillDate;
            string currency_Type = payInfo.Currency_Type;
            string gateway_Type = payInfo.Gateway_Type;
            string lang = payInfo.Lang;
            string merchanturl = payInfo.Merchanturl;
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = Convert.ToString(Math.Round(decimal.Parse(payInfo.ProductPrice), 2));
            string text2 = "5";
            string str5 = "17";
            string str6 = "1";
            string show_url = payInfo.Show_url;
            string str7 = FormsAuthentication.HashPasswordForStoringInConfigFile(string.Concat(new[]
                {
                    "billno",
                    orderNumber,
                    "currencytype",
                    currency_Type,
                    "amount",
                    text,
                    "date",
                    billDate,
                    "orderencodetype",
                    text2,
                    mer_key
                }), "MD5").ToLower();
            string str8 = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + postUrl + "\">";
            str8 = str8 + "<input type=\"hidden\" name=\"Mer_code\" value=\"" + mer_code + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Billno\" value=\"" + orderNumber + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Amount\" value=\"" + text + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Date\" value=\"" + billDate + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Currency_Type\" value=\"" + currency_Type + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Gateway_Type\" value=\"" + gateway_Type + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Lang\" value=\"" + lang + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Merchanturl\" value=\"" + merchanturl + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"FailUrl\" value=\"" + str + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"ErrorUrl\" value=\"" + str2 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Attach\" value=\"" + str3 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"DispAmount\" value=\"" + str4 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"OrderEncodeType\" value=\"" + text2 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"RetEncodeType\" value=\"" + str5 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"Rettype\" value=\"" + str6 + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"ServerUrl\" value=\"" + show_url + "\" />";
            str8 = str8 + "<input type=\"hidden\" name=\"SignMD5\" value=\"" + str7 + "\" />";
            str8 += "</form>";
            return str8 +
                   "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";
        }

        public bool UnionNetPay(PayInfo payInfo, out string url, out Encoding charset)
        {
            var upop = new Upop();
            upop.GoToUpopUrl(payInfo.ProductName, payInfo.OrderNumber, payInfo.ProductPrice, payInfo.Return_url,
                             payInfo.Notify_url, out url, out charset);
            return true;
        }

        public bool ABCPayMent(PayInfo payInfo, out string strUrl)
        {
            var aBCPayMent = new ABCPayMent();
            return aBCPayMent.GetUrlABCPayMent(payInfo, out strUrl);
        }

        public bool CCBPay(PayInfo payInfo, out string strUrl)
        {
            var cCBPayMent = new CCBPayMent();
            return cCBPayMent.GetURLCCBPayMent(payInfo, out strUrl);
        }

        public bool ShengPay(PayInfo payInfo, out string strUrl)
        {
            var shengPayMent = new ShengPayMent();
            return shengPayMent.CreateUrl(payInfo, out strUrl);
        }
    }
}