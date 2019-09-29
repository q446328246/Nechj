using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;

namespace ShopNum1.Payment
{
    public class Alipay3
    {
        private string a = "";
        private string b = "";
        private string c = "";
        private string d = "";
        private string e = "";
        private Dictionary<string, string> f = new Dictionary<string, string>();

        public bool CreatUrl(string partner, string seller_email, string return_url, string notify_url, string show_url,
                             string out_trade_no, string subject, string body, string total_fee, string paymethod,
                             string defaultbank, string encrypt_key, string exter_invoke_ip, string extra_common_param,
                             string buyer_email, string royalty_type, string royalty_parameters, string it_b_pay,
                             string key, string input_charset, string sign_type, out string strUrl)
        {
            a = "https://www.alipay.com/cooperate/gateway.do?";
            b = key.Trim();
            c = input_charset.ToLower();
            d = sign_type.ToUpper();
            f = Para_filter(new SortedDictionary<string, string>
                {
                    {
                        "service",
                        "create_direct_pay_by_user"
                    },

                    {
                        "payment_type",
                        "1"
                    },

                    {
                        "partner",
                        partner
                    },

                    {
                        "seller_email",
                        seller_email
                    },

                    {
                        "return_url",
                        return_url
                    },

                    {
                        "notify_url",
                        notify_url
                    },

                    {
                        "_input_charset",
                        c
                    },

                    {
                        "show_url",
                        show_url
                    },

                    {
                        "out_trade_no",
                        out_trade_no
                    },

                    {
                        "subject",
                        subject
                    },

                    {
                        "body",
                        body
                    },

                    {
                        "total_fee",
                        total_fee
                    },

                    {
                        "paymethod",
                        paymethod
                    },

                    {
                        "defaultbank",
                        defaultbank
                    },

                    {
                        "anti_phishing_key",
                        encrypt_key
                    },

                    {
                        "exter_invoke_ip",
                        exter_invoke_ip
                    },

                    {
                        "extra_common_param",
                        extra_common_param
                    },

                    {
                        "buyer_email",
                        buyer_email
                    },

                    {
                        "royalty_type",
                        royalty_type
                    },

                    {
                        "royalty_parameters",
                        royalty_parameters
                    },

                    {
                        "it_b_pay",
                        it_b_pay
                    }
                });
            e = Build_mysign(f, b, d, c);
            strUrl = a;
            string text = Create_linkstring_urlencode(f);
            strUrl = string.Concat(new[]
                {
                    strUrl,
                    text,
                    "sign=",
                    e,
                    "&sign_type=",
                    d
                });
            return true;
        }

        public Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var current in dicArrayPre)
            {
                if (current.Key.ToLower() != "sign" && current.Key.ToLower() != "sign_type" && current.Value != "")
                {
                    dictionary.Add(current.Key.ToLower(), current.Value);
                }
            }
            return dictionary;
        }

        public string Build_mysign(Dictionary<string, string> dicArray, string key, string sign_type,
                                   string _input_charset)
        {
            string text = Create_linkstring(dicArray);
            int length = text.Length;
            text = text.Substring(0, length - 1);
            text += key;
            return Sign(text, sign_type, _input_charset);
        }

        public static string Create_linkstring(Dictionary<string, string> dicArray)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dicArray)
            {
                stringBuilder.Append(current.Key + "=" + current.Value + "&");
            }
            return stringBuilder.ToString();
        }

        public static string Sign(string prestr, string sign_type, string _input_charset)
        {
            var stringBuilder = new StringBuilder(32);
            if (sign_type.ToUpper() == "MD5")
            {
                MD5 mD = new MD5CryptoServiceProvider();
                byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return stringBuilder.ToString();
        }

        public static string Create_linkstring_urlencode(Dictionary<string, string> dicArray)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dicArray)
            {
                stringBuilder.Append(current.Key + "=" + HttpUtility.UrlEncode(current.Value) + "&");
            }
            return stringBuilder.ToString();
        }

        public static string Query_timestamp(string partner)
        {
            string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + partner;
            var reader = new XmlTextReader(url);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(reader);
            return xmlDocument.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
        }
    }
}