using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MMSInterface_Operate : PageBase, IRequiresSessionState
    {
        public string StrPath = HttpContext.Current.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");

        protected void BindSetting()
        {
            var set = new DataSet();
            set.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow row = set.Tables["ShopSetting"].Rows[0];
            DropDownListType.SelectedValue = row["MMSType"].ToString();
            if (DropDownListType.SelectedValue == "0")
            {
                TextBoxCode.Text = row["Ecode"].ToString();
                TextBoxName.Text = row["UserName"].ToString();
                TextBoxPwd.Text = row["PassWord"].ToString();
            }
            else if (DropDownListType.SelectedValue == "1")
            {
                PanelType.Visible = true;
                TextBoxCode.Text = row["Ecode"].ToString();
                TextBoxName.Text = row["UserName"].ToString();
                TextBoxPwd.Text = row["PassWord"].ToString();
            }
            else if (DropDownListType.SelectedValue == "2")
            {
                PanelType.Visible = false;
                TextBoxName.Text = row["SMSUser"].ToString();
                TextBoxPwd.Text = row["SMSPass"].ToString();
            }
            else if (DropDownListType.SelectedValue == "3")
            {
                PanelType.Visible = false;
                TextBoxName.Text = row["SmsbaoUser"].ToString();
                TextBoxPwd.Text = row["SmsbaoPass"].ToString();
            }
        }

        protected void butTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("手机号码不能为空！");
            }
            else
            {
                var sms = new SMS();
                string retmsg = string.Empty;
                sms.Send(txtTel.Text, Operator.FilterString(txtRc.Text) + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    MessageShow.ShowMessage("发送成功！");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage(retmsg);
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/MMSType", DropDownListType.SelectedValue);
            if (DropDownListType.SelectedValue == "0")
            {
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/Ecode", TextBoxCode.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/UserName", TextBoxName.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/PassWord", ShopNum1.Common.Encryption.Encrypt(TextBoxPwd.Text));
            }
            else if (DropDownListType.SelectedValue == "1")
            {
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/Ecode", TextBoxCode.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/UserName", TextBoxName.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/PassWord", ShopNum1.Common.Encryption.Encrypt(TextBoxPwd.Text));
            }
            else if (DropDownListType.SelectedValue == "2")
            {
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/SMSUser", TextBoxName.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/SMSPass", ShopNum1.Common.Encryption.Encrypt(TextBoxPwd.Text));
            }
            else if (DropDownListType.SelectedValue == "3")
            {
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/SmsbaoUser", TextBoxName.Text);
                XmlOperator.XmlNodeReplace(StrPath, "ShopSetting/SmsbaoPass", ShopNum1.Common.Encryption.Encrypt(TextBoxPwd.Text));
            }
            BindSetting();
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "短信接口设置",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "MMSInterface_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            MessageShow.ShowMessage("EditYes");
            MessageShow.Visible = true;
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelType.Visible = false;
            var set = new DataSet();
            set.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow row = set.Tables["ShopSetting"].Rows[0];
            if (DropDownListType.SelectedValue == "0")
            {
                TextBoxName.Text = row["UserName"].ToString();
                TextBoxPwd.Text = row["PassWord"].ToString();
            }
            else if (DropDownListType.SelectedValue == "1")
            {
                PanelType.Visible = true;
                TextBoxCode.Text = row["Ecode"].ToString();
                TextBoxName.Text = row["UserName"].ToString();
                TextBoxPwd.Text = row["PassWord"].ToString();
            }
            else if (DropDownListType.SelectedValue == "2")
            {
                TextBoxName.Text = row["SMSUser"].ToString();
                TextBoxPwd.Text = row["SMSPass"].ToString();
            }
            else if (DropDownListType.SelectedValue == "3")
            {
                TextBoxName.Text = row["SmsbaoUser"].ToString();
                TextBoxPwd.Text = row["SmsbaoPass"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindSetting();
            }
        }
    }
}