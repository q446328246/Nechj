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
                    Record = "����Աɾ��Ͷ����Ϣ",
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
                    Record = "����Աɾ��Ͷ����Ϣ",
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
                return "δ����";
            }
            if (object_0.ToString() == "1")
            {
                return "������";
            }
            if (object_0.ToString() == "2")
            {
                return "�Ѵ���";
            }
            return "�Ƿ�״̬";
        }

        private void method_5()
        {
            DropDownListType.Items.Clear();
            DropDownListType.Items.Add(new ListItem("-ȫ��-", "-1"));
            DropDownListType.Items.Add(new ListItem("����ɧ��", "����ɧ��"));
            DropDownListType.Items.Add(new ListItem("�ۺ��Ϸ���", "�ۺ��Ϸ���"));
            DropDownListType.Items.Add(new ListItem("δ�յ���", "δ�յ���"));
            DropDownListType.Items.Add(new ListItem("Υ����ŵ", "Υ����ŵ"));
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