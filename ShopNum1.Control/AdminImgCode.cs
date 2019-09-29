using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;

namespace ShopNum1.Control
{
    /// <summary>
    ///     验证码
    /// </summary>
    [ParseChildren(true)]
    public class AdminImgCode : System.Web.UI.WebControls.WebControl
    {
        private void BindData()
        {
            var random = new Random();
            string str = random.Next(0x457, 0x270f).ToString();
            int width = 0;
            int height = 0;
            Bitmap bitmap = null;
            Graphics graphics = null;
            SolidBrush brush = null;
            method_1(str);
            try
            {
                int num14;
                Image image = Image.FromFile(Page.Server.MapPath("images/CheckCode/" + str.Substring(0, 1) + ".gif"));
                Image image2 = Image.FromFile(Page.Server.MapPath("images/CheckCode/" + str.Substring(1, 1) + ".gif"));
                Image image3 = Image.FromFile(Page.Server.MapPath("images/CheckCode/" + str.Substring(2, 1) + ".gif"));
                Image image4 = Image.FromFile(Page.Server.MapPath("images/CheckCode/" + str.Substring(3, 1) + ".gif"));
                width = (((image.Width + image2.Width) + image3.Width) + image4.Width) + 20;
                height = image.Height + 5;
                bitmap = new Bitmap(width, height);
                graphics = Graphics.FromImage(bitmap);
                int red = Convert.ToInt32("63", 0x10);
                int green = Convert.ToInt32("92", 0x10);
                int blue = Convert.ToInt32("C2", 0x10);
                brush = new SolidBrush(Color.FromArgb(red, green, blue));
                int x = random.Next(0, 5);
                int num8 = random.Next(0, 5);
                int num9 = random.Next(0, 5);
                random.Next(0, 5);
                int y = random.Next(0, 5);
                int num11 = random.Next(0, 5);
                int num12 = random.Next(0, 5);
                int num13 = random.Next(0, 5);
                graphics.FillRectangle(brush, 0, 0, width, height);
                graphics.DrawImage(image, x, y);
                graphics.DrawImage(image2, (image.Width + x) + num8, num11);
                graphics.DrawImage(image3, (((image.Width + image2.Width) + x) + num8) + num9, num12);
                graphics.DrawImage(image4, ((((image.Width + image2.Width) + image3.Width) + x) + num8) + num9, num13);
                var colorArray2 = new[] {Color.Black, Color.Green, Color.Orange, Color.Brown};
                for (num14 = 0; num14 < 2; num14++)
                {
                    int num15 = random.Next(80);
                    int num16 = random.Next(0x19);
                    int num17 = random.Next(80);
                    int num18 = random.Next(0x19);
                    Color color = colorArray2[random.Next(colorArray2.Length)];
                    graphics.DrawLine(new Pen(color), num15, num16, num17, num18);
                }
                for (num14 = 0; num14 < 100; num14++)
                {
                    int num19 = random.Next(bitmap.Width);
                    int num20 = random.Next(bitmap.Height);
                    bitmap.SetPixel(num19, num20, Color.FromArgb(random.Next()));
                }
                var stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Bmp);
                Page.Response.ClearContent();
                Page.Response.ContentType = "image/bmp";
                Page.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                brush.Dispose();
                graphics.Dispose();
                bitmap.Dispose();
            }
        }

        private void method_1(string string_0)
        {
            var cookie = new HttpCookie("VerifyCode")
                {
                    Value = string_0
                };
            Page.Response.Cookies.Add(cookie);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            BindData();
        }
    }
}