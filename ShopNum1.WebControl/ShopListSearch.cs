using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System.Web;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.WebControl
{
    public class ShopListSearch : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("ShopListSearch");
        private Button ButtonSearch;
        private Button ButtonSure;
        private DataList DataListRelatedProduct;
        private HiddenField HiddenFieldAddCode;
        private HiddenField HiddenFieldOrdeState;
        private HiddenField HiddenFieldOrdername;
        private HtmlGenericControl IRenqi;
        private HtmlGenericControl ISales;
        private HtmlGenericControl IXinyong;

        private Label LabelAddress;
        private Label LabelAdress;
        private Label LabelPageCount;
        private LinkButton LinkButtonRenqi;
        private LinkButton LinkButtonSales;
        private LinkButton LinkButtonXinyong;
        private Panel PanelNoFind;
        private Repeater RepeaterData;
        private TextBox TextBoxIndex;
        private TextBox TextBoxMember;
        private TextBox TextBoxShopname;
        public string addcode;
        private int int_0;
        public string memberid;
        private HtmlGenericControl pageDiv;
        public string shopName;

        private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private string skinFilename = "ShopListSearch.ascx";
        private string string_2;
        private string string_3;
        private string string_4;

        public ShopListSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CityShowCount { get; set; }

        public int ShowCount { get; set; }

        public string ShowRelatedProduct { get; set; }

        protected void BindData()
        {

            var dataSet = new DataSet();
            dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
            string INDEXURL = dataRow["OverrideDomain"].ToString();

            TextBoxShopname.Text = shopName;
            TextBoxMember.Text = memberid;
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataSet set = action.SearchShopList(addcode, string_2, string_4, string_3, shopName, memberid,
                ShowCount.ToString(), int_0.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ShopListSearch", true)
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
            DataSet set2 = action.SearchShopList(addcode, string_2, string_4, string_3, shopName, memberid,
                ShowCount.ToString(), int_0.ToString(), "0");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                RepeaterData.DataSource = set2.Tables[0];
                RepeaterData.DataBind();
            }
            else
            {
                PanelNoFind.Visible = true;
            }


            string tag = "9";
            HttpCookie cookie2 = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);
            if (!string.IsNullOrEmpty(tag))
            {
                string MemRankGuid = null;
                string MemLinkCategory = null;
                //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
                if (cookie2 != null)
                {
                    MemRankGuid = cookie2.Values["MemRankGuid"];
                }
                else
                {
                    MemRankGuid = MemberLevel.NORMAL_MEMBER_ID;
                }
                //根据会员等级的Guid以及可看属性获得专区板块ID字符串
                DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "1");
                if (linkCategory.Rows.Count > 0)
                {
                    MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
                }
                if (!string.IsNullOrEmpty(MemLinkCategory))
                {

                    //字符串中不包含浏览专区的tag值，说明没有权限查阅，跳回首页
                    if (!MemLinkCategory.Contains(tag))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(string.Format("http://{0}",INDEXURL), true);

                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Redirect(string.Format("http://{0}", INDEXURL), true);
                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Redirect(string.Format("http://{0}", INDEXURL), true);
            }

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            shopName = TextBoxShopname.Text.Trim().Replace("'", "");
            memberid = TextBoxMember.Text.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string text = TextBoxIndex.Text.Trim();
            if (Convert.ToInt32(TextBoxIndex.Text.Trim()) > Convert.ToInt32(LabelPageCount.Text))
            {
                TextBoxIndex.Text = LabelPageCount.Text;
                text = LabelPageCount.Text;
            }
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode + "&pageid=" +
                                   text);
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelAddress = (Label) skin.FindControl("LabelAddress");
            HiddenFieldAddCode = (HiddenField) skin.FindControl("HiddenFieldAddCode");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            TextBoxShopname = (TextBox) skin.FindControl("TextBoxShopname");
            TextBoxShopname.TextChanged += TextBoxShopname_TextChanged;
            TextBoxMember = (TextBox) skin.FindControl("TextBoxMember");
            TextBoxMember.TextChanged += TextBoxMember_TextChanged;
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            DataListRelatedProduct = (DataList) skin.FindControl("DataListRelatedProduct");
            HiddenFieldOrdername = (HiddenField) skin.FindControl("HiddenFieldOrdername");
            HiddenFieldOrdeState = (HiddenField) skin.FindControl("HiddenFieldOrdeState");
            LinkButtonRenqi = (LinkButton) skin.FindControl("LinkButtonRenqi");
            LinkButtonRenqi.Click += LinkButtonRenqi_Click;
            LinkButtonSales = (LinkButton) skin.FindControl("LinkButtonSales");
            LinkButtonSales.Click += LinkButtonSales_Click;
            LinkButtonXinyong = (LinkButton) skin.FindControl("LinkButtonXinyong");
            LinkButtonXinyong.Click += LinkButtonXinyong_Click;
            IRenqi = (HtmlGenericControl) skin.FindControl("IRenqi");
            ISales = (HtmlGenericControl) skin.FindControl("ISales");
            IXinyong = (HtmlGenericControl) skin.FindControl("IXinyong");
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            LabelAdress = (Label) skin.FindControl("LabelAdress");
            string_2 = (Common.Common.ReqStr("code") == "") ? "" : Common.Common.ReqStr("code");
            HiddenFieldOrdername.Value =
                string_4 = (Common.Common.ReqStr("ordername") == "") ? "ordersum" : Common.Common.ReqStr("ordername");
            string_3 = (Common.Common.ReqStr("sort") == "") ? "desc" : Common.Common.ReqStr("sort");
            addcode = (Common.Common.ReqStr("addcode") == "") ? "" : Common.Common.ReqStr("addcode");
            shopName = (Common.Common.ReqStr("search") == "") ? "" : Common.Common.ReqStr("search");
            memberid = (Common.Common.ReqStr("memberid") == "") ? "" : Common.Common.ReqStr("memberid");
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
            method_0(string_4, string_3);
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
            if (string_4 == "collectcount")
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
                string_4 = "collectcount";
                string_3 = "desc";
            }
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            if (string_4 == "salesum")
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
                string_4 = "ordersum";
                string_3 = "desc";
            }
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
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
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void method_0(string string_7, string string_8)
        {
            string_7 = string_7.ToLower();
            if (string_8 == "desc")
            {
                if (string_7 == "salesum")
                {
                    HiddenFieldOrdeState.Value = "销量从高到低";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-dSel");
                }
                if (string_7 == "orderid")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_7 == "collectcount")
                {
                    HiddenFieldOrdeState.Value = "人气从高到低";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-dSel");
                }
                if (string_7 == "shopreputation")
                {
                    HiddenFieldOrdeState.Value = "信用从高到低";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_7 == "salesum")
                {
                    HiddenFieldOrdeState.Value = "销量从低到高";
                    LinkButtonSales.CssClass = "comSort selected";
                    ISales.Attributes.Add("class", "comSort-uSel");
                }
                if (string_7 == "orderid")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_7 == "collectcount")
                {
                    HiddenFieldOrdeState.Value = "人气从低到高";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-uSel");
                }
                if (string_7 == "shopreputation")
                {
                    HiddenFieldOrdeState.Value = "信用从低到高";
                    LinkButtonXinyong.CssClass = "comSort selected";
                    IXinyong.Attributes.Add("class", "comSort-uSel");
                }
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterShopEnsure");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldMemLoginID");
                string shopid = field.Value.Trim().Replace("'", "");
                DataTable shopapplyEnsure = new ShopNum1_Ensure_Action().GetShopapplyEnsure(shopid);
                repeater.DataSource = shopapplyEnsure.DefaultView;
                repeater.DataBind();
            }
        }

        protected void TextBoxShopname_TextChanged(object sender, EventArgs e)
        {
            shopName = TextBoxShopname.Text.Trim().Replace("'", "");
            memberid = TextBoxMember.Text.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }

        protected void TextBoxMember_TextChanged(object sender, EventArgs e)
        {
            shopName = TextBoxShopname.Text.Trim().Replace("'", "");
            memberid = TextBoxMember.Text.Trim().Replace("'", "");
            Page.Response.Redirect(string_1 + "?search=" + shopName + "&code=" + string_2 + "&memberid=" + memberid +
                                   "&sort=" + string_3 + "&ordername=" + string_4 + "&addcode=" + addcode);
        }
    }
}