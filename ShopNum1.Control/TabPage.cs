using System;
using System.ComponentModel;
using System.Web.UI;

namespace ShopNum1.Control
{
    [ToolboxItem(false), ParseChildren(false), PersistChildren(true)]
    public class TabPage : WebControl, INamingContainer
    {
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private TabControl tabControl_0;

        [Browsable(true), NotifyParentProperty(true), Description("")]
        private string ActionLink
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        [NotifyParentProperty(true), Description(""), Browsable(true)]
        public string Caption
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        internal bool Selected { get; set; }

        public object GetTabControl()
        {
            return tabControl_0;
        }

        internal void method_0(HtmlTextWriter htmlTextWriter_0)
        {
            Render(htmlTextWriter_0);
        }

        internal void method_1(TabControl tabControl_1)
        {
            tabControl_0 = tabControl_1;
        }

        protected override void Render(HtmlTextWriter pOutPut)
        {
            if ((tabControl_0 == null) || (tabControl_0.GetType().ToString() != "Discuz.Control.TabControl"))
            {
                throw new ArgumentException("ShopNum1.TabPage 必须是 ShopNum1.TabControl 的子控件");
            }
            if (Selected)
            {
                pOutPut.Write(
                    string.Concat(new object[]
                        {"<div id=\"", UniqueID, "\" class=\"tab-page\" style=\"display: block;background: #fff;\">"}));
            }
            else
            {
                pOutPut.Write(
                    string.Concat(new object[]
                        {"<div id=\"", UniqueID, "\" class=\"tab-page\" style=\"display: none;background: #fff;\">"}));
            }
            RenderChildren(pOutPut);
            pOutPut.Write("</div>");
        }
    }
}