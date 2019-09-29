using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;

namespace ShopNum1.Control
{
    [ToolboxData("<{0}:SpanTimer runat=server></{0}:SpanTimer>")]
    public class SpanTimer : System.Web.UI.Control, IPostBackDataHandler
    {
        [Localizable(true), DefaultValue(""), Bindable(true), Category("Appearance")]
        public string EndTime
        {
            get
            {
                if (ViewState["EndTime"] == null)
                {
                    return "";
                }
                return (string) ViewState["EndTime"];
            }
            set { ViewState["EndTime"] = value; }
        }

        public bool LoadPostData(string postDataKey, NameValueCollection values)
        {
            EndTime = "4/29/2009";
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        protected override void OnPreRender(EventArgs eventArgs_0)
        {
            base.OnPreRender(eventArgs_0);
        }

        protected override void Render(HtmlTextWriter output)
        {
            string str = "\n";
            str = (((((((((((str + "<span style=\"color:#FF0000\" id=\"djs\"> </span>\n") +
                            "<script type=\"text/javascript\">\n" + "    function show_date_time()") + "    {\n" +
                           "        window.setTimeout(\"show_date_time()\", 1000);\n") +
                          "        BirthDay = new Date(\"" + EndTime + "\");\n") + "         today = new Date();\n" +
                         "         timeold = (BirthDay.getTime() - today.getTime());\n") +
                        "        sectimeold = timeold/1000;\n" + "        secondsold = Math.floor(sectimeold); \n") +
                       "        msPerDay = 24*60*60*1000; \n" + "        e_daysold = timeold/msPerDay;\n") +
                      "        daysold = Math.floor(e_daysold);  \n" + "        e_hrsold = (e_daysold-daysold)*24;  \n") +
                     "        hrsold = Math.floor(e_hrsold); \n" + "        e_minsold = (e_hrsold-hrsold)*60; \n") +
                    "        minsold = Math.floor((e_hrsold-hrsold)*60); \n" +
                    "        seconds = Math.floor((e_minsold-minsold)*60);  \n") +
                   "        document.getElementById(\"djs\").innerHTML = daysold+\"天\"+hrsold+\"小时\"+minsold+\"分钟\"+seconds+\"秒\";  \n" +
                   "    }\n") + "   show_date_time();" + "</script>\n";
            output.Write(str);
        }
    }
}