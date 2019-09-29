using System;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class Alipay2GB
    {
        public static string GetMD5(string s)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(s));
            var stringBuilder = new StringBuilder(32);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        public static string[] BubbleSort(string[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                bool flag = false;
                for (int j = r.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        string text = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = text;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            return r;
        }

        public bool CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no,
                             string subject, string body, string quantity, string price, string show_url,
                             string seller_email, string key, string return_url, string notify_url,
                             string logistics_type, string logistics_fee, string logistics_payment,
                             string logistics_type_1, string logistics_fee_1, string logistics_payment_1,
                             string payment_type, out string url)
        {
            bool result = true;
            try
            {
                var r = new[]
                    {
                        "service=" + service,
                        "partner=" + partner,
                        "subject=" + subject,
                        "body=" + body,
                        "out_trade_no=" + out_trade_no,
                        "price=" + price,
                        "show_url=" + show_url,
                        "quantity=" + quantity,
                        "seller_email=" + seller_email,
                        "notify_url=" + notify_url,
                        "return_url=" + return_url,
                        "logistics_type=" + logistics_type,
                        "logistics_fee=" + logistics_fee,
                        "logistics_payment=" + logistics_payment,
                        "logistics_type_1=" + logistics_type_1,
                        "logistics_fee_1=" + logistics_fee_1,
                        "logistics_payment_1=" + logistics_payment_1,
                        "payment_type=" + payment_type
                    };
                string[] array = BubbleSort(r);
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                    {
                        stringBuilder.Append(array[i]);
                    }
                    else
                    {
                        stringBuilder.Append(array[i] + "&");
                    }
                }
                stringBuilder.Append(key);
                string mD = GetMD5(stringBuilder.ToString());
                var stringBuilder2 = new StringBuilder();
                stringBuilder2.Append(gateway);
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder2.Append(array[i] + "&");
                }
                stringBuilder2.Append("sign=" + mD + "&sign_type=" + sign_type);
                url = stringBuilder2.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}