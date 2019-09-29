using ShopNum1.Common;
using System;
using System.Web.SessionState;
namespace ShopNum1.Deploy.Main.Admin
{
    public partial class TbCategory_Settings : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.GetInfo();
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string[] congName = new string[2];
            string[] congValue = new string[2];
            congName[0] = "AdminAppKey";
            congValue[0] = this.TextBoxKey.Text;
            congName[1] = "AdminAppSecret";
            congValue[1] = this.TextBoxUnionPostUrl.Text;
            WebConfigOperate.UpdateAppSetConfigValue(congName, congValue);
            MessageBox.Show("²Ù×÷³É¹¦£¡");
        }

        protected void GetInfo()
        {
            this.TextBoxUnionPostUrl.Text = WebConfigOperate.GetAppSetConfigValue("AdminAppSecret");
            this.TextBoxKey.Text = WebConfigOperate.GetAppSetConfigValue("AdminAppKey");
        }
    }
}