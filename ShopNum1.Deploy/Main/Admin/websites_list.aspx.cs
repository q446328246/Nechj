using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class websites_list : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                DropDownListProductGuidBind();
                BindData();
            }
        }

        public void BindData()
        {
            returnProductCategory();
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            if (LogicFactory.CreateShopNum1_WebSite_Action().DeleteById(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除站群成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "websites_list.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
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
            IShopNum1_WebSite_Action action = LogicFactory.CreateShopNum1_WebSite_Action();
            var action1 = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (action.DeleteById(commandArgument) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除站群成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "websites_list.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("websites_Operate.aspx?ID=" + CheckGuid.Value);
        }

        public void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonUpdata_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("websites_Operate.aspx?ID=" + CheckGuid.Value + "&Type=1");
        }

        protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductGuid2.Items.Clear();
            DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_WebSite_Action) LogicFactory.CreateShopNum1_WebSite_Action()).GetList(
                        DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                    list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
            DropDownListProductGuid2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductGuid3.Items.Clear();
            DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListProductGuid2.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_WebSite_Action) LogicFactory.CreateShopNum1_WebSite_Action()).GetList(
                        DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                    list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListProductGuidBind()
        {
            DropDownListProductGuid1.Items.Clear();
            DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list = ((ShopNum1_WebSite_Action) LogicFactory.CreateShopNum1_WebSite_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListProductGuid1_SelectedIndexChanged(null, null);
        }

        public string GetListImageStatus(string isshow)
        {
            if (isshow == "True")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        public void returnProductCategory()
        {
            if (DropDownListProductGuid3.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListProductGuid2.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListProductGuid1.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }
    }
}