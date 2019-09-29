using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MMSGroupSend_List : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
            if (!Page.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            if (action.Deleted(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MMSGroupSend_List.aspx",
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
                DataTable mMSGroupSendInfo = action.GetMMSGroupSendInfo(CheckGuid.Value.Replace("'", ""));
                string str = string.Empty;
                string content = string.Empty;
                try
                {
                    content = mMSGroupSendInfo.Rows[0]["SendObjectMMS"].ToString();
                    str = mMSGroupSendInfo.Rows[0]["SendObject"].ToString();
                    if (str.IndexOf("-") != -1)
                    {
                        str = str.Split(new[] {'-'})[1];
                    }
                }
                catch (Exception)
                {
                }
                var sms = new SMS();
                string retmsg = "";
                if (str == "")
                {
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                }
                sms.Send(str.Trim(), content, out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    var mMSGroupSend = new ShopNum1_MMSGroupSend
                        {
                            State = 2,
                            Guid = new Guid(CheckGuid.Value.Replace("'", ""))
                        };
                    if (action.Update(mMSGroupSend) > 0)
                    {
                        MessageShow.ShowMessage("重新发送成功！");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("重新发送失败！");
                        MessageShow.Visible = true;
                    }
                }
                else
                {
                    MessageShow.ShowMessage(retmsg);
                    MessageShow.Visible = true;
                }
            }
            catch (Exception exception)
            {
                MessageShow.ShowMessage(exception.Message);
                MessageShow.Visible = true;
            }
        }

        public string ChangeisTime(string isTime)
        {
            if (isTime == "0")
            {
                return " 不定时";// LocalizationUtil.GetChangeMessage("EmailGroupSend", "Istime", "0");
            }
            if (isTime == "1")
            {
                return " 定时";//LocalizationUtil.GetChangeMessage("EmailGroupSend", "Istime", "1");
            }
            return "";
        }

        public string ChangeState(string strState)
        {
            if (strState == "0")
            {
                return " 发送失败"; //LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "0");
            }
            if (strState == "1")
            {
                return " 未发送"; //LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "1");
            }
            if (strState == "2")
            {
                return " 发送成功"; //LocalizationUtil.GetChangeMessage("EmailGroupSend", "State", "2");
            }
            return "";
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


    }
}