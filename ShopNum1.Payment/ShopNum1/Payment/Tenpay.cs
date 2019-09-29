using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShopNum1.Payment
{
    public class Tenpay
    {
        private const int a1 = 1;
        private const int b1 = 2;
        public const int PAYOK = 0;
        public const int PAYSPERROR = 1;
        public const int PAYMD5ERROR = 2;
        public const int PAYERROR = 3;
        private string c1 = "";
        private string d1 = "";
        private string e1 = "https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi";
        private string f1 = "http://portal.tenpay.com/cfbiportal/cgi-bin/cfbiqueryorder.cgi";
        private string g1 = "";
        private string h1 = "http://davidzhu-pc/tenpaymd5/queryresult.aspx";
        private int i1 = 1;
        private string j1;
        private string k1 = "";
        private long long_0;
        private string m1 = "";
        private string n1 = "";
        private string p1 = "";
        private string q1 = getRealIp();
        private int r1;
        private string s1 = "";
        private string string_0 = "";

        public string Bargainor_id
        {
            get { return c1; }
            set { c1 = value; }
        }

        public string Key
        {
            get { return d1; }
            set { d1 = value; }
        }

        public string Paygateurl
        {
            get { return e1; }
            set { e1 = value; }
        }

        public string Querygateurl
        {
            get { return f1; }
            set { f1 = value; }
        }

        public string Return_url
        {
            get { return g1; }
            set { g1 = value; }
        }

        public string Queryreturn_url
        {
            get { return h1; }
            set { h1 = value; }
        }

        public string Date
        {
            get
            {
                if (j1 == null)
                {
                    j1 = DateTime.Now.ToString("yyyyMMdd");
                }
                return j1;
            }
            set
            {
                if (value == null || value.Trim().Length != 8)
                {
                    j1 = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    try
                    {
                        string text = value.Trim();
                        j1 = DateTime.Parse(string.Concat(new[]
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
                        j1 = DateTime.Now.ToString("yyyyMMdd");
                    }
                }
            }
        }

        public string Sp_billno
        {
            get { return k1; }
            set { k1 = value; }
        }

        public long Total_fee
        {
            get { return long_0; }
            set { long_0 = value; }
        }

        public string Transaction_id
        {
            get { return m1; }
            set { m1 = value; }
        }

        public string Desc
        {
            get { return a(n1); }
            set { n1 = b(value); }
        }

        public string Attach
        {
            get { return a(string_0); }
            set { string_0 = b(value); }
        }

        public string Purchaser_id
        {
            get { return p1; }
            set { p1 = value; }
        }

        public string Spbill_create_ip
        {
            get { return q1; }
            set { q1 = value; }
        }

        public int Pay_Result
        {
            get { return r1; }
        }

        public string PayResultStr
        {
            get
            {
                string result;
                switch (r1)
                {
                    case 0:
                        result = "支付成功";
                        break;
                    case 1:
                        result = "商户号错";
                        break;
                    case 2:
                        result = "签名错误";
                        break;
                    case 3:
                        result = "支付失败";
                        break;
                    default:
                        result = "未知类型(" + r1 + ")";
                        break;
                }
                return result;
            }
        }

        public string PayErrMsg
        {
            get { return s1; }
        }

        public uint UnixStamp()
        {
            return
                Convert.ToUInt32(
                    (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        public static string getRealIp()
        {
            string result;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
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

        public static string UrlEncode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string text;
                try
                {
                    text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));
                }
                catch (Exception)
                {
                    text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("GB2312"));
                }
                result = text;
            }
            return result;
        }

        private static string a(string A_0)
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

        public static string UrlDecode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string text;
                try
                {
                    text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));
                }
                catch (Exception)
                {
                    text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("GB2312"));
                }
                result = text;
            }
            return result;
        }

        public static string GetMD5(string encypStr, string charset)
        {
            var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes;
            try
            {
                bytes = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception)
            {
                bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            byte[] value = mD5CryptoServiceProvider.ComputeHash(bytes);
            string text = BitConverter.ToString(value);
            return text.Replace("-", "").ToUpper();
        }

        private string d()
        {
            string text = string.Concat(new object[]
                {
                    "cmdno=",
                    1,
                    "&date=",
                    Date,
                    "&bargainor_id=",
                    c1,
                    "&transaction_id=",
                    Transaction_id,
                    "&sp_billno=",
                    k1,
                    "&total_fee=",
                    long_0,
                    "&fee_type=",
                    i1,
                    "&return_url=",
                    g1,
                    "&attach=",
                    Attach
                });
            if (q1 != "")
            {
                text = text + "&spbill_create_ip=" + q1;
            }
            text = text + "&key=" + d1;
            return GetMD5(text, getCharset());
        }

        private string c()
        {
            string encypStr = string.Concat(new object[]
                {
                    "cmdno=",
                    1,
                    "&pay_result=",
                    r1,
                    "&date=",
                    j1,
                    "&transaction_id=",
                    m1,
                    "&sp_billno=",
                    k1,
                    "&total_fee=",
                    long_0,
                    "&fee_type=",
                    i1,
                    "&attach=",
                    string_0,
                    "&key=",
                    d1
                });
            return GetMD5(encypStr, getCharset());
        }

        public bool GetPayUrl(out string url)
        {
            bool result;
            try
            {
                string str = d();
                url = string.Concat(new object[]
                    {
                        "?attach=",
                        Attach,
                        "&bank_type=0&bargainor_id=",
                        c1,
                        "&cmdno=",
                        1,
                        "&cs=gb2312&date=",
                        Date,
                        "&desc=",
                        TenpayUtil.UrlEncode(n1, getCharset()),
                        "&fee_type=",
                        i1,
                        "&return_url=",
                        TenpayUtil.UrlEncode(g1, getCharset())
                    });
                url = url + "&sign=" + str;
                url = url + "&sp_billno=" + k1;
                url = url + "&spbill_create_ip=" + getRealIp();
                url = url + "&total_fee=" + long_0;
                url = url + "&transaction_id=" + Transaction_id;
                url = e1 + url;
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
                if (querystring["cmdno"] == null || querystring["cmdno"].Trim() != 1.ToString())
                {
                    errmsg = "没有cmdno参数或cmdno参数不正确";
                    result = false;
                }
                else
                {
                    if (querystring["pay_result"] == null)
                    {
                        errmsg = "没有pay_result参数";
                        result = false;
                    }
                    else
                    {
                        if (querystring["date"] == null)
                        {
                            errmsg = "没有date参数";
                            result = false;
                        }
                        else
                        {
                            if (querystring["pay_info"] == null)
                            {
                                errmsg = "没有pay_info参数";
                                result = false;
                            }
                            else
                            {
                                if (querystring["bargainor_id"] == null)
                                {
                                    errmsg = "没有bargainor_id参数";
                                    result = false;
                                }
                                else
                                {
                                    if (querystring["transaction_id"] == null)
                                    {
                                        errmsg = "没有transaction_id参数";
                                        result = false;
                                    }
                                    else
                                    {
                                        if (querystring["sp_billno"] == null)
                                        {
                                            errmsg = "没有sp_billno参数";
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
                                                if (querystring["fee_type"] == null)
                                                {
                                                    errmsg = "没有fee_type参数";
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
                                                                r1 = int.Parse(querystring["pay_result"].Trim());
                                                                s1 = a(querystring["pay_info"].Trim());
                                                                Date = querystring["date"];
                                                                m1 = querystring["transaction_id"];
                                                                k1 = querystring["sp_billno"];
                                                                long_0 = long.Parse(querystring["total_fee"]);
                                                                i1 = int.Parse(querystring["fee_type"]);
                                                                string_0 = querystring["attach"];
                                                                if (querystring["bargainor_id"] != c1)
                                                                {
                                                                    r1 = 1;
                                                                    result = true;
                                                                }
                                                                else
                                                                {
                                                                    string text = querystring["sign"];
                                                                    string text2 = c();
                                                                    if (text2 != text)
                                                                    {
                                                                        r1 = 2;
                                                                    }
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
            return result;
        }

        public void InitQueryParam(string adate, string atransaction_id, string asp_billno, string aattach)
        {
            Date = adate;
            Sp_billno = asp_billno;
            Transaction_id = atransaction_id;
            Attach = aattach;
        }

        private string b()
        {
            string encypStr = string.Concat(new object[]
                {
                    "cmdno=",
                    2,
                    "&date=",
                    j1,
                    "&bargainor_id=",
                    c1,
                    "&transaction_id=",
                    m1,
                    "&sp_billno=",
                    k1,
                    "&return_url=",
                    h1,
                    "&attach=",
                    Attach,
                    "&key=",
                    d1
                });
            return GetMD5(encypStr, getCharset());
        }

        private string a()
        {
            string encypStr = string.Concat(new object[]
                {
                    "cmdno=",
                    2,
                    "&pay_result=",
                    r1,
                    "&date=",
                    j1,
                    "&transaction_id=",
                    m1,
                    "&sp_billno=",
                    k1,
                    "&total_fee=",
                    long_0,
                    "&fee_type=",
                    i1,
                    "&attach=",
                    string_0,
                    "&key=",
                    d1
                });
            return GetMD5(encypStr, getCharset());
        }

        public bool GetQueryUrl(out string url)
        {
            bool result;
            try
            {
                string text = b();
                url = string.Concat(new object[]
                    {
                        f1,
                        "?cmdno=",
                        2,
                        "&date=",
                        j1,
                        "&bargainor_id=",
                        c1,
                        "&transaction_id=",
                        m1,
                        "&sp_billno=",
                        k1,
                        "&return_url=",
                        h1,
                        "&attach=",
                        string_0,
                        "&sign=",
                        text
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

        public bool GetQueryValueFromUrl(NameValueCollection querystring, out string errmsg)
        {
            bool result;
            if (querystring == null || querystring.Count == 0)
            {
                errmsg = "参数为空";
                result = false;
            }
            else
            {
                if (querystring["cmdno"] == null || querystring["cmdno"].Trim() != 2.ToString())
                {
                    errmsg = "没有cmdno参数或cmdno参数不正确";
                    result = false;
                }
                else
                {
                    if (querystring["pay_result"] == null)
                    {
                        errmsg = "没有pay_result参数";
                        result = false;
                    }
                    else
                    {
                        if (querystring["date"] == null)
                        {
                            errmsg = "没有date参数";
                            result = false;
                        }
                        else
                        {
                            if (querystring["pay_info"] == null)
                            {
                                errmsg = "没有pay_info参数";
                                result = false;
                            }
                            else
                            {
                                if (querystring["bargainor_id"] == null)
                                {
                                    errmsg = "没有bargainor_id参数";
                                    result = false;
                                }
                                else
                                {
                                    if (querystring["transaction_id"] == null)
                                    {
                                        errmsg = "没有transaction_id参数";
                                        result = false;
                                    }
                                    else
                                    {
                                        if (querystring["sp_billno"] == null)
                                        {
                                            errmsg = "没有sp_billno参数";
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
                                                if (querystring["fee_type"] == null)
                                                {
                                                    errmsg = "没有fee_type参数";
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
                                                                r1 = int.Parse(querystring["pay_result"].Trim());
                                                                s1 = a(querystring["pay_info"].Trim());
                                                                Date = querystring["date"];
                                                                m1 = querystring["transaction_id"];
                                                                k1 = querystring["sp_billno"];
                                                                long_0 = long.Parse(querystring["total_fee"]);
                                                                i1 = int.Parse(querystring["fee_type"]);
                                                                string_0 = querystring["attach"];
                                                                if (querystring["bargainor_id"] != c1)
                                                                {
                                                                    r1 = 1;
                                                                    result = true;
                                                                }
                                                                else
                                                                {
                                                                    string text = querystring["sign"];
                                                                    string text2 = a();
                                                                    if (text2 != text)
                                                                    {
                                                                        r1 = 2;
                                                                    }
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
            return result;
        }

        protected virtual string getCharset()
        {
            return HttpContext.Current.Request.ContentEncoding.BodyName;
        }
    }
}