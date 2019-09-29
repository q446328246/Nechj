using System;
using System.Collections.Generic;
using System.Text;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;
using ShopNum1.Email;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class EmailSetting : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                if (base.Request.QueryString["op"] != null)
                {
                    string text = base.Request.QueryString["op"].ToString();
                    if (text != null)
                    {
                        if (!(text == "getdata"))
                        {
                            if (text == "savedata")
                            {
                                base.Response.Write("");
                            }
                        }
                        else
                        {
                            base.Response.Write(this.method_5(this.GetXmlData()));
                        }
                    }
                }
            }
        }

        private string method_5(List<string> list_0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            if (list_0.Count > 0)
            {
                for (int i = 0; i < list_0.Count; i++)
                {
                    string[] array = list_0[i].Split(new char[]
				{
					'|'
				});
                    stringBuilder.Append("{");
                    stringBuilder.Append(string.Concat(new string[]
				{
					"\"name\":\"",
					array[0],
					"\",\"tagname\":\"",
					array[1],
					"\",\"value\":\"",
					array[2],
					"\""
				}));
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Append("},");
                }
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        protected List<string> GetXmlData()
        {
            List<string> list = new List<string>();
            XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    string name = xmlNode2.Name;
                    switch (name)
                    {
                        case "EmailServer":
                            list.Add("EmailServer|���ͷ�ʽ��|" + xmlNode2.InnerText);
                            break;
                        case "SSL":
                            if (xmlNode2.InnerText == "1")
                            {
                                this.cbSSL.Checked = true;
                            }
                            break;
                        case "SMTP":
                            list.Add("SMTP|SMTP��������|" + xmlNode2.InnerText);
                            break;
                        case "ServerPort":
                            list.Add("ServerPort|SMTP�������˿ڣ�|" + xmlNode2.InnerText);
                            break;
                        case "EmailAccount":
                            list.Add("EmailAccount|SMTP�û����� |" + xmlNode2.InnerText);
                            break;
                        case "EmailPassword":
                            list.Add("EmailPassword|SMTP�û����룺 |" + xmlNode2.InnerText);
                            break;
                        case "RestoreEmail":
                            list.Add("RestoreEmail|�ʼ��ظ���ַ��|" + xmlNode2.InnerText);
                            break;
                    }
                }
            }
            return list;
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            NetMail netMail = new NetMail();
            netMail.MailDomain=this.txtSmtpServer.Text.Trim();
            netMail.Mailserverport=Convert.ToInt32(this.TextBoxServerPort.Text.Trim());
            netMail.Username=this.TextBoxEmailAccount.Text.Trim();
            netMail.Password=this.TextBoxEmailPassword.Value;
            netMail.Html=true;
            netMail.AddRecipient(this.TextBoxEmailAddress.Text.Trim());
            netMail.Subject="�����ʼ�����";
            netMail.Body="�ʼ����ͳɹ���";
            netMail.From=this.TextBoxRestoreEmail.Text.Trim();
            if (!netMail.Send())
            {
                MessageBox.Show("����ʧ�ܣ�����ϵͳ����Ͳ������������Ƿ���ȷ��");
            }
            else
            {
                MessageBox.Show("���ͳɹ�!");
                this.TextBoxEmailAddress.Text = "";
            }
        }

    }
}