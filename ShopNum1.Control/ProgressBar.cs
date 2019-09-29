using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Control
{
    public class ProgressBar : WebControl
    {
        private int int_3;
        private int int_4 = 20;
        private string string_3 = "";
        private string string_4 = "";
        private string string_5 = "";

        public ProgressBar()
        {
            BackColor = Color.LightGray;
            ForeColor = Color.Blue;
            BorderColor = Color.Empty;
            base.Width = Unit.Pixel(100);
            base.Height = Unit.Pixel(0x10);
        }

        public string BarImageUrl
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string FillImageUrl
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string ImageGeneratorUrl
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public int Percentage
        {
            get { return int_3; }
            set
            {
                if (value > 100)
                {
                    int_3 = 100;
                }
                else if (value < 0)
                {
                    int_3 = 0;
                }
                else
                {
                    int_3 = value;
                }
            }
        }

        public int PercentageStep
        {
            get { return (100/int_4); }
            set
            {
                if ((100%value) != 0)
                {
                    throw new ArgumentException("The percentage step value must be divisible by 100");
                }
                int_4 = 100/value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (Width.Type != UnitType.Pixel)
            {
                throw new ArgumentException("The width must be in pixels");
            }
            var num4 = (int) Width.Value;
            if (ImageGeneratorUrl != "")
            {
                string str3 = "";
                if (BorderColor != Color.Empty)
                {
                    str3 = "&bc=" + ColorTranslator.ToHtml(BorderColor);
                }
                output.Write(
                    string.Format(
                        "<img src='{0}?w={1}&h={2}&p={3}&fc={4}&bk={5}{6}' border='0' width='{1}' height='{2}'>",
                        new object[]
                            {
                                ImageGeneratorUrl, num4, Height.ToString(), Percentage,
                                ColorTranslator.ToHtml(ForeColor),
                                ColorTranslator.ToHtml(BackColor), str3
                            }));
            }
            else
            {
                if (BorderColor != Color.Empty)
                {
                    output.Write("<table border='0' cellspacing='0' cellpadding='1' bgColor='" +
                                 ColorTranslator.ToHtml(BorderColor) + "'><tr><td>");
                }
                if (BarImageUrl == "")
                {
                    output.Write(
                        string.Concat(new object[]
                            {
                                "<table border='0' cellspacing='0' cellpadding='0' height='", Height, "' bgColor='",
                                ColorTranslator.ToHtml(BackColor), "'><tr>"
                            }));
                    int num2 = num4/int_4;
                    int num = 0;
                    int percentageStep = PercentageStep;
                    string str2 = "";
                    if (Page.Request.Browser.Browser.ToUpper() == "NETSCAPE")
                    {
                        if (FillImageUrl != "")
                        {
                            str2 =
                                string.Concat(new object[]
                                    {"<img src='", FillImageUrl, "' border='0' width='", num2, "'>"});
                        }
                        else
                        {
                            str2 = "&nbsp;";
                        }
                    }
                    int num3 = 0;
                    while (num3 < int_4)
                    {
                        string str;
                        if (num < int_3)
                        {
                            str = " bgColor='" + ColorTranslator.ToHtml(ForeColor) + "'";
                        }
                        else
                        {
                            str = "";
                        }
                        if (num3 == 0)
                        {
                            output.Write(
                                string.Concat(new object[]
                                    {"<td height='", Height, "' width='", num2, "'", str, ">", str2, "</td>"}));
                        }
                        else
                        {
                            output.Write(string.Concat(new object[] {"<td width='", num2, "'", str, ">", str2, "</td>"}));
                        }
                        num3++;
                        num += percentageStep;
                    }
                    output.Write("</tr></table>");
                }
                else
                {
                    var num5 = (int) (((int_3)/100.0)*num4);
                    output.Write(
                        string.Concat(new object[]
                            {
                                "<table border='0' cellpadding='0' cellSpacing='0' bgColor='",
                                ColorTranslator.ToHtml(BackColor), "'><tr><td width='", num4, "'>"
                            }));
                    output.Write(
                        string.Concat(new object[]
                            {"<img src='", BarImageUrl, "' width='", num5, "' height='", Height, "'>"}));
                    output.Write("</td></tr></table>");
                }
                if (BorderColor != Color.Empty)
                {
                    output.Write("</td></tr></table>");
                }
            }
        }
    }
}