using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.DiscuzHelper;
using ShopNum1.DiscuzToolkit;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Ucenter.Request;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using System.Xml;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class MemberRegister : BaseUserControl
    {

        public static bool EnableRegister = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    divAgainregester.Visible = false;
                    divregester.Visible = true;
                    Page.Response.Expires = 0;
                    Page.Response.Buffer = true;
                    Page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
                    Page.Response.AddHeader("pragma", "no-cache");
                    Page.Response.CacheControl = "no-cache";
                }
                else
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    LabelMemLoginID.Text = cookie2.Values["MemLoginID"];
                    divAgainregester.Visible = true;
                    divregester.Visible = false;
                }

                if (ShopSettings.GetValue("MemLoginVerifyCode") == "1")
                {
                    VerifyCode.Visible = true;
                }
                else
                {
                    VerifyCode.Visible = false;
                }

                BindData();
            }


        }

        private void BindData()
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            TextBoxMemLoginID.Text = action.GetMemberNumber();
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



        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string TXJ = "";
            if ((Page.Request.QueryString["recommendid"] == null) ||
    string.IsNullOrEmpty(Page.Request.QueryString["recommendid"]))
            {
                Response.Write("<script>alert('没有业务员推荐,暂不开放新会员注册');</script>");
                return;
            }
            else
            {
                TXJ = Page.Request.QueryString["recommendid"].ToString();
            }

            DataTable tbc = member_Action.SearchCMember(TXJ.Trim());
            if (tbc.Rows.Count < 1)
            {
                Response.Write("<script>alert('推荐业务员不存在');</script>");
                return;
            }
            string str = ShopSettings.GetValue("RegIsEmail");
            string str2 = ShopSettings.GetValue("RegIsActivationEmail");

            ShopSettings.GetValue("RegistOrderIsMMS");
            string str3 = ShopSettings.GetValue("Name");

            var member = new ShopNum1_Member();

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

            if ((ShopSettings.GetValue("RegVerifyCode") == "1") &&
                ((Page.Session["code"] == null) ||
                 (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString().ToUpper())))
            {
                MessageBox.Show("验证码输入错误！");
            }
            else
            {
                Exception exception;

                if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
                {
                    if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                    {
                        TextBoxEmail.Text = string.Empty;
                        TextBoxMobile.Text = string.Empty;
                        MessageBox.Show("用户名已经被注册过了,请换一个用户名!");
                        return;
                    }
                    member.MemLoginID = TextBoxMemLoginID.Text;
                }

                if (!string.IsNullOrEmpty(TextBoxMobile.Text.Trim()))
                {
                    if (action.CheckMemMobileByMobile(TextBoxMobile.Text.Trim()).Rows.Count > 0)
                    {
                        TextBoxMemLoginID.Text = string.Empty;
                        TextBoxEmail.Text = string.Empty;
                        MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
                        return;
                    }
                    else
                    {
                        member.Mobile = TextBoxMobile.Text.Trim();
                    }

                }
                if ((!string.IsNullOrEmpty(txtMemberName.Text.Trim())))
                {

                    member.RealName = txtMemberName.Text.Trim(); //用户姓名
                }
                else
                {
                    return;
                }
                string cc = "";
                cc = Page.Request.QueryString["recommendid"];
                if (cc == "" || string.IsNullOrEmpty(cc))
                {
                    MessageBox.Show("推荐人不能没有!");
                    return;
                }
                DataTable rank = action.selectGETMemberloginID_MemberloingNO(cc);
                if (rank.Rows.Count > 0)
                {
                    string ccRank = rank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                    //if (Convert.ToInt32(rank.Rows[0]["Is520Member"].ToString()) < 2)
                    //{
                    //    MessageBox.Show("推荐人错误!");
                    //    return;
                    //}
                }
                else
                {
                    MessageBox.Show("推荐人错误!");
                    return;
                }
                ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                //if (memberAction.CheckIdentityCard2(txtIdentityCard.Text.Trim()) > 0)
                //{
                //    MessageBox.Show("身份证号已存在，不可重复!");
                //    return;
                //}



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
                member.Email = TextBoxEmail.Text.Trim();
                if (!(string.IsNullOrEmpty(TextBoxEmail.Text.Trim()) || !str2.Equals("1")))
                {
                    member.IsForbid = 1;
                }
                else
                {
                    member.IsForbid = 0;
                }


                member.MemberType = 1;


                member.IdentityCard = txtIdentityCard.Text.Trim();//用户身份证号
                member.MemLoginNO = TextBoxMemLoginID.Text.Trim();
                member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(TextBoxPwd.Text);
                member.Guid = Guid.NewGuid();
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = null;
                member.IsMobileActivation = 0;
                member.IsEmailActivation = "0";
                member.Superior = Page.Request.QueryString["recommendid"];
                member.Score_hv = 0;
                if ((Page.Request.QueryString["memberid"] != null) &&
                    !string.IsNullOrEmpty(Page.Request.QueryString["memberid"]))
                {
                    if (
                        !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Member",
                            "   AND  MemLoginID='" +
                            HttpUtility.HtmlDecode(
                                Page.Request.QueryString["memberid"]) + "'")))
                    {
                        member.PromotionMemLoginID = HttpUtility.HtmlDecode(Page.Request.QueryString["memberid"]);
                    }
                    else
                    {
                        member.PromotionMemLoginID = "";
                    }
                }
                else
                {
                    member.PromotionMemLoginID = "";
                }

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
                #region 注册

                int add3g = 1;
                int addcs = 1;
                //int add3g = action.Add3G(member.MemLoginNO, member.Superior, member.RealName, member.IdentityCard, member.Mobile);
                //int addcs = action.AddCS(member.MemLoginNO, member.Pwd, member.RealName, member.IdentityCard, member.Mobile, GetIP(), ConvertDateTimeInt(DateTime.Now).ToString());
                //if (action.Add(member) == 1&&action.Add3G(member.MemLoginNO,member.Superior,member.Name,member.IdentityCard,member.Mobile)==1)
                if (action.Add(member) == 1 && add3g == 1 && addcs==1)
                {
                    #region 东风接口注册

                    //HttpWebRequest request = HttpWebRequest.Create("http://g.dbce.cn/adm/xmlInterface.do") as HttpWebRequest;
                    //request.Method = "POST";

                    //request.Accept = "application/xml";
                    //request.ContentType = "application/xml";
                    //string DongFengNo = "";
                    //string memNO = member.MemLoginNO.ToString();
                    //DongFengNo = memNO.Substring(memNO.IndexOf('C') + 1);
                    //if (DongFengNo.Length == 7)
                    //{
                    //    DongFengNo = "tj0" + DongFengNo;
                    //}
                    //else
                    //{
                    //    DongFengNo = "tj" + DongFengNo;
                    //}
                    //string responseData = "";
                    //string Smobile = memberAction.SelectMemberNObyMobile(member.Superior);
                    //string xmlContent = string.Format("<?xml version=\"1.0\" encoding=\"GBK\" ?><DF name=\"REG\"><header><syscode>tj</syscode><key>a14e8d69b56ad10859b6a7c101a83eb4</key><submitdate>{0}</submitdate><requestsn>{1}</requestsn></header><body><membercode>{2}</membercode><name>{3}</name><mobile>{4}</mobile><introtel>{5}</introtel><introtelbak>{6}</introtelbak><info>{7}</info></body></DF>", System.DateTime.Now.ToString("yyyyMMddhhmmss"), System.DateTime.Now.ToString("yyyyMMdd") + "0000",
                    //        DongFengNo, member.RealName, member.Mobile, Smobile, "15000000001", member.MemLoginNO);
                    //byte[] bs = Encoding.GetEncoding("GBK").GetBytes(xmlContent);

                    //request.ContentLength = bs.Length;

                    //using (Stream reqStream = request.GetRequestStream())
                    //{
                    //    reqStream.Write(bs, 0, bs.Length);
                    //    reqStream.Close();
                    //}


                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //{
                    //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK")))
                    //    {
                    //        responseData = reader.ReadToEnd().ToString();

                    //    }
                    //}
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(responseData);
                    //XmlNode node = doc.SelectSingleNode("//returnmsg");
                    //string result = node.InnerText;


                    #endregion
                    string result = "注册成功";
                    if (result == "注册成功" || result.Contains("推荐人不存在"))
                    {

                        #region 成功注册之后所走流程
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
                        if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                        {
                            try
                            {
                                string oldUser = string.Empty;
                                HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                                oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                                ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                    (oldUser,
                                        TextBoxMemLoginID
                                            .Text
                                            .Trim());
                                cookie3.Values.Clear();
                            }
                            catch (Exception exception2)
                            {
                                exception = exception2;
                            }
                        }

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
                                if (Func.uc_user_register(member.MemLoginID, TextBoxPwd.Text.Trim(), str20) > 0)
                                {
                                    string script =
                                        Func.uc_user_synlogin(
                                            Func.uc_user_login(member.MemLoginID, TextBoxPwd.Text.Trim()).Uid);
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
                                if (session.Register(member.MemLoginID, TextBoxPwd.Text.Trim(), str9, false) > 0)
                                {
                                    int uid = 0;
                                    uid = session.GetUserID(member.MemLoginID);
                                    session.Login(uid, TextBoxPwd.Text.Trim(), false, 100,
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
                            if (TextBoxEmail.Text == "")
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
                                if (TextBoxMemLoginID.Text != "")
                                {
                                    Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                        "  and MemLoginID='" + TextBoxMemLoginID.Text + "'");
                                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                        "window.location.href='" +
                                        GetPageName.RetDomainUrl(
                                            "MemberRegisterSuccess") +
                                        "?type=2&MemLoginID=" +
                                        TextBoxMemLoginID.Text.Trim() + "'", true);
                                }
                                else if (TextBoxMobile.Text != "")
                                {
                                    Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                                        " and Mobile='" + TextBoxMobile.Text + "'");
                                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                        "window.location.href='" +
                                        GetPageName.RetDomainUrl(
                                            "MemberRegisterSuccess") +
                                        "?type=2&MemLoginID=" +
                                        TextBoxMobile.Text.Trim() + "'", true);
                                }
                            }

                            try
                            {
                                RegIsActivationEmail email;
                                str4 = Guid.NewGuid().ToString();
                                email = new RegIsActivationEmail
                                {
                                    Email = TextBoxEmail.Text.Trim(),
                                    Name = TextBoxMemLoginID.Text.Trim(),
                                    link =
                                        GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                                        "&type=0&email=" + TextBoxEmail.Text.Trim() + "&userID=" +
                                        TextBoxMemLoginID.Text.Trim(),
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
                                        .Replace("{$PassWord}", TextBoxPwd.Text)
                                        .Replace("{$ShopName}", email.ShopName)
                                        .Replace("{$CheckUrl}", email.link)
                                        .Replace("{$SendTime}", email.SysSendTime);
                                str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                                SendMailForRegister(TextBoxMemLoginID.Text.Trim(), TextBoxEmail.Text.Trim(), str4, "", str6,
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
                                Email = TextBoxEmail.Text.Trim(),
                                Name = TextBoxMemLoginID.Text.Trim(),
                                Password = TextBoxPwd.Text.Trim(),
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
                            new SendEmail().Emails(TextBoxEmail.Text.Trim(), TextBoxMemLoginID.Text.Trim(), str6, str7, str8);
                        }

                        AddScroll();

                        if (str2 == "0")
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
                                shopRankByMemLoginID =
                                    ((Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                                        .GetShopRankByMemLoginID(member.MemLoginID);
                                if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                                {
                                    cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                                }
                            }
                            cookie.Values.Add("UID", "-1");
                            cookie2 = HttpSecureCookie.Encode(cookie);
                            cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(cookie2);
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                "window.location.href='" +
                                GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                                "?type=2&MemLoginID=" +
                                TextBoxMemLoginID.Text.Trim() + "'",
                                true);
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                                "window.location.href='" +
                                GetPageName.RetDomainUrl("E-mailVerification") +
                                "?email=" + TextBoxEmail.Text.Trim() + "&id=" +
                                TextBoxEmail.Text.Trim() + "'", true);
                        }
                        #endregion
                    }
                    # region

                    //else if (result.Contains("推荐人不存在"))
                    //{
                    //    HttpWebRequest request2 = HttpWebRequest.Create("http://g.dbce.cn/adm/xmlInterface.do") as HttpWebRequest;
                    //    request2.Method = "POST";

                    //    request2.Accept = "application/xml";
                    //    request2.ContentType = "application/xml";

                    //    string xmlContent2 = string.Format("<?xml version=\"1.0\" encoding=\"GBK\" ?><DF name=\"REG\"><header><syscode>tj</syscode><key>a14e8d69b56ad10859b6a7c101a83eb4</key><submitdate>{0}</submitdate><requestsn>{1}</requestsn></header><body><membercode>{2}</membercode><name>{3}</name><mobile>{4}</mobile><introtel>{5}</introtel><introtelbak>{6}</introtelbak><info>{7}</info></body></DF>", System.DateTime.Now.ToString("yyyyMMddhhmmss"), System.DateTime.Now.ToString("yyyyMMdd") + "0000",
                    //        DongFengNo, member.RealName, member.Mobile, "13368376497", "15000000001", member.MemLoginNO);
                    //    byte[] bs2 = Encoding.GetEncoding("GBK").GetBytes(xmlContent2);

                    //    request2.ContentLength = bs2.Length;

                    //    using (Stream reqStream = request2.GetRequestStream())
                    //    {
                    //        reqStream.Write(bs2, 0, bs2.Length);
                    //        reqStream.Close();
                    //    }


                    //    using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
                    //    {
                    //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK")))
                    //        {
                    //            responseData = reader.ReadToEnd().ToString();

                    //        }
                    //    }

                    //    XmlDocument doc2 = new XmlDocument();
                    //    doc2.LoadXml(responseData);
                    //    XmlNode node2 = doc2.SelectSingleNode("//returnmsg");
                    //    string result2 = node2.InnerText;
                    //    if (result2 == "注册成功")
                    //    {

                    //        #region 成功注册之后所走流程
                    //        DataTable DeppTable = action.SelectGetDeep(member.Superior);
                    //        int deep = 0;
                    //        if (DeppTable != null && DeppTable.Rows.Count > 0)
                    //        {
                    //            int SupriDeep = Convert.ToInt32(DeppTable.Rows[0]["deep"]);

                    //            if (SupriDeep == 0)
                    //            {
                    //                deep = 0;
                    //            }
                    //            else
                    //            {
                    //                deep = SupriDeep + 1;
                    //            }
                    //        }
                    //        member.Deep = deep;
                    //        action.AddMemberRecommand(member);

                    //        HttpCookie cookie;
                    //        HttpCookie cookie2;
                    //        string str4;
                    //        string str5;
                    //        string str6;
                    //        string str7;
                    //        string str8;
                    //        DataTable editInfo;
                    //        DataTable shopRankByMemLoginID;
                    //        if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    //        {
                    //            try
                    //            {
                    //                string oldUser = string.Empty;
                    //                HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                    //                oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                    //                ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                    //                    (oldUser,
                    //                        TextBoxMemLoginID
                    //                            .Text
                    //                            .Trim());
                    //                cookie3.Values.Clear();
                    //            }
                    //            catch (Exception exception2)
                    //            {
                    //                exception = exception2;
                    //            }
                    //        }

                    //        if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
                    //        {
                    //            try
                    //            {
                    //                string str20 = member.Email;
                    //                if (member.Email == "")
                    //                {
                    //                    str20 = member.MemLoginID + "@163.com";
                    //                }
                    //                else
                    //                {
                    //                    str20 = member.Email;
                    //                }
                    //                if (Func.uc_user_register(member.MemLoginID, TextBoxPwd.Text.Trim(), str20) > 0)
                    //                {
                    //                    string script =
                    //                        Func.uc_user_synlogin(
                    //                            Func.uc_user_login(member.MemLoginID, TextBoxPwd.Text.Trim()).Uid);
                    //                    HttpContext.Current.Response.AddHeader("P3P",
                    //                        "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
                    //                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msgok", script, false);
                    //                }
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }

                    //        string str19 = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
                    //        if (str19.Trim() == "1")
                    //        {
                    //            DiscuzSession session = DiscuzSessionHelper.GetSession();
                    //            try
                    //            {
                    //                string str9 = member.Email;
                    //                if (member.Email == "")
                    //                {
                    //                    str9 = member.MemLoginID + "@163.com";
                    //                }
                    //                else
                    //                {
                    //                    str9 = member.Email;
                    //                }
                    //                if (session.Register(member.MemLoginID, TextBoxPwd.Text.Trim(), str9, false) > 0)
                    //                {
                    //                    int uid = 0;
                    //                    uid = session.GetUserID(member.MemLoginID);
                    //                    session.Login(uid, TextBoxPwd.Text.Trim(), false, 100,
                    //                        ConfigurationManager.AppSettings["DiscuzCookieDomain"]);
                    //                }
                    //            }
                    //            catch (Exception exception3)
                    //            {
                    //                exception = exception3;
                    //            }
                    //        }

                    //        if (ConfigurationManager.AppSettings["IsIntergrationTg"] == "1")
                    //        {
                    //            var section =
                    //                (AppSettingsSection)
                    //                    WebConfigurationManager.OpenWebConfiguration(Page.Request.ApplicationPath)
                    //                        .GetSection("appSettings");
                    //            string str12 = section.Settings["TgPostUrl"].Value;
                    //            string str16 = section.Settings["TgSourceKey"].Value;
                    //            if (method_0(string.Concat(new object[]
                    //    {
                    //        str12, "IntergrationMemberRegist.aspx?MemLoginID=", member.MemLoginID,"&MemLoginNO=",member.MemLoginNO, "&Email=",
                    //        member.Email, "&Pwd=", member.Pwd, "&PayPwd=", member.PayPwd, "&Sex=", member.Sex,
                    //        "&Birthday=", member.Birthday, "&Photo=", member.Photo, "&RealName=",
                    //        member.RealName, "&Area=", member.Address, "&Vocation=", member.Vocation, "&Address=",
                    //        member.Address, "&Postalcode=", member.Postalcode, "&Fax=", member.Fax, "&QQ=",
                    //        member.QQ, "&WebSite=", member.WebSite, "&Question=",
                    //        member.Question, "&Answer=", member.Answer, "&RegDate=", member.RegeDate,
                    //        "&LastLoginDate=", member.LastLoginDate, "&LastLoginIP=", member.LastLoginIP,
                    //        "&LoginTime=", DateTime.Now.ToString(), "&AdvancePayment=", member.AdvancePayment,
                    //        "&Score=", member.Score, "&RankScore=0&LockAdvancePayment=",
                    //        member.LockAdvancePayment, "&LockSocre=", member.LockSocre, "&MemberRankGuid=",
                    //        Guid.Empty, "&TradeCount=0&CreateUser=  &CreateTime=", DateTime.Now.ToString(),
                    //        "&ModifyUser= &ModifyTime=", DateTime.Now.ToString(), "&TgSourceKey=", str16
                    //    })) != string.Empty)
                    //            {
                    //                string str13 =
                    //                    string.Concat(new object[]
                    //            {
                    //                str12, "IntergrationMemberLogin.aspx?MemLoginID=", member.MemLoginID,
                    //                "&MemberRankGuid=", Guid.NewGuid(), "&Pwd=", member.Pwd, "&TgSourceKey=",
                    //                section.Settings["TgSourceKey"].Value
                    //            });
                    //                string format = "<script src='{0}'></script>";
                    //                format = string.Format(format, str13);
                    //                Page.Response.Write(format);
                    //            }
                    //        }

                    //        if (str2 == "1")
                    //        {
                    //            if (TextBoxEmail.Text == "")
                    //            {
                    //                cookie = new HttpCookie("MemberLoginCookie");
                    //                cookie.Values.Add("MemLoginID", member.MemLoginID);
                    //                cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                    //                cookie.Values.Add("Name", member.RealName);
                    //                cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                    //                cookie.Values.Add("MemberType", member.MemberType.ToString());
                    //                cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());
                    //                if (member.MemberType.ToString() == "2")
                    //                {
                    //                    var action3 =
                    //                        (Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                    //                    shopRankByMemLoginID = action3.GetShopRankByMemLoginID(member.MemLoginID);
                    //                    if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                    //                    {
                    //                        cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                    //                    }
                    //                }
                    //                cookie.Values.Add("UID", "-1");
                    //                cookie2 = HttpSecureCookie.Encode(cookie);
                    //                cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    //                Page.Response.AppendCookie(cookie2);
                    //                if (TextBoxMemLoginID.Text != "")
                    //                {
                    //                    Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                    //                        "  and MemLoginID='" + TextBoxMemLoginID.Text + "'");
                    //                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //                        "window.location.href='" +
                    //                        GetPageName.RetDomainUrl(
                    //                            "MemberRegisterSuccess") +
                    //                        "?type=2&MemLoginID=" +
                    //                        TextBoxMemLoginID.Text.Trim() + "'", true);
                    //                }
                    //                else if (TextBoxMobile.Text != "")
                    //                {
                    //                    Common.Common.UpdateInfo("IsMailActivation=1", "ShopNum1_Member",
                    //                        " and Mobile='" + TextBoxMobile.Text + "'");
                    //                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //                        "window.location.href='" +
                    //                        GetPageName.RetDomainUrl(
                    //                            "MemberRegisterSuccess") +
                    //                        "?type=2&MemLoginID=" +
                    //                        TextBoxMobile.Text.Trim() + "'", true);
                    //                }
                    //            }

                    //            try
                    //            {
                    //                RegIsActivationEmail email;
                    //                str4 = Guid.NewGuid().ToString();
                    //                email = new RegIsActivationEmail
                    //                {
                    //                    Email = TextBoxEmail.Text.Trim(),
                    //                    Name = TextBoxMemLoginID.Text.Trim(),
                    //                    link =
                    //                        GetPageName.RetDomainUrl("MemberRegisterToMail") + "?code=" + str4 +
                    //                        "&type=0&email=" + TextBoxEmail.Text.Trim() + "&userID=" +
                    //                        TextBoxMemLoginID.Text.Trim(),
                    //                    ShopName = str3,
                    //                    SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    //                };
                    //                str5 = string.Empty;
                    //                str6 = string.Empty;
                    //                str7 = "7790bcf5-f88a-46bd-8ead-959118481c02";
                    //                str8 = string.Empty;
                    //                var action2 = new ShopNum1_Email_Action();
                    //                editInfo = action2.GetEditInfo("'" + str7 + "'", 0);
                    //                if (editInfo.Rows.Count > 0)
                    //                {
                    //                    str5 = editInfo.Rows[0]["Remark"].ToString();
                    //                    str6 = editInfo.Rows[0]["Title"].ToString();
                    //                }
                    //                str5 =
                    //                    str5.Replace("{$Name}", email.Name)
                    //                        .Replace("{$PassWord}", TextBoxPwd.Text)
                    //                        .Replace("{$ShopName}", email.ShopName)
                    //                        .Replace("{$CheckUrl}", email.link)
                    //                        .Replace("{$SendTime}", email.SysSendTime);
                    //                str8 = email.ChangeRegister(Page.Server.HtmlDecode(str5));
                    //                SendMailForRegister(TextBoxMemLoginID.Text.Trim(), TextBoxEmail.Text.Trim(), str4, "", str6,
                    //                    str7, str8);
                    //            }
                    //            catch (Exception exception4)
                    //            {
                    //                exception = exception4;
                    //                Context.Response.Write(exception.Message);
                    //            }
                    //        }

                    //        if ((str == "1") && (str2 == "0"))
                    //        {
                    //            var register = new Register
                    //            {
                    //                Email = TextBoxEmail.Text.Trim(),
                    //                Name = TextBoxMemLoginID.Text.Trim(),
                    //                Password = TextBoxPwd.Text.Trim(),
                    //                ShopName = str3,
                    //                SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    //            };
                    //            str5 = string.Empty;
                    //            str6 = string.Empty;
                    //            str7 = "4a12724c-5154-4928-b867-d5bd180e80e6";
                    //            str8 = string.Empty;
                    //            editInfo = new ShopNum1_Email_Action().GetEditInfo("'" + str7 + "'", 0);
                    //            str4 = Guid.NewGuid().ToString();
                    //            if (editInfo.Rows.Count > 0)
                    //            {
                    //                str5 = editInfo.Rows[0]["Remark"].ToString();
                    //                str6 = editInfo.Rows[0]["Title"].ToString();
                    //            }
                    //            str8 = register.ChangeRegister(Page.Server.HtmlDecode(str5));
                    //            new SendEmail().Emails(TextBoxEmail.Text.Trim(), TextBoxMemLoginID.Text.Trim(), str6, str7, str8);
                    //        }

                    //        AddScroll();

                    //        if (str2 == "0")
                    //        {
                    //            cookie = new HttpCookie("MemberLoginCookie");
                    //            cookie.Values.Add("MemLoginID", member.MemLoginID);
                    //            cookie.Values.Add("MemLoginNO", member.MemLoginNO);
                    //            cookie.Values.Add("Name", member.RealName);
                    //            cookie.Values.Add("IsMailActivation", member.IsMailActivation.ToString());
                    //            cookie.Values.Add("MemberType", member.MemberType.ToString());
                    //            cookie.Values.Add("MemRankGuid", member.MemberRankGuid.ToString());

                    //            if (member.MemberType.ToString() == "2")
                    //            {
                    //                shopRankByMemLoginID =
                    //                    ((Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action())
                    //                        .GetShopRankByMemLoginID(member.MemLoginID);
                    //                if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                    //                {
                    //                    cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                    //                }
                    //            }
                    //            cookie.Values.Add("UID", "-1");
                    //            cookie2 = HttpSecureCookie.Encode(cookie);
                    //            cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    //            Page.Response.AppendCookie(cookie2);
                    //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //                "window.location.href='" +
                    //                GetPageName.RetDomainUrl("MemberRegisterSuccess") +
                    //                "?type=2&MemLoginID=" +
                    //                TextBoxMemLoginID.Text.Trim() + "'",
                    //                true);
                    //        }
                    //        else
                    //        {
                    //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "memlogin",
                    //                "window.location.href='" +
                    //                GetPageName.RetDomainUrl("E-mailVerification") +
                    //                "?email=" + TextBoxEmail.Text.Trim() + "&id=" +
                    //                TextBoxEmail.Text.Trim() + "'", true);
                    //        }
                    //        #endregion
                    //    }
                    //    else
                    //    {
                    //        action.DeleteLian3G(member.MemLoginNO);
                    //        action.Delete3G(member.MemLoginNO);
                    //        MessageBox.Show(result2);
                    //    }

                    //}
                    #endregion
                    else
                    {
                        //action.DeleteLian3G(member.MemLoginNO);
                        //action.Delete3G(member.MemLoginNO);
                        MessageBox.Show(result+"111");
                    }
                }
                #endregion
                else
                {
                    //action.DeleteLian3G(member.MemLoginNO);
                    //action.Delete3G(member.MemLoginNO);
                    MessageBox.Show("注册失败!请重新注册");
                }
            }
        }

        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        } 
        public void AddScroll()
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
                    MemLoginID = TextBoxMemLoginID.Text,
                    CreateUser = TextBoxMemLoginID.Text,
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
                    MemLoginID = TextBoxMemLoginID.Text,
                    CreateUser = TextBoxMemLoginID.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
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
    }
}