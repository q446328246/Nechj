using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopnum1.Control
{
    [ToolboxData("<{0}:GroupRadioButton runat=server></{0}:GroupRadioButton>")]
    public class GroupRadioButton : RadioButton, IPostBackDataHandler
    {
        private string Value
        {
            get
            {
                string str = base.Attributes["value"];
                if (str == null)
                {
                    return UniqueID;
                }
                return (UniqueID + "_" + str);
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            bool flag = false;
            string str = postCollection[GroupName];
            if ((str != null) && (str == Value))
            {
                if (!Checked)
                {
                    Checked = true;
                    flag = true;
                }
                return flag;
            }
            if (Checked)
            {
                Checked = false;
            }
            return flag;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            OnCheckedChanged(EventArgs.Empty);
        }

        private void method_0(HtmlTextWriter htmlTextWriter_0)
        {
            htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
            htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Name, GroupName);
            htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Value, Value);
            if (Checked)
            {
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
            }
            if (!Enabled)
            {
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            }
            string str = base.Attributes["onclick"];
            if (AutoPostBack)
            {
                if (str != null)
                {
                    str = string.Empty;
                }
                str = str + Page.ClientScript.GetPostBackEventReference(this, string.Empty);
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
                htmlTextWriter_0.AddAttribute("language", "javascript");
            }
            else if (str != null)
            {
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Onclick, str);
            }
            if (AccessKey.Length > 0)
            {
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Accesskey, AccessKey);
            }
            if (TabIndex != 0)
            {
                htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Tabindex,
                                              TabIndex.ToString(NumberFormatInfo.InvariantInfo));
            }
            htmlTextWriter_0.RenderBeginTag(HtmlTextWriterTag.Input);
            htmlTextWriter_0.RenderEndTag();
        }

        protected override void Render(HtmlTextWriter output)
        {
            method_0(output);
        }
    }
}