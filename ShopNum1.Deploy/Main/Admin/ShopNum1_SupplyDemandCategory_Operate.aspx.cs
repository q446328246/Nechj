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
    public partial class ShopNum1_SupplyDemandCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                BindData();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelTitle.Text = "编辑供求分类";
                    method_8();
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((method_7() + 1));
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑供求分类信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_SupplyDemandCategory_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_11();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加供求分类信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_SupplyDemandCategory_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
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
            var category = new ShopNum1_SupplyDemandCategory
                {
                    ID = Convert.ToInt32(hiddenFieldGuid.Value.Replace("'", "")),
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
                        MessageBox.Show("供求分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    category.CategoryLevel = 2;
                }
            }
            category.FatherID = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
            category.Family = string.Empty;
            category.CreateUser = "";
            category.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.ModifyUser = "";
            category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.IsDeleted = "0";
            var action =
                (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            if (action.Update(hiddenFieldGuid.Value, category) > 0)
            {
                ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
                base.Response.Redirect("ShopNum1_SupplyDemandCategory_List.aspx");
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
            var action =
                (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            foreach (DataRow row in action.SearchtSupplyDemandCategory(0, 0).Rows)
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
            var action =
                (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            foreach (DataRow row in action.SearchtSupplyDemandCategory(int_0, 0).Rows)
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
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_SupplyDemandCategory");
        }

        private void method_8()
        {
            DataTable supplyCategoryByID =
                ((ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action())
                    .GetSupplyCategoryByID(hiddenFieldGuid.Value);
            TextBoxName.Text = supplyCategoryByID.Rows[0]["Name"].ToString();
            TextBoxKeywords.Text = supplyCategoryByID.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = supplyCategoryByID.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = supplyCategoryByID.Rows[0]["OrderID"].ToString();
            DropDownListFatherCateGory.Text = supplyCategoryByID.Rows[0]["FatherID"].ToString();
            DropDownListFatherCateGory.Enabled = false;
            if (supplyCategoryByID.Rows[0]["IsShow"].ToString() == "1")
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
            var category = new ShopNum1_SupplyDemandCategory
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
                        MessageBox.Show("供求分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    category.CategoryLevel = 2;
                }
            }
            category.FatherID = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
            category.Family = string.Empty;
            category.CreateUser = "admin";
            category.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.ModifyUser = "admin";
            category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            category.IsDeleted = "0";
            if (!Common.Common.ReturnExist("name", "shopNum1_SupplyDemandCategory", " and name='" + category.Name + "'"))
            {
                var action =
                    (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
                if (action.Add(category) > 0)
                {
                    ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
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

 
    }
}