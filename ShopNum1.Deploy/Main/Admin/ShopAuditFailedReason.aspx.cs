using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopAuditFailedReason : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string strTitle, string email, int state, string scont)
        {
            return new ShopNum1_EmailGroupSend
                {
                    Guid = Guid.NewGuid(),
                    EmailTitle = strTitle,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    EmailGuid = new Guid("60c1bef2-33e4-4510-944c-afca43d09f0c"),
                    SendObjectEmail = scont,
                    SendObject = memLoginID + "-" + email,
                    State = state
                };
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state,
                                               string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
                {
                    Guid = Guid.NewGuid(),
                    MMSTitle = MMsTitle,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    MMSGuid = new Guid(mmsGuid),
                    SendObjectMMS = mobile,
                    SendObject = memLoginID + "-" + mobile,
                    State = state
                };
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (
                action.UpdateShopState(Page.Request.QueryString["guid"].Replace("'", ""),
                                       TextBoxShopAuditFailedReason.Text.Trim(), base.ShopNum1LoginID,
                                       DateTime.Now.ToString(), 2) > 0)
            {
                if (ShopSettings.GetValue("AuditOpenShopIsEmail") == "1")
                {
                    IsEmail(Page.Request.QueryString["guid"]);
                }
                if (ShopSettings.GetValue("AuditOpenShopIsMMS") == "1")
                {
                    IsMMS();
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员审核店铺不通过",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopAuditFailedReason.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
                ReturnMoney();
                PanelShow.Visible = false;
                PanelShowMsg.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(),"name", "<script>window.parent.location.reload();</script>");
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_4 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailServer"));
            string_5 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            string_7 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "ServerPort"));
            string_6 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailAccount"));
            string_8 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailPassword"));
            string_9 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "RestoreEmail"));
            string_10 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailCode"));
        }

        protected void IsEmail(string strId)
        {
            try
            {
                DataTable memberInfoByGuID =
                    ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(
                        strId.Replace("'", ""));
                if (memberInfoByGuID.Rows[0]["Email"].ToString() != "")
                {
                    ShopNum1_EmailGroupSend send;
                    string str3 = ShopSettings.GetValue("Name");
                    var shop = new ShopNum1.Email.OpenShop();
                    GetEmailSetting();
                    var mail = new NetMail();
                    mail.MailDomain=string_5;
                    mail.Mailserverport=Convert.ToInt32(string_7.Trim());
                    mail.Username=string_6;
                    mail.Password=string_8;
                    mail.Html=true;
                    mail.AddRecipient(memberInfoByGuID.Rows[0]["Email"].ToString());
                    shop.Name= memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
                    shop.ShopID=ShopSettings.GetValue("PersonShopUrl") + memberInfoByGuID.Rows[0]["ShopID"].ToString();
                    shop.ShopStatus="审核不通过";
                    shop.SysSendTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    shop.ShopName=str3;
                    string s = string.Empty;
                    string strTitle = string.Empty;
                    var action2 = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
                    DataTable editInfo = action2.GetEditInfo("'5387cec4-05ed-41d1-bc1f-c900c4959585'", 0);
                    if (editInfo.Rows.Count > 0)
                    {
                        s = editInfo.Rows[0]["Remark"].ToString();
                        strTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    s =
                        s.Replace("{$Name}", memberInfoByGuID.Rows[0]["MemLoginID"].ToString())
                         .Replace("{$ShopName}", shop.ShopName)
                         .Replace("{$SendTime}", DateTime.Now.ToString());
                    mail.Subject=strTitle;
                    mail.Body=shop.ChangeOpenShop(Page.Server.HtmlDecode(s));
                    mail.From=string_9;
                    if (!mail.Send())
                    {
                        send = Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle,
                                   memberInfoByGuID.Rows[0]["Email"].ToString(), 0, mail.Body);
                        action2.AddEmailGroupSend(send);
                    }
                    else
                    {
                        send = Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle,
                                   memberInfoByGuID.Rows[0]["Email"].ToString(), 2, mail.Body);
                        action2.AddEmailGroupSend(send);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void IsMMS()
        {
            try
            {
                ShopNum1_MMSGroupSend send;
                string newValue = ShopSettings.GetValue("Name");
                string mMsTitle = string.Empty;
                string str3 = string.Empty;
                string mobile = string.Empty;
                string mmsGuid = "60c1bef2-33e4-4510-944c-afca43d09f0c";
                string content = string.Empty;
                IShopNum1_MMS_Action action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = action.GetEditInfo(mmsGuid, 0);
                Guid.NewGuid().ToString();
                if (editInfo.Rows.Count > 0)
                {
                    content = editInfo.Rows[0]["Remark"].ToString();
                    mMsTitle = editInfo.Rows[0]["Title"].ToString();
                }
                DataTable memberInfoByGuID =
                    ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(
                        Page.Request.QueryString["guid"].Replace("'", ""));
                if (memberInfoByGuID.Rows.Count > 0)
                {
                    str3 = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
                    if (memberInfoByGuID.Rows[0]["tel"].ToString() != "")
                    {
                        mobile = memberInfoByGuID.Rows[0]["tel"].ToString();
                    }
                    else
                    {
                        mobile = memberInfoByGuID.Rows[0]["mobile"].ToString();
                    }
                }
                content =
                    content.Replace("恭喜", "抱歉")
                           .Replace("已经通过审核", "未通过审核")
                           .Replace("{$Name}", str3)
                           .Replace("{$ShopName}", newValue)
                           .Replace("{$SendTime} ", DateTime.Now.ToString("yyyy-MM-dd"));
                var sms = new SMS();
                string retmsg = "";
                sms.Send(mobile, content + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    send = AddMMS(str3, mobile, mMsTitle, 2, mmsGuid);
                    action.AddMMSGroupSend(send);
                }
                else
                {
                    send = AddMMS(str3, mobile, mMsTitle, 0, mmsGuid);
                    action.AddMMSGroupSend(send);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ReturnMoney()
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string guidid = Page.Request.QueryString["guid"];
            guidid.Replace("'", "");
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllShopInfoByGuid(guidid);
            string guid = string.Empty;
            decimal payprice = 0M;
            string memLoginID = string.Empty;
            if ((allShopInfoByGuid != null) && (allShopInfoByGuid.Rows.Count > 0))
            {
                guid = allShopInfoByGuid.Rows[0]["ShopRank"].ToString();
                memLoginID = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
            }
            decimal num2 = 0M;
            try
            {
                num2 = Convert.ToDecimal(action.GetAdvancePayment(memLoginID).Rows[0][0].ToString());
            }
            catch (Exception)
            {
            }
            if (guid != "")
            {
                DataTable shopRankPrice =
                    ((Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action()).GetShopRankPrice(guid);
                if ((shopRankPrice != null) && (shopRankPrice.Rows.Count > 0))
                {
                    payprice = Convert.ToDecimal(shopRankPrice.Rows[0][0].ToString());
                }
            }
            if ((payprice > 0M) && (action.UpdateAdvancePayment_RV(0, memLoginID, payprice) > 0))
            {
                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = 5,
                        CurrentAdvancePayment = num2,
                        OperateMoney = payprice,
                        LastOperateMoney = Convert.ToDecimal(num2) + payprice,
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Memo = "开店铺审核失败，返回金币（BV）",
                        MemLoginID = memLoginID,
                        CreateUser = memLoginID,
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                ((ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                    .OperateMoney(advancePaymentModifyLog);
            }
        }
    }
}