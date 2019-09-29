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
    public partial class ShopNum1_SupplyDemandCheck_List : PageBase, IRequiresSessionState
    {
        public string Audit(string isAudit)
        {
            if (isAudit == "0")
            {
                return "未审核";
            }
            if (isAudit == "1")
            {
                return "审核中";
            }
            if (isAudit == "2")
            {
                return "审核未通过";
            }
            if (isAudit == "3")
            {
                return "审核通过";
            }
            return "";
        }

        protected void BindCommon_Cf()
        {
            DataTable list = ((ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action()).GetList("0");
            this.DropDownListCommon_Cf.Items.Clear();
            this.DropDownListCommon_Cf.Items.Add(new ListItem("-请选择-", "-1"));
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListCommon_Cf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Update(this.CheckGuid.Value, "3") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "审核通过",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_SupplyDemandCheck_List.aspx",
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
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Update(this.CheckGuid.Value, "2") > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "审核未通过",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_SupplyDemandCheck_List.aspx",
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
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除供求评论信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_SupplyDemandCheck_List.aspx",
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
            string guids = "'" + button.CommandArgument + "'";
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            if (action.Delete(guids) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除供求评论信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_SupplyDemandCheck_List.aspx",
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
            this.SetCode();
            this.BindGrid();
        }

        protected void ButtonSerch_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("SupplyDemandDetails.aspx?guid=" + this.CheckGuid.Value.Replace("'", "") + "&&type=audit");
        }

        protected void DropDownListCommon_Cf_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListCommon_Cs.Items.Clear();
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            this.DropDownListCommon_Cs.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListCommon_Cf.SelectedValue != "-1")
            {
                DataTable list = action.GetList(this.DropDownListCommon_Cf.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListCommon_Cs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
            }
            this.DropDownListCommon_Cs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListCommon_Cs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShopNum1_SupplyDemandCheck_Action action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            this.DropDownListCommon_Ct.Items.Clear();
            this.DropDownListCommon_Ct.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListCommon_Cs.SelectedValue != "-1")
            {
                DataTable list = action.GetList(this.DropDownListCommon_Cs.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListCommon_Ct.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
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
            this.DropDownListIsAudit.Items.Clear();
            this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
                this.BindCommon_Cf();
                this.DropDownListCommon_Cf_SelectedIndexChanged(null, null);
                this.SetCode();
                if (ShopNum1.Common.Common.ReqStr("isAudit") != "")
                {
                    this.CheckAudit.Value = ShopNum1.Common.Common.ReqStr("isAudit");
                }
                this.BindGrid();
            }
        }

        public void SetCode()
        {
            if (this.DropDownListCommon_Ct.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCommon_Ct.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListCommon_Cs.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCommon_Cs.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListCommon_Cf.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListCommon_Cf.SelectedValue.Split(new char[] { '/' })[0];
            }
            else
            {
                this.HiddenFieldCode.Value = "-1";
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
            return "";
        }
    }
}