using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopInfoList_Audit : PageBase, IRequiresSessionState
    {
        private string string_10 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        protected TextBox TextBoxMemberName;
        protected TextBox TextBoxShopName;

        protected ShopNum1_EmailGroupSend Add(string memLoginID, string strTitle, string email, int state, string scont)
        {
            return new ShopNum1_EmailGroupSend { Guid = Guid.NewGuid(), EmailTitle = strTitle, CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), EmailGuid = new Guid("60c1bef2-33e4-4510-944c-afca43d09f0c"), SendObjectEmail = scont, SendObject = memLoginID + "-" + email, State = state };
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend { Guid = Guid.NewGuid(), MMSTitle = MMsTitle, CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), MMSGuid = new Guid(mmsGuid), SendObjectMMS = mobile, SendObject = memLoginID + "-" + mobile, State = state };
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_ShopInfoList_Action action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataTable shopInfoByGuid = action.GetShopInfoByGuid(this.CheckGuid.Value);
            string str = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
            string str2 = shopInfoByGuid.Rows[0]["ShopID"].ToString();
            string path = "~/Shop/Shop/" + Convert.ToDateTime(str).ToString("yyyy/MM/dd").Replace('-', '/') + "/" + ShopSettings.GetValue("PersonShopUrl") + str2;
            string str4 = "~/ImgUpload/" + Convert.ToDateTime(str).ToString("yyyy/MM/dd").Replace('-', '/') + "/" + ShopSettings.GetValue("PersonShopUrl") + str2;
            this.method_6(base.Server.MapPath(str4));
            this.method_6(base.Server.MapPath(path));
            if (action.Delete(this.CheckGuid.Value) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除店铺审核数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopInfoList_Audit.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindData();
                this.MessageShow.ShowMessage("Audit2Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit2No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string guid = "'" + button.CommandArgument + "'";
            ShopNum1_ShopInfoList_Action action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataTable shopInfoByGuid = action.GetShopInfoByGuid(guid);
            string str2 = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
            string str3 = shopInfoByGuid.Rows[0]["ShopID"].ToString();
            string path = "~/Shop/Shop/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/" + ShopSettings.GetValue("PersonShopUrl") + str3;
            string str5 = "~/ImgUpload/" + Convert.ToDateTime(str2).ToString("yyyy/MM/dd").Replace('-', '/') + "/" + ShopSettings.GetValue("PersonShopUrl") + str3;
            this.method_6(base.Server.MapPath(str5));
            this.method_6(base.Server.MapPath(path));
            if (action.Delete(guid) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除店铺审核数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopInfoList_Audit.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindData();
                this.MessageShow.ShowMessage("Audit2Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit2No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
            {
                Record = "店铺审核通过",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "ShopInfoList_Audit.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);

            string guid = this.CheckGuid.Value;
            ShopNum1_ShopInfoList_Action action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            try
            {
                DataTable dt = action.GetShopNameByGuid(guid);
                
                string MemLoginID = dt.Rows[0]["MemLoginID"].ToString();
                string ShopName = dt.Rows[0]["ShopName"].ToString();

                DataTable dt2 = action.GetScore_sv(MemLoginID);
                decimal Score_sv = decimal.Parse(dt2.Rows[0]["Score_sv"].ToString());
                Score_sv += 0;
                //修改runkGuid
                action.UpdateMemberRankGuid(MemLoginID);
                //将所有商品添加到新开的店铺中
                action.AddProductByBTC(MemLoginID, ShopName);
                //增加200000额度
                //action.UpdateScore_sv(MemLoginID,Score_sv);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            base.Response.Redirect("UpdateShopURL.aspx?guid=" + this.CheckGuid.Value + "&type=Audit");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopInfo_AuditOperate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void GetEmailSetting()
        {
            ShopSettings settings = new ShopSettings();
            this.string_4 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailServer"));
            this.string_5 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
            this.string_7 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPort"));
            this.string_6 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailAccount"));
            this.string_8 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailPassword"));
            this.string_9 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "RestoreEmail"));
            this.string_10 = this.Page.Server.HtmlDecode(settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailCode"));
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        protected void IsEmail(string strId)
        {
            try
            {
                DataTable memberInfoByGuID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(strId.Replace("'", ""));
                if (memberInfoByGuID.Rows[0]["Email"].ToString() != "")
                {
                    ShopNum1_EmailGroupSend send;
                    string str3 = ShopSettings.GetValue("Name");
                    var shop = new ShopNum1.Email.OpenShop();
                    this.GetEmailSetting();
                    NetMail mail = new NetMail
                    {
                        MailDomain = this.string_5,
                        Mailserverport = Convert.ToInt32(this.string_7.Trim()),
                        Username = this.string_6,
                        Password = this.string_8,
                        Html = true
                    };
                    mail.AddRecipient(memberInfoByGuID.Rows[0]["Email"].ToString());
                    shop.Name = memberInfoByGuID.Rows[0]["MemLoginID"].ToString();
                    shop.ShopID = ShopSettings.GetValue("PersonShopUrl") + memberInfoByGuID.Rows[0]["ShopID"].ToString();
                    shop.ShopStatus = "审核不通过";
                    shop.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    shop.ShopName = str3;
                    string s = string.Empty;
                    string strTitle = string.Empty;
                    ShopNum1_Email_Action action2 = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                    DataTable editInfo = action2.GetEditInfo("'5387cec4-05ed-41d1-bc1f-c900c4959585'", 0);
                    if (editInfo.Rows.Count > 0)
                    {
                        s = editInfo.Rows[0]["Remark"].ToString();
                        strTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    s = s.Replace("{$Name}", memberInfoByGuID.Rows[0]["MemLoginID"].ToString()).Replace("{$ShopName}", shop.ShopName).Replace("{$SendTime}", DateTime.Now.ToString());
                    mail.Subject = strTitle;
                    mail.Body = shop.ChangeOpenShop(this.Page.Server.HtmlDecode(s));
                    mail.From = this.string_9;
                    if (!mail.Send())
                    {
                        send = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle, memberInfoByGuID.Rows[0]["Email"].ToString(), 0, mail.Body);
                        action2.AddEmailGroupSend(send);
                    }
                    else
                    {
                        send = this.Add(memberInfoByGuID.Rows[0]["MemLoginID"].ToString(), strTitle, memberInfoByGuID.Rows[0]["Email"].ToString(), 2, mail.Body);
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
                DataTable memberInfoByGuID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberInfoByGuID(this.CheckGuid.Value.Replace("'", ""));
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
                content = content.Replace("恭喜", "抱歉").Replace("已经通过审核", "未通过审核").Replace("{$Name}", str3).Replace("{$ShopName}", newValue).Replace("{$SendTime} ", DateTime.Now.ToString("yyyy-MM-dd"));
                SMS sms = new SMS();
                string retmsg = "";
                sms.Send(mobile, content + "【唐江宝宝】", out retmsg);
                if (retmsg.IndexOf("发送成功") != -1)
                {
                    send = this.AddMMS(str3, mobile, mMsTitle, 2, mmsGuid);
                    action.AddMMSGroupSend(send);
                }
                else
                {
                    send = this.AddMMS(str3, mobile, mMsTitle, 0, mmsGuid);
                    action.AddMMSGroupSend(send);
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindData()
        {
            this.Num1GridViewShow.DataBind();
        }

        private void method_6(string string_11)
        {
            if (Directory.Exists(string_11))
            {
                foreach (string str in Directory.GetFileSystemEntries(string_11))
                {
                    if (File.Exists(str))
                    {
                        File.Delete(str);
                    }
                    else
                    {
                        this.method_6(str);
                    }
                }
                Directory.Delete(string_11, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
            }
        }

        public string YesOrNo(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "是";
            }
            return "否";
        }
    }
}