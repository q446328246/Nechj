using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_CategoryInfoChecked_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_CategoryChecked_Action action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Update(this.CheckGuid.Value, "1") > 0)
            {
                this.BindGrid();
                this.MessageShow1.ShowMessage("Audit1Yes");
                this.MessageShow1.Visible = true;
            }
            else
            {
                this.MessageShow1.ShowMessage("Audit1No");
                this.MessageShow1.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_CategoryChecked_Action action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Update(this.CheckGuid.Value, "2") > 0)
            {
                this.BindGrid();
                this.MessageShow1.ShowMessage("Audit2Yes");
                this.MessageShow1.Visible = true;
            }
            else
            {
                this.MessageShow1.ShowMessage("Audit2No");
                this.MessageShow1.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_CategoryChecked_Action action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                this.BindGrid();
                this.MessageShow1.ShowMessage("DelYes");
                this.MessageShow1.Visible = true;
            }
            else
            {
                this.MessageShow1.ShowMessage("DelNo");
                this.MessageShow1.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string guids = "'" + button.CommandArgument + "'";
            ShopNum1_CategoryChecked_Action action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Delete(guids) > 0)
            {
                this.BindGrid();
                this.MessageShow1.ShowMessage("DelYes");
                this.MessageShow1.Visible = true;
            }
            else
            {
                this.MessageShow1.ShowMessage("DelNo");
                this.MessageShow1.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.SetCode();
            this.BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryDetails.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
        }

        protected void CategoryCfBind()
        {
            DataTable list = ((ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList("0");
            this.DropDownListCategoryCf.Items.Clear();
            this.DropDownListCategoryCf.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListCategoryCf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
            }
        }

        protected void DropDownListCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable list = ((ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList(this.DropDownListCategoryCf.SelectedValue.Split(new char[] { '/' })[0]);
            this.DropDownListCategoryCs.Items.Clear();
            this.DropDownListCategoryCs.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListCategoryCs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
            }
            this.DropDownListCategoryCs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable list = ((ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList(this.DropDownListCategoryCs.SelectedValue.Split(new char[] { '/' })[0]);
            this.DropDownListCategoryCt.Items.Clear();
            this.DropDownListCategoryCt.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListCategoryCt.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
            }
        }

        protected string GetValidateTime(object valitime)
        {
            try
            {
                return valitime.ToString().Split(new char[] { '/' })[0];
            }
            catch
            {
                return "";
            }
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "“—…Û∫À";
            }
            if (object_0.ToString() == "0")
            {
                return "Œ¥…Û∫À";
            }
            if (object_0.ToString() == "2")
            {
                return "…Û∫ÀŒ¥Õ®π˝";
            }
            return "∑«∑®◊¥Ã¨";
        }

        private void method_5()
        {
            this.DropDownListIsAudit.Items.Add(new ListItem("-»´≤ø-", "-2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("…Û∫ÀŒ¥Õ®π˝", "2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("Œ¥…Û∫À", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.CategoryCfBind();
                this.method_5();
                this.DropDownListCategoryCf_SelectedIndexChanged(null, null);
                this.SetCode();
                this.BindGrid();
            }
        }

        public void SetCode()
        {
            if (this.DropDownListCategoryCt.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCategoryCt.SelectedValue.Split(new char[] { '/' })[1];
            }
            else if (this.DropDownListCategoryCs.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCategoryCs.SelectedValue.Split(new char[] { '/' })[1];
            }
            else if (this.DropDownListCategoryCf.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCategoryCf.SelectedValue.Split(new char[] { '/' })[1];
            }
            else
            {
                this.HiddenFieldCode.Value = "-1";
            }
        }
    }
}