using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace ShopNum1.Common
{
    public class ShopNum1UpLoad
    {
        public enum PhotoMode
        {
            HW,
            W,
            H,
            Cut
        }

        public static void AddLeftShuiYinPic(string Path, string Path_syp, string Path_sypf)
        {
            Image image = Image.FromFile(Path);
            Image image2 = Image.FromFile(Path_sypf);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image2, new Rectangle(0, 0, image2.Width, image2.Height), 0, 0, image2.Width,
                               image2.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            image.Save(Path_syp);
            image.Dispose();
        }

        public static void AddShuiYinPic(string Path, string Path_syp, string Path_sypf)
        {
            Image image = Image.FromFile(Path);
            Image image2 = Image.FromFile(Path_sypf);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image2, new Rectangle(image.Width - image2.Width, 0, image2.Width, image2.Height), 0, 0,
                               image2.Width, image2.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            image.Save(Path_syp);
            image.Dispose();
        }

        public static void AddShuiYinWord(string Path, string Path_sy, string addText)
        {
            Image image = Image.FromFile(Path);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            var font = new Font("Verdana", 16f);
            Brush brush = new SolidBrush(Color.Blue);
            graphics.DrawString(addText, font, brush, 15f, 15f);
            graphics.Dispose();
            image.Save(Path_sy);
            image.Dispose();
        }

        public static bool FileType(FileUpload fu)
        {
            if (fu.HasFile)
            {
                string fileName = fu.PostedFile.FileName;
                if (fileName.LastIndexOf(".") != -1)
                {
                    string contentType = fu.PostedFile.ContentType;
                    string str3 = fileName.ToLower().Substring(fileName.LastIndexOf("."));
                    return
                        !((((((contentType == "image/gif") || (contentType == "image/x-png")) ||
                             ((contentType == "image/png") || (contentType == "image/pjpeg"))) ||
                            (((contentType == "image/jpeg") || (contentType == "image/jpg")) ||
                             ((contentType == "text/plain") || (contentType == "application/vnd.ms-excel")))) ||
                           ((((contentType == "application/octet-stream") ||
                              (contentType == "application/x-shockwave-flash")) ||
                             ((contentType == "application/x-zip-compressed") || (contentType == "application/msword"))) ||
                            (contentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")))
                              ? ((((((str3 != ".gif") && (str3 != ".jpg")) && ((str3 != ".jpeg") && (str3 != ".png"))) &&
                                   (((str3 != ".xlsx") && (str3 != ".xls")) && ((str3 != ".exl") && (str3 != ".doc")))) &&
                                  (((str3 != ".docx") && (str3 != ".txt")) && ((str3 != ".zip") && (str3 != ".rar")))) &&
                                 !(str3 == ".swf"))
                              : true);
                }
                return false;
            }
            return false;
        }

        public static bool FileType(FileUpload fu, out string retstr)
        {
            string contentType = fu.PostedFile.ContentType;
            string fileName = fu.PostedFile.FileName;
            int contentLength = fu.PostedFile.ContentLength;
            if (fu.HasFile)
            {
                if (fileName.LastIndexOf(".") != -1)
                {
                    string str3 = fileName.ToLower().Substring(fileName.LastIndexOf("."));
                    if (contentLength < 0xfa000)
                    {
                        if (
                            !((((((contentType == "image/gif") || (contentType == "application/x-rar-compressed")) ||
                                 ((contentType == "image/x-png") || (contentType == "image/png"))) ||
                                (((contentType == "image/pjpeg") || (contentType == "image/jpeg")) ||
                                 ((contentType == "image/jpg") || (contentType == "text/plain")))) ||
                               ((((contentType == "application/vnd.ms-excel") ||
                                  (contentType == "application/octet-stream")) ||
                                 ((contentType == "application/x-shockwave-flash") ||
                                  (contentType == "application/x-zip-compressed"))) ||
                                ((contentType == "application/msword") ||
                                 (contentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))))
                                  ? ((((((str3 != ".gif") && (str3 != ".jpg")) &&
                                        ((str3 != ".jpeg") && (str3 != ".png"))) &&
                                       (((str3 != ".xlsx") && (str3 != ".xls")) &&
                                        ((str3 != ".exl") && (str3 != ".doc")))) &&
                                      (((str3 != ".docx") && (str3 != ".txt")) && ((str3 != ".zip") && (str3 != ".rar")))) &&
                                     !(str3 == ".swf"))
                                  : true))
                        {
                            retstr = "文件符合条件！";
                            return true;
                        }
                        retstr = "文件格式不正确！";
                        return false;
                    }
                    retstr = "文件不能大于1M！";
                    return false;
                }
                retstr = "文件格式不正确！";
                return false;
            }
            retstr = "文件不存在！";
            return false;
        }

        public static bool FileUpLoad(FileUpload fu, string filepath, out string retstr)
        {
            var random = new Random();
            string fileName = fu.PostedFile.FileName;
            string path = HttpContext.Current.Server.MapPath(filepath);
            if (FileType(fu, out retstr))
            {
                if (fileName.IndexOf(".") != -1)
                {
                    string str3 = fileName.Substring(fileName.LastIndexOf("."));
                    string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100, 0x3e7).ToString() + str3;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    fu.PostedFile.SaveAs(path + str5);
                    retstr = filepath + str5;
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool ImageType(FileUpload fu)
        {
            string contentType = fu.PostedFile.ContentType;
            string fileName = fu.PostedFile.FileName;
            int contentLength = fu.PostedFile.ContentLength;
            if (fu.HasFile)
            {
                if (fileName.LastIndexOf(".") != -1)
                {
                    string str3 = fileName.ToLower().Substring(fileName.LastIndexOf("."));
                    if (contentLength < 0xf4240)
                    {
                        return
                            !(((((contentType == "image/gif") || (contentType == "image/x-png")) ||
                                ((contentType == "image/png") || (contentType == "image/pjpeg"))) ||
                               ((contentType == "image/jpeg") || (contentType == "image/jpg")))
                                  ? ((((str3 != ".gif") && (str3 != ".jpg")) && (str3 != ".jpeg")) && !(str3 == ".png"))
                                  : true);
                    }
                }
                return false;
            }
            return false;
        }

        public static bool ImageType(FileUpload fu, out string retstr)
        {
            string contentType = fu.PostedFile.ContentType;
            string fileName = fu.PostedFile.FileName;
            int contentLength = fu.PostedFile.ContentLength;
            if (fu.HasFile)
            {
                if (fileName.LastIndexOf(".") != -1)
                {
                    string str3 = fileName.ToLower().Substring(fileName.LastIndexOf("."));
                    if (contentLength < 0xf4240)
                    {
                        if (
                            !(((((contentType == "image/gif") || (contentType == "image/bmp")) ||
                                ((contentType == "image/x-png") || (contentType == "image/png"))) ||
                               (((contentType == "image/pjpeg") || (contentType == "image/jpeg")) ||
                                (contentType == "image/jpg")))
                                  ? ((((str3 != ".gif") && (str3 != ".jpg")) && (str3 != ".jpeg")) && !(str3 == ".png"))
                                  : true))
                        {
                            retstr = "文件符合条件！";
                            return true;
                        }
                        retstr = "文件格式不正确！";
                        return false;
                    }
                    retstr = "文件不能大于1M！";
                    return false;
                }
                retstr = "文件格式不正确！";
                return false;
            }
            retstr = "文件不存在！";
            return false;
        }

        public static bool ImageUpLoad(FileUpload fu, string filepath, out string retstr, bool shuiyin)
        {
            var random = new Random();
            string fileName = fu.PostedFile.FileName;
            string str2 = HttpContext.Current.Server.MapPath(filepath);
            if (!ImageType(fu, out retstr))
            {
                return false;
            }
            string str3 = fileName.Substring(fileName.LastIndexOf("."));
            string str4 = DateTime.Now.ToString("yyyyMMddHHmmss");
            lock (str4)
            {
                Thread.Sleep(20);
            }
            string str6 = str4 + random.Next(100, 0x3e7).ToString() + str3;
            fu.PostedFile.SaveAs(str2 + str6);
            if (shuiyin)
            {
                string originalImagePath = str2 + str6;
                string thumbnailPath = str2 + "s_" + str6;
                string str9 = HttpContext.Current.Server.MapPath("~/upload/shuiyin.png");
                string str10 = str2 + "sy_" + str6;
                try
                {
                    MakeThumbnail(originalImagePath, thumbnailPath, 450, 300, PhotoMode.HW);
                    AddShuiYinPic(thumbnailPath, str10, str9);
                    if (File.Exists(originalImagePath))
                    {
                        File.Delete(originalImagePath);
                    }
                    if (File.Exists(thumbnailPath))
                    {
                        File.Delete(thumbnailPath);
                    }
                    retstr = filepath + "sy_" + str6;
                    goto Label_0184;
                }
                catch (Exception exception)
                {
                    if (File.Exists(originalImagePath))
                    {
                        File.Delete(originalImagePath);
                    }
                    if (File.Exists(thumbnailPath))
                    {
                        File.Delete(thumbnailPath);
                    }
                    retstr = exception.ToString();
                    return false;
                }
            }
            retstr = filepath + str6;
            Label_0184:
            return true;
        }

        public static bool ImageUpLoad(FileUpload fu, string filepath, out string retstr, bool shuiyin, int sytype,
                                       string syimg)
        {
            var random = new Random();
            string fileName = fu.PostedFile.FileName;
            string str2 = HttpContext.Current.Server.MapPath(filepath);
            if (!ImageType(fu, out retstr))
            {
                return false;
            }
            string str3 = fileName.Substring(fileName.LastIndexOf("."));
            string str4 = DateTime.Now.ToString("yyyyMMddHHmmss");
            lock (str4)
            {
                Thread.Sleep(20);
            }
            string str6 = str4 + random.Next(100, 0x3e7).ToString() + str3;
            fu.PostedFile.SaveAs(str2 + str6);
            if (shuiyin)
            {
                string originalImagePath = str2 + str6;
                string thumbnailPath = str2 + "s_" + str6;
                string str9 = HttpContext.Current.Server.MapPath("~/upload/shuiyin.png");
                string str10 = str2 + "sy_" + str6;
                try
                {
                    MakeThumbnail(originalImagePath, thumbnailPath, 450, 300, PhotoMode.HW);
                    AddShuiYinPic(thumbnailPath, str10, str9);
                    if (File.Exists(originalImagePath))
                    {
                        File.Delete(originalImagePath);
                    }
                    if (File.Exists(thumbnailPath))
                    {
                        File.Delete(thumbnailPath);
                    }
                    retstr = filepath + "sy_" + str6;
                    goto Label_0184;
                }
                catch (Exception exception)
                {
                    if (File.Exists(originalImagePath))
                    {
                        File.Delete(originalImagePath);
                    }
                    if (File.Exists(thumbnailPath))
                    {
                        File.Delete(thumbnailPath);
                    }
                    retstr = exception.ToString();
                    return false;
                }
            }
            retstr = filepath + str6;
            Label_0184:
            return true;
        }

        public static bool ImageUpLoad(FileUpload fu, string filepath, bool sPic, int sPicwidth, int sPicheight,
                                       out string retstr)
        {
            var random = new Random();
            string fileName = fu.PostedFile.FileName;
            string str2 = HttpContext.Current.Server.MapPath(filepath);
            if (ImageType(fu, out retstr))
            {
                if (fileName.LastIndexOf(".") != -1)
                {
                    string str3 = fileName.Substring(fileName.LastIndexOf("."));
                    string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100, 0x3e7).ToString() + str3;
                    string originalImagePath = str2 + str5;
                    string thumbnailPath = str2 + "s_" + str5;
                    try
                    {
                        fu.PostedFile.SaveAs(str2 + str5);
                        if (sPic)
                        {
                            MakeThumbnail(originalImagePath, thumbnailPath, sPicwidth, sPicheight, PhotoMode.HW);
                        }
                        retstr = filepath + str5;
                        return true;
                    }
                    catch (Exception exception)
                    {
                        retstr = exception.ToString();
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        public static bool ImageUpLoadWithName(FileUpload fu, string filepath, out string retstr)
        {
            if (ImageType(fu, out retstr))
            {
                string path = HttpContext.Current.Server.MapPath(filepath);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                fu.PostedFile.SaveAs(path);
                return true;
            }
            return false;
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height,
                                         PhotoMode mode)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            switch (mode)
            {
                case PhotoMode.W:
                    num2 = (image.Height*width)/image.Width;
                    break;

                case PhotoMode.H:
                    num = (image.Width*height)/image.Height;
                    break;

                case PhotoMode.Cut:
                    if (((image.Width)/((double) image.Height)) <= ((num)/((double) num2)))
                    {
                        num5 = image.Width;
                        num6 = (image.Width*height)/num;
                        x = 0;
                        y = (image.Height - num6)/2;
                        break;
                    }
                    num6 = image.Height;
                    num5 = (image.Height*num)/num2;
                    y = 0;
                    x = (image.Width - num5)/2;
                    break;
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6),
                               GraphicsUnit.Pixel);
            try
            {
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
    }
}