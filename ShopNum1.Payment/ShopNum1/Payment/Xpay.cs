using System;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class Xpay
    {
        public bool CreateUrl(string gatewayurl, string key, string tid, string bid, string pdt, string type,
                              decimal prc, string card, string lang, string url, string ver, string remark1,
                              string actioncode, string actionparameter, string username, out string url1)
        {
            bool result = true;
            try
            {
                string empty = string.Empty;
                string a_ = string.Concat(new object[]
                    {
                        key,
                        ":",
                        prc,
                        ",",
                        bid,
                        ",",
                        tid,
                        ",",
                        card,
                        ",",
                        empty,
                        ",",
                        actioncode,
                        ",",
                        actionparameter,
                        ",",
                        ver
                    });
                string str = a(a_);
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(gatewayurl);
                stringBuilder.Append("?tid=" + tid);
                stringBuilder.Append("&bid=" + bid);
                stringBuilder.Append("&pdt=" + pdt);
                stringBuilder.Append("&type=" + type);
                stringBuilder.Append("&prc=" + prc);
                stringBuilder.Append("&card=" + card);
                stringBuilder.Append("&scard=" + empty);
                stringBuilder.Append("&lang=" + lang);
                stringBuilder.Append("&url=" + url);
                stringBuilder.Append("&ver=" + ver);
                stringBuilder.Append("&remark1=" + remark1);
                stringBuilder.Append("&actioncode=" + actioncode);
                stringBuilder.Append("&actionparameter=" + actionparameter);
                stringBuilder.Append("&username=" + username);
                stringBuilder.Append("&md=" + str);
                string text = stringBuilder.ToString();
                url1 = text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private string a(string A_0)
        {
            var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            return
                BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(A_0)))
                            .Replace("-", "")
                            .ToLower();
        }
    }
}