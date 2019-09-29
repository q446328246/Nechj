using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.WebControl
{
    public class ZtcGoodsMoreList : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("ZtcGoodslist");
        private Button ButtonAgainSearch;
        private Button ButtonCity;
        private Button ButtonSure;
        private HiddenField HiddenFieldAdd;
        private HiddenField HiddenFieldAddCode;
        private HtmlGenericControl IPrice;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private HtmlGenericControl IXinyong;
        private Label LabelAddress;

        private Label LabelPageCount;
        private LinkButton LinkButtonCreateTime;
        private LinkButton LinkButtonDefault;
        private LinkButton LinkButtonGrid;
        private LinkButton LinkButtonList;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonPriceDown;
        private LinkButton LinkButtonPriceUp;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private LinkButton LinkButtonSalesDown;
        private LinkButton LinkButtonSearch;
        private LinkButton LinkButtonSortStatus;
        private LinkButton LinkButtonXinyong;
        private Panel PanelNoFind;
        public string Pvalue;
        private Repeater RepeaterGrid;
        private Repeater RepeaterProductShow;
        private TextBox TextBoxCity;
        private TextBox TextBoxEndPrice;
        private TextBox TextBoxIndex;
        private TextBox TextBoxSearch;
        private TextBox TextBoxStartPrice;
        public string addcode;
        public string brandguid;
        private Dictionary<string, string> dictionary_0;
        private HtmlGenericControl divGrid;
        private HtmlGenericControl divList;
        private int int_0;
        private HtmlGenericControl pageDiv;

        private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private string skinFilename = "ZtcGoodsMoreList.cs.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        public string string_6;

        public string style;

        public ZtcGoodsMoreList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CityShowCount { get; set; }

        public int ShowCount { get; set; }

        private string strEndPrice { get; set; }

        private string strStartPrice { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&pageid=" + str);
        }

        protected void ButtonAgainSearch_Click(object sender, EventArgs e)
        {
            string_3 = (TextBoxSearch.Text.Trim().Replace("'", "") == string.Empty)
                ? "-1"
                : TextBoxSearch.Text.Trim().Replace("'", "");
            string url = GetPageName.AgentRetUrl("Search_productlist", string_3, "search");
            Page.Response.Redirect(url);
        }

        protected void ButtonCity_Click(object sender, EventArgs e)
        {
            string str = TextBoxCity.Text.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&add=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
            strStartPrice = (Page.Request.QueryString["minprice"] == null) ? "" : Page.Request.QueryString["minprice"];
            strEndPrice = (Page.Request.QueryString["maxprice"] == null) ? "" : Page.Request.QueryString["maxprice"];
            RepeaterGrid = (Repeater) skin.FindControl("RepeaterGrid");
            RepeaterProductShow = (Repeater) skin.FindControl("RepeaterProductShow");
            RepeaterProductShow.ItemDataBound += RepeaterProductShow_ItemDataBound;
            TextBoxStartPrice = (TextBox) skin.FindControl("TextBoxStartPrice");
            TextBoxStartPrice.Text = strStartPrice;
            TextBoxEndPrice = (TextBox) skin.FindControl("TextBoxEndPrice");
            TextBoxEndPrice.Text = strEndPrice;
            LinkButtonSearch = (LinkButton) skin.FindControl("LinkButtonSearch");
            LinkButtonSearch.Click += LinkButtonSearch_Click;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            divGrid = (HtmlGenericControl) skin.FindControl("divGrid");
            divList = (HtmlGenericControl) skin.FindControl("divList");
            LinkButtonRenqi = (LinkButton) skin.FindControl("LinkButtonRenqi");
            LinkButtonRenqi.Click += LinkButtonRenqi_Click;
            LinkButtonSales = (LinkButton) skin.FindControl("LinkButtonSales");
            LinkButtonSales.Click += LinkButtonSales_Click;
            LinkButtonXinyong = (LinkButton) skin.FindControl("LinkButtonXinyong");
            LinkButtonXinyong.Click += LinkButtonXinyong_Click;
            LinkButtonPrice = (LinkButton) skin.FindControl("LinkButtonPrice");
            LinkButtonPrice.Click += LinkButtonPrice_Click;
            LinkButtonGrid = (LinkButton) skin.FindControl("LinkButtonGrid");
            LinkButtonGrid.Click += LinkButtonGrid_Click;
            LinkButtonList = (LinkButton) skin.FindControl("LinkButtonList");
            LinkButtonList.Click += LinkButtonList_Click;
            LinkButtonPriceUp = (LinkButton) skin.FindControl("LinkButtonPriceUp");
            LinkButtonPriceUp.Click += LinkButtonPriceUp_Click;
            LinkButtonPriceDown = (LinkButton) skin.FindControl("LinkButtonPriceDown");
            LinkButtonPriceDown.Click += LinkButtonPriceDown_Click;
            LinkButtonSalesDown = (LinkButton) skin.FindControl("LinkButtonSalesDown");
            LinkButtonSalesDown.Click += LinkButtonSalesDown_Click;
            LinkButtonCreateTime = (LinkButton) skin.FindControl("LinkButtonCreateTime");
            LinkButtonCreateTime.Click += LinkButtonCreateTime_Click;
            LinkButtonDefault = (LinkButton) skin.FindControl("LinkButtonDefault");
            LinkButtonDefault.Click += LinkButtonDefault_Click;
            LinkButtonSortStatus = (LinkButton) skin.FindControl("LinkButtonSortStatus");
            LabelAddress = (Label) skin.FindControl("LabelAddress");
            HiddenFieldAddCode = (HiddenField) skin.FindControl("HiddenFieldAddCode");
            HiddenFieldAdd = (HiddenField) skin.FindControl("HiddenFieldAdd");
            ButtonAgainSearch = (Button) skin.FindControl("ButtonAgainSearch");
            ButtonAgainSearch.Click += ButtonAgainSearch_Click;
            TextBoxSearch = (TextBox) skin.FindControl("TextBoxSearch");
            TextBoxCity = (TextBox) skin.FindControl("TextBoxCity");
            ButtonCity = (Button) skin.FindControl("ButtonCity");
            ButtonCity.Click += ButtonCity_Click;
            IRenqi = (HtmlGenericControl) skin.FindControl("IRenqi");
            ISales = (HtmlGenericControl) skin.FindControl("ISales");
            IXinyong = (HtmlGenericControl) skin.FindControl("IXinyong");
            IPrice = (HtmlGenericControl) skin.FindControl("IPrice");
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            strStartPrice = (Page.Request.QueryString["minprice"] == null) ? "" : Page.Request.QueryString["minprice"];
            strEndPrice = (Page.Request.QueryString["maxprice"] == null) ? "" : Page.Request.QueryString["maxprice"];
            string_2 = (Page.Request.QueryString["code"] == null) ? "-1" : Page.Request.QueryString["code"];
            string_3 = (Page.Request.QueryString["search"] == null) ? "-1" : Page.Request.QueryString["search"];
            brandguid = (Page.Request.QueryString["brandguid"] == null) ? "-1" : Page.Request.QueryString["brandguid"];
            Pvalue = (Page.Request.QueryString["Pvalue"] == null) ? "-1" : Page.Request.QueryString["Pvalue"];
            style = (Page.Request.QueryString["style"] == null) ? "grid" : Page.Request.QueryString["style"];
            string_5 = (Page.Request.QueryString["ordername"] == null)
                ? "salenumber"
                : Page.Request.QueryString["ordername"];
            string_4 = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            addcode = (Page.Request.QueryString["addcode"] == null) ? "-1" : Page.Request.QueryString["addcode"];
            string_6 = (Page.Request.QueryString["add"] == null) ? "-1" : Page.Request.QueryString["add"];
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            Func<string, bool> func = method_2;
            if (Pvalue != "-1")
            {
                func(Pvalue);
            }
            if (!Page.IsPostBack)
            {
                method_1();
                method_0(string_5, string_4);
                if (string.IsNullOrEmpty(addcode) || (addcode == "-1"))
                {
                    HiddenFieldAdd.Value = string_6;
                }
                else
                {
                    HiddenFieldAddCode.Value = addcode;
                }
            }
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            strStartPrice = TextBoxStartPrice.Text.Trim();
            strEndPrice = TextBoxEndPrice.Text.Trim();
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode);
        }

        protected void LinkButtonRenqi_Click(object sender, EventArgs e)
        {
            if (string_5 == "collectcount")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == ""))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "collectcount";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonCreateTime_Click(object sender, EventArgs e)
        {
            string_5 = "createtime";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonDefault_Click(object sender, EventArgs e)
        {
            string_5 = "salenumber";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            if (string_5 == "salenumber")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == ""))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "salenumber";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonXinyong_Click(object sender, EventArgs e)
        {
            if (string_5 == "shopreputation")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "-1" : Page.Request.QueryString["sort"];
                if ((string_4 == "asc") || (string_4 == "-1"))
                {
                    string_4 = "desc";
                }
                else
                {
                    string_4 = "asc";
                }
            }
            else
            {
                string_5 = "shopreputation";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonPrice_Click(object sender, EventArgs e)
        {
            if (string_5 == "shopprice")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if ((string_4 == "desc") || (string_4 == ""))
                {
                    string_4 = "asc";
                }
                else
                {
                    string_4 = "desc";
                }
            }
            else
            {
                string_5 = "shopprice";
                string_4 = "desc";
            }
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonGrid_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=list&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonPriceUp_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "asc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonPriceDown_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void LinkButtonSalesDown_Click(object sender, EventArgs e)
        {
            string_5 = "salenumber";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?code=" + string_2 + "&brandguid=" + brandguid + "&Pvalue=" + Pvalue +
                                   "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" + style + "&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode);
        }

        protected void method_0(string string_10, string string_11)
        {
            if (style == "list")
            {
                divList.Style.Add("display", "block");
                divGrid.Style.Add("display", "none");
            }
            else
            {
                divList.Style.Add("display", "none");
                divGrid.Style.Add("display", "block");
            }
            string_10 = string_10.ToLower();
            if (string_4 == "desc")
            {
                if (string_10 == "shopprice")
                {
                    LinkButtonSortStatus.Text = "价格从高到低";
                    LinkButtonPrice.CssClass = "comSort selected";
                    IPrice.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "销量从高到低";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "createtime")
                {
                    LinkButtonSortStatus.Text = "按发布时间排序";
                }
                if (string_10 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "默认排序";
                }
                if (string_10 == "collectcount")
                {
                    LinkButtonSortStatus.Text = "人气从高到低";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-dSel");
                }
                if (string_10 == "shopreputation")
                {
                    LinkButtonSortStatus.Text = "信用从高到低";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_10 == "shopprice")
                {
                    LinkButtonSortStatus.Text = "价格从低到高";
                    LinkButtonPrice.CssClass = "comSort selected";
                    IPrice.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "销量从低到高";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "createtime")
                {
                    LinkButtonSortStatus.Text = "按发布时间排序";
                }
                if (string_10 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "默认排序";
                }
                if (string_10 == "collectcount")
                {
                    LinkButtonSortStatus.Text = "人气从低到高";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-uSel");
                }
                if (string_10 == "shopreputation")
                {
                    LinkButtonSortStatus.Text = "信用从低到高";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-uSel");
                }
            }
        }

        protected void method_1()
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            decimal num = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
            DataTable table = action.SearchData(1, num);
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows.Count);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ZtcGoodslist", true)
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
            DataTable table2 = action.SearchData(1, num, int_0, ShowCount);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterGrid.DataSource = table2.DefaultView;
                RepeaterGrid.DataBind();
            }
            else
            {
                PanelNoFind.Visible = true;
            }
        }


        private bool method_2(string string_10)
        {
            string[] strArray = string_10.Split(new[] {'-'});
            if (strArray.Length != 0)
            {
                dictionary_0 = new Dictionary<string, string>();
                foreach (string str in strArray)
                {
                    string[] strArray3 = str.Split(new[] {'a'});
                    if (strArray3.Length == 2)
                    {
                        dictionary_0.Add(strArray3[0], strArray3[1]);
                    }
                }
            }
            return true;
        }

        protected void RepeaterProductShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterShopEnsure");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldMemLoginID");
                string shopid = field.Value.Trim().Replace("'", "");
                DataTable shopapplyEnsure =
                    ((Shop_Ensure_Action) ShopFactory.LogicFactory.CreateShop_Ensure_Action()).GetShopapplyEnsure(shopid);
                repeater.DataSource = shopapplyEnsure.DefaultView;
                repeater.DataBind();
            }
        }
    }
}