using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_CategoryInfo_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Update(CheckGuid.Value, "1") > 0)
            {
                BindGrid();
                MessageShow1.ShowMessage("Audit1Yes");
                MessageShow1.Visible = true;
            }
            else
            {
                MessageShow1.ShowMessage("Audit1No");
                MessageShow1.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Update(CheckGuid.Value, "0") > 0)
            {
                BindGrid();
                MessageShow1.ShowMessage("Audit2Yes");
                MessageShow1.Visible = true;
            }
            else
            {
                MessageShow1.ShowMessage("Audit2No");
                MessageShow1.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                BindGrid();
                MessageShow1.ShowMessage("DelYes");
                MessageShow1.Visible = true;
            }
            else
            {
                MessageShow1.ShowMessage("DelNo");
                MessageShow1.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            if (action.Delete(commandArgument) > 0)
            {
                BindGrid();
                MessageShow1.ShowMessage("DelYes");
                MessageShow1.Visible = true;
            }
            else
            {
                MessageShow1.ShowMessage("DelNo");
                MessageShow1.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SetCode();
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryDetails.aspx?guid=" + CheckGuid.Value.Replace("'", ""));
        }

        protected void CategoryCfBind()
        {
            DataTable list =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList("0");
            DropDownListCategoryCf.Items.Clear();
            DropDownListCategoryCf.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListCategoryCf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                              list.Rows[i]["ID"] + "/" + list.Rows[i]["Code"]));
            }
        }

        protected void DropDownListCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable list =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList(
                    DropDownListCategoryCf.SelectedValue.Split(new[] {'/'})[0]);
            DropDownListCategoryCs.Items.Clear();
            DropDownListCategoryCs.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListCategoryCs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                              list.Rows[i]["ID"] + "/" + list.Rows[i]["Code"]));
            }
            DropDownListCategoryCs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable list =
                ((ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action()).GetList(
                    DropDownListCategoryCs.SelectedValue.Split(new[] {'/'})[0]);
            DropDownListCategoryCt.Items.Clear();
            DropDownListCategoryCt.Items.Add(new ListItem("-«Î—°‘Ò-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListCategoryCt.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                              list.Rows[i]["ID"] + "/" + list.Rows[i]["Code"]));
            }
        }

        protected string GetValidateTime(object valitime)
        {
            try
            {
                return valitime.ToString().Split(new[] {'/'})[0];
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
            return "…Û∫ÀŒ¥Õ®π˝";
        }

        private void BindData()
        {
            DropDownListIsAudit.Items.Add(new ListItem("“—…Û∫À", "1"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                CategoryCfBind();
                BindData();
                DropDownListCategoryCf_SelectedIndexChanged(null, null);
                SetCode();
                BindGrid();
            }
        }

        public void SetCode()
        {
            if (DropDownListCategoryCt.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCategoryCt.SelectedValue.Split(new[] {'/'})[1];
            }
            else if (DropDownListCategoryCs.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCategoryCs.SelectedValue.Split(new[] {'/'})[1];
            }
            else if (DropDownListCategoryCf.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCategoryCf.SelectedValue.Split(new[] {'/'})[1];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }
    }
}