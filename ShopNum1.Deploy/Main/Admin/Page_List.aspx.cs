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
    public partial class Page_List : PageBase, IRequiresSessionState
    {
        protected bool One = false;
        protected bool PagePath = true;

        protected bool Two = false;

        protected void AddAll(ref DropDownList dropDownList)
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            if (!dropDownList.Items.Contains(item))
            {
                dropDownList.Items.Add(item);
            }
        }

        protected void AddOne()
        {
            var item = new ListItem
                {
                    Text = "为一级目录",
                    Value = "-1"
                };
            DropDownListOne.Items.Add(item);
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void BindOne()
        {
            DropDownListOne.Items.Clear();
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            foreach (DataRow row in action.GetOnePage(0).Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["OneID"].ToString()
                    };
                DropDownListOne.Items.Add(item);
            }
        }

        protected void BindPageType()
        {
        }

        protected void BindSOne()
        {
            DropDownListSOne.Items.Clear();
            AddAll(ref DropDownListSOne);
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            foreach (DataRow row in action.GetOnePage(0).Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["OneID"].ToString()
                    };
                DropDownListSOne.Items.Add(item);
            }
        }

        protected void BindSTwo()
        {
            DropDownListSTwo.Items.Clear();
            AddAll(ref DropDownListSTwo);
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            foreach (DataRow row in action.GetTwopage(Convert.ToInt32(DropDownListSOne.SelectedValue), 0).Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["TwoID"].ToString()
                    };
                DropDownListSTwo.Items.Add(item);
            }
        }

        protected void BindTwo()
        {
            if (Operator.FormatToEmpty(DropDownListOne.SelectedValue) != string.Empty)
            {
                DropDownListTwo.Items.Clear();
                var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
                foreach (DataRow row in action.GetTwopage(Convert.ToInt32(DropDownListOne.SelectedValue), 0).Rows)
                {
                    var item = new ListItem
                        {
                            Text = row["Name"].ToString(),
                            Value = row["TwoID"].ToString()
                        };
                    DropDownListTwo.Items.Add(item);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            DropDownListPageType.Enabled = true;
            ClearControl();
            if (ButtonAdd.ToolTip == "addok")
            {
                ButtonConfirm.ToolTip = "add";
                divPage.Visible = true;
                ButtonAdd.Text = "取消";
                ButtonAdd.ToolTip = "addno";
            }
            else
            {
                divPage.Visible = false;
                ButtonAdd.Text = "添加";
                ButtonAdd.ToolTip = "addok";
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            num = 1 + ShopNum1_Common_Action.ReturnMaxID("OneID", "ShopNum1_Page");
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            var page = new ShopNum1_Page();
            if (ButtonConfirm.ToolTip == "add")
            {
                page.Guid = Guid.NewGuid();
                page.Name = TextBoxName.Text.Trim();
                page.PagePath = TextBoxPagePath.Text.Trim();
                page.PageType = Convert.ToInt32(DropDownListPageType.SelectedValue);
                page.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                page.Description = TextBoxDescription.Text.Trim();
                page.ThreeID = 0;
                if (DropDownListPageType.SelectedValue.Equals("0"))
                {
                    if (DropDownListOne.SelectedValue.Equals("-1"))
                    {
                        page.OneID = num;
                        page.TwoID = 0;
                    }
                    else
                    {
                        page.OneID = Convert.ToInt32(DropDownListOne.SelectedValue);
                        num2 = 1 + action.RetrunMaxTwoID(Convert.ToInt32(DropDownListOne.SelectedValue));
                        page.TwoID = num2;
                    }
                }
                else if (DropDownListPageType.SelectedValue.Equals("3"))
                {
                    page.OneID = num;
                    page.TwoID = 0;
                }
                else if (DropDownListPageType.SelectedValue.Equals("1"))
                {
                    if ((DropDownListTwo.SelectedValue == "") || (DropDownListTwo.SelectedValue == "-1"))
                    {
                        DropDownListTwo.Focus();
                        base.Response.Write(
                            " <script>alert('操作有误!'); window.location.href=window.location.href </script> ");
                    }
                    page.OneID = Convert.ToInt32(DropDownListOne.SelectedValue);
                    page.TwoID = Convert.ToInt32(DropDownListTwo.SelectedValue);
                    num3 = 1 + action.RetrunMaxThreeID(page.OneID, page.TwoID);
                    page.ThreeID = num3;
                }
                page.CreateUser = "admin";
                page.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                page.ModifyUser = "admin";
                page.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                page.IsDeleted = 0;
                if (action.Add(page) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "系统管理员添加页面",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Page_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                    BindData();
                    BindGrid();
                    ClearControl();
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else
            {
                page.Guid = new Guid(hiddenGuid.Value.Replace("'", ""));
                page.Name = TextBoxName.Text.Trim();
                page.PagePath = TextBoxPagePath.Text.Trim();
                page.PageType = Convert.ToInt32(DropDownListPageType.SelectedValue);
                page.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                page.Description = TextBoxDescription.Text.Trim();
                page.ThreeID = Convert.ToInt32(ViewState["ThreeID"]);
                page.TwoID = Convert.ToInt32(ViewState["TwoID"]);
                page.OneID = Convert.ToInt32(ViewState["OneID"]);
                if (DropDownListPageType.SelectedValue.Equals("0"))
                {
                    if (DropDownListOne.SelectedValue.Equals("-1"))
                    {
                        page.OneID = num;
                        page.TwoID = 0;
                    }
                    else
                    {
                        page.OneID = Convert.ToInt32(DropDownListOne.SelectedValue);
                        num2 = 1 + action.RetrunMaxTwoID(Convert.ToInt32(DropDownListOne.SelectedValue));
                        page.TwoID = num2;
                    }
                }
                else if (DropDownListPageType.SelectedValue.Equals("3"))
                {
                    page.OneID = num;
                    page.TwoID = 0;
                }
                else if (DropDownListPageType.SelectedValue.Equals("1"))
                {
                    if ((DropDownListTwo.SelectedValue == "") || (DropDownListTwo.SelectedValue == "-1"))
                    {
                        base.Response.Write(
                            " <script>alert('操作有误!'); window.location.href=window.location.href </script> ");
                        return;
                    }
                    page.OneID = Convert.ToInt32(DropDownListOne.SelectedValue);
                    page.TwoID = Convert.ToInt32(DropDownListTwo.SelectedValue);
                    page.ThreeID = num3;
                }
                page.ModifyUser = "admin";
                page.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                page.IsDeleted = 0;
                if (action.Update(page) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "系统管理员修改页面",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Page_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("EditYes");
                    MessageShow.Visible = true;
                    BindData();
                    BindGrid();
                    ClearControl();
                }
                else
                {
                    MessageShow.ShowMessage("EditNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            string pageguid = CheckGuid.Value.Replace("'", "");
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            if (action.DelPageBySuper(pageguid) > 0)
            {
                MessageShow.ShowMessage("操作成功");
                MessageShow.Visible = true;
                BindData();
                BindGrid();
            }
            else
            {
                MessageShow.ShowMessage("操作失败");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string pageguid = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action();
            if (action.DelPageBySuper(pageguid) > 0)
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
            ButtonConfirm.ToolTip = "update";
            LabelPageTitle.Text = "【编辑页面】";
            divPage.Visible = true;
            string guid = CheckGuid.Value.Replace("'", "");
            DataTable table = LogicFactory.CreateShopNum1_Page_Action().Search(guid, 0);
            if ((table != null) && (table.Rows.Count != 0))
            {
                BindOne();
                DropDownListPageType.SelectedValue = table.Rows[0]["PageType"].ToString();
                if (DropDownListPageType.SelectedValue.Equals("-1"))
                {
                    RemoveOne();
                }
                else
                {
                    if (DropDownListPageType.SelectedValue.Equals("3"))
                    {
                        One = false;
                        Two = false;
                        RemoveOne();
                    }
                    else if (DropDownListPageType.SelectedValue.Equals("0"))
                    {
                        One = true;
                        AddOne();
                    }
                    else if (DropDownListPageType.SelectedValue.Equals("1"))
                    {
                        One = true;
                        Two = true;
                        BindOne();
                        DropDownListOne.SelectedValue = table.Rows[0]["OneID"].ToString();
                        BindTwo();
                        DropDownListTwo.SelectedValue = table.Rows[0]["TwoID"].ToString();
                        RemoveOne();
                    }
                    if (DropDownListTwo.SelectedValue.Equals("-1"))
                    {
                        PagePath = false;
                    }
                    DropDownListPageType.Enabled = false;
                    TextBoxName.Text = table.Rows[0]["Name"].ToString();
                    TextBoxPagePath.Text = (table.Rows[0]["PagePath"] != null)
                                               ? table.Rows[0]["PagePath"].ToString()
                                               : "";
                    TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
                    TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
                    ViewState["ThreeID"] = table.Rows[0]["ThreeID"].ToString();
                    ViewState["TwoID"] = table.Rows[0]["TwoID"].ToString();
                }
            }
        }

        protected void ButtonEditByLink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string str = "'" + button.CommandArgument + "'";
            hiddenGuid.Value = str;
            ButtonConfirm.ToolTip = "update";
            LabelPageTitle.Text = "【编辑页面】";
            divPage.Visible = true;
            string guid = str.Replace("'", "");
            DataTable table = LogicFactory.CreateShopNum1_Page_Action().Search(guid, 0);
            if ((table != null) && (table.Rows.Count != 0))
            {
                BindOne();
                DropDownListPageType.SelectedValue = table.Rows[0]["PageType"].ToString();
                if (DropDownListPageType.SelectedValue.Equals("-1"))
                {
                    RemoveOne();
                }
                else
                {
                    if (DropDownListPageType.SelectedValue.Equals("3"))
                    {
                        One = false;
                        Two = false;
                        RemoveOne();
                    }
                    else if (DropDownListPageType.SelectedValue.Equals("0"))
                    {
                        One = true;
                        AddOne();
                    }
                    else if (DropDownListPageType.SelectedValue.Equals("1"))
                    {
                        One = true;
                        Two = true;
                        BindOne();
                        DropDownListOne.SelectedValue = table.Rows[0]["OneID"].ToString();
                        BindTwo();
                        DropDownListTwo.SelectedValue = table.Rows[0]["TwoID"].ToString();
                        RemoveOne();
                    }
                    if (DropDownListTwo.SelectedValue.Equals("-1"))
                    {
                        PagePath = false;
                    }
                    DropDownListPageType.Enabled = false;
                    TextBoxName.Text = table.Rows[0]["Name"].ToString();
                    TextBoxPagePath.Text = (table.Rows[0]["PagePath"] != null)
                                               ? table.Rows[0]["PagePath"].ToString()
                                               : "";
                    TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
                    TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
                    ViewState["ThreeID"] = table.Rows[0]["ThreeID"].ToString();
                    ViewState["TwoID"] = table.Rows[0]["TwoID"].ToString();
                }
            }
        }

        protected void ButtonManageControl_Click(object sender, EventArgs e)
        {
            string str = CheckGuid.Value.Replace("'", "");
            base.Response.Redirect("Control_List.aspx?Guid=" + str);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangePageType(string strPageType)
        {
            if (strPageType == "0")
            {
                return "左边菜单页面";
            }
            if (strPageType == "1")
            {
                return "普通操作页面";
            }
            if (strPageType == "3")
            {
                return "顶部页面";
            }
            return "";
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            TextBoxOrderID.Text = string.Empty;
            TextBoxPagePath.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            DropDownListPageType.SelectedValue = "-1";
            One = false;
            Two = false;
        }

        protected void DropDownListOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListOne.SelectedValue.Equals("-1"))
            {
                One = true;
                PagePath = false;
            }
            else
            {
                One = true;
                Two = true;
                if (DropDownListPageType.SelectedValue.Equals("0"))
                {
                    Two = false;
                }
                BindTwo();
            }
        }

        protected void DropDownListPageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListPageType.SelectedValue.Equals("-1"))
            {
                RemoveOne();
            }
            else
            {
                if (DropDownListPageType.SelectedValue.Equals("3"))
                {
                    One = false;
                    Two = false;
                    RemoveOne();
                }
                else if (DropDownListPageType.SelectedValue.Equals("0"))
                {
                    One = true;
                    AddOne();
                }
                else if (DropDownListPageType.SelectedValue.Equals("1"))
                {
                    One = true;
                    Two = true;
                    BindOne();
                    BindTwo();
                    RemoveOne();
                }
                if (DropDownListTwo.SelectedValue.Equals("-1"))
                {
                    PagePath = false;
                }
            }
        }

        protected void DropDownListSOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSTwo();
        }

        protected void DropDownListTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            One = true;
            Two = true;
        }

        public void GetMaxID()
        {
            int num = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Page");
            TextBoxOrderID.Text = (num + 1).ToString();
        }

        private void BindData()
        {
            BindOne();
            BindSOne();
            BindSTwo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
                if (base.ShopNum1UserGuid.ToUpper() == "8EA30851-571B-4FFA-8870-05A7E5134AA9".ToUpper())
                {
                    ButtonDel.Visible = true;
                }
            }
        }

        protected void RemoveOne()
        {
            for (int i = 0; i < DropDownListOne.Items.Count; i++)
            {
                if (DropDownListOne.Items[i].Value.Equals("-1"))
                {
                    DropDownListOne.Items.Remove(DropDownListOne.Items[i]);
                }
            }
        }
    }
}