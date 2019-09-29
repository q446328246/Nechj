using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CouponListSearch : BaseWebControl
    {
        private readonly ShopNum1_Coupon_Action shopNum1_Coupon_Action_0 =
            ((ShopNum1_Coupon_Action) LogicFactory.CreateShopNum1_Coupon_Action());

        private readonly string string_1 = GetPageName.RetDomainUrl("couponslist");

        private Button ButtonSure;
        private DropDownList DropDownListRegionCode1;
        private DropDownList DropDownListRegionCode2;
        private DropDownList DropDownListRegionCode3;
        private HiddenField HiddenFieldCategory;
        private HiddenField HiddenFieldOrdeState;
        private HiddenField HiddenFieldOrdername;
        private HiddenField HiddenFieldRegionCode;
        private HtmlGenericControl IRenqi;

        private Label LabelPageCount;
        private LinkButton LinkButtonRenqi;
        private Panel PanelNofind;
        private Repeater RepeaterCategory;
        private Repeater RepeaterData;
        private TextBox TextBoxIndex;
        private HtmlImage htmlImage_0;
        private int int_0;
        private HtmlGenericControl pageDiv;

        private string skinFilename = "CouponListSearch.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        public CouponListSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string category { get; set; }

        public int ShowCount { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string text = TextBoxIndex.Text.Trim();
            if (Convert.ToInt32(TextBoxIndex.Text.Trim()) > Convert.ToInt32(LabelPageCount.Text))
            {
                TextBoxIndex.Text = LabelPageCount.Text;
                text = LabelPageCount.Text;
            }
            Page.Response.Redirect(string_1 + "?category=" + category + "&order=" + string_3 + "&sdesc=" + string_2 +
                                   "&addcode=" + string_5 + "&pageid=" + text);
        }

        protected void CouponsData()
        {
            SetShopRegionCode();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataTable table = shopNum1_Coupon_Action_0.SearchCouponByType(category, HiddenFieldRegionCode.Value,
                string_3,
                string_2, ShowCount.ToString(),
                int_0.ToString(), "1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("couponslist", true)
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
            DataTable table2 = shopNum1_Coupon_Action_0.SearchCouponByType(category, HiddenFieldRegionCode.Value,
                string_3,
                string_2, ShowCount.ToString(),
                int_0.ToString(), "0");
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterData.DataSource = table2;
                RepeaterData.DataBind();
                PanelNofind.Visible = false;
                RepeaterData.Visible = true;
                for (int i = 0; i < RepeaterData.Items.Count; i++)
                {
                    htmlImage_0 = (HtmlImage) RepeaterData.Items[i].FindControl("ImgCoupon");
                    htmlImage_0.Src = Page.ResolveUrl(table2.Rows[i]["ImgPath"].ToString());
                }
            }
            else
            {
                PanelNofind.Visible = true;
                RepeaterData.Visible = false;
            }
        }

        protected void CouponsDataBind()
        {
            DataTable table = ((ShopNum1_CouponType_Action) LogicFactory.CreateShopNum1_CouponType_Action()).search(-1,
                1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterCategory.DataSource = table.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected void DropDownListRegionCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_0(string_3, string_2);
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                        table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            DataTable table =
                ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(0, 0);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                    table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                        table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
        }

        protected string GetWebFilePath(string ShopID)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string str =
                DateTime.Parse(action.GetOpenTimeByShopID(ShopID).Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "~/ImgUpload/" + str.Replace("-", "/") + "/shop" + ShopID + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenFieldCategory = (HiddenField) skin.FindControl("HiddenFieldCategory");
            HiddenFieldOrdername = (HiddenField) skin.FindControl("HiddenFieldOrdername");
            HiddenFieldOrdeState = (HiddenField) skin.FindControl("HiddenFieldOrdeState");
            IRenqi = (HtmlGenericControl) skin.FindControl("IRenqi");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            PanelNofind = (Panel) skin.FindControl("PanelNofind");
            LinkButtonRenqi = (LinkButton) skin.FindControl("LinkButtonRenqi");
            LinkButtonRenqi.Click += LinkButtonRenqi_Click;
            DropDownListRegionCode1 = (DropDownList) skin.FindControl("DropDownListRegionCode1");
            DropDownListRegionCode1.SelectedIndexChanged += DropDownListRegionCode1_SelectedIndexChanged;
            DropDownListRegionCode2 = (DropDownList) skin.FindControl("DropDownListRegionCode2");
            DropDownListRegionCode2.SelectedIndexChanged += DropDownListRegionCode2_SelectedIndexChanged;
            DropDownListRegionCode3 = (DropDownList) skin.FindControl("DropDownListRegionCode3");
            DropDownListRegionCode3.SelectedIndexChanged += DropDownListRegionCode3_SelectedIndexChanged;
            HiddenFieldRegionCode = (HiddenField) skin.FindControl("HiddenFieldRegionCode");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            string_4 = (Page.Request.QueryString["catename"] == null) ? "全部" : Page.Request.QueryString["catename"];
            HiddenFieldOrdername.Value =
                string_3 =
                    (Page.Request.QueryString["order"] == null) ? "createtime" : Page.Request.QueryString["order"];
            string_2 = (Page.Request.QueryString["sdesc"] == null) ? "desc" : Page.Request.QueryString["sdesc"];
            string_3 = (Page.Request.QueryString["order"] == null) ? "createtime" : Page.Request.QueryString["order"];
            category = (Page.Request.QueryString["category"] == null) ? "-1" : Page.Request.QueryString["category"];
            string_5 = (Page.Request.QueryString["addcode"] == null) ? "-1" : Page.Request.QueryString["addcode"];
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            if (!Page.IsPostBack)
            {
            }
            DropDownListRegionCode1Bind();
            CouponsDataBind();
            CouponsData();
            method_0(string_3, string_2);
        }

        protected void LinkButtonRenqi_Click(object sender, EventArgs e)
        {
            if (string_3 == "browsercount")
            {
                string_2 = (Page.Request.QueryString["sdesc"] == null) ? "" : Page.Request.QueryString["sdesc"];
                if ((string_2 == "asc") || (string_2 == ""))
                {
                    string_2 = "desc";
                }
                else
                {
                    string_2 = "asc";
                }
            }
            else
            {
                string_3 = "browsercount";
                string_2 = "desc";
            }
            Page.Response.Redirect(string_1 + "?regincode=" + Common.Common.ReqStr("regincode") + "&category=" +
                                   category + "&catename=" + string_4 + "&order=" + string_3 + "&sdesc=" + string_2);
        }

        protected void method_0(string string_7, string string_8)
        {
            string_7 = string_7.ToLower();
            if (string_8 == "desc")
            {
                if (string_7 == "createtime")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_7 == "browsercount")
                {
                    HiddenFieldOrdeState.Value = "人气从高到低";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-dSel");
                }
            }
            else
            {
                if (string_7 == "createtime")
                {
                    HiddenFieldOrdeState.Value = "默认排序";
                }
                if (string_7 == "browsercount")
                {
                    HiddenFieldOrdeState.Value = "人气从低到高";
                    LinkButtonRenqi.CssClass = "comSort selected";
                    IRenqi.Attributes.Add("class", "comSort-uSel");
                }
            }
        }

        public void SetShopRegionCode()
        {
            string str = string.Empty;
            if ((Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"] != null) &&
                (Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"] != "-1"))
            {
                str = Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"].Split(new[] {'/'})[0];
            }
            if ((Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"] != null) &&
                (Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"] != "-1"))
            {
                str = str + "," + Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"].Split(new[] {'/'})[0];
            }
            if ((Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"] != null) &&
                (Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"] != "-1"))
            {
                str = str + "," + Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"].Split(new[] {'/'})[0];
            }
            if (str == string.Empty)
            {
                str = "-1";
            }
            HiddenFieldRegionCode.Value = str;
        }
    }
}