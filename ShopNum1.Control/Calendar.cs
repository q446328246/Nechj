using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShopNum1.Control
{
    [DefaultProperty("ScriptPath"), ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
    public class Calendar : WebControl, IPostBackDataHandler, INamingContainer
    {
        protected TextBox DateTextBox = new TextBox();
        protected HtmlImage ImgHtmlImage = new HtmlImage();

        [Description("边框的颜色。"), DefaultValue(""), Category("Appearance")]
        public override Color BorderColor
        {
            get
            {
                object obj2 = ViewState["BorderColor"];
                return ((obj2 == null) ? Color.FromArgb(0x99, 0x99, 0x99) : ((Color) obj2));
            }
            set { ViewState["BorderColor"] = value; }
        }

        [Description("边框的样式。"), DefaultValue(""), Category("Appearance"), TypeConverter(typeof (BorderStyleConverter))]
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

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string ImageUrl
        {
            get
            {
                if (base.ViewState["imageurl"] != null)
                {
                    return (string) base.ViewState["imageurl"];
                }
                return "/images/btn_calendar.gif";
            }
            set
            {
                base.ViewState["imageurl"] = value;
                ImgHtmlImage.Src = value;
            }
        }

        [Description("是否是只读。"), DefaultValue(true)]
        public bool ReadOnly { get; set; }

        [DefaultValue("./"), Description("Javascript脚本文件所在目录。")]
        public string ScriptPath
        {
            get
            {
                object obj2 = ViewState["ScriptPath"];
                return ((obj2 == null) ? "/js/calendar.js" : ((string) obj2));
            }
            set { ViewState["ScriptPath"] = value; }
        }

        [Description("当前选择的日期。"), DefaultValue("")]
        public DateTime SelectedDate
        {
            get
            {
                try
                {
                    return DateTime.Parse(DateTextBox.Text);
                }
                catch
                {
                    return Convert.ToDateTime("1900-1-1");
                }
            }
            set
            {
                try
                {
                    DateTextBox.Text = value.ToString("yyyy-MM-dd");
                }
                catch
                {
                    DateTextBox.Text = "";
                }
            }
        }

        [DefaultValue(""), Description("当前输入框的值")]
        public string SelectedText
        {
            get
            {
                try
                {
                    return DateTextBox.Text;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    DateTextBox.Text = value;
                }
                catch
                {
                    DateTextBox.Text = "";
                }
            }
        }

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string text = DateTextBox.Text;
            string str2 = postCollection[postDataKey];
            if (!text.Equals(str2))
            {
                DateTextBox.Text = str2;
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        public void AddAttributes(string string_3, string valuestr)
        {
            DateTextBox.Attributes.Add(string_3, valuestr);
        }

        protected override void CreateChildControls()
        {
            RegularExpressionValidator validator;
            if (ReadOnly)
            {
                DateTextBox.Attributes.Add("readonly", "readonly");
            }
            DateTextBox.Size = 8;
            DateTextBox.ID = ID;
            Controls.Add(DateTextBox);
            ImgHtmlImage.Src = ImageUrl;
            ImgHtmlImage.Align = "bottom";
            ImgHtmlImage.Attributes.Add("onclick", "showcalendar(event, $('" + ClientID + "_" + ID + "'))");
            ImgHtmlImage.Attributes.Add("class", "calendarimg");
            Controls.Add(ImgHtmlImage);
            validator = new RegularExpressionValidator
                {
                    ID = ClientID,
                    Display = ValidatorDisplay.Dynamic,
                    ControlToValidate = DateTextBox.ID,
                    ValidationExpression =
                        @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$",
                    ErrorMessage = "请输入正确的日期,如:2006-1-1"
                };
            Controls.Add(validator);
            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            if (!Page.ClientScript.IsClientScriptBlockRegistered("CalendarSet"))
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CalendarSet",
                                                            string.Format(
                                                                "<SCRIPT language='javascript' src='{0}'></SCRIPT>",
                                                                ScriptPath));
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
        }
    }
}