using System;
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
    [ParseChildren(true)]
    public class SupplyDemandListSearch : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("SupplyDemandListSearch");
        private Button ButtonCity;
        private Button ButtonSure;
        private HiddenField HiddenFieldAdd;
        private HiddenField HiddenFieldAddCode;
        private Label LabelAdress;
        private Label LabelPageCount;
        private Panel Panel1;
        private Repeater RepeaterData;
        private Repeater RepeaterSupplyCategory;
        private TextBox TextBoxCity;
        private TextBox TextBoxIndex;
        //private bool bool_0;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "SupplyDemandListSearch.ascx";
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        //private string string_6;

        public SupplyDemandListSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected void ButtonCity_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?search=" + string_2 + "&supplyCategoryCode=" + string_3 +
                                   "&supplyAddressCode=" + string_4 + "&ordername=" + string_5 + "&PageID=" + str);
        }

        public static string GetMember(object MemberLoginID, object CompanyName, object MemberType)
        {
            if (MemberType.ToString() != "0")
            {
                return CompanyName.ToString();
            }
            return MemberLoginID.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            RepeaterSupplyCategory = (Repeater) skin.FindControl("RepeaterSupplyCategory");
            Panel1 = (Panel) skin.FindControl("Panel1");
            TextBoxCity = (TextBox) skin.FindControl("TextBoxCity");
            ButtonCity = (Button) skin.FindControl("ButtonCity");
            ButtonCity.Click += ButtonCity_Click;
            HiddenFieldAddCode = (HiddenField) skin.FindControl("HiddenFieldAddCode");
            HiddenFieldAdd = (HiddenField) skin.FindControl("HiddenFieldAdd");
            LabelAdress = (Label) skin.FindControl("LabelAdress");
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
            string_2 = (Page.Request.QueryString["search"] == null) ? "-1" : Page.Request.QueryString["search"];
            string_3 = (Page.Request.QueryString["Code"] == null) ? "-1" : Page.Request.QueryString["Code"];
            string_4 = (Page.Request.QueryString["addcode"] == null) ? "-1" : Page.Request.QueryString["addcode"];
            string_5 = (Page.Request.QueryString["ordername"] == null)
                ? "CreateTime"
                : Page.Request.QueryString["ordername"];
            if (!Page.IsPostBack)
            {
            }
            BindData();
            method_2();
            if ((Page.Request.QueryString["addcode"] != null) &&
                !string.IsNullOrEmpty(Page.Request.QueryString["addcode"]))
            {
                string str = Common.Common.GetNameById("Name", "ShopNum1_Region",
                    "   AND   Code='" + Page.Request.QueryString["addcode"] + "'   ");
                if (!string.IsNullOrEmpty(str))
                {
                    LabelAdress.Text = str;
                }
                else
                {
                    LabelAdress.Text = "所在地";
                }
            }
            else
            {
                LabelAdress.Text = "所在地";
            }
        }

        protected void BindData()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_SupplyDemandCategory";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            if ((productCategoryName != null) && (productCategoryName.Rows.Count > 0))
            {
                RepeaterSupplyCategory.DataSource = productCategoryName.DefaultView;
                RepeaterSupplyCategory.DataBind();
            }
        }

        protected void method_1(object sender, EventArgs e)
        {
            //bool_0 = true;
            ViewState["PageData"] = null;
            method_2();
        }

        protected void method_2()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            DataSet set = action.SearchSupply(ShowCount.ToString(), int_0.ToString(), string_2, string_3, string_4,
                string_5, "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("SupplyDemandListSearch", true)
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
            DataSet set2 = action.SearchSupply(ShowCount.ToString(), int_0.ToString(), string_2, string_3, string_4,
                string_5, "0");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                RepeaterData.DataSource = set2.Tables[0];
                RepeaterData.DataBind();
            }
            else if (string_3 == "-1")
            {
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType != ListItemType.AlternatingItem) && (e.Item.ItemType != ListItemType.Item))
            {
            }
        }
    }
}