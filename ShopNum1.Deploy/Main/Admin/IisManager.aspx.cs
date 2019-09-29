using System;
using System.Web.SessionState;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class IisManager : PageBase, IRequiresSessionState
    {
        protected void ButtonIisRecycle_Click(object sender, EventArgs e)
        {
            Utils.RestartIISProcess();
            method_5();
        }

        protected void ButtonIISRest_Click(object sender, EventArgs e)
        {
            Utils.RestartIISProcess();
            method_5();
        }

        private void method_5()
        {
            Utils.RestartIISProcess();
            base.RegisterStartupScriptNew("PAGE", "window.location.href=window.location.href ;");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}