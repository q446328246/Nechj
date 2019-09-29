using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PageAdID_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindGrid();
            }
        }

        public void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("PageAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value.Split(new char[] { ',' });
            ShopNum1_PageAdID_Action action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
            ShopNum1_Advertisement_Action action2 = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
            DataTable table = action.SelectByID(this.CheckGuid.Value);
            DataTable table2 = action2.ShowADByDivID(table.Rows[0]["divid"].ToString());
            if ((table2 != null) && (table2.Rows.Count != 0))
            {
                MessageBox.Show("广告位下面还有广告，请先删除广告后再删除广告位!");
            }
            else if (action.Delete(this.CheckGuid.Value) > 0)
            {
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
            ShopNum1_PageAdID_Action action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
            ShopNum1_Advertisement_Action action2 = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
            DataTable table = action.SelectByID(commandArgument);
            table.Rows[0]["divid"].ToString();
            DataTable table2 = action2.ShowADByDivID(table.Rows[0]["divid"].ToString());
            if ((table2 != null) && (table2.Rows.Count != 0))
            {
                MessageBox.Show("广告位下面还有广告，请先删除广告后再删除广告位!");
            }
            else if (action.Delete(commandArgument) > 0)
            {
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

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("PageAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
        }


    }
}