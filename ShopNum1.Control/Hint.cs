using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace ShopNum1.Control
{
    [DefaultEvent("Click"), ToolboxData("<{0}:Hint runat=server></{0}:Hint>"), DefaultProperty("Text")]
    public class Hint : System.Web.UI.WebControls.WebControl
    {
        [DefaultValue(""), Bindable(true), Category("Appearance")]
        public string HintImageUrl
        {
            get
            {
                if (base.ViewState["hintimageurl"] != null)
                {
                    return (string) base.ViewState["hintimageurl"];
                }
                return "../images";
            }
            set { base.ViewState["hintimageurl"] = value; }
        }

        protected override void Render(HtmlTextWriter output)
        {
            var builder = new StringBuilder();
            builder.Append("<!--提示层部分开始-->");
            builder.Append("<span id=\"hintdivup\" style=\"display:none; position:absolute;z-index:500;\">\r\n");
            builder.Append("<div style=\"position:absolute; visibility: visible; width: 271px;z-index:501;\">\r\n");
            builder.Append("<p><img src=\"" + HintImageUrl + "/commandbg.gif\" /></p>\r\n");
            builder.Append("<div class=\"messagetext\"><img src=\"" + HintImageUrl +
                           "/dot.gif\" /><span id=\"hintinfoup\" ></span></div>\r\n");
            builder.Append("<p><img src=\"" + HintImageUrl + "/commandbg2.gif\" /></p>\r\n");
            builder.Append("</div>\r\n");
            builder.Append(
                "<iframe id=\"hintiframeup\" style=\"position:absolute;z-index:100;width:266px;scrolling:no;\" frameborder=\"0\"></iframe>\r\n");
            builder.Append("</span>\r\n");
            builder.Append("<span id=\"hintdivdown\" style=\"display:none; position:absolute;z-index:500;\">\r\n");
            builder.Append("<div style=\"position:absolute; visibility: visible; width: 271px;z-index:501;\">\r\n");
            builder.Append("<p><img src=\"" + HintImageUrl + "/commandbg3.gif\" /></p>\r\n");
            builder.Append("<div class=\"messagetext\"><img src=\"" + HintImageUrl +
                           "/dot.gif\" /><span id=\"hintinfodown\" ></span></div>\r\n");
            builder.Append("<p><img src=\"" + HintImageUrl + "/commandbg4.gif\" /></p>\r\n");
            builder.Append("</div>\r\n");
            builder.Append(
                "<iframe id=\"hintiframedown\" style=\"position:absolute;z-index:100;width:266px;scrolling:no;\" frameborder=\"0\"></iframe>\r\n");
            builder.Append("</span>\r\n");
            builder.Append("<!--提示层部分结束-->\r\n");
            output.Write(builder.ToString());
        }
    }
}