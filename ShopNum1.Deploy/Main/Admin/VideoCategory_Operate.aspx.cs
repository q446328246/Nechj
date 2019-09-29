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
    public partial class VideoCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                BindData();
                GetOrderID();
                if (hiddenGuid.Value != "0")
                {
                    method_7();
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_VideoCategory_Action action;
            ShopNum1_VideoCategory category;
            string[] strArray;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
                category = new ShopNum1_VideoCategory
                    {
                        Name = TextBoxName.Text.Trim(),
                        FatherID = Convert.ToInt32(DropDownListFatherID.SelectedValue),
                        Keywords = TextBoxKeywords.Text.Trim(),
                        Description = TextBoxDescription.Text.Trim(),
                        OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                        BackgroundImage = TextBoxBackgroundImage.Text.Trim()
                    };
                if (CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                category.CreateUser = base.ShopNum1LoginID;
                category.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                category.ModifyUser = base.ShopNum1LoginID;
                category.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                category.IsDeleted = 0;
                category.ID = action.GetMaxID();
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
                if (action.Add(category) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "新增" + TextBoxName.Text.Trim() + "成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "VideoCategory_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                    BindData();
                    method_8();
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                if (hiddenGuid.Value == DropDownListFatherID.SelectedValue)
                {
                    MessageShow.ShowMessage("EditError");
                    MessageShow.Visible = true;
                }
                else
                {
                    category = new ShopNum1_VideoCategory
                        {
                            ID = Convert.ToInt32(hiddenGuid.Value),
                            Name = TextBoxName.Text.Trim(),
                            FatherID = Convert.ToInt32(DropDownListFatherID.SelectedValue),
                            Keywords = TextBoxKeywords.Text.Trim(),
                            Description = TextBoxDescription.Text.Trim(),
                            OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                            BackgroundImage = TextBoxBackgroundImage.Text.Trim()
                        };
                    if (CheckBoxIsShow.Checked)
                    {
                        category.IsShow = 1;
                    }
                    else
                    {
                        category.IsShow = 0;
                    }
                    category.ModifyUser = base.ShopNum1LoginID;
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
                    action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
                    if (action.Update(category) > 0)
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "编辑" + TextBoxName.Text.Trim() + "成功",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "VideoCategory_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        base.Response.Redirect("VideoCategory_List.aspx");
                    }
                    else
                    {
                        MessageShow.ShowMessage("EditNo");
                        MessageShow.Visible = true;
                    }
                }
            }
        }

        protected void GetOrderID()
        {
            var action1 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            string columnName = "OrderID";
            string tableName = "ShopNum1_VideoCategory";
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void BindData()
        {
            DropDownListFatherID.Items.Clear();
            var item = new ListItem
                {
                    Text = " 顶级分类",//LocalizationUtil.GetCommonMessage("OneCategory"),
                    Value = "0"
                };
            DropDownListFatherID.Items.Add(item);
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
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
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
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
            DataTable table = new ShopNum1_VideoCategory_Action().SearchInfoByID(hiddenGuid.Value);
            TextBoxName.Text = table.Rows[0]["Name"].ToString();
            DropDownListFatherID.SelectedValue = table.Rows[0]["FatherID"].ToString();
            TextBoxKeywords.Text = table.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
            TextBoxBackgroundImage.Text = table.Rows[0]["BackgroundImage"].ToString();
            if (table.Rows[0]["BackgroundImage"].ToString() != string.Empty)
            {
                ImageBackgroundImage.Src = table.Rows[0]["BackgroundImage"].ToString();
            }
            else
            {
                ImageBackgroundImage.Src = "~/Images/noImage.gif";
            }
            if (table.Rows[0]["IsShow"].ToString() == "0")
            {
                CheckBoxIsShow.Checked = false;
            }
            else
            {
                CheckBoxIsShow.Checked = true;
            }
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
            LabelPageTitle.Text = "编辑视频分类";
        }

        private void method_8()
        {
            TextBoxName.Text = string.Empty;
            TextBoxOrderID.Text = string.Empty;
            DropDownListFatherID.SelectedValue = "0";
            TextBoxKeywords.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            TextBoxBackgroundImage.Text = string.Empty;
            CheckBoxIsShow.Checked = true;
            GetOrderID();
        }
    }
}