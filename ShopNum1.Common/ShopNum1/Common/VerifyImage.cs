using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace ShopNum1.Common
{
    public class VerifyImage : IVerifyImage
    {
        private static readonly Font[] fonts = new[]
            {
                new Font(new FontFamily("Times New Roman"), (0x10 + Next(4)), FontStyle.Bold),
                new Font(new FontFamily("Georgia"), (0x10 + Next(4)), FontStyle.Bold),
                new Font(new FontFamily("Arial"), (0x10 + Next(4)), FontStyle.Bold),
                new Font(new FontFamily("Comic Sans MS"), (0x10 + Next(4)), FontStyle.Bold),
                new Font(new FontFamily("Tahoma"), (0x10 + Next(4)), FontStyle.Bold)
            };

        private static readonly RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
        private static readonly byte[] randb = new byte[4];

        public VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor)
        {
            int num2;
            var info = new VerifyImageInfo
                {
                    ImageFormat = ImageFormat.Jpeg,
                    ContentType = "image/pjpeg"
                };
            var image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            var rectangle = new Rectangle(0, 0, width, height);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(bgcolor);
            int num = (textcolor == 2) ? 60 : 0;
            var brush = new SolidBrush(Color.FromArgb(Next(100), Next(100), Next(100)));
            for (num2 = 0; num2 < 3; num2++)
            {
                var pen = new Pen(Color.FromArgb(Next(150) + num, Next(150) + num, Next(150) + num), 1f);
                graphics.DrawLine(pen, new PointF(0f + Next(20), 0f + Next(height)),
                                  new PointF(0f + Next(width), 0f + Next(height)));
            }
            var matrix = new Matrix();
            num2 = 0;
            while (num2 < code.Length)
            {
                char ch;
                matrix.Reset();
                matrix.RotateAt((Next(30) - 15),
                                new PointF(Convert.ToInt64((width*(0.1*num2))), Convert.ToInt64((height*0.5))));
                graphics.Transform = matrix;
                brush.Color = Color.FromArgb((Next(150) + num) + 20, (Next(150) + num) + 20, (Next(150) + num) + 20);
                var point = new PointF((0f + Next(4)) + (num2*20), 3f + Next(3));
                graphics.DrawString(
                    (Next(1) == 1) ? (ch = code[num2]).ToString() : (ch = code[num2]).ToString().ToUpper(),
                    fonts[Next(fonts.Length - 1)], brush, point);
                graphics.ResetTransform();
                num2++;
            }
            double num3 = Next(5, 10)*((Next(10) == 1) ? 1 : -1);
            using (var bitmap2 = (Bitmap) image.Clone())
            {
                for (int i = 0; i < height; i++)
                {
                    for (num2 = 0; num2 < width; num2++)
                    {
                        int x = num2 + ((int) (num3*Math.Sin((3.1415926535897931*i)/84.5)));
                        int y = i + ((int) (num3*Math.Cos((3.1415926535897931*num2)/54.5)));
                        if ((x < 0) || (x >= width))
                        {
                            x = 0;
                        }
                        if ((y < 0) || (y >= height))
                        {
                            y = 0;
                        }
                        image.SetPixel(num2, i, bitmap2.GetPixel(x, y));
                    }
                }
            }
            brush.Dispose();
            graphics.Dispose();
            info.Image = image;
            return info;
        }

        private static int Next(int max)
        {
            rand.GetBytes(randb);
            int num = BitConverter.ToInt32(randb, 0)%(max + 1);
            if (num < 0)
            {
                num = -num;
            }
            return num;
        }

        private static int Next(int min, int max)
        {
            return (Next(max - min) + min);
        }
    }
}