using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;

namespace ShopNum1.Control
{
    [ToolboxData("<{0}:TextBox runat=server></{0}:TextBox>"), DefaultProperty("Text"),
     Designer(
         "System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
         )]
    public class TextBox : System.Web.UI.WebControls.TextBox, IWebControl
    {
        protected RequiredFieldValidator CanBeNullRFV = new RequiredFieldValidator();
        protected RangeValidator NumberRV = new RangeValidator();
        protected RegularExpressionValidator RequiredFieldTypeREV = new RegularExpressionValidator();
        private int int_0 = 30;
        private int int_3 = 50;
        protected Label lablShow = new Label();
        private string string_2 = "";
        private string string_3 = "";
        private string string_4 = "up";

        [DefaultValue("可为空"), Bindable(false), Category("Behavior"), Description("要滚动的对象。"),
         TypeConverter(typeof(CanBeNullControlsConverter))]
        public string CanBeNull
        {
            get
            {
                object obj2 = ViewState["CanBeNull"];
                return ((obj2 == null) ? "" : obj2.ToString());
            }
            set { ViewState["CanBeNull"] = value; }
        }

        [Category("Appearance"), DefaultValue(30), Bindable(true)]
        public int Cols
        {
            get { return base.Columns; }
            set { base.Columns = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("up")]
        public string HintShowType
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public bool IsReplaceInvertedComma
        {
            get
            {
                object obj2 = ViewState["IsReplaceInvertedComma"];
                return (((obj2 == null) || (obj2.ToString().Trim() == "")) || (obj2.ToString().ToLower() == "true"));
            }
            set { ViewState["IsReplaceInvertedComma"] = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue((string)null)]
        public string MaximumValue { get; set; }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public override int MaxLength
        {
            get
            {
                object obj2 = ViewState["TextBox_MaxLength"];
                if (obj2 != null)
                {
                    int num = Utils.StrToInt(obj2.ToString(), 4);
                    AddAttributes("maxlength", num.ToString());
                    return num;
                }
                return -1;
            }
            set
            {
                ViewState["TextBox_MaxLength"] = value;
                AddAttributes("maxlength", value.ToString());
            }
        }

        [Category("Appearance"), Bindable(true), DefaultValue((string)null)]
        public string MinimumValue { get; set; }

        [TypeConverter(typeof(RequiredFieldTypeControlsConverter)), Bindable(false), Description("要滚动的对象。"),
         DefaultValue(""), Category("Behavior")]
        public string RequiredFieldType
        {
            get
            {
                object obj2 = ViewState["RequiredFieldType"];
                return ((obj2 == null) ? "" : obj2.ToString());
            }
            set { ViewState["RequiredFieldType"] = value; }
        }

        [Category("Appearance"), DefaultValue(""), Bindable(true)]
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
                    base.Attributes.Add("onkeydown",
                                        "if(event.keyCode==13){document.getElementById('" + value + "').focus();}");
                }
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(30)]
        public int Size
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        [Category("Appearance"), Bindable(true), DefaultValue("")]
        public override string Text
        {
            get
            {
                if (RequiredFieldType == "日期")
                {
                    try
                    {
                        return DateTime.Parse(base.Text).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        return "";
                    }
                }
                if (RequiredFieldType == "日期时间")
                {
                    try
                    {
                        return DateTime.Parse(base.Text).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch
                    {
                        return "";
                    }
                }
                return (IsReplaceInvertedComma ? base.Text.Replace("'", "''").Trim() : base.Text);
            }
            set
            {
                if (RequiredFieldType.IndexOf("日期") >= 0)
                {
                    try
                    {
                        base.Text = DateTime.Parse(value).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        base.Text = "";
                    }
                }
                if (RequiredFieldType.IndexOf("日期时间") >= 0)
                {
                    try
                    {
                        base.Text = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm:ss");
                        return;
                    }
                    catch
                    {
                        base.Text = "";
                        return;
                    }
                }
                base.Text = value;
            }
        }

        [Description("要滚动的对象。"), Category("Behavior"), Bindable(false), DefaultValue(0)]
        public override TextBoxMode TextMode
        {
            get { return base.TextMode; }
            set
            {
                if (value == TextBoxMode.MultiLine)
                {
                    base.Attributes.Add("onkeyup", "return isMaxLen(this)");
                }
                base.TextMode = value;
            }
        }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string ValidationExpression
        {
            get
            {
                object obj2 = ViewState["ValidationExpression"];
                if ((obj2 == null) || (obj2.ToString().Trim() == ""))
                {
                    return null;
                }
                return obj2.ToString().ToLower();
            }
            set { ViewState["ValidationExpression"] = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public override string ValidationGroup
        {
            get
            {
                object obj2 = ViewState["ValidationGroup"];
                if (obj2 != null)
                {
                    AddAttributes("ValidationGroup", obj2.ToString());
                    return obj2.ToString();
                }
                return "";
            }
            set
            {
                ViewState["ValidationGroup"] = value;
                AddAttributes("ValidationGroup", ValidationGroup);
            }
        }

        [DefaultValue(130), Bindable(true), Category("Appearance")]
        public int HintHeight
        {
            get { return int_3; }
            set { int_3 = value; }
        }

        [Bindable(true), DefaultValue(""), Category("Appearance")]
        public string HintInfo
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        [Bindable(true), DefaultValue(0), Category("Appearance")]
        public int HintLeftOffSet { get; set; }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string HintTitle
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [Bindable(true), DefaultValue(0), Category("Appearance")]
        public int HintTopOffSet { get; set; }

        public void AddAttributes(string string_5, string valuestr)
        {
            base.Attributes.Add(string_5, valuestr);
        }

        protected override void CreateChildControls()
        {
            string text;
            if (this.RequiredFieldType != null && this.RequiredFieldType != "" && this.RequiredFieldType != "暂无校验")
            {
                if (this.ValidationGroup != "")
                {
                    this.RequiredFieldTypeREV.ValidationGroup = this.ValidationGroup;
                }
                this.RequiredFieldTypeREV.Display = ValidatorDisplay.Dynamic;
                this.RequiredFieldTypeREV.ControlToValidate = this.ID;
                text = this.RequiredFieldType;
                switch (text)
                {
                    case "数据校验":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^[-]?\\d+[.]?\\d*$");
                        this.RequiredFieldTypeREV.ErrorMessage = "数字的格式不正确";
                        break;
                    case "整数验证":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^\\d{1,9}$");
                        this.RequiredFieldTypeREV.ErrorMessage = "格式不正确";
                        break;
                    case "电子邮箱":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
                        this.RequiredFieldTypeREV.ErrorMessage = "邮箱的格式不正确";
                        break;
                    case "邮政编码":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^[0-9 ]{3,12}$");
                        this.RequiredFieldTypeREV.ErrorMessage = "邮政编码格式不正确";
                        break;
                    case "移动手机":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(1[3|5|7|8][0-9])\\d{8}$");
                        this.RequiredFieldTypeREV.ErrorMessage = "手机格式不对!";
                        break;
                    case "家用电话":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{8}|((\\(\\d{3}\\) ?)|(\\d{4}-))?\\d{4}-\\d{7}");
                        this.RequiredFieldTypeREV.ErrorMessage = "电话号码格式为XXX-XXXXXXXX或XXXX-XXXXXXX！";
                        break;
                    case "身份证号码":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^\\d{15}$|^\\d{17}[\\d|X]$");
                        this.RequiredFieldTypeREV.ErrorMessage = "身份证号位15或18位!";
                        break;
                    case "网页地址":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(http|https)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\\\+&%\\$#\\=~_\\-]+))*$");
                        this.RequiredFieldTypeREV.ErrorMessage = "格式为https://xxx.xx或http://xxxx.xx";
                        break;
                    case "日期":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-9]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
                        this.RequiredFieldTypeREV.ErrorMessage = "日期格式为2006-1-1";
                        break;
                    case "日期时间":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-9]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\\d):[0-5]?\\d:[0-5]?\\d$");
                        this.RequiredFieldTypeREV.ErrorMessage = "时间格式为2006-1-1 23:59:59";
                        break;
                    case "金额":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(([0-9]{1,9})|([0-9]{1,9}\\.[0-9]{0,2}))$");
                        this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的金额";
                        break;
                    case "IP地址":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
                        this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的IP地址";
                        break;
                    case "IP地址带端口":
                        this.RequiredFieldTypeREV.ValidationExpression = ((this.ValidationExpression != null) ? this.ValidationExpression : "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]):\\d{1,5}?$");
                        this.RequiredFieldTypeREV.ErrorMessage = "请输入正确的带端口的IP地址";
                        break;
                }
                this.Controls.AddAt(0, this.RequiredFieldTypeREV);
                if (this.MaximumValue != null || this.MinimumValue != null)
                {
                    this.NumberRV.ControlToValidate = this.ID;
                    this.NumberRV.Type = ValidationDataType.Double;
                    this.NumberRV.Display = ValidatorDisplay.Dynamic;
                    if (this.MaximumValue != null && this.MinimumValue != null)
                    {
                        this.NumberRV.MaximumValue = this.MaximumValue;
                        this.NumberRV.MinimumValue = this.MinimumValue;
                        this.NumberRV.ErrorMessage = string.Concat(new string[]
						{
							"输入数据应在",
							this.MinimumValue,
							"和",
							this.MaximumValue,
							"之间!"
						});
                    }
                    else
                    {
                        if (this.MaximumValue != null)
                        {
                            this.NumberRV.MaximumValue = this.MaximumValue;
                            RangeValidator arg_53A_0 = this.NumberRV;
                            int num = -2147483648;
                            arg_53A_0.MinimumValue = num.ToString();
                            this.NumberRV.ErrorMessage = "输入允许最大值为" + this.MaximumValue;
                        }
                        if (this.MinimumValue != null)
                        {
                            this.NumberRV.MinimumValue = this.MinimumValue;
                            RangeValidator arg_589_0 = this.NumberRV;
                            int num = 2147483647;
                            arg_589_0.MaximumValue = num.ToString();
                            this.NumberRV.ErrorMessage = "输入允许最小值为" + this.MinimumValue;
                        }
                    }
                    this.Controls.AddAt(0, this.NumberRV);
                }
            }
            text = this.CanBeNull;
            if (text != null && !(text == "可为空") && text == "必填")
            {
                this.lablShow.Style.Add(HtmlTextWriterStyle.Color, "red");
                this.lablShow.Text = "*";
                this.CanBeNullRFV.Display = ValidatorDisplay.Dynamic;
                this.CanBeNullRFV.ControlToValidate = this.ID;
                this.CanBeNullRFV.ErrorMessage = "不能为空!";
                this.Controls.AddAt(0, this.lablShow);
                this.Controls.AddAt(1, this.CanBeNullRFV);
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (TextMode == TextBoxMode.MultiLine)
            {
                output.WriteLine("<script type=\"text/javascript\">");
                output.WriteLine("function isMaxLen(o){");
                output.WriteLine("var nMaxLen=o.getAttribute? parseInt(o.getAttribute(\"maxlength\")):\"\";");
                output.WriteLine(" if(o.getAttribute && o.value.length>nMaxLen){");
                output.WriteLine(" o.value=o.value.substring(0,nMaxLen)");
                output.WriteLine("}}</script>");
                AddAttributes("rows", Rows.ToString());
                AddAttributes("cols", Cols.ToString());
                base.Attributes.Add("onfocus", "this.className='FormFocus';");
                base.Attributes.Add("onblur", "this.className='FormBase';");
                base.Attributes.Add("class", "FormBase");
            }
            else if (TextMode == TextBoxMode.Password)
            {
                AddAttributes("value", Text);
            }
            if (HintInfo != "")
            {
                AddAttributes("onmouseover",
                              string.Concat(new object[]
                                  {
                                      "showhintinfo(this,", HintLeftOffSet, ",", HintTopOffSet, ",'", HintTitle, "','",
                                      HintInfo, "','", HintHeight, "','", HintShowType, "')"
                                  }));
                AddAttributes("onmouseout", "hidehintinfo()");
            }
            base.Render(output);
            RenderChildren(output);
        }
    }
}