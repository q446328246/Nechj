using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main
{
    public partial class Check : Page, IRequiresSessionState
    {
        private readonly string string_0 = ConfigurationManager.AppSettings["Domain"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request["guid"] != null)
            {
                string g = Page.Request["guid"];
                try
                {
                    var guid = new Guid(g);
                    if (MemberLogin())
                    {
                        base.Response.Redirect("http://" + string_0 +
                                               "/shop/shopadmin/s_index.aspx?shopurl=Order_Detail.aspx?guid=" + g);
                    }
                    else
                    {
                        base.Response.Write("登录失败！");
                    }
                }
                catch (Exception)
                {
                    base.Response.Write("验证失败！");
                }
            }
            else if (MemberLogin())
            {
                base.Response.Redirect("http://" + string_0 + "/shop/shopadmin/s_index.aspx");
            }
            else
            {
                base.Response.Write("登录失败！");
            }
        }

         public string getpwd(string loginid)
        {
            string str = null;
            var builder = new StringBuilder();
            builder.Append("Select Pwd from ShopNum1_Member where MemLoginId='");
            builder.Append(loginid + "'");
            using (var connection = new SqlConnection(DatabaseExcetue.GetConnstring()))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = builder.ToString();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        str = reader["Pwd"].ToString();
                    }
                }
            }
            return str;
        }

        public bool MemberLogin()
        {
            bool flag = false;
            string loginid = base.Request["MemLoginId"];
            string str2 = base.Request["checksign"];
            string str3 = getpwd(loginid).ToLower();
            string str4 = ShopNum1.Common.Encryption.GetMd5Hash(loginid + str3 + "123456");
            if (str2 == str4)
            {
                DataTable memberPassWord =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemberPassWord(loginid, str3);
                var cookie = new HttpCookie("MemberLoginCookie");
                cookie.Values.Add("MemLoginID", loginid);
                cookie.Values.Add("Name", memberPassWord.Rows[0]["Name"].ToString());
                cookie.Values.Add("IsMailActivation", memberPassWord.Rows[0]["IsMailActivation"].ToString());
                cookie.Values.Add("MemberType", memberPassWord.Rows[0]["MemberType"].ToString());
                cookie.Values.Add("UID", "-1");
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                base.Response.AppendCookie(cookie2);
            }
            if (base.Request.Cookies["MemberLoginCookie"] != null)
            {
                flag = true;
            }
            return flag;
        }


    }
}