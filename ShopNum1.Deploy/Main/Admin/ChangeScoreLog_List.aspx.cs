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
                return "赠送红包";
            }
            if (operateType == "2")
            {
                return "转账红包";
            }
            if (operateType == "3")
            {
                return "兑换商品";
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