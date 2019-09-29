using System;
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
    public partial class EmailGroupSend_List : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Deleted(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "EmailGroupSend_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Deleted("'" + commandArgument + "'") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if (string_9 == "")
            {
                MessageBox.Show("请到商城设置中配置邮件发送账号及邮件回复账号！");
            }
            else
            {
                var mail = new NetMail();
                mail.MailDomain=string_5;
                mail.Mailserverport=Convert.ToInt32(string_7.Trim());
                mail.Username=string_6;
                mail.Password=string_8;
                mail.Html=true;
                var action = new ShopNum1_Email_Action();
                DataTable emailGroupSendInfo = action.GetEmailGroupSendInfo(CheckGuid.Value.Replace("'", ""));
                if ((emailGroupSendInfo != null) && (emailGroupSendInfo.Rows.Count > 0))
                {
                    mail.AddRecipient(emailGroupSendInfo.Rows[0]["SendObject"].ToString().Split(new[] {'-'})[1]);
                    mail.Subject=emailGroupSendInfo.Rows[0]["EmailTitle"].ToString();
                    mail.Body=emailGroupSendInfo.Rows[0]["SendObjectEmail"].ToString();
                    mail.From=string_9;
                    if (!mail.Send())
                    {
                        MessageShow.ShowMessage("SendNoteNo");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        var emailGroupSend = new ShopNum1_EmailGroupSend
                            {
                                State = 2,
                                Guid = new Guid(CheckGuid.Value.Replace("'", ""))
                            };
                        if (action.Update(emailGroupSend) > 0)
                        {
                            BindGrid();
                            MessageShow.ShowMessage("SendNoteYes");
                            MessageShow.Visible = true;
                        }
                        else
                        {
                            MessageShow.ShowMessage("SendNoteNo");
                            MessageShow.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageShow.ShowMessage("SendNoteNo");
                    MessageShow.Visible = true;
                }
            }
        }

        public string ChangeisTime(string isTime)
        {
            if (isTime == "0")
            {
                return "不定时";
            }
            if (isTime == "1")
            {
                return "定时";
            }
            return "";
        }

        public string ChangeState(string strState)
        {
            if (strState == "0")
            {
                return " 发送失败";// LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "0");
            }
            if (strState == "1")
            {
                return " 未发送";//LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "1");
            }
            if (strState == "2")
            {
                return " 发送成功";//LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "2");
            }
            return "";
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_4 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "EmailServer"));
            string_5 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "SMTP"));
            string_7 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "ServerPort"));
            string_6 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "EmailAccount"));
            string_8 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "EmailPassword"));
            string_9 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "RestoreEmail"));
            string_10 = Page.Server.HtmlDecode(settings.GetValue(HiddenFieldXmlPath.Value, "EmailCode"));
        }

        private void BindData()
        {
            try
            {
                var item = new ListItem
                    {
                        Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                        Value = "-1"
                    };
                DropDownListIsTime.Items.Add(item);
                var item2 = new ListItem
                    {
                        Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                        Value = "-1"
                    };
                DropDownListState.Items.Add(item2);
                var item3 = new ListItem
                    {
                        Text = " 发送失败",//LocalizationUtil.GetCommonMessage("State0"),
                        Value = "0"
                    };
                DropDownListState.Items.Add(item3);
                var item4 = new ListItem
                    {
                        Text = " 未发送",//LocalizationUtil.GetCommonMessage("State1"),
                        Value = "1"
                    };
                DropDownListState.Items.Add(item4);
                var item5 = new ListItem
                    {
                        Text = " 发送成功",//LocalizationUtil.GetCommonMessage("State2"),
                        Value = "2"
                    };
                DropDownListState.Items.Add(item5);
                var item6 = new ListItem
                    {
                        Text = " 不定时",//LocalizationUtil.GetCommonMessage("IsTime0"),
                        Value = "0"
                    };
                DropDownListIsTime.Items.Add(item6);
                var item7 = new ListItem
                    {
                        Text = " 定时",//LocalizationUtil.GetCommonMessage("IsTime1"),
                        Value = "1"
                    };
                DropDownListIsTime.Items.Add(item7);
            }
            catch
            {
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
            GetEmailSetting();
            if (!Page.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }
    }
}