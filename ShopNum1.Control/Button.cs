using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace ShopNum1.Control
{
    [DefaultProperty("Text"), DefaultEvent("Click"), ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : WebControl, IPostBackEventHandler
    {
        public enum ButtonType
        {
            Normal,
            WithImage
        }

        protected static readonly object EventClick = new object();

        private bool bool_0 = true;
        private bool bool_1 = true;
        private string string_3 = "";

        static Button()
        {
            EventClick = new object();
        }

        public Button()
        {
            ButtontypeMode = ButtonType.WithImage;
        }

        public bool AutoPostBack
        {
            get { return bool_0; }
            set { bool_0 = value; }
        }

        [Description("图版按钮链接"), DefaultValue("../images/submit.gif")]
        public string ButtonImgUrl
        {
            get
            {
                object obj2 = ViewState["ButtonImgUrl"];
                return ((obj2 == null) ? "../images/submit.gif" : ((string) obj2));
            }
            set { ViewState["ButtonImgUrl"] = value; }
        }

        public ButtonType ButtontypeMode
        {
            get
            {
                object obj2 = ViewState["ButtontypeMode"];
                return ((obj2 == null) ? ButtonType.WithImage : ((ButtonType) obj2));
            }
            set { ViewState["ButtontypeMode"] = value; }
        }

        public string OnClientClick
        {
            get { return string_3; }
            set { string_3 = value.EndsWith(";") ? value : (value + ";"); }
        }

        public virtual string PostBackUrl
        {
            get
            {
                var str = (string) ViewState["PostBackUrl"];
                if (str != null)
                {
                    return str;
                }
                return string.Empty;
            }
            set { ViewState["PostBackUrl"] = value; }
        }

        [DefaultValue("../images/"), Description("图版按钮链接")]
        public string ScriptContent
        {
            get
            {
                object obj2 = ViewState["ScriptContent"];
                return ((obj2 == null) ? "" : ((string) obj2));
            }
            set { ViewState["ScriptContent"] = value; }
        }

        public bool ShowPostDiv
        {
            get { return bool_1; }
            set { bool_1 = value; }
        }

        [Bindable(true), DefaultValue(" 提 交 "), Category("Appearance")]
        public string Text
        {
            get
            {
                object obj2 = ViewState["ButtonText"];
                return ((obj2 == null) ? " 提 交 " : ((string) obj2));
            }
            set { ViewState["ButtonText"] = value; }
        }

        public bool ValidateForm { get; set; }

        [Description("图版按钮链接"), DefaultValue("../images/")]
        public string XpBGImgFilePath
        {
            get
            {
                object obj2 = ViewState["XpBGImgFilePath"];
                return ((obj2 == null) ? "../images/" : ((string) obj2));
            }
            set { ViewState["XpBGImgFilePath"] = value; }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            RaisePostBackEvent(eventArgument);
        }

        public event EventHandler Click
        {
            add { base.Events.AddHandler(EventClick, value); }
            remove { base.Events.RemoveHandler(EventClick, value); }
        }

        protected override void AddParsedSubObject(object object_0)
        {
            if (HasControls())
            {
                base.AddParsedSubObject(object_0);
            }
            else if (object_0 is LiteralControl)
            {
                Text = ((LiteralControl) object_0).Text;
            }
            else
            {
                string text = Text;
                if (text.Length != 0)
                {
                    Text = string.Empty;
                    base.AddParsedSubObject(new LiteralControl(text));
                }
                base.AddParsedSubObject(object_0);
            }
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                base.LoadViewState(savedState);
                var str = (string) ViewState["Text"];
                if (str != null)
                {
                    Text = str;
                }
            }
        }

        protected virtual void OnClick(EventArgs eventArgs_0)
        {
            var handler = (EventHandler) base.Events[EventClick];
            if (handler != null)
            {
                handler(this, eventArgs_0);
            }
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            base.OnPreRender(eventArgs_0);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(new EventArgs());
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
            string str = "";
            if (!Enabled)
            {
                str = " disabled=\"true\"";
            }
            if (AutoPostBack)
            {
                var builder = new StringBuilder();
                if (!string.IsNullOrEmpty(OnClientClick))
                {
                    builder.Append(OnClientClick);
                }
                builder.Append(
                    "if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }}");
                builder.Append("this.disabled=true;");
                if (ValidateForm)
                {
                    builder.Append("if(validate(this.form)){");
                    if (ShowPostDiv)
                    {
                        builder.Append(
                            "document.getElementById('success').style.display = 'block';HideOverSels('success');");
                    }
                    builder.Append(Page.ClientScript.GetPostBackEventReference(this, "") +
                                   ";}else{this.disabled=false;}");
                }
                else
                {
                    builder.Append(Page.ClientScript.GetPostBackEventReference(this, "") + ";");
                }
                if (ScriptContent != "")
                {
                    builder.Append(ScriptContent);
                }
                if (ButtontypeMode == ButtonType.Normal)
                {
                    output.Write("<span><button type=\"button\" class=\"ManagerButton\" id=\"" + UniqueID + "\"" + str +
                                 " onclick=\"" + builder + "\">" + Text + "</button></span>");
                }
                if (ButtontypeMode == ButtonType.WithImage)
                {
                    output.Write("<span><button type=\"button\" class=\"ManagerButton\" id=\"" + UniqueID + "\"" + str +
                                 " onclick=\"" + builder + "\"><img src=\"" + ButtonImgUrl + "\"/>" + Text +
                                 "</button></span>");
                }
            }
            else
            {
                if (ButtontypeMode == ButtonType.Normal)
                {
                    output.Write("<span><button type=\"button\" class=\"ManagerButton\" id=\"" + UniqueID + "\"" + str +
                                 " onclick=\"" + OnClientClick + ScriptContent + "\">" + Text + "</button></span>");
                }
                if (ButtontypeMode == ButtonType.WithImage)
                {
                    output.Write("<span><button type=\"button\" class=\"ManagerButton\" id=\"" + UniqueID + "\"" + str +
                                 " onclick=\"" + OnClientClick + ScriptContent + "\"><img src=\"" + ButtonImgUrl +
                                 "\"/>" + Text + "</button></span>");
                }
            }
            if (base.HintInfo != "")
            {
                output.WriteEndTag("span");
            }
        }
    }
}