using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ChangeScoreLog_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "1")
            {
                return "���ͺ��";
            }
            if (operateType == "2")
            {
                return "ת�˺��";
            }
            if (operateType == "3")
            {
                return "�һ���Ʒ";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                BindGrid();
            }
        }
    }
}