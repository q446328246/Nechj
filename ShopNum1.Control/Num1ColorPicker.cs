using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;

namespace ShopNum1.Control
{
    [ToolboxData("<{0}:Num1ColorPicker runat=server></{0}:Num1ColorPicker>")]
    public class Num1ColorPicker : System.Web.UI.Control, IPostBackDataHandler
    {
        [DefaultValue(""), Category("Appearance"), Localizable(true), Bindable(true)]
        public string SelectedHexValue
        {
            get
            {
                if (ViewState["SelectedValue"] == null)
                {
                    return "";
                }
                return (string) ViewState["SelectedValue"];
            }
            set { ViewState["SelectedValue"] = value; }
        }

        public bool LoadPostData(string postDataKey, NameValueCollection values)
        {
            SelectedHexValue = values[UniqueID];
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            base.OnPreRender(eventArgs_0);
            string script = "\n";
            script = ((((((((((script + "<script type=\"text/javascript\">\n" + "    var ActiveColorPicker;\n") +
                              "    function OpenColorPicker(id)\n" + "    {\n") + "        ActiveColorPicker=id; \n" +
                             "        var colorpickerdiv=document.getElementById('colorpicker');\n") +
                            "        colorpickerdiv.style.visibility='visible';\n" +
                            "        colorpickerdiv.style.left=ActiveColorPicker.style.left+ActiveColorPicker.style.width;\n") +
                           "        colorpickerdiv.style.top=window.event.y;\n" +
                           "        colorpickerdiv.style.left=window.event.x;\n") + "    }\n" +
                          "    function ColorPickerOnColorClick(e)\n") + "    {\n" +
                         "        var td = (e.target) ? e.target : e.srcElement; \n") +
                        "        var color=td.style.backgroundColor; \n" +
                        "        ActiveColorPicker.style.backgroundColor=color;\n") +
                       "        ActiveColorPicker.style.color=color;\n" + "        ActiveColorPicker.value=color;\n") +
                      "        var colorpickerdiv=document.getElementById('colorpicker');\n" +
                      "        colorpickerdiv.style.visibility='hidden';\n") + "    }\n" + "</script>\n";
            if (!Page.ClientScript.IsClientScriptBlockRegistered("opendialogscript"))
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "opendialogscript", script);
            }
            string str2 = "";
            str2 = (((str2 + "<style>\n") +
                     "     #colorpicker { visibility:hidden;border:1px solid #999;background-color:#eee;position:absolute; }\n" +
                     "     #colorpicker td { border-right:1px solid #eee; border-bottom:1px solid #eee; width:10px;height:10px;cursor:hand; }\n") +
                    "     .colorpickerbutton{width:25px;border:1px solid #999;cursor:hand;}\n" + "</style>\n") +
                   "<div id=\"colorpicker\">" +
                   "     <table cellpadding=\"0\" cellspacing=\"0\" onclick=\"javascript:ColorPickerOnColorClick(event);\">";
            var strArray = new[]
                {
                    "FFFFFF", "CCCCCC", "999999", "666666", "333333", "000000", "FFCC00", "FF9900", "FF6600", "FF3300",
                    "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF",
                    "99CC00", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "CC9900", "FFCC33", "FFCC66", "FF9966", "FF6633",
                    "CC3300", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "CC0033",
                    "CCFF00", "CCFF33", "333300", "666600", "999900", "CCCC00", "FFFF00", "CC9933", "CC6633", "330000",
                    "660000", "990000", "CC0000", "FF0000", "FF3366", "FF0033",
                    "99FF00", "CCFF66", "99CC33", "666633", "999933", "CCCC33", "FFFF33", "996600", "996600", "663333",
                    "993333", "CC3333", "FF3333", "CC3366", "FF6699", "FF0066",
                    "66FF00", "99FF66", "66CC33", "669900", "999966", "CCCC66", "FFFF66", "996633", "663300", "996666",
                    "CC6666", "FF6666", "990033", "CC3399", "FF66CC", "FF0099",
                    "33FF00", "66FF33", "339900", "66CC00", "99FF33", "CCCC99", "FFFF99", "CC9966", "CC6600", "CC9999",
                    "FF9999", "FF3399", "CC0066", "990066", "FF33CC", "FF00CC",
                    "00CC00", "33CC00", "336600", "669933", "99CC66", "CCFF99", "FFFFCC", "FFCC99", "FF9933", "FFCCCC",
                    "FF99CC", "CC6699", "993366", "660033", "CC0099", "330033",
                    "33CC33", "66CC66", "00FF00", "33FF33", "66FF66", "99FF99", "CCFFCC", "FFFFFF", "FFFFFF", "FFFFFF",
                    "CC99CC", "996699", "993399", "990099", "663366", "660066",
                    "006600", "336633", "009900", "339933", "669966", "99CC99", "FFFFFF", "FFFFFF", "FFFFFF", "FFCCFF",
                    "FF99FF", "FF66FF", "FF33FF", "FF00FF", "CC66CC", "CC33CC",
                    "003300", "00CC33", "006633", "339966", "66CC99", "99FFCC", "CCFFFF", "3399FF", "99CCFF", "CCCCFF",
                    "CC99FF", "9966CC", "663399", "330066", "9900CC", "CC00CC",
                    "00FF33", "33FF66", "009933", "00CC66", "33FF99", "99FFFF", "99CCCC", "0066CC", "6699CC", "9999FF",
                    "9999CC", "9933FF", "6600CC", "660099", "CC33FF", "CC00FF",
                    "00FF66", "66FF99", "33CC66", "009966", "66FFFF", "66CCCC", "669999", "003366", "336699", "6666FF",
                    "6666CC", "666699", "330099", "9933CC", "CC66FF", "9900FF",
                    "00FF99", "66FFCC", "33CC99", "33FFFF", "33CCCC", "339999", "336666", "006699", "003399", "3333FF",
                    "3333CC", "333399", "333366", "6633CC", "9966FF", "6600FF",
                    "00FFCC", "33FFCC", "00FFFF", "00CCCC", "009999", "006666", "003333", "3399CC", "3366CC", "0000FF",
                    "0000CC", "000099", "000066", "000033", "6633FF", "3300FF",
                    "00CC99", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "0099CC", "33CCFF", "66CCFF", "6699FF", "3366FF",
                    "0033CC", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "3300CC",
                    "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "00CCFF", "0099FF", "0066FF", "0033FF",
                    "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF"
                };
            int num2 = 0;
            bool flag = true;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (flag)
                {
                    flag = false;
                    str2 = str2 + "            <tr> ";
                }
                string str3 = "#" + strArray[i];
                str2 = str2 + "                <td style=\"background-color:" + str3 + "\"></td>";
                if (num2++ == 0x10)
                {
                    str2 = str2 + "            </tr>";
                    flag = true;
                    num2 = 0;
                }
            }
            str2 = str2 + "     </table>" + "</div>";
            if (!Page.ClientScript.IsClientScriptBlockRegistered("colorpickerdiv"))
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "colorpickerdiv", str2);
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            string str = "";
            string str2 = "onclick=\"javascript:OpenColorPicker(" + UniqueID + ");\"";
            string str3 = str;
            str = str3 + "<input style=\"background-color:" + SelectedHexValue + ";color:" + SelectedHexValue +
                  ";\" class=\"colorpickerbutton\" " + str2 +
                  " readonly=\"true\" class=\"lookupmodalvalue\" type=\"text\" name=\"" + UniqueID + "\" value=\"" +
                  SelectedHexValue + "\">";
            output.Write(str);
        }
    }
}