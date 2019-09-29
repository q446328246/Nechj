using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Com.Alipay
{
    public class Core
    {
        public static Dictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var current in dicArrayPre)
            {
                if (current.Key.ToLower() != "sign" && current.Key.ToLower() != "sign_type" && current.Value != "" &&
                    current.Value != null)
                {
                    dictionary.Add(current.Key, current.Value);
                }
            }
            return dictionary;
        }

        public static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dicArray)
            {
                stringBuilder.Append(current.Key + "=" + current.Value + "&");
            }
            int length = stringBuilder.Length;
            stringBuilder.Remove(length - 1, 1);
            return stringBuilder.ToString();
        }

        public static string CreateLinkStringUrlencode(Dictionary<string, string> dicArray, Encoding code)
        {
            var stringBuilder = new StringBuilder();
            foreach (var current in dicArray)
            {
                stringBuilder.Append(current.Key + "=" + HttpUtility.UrlEncode(current.Value, code) + "&");
            }
            int length = stringBuilder.Length;
            stringBuilder.Remove(length - 1, 1);
            return stringBuilder.ToString();
        }

        public static void LogResult(string sWord)
        {
            string text = HttpContext.Current.Server.MapPath("log");
            text = text + "\\" + DateTime.Now.ToString().Replace(":", "") + ".txt";
            var streamWriter = new StreamWriter(text, false, Encoding.Default);
            streamWriter.Write(sWord);
            streamWriter.Close();
        }

        public static string GetAbstractToMD5(Stream sFile)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(sFile);
            var stringBuilder = new StringBuilder(32);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        public static string GetAbstractToMD5(byte[] dataFile)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(dataFile);
            var stringBuilder = new StringBuilder(32);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }
    }
}