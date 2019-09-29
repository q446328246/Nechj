using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Control
{
    [DefaultProperty("Text"), ToolboxData("<{0}:RadioButtonList runat=server></{0}:RadioButtonList>")]
    public class RadioButtonList : System.Web.UI.WebControls.RadioButtonList, IWebControl, IPostBackDataHandler
    {
        private int int_2 = 50;
        private string string_0 = "";
        private string string_1 = "";
        private string string_2 = "up";

        public RadioButtonList()
        {
            BorderStyle = BorderStyle.Dotted;
            BorderWidth = 0;
            RepeatColumns = 2;
            RepeatDirection = RepeatDirection.Vertical;
            RepeatLayout = RepeatLayout.Table;
            CssClass = "buttonlist";
        }

        [DefaultValue("up"), Category("Appearance"), Bindable(true)]
        public string HintShowType
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [DefaultValue(0), Bindable(true), Category("Appearance")]
        public int HintTopFirefoxOffset { get; set; }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string SetFocusButtonID
        {
            get
            {
                object obj2 = ViewState[ClientID + "_SetFocusButtonID"];
                return ((obj2 == null) ? "" : obj2.ToString());
            }
            set
            {
                ViewState[ClientID + "_SetFocusButtonID"] = value;
                if (value != "")
                {
                    base.Attributes.Add("onChange", "document.getElementById('" + value + "').focus();");
                }
            }
        }

        [DefaultValue(130), Category("Appearance"), Bindable(true)]
        public int HintHeight
        {
            get { return int_2; }
            set { int_2 = value; }
        }

        [Category("Appearance"), Bindable(true), DefaultValue("")]
        public string HintInfo
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        [Bindable(true), DefaultValue(0), Category("Appearance")]
        public int HintLeftOffSet { get; set; }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string HintTitle
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        [Bindable(true), DefaultValue(0), Category("Appearance")]
        public int HintTopOffSet { get; set; }

        protected override void Render(HtmlTextWriter output)
        {
            if (HintInfo != "")
            {
                output.WriteBeginTag(string.Concat(new object[]
                    {
                        "span id=\"", ClientID, "\"  onmouseover=\"showhintinfo(this,", HintLeftOffSet, ",",
                        HintTopOffSet, ",'", HintTitle, "','", HintInfo, "','", HintHeight, "','", HintShowType, "','",
                        HintTopFirefoxOffset,
                        "');\" onmouseout=\"hidehintinfo();\">"
                    }));
            }
            base.Render(output);
            if (HintInfo != "")
            {
                output.WriteEndTag("span");
            }
        }
    }
}