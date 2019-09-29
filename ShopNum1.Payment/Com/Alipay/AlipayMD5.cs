using System.Security.Cryptography;
using System.Text;

namespace Com.Alipay
{
    public sealed class AlipayMD5
    {
        public static string Sign(string prestr, string key, string _input_charset)
        {
            var stringBuilder = new StringBuilder(32);
            prestr += key;
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        public static bool Verify(string prestr, string sign, string key, string _input_charset)
        {
            string a = Sign(prestr, key, _input_charset);
            return a == sign;
        }
    }
}