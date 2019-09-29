using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AttachMentCateGory_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelTitle.Text = "编辑附件类别";
                GetEditInfo();
            }
        }

        protected void Add()
        {
            var gory = new ShopNum1_AttachMentCateGory
                {
                    Guid = Guid.NewGuid(),
                    CateGoryName = TextBoxCategoryName.Text,
                    Description = TextBoxDescription.Text
                };
            var action = (ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action();
            if (action.Insert(gory) > 0)
            {
                method_5();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增" + TextBoxCategoryName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AttachMentCateGory_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void Edit()
        {
            var gory = new ShopNum1_AttachMentCateGory
                {
                    Guid = new Guid(hiddenFieldGuid.Value.Replace("'", "")),
                    CateGoryName = TextBoxCategoryName.Text,
                    Description = TextBoxDescription.Text
                };
            var action = (ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action();
            if (action.Update(gory) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑" + TextBoxCategoryName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AttachMentCateGory_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("AttachMentCateGory_List.aspx");
                MessageShow.ShowMessage("EditYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataRow row =
                ((ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action()).EditShow(
                    hiddenFieldGuid.Value);
            TextBoxCategoryName.Text = row["CategoryName"].ToString();
            TextBoxDescription.Text = row["Description"].ToString();
            ButtonConfirm.Text = "更新";
        }

        private void method_5()
        {
            TextBoxCategoryName.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
        }
    }
}