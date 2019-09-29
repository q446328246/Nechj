using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PageHander.Main
{
    /// <summary>
    /// CheckAdminLogin 的摘要说明
    /// </summary>
    public class CheckAdminLogin : IHttpHandler
    {

        private string type;

        public void ProcessRequest(HttpContext context)
        {
            type = context.Request["type"];
            if (type == null)
            {
                return;
            }
            switch (type.ToLower().Trim())
            {
                //查询供求分类 
                case "checklogin":
                    string loginID = context.Request["loginID"].Trim();
                    string pwd = context.Request["pwd"].Trim();
                    string code = context.Request["code"].Trim();
                    context.Response.Write(CheckLogin(loginID, ShopNum1.Common.Encryption.GetSHA1SecondHash(pwd), code));
                    break;
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   判断用户名和密码是否正确
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        protected string CheckLogin(string loginID, string pwd, string code)
        {
            string verifycodetype = HttpContext.Current.Request.Cookies["AdminLoginVerifyCode"].Value;
            if (code != verifycodetype)
            {
                return "-2";
            }
            var userAction = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
            return userAction.CheckLogin(loginID, pwd, 0).ToString();
        }
    }
}