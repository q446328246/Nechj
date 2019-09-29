using System;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class MD5Util
    {
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
    }
}