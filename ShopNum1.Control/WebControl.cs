using System.ComponentModel;

namespace ShopNum1.Control
{
    public class WebControl : System.Web.UI.WebControls.WebControl, IWebControl
    {
        private int int_2 = 50;
        private string string_0 = "";
        private string string_1 = "";
        private string string_2 = "up";

        [DefaultValue("up"), Bindable(true), Category("Appearance")]
        public string HintShowType
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [Category("Appearance"), Bindable(true), DefaultValue(50)]
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

        [Category("Appearance"), DefaultValue(0), Bindable(true)]
        public int HintLeftOffSet { get; set; }

        [DefaultValue(""), Category("Appearance"), Bindable(true)]
        public string HintTitle
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        [DefaultValue(0), Bindable(true), Category("Appearance")]
        public int HintTopOffSet { get; set; }
    }
}