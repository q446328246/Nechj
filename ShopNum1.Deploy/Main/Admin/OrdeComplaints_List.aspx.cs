using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrdeComplaints_List : PageBase, IRequiresSessionState
    {
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除投诉信息",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "OrdeComplaints_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                BindData();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
            if (action.Delete(commandArgument) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除投诉信息",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "OrdeComplaints_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                BindData();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrdeComplaints_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected string IsProcess(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未处理";
            }
            if (object_0.ToString() == "1")
            {
                return "处理中";
            }
            if (object_0.ToString() == "2")
            {
                return "已处理";
            }
            return "非法状态";
        }

        private void method_5()
        {
            DropDownListType.Items.Clear();
            DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
            DropDownListType.Items.Add(new ListItem("恶意骚扰", "恶意骚扰"));
            DropDownListType.Items.Add(new ListItem("售后保障服务", "售后保障服务"));
            DropDownListType.Items.Add(new ListItem("未收到货", "未收到货"));
            DropDownListType.Items.Add(new ListItem("违背承诺", "违背承诺"));
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                method_5();
                BindData();
            }
        }

        public string ShowType(string type)
        {
            return "";
        }
    }
}