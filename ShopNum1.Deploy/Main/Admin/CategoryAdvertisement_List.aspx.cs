using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryAdvertisement_List : PageBase, IRequiresSessionState
    {
        public void BindGrid()
        {
            returnCategoryCode();
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("CategoryAdvertisement_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_CategoryAdvertisement_Action) LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_CategoryAdvertisement_Action) LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete(commandArgument) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdvertisement_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdvertisement_SearchDetail.aspx?guid=" + CheckGuid.Value);
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

        protected void DropDownListAdPageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListAdID.Items.Clear();
            DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
            DropDownListCategory1.Items.Clear();
            DropDownListCategory2.Items.Clear();
            DropDownListCategory3.Items.Clear();
            DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
            DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
            DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListAdPageName.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_CategoryAdID_Action) LogicFactory.CreateShopNum1_CategoryAdID_Action()).Search(
                        DropDownListAdPageName.SelectedValue, "-1");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DropDownListAdID.Items.Clear();
                    DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        var item2 = new ListItem
                            {
                                Text = table.Rows[i]["CategoryAdName"].ToString(),
                                Value = table.Rows[i]["ID"].ToString()
                            };
                        DropDownListAdID.Items.Add(item2);
                    }
                }
                var action1 =
                    (ShopNum1_CategoryAdvertisement_Action) LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
                if (DropDownListAdPageName.SelectedValue == "1")
                {
                    method_5("0", DropDownListCategory1);
                }
                if (DropDownListAdPageName.SelectedValue == "2")
                {
                    method_5("0", DropDownListCategory1);
                }
                if (DropDownListAdPageName.SelectedValue == "3")
                {
                    method_5("0", DropDownListCategory1);
                }
                if (DropDownListAdPageName.SelectedValue == "4")
                {
                    method_5("0", DropDownListCategory1);
                }
                if (DropDownListAdPageName.SelectedValue == "6")
                {
                    method_5("0", DropDownListCategory1);
                }
                if (DropDownListAdPageName.SelectedValue == "5")
                {
                    DropDownListCategory1.Items.Clear();
                    DropDownListCategory1.Items.Clear();
                    DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
                    DataTable table2 =
                        ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(
                            0, 0);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        foreach (DataRow row in table2.Rows)
                        {
                            var item = new ListItem
                                {
                                    Text = row["Name"].ToString(),
                                    Value = row["ID"].ToString()
                                };
                            DropDownListCategory1.Items.Add(item);
                        }
                    }
                }
            }
        }

        protected void DropDownListCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory1.SelectedValue == "-1")
            {
                DropDownListCategory2.Items.Clear();
                DropDownListCategory3.Items.Clear();
                DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
                DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            }
            else if (DropDownListAdPageName.SelectedValue != "5")
            {
                method_5(DropDownListCategory1.SelectedValue.Split(new[] {'/'})[1], DropDownListCategory2);
            }
            else
            {
                DataTable table =
                    ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(
                        Convert.ToInt32(DropDownListCategory1.SelectedValue), 0);
                DropDownListCategory2.Items.Clear();
                DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
                foreach (DataRow row in table.Rows)
                {
                    var item = new ListItem
                        {
                            Text = row["Name"].ToString(),
                            Value = row["ID"].ToString().Trim()
                        };
                    DropDownListCategory2.Items.Add(item);
                }
            }
        }

        protected void DropDownListCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory2.SelectedValue == "-1")
            {
                DropDownListCategory3.Items.Clear();
                DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
            }
            else if (DropDownListAdPageName.SelectedValue != "5")
            {
                method_5(DropDownListCategory2.SelectedValue.Split(new[] {'/'})[1], DropDownListCategory3);
            }
            else
            {
                DataTable table =
                    ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).Search(
                        Convert.ToInt32(DropDownListCategory2.SelectedValue), 0);
                DropDownListCategory3.Items.Clear();
                DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
                foreach (DataRow row in table.Rows)
                {
                    var item = new ListItem
                        {
                            Text = row["Name"].ToString(),
                            Value = row["ID"].ToString().Trim()
                        };
                    DropDownListCategory3.Items.Add(item);
                }
            }
        }

        public string IsBuy(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未购买";
            }
            return "已购买";
        }

        public string IsShow(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "不显示";
            }
            return "显示";
        }

        private void method_5(string string_4, DropDownList dropDownList_0)
        {
            string str = string.Empty;
            if (DropDownListAdPageName.SelectedValue == "1")
            {
                str = "ShopNum1_ProductCategory";
            }
            if (DropDownListAdPageName.SelectedValue == "2")
            {
                str = "ShopNum1_Category";
            }
            if (DropDownListAdPageName.SelectedValue == "3")
            {
                str = "ShopNum1_SupplyDemandCategory";
            }
            if (DropDownListAdPageName.SelectedValue == "4")
            {
                str = "ShopNum1_ShopCategory";
            }
            if (DropDownListAdPageName.SelectedValue == "6")
            {
                str = "ShopNum1_ProductCategory";
            }
            var action = (ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action();
            action.TableName = str;
            DataTable productCategoryCode = action.GetProductCategoryCode(string_4);
            dropDownList_0.Items.Clear();
            dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
            if ((productCategoryCode != null) && (productCategoryCode.Rows.Count > 0))
            {
                for (int i = 0; i < productCategoryCode.Rows.Count; i++)
                {
                    dropDownList_0.Items.Add(new ListItem(productCategoryCode.Rows[i]["Name"].ToString(),
                                                          productCategoryCode.Rows[i]["Code"] + "/" +
                                                          productCategoryCode.Rows[i]["ID"]));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
            BindGrid();
        }

        public void returnCategoryCode()
        {
            if (DropDownListAdPageName.SelectedValue != "5")
            {
                if (DropDownListCategory3.SelectedValue != "-1")
                {
                    HiddenFieldCategoryCode.Value = DropDownListCategory3.SelectedValue.Split(new[] {'/'})[0];
                }
                else if (DropDownListCategory2.SelectedValue != "-1")
                {
                    HiddenFieldCategoryCode.Value = DropDownListCategory2.SelectedValue.Split(new[] {'/'})[0];
                }
                else if (DropDownListCategory1.SelectedValue != "-1")
                {
                    HiddenFieldCategoryCode.Value = DropDownListCategory1.SelectedValue.Split(new[] {'/'})[0];
                }
                else
                {
                    HiddenFieldCategoryCode.Value = "-1";
                }
            }
            else if (DropDownListCategory3.SelectedValue != "-1")
            {
                HiddenFieldCategoryCode.Value = DropDownListCategory3.SelectedValue;
            }
            else if (DropDownListCategory2.SelectedValue != "-1")
            {
                HiddenFieldCategoryCode.Value = DropDownListCategory2.SelectedValue;
            }
            else if (DropDownListCategory1.SelectedValue != "-1")
            {
                HiddenFieldCategoryCode.Value = DropDownListCategory1.SelectedValue;
            }
            else
            {
                HiddenFieldCategoryCode.Value = "-1";
            }
        }
    }
}