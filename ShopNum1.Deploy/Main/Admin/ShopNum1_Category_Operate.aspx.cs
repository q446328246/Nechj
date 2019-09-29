using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_Category_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";


        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ButtonConfirm.ToolTip == "Update")
            {
                method_11();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                method_9();
                BindData();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            method_10();
        }

        private void method_10()
        {
            TextBoxName.Text = string.Empty;
            TextBoxKeywords.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            TextBoxOrderID.Text = (method_7() + 1).ToString();
            CheckBoxIsShow.Checked = true;
        }

        private void method_11()
        {
            var category = new ShopNum1_Category
                {
                    ID = Convert.ToInt32(hiddenFieldGuid.Value.Replace("'", "")),
                    Name = TextBoxName.Text.Trim(),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text),
                    Description = TextBoxDescription.Text.Trim(),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            if (CheckBoxIsShow.Checked)
            {
                category.IsShow = 1;
            }
            else
            {
                category.IsShow = 0;
            }
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            if (action.UpdateCatrgoryInfoCategory(category) > 0)
            {
                ShopNum1_CategoryChecked_Action.CategoryTable = null;
                base.Response.Redirect("ShopNum1_Category_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        private void BindData()
        {
            DropDownListFatherCateGory.Items.Clear();
            var item = new ListItem
                {
                    Text = "顶级分类",
                    Value = "0"
                };
            DropDownListFatherCateGory.Items.Add(item);
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            foreach (DataRow row in action.SearchtProductCategory(0, 0).Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString()
                    };
                DropDownListFatherCateGory.Items.Add(item2);
                method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private void method_6(int int_0)
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            foreach (DataRow row in action.SearchtProductCategory(int_0, 0).Rows)
            {
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                var item = new ListItem
                    {
                        Text = str + row["Name"],
                        Value = row["ID"].ToString()
                    };
                DropDownListFatherCateGory.Items.Add(item);
                method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private int method_7()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Category");
        }

        private void method_8()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DataTable productCategoryByID = action.GetProductCategoryByID(hiddenFieldGuid.Value);
            TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
            TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
            DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
            DropDownListFatherCateGory.Enabled = false;
            if (productCategoryByID.Rows[0]["IsShow"].ToString() == "1")
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }

        private void method_9()
        {
            var category = new ShopNum1_ProductCategory
                {
                    Name = TextBoxName.Text.Trim(),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text)
                };
            if (CheckBoxIsShow.Checked)
            {
                category.IsShow = 1;
            }
            else
            {
                category.IsShow = 0;
            }
            if (DropDownListFatherCateGory.SelectedValue == "0")
            {
                category.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = DropDownListFatherCateGory.SelectedItem.Text.Split(new[] {charSapce});
                if (strArray.Length > 0)
                {
                    category.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                    if (category.CategoryLevel >= 4)
                    {
                        MessageBox.Show("分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    category.CategoryLevel = 2;
                }
            }
            category.FatherID = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
            category.CreateUser = "admin";
            category.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.ModifyUser = "admin";
            category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.IsDeleted = 0;
            if (!Common.Common.ReturnExist("name", "shopNum1_Category", " and name='" + category.Name + "'"))
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Category";
                if (action.Add(category) > 0)
                {
                    ShopNum1_CategoryChecked_Action.CategoryTable = null;
                    method_10();
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else
            {
                MessageShow.ShowMessage("添加失败，分类已经存在！");
                MessageShow.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                BindData();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelTitle.Text = "编辑分类信息分类";
                    method_8();
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((method_7() + 1));
                }
            }
        }
    }
}