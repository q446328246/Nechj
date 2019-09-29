using System;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UCDiscuz_Settings : PageBase, IRequiresSessionState
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
            XmlDocument document = method_5();
            string filename = HttpContext.Current.Request.PhysicalApplicationPath + @"WebConfig\AppSettings.config";
            string str2 = "/appSettings/add[@key='?']";
            XmlNode node = document.SelectSingleNode(str2.Replace("?", "UC_IP"));
            XmlNode node2 = document.SelectSingleNode(str2.Replace("?", "UC_API"));
            XmlNode node3 = document.SelectSingleNode(str2.Replace("?", "UC_KEY"));
            XmlNode node4 = document.SelectSingleNode(str2.Replace("?", "UC_CHARSET"));
            XmlNode node5 = document.SelectSingleNode(str2.Replace("?", "UC_APPID"));
            XmlNode node6 = document.SelectSingleNode(str2.Replace("?", "IsIntergrationUCenter"));
            node.Attributes["value"].InnerText = TextBoxDiscuzPostUrl.Text.Trim();
            node2.Attributes["value"].InnerText = TextBoxUCenterUrl.Text.Trim();
            node3.Attributes["value"].InnerText = TextBoxSecret.Text.Trim();
            node4.Attributes["value"].InnerText = TextBoxCharset.Text.Trim();
            node5.Attributes["value"].InnerText = TextBoxIDValue.Text.Trim();
            if (CheckBoxIsIntegration.Checked)
            {
                node6.Attributes["value"].InnerText = "1";
            }
            else
            {
                node6.Attributes["value"].InnerText = "0";
            }
            try
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
          
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "Ucenter设置成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "UCDiscuz_Settings.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                document.Save(filename);
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败,检查是否有修改权限");
            }
        }

        protected void CheckBoxIsIntegration_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IsIntegrationDiscuz"] == "1")
            {
                CheckBoxIsIntegration.Checked = false;
                base.ClientScript.RegisterStartupScript(Page.GetType(), "MSG",
                                                        "<script type='text/javascript'>alert('已集成Discuz，为了系统稳定不能集成UCenter！')</script>",
                                                        false);
            }
        }

        protected void GetInfo()
        {
            TextBoxDiscuzPostUrl.Text = ConfigurationManager.AppSettings["UC_IP"];
            TextBoxUCenterUrl.Text = ConfigurationManager.AppSettings["UC_API"];
            TextBoxSecret.Text = ConfigurationManager.AppSettings["UC_KEY"];
            TextBoxCharset.Text = ConfigurationManager.AppSettings["UC_CHARSET"];
            TextBoxIDValue.Text = ConfigurationManager.AppSettings["UC_APPID"];
            string str = ConfigurationManager.AppSettings["IsIntergrationUCenter"];
            if (str == "1")
            {
                CheckBoxIsIntegration.Checked = true;
            }
            else
            {
                CheckBoxIsIntegration.Checked = false;
            }
        }

        private XmlDocument method_5()
        {
            var document = new XmlDocument();
            string filename = HttpContext.Current.Request.PhysicalApplicationPath + @"WebConfig\AppSettings.config";
            document.Load(filename);
            return document;
        }
    }
}