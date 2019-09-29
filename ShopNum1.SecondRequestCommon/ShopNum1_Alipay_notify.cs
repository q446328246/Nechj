namespace ShopNum1.Second
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    public class ShopNum1_Alipay_notify
    {
        private string a1 = "";
        private string b1 = "";
        private string c1 = "";
        private string d1 = "";
        private string e1 = "";
        private string f1 = "";
        private string g1 = "";
        private string h1 = "";
        private Dictionary<string, string> i1 = new Dictionary<string, string>();
        private string j1 = "";
        private ShopNum1_Alipay_function k1 = new ShopNum1_Alipay_function();

        public ShopNum1_Alipay_notify(SortedDictionary<string, string> inputPara, string notify_id, string partner, string key, string input_charset, string sign_type, string transport)
        {
            this.b1 = transport;
            if (this.b1 == "https")
            {
                this.a1 = "https://www.alipay.com/cooperate/gateway.do?";
            }
            else
            {
                this.a1 = "http://notify.alipay.com/trade/notify_query.do?";
            }
            this.c1 = partner.Trim();
            this.d1 = key.Trim();
            this.e1 = input_charset;
            this.f1 = sign_type.ToUpper();
            this.i1 = this.k1.Para_filter(inputPara);
            this.j1 = this.k1.Create_linkstring(this.i1);
            this.g1 = this.k1.Build_mysign(this.i1, this.d1, this.f1, this.e1);
            this.h1 = this.a(notify_id);
        }

        private string a(string A_0)
        {
            string str = "";
            if (this.b1 == "https")
            {
                str = this.a1 + "service=notify_verify&partner=" + this.c1 + "&notify_id=" + A_0;
            }
            else
            {
                str = this.a1 + "partner=" + this.c1 + "&notify_id=" + A_0;
            }
            return this.a(str, 0x1d4c0);
        }

        private string a(string A_0, int A_1)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(A_0);
                request.Timeout = A_1;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                StringBuilder builder = new StringBuilder();
                while (-1 != reader.Peek())
                {
                    builder.Append(reader.ReadLine());
                }
                return builder.ToString();
            }
            catch (Exception exception)
            {
                return ("错误：" + exception.Message);
            }
        }

        public string Mysign
        {
            get
            {
                return this.g1;
            }
        }

        public string PreSignStr
        {
            get
            {
                return this.j1;
            }
        }

        public string ResponseTxt
        {
            get
            {
                return this.h1;
            }
        }
    }
}

