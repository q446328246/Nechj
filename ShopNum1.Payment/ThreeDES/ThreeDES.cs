using System;
using System.Security.Cryptography;
using System.Text;

namespace ThreeDES
{
    public static class ThreeDES
    {
        private static byte[] a(string A_0)
        {
            A_0 = A_0.Trim();
            if (A_0.Length%2 != 0)
            {
                A_0 += " ";
            }
            var array = new byte[A_0.Length/2];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(A_0.Substring(i*2, 2), 16);
            }
            return array;
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string text = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i].ToString("X2");
                }
            }
            return text;
        }

        public static string byteTohex(byte[] src)
        {
            var bytes = new[]
                {
                    byte.Parse("20")
                };
            string @string = Encoding.GetEncoding("GBK").GetString(bytes);
            return Encoding.GetEncoding("GBK").GetString(src).Replace(@string, "");
        }

        public static byte[] getTrueByte(byte[] src)
        {
            int num = src.Length;
            int num2 = num%8;
            int num3 = 8 - num2;
            var array = new byte[num + num3];
            for (int i = 0; i < src.Length; i++)
            {
                array[i] = src[i];
            }
            for (int j = 0; j < num3; j++)
            {
                array[num + j] = byte.Parse("20");
            }
            return array;
        }

        public static string Encrypt3DES(string a_strString, string a_strKey)
        {
            ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
                {
                    Key = a(a_strKey),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.None
                }.CreateEncryptor();
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(a_strString);
            byte[] array = bytes;
            if (bytes.Length%8 != 0)
            {
                array = getTrueByte(bytes);
            }
            byte[] bytes2 = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            return byteToHexStr(bytes2);
        }

        public static string Decrypt3DES(string a_strString, string a_strKey)
        {
            ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
                {
                    Key = a(a_strKey),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.None
                }.CreateDecryptor();
            byte[] array = a(a_strString);
            byte[] src = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            return byteTohex(src);
        }
    }
}