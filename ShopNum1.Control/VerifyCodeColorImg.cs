using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace ShopNum1.Control
{
    [ParseChildren(true)]
    public class VerifyCodeColorImg : System.Web.UI.WebControls.WebControl
    {
        public string BackgroundColor { get; set; }

        public string isSession { get; set; }

        public string PrefixCookieName { get; set; }

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
                Image image =
                    Image.FromFile(
                        Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + str.Substring(0, 1) + ".gif"));
                Image image2 =
                    Image.FromFile(
                        Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + str.Substring(1, 1) + ".gif"));
                Image image3 =
                    Image.FromFile(
                        Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + str.Substring(2, 1) + ".gif"));
                Image image4 =
                    Image.FromFile(
                        Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + str.Substring(3, 1) + ".gif"));
                width = (((image.Width + image2.Width) + image3.Width) + image4.Width) + 20;
                height = image.Height + 5;
                bitmap = new Bitmap(width, height);
                graphics = Graphics.FromImage(bitmap);
                try
                {
                    brush = new SolidBrush(ToColor(BackgroundColor));
                }
                catch
                {
                    int red = Convert.ToInt32("63", 0x10);
                    int green = Convert.ToInt32("92", 0x10);
                    int blue = Convert.ToInt32("C2", 0x10);
                    brush = new SolidBrush(Color.FromArgb(red, green, blue));
                }
                int x = random.Next(0, 5);
                int num11 = random.Next(0, 5);
                int num12 = random.Next(0, 5);
                random.Next(0, 5);
                int y = random.Next(0, 5);
                int num14 = random.Next(0, 5);
                int num15 = random.Next(0, 5);
                int num16 = random.Next(0, 5);
                graphics.FillRectangle(brush, 0, 0, width, height);
                graphics.DrawImage(image, x, y);
                graphics.DrawImage(image2, (image.Width + x) + num11, num14);
                graphics.DrawImage(image3, (((image.Width + image2.Width) + x) + num11) + num12, num15);
                graphics.DrawImage(image4, ((((image.Width + image2.Width) + image3.Width) + x) + num11) + num12, num16);
                var colorArray = new[] {Color.Black, Color.Green, Color.Orange, Color.Brown};
                for (int i = 0; i < 100; i++)
                {
                    int num8 = random.Next(bitmap.Width);
                    int num9 = random.Next(bitmap.Height);
                    bitmap.SetPixel(num8, num9, Color.FromArgb(random.Next()));
                }
                var stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Bmp);
                Page.Response.ClearContent();
                Page.Response.ContentType = "image/bmp";
                Page.Response.BinaryWrite(stream.ToArray());
            }
            catch
            {
            }
            finally
            {
                brush.Dispose();
                graphics.Dispose();
                bitmap.Dispose();
            }
        }

        private void method_1(string string_3)
        {
            object obj2 = ConfigurationManager.AppSettings["CookieName"];
            string name = (obj2 == null) ? "VerifyCode" : obj2.ToString();
            if (!string.IsNullOrEmpty(PrefixCookieName))
            {
                name = PrefixCookieName + name;
            }
            if (isSession != "1")
            {
                var cookie = new HttpCookie(name)
                    {
                        Value = string_3
                    };
                Page.Response.Cookies.Add(cookie);
            }
            else
            {
                HttpContext.Current.Session[name] = string_3;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            BindData();
        }

        public Color ToColor(string color)
        {
            char[] chArray2;
            int num3;
            int num4;
            int blue = 0;
            color = color.TrimStart(new[] {'#'});
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            int length = color.Length;
            if (length != 3)
            {
                if (length != 6)
                {
                    return Color.FromName(color);
                }
                chArray2 = color.ToCharArray();
                num3 = Convert.ToInt32(chArray2[0].ToString() + chArray2[1].ToString(), 0x10);
                num4 = Convert.ToInt32(chArray2[2].ToString() + chArray2[3].ToString(), 0x10);
                blue = Convert.ToInt32(chArray2[4].ToString() + chArray2[5].ToString(), 0x10);
                return Color.FromArgb(num3, num4, blue);
            }
            chArray2 = color.ToCharArray();
            num3 = Convert.ToInt32(chArray2[0].ToString() + chArray2[0].ToString(), 0x10);
            num4 = Convert.ToInt32(chArray2[1].ToString() + chArray2[1].ToString(), 0x10);
            blue = Convert.ToInt32(chArray2[2].ToString() + chArray2[2].ToString(), 0x10);
            return Color.FromArgb(num3, num4, blue);
        }
    }
}