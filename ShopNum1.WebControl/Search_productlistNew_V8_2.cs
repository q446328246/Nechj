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

namespace ShopNum1.WebControl
{
    public class Search_productlistNew_V8_2 : BaseWebControl
    {
        private readonly ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private readonly string string_1 = GetPageName.RetDomainUrl("Search_productlist");
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
        private LinkButton LinkButtonNoLimit;
        private LinkButton LinkButtonNoSale;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonPriceDown;
        private LinkButton LinkButtonPriceUp;
        private LinkButton LinkButtonQG;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private LinkButton LinkButtonSalesDown;
        private LinkButton LinkButtonSearch;
        private LinkButton LinkButtonSortStatus;
        private LinkButton LinkButtonTG;
        private LinkButton LinkButtonXinyong;
        private LinkButton LinkButtonZH;
        private LinkButton LinkButtonZK;
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
        private Panel panel_0;

        private string skinFilename = "Search_productlistNew_V8_2.ascx";

        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        public string string_6;
        private string string_7;

        public string style;

        public Search_productlistNew_V8_2()
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
                                   addcode + "&pageid=" + str + "&sale=" + string_7);
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
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&add=" + str +
                                   "&sale=" + string_7);
        }

        public static string GetArea(object AddressValue)
        {
            if (AddressValue.ToString().IndexOf(",") != -1)
            {
                return AddressValue.ToString().Split(new[] {','})[0];
            }
            return AddressValue.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {

            strStartPrice = Common.Common.ReqStr("minprice");
            strEndPrice = Common.Common.ReqStr("maxprice");
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
            LinkButtonNoSale = (LinkButton) skin.FindControl("LinkButtonNoSale");
            LinkButtonTG = (LinkButton) skin.FindControl("LinkButtonTG");
            LinkButtonTG.Click += LinkButtonTG_Click;
            LinkButtonZK = (LinkButton) skin.FindControl("LinkButtonZK");
            LinkButtonZK.Click += LinkButtonZK_Click;
            LinkButtonQG = (LinkButton) skin.FindControl("LinkButtonQG");
            LinkButtonQG.Click += LinkButtonQG_Click;
            LinkButtonZH = (LinkButton) skin.FindControl("LinkButtonZH");
            LinkButtonZH.Click += LinkButtonZH_Click;
            LinkButtonNoLimit = (LinkButton) skin.FindControl("LinkButtonNoLimit");
            LinkButtonNoLimit.Click += LinkButtonNoLimit_Click;
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
            panel_0 = (Panel) skin.FindControl("PanelNoFind");
            string_2 = (Common.Common.ReqStr("code") == "") ? "-1" : Common.Common.ReqStr("code");
            string_3 = (Common.Common.ReqStr("search") == "")
                ? "-1"
                : Common.Common.ReqStr("search").Replace("%2f", "/");
            brandguid = (Common.Common.ReqStr("brandguid") == "") ? "-1" : Common.Common.ReqStr("brandguid");
            Pvalue = (Common.Common.ReqStr("Pvalue") == "") ? "-1" : Common.Common.ReqStr("Pvalue");
            style = (Common.Common.ReqStr("style") == "") ? "grid" : Common.Common.ReqStr("style");
            string_5 = (Common.Common.ReqStr("ordername") == "") ? "salenumber" : Common.Common.ReqStr("ordername");
            string_4 = ((Common.Common.ReqStr("sort") == "") || (Common.Common.ReqStr("sort") == "desc"))
                ? "desc"
                : "asc";
            addcode = (Common.Common.ReqStr("addcode") == "") ? "-1" : Common.Common.ReqStr("addcode");
            string_6 = (Common.Common.ReqStr("add") == "") ? "-1" : Common.Common.ReqStr("add");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Common.Common.ReqStr("PageID"));
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
            string_7 = Common.Common.ReqStr("sale");
            if (!Page.IsPostBack)
            {
                method_1();
                if (string.IsNullOrEmpty(addcode) || (addcode == "-1"))
                {
                    HiddenFieldAdd.Value = string_6;
                }
                else
                {
                    HiddenFieldAddCode.Value = addcode;
                }
            }
            method_0(Common.Common.ReqStr("ordername"), string_4);
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            strStartPrice = TextBoxStartPrice.Text.Trim();
            strEndPrice = TextBoxEndPrice.Text.Trim();
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
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
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonCreateTime_Click(object sender, EventArgs e)
        {
            string_5 = "createtime";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonDefault_Click(object sender, EventArgs e)
        {
            string_5 = "orderid";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonTG_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=1");
        }

        protected void LinkButtonZK_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=2");
        }

        protected void LinkButtonQG_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=3");
        }

        protected void LinkButtonZH_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=4");
        }

        protected void LinkButtonNoLimit_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
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
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
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
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonPrice_Click(object sender, EventArgs e)
        {
            if (string_5 == "shopprice")
            {
                string_4 = (Page.Request.QueryString["sort"] == null) ? "" : Page.Request.QueryString["sort"];
                if (string_4 == "desc")
                {
                    string_4 = "asc";
                    LinkButtonPrice.Attributes.Add("title", "按价格从低到高");
                }
                else
                {
                    string_4 = "desc";
                    LinkButtonPrice.Attributes.Add("title", "按价格从高到低");
                }
            }
            else
            {
                string_5 = "shopprice";
                string_4 = "desc";
                LinkButtonPrice.Attributes.Add("title", "按价格从高到低");
            }
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonGrid_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=grid&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=" +
                                   string_7);
        }

        protected void LinkButtonList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=asc&ordername=" + string_5 + "&style=list&minprice=" +
                                   strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" + addcode + "&sale=" +
                                   string_7);
        }

        protected void LinkButtonPriceUp_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "asc";
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonPriceDown_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void LinkButtonSalesDown_Click(object sender, EventArgs e)
        {
            string_5 = "salenumber";
            string_4 = "desc";
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&code=" + string_2 + "&brandguid=" + brandguid +
                                   "&Pvalue=" + Pvalue + "&sort=" + string_4 + "&ordername=" + string_5 + "&style=" +
                                   style + "&minprice=" + strStartPrice + "&maxprice=" + strEndPrice + "&addcode=" +
                                   addcode + "&sale=" + string_7);
        }

        protected void method_0(string string_11, string string_12)
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
            string_11 = string_11.ToLower();
            if (string_4 == "desc")
            {
                if (string_11 == "shopprice")
                {
                    LinkButtonSortStatus.Text = "价格从高到低";
                    LinkButtonPrice.CssClass = "comSort comSort1 selected";
                    IPrice.Attributes.Add("class", "comSort-dSel");
                }
                if (string_11 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "销量从高到低";
                    LinkButtonSales.CssClass = "comSort comSort1 selected";
                    ISales.Attributes.Add("class", "comSort-dSel");
                }
                if (string_11 == "createtime")
                {
                    LinkButtonSortStatus.Text = "按发布时间排序";
                }
                if (string_11 == "orderid")
                {
                    LinkButtonSortStatus.Text = "默认排序";
                }
                if (string_11 == "collectcount")
                {
                    LinkButtonSortStatus.Text = "人气从高到低";
                    LinkButtonRenqi.CssClass = "comSort comSort1 selected";
                    IRenqi.Attributes.Add("class", "comSort-dSel");
                }
                if (string_11 == "shopreputation")
                {
                    LinkButtonSortStatus.Text = "信用从高到低";
                    LinkButtonXinyong.CssClass = "comSort comSort1 selected";
                    IXinyong.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_11 == "shopprice")
                {
                    LinkButtonSortStatus.Text = "价格从低到高";
                    LinkButtonPrice.CssClass = "comSort comSort1 selected";
                    IPrice.Attributes.Add("class", "comSort-uSel");
                }
                if (string_11 == "salenumber")
                {
                    LinkButtonSortStatus.Text = "销量从低到高";
                    LinkButtonSales.CssClass = "comSort comSort1 selected";
                    ISales.Attributes.Add("class", "comSort-uSel");
                }
                if (string_11 == "createtime")
                {
                    LinkButtonSortStatus.Text = "按发布时间排序";
                }
                if (string_11 == "orderid")
                {
                    LinkButtonSortStatus.Text = "默认排序";
                }
                if (string_11 == "collectcount")
                {
                    LinkButtonSortStatus.Text = "人气从低到高";
                    LinkButtonRenqi.CssClass = "comSort comSort1 selected";
                    IRenqi.Attributes.Add("class", "comSort-uSel");
                }
                if (string_11 == "shopreputation")
                {
                    LinkButtonSortStatus.Text = "信用从低到高";
                    LinkButtonXinyong.CssClass = "comSort comSort1 selected";
                    IXinyong.Attributes.Add("class", "comSort-uSel");
                }
            }
            string str = string_7;
            switch (str)
            {
                case null:
                    break;

                case "1":
                    LinkButtonNoSale.Text = "团购活动";
                    LinkButtonNoSale.CssClass = "selected";
                    break;

                case "2":
                    LinkButtonNoSale.Text = "限时折扣";
                    LinkButtonNoSale.CssClass = "selected";
                    break;

                default:
                    if (!(str == "3"))
                    {
                        if (str == "4")
                        {
                            LinkButtonNoSale.Text = "组合套餐";
                            LinkButtonNoSale.CssClass = "selected";
                        }
                    }
                    else
                    {
                        LinkButtonNoSale.Text = "抢购活动";
                        LinkButtonNoSale.CssClass = "selected";
                    }
                    break;
            }
        }

        protected void method_1()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(addcode, string_6, string_2,
                string_5, string_4,
                strStartPrice, strEndPrice,
                string_3, brandguid,
                ShowCount.ToString(),
                int_0.ToString(), "1",
                dictionary_0, string_7, "9");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("Search_productlist", true)
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
            DataSet set2 = shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(addcode, string_6, string_2,
                string_5, string_4,
                strStartPrice, strEndPrice,
                string_3, brandguid,
                ShowCount.ToString(),
                int_0.ToString(), "0",
                dictionary_0, string_7,"9");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                
                DataRow dr;
                set2.Tables[0].Columns.Add("shop_category_id_name", typeof(string));
                for (int i = 0; i < set2.Tables[0].Rows.Count; i++)
                {
                    if (set2.Tables[0].Rows[i]["shop_category_id"].ToString() == "1")
	            {
                    //dr = set2.Tables[0].NewRow();
                    set2.Tables[0].Rows[i]["shop_category_id_name"] = "";
                    //dr["shop_category_id_name"] = "大唐";
                    //set2.Tables[0].Rows.Add(dr);
	            }

                    else if (set2.Tables[0].Rows[i]["shop_category_id"].ToString() == "2")
                    {
                        //dr = set2.Tables[0].NewRow();
                        //dr["shop_category_id_name"] = "VIP";
                        //set2.Tables[0].Rows.Add(dr);
                        set2.Tables[0].Rows[i]["shop_category_id_name"] = "(VIP)"; 
                    }

                    
                }
                
                RepeaterProductShow.DataSource = set2.Tables[0];
                RepeaterProductShow.DataBind();
                RepeaterGrid.DataSource = set2.Tables[0];
                RepeaterGrid.DataBind();
            }
            else
            {
                panel_0.Visible = true;
            }
        }


        private bool method_2(string string_11)
        {
            string[] strArray = string_11.Split(new[] {'-'});
            if (strArray.Length != 0)
            {
                dictionary_0 = new Dictionary<string, string>();
                foreach (string str in strArray)
                {
                    string[] strArray3 = str.Split(new[] {'m'});
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
                    ((ShopNum1_Ensure_Action) LogicFactory.CreateShopNum1_Ensure_Action()).GetShopapplyEnsure(shopid);
                repeater.DataSource = shopapplyEnsure.DefaultView;
                repeater.DataBind();
            }
        }



    }
}