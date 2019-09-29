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
    public class ShopSearch : BaseWebControl
    {
        private Button ButtonGo;
        private Button ButtonSearch;
        private DropDownList DropDownListRegionCode1;
        private DropDownList DropDownListRegionCode2;
        private DropDownList DropDownListRegionCode3;
        private DropDownList DropDownListShopCategoryCode1;
        private DropDownList DropDownListShopCategoryCode2;
        private DropDownList DropDownListShopCategoryCode3;
        private Label LabelPageCount;
        private Label LabelPageIndex;
        private Label LabelShopProductName;
        private LinkButton LinkButtonEnd;
        private LinkButton LinkButtonFirst;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterData;
        private TextBox TextBoxMemberID;
        private TextBox TextBoxPageNum;
        private TextBox TextBoxShopName;
        private bool bool_0;
        private HiddenField hiddenField_0;
        private HtmlGenericControl htmlGenericControl_0;
        private string skinFilename = "ShopSearch.ascx";
        public int PageCount { get; set; }

        protected void BindData()
        {
            string str2;
            string str3;
            DataSet set;
            string regioncode = SetShopRegionCode();
            int num = int.Parse(LabelPageIndex.Text);
            if (!((Page.Request.QueryString["code"] == null) || bool_0))
            {
                str2 = Page.Request.QueryString["code"];
            }
            else
            {
                str2 = SetShopCategoryCode();
            }
            if (!((Page.Request.QueryString["search"] == null) || bool_0))
            {
                str3 = Page.Server.UrlDecode(Page.Request.QueryString["search"]);
            }
            else
            {
                str3 = Operator.FilterString((TextBoxShopName.Text == "") ? "-1" : TextBoxShopName.Text);
            }
            string memberloginid = Operator.FilterString((TextBoxMemberID.Text == "") ? "-1" : TextBoxMemberID.Text);
            if (ViewState["PageData"] == null)
            {
                var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
                set = action.SearchShopList(num.ToString(), PageCount.ToString(), regioncode, str2, str3, memberloginid);
                ViewState["PageData"] = set;
            }
            else
            {
                int num2 = num/10;
                if (num2.ToString() != ((DataSet) ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
                {
                    set =
                        ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                            .SearchShopList(num.ToString(), PageCount.ToString(), regioncode, str2, str3, memberloginid);
                    ViewState["PageData"] = set;
                }
            }
            LabelPageCount.Text = (((DataSet) ViewState["PageData"]).Tables[2].Rows[0][0].ToString() == "0")
                ? "1"
                : ((DataSet) ViewState["PageData"]).Tables[2].Rows[0][0].ToString();
            var source = new PagedDataSource
            {
                AllowPaging = true,
                PageSize = PageCount,
                DataSource = ((DataSet) ViewState["PageData"]).Tables[0].DefaultView,
                CurrentPageIndex = (num - 1)%10
            };
            RepeaterData.DataSource = source;
            RepeaterData.DataBind();
            LinkButtonFirst.Enabled = true;
            LinkButtonLast.Enabled = true;
            LinkButtonNext.Enabled = true;
            LinkButtonEnd.Enabled = true;
            if (num == 1)
            {
                LinkButtonFirst.Enabled = false;
                LinkButtonLast.Enabled = false;
            }
            if (num.ToString() == LabelPageCount.Text)
            {
                LinkButtonNext.Enabled = false;
                LinkButtonEnd.Enabled = false;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = "1";
            bool_0 = true;
            ViewState["PageData"] = null;
            BindData();
            LabelShopProductName.Text = (GetShopCategoryName() == "-1") ? "全部" : GetShopCategoryName();
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = TextBoxPageNum.Text;
            BindData();
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Region";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["Code"] + "/" +
                    productCategoryName.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode2.Items.Clear();
            DropDownListShopCategoryCode2.Items.Add(new ListItem("-全部-", "-1"));
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                        list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode1Bind()
        {
            DropDownListShopCategoryCode1.Items.Clear();
            DropDownListShopCategoryCode1.Items.Add(new ListItem("-全部-", "-1"));
            DataTable list =
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListShopCategoryCode1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                    list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode3.Items.Clear();
            DropDownListShopCategoryCode3.Items.Add(new ListItem("-全部-", "-1"));
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                        list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        public string GetShopCategoryName()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode3.SelectedItem.Text;
            }
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode2.SelectedItem.Text;
            }
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode1.SelectedItem.Text;
            }
            return "-1";
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
            TextBoxShopName = (TextBox) skin.FindControl("TextBoxShopName");
            TextBoxMemberID = (TextBox) skin.FindControl("TextBoxMemberID");
            LabelShopProductName = (Label) skin.FindControl("LabelShopProductName");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            DropDownListShopCategoryCode1 = (DropDownList) skin.FindControl("DropDownListShopCategoryCode1");
            DropDownListShopCategoryCode1.SelectedIndexChanged += DropDownListShopCategoryCode1_SelectedIndexChanged;
            DropDownListShopCategoryCode2 = (DropDownList) skin.FindControl("DropDownListShopCategoryCode2");
            DropDownListShopCategoryCode2.SelectedIndexChanged += DropDownListShopCategoryCode2_SelectedIndexChanged;
            DropDownListShopCategoryCode3 = (DropDownList) skin.FindControl("DropDownListShopCategoryCode3");
            DropDownListRegionCode1 = (DropDownList) skin.FindControl("DropDownListRegionCode1");
            DropDownListRegionCode1.SelectedIndexChanged += DropDownListRegionCode1_SelectedIndexChanged;
            DropDownListRegionCode2 = (DropDownList) skin.FindControl("DropDownListRegionCode2");
            DropDownListRegionCode2.SelectedIndexChanged += DropDownListRegionCode2_SelectedIndexChanged;
            DropDownListRegionCode3 = (DropDownList) skin.FindControl("DropDownListRegionCode3");
            LinkButtonFirst = (LinkButton) skin.FindControl("LinkButtonFirst");
            LinkButtonLast = (LinkButton) skin.FindControl("LinkButtonLast");
            LinkButtonNext = (LinkButton) skin.FindControl("LinkButtonNext");
            LinkButtonEnd = (LinkButton) skin.FindControl("LinkButtonEnd");
            LabelPageIndex = (Label) skin.FindControl("LabelPageIndex");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxPageNum = (TextBox) skin.FindControl("TextBoxPageNum");
            ButtonGo = (Button) skin.FindControl("ButtonGo");
            LinkButtonFirst.Click += LinkButtonFirst_Click;
            LinkButtonLast.Click += LinkButtonLast_Click;
            LinkButtonNext.Click += LinkButtonNext_Click;
            LinkButtonEnd.Click += LinkButtonEnd_Click;
            ButtonGo.Click += ButtonGo_Click;
            if (!Page.IsPostBack)
            {
            }
            DropDownListShopCategoryCode1Bind();
            DropDownListRegionCode1Bind();
            if (Common.Common.ReqStr("code") != "")
            {
                int num;
                string str = Common.Common.ReqStr("code");
                if (str.Length >= 3)
                {
                    for (num = 0; num < DropDownListShopCategoryCode1.Items.Count; num++)
                    {
                        if (DropDownListShopCategoryCode1.Items[num].Value.StartsWith(str.Substring(0, 3) + "/"))
                        {
                            DropDownListShopCategoryCode1.SelectedValue = DropDownListShopCategoryCode1.Items[num].Value;
                            break;
                        }
                    }
                    DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 6)
                {
                    num = 0;
                    while (num < DropDownListShopCategoryCode2.Items.Count)
                    {
                        if (DropDownListShopCategoryCode2.Items[num].Value.StartsWith(str.Substring(0, 6) + "/"))
                        {
                            DropDownListShopCategoryCode2.SelectedValue = DropDownListShopCategoryCode2.Items[num].Value;
                            break;
                        }
                        num++;
                    }
                    DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 9)
                {
                    for (num = 0; num < DropDownListShopCategoryCode3.Items.Count; num++)
                    {
                        if (DropDownListShopCategoryCode3.Items[num].Value.StartsWith(str.Substring(0, 9) + "/"))
                        {
                            DropDownListShopCategoryCode3.Items[num].Selected = true;
                            break;
                        }
                    }
                }
            }
            BindData();
            LabelShopProductName.Text = (GetShopCategoryName() == "-1") ? "全部" : GetShopCategoryName();
        }

        protected void LinkButtonFirst_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = "1";
            BindData();
        }

        protected void LinkButtonLast_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) - 1).ToString();
            BindData();
        }

        protected void LinkButtonNext_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) + 1).ToString();
            BindData();
        }

        protected void LinkButtonEnd_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = LabelPageCount.Text;
            BindData();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            htmlGenericControl_0 = (HtmlGenericControl) e.Item.FindControl("spanMemLoginID");
            var repeater = e.Item.FindControl("RepeaterImg") as Repeater;
            var repeater2 = e.Item.FindControl("RepeaterProduct") as Repeater;
            DataTable ensureImagePathBymemberLoginID =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetEnsureImagePathBymemberLoginID(htmlGenericControl_0.InnerText.Trim());
            if ((ensureImagePathBymemberLoginID != null) && (ensureImagePathBymemberLoginID.Rows.Count > 0))
            {
                repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
                repeater.DataBind();
            }
            string productCount = ShopSettings.GetValue("ShopMainProductCount");
            DataTable table2 =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .SearchProductByMemLoginID(htmlGenericControl_0.InnerText.Trim(), productCount);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                repeater2.DataSource = table2.DefaultView;
                repeater2.DataBind();
            }
            var image = (Image) e.Item.FindControl("ImageReputation");
            hiddenField_0 = (HiddenField) e.Item.FindControl("HiddenFieldReputation");
            var action3 = (ShopNum1_Reputation_Action) LogicFactory.CreateShopNum1_Reputation_Action();
            DataTable table3 = action3.ShopReputationSearch(hiddenField_0.Value, "0", "1");
            if ((table3 != null) && (table3.Rows.Count > 0))
            {
                image.ImageUrl = "~/" + action3.ShopReputationSearch(hiddenField_0.Value, "0", "1").Rows[0]["Pic"];
            }
        }

        public string SetShopCategoryCode()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                return DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            return "-1";
        }

        public string SetShopRegionCode()
        {
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                return DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                return DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                return DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            return "-1";
        }
    }
}