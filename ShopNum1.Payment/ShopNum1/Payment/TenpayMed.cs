using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class TenpayMed
    {
        private const int a1 = 2;
        private readonly string w1 = ConfigurationManager.AppSettings["paygateurl"];
        private string aa;
        private string ab = "";
        private string ac = "";
        private string b1 = "";
        private int c1 = 12;
        private int d1 = 1;
        private string e1 = "";
        private string f1 = "";
        private int g1 = 1;
        private int h1 = 1;
        private int i1 = 2;
        private int int_0 = 1;
        private string j1 = "";
        private string k1 = "";
        private string m1 = "2";
        private int n1 = 1;
        private int p1;
        private string q1 = "";
        private int r1;
        private string s1 = "3";
        private string string_0 = "";
        private string t1 = "";
        private string u1 = "";
        private string v1 = "";
        private string x1 = ConfigurationManager.AppSettings["querygateurl"];
        private string y1 = ConfigurationManager.AppSettings["mch_returl"];
        private string z1 = ConfigurationManager.AppSettings["show_url"];

        public string Chnid
        {
            get { return b1; }
            set { b1 = value; }
        }

        public int Cmdno
        {
            get { return c1; }
            set { c1 = value; }
        }

        public int Encode_type
        {
            get { return d1; }
            set { d1 = value; }
        }

        public string Mch_desc
        {
            get { return e1; }
            set { e1 = value; }
        }

        public string Mch_name
        {
            get { return f1; }
            set { f1 = value; }
        }

        public int Mch_price
        {
            get { return g1; }
            set { g1 = value; }
        }

        public int Mch_type
        {
            get { return h1; }
            set { h1 = value; }
        }

        public int Need_buyerinfo
        {
            get { return i1; }
            set { i1 = value; }
        }

        public string Sign
        {
            get { return j1; }
            set { j1 = value; }
        }

        public string Seller
        {
            get { return k1; }
            set { k1 = value; }
        }

        public string Transport_desc
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string Version
        {
            get { return m1; }
            set { m1 = value; }
        }

        public int Total_fee
        {
            get { return n1; }
            set { n1 = value; }
        }

        public int Trade_price
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public int Transport_fee
        {
            get { return p1; }
            set { p1 = value; }
        }

        public string Mch_vno
        {
            get { return q1; }
            set { q1 = value; }
        }

        public int Retcode
        {
            get { return r1; }
            set { r1 = value; }
        }

        public string Status
        {
            get { return s1; }
            set { s1 = value; }
        }

        public string Buyer_id
        {
            get { return t1; }
            set { t1 = value; }
        }

        public string Cft_tid
        {
            get { return u1; }
            set { u1 = value; }
        }

        public string Key
        {
            get { return v1; }
            set { v1 = value; }
        }

        public string Mch_returl
        {
            get { return y1; }
            set { y1 = value; }
        }

        public string Show_url
        {
            get { return z1; }
            set { z1 = value; }
        }

        public string Date
        {
            get
            {
                if (aa == null)
                {
                    aa = DateTime.Now.ToString("yyyyMMdd");
                }
                return aa;
            }
            set
            {
                if (value == null || value.Trim().Length != 8)
                {
                    aa = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    try
                    {
                        string text = value.Trim();
                        aa = DateTime.Parse(string.Concat(new[]
                            {
                                text.Substring(0, 4),
                                "-",
                                text.Substring(4, 2),
                                "-",
                                text.Substring(6, 2)
                            })).ToString("yyyyMMdd");
                    }
                    catch
                    {
                        aa = DateTime.Now.ToString("yyyyMMdd");
                    }
                }
            }
        }

        public string Attach
        {
            get { return b(ab); }
            set { ab = c(value); }
        }

        public string PayErrMsg
        {
            get { return ac; }
        }

        private static string c(string A_0)
        {
            string result;
            if (A_0 == null || A_0.Trim() == "")
            {
                result = "";
            }
            else
            {
                result =
                    A_0.Replace("%", "%25")
                       .Replace("=", "%3d")
                       .Replace("&", "%26")
                       .Replace("\"", "%22")
                       .Replace("?", "%3f")
                       .Replace("'", "%27")
                       .Replace(" ", "%20");
            }
            return result;
        }

        private static string b(string A_0)
        {
            string result;
            if (A_0 == null || A_0.Trim() == "")
            {
                result = "";
            }
            else
            {
                result =
                    A_0.Replace("%3d", "=")
                       .Replace("%26", "&")
                       .Replace("%22", "\"")
                       .Replace("%3f", "?")
                       .Replace("%27", "'")
                       .Replace("%20", " ")
                       .Replace("%25", "%");
            }
            return result;
        }

        private static string a(string A_0)
        {
            var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(A_0);
            byte[] value = mD5CryptoServiceProvider.ComputeHash(bytes);
            string text = BitConverter.ToString(value);
            return text.Replace("-", "").ToUpper();
        }

        protected StringBuilder AddParameter(StringBuilder buf, string parameterName, string parameterValue)
        {
            StringBuilder result;
            if (parameterValue == null || "".Equals(parameterValue))
            {
                result = buf;
            }
            else
            {
                if ("".Equals(buf.ToString()))
                {
                    buf.Append(parameterName);
                    buf.Append("=");
                    buf.Append(parameterValue);
                }
                else
                {
                    buf.Append("&");
                    buf.Append(parameterName);
                    buf.Append("=");
                    buf.Append(parameterValue);
                }
                result = buf;
            }
            return result;
        }

        public string GetPaySign()
        {
            var stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, "attach", ab);
            AddParameter(stringBuilder, "chnid", b1);
            AddParameter(stringBuilder, "cmdno", c1.ToString());
            AddParameter(stringBuilder, "encode_type", d1.ToString());
            AddParameter(stringBuilder, "mch_desc", e1);
            AddParameter(stringBuilder, "mch_name", f1);
            AddParameter(stringBuilder, "mch_price", g1.ToString());
            AddParameter(stringBuilder, "mch_returl", y1);
            AddParameter(stringBuilder, "mch_type", h1.ToString());
            AddParameter(stringBuilder, "mch_vno", q1);
            AddParameter(stringBuilder, "need_buyerinfo", i1.ToString());
            AddParameter(stringBuilder, "seller", k1);
            AddParameter(stringBuilder, "show_url", z1);
            AddParameter(stringBuilder, "transport_desc", string_0);
            AddParameter(stringBuilder, "transport_fee", p1.ToString());
            AddParameter(stringBuilder, "version", m1);
            AddParameter(stringBuilder, "key", v1);
            return a(stringBuilder.ToString());
        }

        public string GetPayResultSign()
        {
            var stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, "attach", ab);
            AddParameter(stringBuilder, "buyer_id", t1);
            AddParameter(stringBuilder, "cft_tid", u1);
            AddParameter(stringBuilder, "chnid", b1);
            AddParameter(stringBuilder, "cmdno", c1.ToString());
            AddParameter(stringBuilder, "mch_vno", q1);
            AddParameter(stringBuilder, "retcode", r1.ToString());
            AddParameter(stringBuilder, "seller", k1);
            AddParameter(stringBuilder, "status", s1);
            AddParameter(stringBuilder, "total_fee", n1.ToString());
            AddParameter(stringBuilder, "trade_price", int_0.ToString());
            AddParameter(stringBuilder, "transport_fee", p1.ToString());
            AddParameter(stringBuilder, "version", m1);
            AddParameter(stringBuilder, "key", v1);
            return a(stringBuilder.ToString());
        }

        public bool GetPayUrl(out string url)
        {
            bool result;
            try
            {
                string paySign = GetPaySign();
                url = string.Concat(new object[]
                    {
                        w1,
                        "?attach=",
                        ab,
                        "&chnid=",
                        b1,
                        "&cmdno=",
                        c1,
                        "&encode_type=",
                        d1,
                        "&mch_desc=",
                        e1,
                        "&mch_name=",
                        f1,
                        "&mch_price=",
                        g1,
                        "&mch_returl=",
                        y1,
                        "&mch_type=",
                        h1,
                        "&mch_vno=",
                        q1,
                        "&need_buyerinfo=",
                        i1,
                        "&seller=",
                        k1,
                        "&show_url=",
                        z1,
                        "&transport_desc=",
                        string_0,
                        "&transport_fee=",
                        p1,
                        "&version=",
                        m1,
                        "&sign=",
                        paySign
                    });
                result = true;
            }
            catch (Exception ex)
            {
                url = "创建URL时出错,错误信息:" + ex.Message;
                result = false;
            }
            return result;
        }

        public bool GetPayValueFromUrl(NameValueCollection querystring, out string errmsg)
        {
            bool result;
            if (querystring == null || querystring.Count == 0)
            {
                errmsg = "参数为空";
                result = false;
            }
            else
            {
                if (querystring["cmdno"] == null || querystring["cmdno"].Trim() != c1.ToString())
                {
                    errmsg = "没有cmdno参数或cmdno参数不正确";
                    result = false;
                }
                else
                {
                    if (querystring["seller"] == null)
                    {
                        errmsg = "没有seller参数";
                        result = false;
                    }
                    else
                    {
                        if (querystring["buyer_id"] == null)
                        {
                            errmsg = "没有buyer_id参数";
                            result = false;
                        }
                        else
                        {
                            if (querystring["cft_tid"] == null)
                            {
                                errmsg = "没有cft_tid参数";
                                result = false;
                            }
                            else
                            {
                                if (querystring["mch_vno"] == null)
                                {
                                    errmsg = "没有mch_vno参数";
                                    result = false;
                                }
                                else
                                {
                                    if (querystring["retcode"] == null)
                                    {
                                        errmsg = "没有retcode参数";
                                        result = false;
                                    }
                                    else
                                    {
                                        if (querystring["status"] == null)
                                        {
                                            errmsg = "没有status参数";
                                            result = false;
                                        }
                                        else
                                        {
                                            if (querystring["total_fee"] == null)
                                            {
                                                errmsg = "没有total_fee参数";
                                                result = false;
                                            }
                                            else
                                            {
                                                if (querystring["attach"] == null)
                                                {
                                                    errmsg = "没有attach参数";
                                                    result = false;
                                                }
                                                else
                                                {
                                                    if (querystring["trade_price"] == null)
                                                    {
                                                        errmsg = "没有trade_price参数";
                                                        result = false;
                                                    }
                                                    else
                                                    {
                                                        if (querystring["transport_fee"] == null)
                                                        {
                                                            errmsg = "没有transport_fee参数";
                                                            result = false;
                                                        }
                                                        else
                                                        {
                                                            if (querystring["chnid"] == null)
                                                            {
                                                                errmsg = "没有chnid参数";
                                                                result = false;
                                                            }
                                                            else
                                                            {
                                                                if (querystring["sign"] == null)
                                                                {
                                                                    errmsg = "没有sign参数";
                                                                    result = false;
                                                                }
                                                                else
                                                                {
                                                                    errmsg = "";
                                                                    try
                                                                    {
                                                                        ab = querystring["attach"];
                                                                        t1 = querystring["buyer_id"];
                                                                        u1 = querystring["cft_tid"];
                                                                        b1 = querystring["chnid"];
                                                                        c1 = int.Parse(querystring["cmdno"]);
                                                                        q1 = querystring["mch_vno"];
                                                                        r1 = int.Parse(querystring["retcode"]);
                                                                        k1 = querystring["seller"];
                                                                        s1 = querystring["status"];
                                                                        n1 = int.Parse(querystring["total_fee"]);
                                                                        int_0 = int.Parse(querystring["trade_price"]);
                                                                        p1 = int.Parse(querystring["transport_fee"]);
                                                                        m1 = querystring["version"];
                                                                        string text = querystring["sign"];
                                                                        string payResultSign = GetPayResultSign();
                                                                        if (payResultSign != text)
                                                                        {
                                                                            errmsg = "验证签名失败";
                                                                            result = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            result = true;
                                                                        }
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        errmsg = "解析参数出错:" + ex.Message;
                                                                        result = false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}