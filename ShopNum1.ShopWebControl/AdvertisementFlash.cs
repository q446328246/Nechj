using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class AdvertisementFlash : BaseWebControl
    {
        private string skinFilename = "Advertisements.ascx";
        private string string_1 = "200";
        private string string_2 = "702";
        private string string_3 = "0xFFFFFF";
        private string string_4 = "0xE14D4D";

        public AdvertisementFlash()
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

        public string OpenTime { get; set; }

        public string SetPath { get; set; }

        public string ShopID { get; set; }

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
            var action = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
            action.StrPath = SetPath;
            DataTable table = action.ShowADByDivID(DivFlashID);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["type"].ToString() == "3")
                    {
                        string str5 = table.Rows[i]["Content"].ToString();
                        if (str == "")
                        {
                            str = str5;
                        }
                        else
                        {
                            str = str + "|" + str5;
                        }
                        string str6 = table.Rows[i]["Href"].ToString();
                        if (str2 == "")
                        {
                            str2 = str6;
                        }
                        else
                        {
                            str2 = str2 + "|" + str6;
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
            }
            var control = (HtmlGenericControl) Page.FindControl(DivFlashID);
            BindData(control, str, str2, str3);
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            if (ShopID != "0")
            {
                DataTable memSimpleByShopID =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                        ShopSettings.GetValue("PersonShopUrl") + ShopID);
                if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                {
                    OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                              ShopID + "/Themes/Skin_Default/Advertisement.xml";
                    BindAd();
                }
            }
        }

        protected void BindData(HtmlGenericControl htmlGenericControl_0, string string_9, string string_10,
            string string_11)
        {
            string flashWidth = FlashWidth;
            string flashHeight = FlashHeight;
            string str3 = string_9;
            string str4 = string_10;
            string str5 = string_11;
            var builder = new StringBuilder();
            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine(" var swf_width=" + flashWidth);
            builder.AppendLine("var swf_height=" + flashHeight);
            builder.AppendLine(" var files='" + str3 + "'");
            builder.AppendLine("var links='" + str4 + "'");
            builder.AppendLine("var texts='" + str5 + "'");
            builder.AppendLine(
                "document.write('<param name=\"movie\" value=\"bcastr3.swf\"><param name=\"quality\" value=\"high\">');");
            builder.AppendLine(
                "document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');");
            builder.AppendLine(
                "document.write('<param name=\"FlashVars\" value=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=" +
                WordColor + ":文字颜色|1:文字位置|" + backcolors +
                ":文字背景颜色|60:文字背景透明度|0x333333:按键文字颜色|0x4A3E28:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口\">');");
            builder.AppendLine(
                "document.write('<embed src=\"bcastr3.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=" +
                WordColor + ":文字颜色|1:文字位置|" + backcolors +
                ":文字背景颜色|60:文字背景透明度|0xffffff:按键文字颜色|0xdedede:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口& menu=\"false\" quality=\"high\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />'); document.write('</object>');");
            builder.AppendLine("</script>");
            htmlGenericControl_0.InnerHtml = builder.ToString();
        }
    }
}