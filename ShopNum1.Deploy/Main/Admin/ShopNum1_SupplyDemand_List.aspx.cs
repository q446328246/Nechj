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
    public partial class ShopNum1_SupplyDemand_List : PageBase, IRequiresSessionState
    {
        protected void BindCommon_Cf()
        {
            DataTable list =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action()).GetList("0");
            DropDownListCommon_Cf.Items.Clear();
            DropDownListCommon_Cf.Items.Add(new ListItem("-请选择-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListCommon_Cf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                             list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListCommon_Cf_SelectedIndexChanged(null, null);
            SetCode();
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Update(CheckGuid.Value, "1") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("Audit1Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit1No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Update(CheckGuid.Value, "0") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除供求信息成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_SupplyDemand_List.aspx",
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
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除供求信息成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_SupplyDemand_List.aspx",
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SetCode();
            BindGrid();
        }

        protected void ButtonSerch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("SupplyDemandDetails.aspx?guid=" + CheckGuid.Value.Replace("'", "") + "&&type=list");
        }

        protected void DropDownListCommon_Cf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCommon_Cs.Items.Clear();
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            DropDownListCommon_Cs.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListCommon_Cf.SelectedValue != "-1")
            {
                DataTable list = action.GetList(DropDownListCommon_Cf.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListCommon_Cs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                 list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListCommon_Cs_SelectedIndexChanged(null, null);
            SetCode();
        }

        protected void DropDownListCommon_Cs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            DropDownListCommon_Ct.Items.Clear();
            DropDownListCommon_Ct.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListCommon_Cs.SelectedValue != "-1")
            {
                DataTable list = action.GetList(DropDownListCommon_Cs.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListCommon_Ct.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                 list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            SetCode();
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
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            return "审核未通过";
        }

        public string IsOutOFTime(object object_0)
        {
            if (Convert.ToDateTime(object_0) < DateTime.Now.ToLocalTime())
            {
                return "<font color=red>已过期</font>";
            }
            return "<font color=green>未过期</font>";
        }

        public string IsValidTime(object object_0)
        {
            string str = object_0.ToString();
            if (str.IndexOf("/") != -1)
            {
                return str.Split(new[] {'/'})[0];
            }
            return str;
        }

        private void BindData()
        {
            DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                BindCommon_Cf();
                SetCode();
                BindGrid();
            }
        }

        public void SetCode()
        {
            if (DropDownListCommon_Ct.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCommon_Ct.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListCommon_Cs.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCommon_Cs.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListCommon_Cf.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListCommon_Cf.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }

        public string ShowTradeType(object object_0)
        {
            string str = object_0.ToString();
            if (str != null)
            {
                if (!(str == "0"))
                {
                    if (str == "1")
                    {
                        return "求购";
                    }
                }
                else
                {
                    return "供应";
                }
            }
            return "供应";
        }
    }
}