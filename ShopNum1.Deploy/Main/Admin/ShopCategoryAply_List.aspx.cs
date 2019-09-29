using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopCategoryAply_List : PageBase, IRequiresSessionState
    {
        protected void BindProductIsAudit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("审核通过", "1"));
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.DeleteShopCategoryApply(CheckGuid.Value) > 0)
            {
                method_5();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            bool flag = false;
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.UpdataShopCategoryApplyIsAudit(CheckGuid.Value, "1") > 0)
            {
                method_5();
                string[] strArray = CheckGuid.Value.Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    DataTable shopCategoryInfoByGuid = action.GetShopCategoryInfoByGuid(strArray[i]);
                    if ((shopCategoryInfoByGuid != null) && (shopCategoryInfoByGuid.Rows.Count > 0))
                    {
                        string shopCategoryName = shopCategoryInfoByGuid.Rows[i]["ShopCategoryName"].ToString();
                        string shopCategoryCode = shopCategoryInfoByGuid.Rows[i]["NewShopCateGoryCode"].ToString();
                        string brandName = shopCategoryInfoByGuid.Rows[i]["BrandName"].ToString();
                        string brandGuid = shopCategoryInfoByGuid.Rows[i]["NewBrandGuid"].ToString();
                        if (
                            action.UpdateShopCategoryAndBrandByGuids(strArray[i], shopCategoryName, shopCategoryCode,
                                                                     brandName, brandGuid) > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
            }
            if (flag)
            {
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonOperate1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.UpdataShopCategoryApplyIsAudit(CheckGuid.Value, "2") > 0)
            {
                method_5();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_5();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopCategoryAply_SearchDetail.aspx?guid=" + CheckGuid.Value);
        }

        protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode2.Items.Clear();
            DropDownListShopCategoryCode2.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode1Bind()
        {
            DropDownListShopCategoryCode1.Items.Clear();
            DropDownListShopCategoryCode1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list =
                ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListShopCategoryCode1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                     list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListShopCategoryCode3.Items.Clear();
            DropDownListShopCategoryCode3.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action()).GetList(
                        DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                         list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void method_5()
        {
            SetShopCategoryCode();
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindProductIsAudit();
                DropDownListShopCategoryCode1Bind();
                method_5();
            }
        }

        public void SetShopCategoryCode()
        {
            if (DropDownListShopCategoryCode3.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListShopCategoryCode2.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListShopCategoryCode1.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListShopCategoryCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }
    }
}