using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UpdateShopURL : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string strTitle, string strContent, string email,
                                              int state, string scont)
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

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (string_4 == "Audit")
            {
                base.Response.Redirect("ShopInfoList_Audit.aspx");
            }
            else if (string_4 == "List")
            {
                base.Response.Redirect("ShopInfoList_Manage.aspx");
            }
            else if (string_4 == "openshop")
            {
                base.Response.Redirect("Member_List.aspx");
            }
        }

        protected void ButtonUpdata_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (string_4 == "List")
            {
                if (!method_6())
                {
                    MessageBox.Show("店铺URL已经存在！");
                    TextBoxShopURL.Focus();
                }
                else if (action.UpdataShopURLByGuid(CheckGuid.Value.Replace("'", ""), TextBoxShopURL.Text.Trim()) > 0)
                {
                    log = new ShopNum1_OperateLog
                    {
                        Record = "修改店铺URL成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "UpdateShopURL.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(log);
                    base.Response.Redirect("ShopInfoList_Manage.aspx");
                }
                else
                {
                    MessageShow.ShowMessage("Audit2No");
                    MessageShow.Visible = true;
                }
            }
            else if ((string_4 == "Audit") || (string_4 == "openshop"))
            {
                if ((((action.CheckShopURLIsRepeat(TextBoxShopURL.Text.Trim()).Rows[0]["ShopUrl"].ToString()) == "0" &&
                    (action.UpdateShopState(CheckGuid.Value, "IsAudit", "1") > 0) &&
                      (action.UpdateMemberType(CheckGuid.Value.Replace("'", ""), 2) > 0)) &&
                     (action.UpdateShopState(CheckGuid.Value, "IsExpires", "0") > 0)) &&
                    (action.UpdateShopState(CheckGuid.Value, "IsClose", "0") > 0)

                    )
                {
                    try
                    {
                        action.UpdateDate(CheckGuid.Value, DateTime.Now.ToString());
                        action.UpdataShopURLByGuid(CheckGuid.Value.Replace("'", ""), TextBoxShopURL.Text.Trim());
                        DataTable allShopInfoByGuid = action.GetAllShopInfoByGuid(CheckGuid.Value.Replace("'", ""));
                        string shopid = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
                        string s = allShopInfoByGuid.Rows[0]["ShopID"].ToString();
                        string str3 = allShopInfoByGuid.Rows[0]["TemplateType"].ToString();
                        action.InsertShopNav(shopid);
                        ShopNum1_PostageSettings_Action postavtion = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                        ShopNum1_PostageSettings post = new ShopNum1_PostageSettings();
                        post.MemLoginID = shopid;
                        postavtion.Add(post);
                        method_5(shopid, int.Parse(s), str3);
                        if (string_4 == "Audit")
                        {
                            if (ShopSettings.GetValue("AuditOpenShopIsEmail") == "1")
                            {
                                IsEmail();
                            }
                            if (ShopSettings.GetValue("AuditOpenShopIsMMS") == "1")
                            {
                                IsMMS();
                            }
                            base.Response.Redirect("ShopInfoList_Audit.aspx");
                        }
                        else if (string_4 == "openshop")
                        {
                            base.Response.Redirect("Member_List.aspx");
                        }
                    }
                    catch (Exception exception)
                    {
                        base.Response.Write(exception.Message);
                    }
                }
                else
                {
                    MessageShow.ShowMessage("Audit1No");
                    MessageShow.Visible = true;
                }
                log = new ShopNum1_OperateLog
                {
                    Record = "管理员审核店铺通过",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "UpdateShopURL.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
            }
        }

        protected void GetEmailSetting()
        {
            var settings = new ShopSettings();
            string_5 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailServer"));
            string_6 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            string_8 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "ServerPort"));
            string_7 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailAccount"));
            string_9 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailPassword"));
            string_10 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "RestoreEmail"));
            string_11 =
                Page.Server.HtmlDecode(
                    settings.GetValue(Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"),
                                      "EmailCode"));
        }

        protected void IsEmail()
        {
            try
            {
                DataTable memberInfoByGuID =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(
                        CheckGuid.Value.Replace("'", ""));
                if (memberInfoByGuID.Rows[0]["Email"].ToString() != "")
                {
                    ShopNum1_EmailGroupSend send;
                    string str3 = ShopSettings.GetValue("Name");
                    var shop = new ShopNum1.Email.OpenShop();
                    GetEmailSetting();
                    var mail = new NetMail();
                    mail.MailDomain = string_6;
                    mail.Mailserverport = Convert.ToInt32(string_8.Trim());
                    mail.Username = string_7;
                    mail.Password = string_9;
                    mail.Html = true;
                    mail.AddRecipient(memberInfoByGuID.Rows[0]["Email"].ToString());

                    shop.Name = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
                    shop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByGuID.Rows[0]["ShopID"].ToString();
                    shop.ShopStatus = "审核通过";
                    shop.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    shop.ShopName = str3;

                    string s = string.Empty;
                    string strTitle = string.Empty;
                    var action2 = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                    DataTable editInfo = action2.GetEditInfo("'60c1bef2-33e4-4510-944c-afca43d09f0c'", 0);
                    if (editInfo.Rows.Count > 0)
                    {
                        s = editInfo.Rows[0]["Remark"].ToString();
                        strTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    s =
                        s.Replace("{$Name}", memberInfoByGuID.Rows[0]["MemLoginID"].ToString())
                         .Replace("{$ShopName}", shop.ShopName)
                         .Replace("{$SendTime}", DateTime.Now.ToString());
                    mail.Subject = strTitle;
                    mail.Body = shop.ChangeOpenShop(Page.Server.HtmlDecode(s));
                    mail.From = string_10;
                    if (!mail.Send())
                    {
                        send = Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle, s,
                                   memberInfoByGuID.Rows[0]["Email"].ToString(), 0, mail.Body);
                        action2.AddEmailGroupSend(send);
                    }
                    else
                    {
                        send = Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle, s,
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
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(
                        CheckGuid.Value.Replace("'", ""));
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
                content = content.Replace("{$Name}", str3)
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

        private void method_5(string string_12, int int_0, string string_13)
        {
            string str5;
            string path = "~/Template/Shop/" + string_13;
            if (!File.Exists(Page.Server.MapPath("~/Template/Shop/" + string_13)))
            {
                path = "~/Template/Shop/Skin_Default.zipzz";
            }
            string str3 = "";
            string str2 = "";
            str2 = "~/ImgUpload/";
            str3 = "~/Shop/Shop/";
            string openTime =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetOpenTime(string_12);
            object obj2 = str3;
            str3 =
                string.Concat(new[]
                    {
                        obj2, Convert.ToDateTime(openTime).ToString("yyyy/MM/dd").Replace('-', '/'), "/",
                        ShopSettings.GetValue("PersonShopUrl"), int_0, "/"
                    });
            obj2 = str2;
            str2 =
                string.Concat(new[]
                    {
                        obj2, Convert.ToDateTime(openTime).ToString("yyyy/MM/dd").Replace('-', '/'), "/",
                        ShopSettings.GetValue("PersonShopUrl"), int_0, "/"
                    });
            if (!Directory.Exists(Page.Server.MapPath(str3)))
            {
                try
                {
                    Directory.CreateDirectory(Page.Server.MapPath(str3));
                    str5 = str3 + Path.GetFileName(Page.Server.MapPath(path));
                    File.Copy(Page.Server.MapPath(path), Page.Server.MapPath(str5));
                    ShopNum1UnZipClass.UnZip(Page.Server.MapPath(str5), Page.Server.MapPath(str3), null);
                    File.Delete(Page.Server.MapPath(str5));
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    if (!Directory.Exists(Page.Server.MapPath(path)))
                    {
                        str5 = str3 + Path.GetFileName(Page.Server.MapPath(path));
                        File.Copy(Page.Server.MapPath(path), Page.Server.MapPath(str5));
                        ShopNum1UnZipClass.UnZip(Page.Server.MapPath(str5), Page.Server.MapPath(str3), null);
                        File.Delete(Page.Server.MapPath(str5));
                    }
                }
                catch
                {
                }
            }
            if (!Directory.Exists(Page.Server.MapPath(str2)))
            {
                Directory.CreateDirectory(Page.Server.MapPath(str2));
            }
        }

        private bool method_6()
        {
            if (HiddenFieldShopURL.Value == TextBoxShopURL.Text.Trim())
            {
                return false;
            }
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            return (action.CheckShopURLIsRepeat(TextBoxShopURL.Text.Trim()).Rows[0]["ShopUrl"].ToString() == "0");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                LiteralURL.Text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
                CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "-1" : base.Request.QueryString["guid"];
                CheckGuid.Value.Replace("'", "");
                DataTable allShopInfoByGuid =
                    ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action())
                        .GetAllShopInfoByGuid(CheckGuid.Value.Replace("'", ""));
                if ((allShopInfoByGuid != null) && (allShopInfoByGuid.Rows.Count > 0))
                {
                    HiddenFieldShopURL.Value = TextBoxShopURL.Text = allShopInfoByGuid.Rows[0]["ShopUrl"].ToString();
                }
            }
            string_4 = (base.Request.QueryString["type"] == null) ? "-1" : base.Request.QueryString["type"];
        }

        protected void TextBoxShopURL_TextChanged(object sender, EventArgs e)
        {
            if (!method_6())
            {
                MessageBox.Show("店铺URL已经存在！");
                TextBoxShopURL.Focus();
            }
        }
    }
}