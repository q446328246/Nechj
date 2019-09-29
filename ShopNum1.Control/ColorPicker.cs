using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ShopNum1.Control
{
    [ToolboxData("<{0}:ColorPicker runat=server></{0}:ColorPicker>"), DefaultProperty("ScriptPath")]
    public class ColorPicker : WebControl, IPostBackDataHandler, INamingContainer
    {
        protected TextBox ColorTextBox = new TextBox();
        protected HtmlImage ImgHtmlImage = new HtmlImage();

        [DefaultValue(""), Category("Appearance"), Description("边框的颜色。")]
        public override Color BorderColor
        {
            get
            {
                object obj2 = ViewState["BorderColor"];
                return ((obj2 == null) ? Color.FromArgb(0x99, 0x99, 0x99) : ((Color) obj2));
            }
            set { ViewState["BorderColor"] = value; }
        }

        [Category("Appearance"), DefaultValue(""), Description("边框的样式。"), TypeConverter(typeof (BorderStyleConverter))]
        public string BorderStyle
        {
            get
            {
                object obj2 = ViewState["BorderStyle"];
                return ((obj2 == null) ? "solid" : ((string) obj2));
            }
            set { ViewState["BorderStyle"] = value; }
        }

        [Description("边框的宽度。"), DefaultValue(""), Category("Appearance")]
        public string BorderWidth
        {
            get
            {
                object obj2 = ViewState["BorderWidth"];
                return ((obj2 == null) ? "1" : ((string) obj2));
            }
            set { ViewState["BorderWidth"] = value; }
        }

        [Category("Appearance"), DefaultValue(""), Description("CSS文件路径。")]
        public string Css_Path
        {
            get
            {
                object obj2 = ViewState["ColorPickerCssPath"];
                return ((obj2 == null) ? "/css/colorpicker.css" : ((string) obj2));
            }
            set { ViewState["ColorPickerCssPath"] = value; }
        }

        [Category("Appearance"), Bindable(true), DefaultValue("")]
        public string ImageUrl
        {
            get
            {
                if (base.ViewState["imageurl"] != null)
                {
                    return (string) base.ViewState["imageurl"];
                }
                return "/images/colorpicker.gif";
            }
            set
            {
                base.ViewState["imageurl"] = value;
                ImgHtmlImage.Src = value;
            }
        }

        [Description("向左偏移量"), DefaultValue(0)]
        public float LeftOffSet
        {
            get
            {
                object obj2 = ViewState["LeftOffSet"];
                return ((obj2 == null) ? 0f : ((float) obj2));
            }
            set { ViewState["LeftOffSet"] = value; }
        }

        [DefaultValue(true), Description("是否是只读")]
        public bool ReadOnly
        {
            get { return ((Environment.Version.Major == 1) && ColorTextBox.ReadOnly); }
            set
            {
                if (Environment.Version.Major == 1)
                {
                    ColorTextBox.ReadOnly = value;
                }
            }
        }

        [Description("Javascript脚本文件所在目录。"), DefaultValue("./")]
        public string ScriptPath
        {
            get
            {
                object obj2 = ViewState["ScriptPath"];
                return ((obj2 == null) ? "/js/colorpicker.js" : ((string) obj2));
            }
            set { ViewState["ScriptPath"] = value; }
        }

        [Description("当前选择的颜色值"), DefaultValue("")]
        public string Text
        {
            get { return ColorTextBox.Text; }
            set { ColorTextBox.Text = value.Trim(); }
        }

        [Description("向上偏移量"), DefaultValue(0)]
        public float TopOffSet
        {
            get
            {
                object obj2 = ViewState["TopOffSet"];
                return ((obj2 == null) ? 0f : ((float) obj2));
            }
            set { ViewState["TopOffSet"] = value; }
        }

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string text = ColorTextBox.Text;
            string str2 = postCollection[postDataKey];
            if (!text.Equals(str2))
            {
                ColorTextBox.Text = str2;
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        public void AddAttributes(string string_3, string valuestr)
        {
            ColorTextBox.Attributes.Add(string_3, valuestr);
        }

        public string ColorPickHtmlContent()
        {
            var builder = new StringBuilder();
            builder.Append(
                "<span id=\"ColorPicker{0}\" style=\"display:none; position:absolute;z-index:500;\" onmouseout=\"HideColorPanel('{0}');\"  onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
            builder.Append("<div  style=\"display:block;cursor:crosshair;z-index:501\" class=\"article\" >");
            builder.Append(
                "<table border=0 cellPadding=0 cellSpacing=10 onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");
            builder.Append("<script language=\"javaScript\">");
            builder.Append("WriteColorPanel('{0}','{1}',{2},{3});");
            builder.Append("</script>");
            builder.Append("</tr></tbody></table>");
            builder.Append(
                "<table style=\"font-size:12px;word-break:break-all;width:100%;border:0px\"  cellPadding=0 cellSpacing=10 onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");
            builder.Append("<td align=middle rowSpan=2>选中色彩");
            builder.Append(
                "<table border=1 cellPadding=0 cellSpacing=0 height=30 id=ShowColor{0} width=40 bgcolor=\"\">");
            builder.Append("<tbody>");
            builder.Append("<tr>");
            builder.Append("<td></td></tr></tbody></table></td>");
            builder.Append(
                "<td rowSpan=2>基色: <SPAN id=RGB{0}></SPAN><br />亮度: <SPAN id=GRAY{0}>120</SPAN><br />代码: <INPUT id=SelColor{0} size=7 value=\"\" border=0></TD>");
            builder.Append(
                "<td><input type=\"button\" onclick=\"javascript:ColorPickerOK('{0}','{1}');\" value=\"确定\"></TD></TR>");
            builder.Append("<tr>");
            builder.Append(
                "<td><input type=\"button\" onclick=\"javascript:document.getElementById('{0}').value='';document.getElementById('{1}').style.background='#FFFFFF';HideColorPanel('{0}');\" value=\"取消\"></TD>");
            builder.Append("</tr></tbody></table>");
            builder.Append("</DIV>");
            builder.Append(
                "<iframe id=\"pickcoloriframe{0}\" style=\"position:absolute;z-index:102;top:-1px;width:250px;scrolling:no;height:237px;\" frameborder=\"0\"></iframe>");
            builder.Append("</span>");
            builder.Append("<script language=javascript>\r\n");
            builder.Append("InitColorPicker('{1}','" + Text + "');\r\n");
            builder.Append("</script>\r\n");
            return string.Format(builder.ToString(),
                                 new object[] {ColorTextBox.ClientID, ImgHtmlImage.ClientID, LeftOffSet, TopOffSet});
        }

        protected override void CreateChildControls()
        {
            ColorTextBox.Size = 8;
            ColorTextBox.ID = ID;
            Controls.Add(ColorTextBox);
            ImgHtmlImage.ID = "ColorPreview";
            ImgHtmlImage.Src = ImageUrl;
            ImgHtmlImage.Attributes.Add("onclick",
                                        string.Concat(new object[]
                                            {
                                                "IsShowColorPanel('", ColorTextBox.ClientID, "','",
                                                ImgHtmlImage.ClientID,
                                                "',", LeftOffSet, ",", TopOffSet, ")"
                                            }));
            ImgHtmlImage.Attributes.Add("class", "img");
            ImgHtmlImage.Attributes.Add("title", "选择颜色");
            Controls.Add(ImgHtmlImage);
            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            string script =
                string.Format(
                    "<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\">\r\n<script language=\"javascript\" src=\"{1}\"></script>\r\n",
                    Css_Path, ScriptPath);
            if (!Page.ClientScript.IsClientScriptBlockRegistered("ColorPickerSet"))
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ColorPickerSet", script);
            }
            base.OnPreRender(eventArgs_0);
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (base.HintInfo != "")
            {
                output.WriteBeginTag(
                    string.Concat(new object[]
                        {
                            "span id=\"", ClientID, "\"  onmouseover=\"showhintinfo(this,", base.HintLeftOffSet, ",",
                            base.HintTopOffSet, ",'", base.HintTitle, "','", base.HintInfo, "','", base.HintHeight,
                            "','", base.HintShowType, "');\" onmouseout=\"hidehintinfo();\">"
                        }));
            }
            RenderChildren(output);
            if (base.HintInfo != "")
            {
                output.WriteEndTag("span");
            }
            output.Write(ColorPickHtmlContent());
        }
    }
}