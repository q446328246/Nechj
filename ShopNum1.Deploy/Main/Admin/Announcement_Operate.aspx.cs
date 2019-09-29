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
    public partial class Announcement_Operate : PageBase, IRequiresSessionState
    {
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                ClearControl();
                BindData();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑公告";
                    GetEditInfo();
                }
            }
        }

        protected void Add()
        {
            var announcement = new ShopNum1_Announcement
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = base.Server.HtmlEncode(FCKeditorReMark.Text.Replace("'", "''")),
                    CreateTime = Convert.ToDateTime(TextBoxCreateTime.Text.Trim()),
                    CreateUser = "admin",
                    AnnouncementCategoryID = int.Parse(DropDownListFatherID.SelectedValue),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0,
                    Keywords = TextBoxKeywords.Text.Trim(),
                    Description = TextBoxdescription.Text.Trim()
                };
            var action = (ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action();
            if (action.Add(announcement) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Announcement_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                ClearControl();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (BottonConfirm.ToolTip == "Update")
            {
                Edit();
            }
            else if (BottonConfirm.ToolTip == "Submit")
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            FCKeditorReMark.Text = string.Empty;
            TextBoxCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected void Edit()
        {
            var announcement = new ShopNum1_Announcement
                {
                    Title = TextBoxTitle.Text.Trim(),
                    Remark = base.Server.HtmlEncode(FCKeditorReMark.Text.Replace("'", "''")),
                    CreateTime = Convert.ToDateTime(TextBoxCreateTime.Text.Trim()),
                    ModifyUser = "admin",
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0,
                    Keywords = TextBoxKeywords.Text.Trim(),
                    Description = TextBoxdescription.Text.Trim(),
                    AnnouncementCategoryID = int.Parse(DropDownListFatherID.SelectedValue)
                };
            var action = (ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action();
            if (action.Update(hiddenFieldGuid.Value, announcement) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxTitle.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Announcement_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("Announcement_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action()).GetEditInfo(
                    hiddenFieldGuid.Value, 0);
            TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            FCKeditorReMark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
            TextBoxCreateTime.Text = editInfo.Rows[0]["CreateTime"].ToString();
            DropDownListFatherID.SelectedValue = editInfo.Rows[0]["AnnouncementCategoryID"].ToString();
            TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
            TextBoxdescription.Text = editInfo.Rows[0]["Description"].ToString();
            BottonConfirm.Text = "更新";
            BottonConfirm.ToolTip = "Update";
        }

        private void BindData()
        {
            DropDownListFatherID.Items.Clear();
            var item = new ListItem
                {
                    Text = "-请选择-",
                    Value = "0"
                };
            DropDownListFatherID.Items.Add(item);
            var action =
                (ShopNum1_AnnouncementCategory_Action) LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
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
            var action =
                (ShopNum1_AnnouncementCategory_Action) LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
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
    }
}