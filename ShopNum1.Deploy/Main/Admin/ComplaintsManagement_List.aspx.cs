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
    public partial class ComplaintsManagement_List : PageBase, IRequiresSessionState
    {
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
            if (action.DeleteReport(CheckGuid.Value) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ���ٱ���Ϣ",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ComplaintsManagement_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                method_6();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
            var button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            if (action.DeleteReport(commandArgument) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ���ٱ���Ϣ",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ComplaintsManagement_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                method_6();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
            if (action.GetComplaintsManagement(CheckGuid.Value).Rows.Count > 0)
            {
                base.Response.Redirect("ComplaintsManagement_Operate.aspx?guid=" + CheckGuid.Value);
            }
            else
            {
                MessageBox.Show("�ٱ�����Ʒ�ѱ�ɾ���򲻴��ڣ�");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_6();
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
            DropDownListType.Items.Add(new ListItem("�������ö�", "�������ö�"));
            DropDownListType.Items.Add(new ListItem("��̧���", "��̧���"));
            DropDownListType.Items.Add(new ListItem("ͼƬ������Ȩ", "ͼƬ������Ȩ"));
            DropDownListType.Items.Add(new ListItem("���������Ϣ", "���������Ϣ"));
            DropDownListType.Items.Add(new ListItem("֧����ʽ��������Ʒ", "֧����ʽ��������Ʒ"));
            DropDownListType.Items.Add(new ListItem("���۽��ۻ�", "���۽��ۻ�"));
            DropDownListType.Items.Add(new ListItem("�Ŵ���Ŀ����", "�Ŵ���Ŀ����"));
            DropDownListType.Items.Add(new ListItem("�ظ��̻�", "�ظ��̻�"));
            DropDownListType.Items.Add(new ListItem("���ùؼ���", "���ùؼ���"));
        }

        private void method_6()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                method_5();
                method_6();
            }
        }
    }
}