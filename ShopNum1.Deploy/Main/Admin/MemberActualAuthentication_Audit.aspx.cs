using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberActualAuthentication_Audit : PageBase, IRequiresSessionState
    {
        private ShopNum1_Member_Action shopNum1_Member_Action_0 =
            ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action());

        protected void BindProductIsAudit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-ȫ��-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("���δͨ��", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("δ���", "0"));
        }

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonOperate1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberActualAuthentication_Detai.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "δ���";
            }
            if (object_0.ToString() == "1")
            {
                return "��ͨ��";
            }
            if (object_0.ToString() == "2")
            {
                return "���δͨ��";
            }
            return "�Ƿ�״̬";
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                base.CheckLogin();
                BindProductIsAudit();
                BindData();
            }
        }
    }
}