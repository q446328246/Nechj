using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using System.Configuration;
using ShopNum1.DiscuzToolkit;
using ShopNum1.DiscuzHelper;
using System.Web.Configuration;
using ShopNum1.Ucenter.Request;
using System.IO;
using System.Net;
using System.Text;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Email;
using ShopNum1.Deploy.App_Code;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class SignIn : BaseUserControl
    {


        //签到
        public string SignIn_HV(string MemberLoginID)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID

            var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //判断今天是否签到过
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dataTable = member_Action.CheckSignin(MemberLoginID, dayTime);
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
                {
                    return "have";
                }
                else
                {
                    string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore"); //签到是否送红包 0表示不送红包，1表示送红包 
                    string strRankScore = ShopSettings.GetValue("SignRankScore"); //等级红包
                    string strSignScore = ShopSettings.GetValue("SignScore"); //消费红包
                    if (SignOrSendScore == "1")
                    {
                        if (SignInBool(MemberLoginID))
                        {
                            return "true";
                        }
                        else
                        {
                            return "true";
                        }
                    }

                    return "false";
                }
            }
            else
            {
                if (SignInBool(MemberLoginID))
                {
                    return "true";
                }
                return "false";
            }
        }

        public bool SignInBool(string MemberLoginID)
        {
            var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            var signIn = new ShopNum1_SignIn();
            signIn.guid = Guid.NewGuid();
            signIn.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            signIn.MemLoginID = MemberLoginID;
            int check = member_Action.AddSignin(signIn);
            if (check > 0)
            {
                //签到成功
                string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore"); //签到是否送红包 0表示不送红包，1表示送红包 
                string strRankScore = ShopSettings.GetValue("SignRankScore"); //等级红包
                string strSignScore = ShopSettings.GetValue("SignScore"); //消费红包

                //送红包
                if (!string.IsNullOrEmpty(SignOrSendScore) && int.Parse(SignOrSendScore) == 1)
                {
                    member_Action.UpdateMemberScore(MemberLoginID, Convert.ToInt32(strRankScore),
                                                    Convert.ToInt32(strSignScore));
                    decimal vScore = Convert.ToDecimal(ShopNum1.Common.Common.GetScore_hv(MemberLoginID).Rows[0]["Score_hv"]);
                    var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
                    shopNum1_AdvancePaymentModifyLog.hv_guid_two = Guid.NewGuid();
                    shopNum1_AdvancePaymentModifyLog.OperateType = 1;

                    shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = vScore - Convert.ToDecimal(strSignScore);
                    shopNum1_AdvancePaymentModifyLog.HuoDe_hv = Convert.ToDecimal(strSignScore);
                    shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = vScore;
                    shopNum1_AdvancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "签到送红包";
                    shopNum1_AdvancePaymentModifyLog.MemLoginID = MemberLoginID;
                    shopNum1_AdvancePaymentModifyLog.CreateUser = MemberLoginID;
                    shopNum1_AdvancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
                    var shopNum1_AdvancePaymentModifyLog_Action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    shopNum1_AdvancePaymentModifyLog_Action.OperateScore_HV(shopNum1_AdvancePaymentModifyLog);
                    UpdateRankScore(Convert.ToInt32(strSignScore), Convert.ToInt32(strRankScore), MemberLoginID);
                }
                return true;
            }
            return false;
        }


        //对红包进行添加
        private void UpdateRankScore(int Score, int RankScore, string MemLoginID)
        {
            string vScore = ShopNum1.Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member",
                                               " and memloginid='" + MemLoginID + "'");
            int currentscore = 0, rankscore = 0;
            if (vScore != "" && vScore.IndexOf("-") != -1)
            {
                currentscore = Convert.ToInt32(vScore.Split('-')[1]);
                rankscore = Convert.ToInt32(vScore.Split('-')[0]);
            }
            if (Score > 0)
            {
                var ScoreModifyLog = new ShopNum1_ScoreModifyLog();
                ScoreModifyLog.Guid = Guid.NewGuid();
                ScoreModifyLog.OperateType = 1;
                ScoreModifyLog.CurrentScore = (currentscore - Score);
                ScoreModifyLog.OperateScore = Score;
                ScoreModifyLog.LastOperateScore = currentscore;
                ScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ScoreModifyLog.Memo = "签到送消费红包";
                ScoreModifyLog.MemLoginID = MemLoginID;
                ScoreModifyLog.CreateUser = MemLoginID;
                ScoreModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ScoreModifyLog.IsDeleted = 0;
                var shopNum1_ScoreModifyLog =
                    (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
                shopNum1_ScoreModifyLog.OperateScore(ScoreModifyLog);
            }
            //等级红包
            if (RankScore > 0)
            {


                var RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();

                RankScoreModifyLog.OperateType = 1;
                RankScoreModifyLog.CurrentScore = (rankscore - RankScore);
                RankScoreModifyLog.OperateScore = RankScore;
                RankScoreModifyLog.LastOperateScore = rankscore;
                RankScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                RankScoreModifyLog.Memo = "签到送等级红包";
                RankScoreModifyLog.MemLoginID = MemLoginID;
                RankScoreModifyLog.CreateUser = MemLoginID;
                RankScoreModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                RankScoreModifyLog.IsDeleted = 0;
                var RankScoreModifyLog_Action =
                    (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
                RankScoreModifyLog_Action.OperateScore(RankScoreModifyLog);
            }
        }


        //注册普通会员
        // 0会员已存在
        //1 推荐人不能没有
        //2 真实姓名为空
        //3 推荐人错误
        //4 身份证已存在
        //5 注册失败
        //7 注册成功
        public string MemberRegisterMember(string memloginid, string Email, string Mobile, string Name, string recommendid, string IdentityCard, string Pwd)
        {

            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");

            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");

            var member = new ShopNum1_Member();

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


            Exception exception;

            if (!string.IsNullOrEmpty(memloginid.Trim()))
            {
                if (action.CheckmemLoginID(memloginid.Trim()) > 0)
                {


                    return "0";
                }
                member.MemLoginID = memloginid;
            }

            if (!string.IsNullOrEmpty(Mobile.Trim()))
            {
                if (action.CheckMemMobileByMobile(Mobile.Trim()).Rows.Count > 0)
                {
                    return "9";
                }
                else
                {
                    member.Mobile = Mobile.Trim();
                }
               
            }
            if ((!string.IsNullOrEmpty(Name.Trim())))
            {

                member.RealName = Name.Trim(); //用户姓名
            }
            else
            {
                return "2";
            }
            string cc = "";
            cc = recommendid;
            if (cc == "" || string.IsNullOrEmpty(cc))
            {

                return "1";
            }
            //DataTable rank = action.selectGETMemberloginID_MemberloingNO(cc);
            //if (rank.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32 ( rank.Rows[0]["Is520Member"])<2)
            //    {
            //        return "3";
            //    }
            //}
            //else
            //{
            //    return "3";
            //}
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckIdentityCard2(IdentityCard.Trim()) > 0)
            {

                return "4";
            }



            //if (!string.IsNullOrEmpty(TextBoxEmail.Text.Trim()))
            //{
            //    //TextBoxMemLoginID.Text = string.Empty;
            //    //TextBoxMobile.Text = string.Empty;
            //    //if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
            //    //{
            //    //    MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
            //    //    return;
            //    //}

            //}
            member.Email = Email.Trim();
            if (!(string.IsNullOrEmpty(Email.Trim()) || !str2.Equals("1")))
            {
                member.IsForbid = 1;
            }
            else
            {
                member.IsForbid = 0;
            }


            member.MemberType = 1;


            member.IdentityCard = IdentityCard.Trim();//用户身份证号
            member.MemLoginNO = memloginid.Trim();
            member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(Pwd);
            member.Guid = Guid.NewGuid();
            member.AdvancePayment = 0;
            member.AddressValue = "";
            member.AddressCode = "";
            member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            member.LoginDate = null;
            member.IsMobileActivation = 0;
            member.IsEmailActivation = "0";
            member.Superior = recommendid;
            member.Score_hv = 1000;

            member.PromotionMemLoginID = "";


            if (str2 == "0")
            {
                member.IsMailActivation = 1;
            }
            else
            {
                member.IsMailActivation = 0;
            }

            string s = ShopSettings.GetValue("RegPresentRankScore");
            if ((s == "") || (s == null))
            {
                member.MemberRank = 0;
            }
            else
            {
                member.MemberRank = int.Parse(s);
            }

            DataTable defaultMemberRank =
                ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).GetDefaultMemberRank();

            Guid guid2 = Guid.NewGuid();

            try
            {
                if ((defaultMemberRank != null) && (defaultMemberRank.Rows.Count > 0))
                {
                    guid2 = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
                }
                else
                {
                    guid2 = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                }
            }
            catch (Exception exception1)
            {
                exception = exception1;
                guid2 = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
            }

            member.MemberRankGuid = guid2;

            //注册赠积分
            string str10 = ShopSettings.GetValue("RegPresentScore");
            if ((str10 == "") || (str10 == null))
            {
                member.Score = 0;
            }
            else
            {
                member.Score = int.Parse(str10);
            }

            member.LastLoginIP = null;
            member.LoginTime = 1;
            member.AdvancePayment = 0;
            member.LockAdvancePayment = 0;
            member.LockSocre = 0;
            member.CostMoney = 0;

            member.Score1 = 0;
            member.Score2 = 0;
            member.Score3 = 0;
            member.Score4 = 0;
            member.Score5 = 0;
            member.Score6 = 0;

            //会员注册成功
            if (action.Add(member) == 1)
            {
                DataTable DeppTable = action.SelectGetDeep(member.Superior);
                int deep = 0;
                if (DeppTable != null && DeppTable.Rows.Count > 0)
                {
                    int SupriDeep = Convert.ToInt32(DeppTable.Rows[0]["deep"]);

                    if (SupriDeep == 0)
                    {
                        deep = 0;
                    }
                    else
                    {
                        deep = SupriDeep + 1;
                    }
                }
                member.Deep = deep;
                action.AddMemberRecommand(member);
                HttpCookie cookie;
                HttpCookie cookie2;
                string str4;
                string str5;
                string str6;
                string str7;
                string str8;
                DataTable editInfo;
                DataTable shopRankByMemLoginID;
                //看不懂的直接注释的，看到cookie字样 应该没用】

                //if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                //{
                //    try
                //    {
                //        string oldUser = string.Empty;
                //        HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                //        oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                //        ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                //            (oldUser,
                //                TextBoxMemLoginID
                //                    .Text
                //                    .Trim());
                //        cookie3.Values.Clear();
                //    }
                //    catch (Exception exception2)
                //    {
                //        exception = exception2;
                //    }
                //}

                if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
                {
                    try
                    {
                        string str20 = member.Email;
                        if (member.Email == "")
                        {
                            str20 = member.MemLoginID + "@163.com";
                        }
                        else
                        {
                            str20 = member.Email;
                        }
                        if (Func.uc_user_register(member.MemLoginID, Pwd.Trim(), str20) > 0)
                        {

                        }
                    }
                    catch
                    {
                    }
                }

                string str19 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                if (str19.Trim() == "1")
                {
                    DiscuzSession session = DiscuzSessionHelper.GetSession();
                    try
                    {
                        string str9 = member.Email;
                        if (member.Email == "")
                        {
                            str9 = member.MemLoginID + "@163.com";
                        }
                        else
                        {
                            str9 = member.Email;
                        }
                        if (session.Register(member.MemLoginID, Pwd.Trim(), str9, false) > 0)
                        {
                            int uid = 0;
                            uid = session.GetUserID(member.MemLoginID);

                        }
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                    }
                }

                if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                {
                    var section =
                        (AppSettingsSection)
                            WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                                .GetSection("appSettings");
                    string str12 = section.Settings["TgPostUrl"].Value;
                    string str16 = section.Settings["TgSourceKey"].Value;
                    if (method_0(string.Concat(new object[]
                        {
                            str12, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID,"&MemLoginNO=",member.MemLoginNO, "&Email=",
                            member.Email, "&Pwd=", member.Pwd, "&PayPwd=", member.PayPwd, "&Sex=", member.Sex,
                            "&Birthday=", member.Birthday, "&Photo=", member.Photo, "&RealName=",
                            member.RealName, "&Area=", member.Address, "&Vocation=", member.Vocation, "&Address=",
                            member.Address, "&Postalcode=", member.Postalcode, "&Fax=", member.Fax, "&QQ=",
                            member.QQ, "&WebSite=", member.WebSite, "&Question=",
                            member.Question, "&Answer=", member.Answer, "&RegDate=", member.RegeDate,
                            "&LastLoginDate=", member.LastLoginDate, "&LastLoginIP=", member.LastLoginIP,
                            "&LoginTime=", DateTime.Now.ToString(), "&AdvancePayment=", member.AdvancePayment,
                            "&Score=", member.Score, "&RankScore=0&LockAdvancePayment=",
                            member.LockAdvancePayment, "&LockSocre=", member.LockSocre, "&MemberRankGuid=",
                            Guid.Empty, "&TradeCount=0&CreateUser=  &CreateTime=", DateTime.Now.ToString(),
                            "&ModifyUser= &ModifyTime=", DateTime.Now.ToString(), "&TgSourceKey=", str16
                        })) != string.Empty)
                    {
                        string str13 =
                            string.Concat(new object[]
                                {
                                    str12, "IntergrationMemberLogin.aspx?MemLoginID=", member.MemLoginID,
                                    "&MemberRankGuid=", Guid.NewGuid(), "&Pwd=", member.Pwd, "&TgSourceKey=",
                                    section.Settings["TgSourceKey"].Value
                                });
                        string format = "<script src='{0}'></script>";
                        format = string.Format(format, str13);
                        Page.Response.Write(format);
                    }
                }

                if (str2 == "1")
                {
                    if (Email == "")
                    {
                        cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", member.MemLoginID);
                        cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                        cookie.Values.Add("Name", member.RealName);
                        cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                        cookie.Values.Add("MemberType", member.MemberType.ToString());
                        cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());
                        if (member.MemberType.ToString() == "2")
                        {
                            var action3 =
                                (Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                            shopRankByMemLoginID = action3.GetShopRankByMemLoginID(member.MemLoginID);
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        //cookie.Values.Add("UID", "-1");
                        //cookie2 = HttpSecureCookie.Encode(cookie);
                        //cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        //Page.Response.AppendCookie(cookie2);
                        //    if (memloginid != "")
                        //    {
                        //        Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                        //            "  and MemLoginID='" + memloginid + "'");
                        //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                        //            "window.location.href='" +
                        //            GetPageName.RetDomainUrl(
                        //                "MemberRegisterSuccess") +
                        //            "?type=2&MemLoginID=" +
                        //            TextBoxMemLoginID.Text.Trim() + "'", true);
                        //    }
                        //    else if (TextBoxMobile.Text != "")
                        //    {
                        //        Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                        //            " and Mobile='" + TextBoxMobile.Text + "'");
                        //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                        //            "window.location.href='" +
                        //            GetPageName.RetDomainUrl(
                        //                "MemberRegisterSuccess") +
                        //            "?type=2&MemLoginID=" +
                        //            TextBoxMobile.Text.Trim() + "'", true);
                        //    }
                        //}

                        try
                        {
                            RegIsActivationEmail email;
                            str4 = Guid.NewGuid().ToString();
                            email = new RegIsActivationEmail
                            {
                                Email = Email.Trim(),
                                Name = memloginid.Trim(),
                                link =
                                    GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                                    "&type=0&email=" + Email.Trim() + "&userID=" +
                                    memloginid.Trim(),
                                ShopName = str3,
                                SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            };
                            str5 = string.Empty;
                            str6 = string.Empty;
                            str7 = "7790bcf5-f88a-46bd-8ead-959118481c02";
                            str8 = string.Empty;
                            var action2 = new ShopNum1_Email_Action();
                            editInfo = action2.GetEditInfo("'" + str7 + "'", 0);
                            if (editInfo.Rows.Count > 0)
                            {
                                str5 = editInfo.Rows[0]["Remark"].ToString();
                                str6 = editInfo.Rows[0]["Title"].ToString();
                            }
                            str5 =
                                str5.Replace("{$Name}", email.Name)
                                    .Replace("{$PassWord}", Pwd)
                                    .Replace("{$ShopName}", email.ShopName)
                                    .Replace("{$CheckUrl}", email.link)
                                    .Replace("{$SendTime}", email.SysSendTime);
                            str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                            SendMailForRegister(memloginid.Trim(), Email.Trim(), str4, "", str6,
                                str7, str8);
                        }
                        catch (Exception exception4)
                        {
                            exception = exception4;
                            Context.Response.Write(exception.Message);
                        }
                    }

                    if ((str == "1") && (str2 == "0"))
                    {
                        var register = new Register
                        {
                            Email = Email.Trim(),
                            Name = memloginid.Trim(),
                            Password = Pwd.Trim(),
                            ShopName = str3,
                            SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        str5 = string.Empty;
                        str6 = string.Empty;
                        str7 = "4a12724c-5154-4928-b867-d5bd180e80e6";
                        str8 = string.Empty;
                        editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + str7 + "'", 0);
                        str4 = Guid.NewGuid().ToString();
                        if (editInfo.Rows.Count > 0)
                        {
                            str5 = editInfo.Rows[0]["Remark"].ToString();
                            str6 = editInfo.Rows[0]["Title"].ToString();
                        }
                        str8 = register.ChangeRegister(Page.Server.HtmlDecode(str5));
                        new SendEmail().Emails(Email.Trim(), memloginid.Trim(), str6, str7, str8);
                    }

                    AddScroll(memloginid);

                    //if (str2 == "0")
                    //{
                    //    cookie = new HttpCookie("MemberLoginCookie");
                    //    cookie.Values.Add("MemLoginID", member.MemLoginID);
                    //    cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                    //    cookie.Values.Add("Name", member.RealName);
                    //    cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                    //    cookie.Values.Add("MemberType", member.MemberType.ToString());
                    //    cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());

                    //    if (member.MemberType.ToString() == "2")
                    //    {
                    //        shopRankByMemLoginID =
                    //            ((Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                    //                .GetShopRankByMemLoginID(member.MemLoginID);
                    //        if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                    //        {
                    //            //cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                    //        }
                    //    }
                    //    //cookie.Values.Add("UID", "-1");
                    //    //cookie2 = HttpSecureCookie.Encode(cookie);
                    //    //cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    //    //Page.Response.AppendCookie(cookie2);
                    //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //    //    "window.location.href='" +
                    //    //    GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                    //    //    "?type=2&MemLoginID=" +
                    //    //    memloginid.Trim() + "'",
                    //    //    true);
                    //}
                    //else
                    //{
                    //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //    //    "window.location.href='" +
                    //    //    GetPageName.RetDomainUrl("E-mailVerification") +
                    //    //    "?email=" + Email.Trim() + "&id=" +
                    //    //    Email.Trim() + "'", true);
                    //}

                }
                return "7";


            }
            else
            {
                return "5";
            }
        }


        public string MemberRegisterMandarinMember(string MemLoginID, string Email, string Mobile, string Name, string recommendid, string IdentityCard, string Pwd)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string TXJ = "";
            if ((recommendid == null) ||
    string.IsNullOrEmpty(recommendid))
            {

                return "1";
            }
            else
            {
                TXJ = recommendid;
            }

            DataTable tbc = member_Action.SearchCMember(TXJ.Trim());
            if (tbc.Rows.Count < 1)
            {

                return "3";
            }

            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");

            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");

            var member = new ShopNum1_Member();

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


            Exception exception;

            if (!string.IsNullOrEmpty(MemLoginID.Trim()))
            {
                if (action.CheckmemLoginID(MemLoginID.Trim()) > 0)
                {


                    return "0";
                }
                member.MemLoginID = MemLoginID.Trim();
            }

            if (!string.IsNullOrEmpty(Mobile.Trim()))
            {
                //if (action.CheckMemMobileByMobile(TextBoxMobile.Text.Trim()).Rows.Count > 0)
                //{
                //    TextBoxMemLoginID.Text = string.Empty;
                //    TextBoxEmail.Text = string.Empty;
                //    MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
                //    return;
                //}
                member.Mobile = Mobile.Trim();
            }
            if ((!string.IsNullOrEmpty(Name.Trim())))
            {

                member.RealName = Name.Trim(); //用户姓名
            }
            else
            {
                return "2";
            }
            //if (!string.IsNullOrEmpty(TextBoxEmail.Text.Trim()))
            //{
            //    //TextBoxMemLoginID.Text = string.Empty;
            //    //TextBoxMobile.Text = string.Empty;
            //    //if (action.CheckmemEmail(TextBoxEmail.Text.Trim()) > 0)
            //    //{
            //    //    MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
            //    //    return;
            //    //}

            //}
            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (memberAction.CheckIdentityCard(IdentityCard.Trim()) > 0)
            {

                return "4";
            }

            member.Email = Email.Trim();
            if (!(string.IsNullOrEmpty(Email.Trim()) || !str2.Equals("1")))
            {
                member.IsForbid = 1;
            }
            else
            {
                member.IsForbid = 0;
            }


            member.MemberType = 1;


            member.IdentityCard = IdentityCard.Trim();//用户身份证号
            member.MemLoginNO = MemLoginID.Trim();
            member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(Pwd.Trim());
            member.Guid = Guid.NewGuid();
            member.AdvancePayment = 0;
            member.AddressValue = "";
            member.AddressCode = "";
            member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            member.LoginDate = null;
            member.IsMobileActivation = 0;
            member.IsEmailActivation = "0";
            member.Superior = recommendid;


            //if ((Page.Request.QueryString["memberid"] != null) &&
            //    !string.IsNullOrEmpty(Page.Request.QueryString["memberid"]))
            //{
            //    if (
            //        !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Member",
            //            "   AND  MemLoginID='" +
            //            HttpUtility.HtmlDecode(
            //                Page.Request.QueryString["memberid"]) + "'")))
            //    {
            //        member.PromotionMemLoginID = HttpUtility.HtmlDecode(Page.Request.QueryString["memberid"]);
            //    }
            //    else
            //    {
            member.PromotionMemLoginID = "";
            //    }
            //}
            //else
            //{


            //    member.PromotionMemLoginID = "";
            //}

            if (str2 == "0")
            {
                member.IsMailActivation = 1;
            }
            else
            {
                member.IsMailActivation = 0;
            }

            string s = ShopSettings.GetValue("RegPresentRankScore");
            if ((s == "") || (s == null))
            {
                member.MemberRank = 0;
            }
            else
            {
                member.MemberRank = int.Parse(s);
            }

            member.MemberRankGuid = new Guid("197B6B51-3EB3-452E-BD03-D560577A34D2");

            //注册赠积分
            string str10 = ShopSettings.GetValue("RegPresentScore");
            if ((str10 == "") || (str10 == null))
            {
                member.Score = 0;
            }
            else
            {
                member.Score = int.Parse(str10);
            }

            member.LastLoginIP = null;
            member.LoginTime = 1;
            member.AdvancePayment = 0;
            member.LockAdvancePayment = 0;
            member.LockSocre = 0;
            member.CostMoney = 0;

            member.Score1 = 0;
            member.Score2 = 0;
            member.Score3 = 0;
            member.Score4 = 0;
            member.Score5 = 0;
            member.Score6 = 0;

            //会员注册成功
            if (action.Add(member) == 1)
            {
                HttpCookie cookie;
                HttpCookie cookie2;
                string str4;
                string str5;
                string str6;
                string str7;
                string str8;
                DataTable editInfo;
                DataTable shopRankByMemLoginID;
                //if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                //{
                //    try
                //    {
                //        string oldUser = string.Empty;
                //        HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                //        oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                //        ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                //            (oldUser,
                //                MemLoginID.Trim());
                //        cookie3.Values.Clear();
                //    }
                //    catch (Exception exception2)
                //    {
                //        exception = exception2;
                //    }
                //}

                if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
                {
                    try
                    {
                        string str20 = member.Email;
                        if (member.Email == "")
                        {
                            str20 = member.MemLoginID + "@163.com";
                        }
                        else
                        {
                            str20 = member.Email;
                        }
                        if (Func.uc_user_register(member.MemLoginID, Pwd.Trim(), str20) > 0)
                        {
                            string script =
                                Func.uc_user_synlogin(
                                    Func.uc_user_login(member.MemLoginID, Pwd.Trim()).Uid);
                            HttpContext.Current.Response.AddHeader("P3P",
                                "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msgok", script, false);
                        }
                    }
                    catch
                    {
                    }
                }

                string str19 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                if (str19.Trim() == "1")
                {
                    DiscuzSession session = DiscuzSessionHelper.GetSession();
                    try
                    {
                        string str9 = member.Email;
                        if (member.Email == "")
                        {
                            str9 = member.MemLoginID + "@163.com";
                        }
                        else
                        {
                            str9 = member.Email;
                        }
                        if (session.Register(member.MemLoginID, Pwd.Trim(), str9, false) > 0)
                        {
                            int uid = 0;
                            uid = session.GetUserID(member.MemLoginID);
                            session.Login(uid, Pwd.Trim(), false, 100,
                                ConfigurationManager.AppSettings["DiscuzCookieDomain"]);
                        }
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                    }
                }

                if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                {
                    var section =
                        (AppSettingsSection)
                            WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                                .GetSection("appSettings");
                    string str12 = section.Settings["TgPostUrl"].Value;
                    string str16 = section.Settings["TgSourceKey"].Value;
                    if (method_0(string.Concat(new object[]
                        {
                            str12, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID,"&MemLoginNO=",member.MemLoginNO, "&Email=",
                            member.Email, "&Pwd=", member.Pwd, "&PayPwd=", member.PayPwd, "&Sex=", member.Sex,
                            "&Birthday=", member.Birthday, "&Photo=", member.Photo, "&RealName=",
                            member.RealName, "&Area=", member.Address, "&Vocation=", member.Vocation, "&Address=",
                            member.Address, "&Postalcode=", member.Postalcode, "&Fax=", member.Fax, "&QQ=",
                            member.QQ, "&WebSite=", member.WebSite, "&Question=",
                            member.Question, "&Answer=", member.Answer, "&RegDate=", member.RegeDate,
                            "&LastLoginDate=", member.LastLoginDate, "&LastLoginIP=", member.LastLoginIP,
                            "&LoginTime=", DateTime.Now.ToString(), "&AdvancePayment=", member.AdvancePayment,
                            "&Score=", member.Score, "&RankScore=0&LockAdvancePayment=",
                            member.LockAdvancePayment, "&LockSocre=", member.LockSocre, "&MemberRankGuid=",
                            Guid.Empty, "&TradeCount=0&CreateUser=  &CreateTime=", DateTime.Now.ToString(),
                            "&ModifyUser= &ModifyTime=", DateTime.Now.ToString(), "&TgSourceKey=", str16
                        })) != string.Empty)
                    {
                        string str13 =
                            string.Concat(new object[]
                                {
                                    str12, "IntergrationMemberLogin.aspx?MemLoginID=", member.MemLoginID,
                                    "&MemberRankGuid=", Guid.NewGuid(), "&Pwd=", member.Pwd, "&TgSourceKey=",
                                    section.Settings["TgSourceKey"].Value
                                });
                        string format = "<script src='{0}'></script>";
                        format = string.Format(format, str13);
                        Page.Response.Write(format);
                    }
                }

                if (str2 == "1")
                {
                    if (Email == "")
                    {
                        cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", member.MemLoginID);
                        cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                        cookie.Values.Add("Name", member.RealName);
                        cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                        cookie.Values.Add("MemberType", member.MemberType.ToString());
                        cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());
                        if (member.MemberType.ToString() == "2")
                        {
                            var action3 =
                                (Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                            shopRankByMemLoginID = action3.GetShopRankByMemLoginID(member.MemLoginID);
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        cookie.Values.Add("UID", "-1");
                        cookie2 = HttpSecureCookie.Encode(cookie);
                        cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        Page.Response.AppendCookie(cookie2);
                        if (MemLoginID != "")
                        {
                            Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                "  and MemLoginID='" + MemLoginID + "'");
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                "window.location.href='" +
                                GetPageName.RetDomainUrl(
                                    "MemberRegisterSuccess") +
                                "?type=2&MemLoginID=" +
                                MemLoginID.Trim() + "'", true);
                        }
                        else if (Mobile != "")
                        {
                            Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                " and Mobile='" + Mobile + "'");
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                "window.location.href='" +
                                GetPageName.RetDomainUrl(
                                    "MemberRegisterSuccess") +
                                "?type=2&MemLoginID=" +
                                Mobile.Trim() + "'", true);
                        }
                    }

                    try
                    {
                        RegIsActivationEmail email;
                        str4 = Guid.NewGuid().ToString();
                        email = new RegIsActivationEmail
                        {
                            Email = Email.Trim(),
                            Name = MemLoginID.Trim(),
                            link =
                                GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                                "&type=0&email=" + Email.Trim() + "&userID=" +
                                MemLoginID.Trim(),
                            ShopName = str3,
                            SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        str5 = string.Empty;
                        str6 = string.Empty;
                        str7 = "7790bcf5-f88a-46bd-8ead-959118481c02";
                        str8 = string.Empty;
                        var action2 = new ShopNum1_Email_Action();
                        editInfo = action2.GetEditInfo("'" + str7 + "'", 0);
                        if (editInfo.Rows.Count > 0)
                        {
                            str5 = editInfo.Rows[0]["Remark"].ToString();
                            str6 = editInfo.Rows[0]["Title"].ToString();
                        }
                        str5 =
                            str5.Replace("{$Name}", email.Name)
                                .Replace("{$PassWord}", Pwd)
                                .Replace("{$ShopName}", email.ShopName)
                                .Replace("{$CheckUrl}", email.link)
                                .Replace("{$SendTime}", email.SysSendTime);
                        str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                        SendMailForRegister(MemLoginID.Trim(), Email.Trim(), str4, "", str6,
                            str7, str8);
                    }
                    catch (Exception exception4)
                    {
                        exception = exception4;
                        Context.Response.Write(exception.Message);
                    }
                }

                if ((str == "1") && (str2 == "0"))
                {
                    var register = new Register
                    {
                        Email = Email.Trim(),
                        Name = MemLoginID.Trim(),
                        Password = Pwd.Trim(),
                        ShopName = str3,
                        SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    str5 = string.Empty;
                    str6 = string.Empty;
                    str7 = "4a12724c-5154-4928-b867-d5bd180e80e6";
                    str8 = string.Empty;
                    editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + str7 + "'", 0);
                    str4 = Guid.NewGuid().ToString();
                    if (editInfo.Rows.Count > 0)
                    {
                        str5 = editInfo.Rows[0]["Remark"].ToString();
                        str6 = editInfo.Rows[0]["Title"].ToString();
                    }
                    str8 = register.ChangeRegister(Page.Server.HtmlDecode(str5));
                    new SendEmail().Emails(Email.Trim(), MemLoginID.Trim(), str6, str7, str8);
                }

                AddScroll(MemLoginID);

                //if (str2 == "0")
                //{
                //    cookie = new HttpCookie("MemberLoginCookie");
                //    cookie.Values.Add("MemLoginID", member.MemLoginID);
                //    cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                //    cookie.Values.Add("Name", member.RealName);
                //    cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                //    cookie.Values.Add("MemberType", member.MemberType.ToString());
                //    cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());

                //    if (member.MemberType.ToString() == "2")
                //    {
                //        shopRankByMemLoginID =
                //            ((Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                //                .GetShopRankByMemLoginID(member.MemLoginID);
                //        if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                //        {
                //            cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                //        }
                //    }
                //    //cookie.Values.Add("UID", "-1");
                //    //cookie2 = HttpSecureCookie.Encode(cookie);
                //    //cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                //    //Page.Response.AppendCookie(cookie2);
                //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                //    //    "window.location.href='" +
                //    //    GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                //    //    "?type=2&MemLoginID=" +
                //    //    MemLoginID.Trim() + "'",
                //    //    true);
                //}
                //else
                //{
                ////    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                ////        "window.location.href='" +
                ////        GetPageName.RetDomainUrl("E-mailVerification") +
                ////        "?email=" + Email.Trim() + "&id=" +
                ////        Email.Trim() + "'", true);
                //}
                return "7";
            }
            else
            {
                return "5";

            }
        }

        private string method_0(string string_1)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_1);
            try
            {
                request.Timeout = 0xbb8;
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



        public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle,
            string emailTemplentGuid, string emailBody)
        {
            var action = (ShopNum1_MemberEmailExec_Action)LogicFactory.CreateShopNum1_MemberEmailExec_Action();
            var memberEmailExec = new ShopNum1_MemberEmailExec
            {
                ExtireTime = DateTime.Now.AddHours(24.0),
                Email = Email,
                Emailkey = Emailkey,
                Guid = Guid.NewGuid(),
                Isinvalid = 0,
                MemberID = MemLoginID,
                Phone = Phone,
                Type = 0
            };
            if (action.MemberEmailInsert(memberEmailExec) > 0)
            {
                new SendEmail().Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
            }
        }

        public void AddScroll(string MemLoginID)
        {
            string s = ShopSettings.GetValue("RegPresentScore");
            string str2 = ShopSettings.GetValue("RegPresentRankScore");

            if (int.Parse(s) > 0)
            {
                var scoreModeLog = new ShopNum1_ScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = 0,
                    OperateScore = int.Parse(s),
                    LastOperateScore = int.Parse(s),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = "注册赠送消费红包",
                    MemLoginID = MemLoginID.Trim(),
                    CreateUser = MemLoginID.Trim(),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                    scoreModeLog);
            }

            if (int.Parse(str2) > 0)
            {
                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = 0,
                    OperateScore = int.Parse(str2),
                    LastOperateScore = int.Parse(str2),
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = "注册赠送等级红包",
                    MemLoginID = MemLoginID.Trim(),
                    CreateUser = MemLoginID.Trim(),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }



        public string imgCode(string string_2)
        {
            string string_1 = string_2;

            var random2 = new Random();

            var image = new Bitmap((int)Math.Ceiling((string_1.Length * 13.5)), 0x16);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                int num;

                graphics.Clear(Color.White);
                for (num = 0; num < 0x19; num++)
                {
                    int num2 = random2.Next(image.Width);
                    int num3 = random2.Next(image.Width);
                    int num4 = random2.Next(image.Height);
                    int num5 = random2.Next(image.Height);
                    graphics.DrawLine(new Pen(Color.Silver), num2, num4, num3, num5);
                }
                var font = new Font("Arial", 12f, FontStyle.Italic | FontStyle.Bold);
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue,
                    Color.DarkRed, 1.2f, true);
                graphics.DrawString(string_1, font, brush, 2f, 2f);
                for (num = 0; num < 100; num++)
                {
                    int x = random2.Next(image.Width);
                    int y = random2.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random2.Next()));
                }
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);


                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Gif);

                return Convert.ToBase64String(stream.GetBuffer());
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();
            }

        }
    }
}