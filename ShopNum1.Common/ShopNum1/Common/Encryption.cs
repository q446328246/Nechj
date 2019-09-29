using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace ShopNum1.Common
{
    public static class Encryption
    {
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "TangJangGuoji");
        }

        public static string Decrypt(string Text, string sKey)
        {
            try
            {
                if (!string.IsNullOrEmpty(Text))
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
                        Encoding.ASCII.GetBytes(
                            FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                    provider.IV =
                        Encoding.ASCII.GetBytes(
                            FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                    var stream = new MemoryStream();
                    var stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    return Encoding.Default.GetString(stream.ToArray());
                }
                return "";
            }
            catch
            {
                return Text;
            }
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

        public static string GetMd5Hash(string input)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            var builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string GetMd5SecondHash(string input)
        {
            input = "shotjum1" + input + "@1$%^^)+_)(*&^%$#@!";
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            var builder = new StringBuilder();
            byte num = buffer[0];
            buffer[0] = buffer[buffer.Length - 1];
            buffer[buffer.Length - 1] = num;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (i == 3)
                {
                    builder.Append(buffer[i].ToString("x2").Replace('a', 'd'));
                }
                else
                {
                    builder.Append(buffer[i].ToString("x2"));
                }
            }
            return builder.ToString().ToUpper().Substring(0, 30);
        }

        public static string GetSHA1Hash(string input)
        {
            byte[] buffer = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            var builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string GetSHA1SecondHash(string input)
        {
            input = "~!@#$%&*()_01qda31+" + input + "shotjum1";
            byte[] buffer = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            var builder = new StringBuilder();
            buffer[0] = buffer[buffer.Length - 1];
            buffer[buffer.Length - 1] = buffer[0];
            for (int i = 0; i < buffer.Length; i++)
            {
                if (i == 4)
                {
                    builder.Append(buffer[i].ToString("x2").Replace('a', 'd'));
                }
                else
                {
                    builder.Append(buffer[i].ToString("x2"));
                }
            }
            return builder.ToString().ToUpper();
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            string x = GetMd5Hash(input);
            StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
            return (0 == ordinalIgnoreCase.Compare(x, hash));
        }
    }
}