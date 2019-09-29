using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace ShopNum1.WebControl
{
    public class ShopNum1_KuaiDiRequest
    {
        private string string_0 = "http://www.kuaidi100.com/applyurl?key={0}&com={1}&nu={2}";

        private string string_1 =
            "http://api.kuaidi100.com/api?id={0}&com={1}&nu={2}&valicode=[]&show=3&muti=1&order=asc";

        private string string_2 = "";
        private string string_3 = "2";
        private string string_4 = "desc";
        private string string_5 = "1";

        public string apikey
        {
            get
            {
                if (string_2 == "")
                {
                    string_2 = ConfigurationManager.AppSettings["KuaiDiApiKey"];
                }
                return string_2;
            }
            set { string_2 = value; }
        }

        public string muti
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public string order
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string showtype
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode)
        {
            string requestUriString = string.Empty;
            if (kuaicom == "shunfeng")
            {
                requestUriString = string.Format(string_0, apikey, kuaicom, kuainum);
            }
            else
            {
                requestUriString = string.Format(string_1, apikey, kuaicom, kuainum);
            }
            Stream responseStream = WebRequest.Create(requestUriString).GetResponse().GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            var reader = new StreamReader(responseStream, encoding);
            return reader.ReadToEnd();
        }

        public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode, string kuaidishow, string kuaidimuti,
            string kuaidiorder)
        {
            if (kuaidishow == "")
            {
                kuaidishow = showtype;
            }
            if (kuaidimuti == "")
            {
                kuaidimuti = muti;
            }
            if (kuaidiorder == "")
            {
                kuaidiorder = order;
            }
            Stream responseStream =
                WebRequest.Create(string.Format(string_1,
                    new object[]
                    {apikey, kuaicom, kuainum, kuaidishow, kuaidimuti, kuaidiorder}))
                    .GetResponse()
                    .GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            var reader = new StreamReader(responseStream, encoding);
            return reader.ReadToEnd();
        }

        private string method_0(string string_6)
        {
            Stream responseStream = WebRequest.Create(string_6).GetResponse().GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            var reader = new StreamReader(responseStream, encoding);
            return reader.ReadToEnd();
        }
    }
}