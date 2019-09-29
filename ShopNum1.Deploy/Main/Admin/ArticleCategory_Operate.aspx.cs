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
    public partial class ArticleCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';
        protected string strSapce = "　　";

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_ArticleCategory category;
            string[] strArray;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                category = new ShopNum1_ArticleCategory
                    {
                        Name = TextBoxName.Text.Trim(),
                        FatherID = Convert.ToInt32(DropDownListFatherID.SelectedValue),
                        Keywords = TextBoxKeywords.Text.Trim(),
                        Description = TextBoxDescription.Text.Trim(),
                        OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim())
                    };
                if (CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                category.CreateUser = "admin";
                category.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                category.ModifyUser = "admin";
                category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                category.IsDeleted = 0;
                if (DropDownListFatherID.SelectedValue == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray = DropDownListFatherID.SelectedItem.Text.Split(new[] {charSapce});
                    if (strArray.Length > 0)
                    {
                        category.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
                var action2 = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
                if (action2.Add(category) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "添加资讯分类管理",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ArticleCategory_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                    method_5();
                    method_7();
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                category = new ShopNum1_ArticleCategory
                    {
                        ID = Convert.ToInt32(hiddenFieldGuid.Value.Replace("'", "")),
                        Name = TextBoxName.Text.Trim(),
                        FatherID = Convert.ToInt32(DropDownListFatherID.SelectedValue),
                        Keywords = TextBoxKeywords.Text.Trim(),
                        Description = TextBoxDescription.Text.Trim(),
                        OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim())
                    };
                if (CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                category.ModifyUser = "admin";
                category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                category.IsDeleted = 0;
                if (DropDownListFatherID.SelectedValue == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray = DropDownListFatherID.SelectedItem.Text.Split(new[] {charSapce});
                    if (strArray.Length > 0)
                    {
                        category.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
                var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
                if (action.Update(category) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "修改资讯分类管理",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ArticleCategory_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    base.Response.Redirect("ArticleCategory_List.aspx");
                }
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action()).GetEditInfo(
                    hiddenFieldGuid.Value);
            TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
            DropDownListFatherID.SelectedValue = editInfo.Rows[0]["FatherID"].ToString();
            TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            if (Convert.ToInt32(editInfo.Rows[0]["IsShow"].ToString()) == 1)
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
            LabelPageTitle.Text = "编辑资讯分类";
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_ArticleCategory";
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void method_5()
        {
            DropDownListFatherID.Items.Clear();
            var item = new ListItem
                {
                    Text = "顶级分类",
                    Value = "0"
                };
            DropDownListFatherID.Items.Add(item);
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in action.Search(0, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListFatherID.Items.Add(item2);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    method_6(table);
                }
            }
        }

        private void method_6(DataTable dt)
        {
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListFatherID.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    method_6(table);
                }
            }
        }

        private void method_7()
        {
            TextBoxName.Text = string.Empty;
            DropDownListFatherID.SelectedValue = "0";
            TextBoxKeywords.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            CheckBoxIsShow.Checked = true;
            GetOrderID();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                method_5();
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    DropDownListFatherID.Enabled = false;
                    GetEditInfo();
                    ButtonConfirm.Text = "更新";
                }
            }
        }
    }
}