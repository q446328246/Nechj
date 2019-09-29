using System;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceSite_EmailSetting : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                this.BindEmailCode();
                this.BindSetting();
            }
        }
        protected void BindEmailCode()
        {
            this.CheckBoxListEmailCode.Items.Add(new ListItem("默认编码", "0"));
        }
        protected void BindSetting()
        {
            XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    string name = xmlNode2.Name;
                    switch (name)
                    {
                        case "EmailServer":
                            this.selectSendType.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "SSL":
                            if (xmlNode2.InnerText == "1")
                            {
                                this.cbSSL.Checked = true;
                            }
                            break;
                        case "SMTP":
                            this.txtSmtpServer.Text = xmlNode2.InnerText;
                            break;
                        case "ServerPort":
                            this.TextBoxServerPort.Text = xmlNode2.InnerText;
                            break;
                        case "EmailAccount":
                            this.TextBoxEmailAccount.Text = xmlNode2.InnerText;
                            break;
                        case "EmailPassword":
                            this.HidPassword.Value = Common.Encryption.Decrypt(xmlNode2.InnerText);
                            this.TextBoxEmailPassword.Value = Common.Encryption.Decrypt(xmlNode2.InnerText);
                            break;
                        case "RestoreEmail":
                            this.TextBoxRestoreEmail.Text = xmlNode2.InnerText;
                            break;
                        case "EmailCode":
                            this.CheckBoxListEmailCode.SelectedValue = xmlNode2.InnerText;
                            break;
                    }
                }
            }
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            int num = 1;
            try
            {
                this.Updata();
            }
            catch (Exception)
            {
                num = 0;
            }
            if (num > 0)
            {
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="设置邮件接口";
                shopNum1_OperateLog.OperatorID=base.ShopNum1LoginID;
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="ServiceSite_EmailSetting.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
          
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                ShopSettings.ResetShopSetting();
                this.TextBoxEmailAddress.Value = "";
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }
        protected void Updata()
        {
            this.HidPassword.Value = this.TextBoxEmailPassword.Value;
            if (this.cbSSL.Checked)
            {
            }
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailServer", this.selectSendType.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SMTP", this.txtSmtpServer.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ServerPort", this.TextBoxServerPort.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailAccount", this.TextBoxEmailAccount.Text);
            if (this.TextBoxEmailPassword.Value != "")
            {
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailPassword", Common.Encryption.Encrypt(this.TextBoxEmailPassword.Value));
            }
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RestoreEmail", this.TextBoxRestoreEmail.Text);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailCode", this.CheckBoxListEmailCode.SelectedValue);
            ShopSettings.ResetShopSetting();
        }
        protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
        {
            new Random();
            string fileName = fileUpload.PostedFile.FileName;
            FileInfo fileInfo = new FileInfo(fileName);
            string text = "~/Upload/";
            fileName.Substring(fileName.LastIndexOf(".") + 1);
            string arg_3E_0 = fileUpload.PostedFile.ContentType;
            int contentLength = fileUpload.PostedFile.ContentLength;
            bool result;
            if (fileName != "")
            {
                if (contentLength < 1024000)
                {
                    if (!Directory.Exists(base.Server.MapPath(text)))
                    {
                        Directory.CreateDirectory(base.Server.MapPath(text));
                    }
                    fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
                    strext = fileName;
                    result = true;
                }
                else
                {
                    strext = "文件不能大于1M！";
                    result = false;
                }
            }
            else
            {
                strext = "upload 为空！";
                result = false;
            }
            return result;
        }
        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            NetMail netMail = new NetMail();
            netMail.MailDomain=this.txtSmtpServer.Text.Trim();
            netMail.Mailserverport=Convert.ToInt32(this.TextBoxServerPort.Text.Trim());
            netMail.Username=this.TextBoxEmailAccount.Text.Trim();
            if (this.HidPassword.Value != "")
            {
                netMail.Password=this.HidPassword.Value;
            }
            else
            {
                netMail.Password=this.TextBoxEmailPassword.Value;
            }
            netMail.Html=true;
            netMail.AddRecipient(this.TextBoxEmailAddress.Value.Trim());
            netMail.Subject="发送邮件测试";
            netMail.Body="邮件发送成功！";
            netMail.From=this.TextBoxRestoreEmail.Text.Trim();
            if (!netMail.Send())
            {
                MessageBox.Show("发送失败！请检查系统邮箱和测试邮箱配置是否正确！");
            }
            else
            {
                MessageBox.Show("发送成功!");
                this.TextBoxEmailAddress.Value = "";
            }
        }
       
    }
}