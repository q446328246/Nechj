using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.DiscuzCommon
{
    public class DES
    {
        private static readonly byte[] byte_0 = new byte[] {0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef};

        public static string Decode(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = Utils.GetSubString(decryptKey, 8, "");
                decryptKey = decryptKey.PadRight(8, ' ');
                byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = byte_0;
                byte[] buffer = Convert.FromBase64String(decryptString);
                var provider = new DESCryptoServiceProvider();
                var stream = new MemoryStream();
                var stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string Encode(string encryptString, string encryptKey)
        {
            encryptKey = Utils.GetSubString(encryptKey, 8, "");
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = byte_0;
            byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
            var provider = new DESCryptoServiceProvider();
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}