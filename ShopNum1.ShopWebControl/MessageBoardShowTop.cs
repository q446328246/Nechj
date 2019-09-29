using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class MessageBoardShowTop : BaseWebControl
    {
        private HtmlGenericControl htmlGenericControl_0;
        private HtmlGenericControl htmlGenericControl_1;
        private HtmlGenericControl htmlGenericControl_2;
        private HtmlGenericControl htmlGenericControl_3;
        private HtmlGenericControl htmlGenericControl_4;
        private HtmlGenericControl htmlGenericControl_5;
        private HyperLink hyperLink_0;
        private HyperLink hyperLink_1;
        private HyperLink hyperLink_2;
        private HyperLink hyperLink_3;
        //private int int_0;
        private Label label_0;
        private LinkButton linkButton_0;
        private LinkButton linkButton_1;
        private LinkButton linkButton_2;
        private LinkButton linkButton_3;
        private LinkButton linkButton_4;
        private LinkButton linkButton_5;
        private LinkButton linkButton_6;
        private Literal literal_0;
        private Repeater repeater_0;
        private string string_0 = "MessageBoardShowTop.ascx";
        private string string_1 = "-1";

        //private string string_2;

        public MessageBoardShowTop()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_0;
            }
        }

        public int PageCount { get; set; }
        public string MemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var shop_ShopInfo_Action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid);
            repeater_0 = (Repeater) skin.FindControl("RepeaterBoardList");
            linkButton_0 = (LinkButton) skin.FindControl("LinkButton0");
            linkButton_1 = (LinkButton) skin.FindControl("LinkButton1");
            linkButton_2 = (LinkButton) skin.FindControl("LinkButton2");
            linkButton_3 = (LinkButton) skin.FindControl("LinkButton3");
            linkButton_4 = (LinkButton) skin.FindControl("LinkButton4");
            linkButton_5 = (LinkButton) skin.FindControl("LinkButton5");
            linkButton_6 = (LinkButton) skin.FindControl("LinkButtonAll");
            hyperLink_0 = (HyperLink) skin.FindControl("lnkPrev");
            hyperLink_1 = (HyperLink) skin.FindControl("lnkFirst");
            hyperLink_2 = (HyperLink) skin.FindControl("lnkNext");
            hyperLink_3 = (HyperLink) skin.FindControl("lnkLast");
            label_0 = (Label) skin.FindControl("LabelPageMessage");
            literal_0 = (Literal) skin.FindControl("lnkTo");
            linkButton_0.Click += linkButton_5_Click;
            linkButton_1.Click += linkButton_5_Click;
            linkButton_2.Click += linkButton_5_Click;
            linkButton_3.Click += linkButton_5_Click;
            linkButton_4.Click += linkButton_5_Click;
            linkButton_5.Click += linkButton_5_Click;
            linkButton_6.Click += linkButton_6_Click;
            htmlGenericControl_0 = (HtmlGenericControl) skin.FindControl("div1");
            htmlGenericControl_1 = (HtmlGenericControl) skin.FindControl("div2");
            htmlGenericControl_2 = (HtmlGenericControl) skin.FindControl("div3");
            htmlGenericControl_3 = (HtmlGenericControl) skin.FindControl("div4");
            htmlGenericControl_4 = (HtmlGenericControl) skin.FindControl("div5");
            htmlGenericControl_5 = (HtmlGenericControl) skin.FindControl("div6");
            if (!Page.IsPostBack)
            {
            }
            method_0();
        }

        protected void linkButton_6_Click(object sender, EventArgs e)
        {
            string_1 = "-1";
            method_0();
        }

        protected void linkButton_5_Click(object sender, EventArgs e)
        {
            string_1 = ((LinkButton) sender).ID.Replace("LinkButton", "");
            method_0();
        }

        protected void method_0()
        {
            var shop_MessageBoard_Action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            DataTable dataTable = shop_MessageBoard_Action.SearchMessageBoardList(MemLoginID, "1", "-1", string_1);
            htmlGenericControl_0.Style.Value = "";
            htmlGenericControl_1.Style.Value = "";
            htmlGenericControl_2.Style.Value = "";
            htmlGenericControl_3.Style.Value = "";
            htmlGenericControl_4.Style.Value = "";
            htmlGenericControl_5.Style.Value = "";
            string text = string_1;
            switch (text)
            {
                case "0":
                    htmlGenericControl_0.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
                case "1":
                    htmlGenericControl_1.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
                case "2":
                    htmlGenericControl_2.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
                case "3":
                    htmlGenericControl_3.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
                case "4":
                    htmlGenericControl_4.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
                case "6":
                    htmlGenericControl_5.Style["background"] =
                        "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
                    break;
            }
            var pagedDataSource = new PagedDataSource();
            pagedDataSource.DataSource = dataTable.DefaultView;
            pagedDataSource.AllowPaging = true;
            pagedDataSource.PageSize = PageCount;
            int num2;
            if (Page.Request.QueryString.Get("page") != null)
            {
                num2 = Convert.ToInt32(Page.Request.QueryString.Get("page"));
            }
            else
            {
                num2 = 1;
            }
            pagedDataSource.CurrentPageIndex = num2 - 1;
            repeater_0.DataSource = pagedDataSource;
            repeater_0.DataBind();
            var num1WebControlCommon = new Num1WebControlCommon();
            label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount,
                pagedDataSource.PageCount, pagedDataSource.PageSize, num2);
            literal_0.Text = num1WebControlCommon.AppendPage(Page, pagedDataSource.PageCount, num2);
            hyperLink_0.NavigateUrl = GetPageName.GetPage("?Page=" + Convert.ToInt32(num2 - 1) + "&guid=");
            hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1");
            hyperLink_2.NavigateUrl = GetPageName.GetPage("?Page=" + Convert.ToInt32(num2 + 1));
            hyperLink_3.NavigateUrl = GetPageName.GetPage("?Page=" + pagedDataSource.PageCount);
            if (num2 <= 1 && pagedDataSource.PageCount <= 1)
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            if (num2 <= 1 && pagedDataSource.PageCount > 1)
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
            }
            if (num2 >= pagedDataSource.PageCount)
            {
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
        }

        public static string GetValue(object object_0)
        {
            string text = object_0.ToString();
            string result;
            switch (text)
            {
                case "0":
                    result = "售后";
                    return result;
                case "1":
                    result = "询问";
                    return result;
                case "2":
                    result = "一般消息";
                    return result;
                case "3":
                    result = "求购";
                    return result;
                case "4":
                    result = "留言";
                    return result;
                case "5":
                    result = "重要消息";
                    return result;
            }
            result = "一般消息";
            return result;
        }
    }
}