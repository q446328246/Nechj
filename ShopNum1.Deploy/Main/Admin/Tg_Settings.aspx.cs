using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Tg_Settings : PageBase, IRequiresSessionState
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
            ShopNum1_OperateLog log;
            System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
            AppSettingsSection section = (AppSettingsSection)configuration.GetSection("appSettings");
            section.Settings["TgPostUrl"].Value = this.TextBoxUnionPostUrl.Text;
            section.Settings["TgSourceKey"].Value = this.TextBoxKey.Text;
            if (this.CheckBoxIsIntergration.Checked)
            {
                section.Settings["IsIntergrationTg"].Value = "1";
                string str = this.method_5(section.Settings["TgPostUrl"].Value + "IntergrationCheck.aspx?TgSourceKey=" + section.Settings["TgSourceKey"].Value);
                if (str == "0")
                {
                    MessageBox.Show("团购系统的地址或是密钥不对！");
                }
                else if (str == "1")
                {
                      HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                  
                    log = new ShopNum1_OperateLog
                    {
                        Record = "团购系统设置成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Tg_Settings.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(log);
                    MessageBox.Show("操作成功！");
                    configuration.Save();
                }
                else
                {
                    MessageBox.Show("团购系统的地址或是密钥不对！");
                }
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                log = new ShopNum1_OperateLog
                {
                    Record = "团购系统设置成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "Tg_Settings.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                section.Settings["IsIntergrationTg"].Value = "0";
                MessageBox.Show("操作成功！");
                configuration.Save();
            }
        }

        protected void GetInfo()
        {
            this.TextBoxUnionPostUrl.Text = ConfigurationManager.AppSettings["TgPostUrl"];
            this.TextBoxKey.Text = ConfigurationManager.AppSettings["TgSourceKey"];
            string str = ConfigurationManager.AppSettings["IsIntergrationTg"];
            if (str == "1")
            {
                this.CheckBoxIsIntergration.Checked = true;
            }
            else
            {
                this.CheckBoxIsIntergration.Checked = false;
            }
        }

        private string method_5(string string_4)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_4);
            try
            {
                request.Timeout = 0x7d0;
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }



    }
}