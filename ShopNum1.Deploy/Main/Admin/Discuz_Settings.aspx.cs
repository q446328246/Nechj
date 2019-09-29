using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Discuz_Settings : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                GetInfo();
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
            var section = (AppSettingsSection)configuration.GetSection("appSettings");
            section.Settings["DiscuzPostUrl"].Value = TextBoxDiscuzPostUrl.Text;
            section.Settings["DiscuzApiKey"].Value = TextBoxApiKey.Text;
            section.Settings["DiscuzSecret"].Value = TextBoxSecret.Text;
            section.Settings["DiscuzCookieDomain"].Value = TextBoxDomain.Text;
            if (CheckBoxIsIntegration.Checked)
            {
                section.Settings["IsIntegrationDiscuz"].Value = "1";
            }
            else
            {
                section.Settings["IsIntegrationDiscuz"].Value = "0";
            }
            try
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "Discuz论坛设置成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Discuz_Settings.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                DiscuzSessionHelper.GetSession();
                configuration.Save();
                MessageBox.Show("修改成功");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void CheckBoxIsIntegration_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
            {
                CheckBoxIsIntegration.Checked = false;
                base.ClientScript.RegisterStartupScript(Page.GetType(), "MSG",
                                                        "<script type='text/javascript'>alert('已集成UCenter，为了系统的稳定不要同时集成Discuz！')</script>",
                                                        false);
            }
        }

        protected void GetInfo()
        {
            TextBoxDiscuzPostUrl.Text = ConfigurationManager.AppSettings["DiscuzPostUrl"];
            TextBoxApiKey.Text = ConfigurationManager.AppSettings["DiscuzApiKey"];
            TextBoxSecret.Text = ConfigurationManager.AppSettings["DiscuzSecret"];
            TextBoxDomain.Text = ConfigurationManager.AppSettings["DiscuzCookieDomain"];
            string str = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
            if (str == "1")
            {
                CheckBoxIsIntegration.Checked = true;
            }
            else
            {
                CheckBoxIsIntegration.Checked = false;
            }
        }

    }
}