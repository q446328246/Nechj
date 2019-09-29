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
    public partial class SendEmailHistory_List : PageBase, IRequiresSessionState
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
            this.Num1GridView.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_Email_Action action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
            if (action.Deleted(this.CheckGuid.Value.ToString()) > 0)
            {
                this.BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click1(object sender, EventArgs e)
        {
            ShopNum1_Email_Action action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
            if (action.Deleted(this.CheckGuid.Value.ToString()) > 0)
            {
                this.BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.string_9 == "")
                {
                    MessageBox.Show("请到设置配置邮件发送账号及邮件回复账号！");
                }
                else
                {
                    NetMail mail = new NetMail();
                    mail.MailDomain=this.string_5;
                    mail.Mailserverport=Convert.ToInt32(this.string_7.Trim());
                    mail.Username=this.string_6;
                    mail.Password=this.string_8;
                    mail.Html=true;
                    ShopNum1_Email_Action action = new ShopNum1_Email_Action();
                    DataTable emailGroupSendInfo = action.GetEmailGroupSendInfo(this.CheckGuid.Value.Replace("'", ""));
                    mail.AddRecipient(emailGroupSendInfo.Rows[0]["SendObjectEmail"].ToString());
                    mail.Subject=emailGroupSendInfo.Rows[0]["EmailTitle"].ToString();
                    mail.Body=emailGroupSendInfo.Rows[0]["Remark"].ToString();
                    mail.From=this.string_9;
                    if (!mail.Send())
                    {
                        this.MessageShow.ShowMessage("SendNoteNo");
                        this.MessageShow.Visible = true;
                    }
                    else
                    {
                        ShopNum1_EmailGroupSend emailGroupSend = new ShopNum1_EmailGroupSend
                        {
                            State = 2,
                            Guid = new Guid(this.CheckGuid.Value.ToString().Replace("'", ""))
                        };
                        if (action.Update(emailGroupSend) > 0)
                        {
                            this.BindGrid();
                            this.MessageShow.ShowMessage("SendNoteYes");
                            this.MessageShow.Visible = true;
                        }
                        else
                        {
                            this.MessageShow.ShowMessage("SendNoteNo");
                            this.MessageShow.Visible = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
            return "error";
        }

        public string ChangeState(string strState)
        {
            if (strState == "0")
            {
                return "发送失败";
            }
            if (strState == "1")
            {
                return "未发送";
            }
            if (strState == "2")
            {
                return "发送成功";
            }
            return "";
        }

        protected void GetEmailSetting()
        {
            DataSet set = new DataSet();
            set.ReadXml(this.HiddenFieldXmlPath.Value);
            this.string_4 = set.Tables[0].Rows[0]["EmailServer"].ToString();
            this.string_5 = set.Tables[0].Rows[0]["SMTP"].ToString();
            this.string_7 = set.Tables[0].Rows[0]["ServerPort"].ToString();
            this.string_6 = set.Tables[0].Rows[0]["EmailAccount"].ToString();
            this.string_8 = set.Tables[0].Rows[0]["EmailPassword"].ToString();
            this.string_9 = set.Tables[0].Rows[0]["RestoreEmail"].ToString();
            this.string_10 = set.Tables[0].Rows[0]["EmailCode"].ToString();
        }

        private void BindData()
        {
            try
            {
                ListItem item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
                this.DropDownListIsTime.Items.Add(item);
                ListItem item2 = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
                this.DropDownListState.Items.Add(item2);
                ListItem item3 = new ListItem
                {
                    Text = "发送失败",
                    Value = "0"
                };
                this.DropDownListState.Items.Add(item3);
                ListItem item4 = new ListItem
                {
                    Text = "未失败",
                    Value = "1"
                };
                this.DropDownListState.Items.Add(item4);
                ListItem item5 = new ListItem
                {
                    Text = "发送成功",
                    Value = "2"
                };
                this.DropDownListState.Items.Add(item5);
                ListItem item6 = new ListItem
                {
                    Text = "是",
                    Value = "0"
                };
                this.DropDownListIsTime.Items.Add(item6);
                ListItem item7 = new ListItem
                {
                    Text = "否",
                    Value = "1"
                };
                this.DropDownListIsTime.Items.Add(item7);
            }
            catch
            {
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.HiddenFieldXmlPath.Value = base.Server.MapPath("~/Main/Settings/Site_Settings.xml");
            this.GetEmailSetting();
            if (!this.Page.IsPostBack)
            {
                this.BindData();
                this.BindGrid();
            }
        }
    }
}