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
    public class Search_productlistNew : BaseWebControl
    {
        private readonly ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private readonly string string_1 = GetPageName.RetDomainUrl("ProductListPromotion");
        private Button ButtonAgainSearch;
        private Button ButtonCity;
        private Button ButtonSure;
        private HiddenField HiddenFieldAdd;
        private HiddenField HiddenFieldAddCode;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private HtmlGenericControl IXinyong;
        public int IsShopGood;
        public int IsShopRecommend;
        public int IsshopHot;
        public int IsshopNew;
        private Label LabelAddress;
        private Label LabelPageCount;
        private LinkButton LinkButtonCreateTime;
        private LinkButton LinkButtonDefault;
        private LinkButton LinkButtonGood;
        private LinkButton LinkButtonGrid;
        private LinkButton LinkButtonHot;
        private LinkButton LinkButtonList;
        private LinkButton LinkButtonNew;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonPriceDown;
        private LinkButton LinkButtonPriceUp;
        private LinkButton LinkButtonRecommend;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private LinkButton LinkButtonSalesDown;
        private LinkButton LinkButtonSearch;
        private LinkButton LinkButtonSortStatus;
        private LinkButton LinkButtonStatus;
        private LinkButton LinkButtonXinyong;
        private Panel PanelNoFind;
        public string Pvalue;
        private HtmlGenericControl RepeaterGrid;
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
        private Repeater repeater_0;

        private string skinFilename = "Search_productlistNew.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        public string string_6;

        public string style;

        public Search_productlistNew()
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?search=", string_3, "&code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue,
                "&sort=", string_4, "&ordername=", string_5, "&style=", style, "&minprice=",
                strStartPrice, "&maxprice=", strEndPrice, "&addcode=", addcode, "&pageid=", str, "&IsshopNew= ",
                IsshopNew, "&IsshopHot=", IsshopHot, "&IsShopGood=", IsShopGood, "&IsshopRecommend=",
                IsShopRecommend
            }));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?search=", string_3, "&code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue,
                "&sort=", string_4, "&ordername=", string_5, "&style=", style, "&minprice=",
                strStartPrice, "&maxprice=", strEndPrice, "&add=", str, "&IsshopNew= ", IsshopNew, "&IsshopHot=",
                IsshopHot, "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected override void InitializeSkin(Control skin)
        {
            strStartPrice = Common.Common.ReqStr("minprice");
            strEndPrice = Common.Common.ReqStr("maxprice");
            if (Page.Request.QueryString["IsshopNew"] != null)
            {
                IsshopNew = Convert.ToInt32(Page.Request.QueryString["IsshopNew"]);
            }
            if (Page.Request.QueryString["IsshopHot"] != null)
            {
                IsshopHot = Convert.ToInt32(Page.Request.QueryString["IsshopHot"]);
            }
            if (Page.Request.QueryString["IsShopGood"] != null)
            {
                IsShopGood = Convert.ToInt32(Page.Request.QueryString["IsShopGood"]);
            }
            if (Page.Request.QueryString["IsShopRecommend"] != null)
            {
                IsShopRecommend = Convert.ToInt32(Page.Request.QueryString["IsShopRecommend"]);
            }
            repeater_0 = (Repeater) skin.FindControl("RepeaterGrid");
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
            RepeaterGrid = (HtmlGenericControl) skin.FindControl("IPrice");
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            LinkButtonStatus = (LinkButton) skin.FindControl("LinkButtonStatus");
            LinkButtonNew = (LinkButton) skin.FindControl("LinkButtonNew");
            LinkButtonNew.Click += LinkButtonNew_Click;
            LinkButtonHot = (LinkButton) skin.FindControl("LinkButtonHot");
            LinkButtonHot.Click += LinkButtonHot_Click;
            LinkButtonGood = (LinkButton) skin.FindControl("LinkButtonGood");
            LinkButtonGood.Click += LinkButtonGood_Click;
            LinkButtonRecommend = (LinkButton) skin.FindControl("LinkButtonRecommend");
            LinkButtonRecommend.Click += LinkButtonRecommend_Click;
            string_2 = (Common.Common.ReqStr("code") == "") ? "-1" : Common.Common.ReqStr("code");
            string_3 = (Common.Common.ReqStr("search") == "") ? "-1" : Common.Common.ReqStr("search");
            brandguid = (Common.Common.ReqStr("brandguid") == "") ? "-1" : Common.Common.ReqStr("brandguid");
            Pvalue = (Common.Common.ReqStr("Pvalue") == "") ? "-1" : Common.Common.ReqStr("Pvalue");
            style = (Common.Common.ReqStr("style") == "") ? "grid" : Common.Common.ReqStr("style");
            string_5 = (Common.Common.ReqStr("ordername") == "") ? "salenumber" : Common.Common.ReqStr("ordername");
            string_4 = (Common.Common.ReqStr("sort") == "") ? "desc" : Common.Common.ReqStr("sort");
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
            if (!Page.IsPostBack)
            {
                method_1();
                method_0(Common.Common.ReqStr("ordername"), Common.Common.ReqStr("sort"));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?search=", string_3, "&code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue,
                "&sort=", string_4, "&ordername=", string_5, "&style=", style, "&minprice=",
                strStartPrice, "&maxprice=", strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew,
                "&IsshopHot=", IsshopHot, "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonCreateTime_Click(object sender, EventArgs e)
        {
            string_5 = "createtime";
            string_4 = "desc";
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonDefault_Click(object sender, EventArgs e)
        {
            string_5 = "orderid";
            string_4 = "desc";
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonNew_Click(object sender, EventArgs e)
        {
            IsshopNew = 1;
            IsshopHot = 0;
            IsShopGood = 0;
            IsShopRecommend = 0;
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonHot_Click(object sender, EventArgs e)
        {
            IsshopHot = 1;
            IsshopNew = 0;
            IsShopGood = 0;
            IsShopRecommend = 0;
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonGood_Click(object sender, EventArgs e)
        {
            IsShopGood = 1;
            IsshopNew = 0;
            IsshopHot = 0;
            IsShopRecommend = 0;
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonRecommend_Click(object sender, EventArgs e)
        {
            IsShopRecommend = 1;
            IsshopNew = 0;
            IsshopHot = 0;
            IsShopGood = 0;
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
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
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonGrid_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=grid&minprice=", strStartPrice, "&maxprice=", strEndPrice,
                "&addcode=",
                addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot, "&IsShopGood=", IsShopGood,
                "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=list&minprice=", strStartPrice, "&maxprice=", strEndPrice,
                "&addcode=",
                addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot, "&IsShopGood=", IsShopGood,
                "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonPriceUp_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "asc";
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonPriceDown_Click(object sender, EventArgs e)
        {
            string_5 = "shopprice";
            string_4 = "desc";
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
        }

        protected void LinkButtonSalesDown_Click(object sender, EventArgs e)
        {
            string_5 = "salenumber";
            string_4 = "desc";
            Page.Response.Redirect(string.Concat(new object[]
            {
                string_1, "?code=", string_2, "&brandguid=", brandguid, "&Pvalue=", Pvalue, "&sort=", string_4,
                "&ordername=", string_5, "&style=", style, "&minprice=", strStartPrice, "&maxprice=",
                strEndPrice, "&addcode=", addcode, "&IsshopNew= ", IsshopNew, "&IsshopHot=", IsshopHot,
                "&IsShopGood=", IsShopGood, "&IsshopRecommend=", IsShopRecommend
            }));
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
                    RepeaterGrid.Attributes.Add("class", "comSort-dSel");
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
                if (string_10 == "orderid")
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
                    RepeaterGrid.Attributes.Add("class", "comSort-uSel");
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
                if (string_10 == "orderid")
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
            if (IsshopNew == 1)
            {
                LinkButtonStatus.Text = "新品";
            }
            if (IsshopHot == 1)
            {
                LinkButtonStatus.Text = "热卖";
            }
            if (IsShopGood == 1)
            {
                LinkButtonStatus.Text = "精品";
            }
            if (IsShopRecommend == 1)
            {
                LinkButtonStatus.Text = "推荐";
            }
        }

        protected void method_1()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = shopNum1_ProuductChecked_Action_0.GetFurnitureProduct2(addcode, string_6, string_2, string_5,
                string_4, strStartPrice, strEndPrice,
                string_3, brandguid,
                ShowCount.ToString(), int_0.ToString(),
                "1", dictionary_0, IsshopNew, IsshopHot,
                IsShopGood, IsShopRecommend);
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ProductListPromotion", true)
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
            DataSet set2 = shopNum1_ProuductChecked_Action_0.GetFurnitureProduct2(addcode, string_6, string_2, string_5,
                string_4, strStartPrice, strEndPrice,
                string_3, brandguid,
                ShowCount.ToString(), int_0.ToString(),
                "0", dictionary_0, IsshopNew,
                IsshopHot, IsShopGood, IsShopRecommend);
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                RepeaterProductShow.DataSource = set2.Tables[0];
                RepeaterProductShow.DataBind();
                repeater_0.DataSource = set2.Tables[0];
                repeater_0.DataBind();
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
                    ((ShopNum1_Ensure_Action) LogicFactory.CreateShopNum1_Ensure_Action()).GetShopapplyEnsure(shopid);
                repeater.DataSource = shopapplyEnsure.DefaultView;
                repeater.DataBind();
            }
        }
    }
}