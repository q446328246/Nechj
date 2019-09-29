using System;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using ShopNum1MultiEntity;
using ShopNum1_Second;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SecondUserBind : BaseWebControl, ICallbackEventHandler
    {
        private readonly ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 =
            new ShopNum1_SecondTypeBussiness();

        private readonly ShopNum1_SecondUserBussiness shopNum1_SecondUserBussiness_0 =
            new ShopNum1_SecondUserBussiness();

        private HtmlGenericControl Divcontent1;
        private HtmlGenericControl Divcontent2;
        private LinkButton LinkButton1;
        private LinkButton LinkButton2;
        private Literal LiteralAccount;
        private Literal LiteralAccountType;
        private Literal LiteralUserName;

        private string skinFilename = "SecondUserBind.ascx";
        private string string_1;

        public SecondUserBind()
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
            Divcontent1 = (HtmlGenericControl) skin.FindControl("Divcontent1");
            Divcontent2 = (HtmlGenericControl) skin.FindControl("Divcontent2");
            LinkButton1 = (LinkButton) skin.FindControl("LinkButton1");
            LinkButton1.Click += LinkButton1_Click;
            LinkButton2 = (LinkButton) skin.FindControl("LinkButton2");
            LinkButton2.Click += LinkButton2_Click;
            if (!Page.IsPostBack && (Page.Request.QueryString["type"] != null))
            {
                string str;
                string memLogid;
                string str5;
                string str3 = Page.Request.QueryString["type"];
                ViewState["type"] = str3;
                string str4 = str3;
                switch (str4)
                {
                    case null:
                        goto Label_0620;

                    case "1":
                    {
                        LiteralAccountType.Text = "QQ账户";
                        LiteralAccount.Text = "QQ";
                        str5 = Page.Request.QueryString["access_token"];
                        var client2 = new ShopNum1_QzoneCommonClient();
                        var response2 = new ShopNum1_QzoneCommonResponse();
                        client2.access_token = str5;
                        string qzoneOpenID = client2.GetQzoneOpenID();
                        if (qzoneOpenID != "")
                        {
                            client2.openid = qzoneOpenID;
                            client2.access_token = str5;
                            client2.AppId = "100226141";
                            DataTable model = shopNum1_SecondTypeBussiness_0.GetModel(1);
                            if ((model != null) && (model.Rows.Count > 0))
                            {
                                client2.AppId = model.Rows[0]["AppID"].ToString();
                            }
                            string str7 = client2.QzoneGet("user", "get_user_info", "xml");
                            LiteralUserName.Text = response2.GetQQUserName(str7, "xml");
                            ViewState["openID"] = qzoneOpenID;
                            ViewState["userName"] = LiteralUserName.Text;
                            memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(qzoneOpenID, "1");
                            if (method_0(memLogid))
                            {
                                Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                                return;
                            }
                        }
                        goto Label_0620;
                    }
                    case "2":
                    {
                        LiteralAccountType.Text = "百度账户";
                        LiteralAccount.Text = "百度";
                        str5 = Page.Request.QueryString["access_token"];
                        ShopNum1_BaiduUserResponse baiduUser = new ShopNum1_BaiduCommonClient().GetBaiduUser(str5,
                            "xml");
                        if (!(baiduUser.uid != ""))
                        {
                            goto Label_0620;
                        }
                        LiteralUserName.Text = baiduUser.uname;
                        ViewState["user"] = baiduUser;
                        memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(baiduUser.uid, "2");
                        if (!method_0(memLogid))
                        {
                            goto Label_0620;
                        }
                        Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                        return;
                    }
                    case "3":
                        LiteralAccountType.Text = "新浪微博";
                        LiteralAccount.Text = "新浪";
                        str = Page.Request.QueryString["uid"];
                        str5 = Page.Request.QueryString["access_token"];
                        if (!(str != ""))
                        {
                            goto Label_0620;
                        }
                        LiteralUserName.Text = "";
                        ViewState["user"] = str;
                        memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str, "3");
                        if (!method_0(memLogid))
                        {
                            goto Label_0620;
                        }
                        Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                        return;
                }
                if (!(str4 == "4"))
                {
                    if (!(str4 == "5"))
                    {
                        goto Label_0620;
                    }
                    LiteralAccountType.Text = "淘宝";
                    LiteralAccount.Text = "淘宝";
                    str = Page.Request.QueryString["user_id"];
                    if (!(str != ""))
                    {
                        goto Label_0620;
                    }
                    ViewState["user_id"] = str;
                    memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str, "5");
                    if (!method_0(memLogid))
                    {
                        goto Label_0620;
                    }
                    Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                }
                else
                {
                    LiteralAccountType.Text = "淘宝支付宝";
                    LiteralAccount.Text = "支付宝";
                    str = Page.Request.QueryString["user_id"];
                    if (!(str != ""))
                    {
                        goto Label_0620;
                    }
                    ViewState["user_id"] = str;
                    memLogid = shopNum1_SecondUserBussiness_0.GetMemLogid(str, "4");
                    if (!method_0(memLogid))
                    {
                        goto Label_0620;
                    }
                    Page.Response.Redirect("http://" + ConfigurationManager.AppSettings["domain"]);
                }
                return;
            }
            Label_0620:
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
            string str9 = "function existemail(inputcontrol) {\n";
            str9 = ((((str9 + "var context = document.getElementById(\"spanErrEmail\");\n" +
                       "var arg = \"ExistEmail|\" + inputcontrol.value;\n") + "if(inputcontrol.value != \"\") {\n" +
                      "var reg = new RegExp(\"\\\\w+([-+.']\\\\w+)*@\\\\w+([-.]\\\\w+)*\\\\.\\\\w+([-.]\\\\w+)*\");\n") +
                     "if(reg.test(inputcontrol.value)) {\n" + "context.innerHTML = \"数据查询中..\"; ") +
                    Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerEmailData", "context") +
                    "; }\n") + "else { context.innerHTML = \"电子邮箱格式不正确\"; }\n}\n" +
                   "else { context.innerHTML = \"电子邮箱不能为空\"; }\n}\n";
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckMemLogin", script, true);
            Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CheckEmail", str9, true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Divcontent1.Visible = true;
            Divcontent2.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Divcontent1.Visible = false;
            Divcontent2.Visible = true;
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
                    var cookie = new HttpCookie("MemberLoginCookie");
                    cookie.Values.Add("MemLoginID", string_2);
                    cookie.Values.Add("Name", memInfoByMemberloginId.Rows[0]["Name"].ToString());
                    cookie.Values.Add("MemberType", memInfoByMemberloginId.Rows[0]["MemberType"].ToString());
                    if (memInfoByMemberloginId.Rows[0]["MemberType"].ToString() == "2")
                    {
                        DataTable shopRankByMemLoginID =
                            ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                                .GetShopRankByMemLoginID(string_2);
                        if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                        {
                            cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                        }
                    }
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie2);
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
            string str3 = Page.Request.Form["seconduserBind_userName_c"];
            string str4 = ViewState["type"].ToString();
            string str5 = str4;
            switch (str5)
            {
                case null:
                    break;

                case "1":
                    model.MemlogID = str3;
                    model.SecondID = ViewState["openID"].ToString();
                    break;

                case "2":
                    response = (ShopNum1_BaiduUserResponse) ViewState["user"];
                    model.MemlogID = str3;
                    model.SecondID = response.uid;
                    break;

                case "3":
                    model.MemlogID = str3;
                    model.SecondID = ViewState["user"].ToString();
                    break;

                default:
                    if (!(str5 == "4"))
                    {
                        if (str5 == "5")
                        {
                            model.MemlogID = str3;
                            model.SecondID = ViewState["user_id"].ToString();
                        }
                    }
                    else
                    {
                        model.MemlogID = str3;
                        model.SecondID = ViewState["user_id"].ToString();
                    }
                    break;
            }
            model.Secondtype = str4;
            model.isAvailable = 1;
            if (shopNum1_SecondUserBussiness_0.Add(model))
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                var member = new ShopNum1_Member
                {
                    MemLoginID = model.MemlogID,
                    MemberType = 1
                };
                str5 = str4;
                switch (str5)
                {
                    case null:
                        break;

                    case "1":
                        member.Name = ViewState["userName"].ToString();
                        member.Photo = "";
                        break;

                    case "2":
                    {
                        response = (ShopNum1_BaiduUserResponse) ViewState["user"];
                        member.Name = response.uname;
                        var operate = new UrlImgOperate();
                        string str8 = string.Format("http://himg.bdimg.com/sys/portraitn/item/{0}.jpg",
                            response.portrait);
                        member.Photo = operate.GetUrlFileName(str8);
                        break;
                    }
                    case "3":
                        member.Name = "";
                        member.Photo = "";
                        break;

                    default:
                        if (!(str5 == "4"))
                        {
                            if (str5 == "5")
                            {
                                member.Name = "";
                                member.Photo = "";
                            }
                        }
                        else
                        {
                            member.Name = "";
                            member.Photo = "";
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
                member.IsMailActivation = 0;
                member.IsMobileActivation = 0;
                string s = ShopSettings.GetValue("RegPresentRankScore");
                if ((s == "") || (s == null))
                {
                    member.MemberRank = 0;
                }
                else
                {
                    member.MemberRank = int.Parse(s);
                }
                string str7 = ShopSettings.GetValue("RegPresentScore");
                if ((str7 == "") || (str7 == null))
                {
                    member.Score = 0;
                }
                else
                {
                    member.Score = int.Parse(str7);
                }
                member.LastLoginIP = null;
                member.LoginTime = 0;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                member.PayPwd = Encryption.GetMd5SecondHash(model.MemlogID);
                member.PromotionMemLoginID = "";
                if (action.Add(member) == 1)
                {
                    var cookie = new HttpCookie("MemberLoginCookie");
                    cookie.Values.Add("MemLoginID", member.MemLoginID);
                    cookie.Values.Add("MemberType", "1");
                    cookie.Values.Add("uid", "-1");
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie2);
                    string str9 = ShopSettings.GetValue("RegIsEmail");
                    ShopSettings.GetValue("RegIsMMS");
                    ShopSettings.GetValue("Name");
                    if (!(str9 == "1"))
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
                {
                    var response2 = (ShopNum1_XinlanUserResponse) ViewState["user"];
                    model.SecondID = response2.Id.ToString();
                    break;
                }
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
                IShopNum1_Member_Action action = LogicFactory.CreateShopNum1_Member_Action();
                DataTable memberPassWord = action.GetMemberPassWord(loginID, Encryption.GetMd5Hash(input));
                if ((memberPassWord != null) && (memberPassWord.Rows.Count > 0))
                {
                    if (memberPassWord.Rows[0]["IsForbid"].ToString() != "1")
                    {
                        var cookie = new HttpCookie("MemberLoginCookie");
                        cookie.Values.Add("MemLoginID", memberPassWord.Rows[0]["MemLoginID"].ToString());
                        cookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
                        cookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
                        if (memberPassWord.Rows[0]["MemberType"].ToString() == "2")
                        {
                            DataTable shopRankByMemLoginID =
                                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                                    .GetShopRankByMemLoginID(memberPassWord.Rows[0]["MemLoginID"].ToString());
                            if ((shopRankByMemLoginID != null) && (shopRankByMemLoginID.Rows.Count > 0))
                            {
                                cookie.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
                            }
                        }
                        cookie.Values.Add("uid", "-1");
                        HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                        cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                        Page.Response.AppendCookie(cookie2);
                        action.UpdateLoginTime(loginID, Page.Request.UserHostAddress);
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

        public void RaisePostBackEvent()
        {
            var class2 = new Class1
            {
                secondUserBind_0 = this,
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


        private sealed class Class1
        {
            public SecondUserBind secondUserBind_0;
            public string string_0;

            public bool method_0(string string_1)
            {
                if (string_0 == "BtnBind")
                {
                    secondUserBind_0.method_2();
                }
                else if (string_0 == "BtnCreate")
                {
                    secondUserBind_0.method_1();
                }
                return true;
            }
        }
    }
}