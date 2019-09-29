using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.DataAccess;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopCategoryAply_Audit : PageBase, IRequiresSessionState
    {
        protected void BindProductIsAudit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.DeleteShopCategoryApply("'" + CheckGuid.Value.Replace("'", "") + "'") > 0)
            {
                BindData();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.DeleteShopCategoryApply(guids) > 0)
            {
                BindData();
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
                BindData();
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
                BindData();
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
            BindData();
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

        private DataTable method_5(string string_4, string string_5, string string_6, string string_7, string string_8,
                                   string string_9)
        {
            string str = string.Empty;
            str =
                "SELECT A.*,B.ShopName,B.ShopUrl FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID ";
            if (!string.IsNullOrEmpty(string_4))
            {
                str = str + " AND B.ShopName='" + string_4.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(string_5))
            {
                str = str + " AND A.ShopID='" + string_5.Trim() + "'";
            }
            if ((string_6.Trim() != "-1") && (string_6.Trim() != ""))
            {
                str = str + " AND A.OldShopCategoryCode='" + string_6.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(string_7))
            {
                str = str + " AND A.IsAudit=" + string_7.Trim();
            }
            if (!string.IsNullOrEmpty(string_8))
            {
                str = str + " AND A.ApplyTime>='" + string_8.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(string_9))
            {
                str = str + " AND A.ApplyTime<='" + string_9.Trim() + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " AND A.IsAudit IN (0,2) ORDER BY A.ApplyTime DESC");
        }

        private void BindData()
        {
            SetShopCategoryCode();
            Num1GridViewShow.DataSource = method_5("", "", "", "", "", "").DefaultView;
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindProductIsAudit();
                DropDownListShopCategoryCode1Bind();
                BindData();
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