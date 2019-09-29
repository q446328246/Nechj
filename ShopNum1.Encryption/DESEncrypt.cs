using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace ShopNum1.Encryption
{
    public class DESEncrypt
    {
        public byte[] DESKey =
        {
            0x68, 0xad, 0x89, 0x5f, 0x7c, 120, 0x9d, 230, 0x4b, 0xbb, 0x58, 0x69, 0x7f, 0x3d, 0xed, 0x1f,
            0x97, 0x68, 0xe2, 0x5f, 0xd4, 0xbc, 0xb8, 0x3d, 80, 0xb9, 0x3a, 0x91, 0x9e, 0xba, 0xfb, 0xdd
        };


        public static string M_Decrypt(string text)
        {
            return M_Decrypt(text, "TangJangGuoji");
        }

        public static string M_Encrypt(string text)
        {
            return M_Encrypt(text, "TangJangGuoji");
        }
        public static string M_Decrypttwo(string text)
        {
            return M_Decrypt(text, "XianShiYou");
        }

        public static string M_Encrypttwo(string text)
        {
            return M_Encrypt(text, "XianShiYou");
        }

        public static string M_Encrypt(string Text, string sKey)
        {
            var provider = new DESCryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(Text); ;

            provider.Key =
                Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            provider.IV =
                Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();

            return Convert.ToBase64String(stream.ToArray());
        }


        public static string M_Decrypt(string Text, string sKey)
        {
            var provider = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(Text);

            provider.Key =
                Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            provider.IV =
                Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();

            return Encoding.Default.GetString(stream.ToArray());

        }

        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "TangJangGuoji");
        }

        public static string Decrypt(string Text, string sKey)
        {
            var provider = new DESCryptoServiceProvider();
            int num = Text.Length/2;
            var buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num3 = Convert.ToInt32(Text.Substring(i*2, 2), 0x10);
                buffer[i] = (byte) num3;
            }
            provider.Key =
                Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5")
                    .Substring(0, 8));
            provider.IV =
                Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5")
                    .Substring(0, 8));
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.Default.GetString(stream.ToArray());
        }

        public string Decrypt3DES(string Value)
        {
            string s = "wi11iam450";
            string str2 = "5484450";
            SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider
            {
                Key = Convert.FromBase64String(s),
                IV = Convert.FromBase64String(str2),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            byte[] buffer = Convert.FromBase64String(Value);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public string Decrypt3DES(string string_0, string sKey, string sIV)
        {
            SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider
            {
                Key = Convert.FromBase64String(sKey),
                IV = Convert.FromBase64String(sIV),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            byte[] buffer = Convert.FromBase64String(string_0);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "TangJangGuoji");
        }

        public static string Encrypt(string Text, string sKey)
        {
            var provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(Text);
            provider.Key =
                Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5")
                    .Substring(0, 8));
            provider.IV =
                Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5")
                    .Substring(0, 8));
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            var builder = new StringBuilder();
            foreach (byte num2 in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num2);
            }
            return builder.ToString();
        }

        public string Encrypt3DES(string string_0)
        {
            string s = "wi11iam450";
            string str2 = "5484450";
            SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider
            {
                Key = Convert.FromBase64String(s),
                IV = Convert.FromBase64String(str2),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            byte[] bytes = Encoding.UTF8.GetBytes(string_0);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream.ToArray());
        }

        public string Encrypt3DES(string string_0, string sKey, string sIV)
        {
            SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider
            {
                Key = Convert.FromBase64String(sKey),
                IV = Convert.FromBase64String(sIV),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform transform = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            byte[] bytes = Encoding.UTF8.GetBytes(string_0);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}