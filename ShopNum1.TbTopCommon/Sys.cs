using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.TbTopCommon
{
    public class Sys
    {
        public static string GetFileSuffix(byte[] fileData)
        {
            if ((fileData != null) && (fileData.Length >= 10))
            {
                if (((fileData[0] == 0x47) && (fileData[1] == 0x49)) && (fileData[2] == 70))
                {
                    return "GIF";
                }
                if (((fileData[1] == 80) && (fileData[2] == 0x4e)) && (fileData[3] == 0x47))
                {
                    return "PNG";
                }
                if ((((fileData[6] == 0x4a) && (fileData[7] == 70)) && (fileData[8] == 0x49)) && (fileData[9] == 70))
                {
                    return "JPG";
                }
                if ((fileData[0] == 0x42) && (fileData[1] == 0x4d))
                {
                    return "BMP";
                }
            }
            return null;
        }

        public static string GetMimeType(byte[] fileData)
        {
            switch (GetFileSuffix(fileData))
            {
                case "JPG":
                    return "image/jpeg";

                case "GIF":
                    return "image/gif";

                case "PNG":
                    return "image/png";

                case "BMP":
                    return "image/bmp";
            }
            return "application/octet-stream";
        }

        public static string GetMimeType(string fileName)
        {
            fileName = fileName.ToLower();
            if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
            {
                return "image/bmp";
            }
            if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
            {
                return "image/gif";
            }
            if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) ||
                fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
            {
                return "image/jpeg";
            }
            if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
            {
                return "image/png";
            }
            return "application/octet-stream";
        }

        public static bool VerifyTopResponse(string callbackUrl, string appSecret)
        {
            var uri = new Uri(callbackUrl);
            string query = uri.Query;
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }
            query = query.Trim(new[] {'?', ' '});
            if (query.Length == 0)
            {
                return false;
            }
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] strArray3 = query.Split(new[] {'&'});
            if ((strArray3 != null) && (strArray3.Length > 0))
            {
                foreach (string str3 in strArray3)
                {
                    string[] strArray2 = str3.Split(new[] {'='});
                    if (strArray2.Length >= 2)
                    {
                        dictionary.Add(strArray2[0], strArray2[1]);
                    }
                }
            }
            var builder = new StringBuilder();
            if (dictionary.ContainsKey("top_appkey"))
            {
                builder.Append(dictionary["top_appkey"]);
            }
            if (dictionary.ContainsKey("top_parameters"))
            {
                builder.Append(dictionary["top_parameters"]);
            }
            if (dictionary.ContainsKey("top_session"))
            {
                builder.Append(dictionary["top_session"]);
            }
            builder.Append(appSecret);
            string stringToEscape =
                Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(builder.ToString())));
            return (dictionary.ContainsKey("top_sign") &&
                    (Uri.EscapeDataString(stringToEscape) == dictionary["top_sign"]));
        }

        public static bool VerifyTopResponse(string topParams, string topSession, string topSign, string appKey,
            string appSecret)
        {
            var builder = new StringBuilder();
            if ((appKey.ToLower() == "test") || (appKey == "系统分配"))
            {
                appKey = "";
                appSecret = "";
            }
            new MD5CryptoServiceProvider();
            builder.Append(appKey).Append(topParams).Append(topSession).Append(appSecret);
            return (Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()))) ==
                    topSign);
        }
    }
}