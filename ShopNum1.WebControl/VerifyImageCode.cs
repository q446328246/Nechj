using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VerifyImageCode : BaseWebControl
    {
        private string skinFilename = "ImgCode.ascx";

        public VerifyImageCode()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
        }

        protected void BindData()
        {
            string htmlColor = "#f6f4f0";
            int textcolor = 1;
            string[] strNumber = htmlColor.Split(new[] {','});
            Color bgcolor = ColorTranslator.FromHtml(htmlColor);
            if (((strNumber.Length != 1) || !(htmlColor != string.Empty)) &&
                ((strNumber.Length == 3) && Validator.IsNumericArray(strNumber)))
            {
                bgcolor = Color.FromArgb(TypeConverter.StrToInt(strNumber[0], 0xff),
                    TypeConverter.StrToInt(strNumber[1], 0xff),
                    TypeConverter.StrToInt(strNumber[2], 0xff));
            }
            VerifyImageInfo info = VerifyImageProvider.GetInstance("1.0.8.16")
                .GenerateImage(method_1(), 0x80, 0x30, bgcolor, textcolor);
            Bitmap image = info.Image;
            HttpContext.Current.Response.ContentType = info.ContentType;
            image.Save(Page.Response.OutputStream, info.ImageFormat);
        }

        private string method_1()
        {
            string str = string.Empty;
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                char ch;
                int num2 = random.Next();
                if ((num2%2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num2%10)));
                }
                else
                {
                    ch = (char) (0x61 + ((ushort) (num2%0x1a)));
                }
                str = str + ch;
            }
            Page.Response.Cookies.Remove("VerifyCode");
            Page.Response.Cookies.Add(new HttpCookie("VerifyCode", str));
            return str;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            BindData();
        }
    }
}