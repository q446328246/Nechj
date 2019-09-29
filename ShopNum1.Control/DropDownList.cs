using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Control
{
    [DefaultProperty("Text"), ToolboxData("<{0}:DropDownList runat=server></{0}:DropDownList>")]
    public class DropDownList : System.Web.UI.WebControls.DropDownList, IWebControl, IPostBackDataHandler
    {
        private int int_2 = 50;
        private string string_0 = "";
        private string string_1 = "";
        private string string_2 = "up";

        [Bindable(true), Category("Appearance"), DefaultValue("up")]
        public string HintShowType
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [DefaultValue(""), Category("Appearance"), Bindable(true)]
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

        [Category("Appearance"), Bindable(true), DefaultValue(130)]
        public int HintHeight
        {
            get { return int_2; }
            set { int_2 = value; }
        }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string HintInfo
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        [DefaultValue(0), Category("Appearance"), Bindable(true)]
        public int HintLeftOffSet { get; set; }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string HintTitle
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        [Category("Appearance"), DefaultValue(0), Bindable(true)]
        public int HintTopOffSet { get; set; }

        public void AddTableData(DataTable dt, string textName, string valueName)
        {
            Items.Clear();
            Items.Add(new ListItem("请选择     ", "0"));
            foreach (DataRow row in dt.Rows)
            {
                Items.Add(new ListItem(row[textName].ToString(), row[valueName].ToString()));
            }
            DataBind();
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (HintInfo != "")
            {
                output.WriteBeginTag(
                    string.Concat(new object[]
                        {
                            "span id=\"", ClientID, "\"  onmouseover=\"showhintinfo(this,", HintLeftOffSet, ",",
                            HintTopOffSet, ",'", HintTitle, "','", HintInfo, "','", HintHeight, "','", HintShowType,
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