using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_AddScoreProduct : BaseShopWebControl
    {
        private Button ButtonAdd;
        private CheckBox CheckBoxIsHot;
        private CheckBox CheckBoxIsNew;
        private DropDownList DropDownListProductCategoryCode1;
        private DropDownList DropDownListProductCategoryCode2;
        private DropDownList DropDownListProductCategoryCode3;
        private HtmlTextArea FCKeditorDetail;
        private HiddenField HiddenFieldProduct;
        private HtmlImage ImgOrganizImg;
        private TextBox TextBoxDescription;
        private TextBox TextBoxIntegral;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxMarketPrice;
        private TextBox TextBoxName;
        private TextBox TextBoxProductNum;
        private TextBox TextBoxRepertoryCount;
        private TextBox TextBoxTitle;
        private TextBox TextBoxUnitName;
        private string skinFilename = "S_AddScoreProduct.ascx";

        public S_AddScoreProduct()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShopRank { get; set; }

        public void Add()
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            var scoreProductNew = new ShopNum1_Shop_ScoreProduct
            {
                Brief = TextBoxKeywords.Text.Trim(),
                ClickCount = 0,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                CreateUser = base.MemLoginID,
                Detail = FCKeditorDetail.Value.Replace("'", ""),
                Guid = Guid.NewGuid(),
                IsAudit = 0,
                IsDeleted = 0
            };
            if (CheckBoxIsHot.Checked)
            {
                scoreProductNew.IsHot = 1;
            }
            else
            {
                scoreProductNew.IsHot = 0;
            }
            if (CheckBoxIsNew.Checked)
            {
                scoreProductNew.IsNew = 1;
            }
            else
            {
                scoreProductNew.IsNew = 0;
            }
            scoreProductNew.IsRecommend = 0;
            scoreProductNew.IsSaled = 1;
            scoreProductNew.MemLoginID = base.MemLoginID;
            scoreProductNew.Meto_Description = TextBoxDescription.Text.Trim();
            scoreProductNew.Meto_Keywords = TextBoxKeywords.Text.Trim();
            scoreProductNew.Meto_Title = TextBoxTitle.Text.Trim();
            scoreProductNew.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductNew.ModifyUser = base.MemLoginID;
            scoreProductNew.Name = TextBoxName.Text.Trim();
            scoreProductNew.OrderID = 0;
            scoreProductNew.OriginalImge = HiddenFieldProduct.Value;
            scoreProductNew.ProductCategoryCode = GetDropDownListProductCategoryCode();
            scoreProductNew.ProductCategoryID = Convert.ToInt32(GetDropDownListProductCategoryID());
            scoreProductNew.ProductCategoryName = GetDropDownListProductCategoryName();
            scoreProductNew.RepertoryCount = Convert.ToInt32(TextBoxRepertoryCount.Text.Trim());
            scoreProductNew.RepertoryNumber = TextBoxProductNum.Text.Trim();
            scoreProductNew.RepertoryWarnCount = 0;
            scoreProductNew.SaleTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductNew.Score = Convert.ToInt32(TextBoxIntegral.Text.Trim());
            scoreProductNew.ShopID = "";
            scoreProductNew.SmallImage = "";
            scoreProductNew.ThumbImage = "";
            scoreProductNew.UnitName = TextBoxUnitName.Text.Trim();
            scoreProductNew.Weight = 0;
            scoreProductNew.MarketPrice = Convert.ToDecimal(TextBoxMarketPrice.Text.Trim());
            scoreProductNew.HaveSale = 0;
            try
            {
                if (action.Add(scoreProductNew) > 0)
                {
                    MessageBox.Show("红包商品添加成功");
                    ClearControl();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!CheckNumber(TextBoxRepertoryCount.Text.Trim(), "int"))
            {
                MessageBox.Show("库存必须为整数,请填写正确格式！");
            }
            else if (!CheckNumber(TextBoxMarketPrice.Text.Trim(), "Decimal"))
            {
                MessageBox.Show("市场价格式错误，请填写正确格式！");
            }
            else if (!CheckNumber(TextBoxIntegral.Text.Trim(), "int"))
            {
                MessageBox.Show("兑换红包必须为整数，请填写正确格式！");
            }
            else if (
                !((Page.Request.QueryString["guid"] == null) ||
                  string.IsNullOrEmpty(Page.Request.QueryString["guid"])))
            {
                Edit();
            }
            else
            {
                try
                {
                    Add();
                }
                catch (Exception)
                {
                }
            }
        }

        public bool CheckNumber(string value, string valueType)
        {
            string str = valueType;
            if (str != null)
            {
                if (!(str == "int"))
                {
                    if (str == "Decimal")
                    {
                        decimal result = 0M;
                        return decimal.TryParse(value, out result);
                    }
                }
                else
                {
                    int num2 = 0;
                    return int.TryParse(value, out num2);
                }
            }
            return false;
        }

        public void ClearControl()
        {
            DropDownListProductCategoryCode1.SelectedValue = "-1";
            DropDownListProductCategoryCode2.Visible = false;
            DropDownListProductCategoryCode3.Visible = false;
            TextBoxName.Text = "";
            TextBoxProductNum.Text = "";
            TextBoxUnitName.Text = "";
            TextBoxRepertoryCount.Text = "";
            TextBoxMarketPrice.Text = "";
            TextBoxIntegral.Text = "";
            FCKeditorDetail.Value = "";
            TextBoxTitle.Text = "";
            TextBoxKeywords.Text = "";
            TextBoxDescription.Text = "";
        }

        protected void DropDownListProductCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductCategoryCode2.Visible = false;
            DropDownListProductCategoryCode3.Visible = false;
            if (DropDownListProductCategoryCode1.SelectedValue != "-1")
            {
                method_0(DropDownListProductCategoryCode1.SelectedValue.Split(new[] {'/'})[1],
                    DropDownListProductCategoryCode2);
            }
        }

        protected void DropDownListProductCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductCategoryCode3.Visible = false;
            if (DropDownListProductCategoryCode2.SelectedValue != "-1")
            {
                method_0(DropDownListProductCategoryCode2.SelectedValue.Split(new[] {'/'})[1],
                    DropDownListProductCategoryCode3);
            }
        }

        protected void DropDownListProductCategoryCode1Bind()
        {
            DropDownListProductCategoryCode2.Visible = false;
            DropDownListProductCategoryCode3.Visible = false;
            method_0("0", DropDownListProductCategoryCode1);
        }

        public void Edit()
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            var scoreProductNew = new ShopNum1_Shop_ScoreProduct
            {
                Brief = "",
                Detail = FCKeditorDetail.Value.Replace("'", "")
            };
            if (CheckBoxIsHot.Checked)
            {
                scoreProductNew.IsHot = 1;
            }
            else
            {
                scoreProductNew.IsHot = 0;
            }
            if (CheckBoxIsNew.Checked)
            {
                scoreProductNew.IsNew = 1;
            }
            else
            {
                scoreProductNew.IsNew = 0;
            }
            scoreProductNew.MarketPrice = Convert.ToDecimal(TextBoxMarketPrice.Text.Trim());
            scoreProductNew.Meto_Description = TextBoxDescription.Text.Trim();
            scoreProductNew.Meto_Keywords = TextBoxKeywords.Text.Trim();
            scoreProductNew.Meto_Title = TextBoxTitle.Text.Trim();
            scoreProductNew.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductNew.ModifyUser = base.MemLoginID;
            scoreProductNew.Name = TextBoxName.Text.Trim();
            scoreProductNew.OriginalImge = HiddenFieldProduct.Value;
            scoreProductNew.ProductCategoryCode = GetDropDownListProductCategoryCode();
            scoreProductNew.ProductCategoryID = Convert.ToInt32(GetDropDownListProductCategoryID());
            scoreProductNew.ProductCategoryName = GetDropDownListProductCategoryName();
            scoreProductNew.RepertoryCount = Convert.ToInt32(TextBoxRepertoryCount.Text.Trim());
            scoreProductNew.RepertoryNumber = TextBoxProductNum.Text.Trim();
            scoreProductNew.Score = Convert.ToInt32(TextBoxIntegral.Text.Trim());
            scoreProductNew.SmallImage = "";
            scoreProductNew.ThumbImage = "";
            scoreProductNew.UnitName = TextBoxUnitName.Text.Trim();
            scoreProductNew.Weight = 0;
            scoreProductNew.Guid = new Guid(Page.Request.QueryString["guid"]);
            try
            {
                if (action.Update(scoreProductNew) > 0)
                {
                    MessageBox.Show("红包商品更新成功");
                    GetEditInfo();
                }
                else
                {
                    MessageBox.Show("红包商品更新失败");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("红包商品更新失败");
            }
        }

        public string GetDropDownListProductCategoryCode()
        {
            if (DropDownListProductCategoryCode3.Visible && (DropDownListProductCategoryCode3.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListProductCategoryCode2.Visible && (DropDownListProductCategoryCode2.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            if (DropDownListProductCategoryCode1.Visible && (DropDownListProductCategoryCode1.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            return "-1";
        }

        public string GetDropDownListProductCategoryID()
        {
            if (DropDownListProductCategoryCode3.Visible && (DropDownListProductCategoryCode3.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode3.SelectedValue.Split(new[] {'/'})[1];
            }
            if (DropDownListProductCategoryCode2.Visible && (DropDownListProductCategoryCode2.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode2.SelectedValue.Split(new[] {'/'})[1];
            }
            if (DropDownListProductCategoryCode1.Visible && (DropDownListProductCategoryCode1.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode1.SelectedValue.Split(new[] {'/'})[1];
            }
            return "-1";
        }

        public string GetDropDownListProductCategoryName()
        {
            if (DropDownListProductCategoryCode3.Visible && (DropDownListProductCategoryCode3.SelectedValue != "-1"))
            {
                return (DropDownListProductCategoryCode1.SelectedItem.Text + "/" +
                        DropDownListProductCategoryCode2.SelectedItem.Text + "/" +
                        DropDownListProductCategoryCode3.SelectedItem.Text);
            }
            if (DropDownListProductCategoryCode2.Visible && (DropDownListProductCategoryCode2.SelectedValue != "-1"))
            {
                return (DropDownListProductCategoryCode1.SelectedItem.Text + "/" +
                        DropDownListProductCategoryCode2.SelectedItem.Text);
            }
            if (DropDownListProductCategoryCode1.Visible && (DropDownListProductCategoryCode1.SelectedValue != "-1"))
            {
                return DropDownListProductCategoryCode1.SelectedItem.Text;
            }
            return "-1";
        }

        public void GetEditInfo()
        {
            DataTable infoByGuid =
                ((ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action())
                    .GetInfoByGuid(Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                int num;
                string str = infoByGuid.Rows[0]["ProductCategoryCode"].ToString();
                if (str.Length >= 3)
                {
                    for (num = 0; num < DropDownListProductCategoryCode1.Items.Count; num++)
                    {
                        if (DropDownListProductCategoryCode1.Items[num].Value.StartsWith(str.Substring(0, 3) + "/"))
                        {
                            DropDownListProductCategoryCode1.SelectedValue =
                                DropDownListProductCategoryCode1.Items[num].Value;
                        }
                    }
                    DropDownListProductCategoryCode1_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 6)
                {
                    for (num = 0; num < DropDownListProductCategoryCode2.Items.Count; num++)
                    {
                        if (DropDownListProductCategoryCode2.Items[num].Value.StartsWith(str.Substring(0, 6) + "/"))
                        {
                            DropDownListProductCategoryCode2.SelectedValue =
                                DropDownListProductCategoryCode2.Items[num].Value;
                        }
                    }
                    DropDownListProductCategoryCode2_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 9)
                {
                    for (num = 0; num < DropDownListProductCategoryCode3.Items.Count; num++)
                    {
                        if (DropDownListProductCategoryCode3.Items[num].Value.StartsWith(str.Substring(0, 9) + "/"))
                        {
                            DropDownListProductCategoryCode3.SelectedValue =
                                DropDownListProductCategoryCode3.Items[num].Value;
                        }
                    }
                }
                if (!Page.IsPostBack)
                {
                    ViewState["ProductCategoryID"] = GetDropDownListProductCategoryID();
                }
                TextBoxName.Text = infoByGuid.Rows[0]["Name"].ToString();
                if (infoByGuid.Rows[0]["IsNew"].ToString() == "1")
                {
                    CheckBoxIsNew.Checked = true;
                }
                else
                {
                    CheckBoxIsNew.Checked = false;
                }
                if (infoByGuid.Rows[0]["IsHot"].ToString() == "1")
                {
                    CheckBoxIsHot.Checked = true;
                }
                else
                {
                    CheckBoxIsHot.Checked = false;
                }
                TextBoxProductNum.Text = infoByGuid.Rows[0]["RepertoryNumber"].ToString();
                TextBoxUnitName.Text = infoByGuid.Rows[0]["UnitName"].ToString();
                TextBoxRepertoryCount.Text = infoByGuid.Rows[0]["RepertoryCount"].ToString();
                TextBoxMarketPrice.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
                TextBoxIntegral.Text = infoByGuid.Rows[0]["Score"].ToString();
                FCKeditorDetail.Value = infoByGuid.Rows[0]["Detail"].ToString();
                HiddenFieldProduct.Value = infoByGuid.Rows[0]["OriginalImge"].ToString();
                TextBoxTitle.Text = infoByGuid.Rows[0]["Meto_Title"].ToString();
                TextBoxKeywords.Text = infoByGuid.Rows[0]["Meto_Keywords"].ToString();
                TextBoxDescription.Text = infoByGuid.Rows[0]["Meto_Description"].ToString();
                ImgOrganizImg.Src = infoByGuid.Rows[0]["OriginalImge"].ToString();
                TextBoxMarketPrice.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DropDownListProductCategoryCode1 = (DropDownList) skin.FindControl("DropDownListProductCategoryCode1");
            DropDownListProductCategoryCode1.SelectedIndexChanged +=
                DropDownListProductCategoryCode1_SelectedIndexChanged;
            DropDownListProductCategoryCode2 = (DropDownList) skin.FindControl("DropDownListProductCategoryCode2");
            DropDownListProductCategoryCode2.SelectedIndexChanged +=
                DropDownListProductCategoryCode2_SelectedIndexChanged;
            DropDownListProductCategoryCode3 = (DropDownList) skin.FindControl("DropDownListProductCategoryCode3");
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            CheckBoxIsNew = (CheckBox) skin.FindControl("CheckBoxIsNew");
            CheckBoxIsHot = (CheckBox) skin.FindControl("CheckBoxIsHot");
            TextBoxProductNum = (TextBox) skin.FindControl("TextBoxProductNum");
            TextBoxUnitName = (TextBox) skin.FindControl("TextBoxUnitName");
            TextBoxRepertoryCount = (TextBox) skin.FindControl("TextBoxRepertoryCount");
            TextBoxMarketPrice = (TextBox) skin.FindControl("TextBoxMarketPrice");
            TextBoxIntegral = (TextBox) skin.FindControl("TextBoxIntegral");
            FCKeditorDetail = (HtmlTextArea) skin.FindControl("FCKeditorDetail");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            ButtonAdd = (Button) skin.FindControl("ButtonAdd");
            ButtonAdd.Click += ButtonAdd_Click;
            HiddenFieldProduct = (HiddenField) skin.FindControl("HiddenFieldProduct");
            ImgOrganizImg = (HtmlImage) skin.FindControl("ImgOrganizImg");
            DropDownListProductCategoryCode1Bind();
            if (!((Page.Request.QueryString["guid"] == null) || string.IsNullOrEmpty(Page.Request.QueryString["guid"])))
            {
                ButtonAdd.Text = "编辑商品";
                GetEditInfo();
            }
            else
            {
                ButtonAdd.Text = "上架商品";
            }
        }

        protected void method_0(string string_2, DropDownList dropDownList_3)
        {
            DataTable category =
                ((ShopNum1_ScoreProductCategory_Action) LogicFactory.CreateShopNum1_ScoreProductCategory_Action())
                    .GetCategory(string_2);
            dropDownList_3.Visible = true;
            dropDownList_3.Items.Clear();
            dropDownList_3.Items.Add(new ListItem("-请选择-", "-1"));
            if ((category != null) && (category.Rows.Count > 0))
            {
                for (int i = 0; i < category.Rows.Count; i++)
                {
                    dropDownList_3.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(),
                        category.Rows[i]["Code"] + "/" + category.Rows[i]["ID"]));
                }
            }
            else
            {
                dropDownList_3.Visible = false;
            }
        }
    }
}