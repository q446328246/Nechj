using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopArticle_List : PageBase, IRequiresSessionState
    {
        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            if (DropDownListOperate.SelectedValue != "0")
            {
                var action = (ShopNum1_ArticleCheck_Action) LogicFactory.CreateShopNum1_ArticleCheck_Action();
                if (action.UpdateAudit(CheckGuid.Value, int.Parse(DropDownListOperate.SelectedValue)) > 0)
                {
                    method_6();
                    MessageShow.ShowMessage("Audit2Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            else
            {
                MessageShow.ShowMessage("请选择操作");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int num =
                ((ShopNum1_ArticleCheck_Action) LogicFactory.CreateShopNum1_ArticleCheck_Action()).Delete(
                    CheckGuid.Value);
            method_6();
            if (num > 0)
            {
                method_6();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺文章",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticle_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            var action = (ShopNum1_ArticleCheck_Action) LogicFactory.CreateShopNum1_ArticleCheck_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺文章",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticle_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
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
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_6();
        }

        protected void ButtonSearchDetails_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopArticle_Details.aspx?guid=" + CheckGuid.Value);
        }

        public string ChangeIsAudit(object strIsAudit)
        {
            if (strIsAudit.ToString() == "0")
            {
                return "未审核";
            }
            if (strIsAudit.ToString() == "1")
            {
                return "正常";
            }
            if (strIsAudit.ToString() == "2")
            {
                return "已审核";
            }
            if (strIsAudit.ToString() == "3")
            {
                return "禁止";
            }
            return "";
        }

        public string GetShopName(string memloginId)
        {
            return Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginid='" + memloginId + "'");
        }

        private void BindData()
        {
            var item = new ListItem
                {
                    Text = "正常",
                    Value = "1"
                };
            DropDownListIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "禁止",
                    Value = "3"
                };
            DropDownListIsAudit.Items.Add(item2);
        }

        private void method_6()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                method_6();
            }
        }
    }
}