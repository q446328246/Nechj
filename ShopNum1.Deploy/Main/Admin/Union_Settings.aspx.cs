using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Union_Settings : PageBase, IRequiresSessionState
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
            string[] congName = new string[3];
            string[] congValue = new string[3];
            congName[0] = "UnionPostUrl";
            congValue[0] = this.TextBoxUnionPostUrl.Text;
            congName[1] = "SourceKey";
            congValue[1] = this.TextBoxKey.Text;
            congName[2] = "IsIntergrationUnion";
            if (this.CheckBoxIsIntergration.Checked)
            {
                congValue[2] = "1";
                switch (this.method_5(this.TextBoxUnionPostUrl.Text + "IntergrationCheck.aspx?SourceKey=" + this.TextBoxKey.Text))
                {
                    case "0":
                    case "":
                        MessageBox.Show("联盟系统的地址或是密钥不对！");
                        break;

                    case "1":
                          HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                
                        log = new ShopNum1_OperateLog
                        {
                            Record = "联盟系统设置成功",
                            OperatorID = cookie2.Values["LoginID"].ToString(),
                            IP = Globals.IPAddress,
                            PageName = "Union_Settings.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                        base.OperateLog(log);
                        WebConfigOperate.UpdateAppSetConfigValue(congName, congValue);
                        MessageBox.Show("操作成功！");
                        break;
                }
            }
            else
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                log = new ShopNum1_OperateLog
                {
                    Record = "联盟系统设置成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "Union_Settings.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                congValue[2] = "0";
                WebConfigOperate.UpdateAppSetConfigValue(congName, congValue);
                MessageBox.Show("操作成功！");
            }
        }

        protected void GetInfo()
        {
            this.TextBoxUnionPostUrl.Text = WebConfigOperate.GetAppSetConfigValue("UnionPostUrl");
            this.TextBoxKey.Text = WebConfigOperate.GetAppSetConfigValue("SourceKey");
            if (WebConfigOperate.GetAppSetConfigValue("IsIntergrationUnion") == "1")
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
            request.Timeout = 0xbb8;
            try
            {
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