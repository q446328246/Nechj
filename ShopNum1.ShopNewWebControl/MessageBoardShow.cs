using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class MessageBoardShow : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        public string AgentMemberID;
        private Button ButtonSure;

        private Label LabelPageCount;
        private LinkButton LinkButton0;
        private LinkButton LinkButton1;
        private LinkButton LinkButton2;
        private LinkButton LinkButton3;
        private LinkButton LinkButtonAll;
        private Repeater RepeaterBoardList;

        private TextBox TextBoxIndex;
        private HtmlGenericControl div0;
        private HtmlGenericControl div1;
        private HtmlGenericControl div2;
        private HtmlGenericControl div3;
        private HtmlGenericControl div4;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "MessageBoardShowNew.ascx";

        public MessageBoardShow()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string ordername { get; set; }

        public int PageCount { get; set; }

        public int ShowCount { get; set; }

        public string soft { get; set; }

        public string type { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername + "&pageid=" + str);
        }

        public static string GetValue(object object_0)
        {
            string str = object_0.ToString();
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "询问";

                case "1":
                    return "求购";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
                        {
                            return "其它";
                        }
                    }
                    else
                    {
                        return "售后";
                    }
                    break;
            }
            return "其它";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            ordername = (Page.Request.QueryString["ordername"] == null)
                ? "a.sendtime"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            type = (Page.Request.QueryString["type"] == null) ? "" : Page.Request.QueryString["type"];
            try
            {
                type = Convert.ToInt16(type).ToString();
            }
            catch
            {
                type = "";
            }
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterBoardList = (Repeater) skin.FindControl("RepeaterBoardList");
            LinkButtonAll = (LinkButton) skin.FindControl("LinkButtonAll");
            LinkButton0 = (LinkButton) skin.FindControl("LinkButton0");
            LinkButton1 = (LinkButton) skin.FindControl("LinkButton1");
            LinkButton2 = (LinkButton) skin.FindControl("LinkButton2");
            LinkButton3 = (LinkButton) skin.FindControl("LinkButton3");
            LinkButton0.Click += LinkButton0_Click;
            LinkButton1.Click += LinkButton1_Click;
            LinkButton2.Click += LinkButton2_Click;
            LinkButton3.Click += LinkButton3_Click;
            LinkButtonAll.Click += LinkButtonAll_Click;
            div1 = (HtmlGenericControl) skin.FindControl("div1");
            div2 = (HtmlGenericControl) skin.FindControl("div2");
            div3 = (HtmlGenericControl) skin.FindControl("div3");
            div4 = (HtmlGenericControl) skin.FindControl("div4");
            try
            {
                div0 = (HtmlGenericControl) skin.FindControl("div0");
            }
            catch
            {
            }
            if (Page.Request.Cookies["AgentLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["AgentLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                AgentMemberID = cookie2.Values["AgentLoginID"];
            }
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void LinkButton0_Click(object sender, EventArgs e)
        {
            type = ((LinkButton) sender).ID.Replace("LinkButton", "");
            Page.Response.Redirect("http://" + Page.Request.Url.Host + "/ShopMessageBoard.aspx?select=" +
                                   Common.Common.ReqStr("select") + "&type=" + type+"&category="+CookieCustomerCategory);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            type = ((LinkButton) sender).ID.Replace("LinkButton", "");
            Page.Response.Redirect("http://" + Page.Request.Url.Host + "/ShopMessageBoard.aspx?select=" +
                                   Common.Common.ReqStr("select") + "&type=" + type + "&category=" + CookieCustomerCategory);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            type = ((LinkButton) sender).ID.Replace("LinkButton", "");
            Page.Response.Redirect("http://" + Page.Request.Url.Host + "/ShopMessageBoard.aspx?select=" +
                                   Common.Common.ReqStr("select") + "&type=" + type + "&category=" + CookieCustomerCategory);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            type = ((LinkButton) sender).ID.Replace("LinkButton", "");
            Page.Response.Redirect("http://" + Page.Request.Url.Host + "/ShopMessageBoard.aspx?select=" +
                                   Common.Common.ReqStr("select") + "&type=" + type + "&category=" + CookieCustomerCategory);
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            type = "";
            Page.Response.Redirect("http://" + Page.Request.Url.Host + "/ShopMessageBoard.aspx?select=" +
                                   Common.Common.ReqStr("select") + "&type=" + type + "&category=" + CookieCustomerCategory);
        }

        protected void BindData()
        {
            var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = action.SearchMessageBoardListNew(MemLoginID, this.type, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "1",CookieCustomerCategory);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ShopMessageBoard", true)
            {
                ShowPageCount = false,
                ShowPageIndex = false,
                ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (int_0 > pl.PageCount)
            {
                int_0 = pl.PageCount;
            }
            DataSet set2 = action.SearchMessageBoardListNew(MemLoginID, this.type, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "0",CookieCustomerCategory);
            RepeaterBoardList.DataSource = set2.Tables[0];
            RepeaterBoardList.DataBind();
            div1.Attributes.Remove("class");
            div2.Attributes.Remove("class");
            div3.Attributes.Remove("class");
            div4.Attributes.Remove("class");
            div0.Attributes.Remove("class");
            string type = this.type;
            switch (type)
            {
                case null:
                    break;

                case "0":
                    div1.Attributes.Add("class", "selecttab");
                    break;

                case "1":
                    div2.Attributes.Add("class", "selecttab");
                    break;

                case "2":
                    div3.Attributes.Add("class", "selecttab");
                    break;

                default:
                    if (!(type == "3"))
                    {
                        if (type == "")
                        {
                            div0.Attributes.Add("class", "selecttab");
                        }
                    }
                    else
                    {
                        div4.Attributes.Add("class", "selecttab");
                    }
                    break;
            }
        }
    }
}