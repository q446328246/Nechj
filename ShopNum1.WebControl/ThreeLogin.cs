using System;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using ShopNum1_Second;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ThreeLogin : BaseWebControl, ICallbackEventHandler
    {
        private static Func<string, string> func_0;

        private readonly ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 =
            new ShopNum1_SecondTypeBussiness();

        private readonly ShopNum1_SecondUserBussiness shopNum1_SecondUserBussiness_0 =
            new ShopNum1_SecondUserBussiness();

        private Literal LiteralAccount;
        private Literal LiteralAccountType;
        private Literal LiteralUserName;

        private string skinFilename = "ThreeLogin.ascx";
        private string string_1;

        public ThreeLogin()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetCallbackResult()
        {
            string[] strArray = string_1.Split(new[] {'|'});
            if (strArray.Length == 2)
            {
                return (string) base.GetType().GetMethod(strArray[0]).Invoke(this, new object[] {strArray[1]});
            }
            return (string) base.GetType().GetMethod(strArray[0]).Invoke(this, new object[] {strArray[1], strArray[2]});
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string_1 = eventArgument;
        }

        public string CheckLogin(string memlogid, string string_2)
        {
            return "1";
        }

        public string ExistEmail(string email)
        {
            if (LogicFactory.CreateShopNum1_Member_Action().CheckmemEmail(email) > 0)
            {
                return "1";
            }
            return "0";
        }

        protected override void InitializeSkin(Control skin)
        {
            LiteralUserName = (Literal) skin.FindControl("LiteralUserName");
            LiteralAccountType = (Literal) skin.FindControl("LiteralAccountType");
            LiteralAccount = (Literal) skin.FindControl("LiteralAccount");
            if (Page.Request.QueryString["type"] != null)
            {
                string memLogid;
                string str6;
                string str7;
                string str8;
                string str = Page.Request.QueryString["type"];
                ViewState["type"] = str;
                switch (str)
                {
                    case "1":
                    {
                        LiteralAccountType.Text = "QQ账户";
                        LiteralAccount.Text = "QQ";
                        str8 = Page.Request.QueryString["access_token"];
                        var client = new ShopNum1_QzoneCommonClient();
                        var response = new ShopNum1_QzoneCommonResponse();
                        client.access_token = str8;
                        string qzoneOpenID = client.GetQzoneOpenID();
                        if (qzoneOpenID != "")
                        {
                            client.openid = qzoneOpenID;
                            client.access_token = str8;
                            client.AppId = "100226141";
                            DataTable model = shopNum1_SecondTypeBussiness_0.GetModel(1);
                            if ((model != null) && (model.Rows.Count > 0))
                            {
                                client.AppId = model.Rows[0]["AppID"].ToString();
                            }
                            string str3 = client.QzoneGet("user", "get_user_info", "xml");
                            LiteralUserName.Text = response.GetQQUserName(str3, "xml");
                            ViewState["openID"] = qzoneOpenID;
                            ViewState["userName"] = LiteralUserName.Text;
                            memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(qzoneOpenID, "1");
                            if (method_0(memLogid))
                            {
                                if (Page.Request.Cookies["ProductDetail"] != null)
                                {
                                    str6 =
                                        Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/")
                                            .Replace(".aspx%3Fguid%3D", "/");
                                    Page.Response.Redirect(str6);
                                }
                                else
                                {
                                    Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                                }
                                return;
                            }
                            method_3();
                        }
                        break;
                    }
                    case "2":
                    {
                        LiteralAccountType.Text = "百度账户";
                        LiteralAccount.Text = "百度";
                        str8 = Page.Request.QueryString["access_token"];
                        ShopNum1_BaiduUserResponse baiduUser = new ShopNum1_BaiduCommonClient().GetBaiduUser(str8,
                            "json");
                        if (!(baiduUser.uid != ""))
                        {
                            break;
                        }
                        LiteralUserName.Text = baiduUser.uname;
                        ViewState["user"] = baiduUser;
                        memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(baiduUser.uid, "2");
                        if (!method_0(memLogid))
                        {
                            break;
                        }
                        if (Page.Request.Cookies["ProductDetail"] != null)
                        {
                            str6 =
                                Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/")
                                    .Replace(".aspx%3Fguid%3D", "/");
                            Page.Response.Redirect(str6);
                        }
                        else
                        {
                            Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                        }
                        return;
                    }
                    case "3":
                        LiteralAccountType.Text = "新浪微博";
                        LiteralAccount.Text = "新浪";
                        str7 = Page.Request.QueryString["uid"];
                        str8 = Page.Request.QueryString["access_token"];
                        new ShopNum1_XinlanCommonClient().GetXinlanUser(str7, str8);
                        if (!(str7 != ""))
                        {
                            break;
                        }
                        LiteralUserName.Text = "";
                        ViewState["user"] = str7;
                        memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str7, "3");
                        if (!method_0(memLogid))
                        {
                            break;
                        }
                        if (Page.Request.Cookies["ProductDetail"] != null)
                        {
                            str6 =
                                Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/")
                                    .Replace(".aspx%3Fguid%3D", "/");
                            Page.Response.Redirect(str6);
                        }
                        else
                        {
                            Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                        }
                        return;

                    case "4":
                        LiteralAccountType.Text = "淘宝支付宝";
                        LiteralAccount.Text = "支付宝";
                        str7 = Page.Request.QueryString["user_id"];
                        if (str7 != "")
                        {
                            ViewState["user_id"] = str7;
                            memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str7, "4");
                            if (method_0(memLogid))
                            {
                                if (Page.Request.Cookies["ProductDetail"] != null)
                                {
                                    str6 =
                                        Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/")
                                            .Replace(".aspx%3Fguid%3D", "/");
                                    Page.Response.Redirect(str6);
                                }
                                else
                                {
                                    Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                                }
                                return;
                            }
                        }
                        break;

                    case "5":
                        LiteralAccountType.Text = "淘宝";
                        LiteralAccount.Text = "淘宝";
                        str7 = Page.Request.QueryString["user_id"];
                        if (str7 != "")
                        {
                            ViewState["user_id"] = str7;
                            memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str7, "5");
                            if (method_0(memLogid))
                            {
                                if (Page.Request.Cookies["ProductDetail"] != null)
                                {
                                    str6 =
                                        Page.Request.Cookies["ProductDetail"].Value.Replace("%3A", ":/")
                                            .Replace(".aspx%3Fguid%3D", "/");
                                    Page.Response.Redirect(str6);
                                }
                                else
                                {
                                    Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                                }
                                return;
                            }
                        }
                        break;
                }
            }
            if (Page.IsPostBack &&
                ((Page.Request.Form["secondUserEVENTTARGET"] != null) &&
                 (Page.Request.Form["secondUserEVENTTARGET"] != "")))
            {
                RaisePostBackEvent();
            }
            string script = "function CheckMemLogin() {\n";
            script = (((((script + "var inputcontrol = document.getElementById(\"seconduserBind_userName\");\n") +
                         "var context = document.getElementById(\"spanContent\");\n" +
                         "var pwd = document.getElementById(\"seconduserBind_password\").value; \n") +
                        "var arg2 = \"CheckLogin|\" + inputcontrol.value+\"|\"+pwd;\n" +
                        @"var reg = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,12}$/") + "\n if(inputcontrol.value != \"\") {\n" +
                       "if(reg.test(inputcontrol.value)) {context.innerHTML = \"正在验证..\"; ") +
                      Page.ClientScript.GetCallbackEventReference(this, "arg2", "ReceiveServerData", "context") +
                      "; }\n") + "else { context.innerHTML = \"用户名格式不正确\";}\n}\n" +
                     "else { context.innerHTML = \"用户名不能为空\";}\n}\n";
            string str10 = "function existemail(inputcontrol) {\n";
            str10 = ((((str10 + "var context = document.getElementById(\"spanErrEmail\");\n" +
                        "var arg = \"ExistEmail|\" + inputcontrol.value;\n") + "if(inputcontrol.value != \"\") {\n" +
                       "var reg = new RegExp(\"\\\\w+([-+.']\\\\w+)*@\\\\w+([-.]\\\\w+)*\\\\.\\\\w+([-.]\\\\w+)*\");\n") +
                      "if(reg.test(inputcontrol.value)) {\n" + "context.innerHTML = \"数据查询中..\"; ") +
                     Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerEmailData", "context") +
                     "; }\n") + "else { context.innerHTML = \"电子邮箱格式不正确\"; }\n}\n" +
                    "else { context.innerHTML = \"电子邮箱不能为空\"; }\n}\n";
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckMemLogin", script, true);
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckEmail", str10, true);
        }

        private bool method_0(string string_2)
        {
            if (!string.IsNullOrEmpty(string_2))
            {
                DataTable memInfoByMemberloginId =
                    LogicFactory.CreateShopNum1_Member_Action().GetMemInfoByMemberloginId(string_2);
                if ((memInfoByMemberloginId != null) && (memInfoByMemberloginId.Rows.Count > 0))
                {
                    if (memInfoByMemberloginId.Rows[0]["IsForbid"].ToString() == "1")
                    {
                        MessageBox.Show("对不起，您的账户已被禁用！");
                        return false;
                    }
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie cookie = Page.Request.Cookies["Visitor_LoginCookie"];
                            oldUser = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
                            ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                (oldUser,
                                    string_2);
                            cookie.Values.Clear();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var cookie3 = new HttpCookie("MemberLoginCookie");
                    cookie3.Values.Add("MemLoginID", string_2);
                    cookie3.Values.Add("Name", memInfoByMemberloginId.Rows[0]["Name"].ToString());
                    cookie3.Values.Add("MemberType", memInfoByMemberloginId.Rows[0]["MemberType"].ToString());
                    if (memInfoByMemberloginId.Rows[0]["MemberType"].ToString() == "2")
                    {
                        DataTable shopRankByMemLoginID =
                            ShopFactory.LogicFactory.CreateShop_ShopInfo_Action().GetShopRankByMemLoginID(string_2);
                        if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                        {
                            cookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                        }
                    }
                    HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                    cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie4);
                    return true;
                }
            }
            return false;
        }

        protected void method_1()
        {
            ShopNum1_BaiduUserResponse response;
            var model = new ShopNum1_SecondUser();
            lock (DateTime.Now.ToString("MMddmmss"))
            {
                Thread.Sleep(20);
            }
            string str5 = Page.Request.Form["seconduserBind_userName_c"];
            string str6 = ViewState["type"].ToString();
            string str4 = str6;
            switch (str4)
            {
                case null:
                    break;

                case "1":
                    model.MemlogID = str5;
                    model.SecondID = ViewState["openID"].ToString();
                    break;

                case "2":
                    response = (ShopNum1_BaiduUserResponse) ViewState["user"];
                    model.MemlogID = str5;
                    model.SecondID = response.uid;
                    break;

                case "3":
                    model.MemlogID = str5;
                    model.SecondID = ViewState["user"].ToString();
                    break;

                default:
                    if (!(str4 == "4"))
                    {
                        if (str4 == "5")
                        {
                            model.MemlogID = str5;
                            model.SecondID = ViewState["user_id"].ToString();
                        }
                    }
                    else
                    {
                        model.MemlogID = str5;
                        model.SecondID = ViewState["user_id"].ToString();
                    }
                    break;
            }
            model.Secondtype = str6;
            model.isAvailable = 1;
            if (shopNum1_SecondUserBussiness_0.Add(model))
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                var member = new ShopNum1_Member
                {
                    MemLoginID = model.MemlogID,
                    MemberType = 1
                };
                str4 = str6;
                switch (str4)
                {
                    case null:
                        break;

                    case "1":
                        member.Name = ViewState["userName"].ToString();
                        break;

                    case "2":
                        response = (ShopNum1_BaiduUserResponse) ViewState["user"];
                        member.Name = response.uname;
                        new UrlImgOperate();
                        string.Format("http://himg.bdimg.com/sys/portraitn/item/{0}.jpg", response.portrait);
                        break;

                    case "3":
                        member.Name = "";
                        break;

                    default:
                        if (!(str4 == "4"))
                        {
                            if (str4 == "5")
                            {
                                member.Name = "";
                            }
                        }
                        else
                        {
                            member.Name = "";
                        }
                        break;
                }
                member.Pwd = Encryption.GetMd5Hash(Page.Request.Form["seconduserBind_Newpassword"]);
                member.IsForbid = 0;
                member.Email = Page.Request.Form["seconduserBind_email"];
                member.Guid = Guid.NewGuid();
                member.Tel = "";
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.IsMailActivation = 1;
                string s = ShopSettings.GetValue("RegPresentRankScore");
                if ((s == "") || (s == null))
                {
                    member.MemberRank = 0;
                }
                else
                {
                    member.MemberRank = int.Parse(s);
                }
                string str8 = ShopSettings.GetValue("RegPresentScore");
                if ((str8 == "") || (str8 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str8);
                }
                member.LastLoginIP = null;
                member.LoginTime = 0;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                member.PayPwd = Encryption.GetMd5SecondHash(model.MemlogID);
                if (action.Add(member) == 1)
                {
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                            oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                            ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                (oldUser,
                                    model
                                        .MemlogID);
                            cookie3.Values.Clear();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var cookie = new HttpCookie("MemberLoginCookie");
                    cookie.Values.Add("MemLoginID", member.MemLoginID);
                    cookie.Values.Add("MemberType", "1");
                    cookie.Values.Add("uid", "-1");
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie2);
                    string str7 = ShopSettings.GetValue("RegIsEmail");
                    ShopSettings.GetValue("RegIsMMS");
                    ShopSettings.GetValue("Name");
                    if (!(str7 == "1"))
                    {
                    }
                    Page.Response.Redirect("http://" + ShopSettings.siteDomain);
                }
                else
                {
                    MessageBox.Show("会员绑定失败!请重新绑定");
                }
            }
        }

        protected void method_2()
        {
            string loginID = Page.Request.Form["seconduserBind_userName"];
            string input = Page.Request.Form["seconduserBind_password"];
            var model = new ShopNum1_SecondUser
            {
                MemlogID = loginID
            };
            string str3 = ViewState["type"].ToString();
            string str4 = str3;
            switch (str4)
            {
                case null:
                    break;

                case "1":
                    model.SecondID = ViewState["openID"].ToString();
                    break;

                case "2":
                    model.SecondID = ((ShopNum1_BaiduUserResponse) ViewState["user"]).uid;
                    break;

                case "3":
                    try
                    {
                        model.SecondID = ViewState["user"].ToString();
                    }
                    catch
                    {
                    }
                    break;

                default:
                    if (!(str4 == "4"))
                    {
                        if (str4 == "5")
                        {
                            model.SecondID = ViewState["user_id"].ToString();
                        }
                    }
                    else
                    {
                        model.SecondID = ViewState["user_id"].ToString();
                    }
                    break;
            }
            model.Secondtype = str3;
            model.isAvailable = 1;
            if (shopNum1_SecondUserBussiness_0.Add(model))
            {
                IShopNum1_Member_Action action2 = LogicFactory.CreateShopNum1_Member_Action();
                DataTable memberPassWord = action2.GetMemberPassWord(loginID, Encryption.GetMd5Hash(input));
                if ((memberPassWord != null) && (memberPassWord.Rows.Count > 0))
                {
                    if (memberPassWord.Rows[0]["IsForbid"].ToString() != "1")
                    {
                        var cookie3 = new HttpCookie("MemberLoginCookie");
                        cookie3.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
                        if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                        {
                            try
                            {
                                string oldUser = string.Empty;
                                HttpCookie cookie = Page.Request.Cookies["Visitor_LoginCookie"];
                                oldUser = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
                                ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action())
                                    .ChangeCarByCook(
                                        oldUser, memberPassWord.Rows[0]["MemLoginID"].ToString());
                                cookie.Values.Clear();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        cookie3.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
                        cookie3.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
                        if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
                        {
                            DataTable shopRankByMemLoginID =
                                ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()
                                    .GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie3.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        cookie3.Values.Add("uid", "-1");
                        HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                        cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        Page.Response.AppendCookie(cookie4);
                        action2.UpdateLoginTime(loginID, Page.Request.UserHostAddress);
                        Page.Response.Redirect("http://" + ShopSettings.siteDomain);
                    }
                    else
                    {
                        MessageBox.Show("您不能绑定该账户，该账户已经被禁用了!");
                    }
                }
                else
                {
                    MessageBox.Show("输入的账户或者密码不正确!");
                }
            }
        }

        protected void method_3()
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string str = ViewState["userName"].ToString().Replace("(", "").Replace(")", "") + "_" + method_5();
            str = method_4(str);
            var model = new ShopNum1_SecondUser();
            lock (DateTime.Now.ToString("MMddmmss"))
            {
                Thread.Sleep(20);
            }
            ViewState["userName"].ToString();
            model.MemlogID = str;
            model.SecondID = ViewState["openID"].ToString();
            model.Secondtype = "1";
            model.isAvailable = 1;
            if (shopNum1_SecondUserBussiness_0.Add(model))
            {
                var member = new ShopNum1_Member
                {
                    MemLoginID = str,
                    MemberType = 1,
                    Name = ViewState["userName"].ToString(),
                    Pwd = Encryption.GetMd5Hash("123456"),
                    IsForbid = 0,
                    Email = "",
                    Guid = Guid.NewGuid(),
                    Tel = "",
                    AdvancePayment = 0,
                    AddressValue = "",
                    AddressCode = "",
                    RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    LoginDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsMailActivation = 1
                };
                string s = ShopSettings.GetValue("RegPresentRankScore");
                if ((s == "") || (s == null))
                {
                    member.MemberRank = 0;
                }
                else
                {
                    member.MemberRank = int.Parse(s);
                }
                string str5 = ShopSettings.GetValue("RegPresentScore");
                if ((str5 == "") || (str5 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str5);
                }
                member.LastLoginIP = null;
                member.LoginTime = 0;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                member.PayPwd = Encryption.GetMd5SecondHash(model.MemlogID);
                DataTable defaultMemberRank =
                    ((ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action()).GetDefaultMemberRank();
                Guid guid = Guid.NewGuid();
                try
                {
                    if ((defaultMemberRank != null) && (defaultMemberRank.Rows.Count > 0))
                    {
                        guid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
                    }
                    else
                    {
                        guid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                    }
                }
                catch (Exception)
                {
                    guid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
                }
                member.MemberRankGuid = guid;
                if (action.Add(member) == 1)
                {
                    var cookie = new HttpCookie("MemberLoginCookie");
                    cookie.Values.Add("MemLoginID", member.MemLoginID);
                    if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                    {
                        try
                        {
                            string oldUser = string.Empty;
                            HttpCookie cookie3 = Page.Request.Cookies["Visitor_LoginCookie"];
                            oldUser = HttpSecureCookie.Decode(cookie3).Values["MemLoginID"];
                            ((Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action()).ChangeCarByCook
                                (oldUser,
                                    member
                                        .MemLoginID);
                            cookie3.Values.Clear();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    cookie.Values.Add("MemberType", "1");
                    cookie.Values.Add("uid", "-1");
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie2);
                    string str6 = ShopSettings.GetValue("RegIsEmail");
                    ShopSettings.GetValue("RegIsMMS");
                    ShopSettings.GetValue("Name");
                    if (!(str6 == "1"))
                    {
                    }
                    Page.Response.Redirect("http://" + ShopSettings.siteDomain);
                }
                else
                {
                    MessageBox.Show("会员绑定失败!请重新绑定");
                }
            }
        }

        private string method_4(string string_2)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if (action.CheckmemLoginID(string_2) > 0)
            {
                string_2 = ViewState["userName"].ToString().Replace("(", "").Replace(")", "") + "_" + method_5();
                method_4(string_2);
                return string_2;
            }
            return string_2;
        }

        private string method_5()
        {
            if (func_0 == null)
            {
                func_0 = smethod_0;
            }
            Func<string, string> func = func_0;
            string arg = string.Empty;
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                char ch;
                int num2 = random.Next();
                if ((num2%2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num2%10)));
                }
                else
                {
                    ch = (char) (0x41 + ((ushort) (num2%0x1a)));
                }
                arg = arg + ch;
            }
            return func(arg);
        }

        public void RaisePostBackEvent()
        {
            var class2 = new Class2
            {
                threeLogin_0 = this,
                string_0 = Page.Request.Form["secondUserEVENTTARGET"]
            };
            Func<string, bool> func = class2.method_0;
            func(class2.string_0);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Page.Request.QueryString["type"] != null)
            {
                base.Render(writer);
            }
        }


        private static string smethod_0(string string_2)
        {
            HttpContext.Current.Session["code"] = string_2;
            return string_2;
        }


        private sealed class Class2
        {
            public string string_0;
            public ThreeLogin threeLogin_0;

            public bool method_0(string string_1)
            {
                if (string_0 == "BtnBind")
                {
                    threeLogin_0.method_2();
                }
                else if (string_0 == "BtnCreate")
                {
                    threeLogin_0.method_1();
                }
                return true;
            }
        }
    }
}