using ShopNum1.Common;
using System;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class index : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    base.CheckNoPowerLogin();
                }
                catch (Exception ex)
                {


                    base.Response.Redirect("Login.aspx");
                }
            }
            checkT_UserGuid();
        }

        public void checkT_UserGuid() {
            if (base.checkadmin())
            {
                a_NewBlackList.Attributes.Remove("style");//显示黑名单
                a_Select_Money_All.Attributes.Remove("style");//显示admin每日资金统计
            }
            else {
              
            }
        }

    }
}