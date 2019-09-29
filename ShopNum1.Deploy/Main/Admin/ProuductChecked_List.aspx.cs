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
    public partial class ProuductChecked_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.DropDownListProductGuidBind();
                this.method_6();
                this.BindData();
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.SetCode();
            this.Num1GridViewShow.DataBind();
        }
        //资格审核
        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Update(this.CheckGuid.Value, "1") > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                //资格商品
                action.UpdateAgent(this.CheckGuid.Value, "0");
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核通过商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductChecked_List.aspx",
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

        //普通审核
        protected void ButtonAudit1_Click(object sender, EventArgs e)
        {
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Update(this.CheckGuid.Value, "1") > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                //普通商品
                action.UpdateAgent(this.CheckGuid.Value, "2");
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核通过商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductChecked_List.aspx",
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
            object obj2 = this.CheckGuid.Value;
            if (obj2.ToString() == "0")
            {
                obj2 = "null";
            }
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Update(obj2.ToString(), "2") > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核不通过商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductChecked_List.aspx",
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
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除审核商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductChecked_List.aspx",
                    Date = DateTime.Now
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

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.SetCode();
            this.BindGrid();
        }

        protected void ButtonSearchBylink_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string str = "'" + button.CommandArgument + "'";
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + str + "&Type=Other&Back=2");
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + this.CheckGuid.Value.Replace("'", "") + "&Type=Other&Back=2");
        }

        protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid2.Items.Clear();
            this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
            }
            this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid3.Items.Clear();
            this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
            }
        }

        protected void DropDownListProductGuidBind()
        {
            this.DropDownListProductGuid1.Items.Clear();
            this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
            }
            this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
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
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        protected void LinkDelte_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除审核商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductChecked_List.aspx",
                    Date = DateTime.Now
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

        private void BindData()
        {
            this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
            if (ShopNum1.Common.Common.ReqStr("audit") == "0")
            {
                this.DropDownListIsAudit.SelectedValue = "0";
            }
        }

        private void method_6()
        {
            ListItem item = new ListItem
            {
                Text = "-全部-",
                Value = "-1"
            };
            this.DropDownListIsSaled.Items.Add(item);
            ListItem item2 = new ListItem
            {
                Text = "否",
                Value = "0"
            };
            this.DropDownListIsSaled.Items.Add(item2);
            ListItem item3 = new ListItem
            {
                Text = "是",
                Value = "1"
            };
            this.DropDownListIsSaled.Items.Add(item3);
        }



        public void SetCode()
        {
            if (this.DropDownListProductGuid3.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[] { '/' })[0];
            }
            else
            {
                this.HiddenFieldCode.Value = "-1";
            }
        }
    }
}