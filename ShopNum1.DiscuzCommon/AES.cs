using System;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.DiscuzCommon
{
    public class AES
    {
        private static readonly byte[] byte_0 = new byte[]
            {0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f};

        public static string Decode(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = Utils.GetSubString(decryptKey, 0x20, "");
                decryptKey = decryptKey.PadRight(0x20, ' ');
                ICryptoTransform transform =
                    new RijndaelManaged {Key = Encoding.UTF8.GetBytes(decryptKey), IV = byte_0}.CreateDecryptor();
                byte[] inputBuffer = Convert.FromBase64String(decryptString);
                byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return "";
            }
        }

        public static string Encode(string encryptString, string encryptKey)
        {
            encryptKey = Utils.GetSubString(encryptKey, 0x20, "");
            encryptKey = encryptKey.PadRight(0x20, ' ');
            ICryptoTransform transform =
                new RijndaelManaged {Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 0x20)), IV = byte_0}
                    .CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }
    }
}