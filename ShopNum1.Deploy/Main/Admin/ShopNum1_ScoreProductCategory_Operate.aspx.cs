using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ScoreProductCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        private IShopNum1_SpecificationProudctCategory_Action ishopNum1_SpecificationProudctCategory_Action_0 = LogicFactory.CreateShopNum1_SpecificationProudctCategory_Action();

        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                this.BindData();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelTitle.Text = "编辑红包商品分类";
                    this.DropDownListFatherCateGory.Enabled = false;
                    this.method_8();
                }
                else
                {
                    this.TextBoxOrderID.Text = Convert.ToString((int)(this.method_7() + 1));
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (this.ButtonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "编辑商品分类",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_ScoreProductCategory_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_11();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "新增商品分类",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_ScoreProductCategory_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_9();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            this.method_10();
        }

        private void method_10()
        {
            this.TextBoxName.Text = string.Empty;
            this.TextBoxKeywords.Text = string.Empty;
            this.TextBoxDescription.Text = string.Empty;
            this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
            this.CheckBoxIsShow.Checked = true;
        }

        private void method_11()
        {
            ShopNum1_ScoreProductCategory scoreProductCategory = new ShopNum1_ScoreProductCategory
            {
                ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", "")),
                Name = this.TextBoxName.Text.Trim(),
                Keywords = this.TextBoxKeywords.Text.Trim(),
                Description = this.TextBoxDescription.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
            };
            if (this.CheckBoxIsShow.Checked)
            {
                scoreProductCategory.IsShow = 1;
            }
            else
            {
                scoreProductCategory.IsShow = 0;
            }
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                scoreProductCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                if (strArray.Length > 0)
                {
                    scoreProductCategory.CategoryLevel = new int?(((strArray.Length + 1) / 2) + 1);
                    if (scoreProductCategory.CategoryLevel >= 4)
                    {
                        MessageBox.Show("商品分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    scoreProductCategory.CategoryLevel = 2;
                }
            }
            scoreProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            scoreProductCategory.Family = string.Empty;
            scoreProductCategory.CreateUser = "admin";
            scoreProductCategory.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductCategory.ModifyUser = "admin";
            scoreProductCategory.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductCategory.IsDeleted = 0;
            scoreProductCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString());
            ShopNum1_ScoreProductCategory_Action action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
            if (action.Update(scoreProductCategory) > 0)
            {
                base.Response.Redirect("ShopNum1_ScoreProductCategory_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        private void BindData()
        {
            ListItem item = new ListItem
            {
                Text = "顶级分类",
                Value = "0"
            };
            this.DropDownListFatherCateGory.Items.Add(item);
            ShopNum1_ScoreProductCategory_Action action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
            foreach (DataRow row in action.SearchtProductCategory(0, 0).Rows)
            {
                ListItem item2 = new ListItem
                {
                    Text = row["Name"].ToString(),
                    Value = row["ID"].ToString()
                };
                this.DropDownListFatherCateGory.Items.Add(item2);
                this.method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private void method_6(int int_0)
        {
            ShopNum1_ScoreProductCategory_Action action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
            foreach (DataRow row in action.SearchtProductCategory(int_0, 0).Rows)
            {
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + this.strSapce;
                }
                ListItem item = new ListItem
                {
                    Text = str + row["Name"].ToString(),
                    Value = row["ID"].ToString()
                };
                this.DropDownListFatherCateGory.Items.Add(item);
                this.method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private int method_7()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ScoreProductCategory");
        }

        private void method_8()
        {
            DataTable productCategoryByID = ((ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action()).GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
            this.TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
            this.TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
            this.TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
            this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
            this.DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
            if (productCategoryByID.Rows[0]["IsShow"].ToString() == "1")
            {
                this.CheckBoxIsShow.Checked = true;
            }
            else
            {
                this.CheckBoxIsShow.Checked = false;
            }
            this.ButtonConfirm.Text = "更新";
            this.ButtonConfirm.ToolTip = "Update";
        }

        private void method_9()
        {
            ShopNum1_ScoreProductCategory scoreProductCategory = new ShopNum1_ScoreProductCategory
            {
                Name = this.TextBoxName.Text.Trim(),
                Keywords = this.TextBoxKeywords.Text.Trim(),
                Description = this.TextBoxDescription.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
            };
            if (this.CheckBoxIsShow.Checked)
            {
                scoreProductCategory.IsShow = 1;
            }
            else
            {
                scoreProductCategory.IsShow = 0;
            }
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                scoreProductCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                if (strArray.Length > 0)
                {
                    scoreProductCategory.CategoryLevel = new int?(((strArray.Length + 1) / 2) + 1);
                    if (scoreProductCategory.CategoryLevel >= 4)
                    {
                        MessageBox.Show("商品分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    scoreProductCategory.CategoryLevel = 2;
                }
            }
            scoreProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            scoreProductCategory.Family = string.Empty;
            scoreProductCategory.CreateUser = "admin";
            scoreProductCategory.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductCategory.ModifyUser = "admin";
            scoreProductCategory.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            scoreProductCategory.IsDeleted = 0;
            ShopNum1_ScoreProductCategory_Action action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
            if (action.Add(scoreProductCategory) > 0)
            {
                if (this.hiddenFieldSpecification.Value != "-1")
                {
                    this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(this.hiddenFieldGuid.Value, "", this.hiddenFieldSpecification.Value);
                }
                this.method_10();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
                this.Page.Response.Redirect("ShopNum1_ScoreProductCategory_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }


    }
}