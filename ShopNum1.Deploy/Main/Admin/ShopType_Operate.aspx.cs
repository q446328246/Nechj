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
    public partial class ShopType_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";


        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (this.ButtonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改店铺分类",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopType_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_12();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员添加店铺分类",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopType_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_10();
            }
            BindData();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            method_11();
        }

        private void method_10()
        {
            var shopCategory = new ShopNum1_ShopCategory
                {
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
                };
            if (this.CheckBoxIsShow.Checked)
            {
                shopCategory.IsShow = 1;
            }
            else
            {
                shopCategory.IsShow = 0;
            }
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                shopCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new[] {charSapce});
                if (strArray.Length > 0)
                {
                    shopCategory.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                    if (shopCategory.CategoryLevel >= 4)
                    {
                        MessageBox.Show("店铺分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    shopCategory.CategoryLevel = 2;
                }
            }
            shopCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            shopCategory.Family = string.Empty;
            shopCategory.CreateUser = "admin";
            shopCategory.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopCategory.ModifyUser = "admin";
            shopCategory.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopCategory.IsDeleted = "0";
            if (!Common.Common.ReturnExist("name", "shopNum1_ShopCategory", " and name='" + shopCategory.Name + "'"))
            {
                var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
                if (action.Add(shopCategory) > 0)
                {
                    method_11();
                    this.MessageShow.ShowMessage("AddYes");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage("AddNo");
                    this.MessageShow.Visible = true;
                }
            }
            else
            {
                this.MessageShow.ShowMessage("添加失败，分类已经存在！");
                this.MessageShow.Visible = true;
            }
        }

        private void method_11()
        {
            this.TextBoxName.Text = string.Empty;
            TextBoxKeywords.Text = string.Empty;
            this.TextBoxDescription.Text = string.Empty;
            this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
            this.CheckBoxIsShow.Checked = true;
        }

        private void method_12()
        {
            var shopCategory = new ShopNum1_ShopCategory
                {
                    ID = Convert.ToInt32(hiddenFieldGuid.Value.Replace("'", "")),
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
                };
            if (this.CheckBoxIsShow.Checked)
            {
                shopCategory.IsShow = 1;
            }
            else
            {
                shopCategory.IsShow = 0;
            }
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                shopCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new[] {charSapce});
                if (strArray.Length > 0)
                {
                    shopCategory.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                    if (shopCategory.CategoryLevel >= 4)
                    {
                        MessageBox.Show("店铺分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    shopCategory.CategoryLevel = 2;
                }
            }
            shopCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            shopCategory.Family = string.Empty;
            shopCategory.CreateUser = "";
            shopCategory.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopCategory.ModifyUser = "";
            shopCategory.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopCategory.IsDeleted = "0";
            var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
            if (action.Update(hiddenFieldGuid.Value, shopCategory) > 0)
            {
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        private void BindData()
        {
            method_6();
            if (hiddenFieldGuid.Value != "0")
            {
                this.ButtonConfirm.Text = "更新";
                this.ButtonConfirm.ToolTip = "Update";
                this.DropDownListFatherCateGory.Enabled = false;
                method_9();
                if (Common.Common.ReqStr("op") == "add")
                {
                    this.TextBoxOrderID.Text = Convert.ToString((method_8() + 1));
                }
            }
            else
            {
                this.TextBoxOrderID.Text = Convert.ToString((method_8() + 1));
            }
        }

        private void method_6()
        {
            this.DropDownListFatherCateGory.Items.Clear();
            if (Common.Common.ReqStr("op") != "add")
            {
                var item = new ListItem
                    {
                        Text = "顶级分类",
                        Value = "0"
                    };
                this.DropDownListFatherCateGory.Items.Add(item);
                var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
                foreach (DataRow row in action.SearchShopCategory(0, 0).Rows)
                {
                    var item2 = new ListItem
                        {
                            Text = row["Name"].ToString(),
                            Value = row["ID"].ToString()
                        };
                    this.DropDownListFatherCateGory.Items.Add(item2);
                    method_7(Convert.ToInt32(row["ID"].ToString()));
                }
            }
        }

        private void method_7(int int_0)
        {
            var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
            foreach (DataRow row in action.SearchShopCategory(int_0, 0).Rows)
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
                this.DropDownListFatherCateGory.Items.Add(item);
                method_7(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private int method_8()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ShopCategory");
        }

        private void method_9()
        {
            ShopNum1_ShopCategory_Action action;
            DataTable shopCategoryByID;
            if (base.Request.QueryString["op"] == "edit")
            {
                action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
                shopCategoryByID = action.GetShopCategoryByID(hiddenFieldGuid.Value);
                this.TextBoxName.Text = shopCategoryByID.Rows[0]["Name"].ToString();
                TextBoxKeywords.Text = shopCategoryByID.Rows[0]["Keywords"].ToString();
                this.TextBoxDescription.Text = shopCategoryByID.Rows[0]["Description"].ToString();
                this.TextBoxOrderID.Text = shopCategoryByID.Rows[0]["OrderID"].ToString();
                this.DropDownListFatherCateGory.Text = shopCategoryByID.Rows[0]["FatherID"].ToString();
                if (shopCategoryByID.Rows[0]["IsShow"].ToString() == "1")
                {
                    this.CheckBoxIsShow.Checked = true;
                }
                else
                {
                    this.CheckBoxIsShow.Checked = false;
                }
            }
            else if ((base.Request.QueryString["op"] == "add") && (Common.Common.ReqStr("guid") != ""))
            {
                action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
                shopCategoryByID = action.GetShopCategoryByID(hiddenFieldGuid.Value);
                this.TextBoxOrderID.Text = shopCategoryByID.Rows[0]["OrderID"].ToString();
                string str = Common.Common.GetNameById("[Name]+','+cast(id as varchar(8))", "ShopNum1_ProductCategory",
                                                       " and id='" + Common.Common.ReqStr("guid") + "'");
                var item = new ListItem();
                if (Common.Common.ReqStr("level") == "1")
                {
                    item.Text = charSapce + str.Split(new[] {','})[0];
                }
                else if (Common.Common.ReqStr("level") == "2")
                {
                    item.Text = strSapce + str.Split(new[] {','})[0];
                }
                item.Value = str.Split(new[] {','})[1];
                this.DropDownListFatherCateGory.Items.Add(item);
                this.ButtonConfirm.Text = "添加";
                this.ButtonConfirm.ToolTip = "Submit";
            }
            else
            {
                shopCategoryByID =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action())
                        .GetShopCategoryByID(hiddenFieldGuid.Value);
                this.DropDownListFatherCateGory.Text = base.Request.QueryString["guid"];
                this.TextBoxOrderID.Text = shopCategoryByID.Rows[0]["OrderID"].ToString();
                this.ButtonConfirm.Text = "添加";
                this.ButtonConfirm.ToolTip = "Submit";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                BindData();
            }
        }
    }
}