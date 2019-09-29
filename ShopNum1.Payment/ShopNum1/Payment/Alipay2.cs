﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShopNum1.Payment
{
    public class Alipay2
    {
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
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
                             string subject, string body, string payment_type, string total_fee, string show_url,
                             string seller_email, string key, string return_url, string _input_charset,
                             string notify_url, string logistics_type, string logistics_fee, string logistics_payment,
                             string logistics_type_1, string logistics_fee_1, string logistics_payment_1,
                             string quantity, out string url)
        {
            bool result = true;
            try
            {
                var r = new[]
                    {
                        "service=" + service,
                        "partner=" + partner,
                        "notify_url=" + notify_url,
                        "return_url=" + return_url,
                        "_input_charset=" + _input_charset,
                        "subject=" + subject,
                        "body=" + body,
                        "out_trade_no=" + out_trade_no,
                        "price=" + total_fee,
                        "show_url=" + show_url,
                        "quantity=" + quantity,
                        "payment_type=" + payment_type,
                        "seller_email=" + seller_email,
                        "logistics_type=" + logistics_type,
                        "logistics_fee=" + logistics_fee,
                        "logistics_payment=" + logistics_payment,
                        "logistics_type_1=" + logistics_type_1,
                        "logistics_fee_1=" + logistics_fee_1,
                        "logistics_payment_1=" + logistics_payment_1
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
                string mD = GetMD5(stringBuilder.ToString(), _input_charset);
                var separator = new[]
                    {
                        '='
                    };
                var stringBuilder2 = new StringBuilder();
                stringBuilder2.Append(gateway);
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder2.Append(array[i].Split(separator)[0] + "=" +
                                          HttpUtility.UrlEncode(array[i].Split(separator)[1]) + "&");
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