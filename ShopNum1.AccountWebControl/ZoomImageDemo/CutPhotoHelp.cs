using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ZoomImageDemo
{
    public class CutPhotoHelp
    {
        public static Bitmap MakeThumbnail(Image fromImg, int width, int height)
        {
            var image = new Bitmap(width, height);
            int num = fromImg.Width;
            int num2 = fromImg.Height;
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(fromImg, new Rectangle(0, 0, width, height), new Rectangle(0, 0, num, num2),
                GraphicsUnit.Pixel);
            return image;
        }

        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY,
            int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            string str = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = pSavedPath + @"\" + str;
            using (Image image = Image.FromFile(pPath))
            {
                var bitmap = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(bitmap);
                var destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY),
                    new Size(pPartWidth, pPartHeight));
                var srcRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY),
                    new Size(pPartWidth, pPartHeight));
                Graphics graphics2 = Graphics.FromImage(bitmap);
                graphics2.Clear(Color.White);
                graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                graphics2.Dispose();
                image.Dispose();
                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                bitmap.Save(path, ImageFormat.Jpeg);
                bitmap.Dispose();
            }
            return str;
        }

        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY,
            int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY,
            int imageWidth, int imageHeight)
        {
            using (Image image = Image.FromFile(pPath))
            {
                if ((image.Width == imageWidth) && (image.Height == imageHeight))
                {
                    return SaveCutPic(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight,
                        pOrigStartPointX, pOrigStartPointY);
                }
                string str = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                string path = pSavedPath + @"\" + str;
                Bitmap bitmap = MakeThumbnail(image, imageWidth, imageHeight);
                var bitmap2 = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(bitmap2);
                var destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY),
                    new Size(pPartWidth, pPartHeight));
                var srcRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY),
                    new Size(pPartWidth, pPartHeight));
                Graphics graphics2 = Graphics.FromImage(bitmap2);
                graphics2.Clear(Color.White);
                graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                graphics2.Dispose();
                image.Dispose();
                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                bitmap2.Save(path, ImageFormat.Jpeg);
                bitmap2.Dispose();
                bitmap.Dispose();
                return str;
            }
        }
    }
}