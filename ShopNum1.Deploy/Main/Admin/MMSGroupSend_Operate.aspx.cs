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
    public partial class MMSGroupSend_Operate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_MMS_Action shopNum1_MMS_Action_0 =
            ((ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action());

        private bool bool_1;

        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_12 = "";
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected ShopNum1_MMSGroupSend Add(string memLoginID, string mobile, int state, string noteContent)
        {
            return new ShopNum1_MMSGroupSend
                {
                    Guid = Guid.NewGuid(),
                    MMSTitle = dropTemplte.SelectedItem.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    MMSGuid = new Guid(dropTemplte.SelectedValue),
                    SendObjectMMS = noteContent,
                    SendObject = memLoginID + "-" + mobile,
                    State = state
                };
        }

        protected void BindDropDownListMMSCaregory()
        {
            ListItem item2;
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            DataView defaultView = action.Search(0).DefaultView;
            var item = new ListItem
                {
                    Text = "-请选择短信模板-",
                    Value = "00000000-0000-0000-0000-000000000000"
                };
            dropTemplte.Items.Add(item);
            foreach (DataRow row in defaultView.Table.Rows)
            {
                item2 = new ListItem
                    {
                        Text = row["Title"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                dropTemplte.Items.Add(item2);
            }
            LabeSendTObjectMMS.Text = "选择会员:";
            selectMMS.Items.Clear();
            var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            foreach (DataRow row in action2.SearchMember(0).DefaultView.Table.Rows)
            {
                if (row["Tel"].ToString().Length == 11)
                {
                    selectMMS.Visible = true;
                    TextBoxSendObjectMMS.Visible = false;
                    item2 = new ListItem
                        {
                            Text = row["MemLoginID"].ToString().Trim() + "-" + row["Tel"].ToString().Trim(),
                            Value = row["MemLoginID"].ToString().Trim() + "-" + row["Tel"].ToString().Trim()
                        };
                    selectMMS.Items.Add(item2);
                }
            }
        }

        protected void BindStatus()
        {
            DropDownListMMSTitle.Items.Clear();
            var item = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "-1"
                };
            DropDownListMMSTitle.Items.Add(item);
            var action = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
            foreach (
                DataRow row in
                    action.Search(string.Empty, DropDownListMMSCaregory.SelectedValue, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Title"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                DropDownListMMSTitle.Items.Add(item2);
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (FCKeditorContent.Text == string.Empty)
            {
                MessageBox.Show("短信内容不能为空!");
            }
            else
            {
                int num;
                DataTable table;
                int num2;
                ListItem item;
                var sms = new SMS();
                string[] strArray = hidValue.Value.Split(new[] {'|'});
                if (RadioButtonListSendObject.SelectedValue == "0")
                {
                    for (num2 = 0; num2 < strArray.Length; num2++)
                    {
                        if (strArray[num2].Split(new[] {'-'})[1] != "")
                        {
                            bool_1 = true;
                            sms.Send(strArray[num2].Split(new[] { '-' })[1], Operator.FilterString(FCKeditorContent.Text) + "【唐江宝宝】",
                                     out string_12);
                        }
                    }
                }
                if (RadioButtonListSendObject.SelectedValue == "1")
                {
                    for (num2 = 0; num2 < strArray.Length; num2++)
                    {
                        table = shopNum1_MMS_Action_0.SearchMemberAssignGroup(strArray[num2]);
                        num = 0;
                        while (num < table.Rows.Count)
                        {
                            if (table.Rows[num]["TEL"].ToString().Length == 11)
                            {
                                bool_1 = true;
                                item = new ListItem
                                    {
                                        Text = table.Rows[num]["MemLoginID"].ToString(),
                                        Value = table.Rows[num]["TEL"].ToString()
                                    };
                                sms.Send(item.Value, Operator.FilterString(FCKeditorContent.Text) + "【唐江宝宝】", out string_12);
                            }
                            num++;
                        }
                    }
                }
                if (RadioButtonListSendObject.SelectedValue == "3")
                {
                    for (num2 = 0; num2 < strArray.Length; num2++)
                    {
                        table = new ShopNum1_Member_Action().SearchMemberByMemberRank(strArray[num2]);
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            if (table.Rows[num]["Mobile"].ToString().Length == 11)
                            {
                                bool_1 = true;
                                item = new ListItem
                                    {
                                        Text = table.Rows[num]["MemLoginID"].ToString(),
                                        Value = table.Rows[num]["Mobile"].ToString()
                                    };
                                sms.Send(item.Value, Operator.FilterString(FCKeditorContent.Text) + "【唐江宝宝】", out string_12);
                            }
                        }
                    }
                }
                if (RadioButtonListSendObject.SelectedValue == "5")
                {
                    string str = TextBoxSendObjectMMS.Text.Replace("\r\n", "");
                    if (str == "")
                    {
                        MessageBox.Show("请输入手机号码");
                        return;
                    }
                    string[] strArray2 = str.Split(new[] {';'});
                    for (num2 = 0; num2 < strArray2.Length; num2++)
                    {
                        if (!(strArray2[num2] == ""))
                        {
                            if (!method_5(strArray2[num2]))
                            {
                                MessageBox.Show("输入不正确");
                                return;
                            }
                            bool_1 = true;
                            sms.Send(strArray2[num2], Operator.FilterString(FCKeditorContent.Text) + "【唐江宝宝】", out string_12);
                        }
                    }
                }
                if (bool_1)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "群发短信",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "MMSGroupSend_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageShow.ShowMessage("短信发送成功！");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("短信发送失败！");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ClearControl()
        {
            FCKeditorContent.Text = string.Empty;
        }

        protected void DropDownListMMSCaregory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListMMSCaregory.SelectedValue != "-1")
            {
                BindStatus();
            }
            else
            {
                DropDownListMMSTitle.Items.Clear();
                var item = new ListItem
                    {
                        Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                        Value = "-1"
                    };
                DropDownListMMSTitle.Items.Add(item);
            }
        }

        protected void DropDownListMMSTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FCKeditorContent.Text = string.Empty;
            DataTable table =
                ((ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action()).SearchMMSContent(
                    DropDownListMMSTitle.SelectedValue);
            FCKeditorContent.Text = table.Rows[0]["Remark"].ToString();
            if (DropDownListMMSTitle.SelectedValue == "-1")
            {
                FCKeditorContent.Text = string.Empty;
            }
        }

        protected void dropTemplte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FCKeditorContent.Text = string.Empty;
                DataTable table =
                    ((ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action()).SearchMMSContent(
                        dropTemplte.SelectedValue);
                FCKeditorContent.Text = table.Rows[0]["Remark"].ToString();
                if (dropTemplte.SelectedValue == "-1")
                {
                    FCKeditorContent.Text = string.Empty;
                }
                hidSelect.Value = dropTemplte.SelectedValue;
            }
            catch (Exception exception)
            {
                base.Response.Write(exception.Message);
            }
        }

        private bool method_5(string string_13)
        {
            for (int i = 0; i < string_13.Length; i++)
            {
                if ((string_13[i] < '0') || (string_13[i] > '9'))
                {
                    return false;
                }
            }
            return true;
        }

        private void method_6(string string_13, string string_14, string string_15, string string_16)
        {
            ShopNum1_MMSGroupSend send;
            if (string_12.IndexOf("发送成功") != -1)
            {
                send = Add(string_13, string_14, 2, string_15);
                shopNum1_MMS_Action_0.AddMMSGroupSend(send);
                MessageShow.ShowMessage("SendNoteYes");
                MessageShow.Visible = true;
            }
            else
            {
                send = Add(string_13, string_14, 0, string_15);
                shopNum1_MMS_Action_0.AddMMSGroupSend(send);
                MessageShow.ShowMessage("SendNoteNo");
                MessageShow.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                RadioButtonListSendObject.SelectedIndex = 0;
                BindDropDownListMMSCaregory();
            }
        }

        protected void RadioButtonListSendObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action;
            ListItem item;
            if (RadioButtonListSendObject.SelectedValue == "0")
            {
                LabeSendTObjectMMS.Text = "选择会员:";
                selectMMS.Items.Clear();
                action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                foreach (DataRow row in action.SearchMember(0).DefaultView.Table.Rows)
                {
                    if (row["Tel"].ToString() != "")
                    {
                        selectMMS.Visible = true;
                        TextBoxSendObjectMMS.Visible = false;
                        item = new ListItem
                            {
                                Text = row["MemLoginID"].ToString().Trim() + "-" + row["Tel"].ToString().Trim(),
                                Value = row["Tel"].ToString().Trim()
                            };
                        selectMMS.Items.Add(item);
                    }
                }
            }
            if (RadioButtonListSendObject.SelectedValue == "1")
            {
                LabeSendTObjectMMS.Text = "选择短信组:";
                selectMMS.Items.Clear();
                var action2 = (ShopNum1_MMS_Action) LogicFactory.CreateShopNum1_MMS_Action();
                foreach (DataRow row in action2.SearchMemberGroup(0).DefaultView.Table.Rows)
                {
                    selectMMS.Visible = true;
                    TextBoxSendObjectMMS.Visible = false;
                    item = new ListItem
                        {
                            Text = row["Name"].ToString().Trim(),
                            Value = row["Guid"].ToString().Trim()
                        };
                    selectMMS.Items.Add(item);
                }
            }
            if (RadioButtonListSendObject.SelectedValue == "3")
            {
                LabeSendTObjectMMS.Text = "选择会员等级:";
                selectMMS.Items.Clear();
                action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                foreach (DataRow row in action.SearchMemberRank(0).DefaultView.Table.Rows)
                {
                    selectMMS.Visible = true;
                    TextBoxSendObjectMMS.Visible = false;
                    item = new ListItem
                        {
                            Text = row["Name"].ToString().Trim(),
                            Value = row["minScore"] + "/" + row["maxScore"]
                        };
                    selectMMS.Items.Add(item);
                }
            }
            if (RadioButtonListSendObject.SelectedValue == "5")
            {
                selectMMS.Items.Clear();
                selectMMS.Visible = false;
                TextBoxSendObjectMMS.Visible = true;
                LabeSendTObjectMMS.Text = "输入手机号：";
                Labelmessage.Text = "多个手机号以\";\"分割";
            }
        }
    }
}