using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Prouduct_PanicChecked_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                DropDownListProductGuidBind();
                method_6();
                BindData();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            SetCode();
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Update(CheckGuid.Value, "1") > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员审核通过抢购商品",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Prouduct_PanicChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            var action = (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Update(CheckGuid.Value, "2") > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员审核不通过抢购商品",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Prouduct_PanicChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            var action = (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除抢购商品",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Prouduct_PanicChecked_List.aspx",
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
            var action = (ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除抢购商品",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Prouduct_PanicChecked_List.aspx",
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

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + CheckGuid.Value.Replace("'", "") +
                                   "&Type=Panic&Back=4");
        }

        protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductGuid2.Items.Clear();
            DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable list =
                    ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(
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
                    ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(
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
            DataTable list =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(),
                                                                list.Rows[i]["Code"] + "/" + list.Rows[i]["ID"]));
            }
            DropDownListProductGuid1_SelectedIndexChanged(null, null);
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
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        private void method_6()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListIsSaled.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "未上架",
                    Value = "0"
                };
            DropDownListIsSaled.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "下架",
                    Value = "1"
                };
            DropDownListIsSaled.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = "已上架",
                    Value = "2"
                };
            DropDownListIsSaled.Items.Add(item4);
        }



        public void SetCode()
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