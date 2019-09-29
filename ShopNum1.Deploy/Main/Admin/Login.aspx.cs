using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Login : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.ClientDomainCheck();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            DataTable userInfo = null;
            ShopNum1_OperateLog log;
            
            string loginID = TextBoxLoginID.Text.Trim().ToLower();
            string str2 = Common.Encryption.GetSHA1SecondHash(TextBoxPwd.Text.Trim());
         
            if (CheckLogin(loginID, str2) > 0)
            {
                userInfo = GetUserInfo(TextBoxLoginID.Text.Trim().ToLower());
                var cookie = new HttpCookie("AdminLoginCookie");
                Session["AdminLoginCookie"] = TextBoxLoginID.Text.Trim().ToLower();
                cookie.Values.Add("LoginID", TextBoxLoginID.Text.Trim().ToLower());
                cookie.Values.Add("Guid", userInfo.Rows[0]["Guid"].ToString());
                cookie.Values.Add("PeopleType", userInfo.Rows[0]["PeopleType"].ToString());
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                
                log = new ShopNum1_OperateLog
                    {
                        Record = "后台用户登陆系统成功",
                        OperatorID = TextBoxLoginID.Text.Trim().ToLower(),
                        IP = Globals.IPAddress,
                        PageName = "login.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
              
                var cookie3 = new HttpCookie("AdminLoginDateCookie");
                string str3 = string.Empty;
                str3 = Common.Common.GetNameById("LastLoginTime", "ShopNum1_User",
                                                 "   AND   LoginId='" + TextBoxLoginID.Text.Trim().ToLower() + "' ");
                if (string.IsNullOrEmpty(str3))
                {
                    str3 = DateTime.Now.ToString();
                }
          
                cookie3.Values.Add("LastLoginTime", str3);
                HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                cookie4.Expires = Convert.ToDateTime(DateTime.Now.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"));

                Page.Response.AppendCookie(cookie4);

                UpdateLoginInfo(TextBoxLoginID.Text.Trim().ToLower());

                base.Response.Redirect("Index.aspx");
            }
            else
            {
                Message.Text = "登录失败！";
                log = new ShopNum1_OperateLog
                    {
                        Record =
                            "用户" + TextBoxLoginID.Text.Trim().ToLower() + "尝试用错误密码" + TextBoxPwd.Text.Trim() +
                            "登陆系统,被拒绝!",
                        OperatorID = TextBoxLoginID.Text.Trim().ToLower(),
                        IP = Globals.IPAddress,
                        PageName = "login.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };

                base.OperateLog(log);
            }
        }

        protected int CheckLogin(string loginID, string string_4)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            return action.CheckLogin(loginID, string_4, 0);
        }

        protected DataTable GetUserInfo(string loginID)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            return action.GetUserByLoginID(loginID, 0);
        }

        private void UpdateLoginInfo(string loginId)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            var user = new ShopNum1_User
                {
                    LoginId = loginId,
                    LastLoginTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    LastLoginIP = Globals.IPAddress
                };
            action.UpdateLoginInfo(user);
        }
    }
}