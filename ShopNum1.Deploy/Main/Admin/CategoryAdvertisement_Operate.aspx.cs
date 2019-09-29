using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryAdvertisement_Operate : PageBase, IRequiresSessionState
    {
      
        private ShopNum1_Advertisement_Action shopNum1_Advertisement_Action_0 = ((ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action());


        public void Add()
        {
            ShopNum1_CategoryAdvertisement advertisement = new ShopNum1_CategoryAdvertisement
            {
                AdvertisementName = this.TextBoxPageName.Text.Trim(),
                Width = 0,
                Height = 0,
                AdvertisementDPic = this.TextBoxDefaultPic.Text.Trim(),
                CategoryAdID = int.Parse(this.TextBoxCategoryAdID.Text),
                CategoryType = this.DropDownListAdPageName.SelectedValue,
                CategoryCode = this.HiddenFieldCategoryCode.Value,
                CategoryName = this.returnCategoryName(),
                AdDefaultLike = "http://" + this.TextBoxDefaultLikeAddress.Text.Trim().ToLower().Replace("http://", ""),
                AdvertisementPrice = Convert.ToDecimal(this.TextBoxAdPrice.Text.Trim()),
                AdIntroduce = this.TextBoxAdIntroduce.Text.Trim(),
                Advertisementflow = new int?(int.Parse(this.TextBoxAdvertisementflow.Text.Trim())),
                IsEnabled = 1,
                IsShow = this.CheckBoxIsShow.Checked ? 1 : 0,
                IsBuy = 0,
                CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
            };
            ShopNum1_CategoryAdvertisement_Action action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
            if (action.Add(advertisement) > 0)
            {
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdvertisement_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.returnCategoryCode();
            if (this.hiddenFieldGuid.Value != "0")
            {
                this.Edit();
            }
            else
            {
                this.Add();
            }
        }

        public string CategoryType(object object_0)
        {
            switch (object_0.ToString())
            {
                case "1":
                    return "商品分类";

                case "2":
                    return "分类信息分类";

                case "3":
                    return "供求分类";

                case "4":
                    return "店铺分类";

                case "5":
                    return "资讯分类";

                case "6":
                    return "品牌分类";
            }
            return "非法页面";
        }

        protected void DropDownListAdID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListAdID.SelectedValue != "-1")
            {
                this.TextBoxCategoryAdID.Text = this.DropDownListAdID.SelectedValue;
            }
        }

        protected void DropDownListAdPageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListAdID.Items.Clear();
            this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
            this.DropDownListCategory1.Items.Clear();
            this.DropDownListCategory2.Items.Clear();
            this.DropDownListCategory3.Items.Clear();
            this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
            this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
            this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListAdPageName.SelectedValue != "-1")
            {
                DataTable table = ((ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action()).Search(this.DropDownListAdPageName.SelectedValue, "-1");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    this.DropDownListAdID.Items.Clear();
                    this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        ListItem item2 = new ListItem
                        {
                            Text = table.Rows[i]["CategoryAdName"].ToString(),
                            Value = table.Rows[i]["ID"].ToString()
                        };
                        this.DropDownListAdID.Items.Add(item2);
                    }
                }
                ShopNum1_CategoryAdvertisement_Action action1 = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
                if (this.DropDownListAdPageName.SelectedValue == "1")
                {
                    this.method_5("0", this.DropDownListCategory1);
                }
                if (this.DropDownListAdPageName.SelectedValue == "2")
                {
                    this.method_5("0", this.DropDownListCategory1);
                }
                if (this.DropDownListAdPageName.SelectedValue == "3")
                {
                    this.method_5("0", this.DropDownListCategory1);
                }
                if (this.DropDownListAdPageName.SelectedValue == "4")
                {
                    this.method_5("0", this.DropDownListCategory1);
                }
                if (this.DropDownListAdPageName.SelectedValue == "6")
                {
                    this.method_5("0", this.DropDownListCategory1);
                }
                if (this.DropDownListAdPageName.SelectedValue == "5")
                {
                    this.DropDownListCategory1.Items.Clear();
                    this.DropDownListCategory1.Items.Clear();
                    this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
                    DataTable table2 = ((ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(0, 0);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        foreach (DataRow row in table2.Rows)
                        {
                            ListItem item = new ListItem
                            {
                                Text = row["Name"].ToString(),
                                Value = row["ID"].ToString()
                            };
                            this.DropDownListCategory1.Items.Add(item);
                        }
                    }
                }
            }
        }

        protected void DropDownListCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListCategory1.SelectedValue == "-1")
            {
                this.DropDownListCategory2.Items.Clear();
                this.DropDownListCategory3.Items.Clear();
                this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
                this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            }
            else if (this.DropDownListAdPageName.SelectedValue != "5")
            {
                this.method_5(this.DropDownListCategory1.SelectedValue.Split(new char[] { '/' })[1], this.DropDownListCategory2);
            }
            else
            {
                DataTable table = ((ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(Convert.ToInt32(this.DropDownListCategory1.SelectedValue), 0);
                this.DropDownListCategory2.Items.Clear();
                this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
                foreach (DataRow row in table.Rows)
                {
                    ListItem item = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim()
                    };
                    this.DropDownListCategory2.Items.Add(item);
                }
            }
        }

        protected void DropDownListCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListCategory2.SelectedValue == "-1")
            {
                this.DropDownListCategory3.Items.Clear();
                this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            }
            else if (this.DropDownListAdPageName.SelectedValue != "5")
            {
                this.method_5(this.DropDownListCategory2.SelectedValue.Split(new char[] { '/' })[1], this.DropDownListCategory3);
            }
            else
            {
                DataTable table = ((ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(Convert.ToInt32(this.DropDownListCategory2.SelectedValue), 0);
                this.DropDownListCategory3.Items.Clear();
                this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
                foreach (DataRow row in table.Rows)
                {
                    ListItem item = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim()
                    };
                    this.DropDownListCategory3.Items.Add(item);
                }
            }
        }

        public void Edit()
        {
            ShopNum1_CategoryAdvertisement advertisement = new ShopNum1_CategoryAdvertisement
            {
                AdvertisementName = this.TextBoxPageName.Text.Trim(),
                Width = 0,
                Height = 0,
                AdvertisementDPic = this.TextBoxDefaultPic.Text.Trim(),
                CategoryAdID = int.Parse(this.TextBoxCategoryAdID.Text),
                CategoryType = this.DropDownListAdPageName.SelectedValue,
                CategoryCode = this.HiddenFieldCategoryCode.Value,
                CategoryName = this.returnCategoryName(),

                AdDefaultLike = "http://" + this.TextBoxDefaultLikeAddress.Text.Trim().ToLower().Replace("http://", ""),
                AdvertisementPrice = Convert.ToDecimal(this.TextBoxAdPrice.Text.Trim()),
                AdIntroduce = this.TextBoxAdIntroduce.Text.Trim(),
                Advertisementflow = 0,
                IsEnabled = 1,
                IsShow = this.CheckBoxIsShow.Checked ? 1 : 0,
                IsBuy = 0,
                ID = int.Parse(this.hiddenFieldGuid.Value)
            };
            ShopNum1_CategoryAdvertisement_Action action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
            if (action.Updata(advertisement) > 0)
            {
                base.Response.Redirect("CategoryAdvertisement_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        public void GetEditInfo()
        {
            string str = string.Empty;
            ShopNum1_CategoryAdvertisement_Action action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
            DataTable table = action.Search(this.hiddenFieldGuid.Value);
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.TextBoxPageName.Text = table.Rows[0]["AdvertisementName"].ToString();
                this.DropDownListAdPageName.SelectedValue = table.Rows[0]["CategoryType"].ToString();
                this.DropDownListAdPageName_SelectedIndexChanged(null, null);
                this.DropDownListAdID.SelectedValue = table.Rows[0]["CategoryAdID"].ToString();
                this.TextBoxCategoryAdID.Text = table.Rows[0]["CategoryAdID"].ToString();
                this.TextBoxDefaultPic.Text = table.Rows[0]["AdvertisementDPic"].ToString();
                this.ImageOriginalImge2.Src = this.Page.ResolveUrl("~/ImgUpload/" + table.Rows[0]["AdvertisementDPic"].ToString());
                this.TextBoxDefaultLikeAddress.Text = table.Rows[0]["AdDefaultLike"].ToString();
                this.TextBoxAdPrice.Text = table.Rows[0]["AdvertisementPrice"].ToString();
                this.TextBoxAdIntroduce.Text = table.Rows[0]["AdIntroduce"].ToString();
                this.TextBoxAdvertisementflow.Text = table.Rows[0]["Advertisementflow"].ToString();
                if (table.Rows[0]["IsShow"].ToString() == "0")
                {
                    this.CheckBoxIsShow.Checked = false;
                }
                str = table.Rows[0]["CategoryCode"].ToString();
            }
            if (!(this.DropDownListAdPageName.SelectedValue != "5"))
            {
                string fatherIDByID = string.Empty;
                string str2 = string.Empty;
                fatherIDByID = action.GetFatherIDByID(str);
                if (((fatherIDByID != null) && (fatherIDByID != string.Empty)) && (fatherIDByID != "0"))
                {
                    str2 = action.GetFatherIDByID(fatherIDByID);
                    if (((str2 != null) && (str2 != string.Empty)) && (str2 != "0"))
                    {
                        this.DropDownListCategory1.SelectedValue = str2;
                        this.DropDownListCategory2.SelectedValue = fatherIDByID;
                        this.DropDownListCategory3.SelectedValue = str;
                    }
                    else
                    {
                        this.DropDownListCategory1.SelectedValue = fatherIDByID;
                        this.DropDownListCategory2.SelectedValue = str;
                    }
                }
                else
                {
                    this.DropDownListCategory1.SelectedValue = str;
                }
            }
            else
            {
                int num;
                if (str.Length >= 3)
                {
                    for (num = 0; num < this.DropDownListCategory1.Items.Count; num++)
                    {
                        if (this.DropDownListCategory1.Items[num].Value.ToString().StartsWith(str.Substring(0, 3) + "/"))
                        {
                            this.DropDownListCategory1.SelectedValue = this.DropDownListCategory1.Items[num].Value.ToString();
                            break;
                        }
                    }
                    this.DropDownListCategory1_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 6)
                {
                    num = 0;
                    while (num < this.DropDownListCategory2.Items.Count)
                    {
                        if (this.DropDownListCategory2.Items[num].Value.ToString().StartsWith(str.Substring(0, 6) + "/"))
                        {
                            this.DropDownListCategory2.SelectedValue = this.DropDownListCategory2.Items[num].Value.ToString();
                            break;
                        }
                        num++;
                    }
                    this.DropDownListCategory2_SelectedIndexChanged(null, null);
                }
                if (str.Length >= 9)
                {
                    for (num = 0; num < this.DropDownListCategory3.Items.Count; num++)
                    {
                        if (this.DropDownListCategory3.Items[num].Value.ToString().StartsWith(str.Substring(0, 9) + "/"))
                        {
                            this.DropDownListCategory3.SelectedValue = this.DropDownListCategory3.Items[num].Value.ToString();
                            break;
                        }
                    }
                }
            }
        }

        private void method_5(string string_4, DropDownList dropDownList_0)
        {
            string str = string.Empty;
            if (this.DropDownListAdPageName.SelectedValue == "1")
            {
                str = "ShopNum1_ProductCategory";
            }
            if (this.DropDownListAdPageName.SelectedValue == "2")
            {
                str = "ShopNum1_Category";
            }
            if (this.DropDownListAdPageName.SelectedValue == "3")
            {
                str = "ShopNum1_SupplyDemandCategory";
            }
            if (this.DropDownListAdPageName.SelectedValue == "4")
            {
                str = "ShopNum1_ShopCategory";
            }
            if (this.DropDownListAdPageName.SelectedValue == "6")
            {
                str = "ShopNum1_ProductCategory";
            }
            ShopNum1_Brand_Action action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            action.TableName = str;
            DataTable productCategoryCode = action.GetProductCategoryCode(string_4);
            dropDownList_0.Items.Clear();
            dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
            if ((productCategoryCode != null) && (productCategoryCode.Rows.Count > 0))
            {
                for (int i = 0; i < productCategoryCode.Rows.Count; i++)
                {
                    dropDownList_0.Items.Add(new ListItem(productCategoryCode.Rows[i]["Name"].ToString(), productCategoryCode.Rows[i]["Code"].ToString() + "/" + productCategoryCode.Rows[i]["ID"].ToString()));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", "");
            if (!this.Page.IsPostBack && (this.hiddenFieldGuid.Value != "0"))
            {
                this.LabelPageTitle.Text = "编辑分类广告";
                this.GetEditInfo();
            }
        }

        public void returnCategoryCode()
        {
            if (this.DropDownListAdPageName.SelectedValue != "5")
            {
                if (this.DropDownListCategory3.SelectedValue != "-1")
                {
                    this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue.Split(new char[] { '/' })[0];
                }
                else if (this.DropDownListCategory2.SelectedValue != "-1")
                {
                    this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue.Split(new char[] { '/' })[0];
                }
                else if (this.DropDownListCategory1.SelectedValue != "-1")
                {
                    this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue.Split(new char[] { '/' })[0];
                }
                else
                {
                    this.HiddenFieldCategoryCode.Value = "-1";
                }
            }
            else if (this.DropDownListCategory3.SelectedValue != "-1")
            {
                this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue;
            }
            else if (this.DropDownListCategory2.SelectedValue != "-1")
            {
                this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue;
            }
            else if (this.DropDownListCategory1.SelectedValue != "-1")
            {
                this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue;
            }
            else
            {
                this.HiddenFieldCategoryCode.Value = "-1";
            }
        }

        public string returnCategoryName()
        {
            if (this.DropDownListAdPageName.SelectedValue != "5")
            {
                if (this.DropDownListCategory3.SelectedValue != "-1")
                {
                    return (this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text + "/" + this.DropDownListCategory3.SelectedItem.Text);
                }
                if (this.DropDownListCategory2.SelectedValue != "-1")
                {
                    return (this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text);
                }
                if (this.DropDownListCategory1.SelectedValue != "-1")
                {
                    return this.DropDownListCategory1.SelectedItem.Text;
                }
                return "";
            }
            if (this.DropDownListCategory3.SelectedValue != "-1")
            {
                return (this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text + "/" + this.DropDownListCategory3.SelectedItem.Text);
            }
            if (this.DropDownListCategory2.SelectedValue != "-1")
            {
                return (this.DropDownListCategory1.SelectedItem.Text + "/" + this.DropDownListCategory2.SelectedItem.Text);
            }
            if (this.DropDownListCategory1.SelectedValue != "-1")
            {
                return this.DropDownListCategory1.SelectedItem.Text;
            }
            return "";
        }
    }
}