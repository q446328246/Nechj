using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DefaultAdvertisementFlash : BaseWebControl
    {
        private HtmlGenericControl DivFlash;
        private string skinFilename = "DefaultAdvertisementFlash.ascx";
        private string string_1 = "247";
        private string string_2 = "497";
        private string string_3 = "0x333333";
        private string string_4 = "0xFCEBAF";

        public DefaultAdvertisementFlash()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string backcolors
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string DivFlashID { get; set; }

        public string FlashHeight
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string FlashWidth
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string WordColor
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public void BindAd()
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            DataTable table =
                ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowADByDivID(
                    DivFlashID, "2");
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str6 = table.Rows[i]["Content"].ToString();
                    if (str == "")
                    {
                        str = str6;
                    }
                    else
                    {
                        str = str + "|" + str6;
                    }
                    string str5 = table.Rows[i]["Href"].ToString();
                    if (str2 == "")
                    {
                        str2 = str5;
                    }
                    else
                    {
                        str2 = str2 + "|" + str5;
                    }
                    string str4 = table.Rows[i]["explain"].ToString();
                    if (str3 == "")
                    {
                        str3 = str4;
                    }
                    else
                    {
                        str3 = str3 + "|" + str4;
                    }
                }
            }
            method_0(DivFlash, str, str2, str3);
        }

        protected override void InitializeSkin(Control skin)
        {
            DivFlash = (HtmlGenericControl) skin.FindControl("DivFlash");
            BindAd();
        }

        protected void method_0(HtmlGenericControl htmlGenericControl_1, string string_6, string string_7,
            string string_8)
        {
            string flashWidth = FlashWidth;
            string flashHeight = FlashHeight;
            string str3 = string_6;
            string str4 = string_7;
            string str5 = string_8;
            var builder = new StringBuilder();
            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine(" var swf_width=" + flashWidth);
            builder.AppendLine("var swf_height=" + flashHeight);
            builder.AppendLine(" var files='" + str3 + "'");
            builder.AppendLine("var links='" + str4 + "'");
            builder.AppendLine("var texts='" + str5 + "'");
            builder.AppendLine(
                "document.write('<param name=\"movie\" value=\"Themes/Skin_Default/bcastr3.swf\"><param name=\"quality\" value=\"high\">');");
            builder.AppendLine(
                "document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');");
            builder.AppendLine(
                "document.write('<param name=\"FlashVars\" value=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=" +
                WordColor + ":文字颜色|1:文字位置|" + backcolors +
                ":文字背景颜色|60:文字背景透明度|0x333333:按键文字颜色|0x4A3E28:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口\">');");
            builder.AppendLine(
                "document.write('<embed src=\"Themes/Skin_Default/bcastr3.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=" +
                WordColor + ":文字颜色|1:文字位置|" + backcolors +
                ":文字背景颜色|60:文字背景透明度|0xffffff:按键文字颜色|0xdedede:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口& menu=\"false\" quality=\"high\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />'); document.write('</object>');");
            builder.AppendLine("</script>");
            htmlGenericControl_1.InnerHtml = builder.ToString();
        }
    }
}