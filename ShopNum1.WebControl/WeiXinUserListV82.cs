using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;

namespace ShopNum1.WebControl
{
    public class WeiXinUserListV82 : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("WeiXinUserListV82");
        private Button ButtonSearch;
        private Button ButtonSure;
        private HiddenField HiddenFieldAddCode;
        private HiddenField HiddenFieldOrdeState;
        private HiddenField HiddenFieldOrdername;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private HtmlGenericControl IXinyong;
        private Label LabelAdress;
        private Label LabelPageCount;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private LinkButton LinkButtonXinyong;
        private Panel PanelNoFind;
        public string PublicNo;
        private Repeater RepeaterGrid;
        private TextBox TextBoxIndex;
        public string WeiXinName;
        public string addcode;
        private int int_0;
        private HtmlGenericControl pageDiv;

        private ShopNum1_WeiXin_ShopUser_Active shopNum1_WeiXin_ShopUser_Active_0 =
            new ShopNum1_WeiXin_ShopUser_Active();

        private string skinFilename = "WeiXinUserListV82.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private HtmlInputText tbPublicNo;
        private HtmlInputText tbWeiXinName;

        public WeiXinUserListV82()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CityShowCount { get; set; }

        public int ShowCount { get; set; }

        protected void BindData()
        {
            if (string_3.IndexOf(",") != -1)
            {
                string_3 = string_3.Split(new[] {','})[0];
            }
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var active = new ShopNum1_WeiXin_ShopUser_Active();
            DataTable table = active.SelectWeiXinStore(ShowCount.ToString(), int_0.ToString(), "3", method_0(), string_4,
                string_3);
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("WeiXinUserListV82", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
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
            DataTable table2 = active.SelectWeiXinStore(ShowCount.ToString(), int_0.ToString(), "2", method_0(),
                string_4, string_3);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterGrid.DataSource = table2;
                RepeaterGrid.DataBind();
            }
            else
            {
                PanelNoFind.Visible = true;
            }
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string text = TextBoxIndex.Text.Trim();
            if (Convert.ToInt32(TextBoxIndex.Text.Trim()) > Convert.ToInt32(LabelPageCount.Text))
            {
                TextBoxIndex.Text = LabelPageCount.Text;
                text = LabelPageCount.Text;
            }
            Page.Response.Redirect(string_1 + "?search=" + WeiXinName + "&code=" + string_2 + "&PublicNo=" + PublicNo +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode + "&pageid=" +
                                   text);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            WeiXinName = tbWeiXinName.Value.Trim().Replace("'", "");
            PublicNo = tbPublicNo.Value.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?search=" + WeiXinName + "&code=" + string_2 + "&PublicNo=" + PublicNo +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterGrid = (Repeater) skin.FindControl("RepeaterGrid");
            tbWeiXinName = (HtmlInputText) skin.FindControl("tbWeiXinName");
            tbPublicNo = (HtmlInputText) skin.FindControl("tbPublicNo");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            LinkButtonRenqi = (LinkButton) skin.FindControl("LinkButtonRenqi");
            LinkButtonRenqi.Click += LinkButtonRenqi_Click;
            LinkButtonSales = (LinkButton) skin.FindControl("LinkButtonSales");
            LinkButtonSales.Click += LinkButtonSales_Click;
            LinkButtonXinyong = (LinkButton) skin.FindControl("LinkButtonXinyong");
            LinkButtonXinyong.Click += LinkButtonXinyong_Click;
            HiddenFieldAddCode = (HiddenField) skin.FindControl("HiddenFieldAddCode");
            HiddenFieldOrdername = (HiddenField) skin.FindControl("HiddenFieldOrdername");
            HiddenFieldOrdeState = (HiddenField) skin.FindControl("HiddenFieldOrdeState");
            IRenqi = (HtmlGenericControl) skin.FindControl("IRenqi");
            ISales = (HtmlGenericControl) skin.FindControl("ISales");
            IXinyong = (HtmlGenericControl) skin.FindControl("IXinyong");
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            LabelAdress = (Label) skin.FindControl("LabelAdress");
            string_2 = (Common.Common.ReqStr("code") == "") ? "" : Common.Common.ReqStr("code");
            HiddenFieldOrdername.Value =
                string_4 = (Common.Common.ReqStr("ordername") == "") ? "salenumber" : Common.Common.ReqStr("ordername");
            string_3 = (Common.Common.ReqStr("sort") == "") ? "desc" : Common.Common.ReqStr("sort");
            addcode = (Common.Common.ReqStr("addcode") == "") ? "" : Common.Common.ReqStr("addcode");
            WeiXinName = (Common.Common.ReqStr("search") == "") ? "" : Common.Common.ReqStr("search");
            PublicNo = (Common.Common.ReqStr("PublicNo") == "") ? "" : Common.Common.ReqStr("PublicNo");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Common.Common.ReqStr("PageID"));
            }
            catch
            {
                int_0 = 1;
            }
            if (!Page.IsPostBack)
            {
            }
            HiddenFieldAddCode.Value = addcode;
            BindData();
            method_1(string_4, string_3);
            if ((Page.Request.QueryString["addcode"] != null) &&
                !string.IsNullOrEmpty(Page.Request.QueryString["addcode"]))
            {
                string str2 = Common.Common.GetNameById("Name", "ShopNum1_Region",
                    "   AND   Code='" + Page.Request.QueryString["addcode"] + "'   ");
                if (!string.IsNullOrEmpty(str2))
                {
                    LabelAdress.Text = str2;
                }
                else
                {
                    LabelAdress.Text = "所有地区";
                }
            }
            else
            {
                LabelAdress.Text = "所有地区";
            }
        }

        protected void LinkButtonRenqi_Click(object sender, EventArgs e)
        {
            if (string_4 == "clickcount")
            {
                string_3 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_3 == "asc") || (string_3 == ""))
                {
                    string_3 = "desc";
                }
                else
                {
                    string_3 = "asc";
                }
            }
            else
            {
                string_4 = "clickcount";
                string_3 = "desc";
            }
            Page.Response.Redirect(string_1 + "?search=" + WeiXinName + "&code=" + string_2 + "&PublicNo=" + PublicNo +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            if (string_4 == "salenumber")
            {
                string_3 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_3 == "asc") || (string_3 == ""))
                {
                    string_3 = "desc";
                }
                else
                {
                    string_3 = "asc";
                }
            }
            else
            {
                string_4 = "salenumber";
                string_3 = "desc";
            }
            Page.Response.Redirect(string_1 + "?search=" + WeiXinName + "&code=" + string_2 + "&PublicNo=" + PublicNo +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void LinkButtonXinyong_Click(object sender, EventArgs e)
        {
            if (string_4 == "shopreputation")
            {
                string_3 = (Page.Request.QueryString["sort"] == null) ? "-1" : Page.Request.QueryString["sort"];
                if ((string_3 == "asc") || (string_3 == "-1"))
                {
                    string_3 = "desc";
                }
                else
                {
                    string_3 = "asc";
                }
            }
            else
            {
                string_4 = "shopreputation";
                string_3 = "desc";
            }
            Page.Response.Redirect(string_1 + "?search=" + WeiXinName + "&code=" + string_2 + "&PublicNo=" + PublicNo +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        private string method_0()
        {
            var builder = new StringBuilder();
            if (string_2 != "")
            {
                builder.Append(" And ShopCategoryId like '" + string_2 + "%'");
            }
            if ((addcode != "") && (addcode != "000"))
            {
                builder.Append(" And addresscode like '" + addcode + "%'");
            }
            if (WeiXinName != "")
            {
                builder.Append(" And WeiXinName like '%" + WeiXinName + "%'");
                tbWeiXinName.Value = WeiXinName.Trim();
            }
            if (PublicNo != "")
            {
                builder.Append(" And PublicNo like '%" + PublicNo + "%'");
                tbPublicNo.Value = PublicNo.Trim();
            }
            return builder.ToString();
        }

        protected void method_1(string string_6, string string_7)
        {
            string_6 = string_6.ToLower();
            if (string_7 == "desc")
            {
                if (string_6 == "salenumber")
                {
                    HiddenFieldOrdeState.Value = "销量从高到低";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-dSel");
                }
                if (string_6 == "orderid")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_6 == "clickcount")
                {
                    HiddenFieldOrdeState.Value = "人气从高到低";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-dSel");
                }
                if (string_6 == "shopreputation")
                {
                    HiddenFieldOrdeState.Value = "信用从高到低";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_6 == "salenumber")
                {
                    HiddenFieldOrdeState.Value = "销量从低到高";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-uSel");
                }
                if (string_6 == "orderid")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_6 == "clickcount")
                {
                    HiddenFieldOrdeState.Value = "人气从低到高";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-uSel");
                }
                if (string_6 == "shopreputation")
                {
                    HiddenFieldOrdeState.Value = "信用从低到高";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-uSel");
                }
            }
        }
    }
}