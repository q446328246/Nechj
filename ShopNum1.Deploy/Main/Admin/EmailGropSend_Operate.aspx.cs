using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class EmailGropSend_Operate : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state)
        {
            ShopNum1_EmailGroupSend send = new ShopNum1_EmailGroupSend
            {
                Guid = Guid.NewGuid()
            };
            string str = string.Empty;
            str = this.DropDownListEmailTitle.SelectedItem.Text.Trim();
            str = this.TextBoxEmailTitle.Text.Trim().Replace("'", "");
            send.EmailTitle = str;
            send.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            send.EmailGuid = new Guid("00000000-0000-0000-0000-000000000000");
            send.SendObjectEmail = this.FCKeditorContent.Text;
            if (memLoginID != email)
            {
                send.SendObject = memLoginID + "-" + email;
            }
            else
            {
                send.SendObject = memLoginID;
            }
            send.State = state;
            return send;
        }

        protected void BindStatus()
        {
            ListItem item = new ListItem
            {
                Text = "-请选择-",
                Value = "-1"
            };
            this.DropDownListEmailTitle.Items.Add(item);
            ShopNum1_Email_Action action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                ListItem item2 = new ListItem
                {
                    Text = row["Title"].ToString().Trim(),
                    Value = row["Guid"].ToString().Trim()
                };
                this.DropDownListEmailTitle.Items.Add(item2);
            }
            ListItem item3 = new ListItem
            {
                Text = "自定义模板标题",
                Value = "00000000-0000-0000-0000-000000000000"
            };
            this.DropDownListEmailTitle.Items.Add(item3);
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
            {
                Record = "邮件群发",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "EmailGroupSend_Operate.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            this.ButtonConfirm.Text = "发送中...";
            this.method_6();
            this.ButtonConfirm.Text = "确定";
        }

        protected void DropDownListEmailTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FCKeditorContent.Text = string.Empty;
            if (this.DropDownListEmailTitle.SelectedValue != "00000000-0000-0000-0000-000000000000")
            {
                DataTable table = ((ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action()).SearchEmailContent(this.DropDownListEmailTitle.SelectedValue);
                this.FCKeditorContent.Text = table.Rows[0]["Remark"].ToString();
                if (this.DropDownListEmailTitle.SelectedValue == "-1")
                {
                    this.FCKeditorContent.Text = string.Empty;
                }
                this.txtDefine.Visible = false;
            }
            else
            {
                this.FCKeditorContent.Text = string.Empty;
                this.txtDefine.Visible = true;
            }
            this.hidSelect.Value = this.DropDownListEmailTitle.SelectedValue;
        }

        protected void GetEmailSetting()
        {
            new ShopSettings();
            DataSet set = new DataSet();
            set.ReadXml(this.HiddenFieldXmlPath.Value);
            this.string_4 = set.Tables[0].Rows[0]["EmailServer"].ToString();
            this.string_5 = set.Tables[0].Rows[0]["SMTP"].ToString();
            this.string_7 = set.Tables[0].Rows[0]["ServerPort"].ToString();
            this.string_6 = set.Tables[0].Rows[0]["EmailAccount"].ToString();
            this.string_8 = set.Tables[0].Rows[0]["EmailPassword"].ToString();
            this.string_9 = set.Tables[0].Rows[0]["RestoreEmail"].ToString();
            this.string_10 = set.Tables[0].Rows[0]["EmailCode"].ToString();
            this.string_11 = set.Tables[0].Rows[0]["EmailCode"].ToString();
        }

        private void BindData()
        {
        }

        private void method_6()
        {
            if (this.FCKeditorContent.Text == string.Empty)
            {
                MessageBox.Show("邮件内容不能为空!");
            }
            else if (this.FCKeditorContent.Text.Length > 0x3e8)
            {
                MessageBox.Show("你输入的邮件内容长度已经大于1000，<br/>请删减文字！");
            }
            else
            {
                int num2;
                NetMail mail = new NetMail();
                mail.MailDomain=this.string_5;
                mail.Mailserverport=Convert.ToInt32(this.string_7.Trim());
                mail.Username=this.string_6;
                mail.Password=ShopNum1.Common.Encryption.Decrypt(this.string_8);
                mail.Html=true;
                mail.Subject=this.TextBoxEmailTitle.Text.Trim();
                if (this.DropDownListEmailTitle.SelectedItem.Value.Trim() == "00000000-0000-0000-0000-000000000000")
                {
                    mail.Subject=this.txtDefine.Text.Trim().Replace("'", "");
                }
                mail.Body=this.FCKeditorContent.Text;
                mail.From=this.string_9;
                new List<string>();
                string[] strArray2 = this.hidValue.Value.Split(new char[] { '|' });
                ShopNum1_Email_Action action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                bool flag2 = true;
                bool flag = true;
                int num3 = 0;
                int num4 = 0;
                string str3 = string.Empty;
                string str2 = string.Empty;
                if (this.RadioButtonListSendObject.SelectedValue == "0")
                {
                    num2 = 0;
                    while (num2 < strArray2.Length)
                    {
                        if (strArray2[num2].ToString() != "")
                        {
                            string str = strArray2[num2];
                            string[] strArray = null;
                            if (str.IndexOf(';') != -1)
                            {
                                strArray = str.Split(new char[] { ';' });
                            }
                            else
                            {
                                strArray = (str + ";").Split(new char[] { ';' });
                            }
                            mail.AddRecipient(strArray[0]);
                            try
                            {
                                ShopNum1_EmailGroupSend send2;
                                if (!mail.Send())
                                {
                                    flag = false;
                                    num4++;
                                    str2 = str2 + strArray[1] + ",";
                                    send2 = this.Add(strArray[0], strArray[1], 0);
                                    action.AddEmailGroupSend(send2);
                                }
                                else
                                {
                                    flag2 = false;
                                    num3++;
                                    str3 = str3 + strArray[1] + ",";
                                    send2 = this.Add(strArray[1], strArray[0], 2);
                                    action.AddEmailGroupSend(send2);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        num2++;
                    }
                }
                else
                {
                    DataTable table;
                    int num;
                    ListItem item;
                    ShopNum1_EmailGroupSend send;
                    if (this.RadioButtonListSendObject.SelectedValue == "1")
                    {
                        for (num2 = 0; num2 < strArray2.Length; num2++)
                        {
                            if (strArray2[num2].ToString() != "")
                            {
                                ShopNum1_Member_Action action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                table = action2.SearchMemberAssignGroup(strArray2[num2].ToString());
                                num = 0;
                                while (num < table.Rows.Count)
                                {
                                    if (table.Rows[num]["Email"].ToString().IndexOf("@") != -1)
                                    {
                                        item = new ListItem
                                        {
                                            Text = table.Rows[num]["MemLoginID"].ToString(),
                                            Value = table.Rows[num]["Email"].ToString()
                                        };
                                        mail.AddRecipient(item.Value);
                                        if (!mail.Send())
                                        {
                                            flag = false;
                                            str2 = str2 + item.Text;
                                            send = this.Add(item.Text, item.Value, 0);
                                            action.AddEmailGroupSend(send);
                                        }
                                        else
                                        {
                                            flag2 = false;
                                            str3 = str3 + item.Text;
                                            send = this.Add(item.Text, item.Value, 2);
                                            action.AddEmailGroupSend(send);
                                        }
                                    }
                                    num++;
                                }
                            }
                        }
                    }
                    else if (this.RadioButtonListSendObject.SelectedValue == "3")
                    {
                        for (num2 = 0; num2 < strArray2.Length; num2++)
                        {
                            if (strArray2[num2] != "")
                            {
                                table = new ShopNum1_Member_Action().SearchMemberByMemberRank(strArray2[num2]);
                                if (table != null)
                                {
                                    for (num = 0; num < table.Rows.Count; num++)
                                    {
                                        if (table.Rows[num]["Email"].ToString().IndexOf("@") != -1)
                                        {
                                            item = new ListItem
                                            {
                                                Text = table.Rows[num]["MemLoginID"].ToString(),
                                                Value = table.Rows[num]["Email"].ToString()
                                            };
                                            mail.AddRecipient(item.Value);
                                            if (!mail.Send())
                                            {
                                                flag = false;
                                                this.method_7();
                                                str2 = str2 + item.Text;
                                                send = this.Add(item.Text, item.Value, 0);
                                                action.AddEmailGroupSend(send);
                                            }
                                            else
                                            {
                                                flag2 = false;
                                                str3 = str3 + item.Text + "|";
                                                send = this.Add(item.Text, item.Value, 2);
                                                action.AddEmailGroupSend(send);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (this.RadioButtonListSendObject.SelectedValue == "5")
                    {
                        strArray2 = this.TextBoxSendObjectEmail.Text.Trim().Split(new char[] { ';' });
                        for (num2 = 0; num2 < strArray2.Length; num2++)
                        {
                            if (strArray2[num2].ToString().IndexOf("@") != -1)
                            {
                                mail.AddRecipient(strArray2[num2]);
                                if (!mail.Send())
                                {
                                    flag = false;
                                    this.method_7();
                                    str2 = str2 + strArray2[num2];
                                    send = this.Add(strArray2[num2], strArray2[num2], 0);
                                    action.AddEmailGroupSend(send);
                                }
                                else
                                {
                                    flag2 = false;
                                    str3 = str3 + strArray2[num2];
                                    send = this.Add(strArray2[num2], strArray2[num2], 2);
                                    action.AddEmailGroupSend(send);
                                }
                            }
                        }
                    }
                }
                if (!flag)
                {
                    if ((str3 != null) && (str3 != ""))
                    {
                        this.MessageShow.ShowMessage(str2 + "的邮件发送失败，可能是没有这个邮箱地址, " + str3 + "的邮件发送成功！");
                    }
                    else
                    {
                        this.MessageShow.ShowMessage("邮件接口没有配置好，请在邮件发送接口那里测试邮件是否可以发送！");
                    }
                    this.MessageShow.Visible = true;
                }
                else if (flag2)
                {
                    this.MessageShow.ShowMessage("你选择的对象，没有可供发送的邮件地址！");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage(str3 + "的邮件发送成功！");
                    this.MessageShow.Visible = true;
                }
            }
        }

        private void method_7()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.HiddenFieldXmlPath.Value = base.Server.MapPath("~/Settings/ShopSetting.xml");
            this.GetEmailSetting();
            this.BindData();
            if (!this.Page.IsPostBack)
            {
                this.RadioButtonListSendObject.SelectedIndex = 0;
                this.RadioButtonListSendObject_SelectedIndexChanged(null, null);
                this.BindStatus();
            }
        }

        protected void RadioButtonListSendObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action;
            ListItem item;
            if (this.RadioButtonListSendObject.SelectedValue == "0")
            {
                this.LabeSendTObjectEmail.Text = "选择会员：";
                this.selectEmail.Items.Clear();
                this.selectEmail.Visible = true;
                this.TextBoxSendObjectEmail.Visible = false;
                action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                foreach (DataRow row in action.SearchMember(0).DefaultView.Table.Rows)
                {
                    if (row["Email"].ToString().IndexOf("@") != -1)
                    {
                        item = new ListItem
                        {
                            Text = row["Email"].ToString().Trim() + ";" + row["MemLoginID"].ToString().Trim(),
                            Value = row["Email"].ToString().Trim() + ";" + row["MemLoginID"].ToString().Trim()
                        };
                        this.selectEmail.Items.Add(item);
                    }
                }
            }
            if (this.RadioButtonListSendObject.SelectedValue == "1")
            {
                this.LabeSendTObjectEmail.Text = "选择短信组:";
                this.selectEmail.Items.Clear();
                this.selectEmail.Visible = true;
                this.TextBoxSendObjectEmail.Visible = false;
                ShopNum1_Email_Action action2 = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                foreach (DataRow row in action2.SearchMemberGroup(0).DefaultView.Table.Rows)
                {
                    item = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                    this.selectEmail.Items.Add(item);
                }
            }
            if (this.RadioButtonListSendObject.SelectedValue == "3")
            {
                this.LabeSendTObjectEmail.Text = "选择会员等级:";
                this.selectEmail.Items.Clear();
                this.selectEmail.Visible = true;
                this.TextBoxSendObjectEmail.Visible = false;
                action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                foreach (DataRow row in action.SearchMemberRank(0).DefaultView.Table.Rows)
                {
                    item = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["minScore"].ToString() + "/" + row["maxScore"].ToString()
                    };
                    this.selectEmail.Items.Add(item);
                }
            }
            if (this.RadioButtonListSendObject.SelectedValue == "5")
            {
                this.selectEmail.Items.Clear();
                this.selectEmail.Visible = false;
                this.TextBoxSendObjectEmail.Visible = true;
                this.LabeSendTObjectEmail.Text = "输入邮件地址：";
                this.Labelmessage.Text = "多个邮件地址以\";\"分割";
            }
        }
    }
}