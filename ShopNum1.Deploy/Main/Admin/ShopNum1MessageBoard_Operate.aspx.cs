using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1MessageBoard_Operate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.BindData();
                }
            }
        }

        private void BindData()
        {
            DataTable table = ((ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action()).Search(this.hiddenFieldGuid.Value);
            this.LabelMemLoginID.Text = (string.Format("{0}", table.Rows[0]["MemLoginID"]) == string.Empty) ? "ÄäÃû" : table.Rows[0]["MemLoginID"].ToString();
            this.LabelSendTime.Text = table.Rows[0]["SendTime"].ToString();
            this.Label2.Text = table.Rows[0]["ReplyUser"].ToString();
            this.TextBoxContent.Text = table.Rows[0]["Content"].ToString();
        }

    }
}