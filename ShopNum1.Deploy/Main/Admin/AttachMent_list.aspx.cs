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
    public partial class AttachMent_list : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                AssociatedCategoryGuidBind();
                BindGrid();
            }
        }

        protected void AssociatedCategoryGuidBind()
        {
            DropDownListAssociatedCategoryGuid.Items.Add(new ListItem("-全部-", "-1"));
            DataTable table =
                ((ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action()).Search();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListAssociatedCategoryGuid.Items.Add(new ListItem(table.Rows[i]["CategoryName"].ToString(),
                                                                          table.Rows[i]["Guid"].ToString()));
            }
        }

        protected void BindGrid()
        {
            num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("AttachMent_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_AttachMent_Action) LogicFactory.CreateShopNum1_AttachMent_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AttachMent_list.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guid = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_AttachMent_Action) LogicFactory.CreateShopNum1_AttachMent_Action();
            if (action.Delete(guid) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AttachMent_list.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
    }
}