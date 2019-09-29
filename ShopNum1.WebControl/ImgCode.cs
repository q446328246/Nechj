using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ImgCode : BaseWebControl
    {
        private string skinFilename = "ImgCode.ascx";

        public ImgCode()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int isSession { get; set; }

        protected override void InitializeSkin(Control skin)
        {
        }

        private string BindData()
        {
            Func<string, string> func = method_2;
            string arg = string.Empty;
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                char ch;
                int num2 = random.Next();
                if ((num2%2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num2%10)));
                }
                else
                {
                    ch = (char) (0x41 + ((ushort) (num2%0x1a)));
                }
                arg = arg + ch;
            }
            return func(arg);
        }

        protected void method_1(string string_1)
        {
            var image = new Bitmap((int) Math.Ceiling((string_1.Length*13.5)), 0x16);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                int num;
                var random = new Random();
                graphics.Clear(Color.White);
                for (num = 0; num < 0x19; num++)
                {
                    int num2 = random.Next(image.Width);
                    int num3 = random.Next(image.Width);
                    int num4 = random.Next(image.Height);
                    int num5 = random.Next(image.Height);
                    graphics.DrawLine(new Pen(Color.Silver), num2, num4, num3, num5);
                }
                var font = new Font("Arial", 12f, FontStyle.Italic | FontStyle.Bold);
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue,
                    Color.DarkRed, 1.2f, true);
                graphics.DrawString(string_1, font, brush, 2f, 2f);
                for (num = 0; num < 100; num++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                var stream = new MemoryStream();
                image.Save(stream, ImageFormat.Gif);

                Page.Response.ClearContent();
                Page.Response.ContentType = "image/Gif";
                Page.Response.BinaryWrite(stream.ToArray());
                stream.Close();
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();
            }
        }


        private string method_2(string string_1)
        {
            if (isSession == 1)
            {
                HttpContext.Current.Session["code"] = string_1;
                return string_1;
            }
            Page.Response.Cookies.Remove("VerifyCode");
            Page.Response.Cookies.Add(new HttpCookie("VerifyCode", string_1));
            return string_1;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            method_1(BindData());
        }
    }
}