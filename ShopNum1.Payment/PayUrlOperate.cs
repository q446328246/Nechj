using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using Com.Alipay;

namespace ShopNum1.Payment
{
    public class PayUrlOperate
    {
        public string GetPayUrl(string paymentGuid, string shouldPayPrice, string dourl, string prNames,string strTradeID, string type, string IsAllPayMent, string PayMentMemloginID,string memloginid, string timetemp)
        {
            string paymentType = string.Empty;
            ShopNum1_OrderInfo_Action orderAction=(ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            
            var shopNum1_Payment_Action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(paymentGuid);
            var shopNum1_ShopPayment_Action = new ShopNum1_ShopPayment_Action();
            string result;
            if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
            {
                paymentInfoByGuid = shopNum1_ShopPayment_Action.GetPaymentInfoByGuid(paymentGuid);
                if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
                {
                    MessageBox.Show("支付有异常！");
                    result = "";
                    return result;
                }
            }

            paymentType = paymentInfoByGuid.Rows[0]["PaymentType"].ToString();
            var payInfo = new PayInfo();
            var pay = new Pay();

            switch (paymentType)
            {
                case "Dinpay.aspx": 
                    {
                        string text3 = string.Empty;
                        payInfo.merchant_code = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.service_type = "direct_pay";
                        payInfo.input_charset = "UTF-8";
                        payInfo.Notify_url = ShopSettings.dinpaynotifr;
                        //payInfo.Notify_url = @"http://test.tj88.com/PayReturn/Dinpay/DinpayToMer_notify.aspx";
                        payInfo.interface_version = "V3.0";
                        payInfo.SignType = "MD5";
                        payInfo.order_no = strTradeID;
                        payInfo.order_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
                        payInfo.order_amount = shouldPayPrice;
                        payInfo.ProductName=strTradeID;
                        payInfo.bank_code="";
                        payInfo.client_ip="";
                        payInfo.extend_param="";
                        payInfo.extra_return_param = prNames + "|" + type;
                        payInfo.product_code="";
                        payInfo.product_desc="";
                        payInfo.product_num="";
                        payInfo.Return_url = ShopSettings.dinpaypage;
                        //payInfo.Return_url = @"http://test.tj88.com/PayReturn/Dinpay/DinpayToMer_page.aspx";
                        payInfo.Show_url="";
                        payInfo.redo_flag="";
                        if (pay.Dinpay(payInfo, out text3))
                        {
                            result = text3;
                            return result;
                        }
                        result = "";
                        return result;


                    }
                case "Xpay.aspx":
                    {
                        string text3 = string.Empty;
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString(); //
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.OrderNumber = strTradeID.Substring(0, 6);
                        payInfo.ProductName = strTradeID;
                        payInfo.ProductType = "";
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.ProductPrice = shouldPayPrice;
                        payInfo.Description = "";
                        if (pay.XpayPay(payInfo, out text3))
                        {
                            result = text3;
                            return result;
                        }
                        result = "";
                        return result;
                    }
                case "Alipay.aspx":
                    {
                        payInfo.Gateway = "https://www.alipay.com/cooperate/gateway.do?";
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.SignType = "MD5";
                        payInfo.ProductName = strTradeID;
                        payInfo.Description = prNames;
                        payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
                        payInfo.Quantity = "1";
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.Return_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["receivealipay1_url"];
                        payInfo.Notify_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["showalipay1_url"];
                        payInfo.Logistics_type = "EXPRESS";
                        payInfo.Logistics_fee = "0";
                        payInfo.Logistics_payment = "BUYER_PAY";
                        payInfo.Show_url = "javascript:void(0)";
                        payInfo.Info1 = "shop1";
                        payInfo.Info2 = "shop2";
                        payInfo.OrderNumber = strTradeID;
                        string text3;
                        pay.AlipayPay(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "Alipay2.aspx":
                    {
                        payInfo.ProductName = strTradeID;
                        payInfo.Body = prNames;
                        payInfo.Quantity = "1";
                        payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
                        payInfo.OrderNumber = strTradeID;
                        payInfo.Logistics_type = "EXPRESS";
                        payInfo.Logistics_fee = "0";
                        payInfo.Logistics_payment = "BUYER_PAY";
                        payInfo.Logistics_type_1 = "POST";
                        payInfo.Logistics_fee_1 = "0";
                        payInfo.Logistics_payment_1 = "BUYER_PAY";
                        payInfo.Show_url = "http://" + dourl;
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["showalipay1_url"];
                        payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["receivealipay1_url"];
                        string text3;
                        pay.AlipayPay2(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "Alipay3.aspx":
                    {
                        payInfo.ProductName = strTradeID + "|" + method_0();
                        payInfo.Body = prNames + "|" + type;
                        payInfo.OrderNumber = strTradeID;
                        payInfo.ShouldPayPrice = Convert.ToString(shouldPayPrice);
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.Seller_email = paymentInfoByGuid.Rows[0]["Email"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        //显示  <add key="receivealipay2_url" value="/PayReturn/Alipay/alipay2_receive.aspx" />
                        payInfo.Return_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["showalipay2_url"];
                        //处理  <add key="showalipay2_url" value="/PayReturn/Alipay/alipay2_show.aspx" />
                        payInfo.Notify_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["receivealipay2_url"];
                        payInfo.Show_url = "http://" + ShopSettings.siteDomain;
                        payInfo.Payment_type = IsAllPayMent;
                        string text3;
                        if (pay.AlipayPay3(payInfo, out text3))
                        {
                            result = text3;
                            return result;
                        }
                        result = "";
                        return result;
                    }
                case "Allbuy.aspx":
                    {
                        payInfo.ProductName = strTradeID;
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.OrderNumber = strTradeID.Substring(0, 6);
                        payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
                        payInfo.CreateTime = DateTime.Now.ToString("yyyy-M-d");
                        payInfo.Description = "";
                        payInfo.Payment_type = IsAllPayMent;
                        string text3;
                        pay.AllBuyPay(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "Yeepay.aspx":
                    {
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.OrderNumber = strTradeID;
                        payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
                        payInfo.ProductName = strTradeID;
                        payInfo.ProductType = "1";
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.Description = "";
                        payInfo.SellerRemark = "";
                        payInfo.Return_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["callback"];
                        string text3;
                        pay.YeepayPay(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "YeepaySZX.aspx":
                    {
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.OrderNumber = strTradeID.Substring(0, 6);
                        payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
                        payInfo.ProductName = strTradeID;
                        payInfo.ProductType = "1";
                        payInfo.Description = "";
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.SellerRemark = "";
                        payInfo.FormID = "";
                        string empty = string.Empty;
                        string text3;
                        pay.YeepayPaySZX(payInfo, out text3, out empty);
                        result = text3;
                        return result;
                    }
                case "TenpayMed.aspx":
                    {
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.ProductName = strTradeID;
                        payInfo.Description = strTradeID;
                        payInfo.ProductPrice = Convert.ToString(Math.Round(Convert.ToDecimal(shouldPayPrice)*100m, 0));
                        payInfo.ProductType = "1";
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.TransportType = "2";
                        payInfo.TransportPrice = "0";
                        payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["show_url"];
                        payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["mch_returl"];
                        payInfo.OrderNumber = strTradeID.Substring(0, 10);
                        payInfo.ShouldPayPrice = "0";
                        string text3;
                        if (pay.TenpayMedPay(payInfo, out text3))
                        {
                            result = text3;
                            return result;
                        }
                        result = "";
                        return result;
                    }
                case "Tenpay.aspx":
                    {
                        payInfo.ProductName = strTradeID;
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();//商户号
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.OrderNumber = strTradeID.Trim();
                        payInfo.ShouldPayPrice = Convert.ToString(Convert.ToDouble(shouldPayPrice)*100.0);
                        payInfo.Return_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["tenpayAppreturn_url"];
                        payInfo.Notify_url = "http://" + ShopSettings.siteDomain +
                                             ConfigurationManager.AppSettings["tenpayAppshow_url"];
                        string text3;
                        if (pay.TenpayPay(payInfo, out text3))
                        {
                            result = text3;
                            return result;
                        }
                        result = "";
                        return result;
                    }
                case "BankTransfer.aspx":
                    paymentInfoByGuid.Rows[0]["Memo"].ToString();
                    result = "";
                    return result;
                case "PreDeposits.aspx":
                    {
                        Dictionary<string, string> dictionary_ = method_1(new SortedDictionary<string, string>
                            {
                                {
                                    "paymoney",
                                    shouldPayPrice
                                },

                                {
                                    "tradeid",
                                    strTradeID
                                },

                                {
                                    "type",
                                    type.ToLower()
                                },

                                {
                                    "isallpay",
                                    IsAllPayMent.ToLower()
                                },

                                {
                                    "paymentshopid",
                                    PayMentMemloginID.ToLower()
                                },

                                {
                                    "memlogid",
                                    memloginid.ToLower()
                                },

                                {
                                    "timetemp",
                                    timetemp
                                }
                            });
                        string text4 = method_2(dictionary_, "GB2312");
                        result = string.Concat(new[]
                            {
                                "~/PreDeposits.aspx?PayMoney=",
                                shouldPayPrice,
                                "&TradeID=",
                                strTradeID,
                                "&type=",
                                type.ToLower(),
                                "&IsAllPay=",
                                IsAllPayMent,
                                "&PayMentShopID=",
                                PayMentMemloginID.ToLower(),
                                "&memlogid=",
                                memloginid.ToLower(),
                                "&sign=",
                                text4,
                                "&timetemp=",
                                timetemp
                            });
                        return result;
                    }
                case "PayPal.aspx":
                    {
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.OrderNumber = strTradeID.Substring(0, 6);
                        payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.ProductName = prNames;
                        string text3;
                        pay.PayPalPay(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "huanxun.aspx":
                    result = string.Concat(new[]
                        {
                            "/PayReturn/HuanXun/Hx_Post.aspx?OrderNumber=",
                            strTradeID,
                            "&amount=",
                            shouldPayPrice,
                            "&sign=huanxun"
                        });
                    return result;
                case "wanghuitong.aspx":
                    {
                        payInfo.MerchantId = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.OrderNumber = strTradeID;
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.ProductPrice = Convert.ToString(shouldPayPrice);
                        payInfo.DesKey = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new[]
                            {
                                '|'
                            })[0].ToUpper();
                        payInfo.MPK = paymentInfoByGuid.Rows[0]["SecretKey"].ToString().Split(new[]
                            {
                                '|'
                            })[1].ToUpper();
                        payInfo.Wht_n = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new[]
                            {
                                '|'
                            })[0].ToUpper();
                        payInfo.Wht_e = paymentInfoByGuid.Rows[0]["SecredKey"].ToString().Split(new[]
                            {
                                '|'
                            })[1].ToUpper();
                        payInfo.MerURL = "http://" + dourl + ConfigurationManager.AppSettings["merURL"];
                        payInfo.PostUrl = "http://www.udpay.com.cn/gateway/cashback.jsp";
                        string text3 = pay.wanghuitong(payInfo);
                        result = text3;
                        return result;
                    }
                case "Send.aspx":
                    result = string.Concat(new[]
                        {
                            "http://",
                            dourl.Split(new[]
                                {
                                    '/'
                                })[0],
                            ConfigurationManager.AppSettings["showbank_url"],
                            "?id=",
                            strTradeID,
                            "&&PayType=",
                            IsAllPayMent
                        });
                    return result;
                case "BankOnline.aspx":
                    result = "PayReturn/BankSend.aspx?ID=" + strTradeID + "&&PayType=" + IsAllPayMent;
                    return result;
                case "NetPayClient.aspx":
                    {
                        payInfo.Gateway = "http://payment.chinapay.com/pay/TransGet";
                        payInfo.Mer_code = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.OrderNumber = strTradeID;
                        PayInfo arg_F70_0 = payInfo;
                        int num = Convert.ToInt32(decimal.Parse(shouldPayPrice)*100m);
                        arg_F70_0.ProductPrice = num.ToString();
                        payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                        payInfo.SignType = "MD5";
                        payInfo.ProductName = strTradeID;
                        payInfo.Payment_type = IsAllPayMent;
                        payInfo.Description = prNames;
                        payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
                        payInfo.Quantity = "1";
                        payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
                        payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                        payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["unionreturn_url"];
                        payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["unionshow_url"];
                        payInfo.Logistics_type = "EXPRESS";
                        payInfo.Logistics_fee = "0";
                        payInfo.Logistics_payment = "BUYER_PAY";
                        payInfo.Show_url = "http://" + dourl;
                        payInfo.OrderNumber = strTradeID;
                        string text3;
                        Encoding arg;
                        pay.UnionNetPay(payInfo, out text3, out arg);
                        result = arg + "|" + text3;
                        return result;
                    }
                case "ABCPay.aspx":
                    {
                        payInfo.ABCOrderNO = strTradeID;
                        payInfo.ABCExpiredDate = 10;
                        payInfo.ABCOrderDesc = type;
                        payInfo.ABCOrderDate = DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                        payInfo.ABCOrderTime = DateTime.Now.ToString("hh:MM:ss");
                        payInfo.ABCOrderAmount = double.Parse(shouldPayPrice);
                        payInfo.ABCOrderURL = string.Format("http://{0}{1}", dourl,
                                                            ConfigurationManager.AppSettings["abcsearch_url"]);
                        payInfo.ABCBuyIP = "127.0.0.1";
                        payInfo.ABCProductType = "1";
                        payInfo.ABCPaymentType = "1";
                        payInfo.ABCPaymentLinkType = "1";
                        payInfo.ABCNotifyType = "1";
                        payInfo.ABCResultNotifyURL =
                            string.Format("http://{0}{1}?memloginid={2}&TradeID={3}&OperateType={4}&OrderAmount={5}",
                                          new object[]
                                              {
                                                  dourl,
                                                  ConfigurationManager.AppSettings["abcpayreceive_url"],
                                                  memloginid,
                                                  strTradeID,
                                                  type,
                                                  shouldPayPrice
                                              });
                        payInfo.ABCMerchantRemarks = "";
                        string text3;
                        pay.ABCPayMent(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "CCBPay.aspx":
                    {
                        payInfo.CCBMerchantID = string.Format("{0}", paymentInfoByGuid.Rows[0]["MerchantCode"]);
                        payInfo.CCBPosID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecretKey"]);
                        payInfo.CCBBranchID = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecondKey"]);
                        payInfo.CCBOrderID = strTradeID;
                        payInfo.CCBPayMent = shouldPayPrice;
                        payInfo.CCBCurCode = "01";
                        payInfo.CCBTxCode = "520100";
                        payInfo.CCBRemark1 = type;
                        payInfo.CCBRemark2 = memloginid;
                        string text3;
                        pay.CCBPay(payInfo, out text3);
                        result = text3;
                        return result;
                    }
                case "Baofoo.aspx":
                    result = "/PayReturn/Baofoo/Baofoopay_post.aspx?OrderNumber=" + strTradeID + "&price=" +
                             shouldPayPrice;
                    return result;
                case "ShengPay.aspx":
                    result = string.Concat(new[]
                        {
                            "/PayReturn/ShengPay/SP_Post.aspx?OrderNumber=",
                            strTradeID,
                            "&amount=",
                            shouldPayPrice,
                            "&sign=ShengPay"
                        });
                    return result;
            }
            result = "";
            return result;
        }

        private string method_0()
        {
            string result = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                result = httpCookie.Values["MemLoginID"];
            }
            return result;
        }

        public string GetPayUrl(string shopid, string paymentGuid, string shouldPayPrice, string dourl, string prNames,
                                string strTradeID, string type, string IsAllPayMent, string PayMentMemloginID,
                                string memloginid, string timetemp)
        {
            string paymentType = string.Empty;
            var shopNum1_Payment_Action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(paymentGuid);
            string result;
            if (paymentInfoByGuid == null || paymentInfoByGuid.Rows.Count <= 0)
            {
                MessageBox.Show("支付有异常！");
                result = "";
            }
            else
            {
                paymentType = paymentInfoByGuid.Rows[0]["PaymentType"].ToString();
                var payInfo = new PayInfo();
                var pay = new Pay();

                if (paymentType != null && paymentType == "NetPayClient.aspx")
                {
                    string empty = string.Empty;
                    payInfo.SellerID = shopid;
                    payInfo.Gateway = "http://payment.chinapay.com/pay/TransGet";
                    payInfo.Mer_code = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                    payInfo.OrderNumber = strTradeID;
                    payInfo.ProductPrice = Convert.ToInt32(decimal.Parse(shouldPayPrice)*100m).ToString();
                    payInfo.PlatSupplierID = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                    payInfo.SignType = "MD5";
                    payInfo.ProductName = strTradeID;
                    payInfo.Payment_type = IsAllPayMent;
                    payInfo.Description = prNames;
                    payInfo.SiglePrice = Convert.ToString(shouldPayPrice);
                    payInfo.Quantity = "1";
                    payInfo.SellerID = paymentInfoByGuid.Rows[0]["Email"].ToString();
                    payInfo.Key = paymentInfoByGuid.Rows[0]["SecretKey"].ToString();
                    payInfo.Return_url = "http://" + dourl + ConfigurationManager.AppSettings["unionreturn_url"];
                    payInfo.Notify_url = "http://" + dourl + ConfigurationManager.AppSettings["unionshow_url"];
                    payInfo.Logistics_type = "EXPRESS";
                    payInfo.Logistics_fee = "0";
                    payInfo.Logistics_payment = "BUYER_PAY";
                    payInfo.Show_url = "http://" + dourl;
                    payInfo.OrderNumber = strTradeID;
                    Encoding arg;
                    pay.UnionNetPay(payInfo, out empty, out arg);
                    result = arg + "|" + empty;
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }

        public bool CheckSign(SortedDictionary<string, string> dicArrayPre, string sign)
        {
            Dictionary<string, string> dictionary_ = method_1(dicArrayPre);
            string a = method_2(dictionary_, "GB2312");
            return !(a != sign);
        }

        public string ConfimSendProduct(string partner, string trade_no, string LogisticsCompany, string ShipmentNumber)
        {
            var shopNum1_Payment_Action = (ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
            string key = string.Empty;
            if (paymentKey.Rows.Count > 0)
            {
                key = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            Submit._key = key;
            return Submit.BuildRequest(new SortedDictionary<string, string>
                {
                    {
                        "partner",
                        partner
                    },

                    {
                        "_input_charset",
                        Config.Input_charset.ToLower()
                    },

                    {
                        "service",
                        "send_goods_confirm_by_platform"
                    },

                    {
                        "trade_no",
                        trade_no
                    },

                    {
                        "logistics_name",
                        LogisticsCompany
                    },

                    {
                        "invoice_no",
                        ShipmentNumber
                    },

                    {
                        "transport_type",
                        "EXPRESS"
                    }
                });
        }

        public string Sign(string prestr, string _input_charset)
        {
            prestr = "~(*&^%$#@!" + prestr + "shopnum1mall123456";
            var stringBuilder = new StringBuilder(32);
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        private Dictionary<string, string> method_1(SortedDictionary<string, string> sortedDictionary_0)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var current in sortedDictionary_0)
            {
                if (current.Key.ToLower() != "sign" && current.Value != "")
                {
                    dictionary.Add(current.Key.ToLower(), current.Value);
                }
            }
            return dictionary;
        }

        private string method_2(Dictionary<string, string> dictionary_0, string string_0)
        {
            string text = method_3(dictionary_0);
            int length = text.Length;
            text = text.Substring(0, length - 1);
            return Sign(text, string_0);
        }

        private string method_3(Dictionary<string, string> dictionary_0)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dictionary_0)
            {
                stringBuilder.Append(current.Key + "=" + current.Value + "&");
            }
            return stringBuilder.ToString();
        }
    }
}