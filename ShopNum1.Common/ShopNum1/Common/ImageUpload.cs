using System;
using System.IO;
using System.Web;

namespace ShopNum1.Common
{
    public class ImageUpload
    {
        public void CheckImgType(string fileName)
        {
            FileStream stream = new FileInfo(HttpContext.Current.Server.MapPath(fileName)).OpenRead();
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
        }

        public static bool CheckImgTypex(string[] ExtArry, string strExt)
        {
            bool flag = false;
            for (int i = 0; i < ExtArry.Length; i++)
            {
                if (ExtArry[i] == strExt)
                {
                    flag = true;
                }
            }
            return flag;
        }

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
    }
}