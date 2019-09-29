using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopImgCode : BaseWebControl
    {
        private string skinFilename = "ShopImgCode.ascx";

        public ShopImgCode()
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
            Delegate0 delegate2 = method_2;
            string str = string.Empty;
            var chArray = new[]
            {
                '2', '3', '4', '5', '6', '8', 'a', 'd', 'e', 'f', 'g', '9', 'A', 'B', 'C', 'D',
                'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y'
            };
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                str = str + chArray[random.Next(chArray.Length)];
            }
            return delegate2(str);
        }

        protected void method_1(string string_1)
        {
            int num;
            Color color;
            var colorArray2 = new[]
            {Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue};
            var strArray2 = new[] {"Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact"};
            var random = new Random();
            var image = new Bitmap(80, 0x19);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            for (num = 0; num < 5; num++)
            {
                int num2 = random.Next(80);
                int num3 = random.Next(0x19);
                int num4 = random.Next(80);
                int num5 = random.Next(0x19);
                color = colorArray2[random.Next(colorArray2.Length)];
                graphics.DrawLine(new Pen(color), num2, num3, num4, num5);
            }
            for (num = 0; num < string_1.Length; num++)
            {
                string familyName = strArray2[random.Next(strArray2.Length)];
                var font = new Font(familyName, 16f);
                color = colorArray2[random.Next(colorArray2.Length)];
                graphics.DrawString(string_1[num].ToString(), font, new SolidBrush(color), (num*20f), 3f);
            }
            for (num = 0; num < 100; num++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                color = colorArray2[random.Next(colorArray2.Length)];
                image.SetPixel(x, y, color);
            }
            Page.Response.Buffer = true;
            Page.Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(0.0);
            Page.Response.Expires = 0;
            Page.Response.CacheControl = "no-cache";
            Page.Response.AppendHeader("Pragma", "No-Cache");
            var stream = new MemoryStream();
            try
            {
                image.Save(stream, ImageFormat.Png);
                Page.Response.ClearContent();
                Page.Response.ContentType = "image/Png";
                Page.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                image.Dispose();
                graphics.Dispose();
            }
        }


        private string method_2(string string_1)
        {
            if (isSession == 1)
            {
                HttpContext.Current.Session["code"] = string_1;
                return string_1;
            }
            Page.Response.Cookies.Remove("ShopVerifyCode");
            Page.Response.Cookies.Add(new HttpCookie("ShopVerifyCode", string_1));
            return string_1;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            method_1(BindData());
        }

        private delegate string Delegate0(string string_0);
    }
}