using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopWebControl
{
    public class CombinationDetail : BaseWebControl
    {

        private string string_0 = "CombinationDetail.ascx";
        private Repeater repeater_0;
        private Repeater repeater_1;
        private Repeater repeater_2;
        private Label label_0;
        private Label label_1;
        private Label label_2;
        private Label label_3;
        private Label label_4;
        private Button button_0;
        private HtmlInputText htmlInputText_0;
        private Literal literal_0;
        private Literal literal_1;
        private HtmlInputHidden htmlInputHidden_0;
        private HtmlInputHidden htmlInputHidden_1;
        private HtmlInputHidden htmlInputHidden_2;
        private HtmlInputHidden htmlInputHidden_3;
        private HtmlInputHidden htmlInputHidden_4;
        private HtmlInputHidden htmlInputHidden_5;
        private HtmlInputHidden htmlInputHidden_6;
        private Repeater repeater_3;
        private Repeater repeater_4;
        private IShopNum1_SpecProudct_Action ishopNum1_SpecProudct_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudct_Action();
        private IShopNum1_Spec_Action ishopNum1_Spec_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_Spec_Action();
        private IShopNum1_SpecProudctDetail_Action ishopNum1_SpecProudctDetail_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_SpecProudctDetail_Action();
        private DataTable dataTable_0 = null;
        public CombinationDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = this.string_0;
            }
        }
        protected override void InitializeSkin(Control skin)
        {
            this.repeater_0 = (Repeater)skin.FindControl("repImg");
            this.repeater_1 = (Repeater)skin.FindControl("repPackProduct");
            this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
            this.repeater_2 = (Repeater)skin.FindControl("OtherPackList");
            this.label_0 = (Label)skin.FindControl("lblPackName");
            this.label_1 = (Label)skin.FindControl("lblSaveMoney");
            this.label_2 = (Label)skin.FindControl("lblOldPrice");
            this.label_3 = (Label)skin.FindControl("lblSalePrice");
            this.label_4 = (Label)skin.FindControl("lblMsg");
            this.button_0 = (Button)skin.FindControl("btnBuyPack");
            this.button_0.Click += new EventHandler(this.button_0_Click);
            this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtBuyNum");
            this.literal_0 = (Literal)skin.FindControl("literalDetail");
            this.literal_1 = (Literal)skin.FindControl("literalImg");
            this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidProductGuID");
            this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidShopName");
            this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidMemloginId");
            this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidSpecId");
            this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidSpecName");
            this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidPack_Price");
            if (this.Page.IsPostBack)
            {
            }
            if (ShopNum1.Common.Common.ReqStr("pid") != "" && ShopNum1.Common.Common.ReqStr("packid") != "")
            {
                this.method_0();
            }
            if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                string a = httpCookie.Values["MemLoginID"].ToString();
                if (a == this.htmlInputHidden_2.Value)
                {
                    try
                    {
                        this.label_4.Visible = true;
                        this.label_4.Text = "自己不能购买自己的商品！";
                    }
                    catch
                    {
                    }
                    this.button_0.Enabled = false;
                }
            }
            else
            {
                try
                {
                    this.label_4.Visible = true;
                    this.label_4.Text = "未登录的用户不能购买组合套餐商品！";
                }
                catch
                {
                }
                this.button_0.Enabled = false;
            }
        }
        private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Func<bool> func = null;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    this.repeater_3 = (Repeater)e.Item.FindControl("RepeaterProductSepc");
                    this.repeater_3.ItemDataBound += new RepeaterItemEventHandler(this.repeater_3_ItemDataBound);
                    this.htmlInputHidden_3 = (HtmlInputHidden)e.Item.FindControl("hidGuId");
                    if (func == null)
                    {
                        func = new Func<bool>(this.method_1);
                    }
                    Func<bool> func2 = func;
                    func2();
                }
                catch
                {
                }
            }
        }
        private void repeater_3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    this.repeater_4 = (Repeater)e.Item.FindControl("RepeaterProductSepcDetail");
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < this.dataTable_0.Rows.Count; i++)
                    {
                        string text = this.dataTable_0.Rows[i]["specdetail"].ToString().Split(new char[]
						{
							'|'
						})[e.Item.ItemIndex].Split(new char[]
						{
							','
						})[1];
                        if (i <= 0 || !(text == this.dataTable_0.Rows[i - 1]["specdetail"].ToString().Split(new char[]
						{
							'|'
						})[e.Item.ItemIndex].Split(new char[]
						{
							','
						})[1]))
                        {
                            stringBuilder.Append(text + ",");
                        }
                    }
                    if (stringBuilder.ToString() != "")
                    {
                        DataTable detailByDGuid = this.ishopNum1_SpecProudctDetail_Action_0.GetDetailByDGuid(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1), this.htmlInputHidden_3.Value);
                        this.repeater_4.DataSource = detailByDGuid;
                        this.repeater_4.DataBind();
                    }
                    else
                    {
                        this.repeater_3.DataSource = this.dataTable_0.DefaultView;
                        this.repeater_3.DataBind();
                    }
                }
                catch
                {
                }
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            string value = this.htmlInputHidden_0.Value;
            HttpCookie httpCookie = new HttpCookie("PackAgeCookie");
            httpCookie.Values.Add("PackGuId", value);
            httpCookie.Values.Add("BuyNum", this.htmlInputText_0.Value);
            httpCookie.Values.Add("MemloginId", this.htmlInputHidden_2.Value);
            httpCookie.Values.Add("ShopName", this.htmlInputHidden_1.Value);
            httpCookie.Values.Add("PackPrice", this.label_3.Text);
            try
            {
                httpCookie.Values.Add("SpecId", this.htmlInputHidden_4.Value);
                httpCookie.Values.Add("SpecName", this.htmlInputHidden_5.Value);
                httpCookie.Values.Add("Pack_Price", this.htmlInputHidden_6.Value);
            }
            catch
            {
            }
            HttpCookie httpCookie2 = HttpSecureCookie.Encode(httpCookie);
            httpCookie2.Expires = Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
            httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
            this.Page.Response.AppendCookie(httpCookie2);
            if (this.Page.Request.Cookies["SpecificationCookie"] != null)
            {
                HttpCookie httpCookie3 = this.Page.Request.Cookies["SpecificationCookie"];
                httpCookie3.Values.Clear();
                httpCookie3.Expires = Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
                httpCookie3.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                this.Page.Response.Cookies.Add(httpCookie3);
            }
            this.Page.Response.Redirect(GetPageName.GetMainPage("ConfirmOrder.html?num=" + this.htmlInputText_0.Value + "&"));
        }
        private void method_0()
        {
            Shop_PackAge_Action shop_PackAge_Action = (Shop_PackAge_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_PackAge_Action();
            DataSet packAgeProduct = shop_PackAge_Action.GetPackAgeProduct(ShopNum1.Common.Common.ReqStr("packid"), ShopNum1.Common.Common.ReqStr("pid"));
            if (packAgeProduct != null)
            {
                DataTable dataTable = packAgeProduct.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    this.htmlInputHidden_2.Value = dataTable.Rows[0]["memloginId"].ToString();
                    this.htmlInputHidden_1.Value = dataTable.Rows[0]["shopname"].ToString();
                    this.label_0.Text = dataTable.Rows[0]["name"].ToString();
                    this.label_3.Text = dataTable.Rows[0]["SalePrice"].ToString();
                    this.label_2.Text = dataTable.Rows[0]["price"].ToString();
                    this.label_1.Text = (Convert.ToDecimal(this.label_2.Text) - Convert.ToDecimal(this.label_3.Text)).ToString();
                    this.literal_0.Text = dataTable.Rows[0]["Desc"].ToString();
                }
                this.repeater_0.DataSource = packAgeProduct.Tables[1];
                this.repeater_0.DataBind();
                if (packAgeProduct.Tables[1].Rows.Count > 0)
                {
                    this.literal_1.Text = string.Concat(new string[]
					{
						"<img id=\"ProductImgurl\" src='",
						this.Page.ResolveUrl(packAgeProduct.Tables[1].Rows[0]["originalimage"].ToString() + "_300x300.jpg"),
						"' width=\"222\" height=\"222\" onerror=\"javascript:this.src='Themes/Skin_Default/Images/noImage.gif'\" jqimg='",
						this.Page.ResolveUrl(packAgeProduct.Tables[1].Rows[0]["originalimage"].ToString()),
						"' />"
					});
                }
                this.repeater_1.DataSource = packAgeProduct.Tables[2];
                this.repeater_1.DataBind();
                this.repeater_2.DataSource = packAgeProduct.Tables[3];
                this.repeater_2.DataBind();
            }
        }
        private bool method_1()
        {
            bool result;
            if (this.htmlInputHidden_3.Value != string.Empty)
            {
                this.dataTable_0 = this.ishopNum1_SpecProudct_Action_0.dt_SpecProducts(this.htmlInputHidden_3.Value);
                if (this.dataTable_0.Rows.Count > 0)
                {
                    DataTable dataTable = this.ishopNum1_Spec_Action_0.SearchNameByGuid(this.htmlInputHidden_3.Value);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.repeater_3.DataSource = dataTable;
                        this.repeater_3.DataBind();
                    }
                    if (this.repeater_3.Items.Count > 0)
                    {
                        HtmlGenericControl htmlGenericControl = (HtmlGenericControl)this.repeater_3.Controls[this.repeater_3.Controls.Count - 1].FindControl("spanNoSelect");
                        string text = string.Empty;
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            text = text + "\"" + dataRow["specname"].ToString() + "\" ";
                        }
                        htmlGenericControl.InnerHtml = text;
                    }
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}