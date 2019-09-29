using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SupplyDemandCommentAudit_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandComment_Action action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            if (action.UpdateSupplyDemandCommentAudit(this.CheckGuid.Value, "1") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "审核通过",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SupplyDemandCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("Audit1Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit1No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandComment_Action action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            if (action.UpdateSupplyDemandCommentAudit(this.CheckGuid.Value, "2") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "审核未通过",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SupplyDemandCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("Audit2Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit2No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandComment_Action action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            if (action.DeleteSupplyDemandComment(this.CheckGuid.Value.ToString()) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除供求评论审核信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SupplyDemandCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
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
            LinkButton button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            ShopNum1_SupplyDemandComment_Action action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            if (action.DeleteSupplyDemandComment("'" + commandArgument + "'") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除供求评论审核信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "SupplyDemandCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SupplyDemandComment_Operate.aspx?guid=" + this.CheckGuid.Value + "&&type=audit");
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            return "审核未通过";
        }

        private void BindData()
        {
            ListItem item = new ListItem
            {
                Text = "-全部-",
                Value = "-2"
            };
            this.DropDownListIsAudit.Items.Add(item);
            ListItem item2 = new ListItem
            {
                Text = "未审核",
                Value = "0"
            };
            this.DropDownListIsAudit.Items.Add(item2);
            ListItem item3 = new ListItem
            {
                Text = "审核未通过",
                Value = "2"
            };
            this.DropDownListIsAudit.Items.Add(item3);
        }



    }
}