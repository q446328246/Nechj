using System;
using System.Web.UI.WebControls;

namespace ShopNum1.Control
{
    public class PasswordTextBox : TextBox
    {
        public PasswordTextBox()
        {
            TextMode = TextBoxMode.Password;
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                base.Attributes["value"] = value;
            }
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            base.OnPreRender(eventArgs_0);
            base.Attributes["value"] = Text;
        }
    }
}