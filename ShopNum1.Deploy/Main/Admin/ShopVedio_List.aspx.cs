using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopVedio_List : PageBase, IRequiresSessionState
    {
        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            if (this.DropDownListOperate.SelectedValue != "0")
            {
                var action = (ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action();
                if (
                    action.UpdateAudit(this.CheckGuid.Value.ToString(),
                                       int.Parse(this.DropDownListOperate.SelectedValue)) > 0)
                {
                    method_6();
                    this.MessageShow.ShowMessage("Audit2Yes");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage("Audit2No");
                    this.MessageShow.Visible = true;
                }
            }
            else
            {
                this.MessageShow.ShowMessage("请选择操作");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int num =
                ((ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action()).Delete(
                    this.CheckGuid.Value.ToString());
            method_6();
            if (num > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺视频",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedio_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺视频",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedio_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
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
            base.Response.Redirect("ShopVedio_Details.aspx?guid=" + this.CheckGuid.Value);
        }

        public string ChangeIsAudit(object strIsAudit)
        {
            if (strIsAudit.ToString() == "0")
            {
                return "未审核";
            }
            if (strIsAudit.ToString() == "1")
            {
                return "已审核";
            }
            if (strIsAudit.ToString() == "2")
            {
                return "未通过";
            }
            if (strIsAudit.ToString() == "3")
            {
                return "禁止";
            }
            return "非法状态";
        }

        private void BindData()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-3"
                };
            this.DropDownListIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "已审核",
                    Value = "1"
                };
            this.DropDownListIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "禁止",
                    Value = "3"
                };
            this.DropDownListIsAudit.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = "未通过",
                    Value = "2"
                };
            this.DropDownListIsAudit.Items.Add(item4);
        }

        private void method_6()
        {
            this.Num1GridViewShow.DataBind();
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