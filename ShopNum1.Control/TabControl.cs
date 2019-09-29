using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;

namespace ShopNum1.Control
{
    [DesignTimeVisible(true), ParseChildren(true, "Items"), Designer(typeof (TabControlDesigner)),
     ToolboxData("<{0}:TabControl runat=server></{0}:TabControl>"), DefaultEvent("SelectedIndexChanged"),
     Description("ShopNum1 WebControl TabControl"), PersistChildren(false)]
    public class TabControl : WebControl, IPostBackDataHandler, IPostBackEventHandler, INamingContainer
    {
        public enum HeightUnitEnum
        {
            percent,
            const_1
        }

        public enum SelectionModeEnum
        {
            Client,
            Server
        }

        public enum WidthUnitEnum
        {
            percent,
            const_1
        }

        private static readonly object object_0 = new object();
        private readonly HtmlInputHidden htmlInputHidden_0 = new HtmlInputHidden();
        private readonly TabPageCollection tabPageCollection_0;
        private int int_3 = -1;
        private Unit unit_0;
        private Unit unit_1;

        public TabControl()
        {
            htmlInputHidden_0.Value = string.Empty;
            unit_1 = Unit.Pixel(350);
            unit_0 = Unit.Pixel(150);
            tabPageCollection_0 = new TabPageCollection(this);
            SelectionMode = SelectionModeEnum.Client;
            Height = Unit.Pixel(100);
            Width = Unit.Pixel(100);
            HeightUnitMode = HeightUnitEnum.percent;
            WidthUnitMode = WidthUnitEnum.percent;
            LeftOffSetX = 0;
        }

        public HeightUnitEnum HeightUnitMode { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), MergableProperty(false),
         PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public TabPageCollection Items
        {
            get { return tabPageCollection_0; }
        }

        [Description("顶部属性页标题距左边偏移量"), DefaultValue(0)]
        public int LeftOffSetX
        {
            get
            {
                object obj2 = ViewState["LeftOffSetX"];
                return ((obj2 == null) ? 0 : Utils.StrToInt(obj2.ToString(), 0));
            }
            set { ViewState["LeftOffSetX"] = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                int num;
                if (Items.Count <= 0)
                {
                    int_3 = num = -1;
                    return -1;
                }
                if (int_3 == -1)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Visible && (Items[i].UniqueID == SelectedTabPageID))
                        {
                            return (int_3 = i);
                        }
                    }
                    int_3 = num = 0;
                    return 0;
                }
                if (int_3 >= Items.Count)
                {
                    int_3 = num = 0;
                    return 0;
                }
                return int_3;
            }
            set
            {
                if ((value < -1) || (value >= Items.Count))
                {
                    throw new ArgumentOutOfRangeException("选项页必须小于" + Items.Count.ToString());
                }
                int_3 = value;
            }
        }

        protected string SelectedTabPageID
        {
            get
            {
                if (ViewState["SelectedTabPageID"] != null)
                {
                    return (string) ViewState["SelectedTabPageID"];
                }
                return string.Empty;
            }
            set { ViewState["SelectedTabPageID"] = value; }
        }

        public SelectionModeEnum SelectionMode { get; set; }

        [Description("css文件所在目录。"), DefaultValue("./")]
        public string TabCssPath
        {
            get
            {
                object obj2 = ViewState["TabCssPath"];
                return ((obj2 == null) ? "../styles/tab.css" : ((string) obj2));
            }
            set { ViewState["TabCssPath"] = value; }
        }

        [DefaultValue("./"), Description("Javascript脚本文件所在目录。")]
        public string TabScriptPath
        {
            get
            {
                object obj2 = ViewState["TabScriptPath"];
                return ((obj2 == null) ? "../js/tabstrip.js" : ((string) obj2));
            }
            set { ViewState["TabScriptPath"] = value; }
        }

        public WidthUnitEnum WidthUnitMode { get; set; }

        bool IPostBackDataHandler.LoadPostData(string ControlDataKey, NameValueCollection PostBackDataCollection)
        {
            string str = PostBackDataCollection[ControlDataKey];
            if ((str != null) && (str != SelectedTabPageID))
            {
                SelectedTabPageID = str;
                return true;
            }
            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            OnTabSelectedIndexChanged(EventArgs.Empty);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string pEventArgument)
        {
        }

        public event EventHandler TabSelectedIndexChanged
        {
            add { base.Events.AddHandler(object_0, value); }
            remove { base.Events.RemoveHandler(object_0, value); }
        }

        protected override void AddParsedSubObject(object parsedObj)
        {
            if (parsedObj is TabPage)
            {
                Items.Add((TabPage) parsedObj);
            }
        }

        protected override void CreateChildControls()
        {
            CreateControlCollection();
            htmlInputHidden_0.ID = UniqueID;
            for (int i = 0; i < Items.Count; i++)
            {
                Controls.Add(Items[i]);
            }
            base.ChildControlsCreated = true;
            base.CreateChildControls();
        }

        public void InitTabPage()
        {
            CreateChildControls();
        }

        internal void method_0(HtmlTextWriter htmlTextWriter_0)
        {
            Render(htmlTextWriter_0);
        }

        private void method_1(HtmlTextWriter htmlTextWriter_0)
        {
            int num;
            if (SelectionMode == SelectionModeEnum.Server)
            {
                for (num = 0; num < Items.Count; num++)
                {
                    if (Items[num].Selected)
                    {
                        htmlTextWriter_0.Write(
                            "<li class=\"CurrentTabSelect\" ><a href=\"#\" class=\"current\" onfocus=\"this.blur();\">" +
                            Items[num].Caption + "</a></li>");
                    }
                    else
                    {
                        htmlTextWriter_0.Write(
                            "<li class=\"TabSelect\" onmouseover=\"tabpage_mouseover(this)\" onmouseout=\"tabpage_mouseout(this)\" onClick=\"tabpage_selectonserver(this,'" +
                            Items[num].UniqueID + "');" + Page.ClientScript.GetPostBackEventReference(this, "") +
                            "\"><a href=\"#\" onfocus=\"this.blur();\">" + Items[num].Caption + "</a></li>");
                    }
                }
            }
            else
            {
                for (num = 0; num < Items.Count; num++)
                {
                    if (Items[num].Selected)
                    {
                        htmlTextWriter_0.Write("<li id=\"" + Items[num].UniqueID +
                                               "_li\" class=\"CurrentTabSelect\" onclick=\"tabpage_selectonclient(this,'" +
                                               Items[num].UniqueID +
                                               "');\"><a href=\"#\" class=\"current\" onfocus=\"this.blur();\">" +
                                               Items[num].Caption + "</a></li>");
                    }
                    else
                    {
                        htmlTextWriter_0.Write("<li id=\"" + Items[num].UniqueID +
                                               "_li\" class=\"TabSelect\" onmouseover=\"tabpage_mouseover(this)\" onMouseOut=\"tabpage_mouseout(this)\" onclick=\"tabpage_selectonclient(this,'" +
                                               Items[num].UniqueID + "');\"><a href=\"#\" onfocus=\"this.blur();\">" +
                                               Items[num].Caption + "</a></li>");
                    }
                }
            }
        }

        private void method_2(HtmlTextWriter htmlTextWriter_0)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].RenderControl(htmlTextWriter_0);
            }
        }

        protected override void OnPreRender(EventArgs args)
        {
            base.OnPreRender(args);
            int selectedIndex = SelectedIndex;
            if (selectedIndex != -1)
            {
                Items[selectedIndex].Selected = true;
                htmlInputHidden_0.Value = Items[selectedIndex].UniqueID;
            }
            else
            {
                htmlInputHidden_0.Value = string.Empty;
            }
            string script =
                string.Format(
                    "<SCRIPT language=\"javascript\" src=\"{0}\"></SCRIPT>\r\n<LINK href=\"{1}\" type=\"text/css\" rel=\"stylesheet\">\r\n",
                    TabScriptPath, TabCssPath);
            if (!Page.ClientScript.IsClientScriptBlockRegistered("TabWindow"))
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "TabWindow", script);
            }
            base.OnPreRender(args);
        }

        protected void OnTabSelectedIndexChanged(EventArgs eventArgs_0)
        {
            if (base.Events != null)
            {
                var handler = (EventHandler) base.Events[object_0];
                if (handler != null)
                {
                    handler(this, eventArgs_0);
                }
            }
        }

        protected override void Render(HtmlTextWriter pOutPut)
        {
            if (LeftOffSetX > 0)
            {
                pOutPut.Write(
                    string.Concat(new object[]
                        {"<div Class=\"tabs\" ID=\"", UniqueID, "_Tab\" style=\"padding-left:", LeftOffSetX, ";\">"}));
            }
            else
            {
                pOutPut.Write("<div Class=\"tabs\" ID=\"" + UniqueID + "_Tab\" >");
            }
            htmlInputHidden_0.RenderControl(pOutPut);
            pOutPut.Write("<ul>");
            method_1(pOutPut);
            pOutPut.Write("</ul></div><div id=\"" + UniqueID + "tabarea\" class=\"tabarea\">");
            method_2(pOutPut);
            pOutPut.Write("</div>");
        }
    }
}