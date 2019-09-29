using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.Main.Member
{
    /// <summary>
    /// M_OrderDetail 的摘要说明
    /// </summary>
    public class M_OrderDetail : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strOrderNumber = ShopNum1.Common.Common.ReqStr("ordernumber");
            string strShopId = ShopNum1.Common.Common.ReqStr("shoploginid");
            if (strOrderNumber != "" && strShopId != "")
            {
                var MemberMessage_Action = new ShopNum1_MemberMessage_Action();
                var MemberMessage = new ShopNum1_MemberMessage();
                MemberMessage.Title = "买家提醒卖家发货";
                MemberMessage.Content = "买家【" + GetMemLoginId() + "】已经付款的订单【" + strOrderNumber + "】等待您发货。";
                MemberMessage.SendLoginID = GetMemLoginId();
                MemberMessage.ReLoginID = strShopId;
                MemberMessage_Action.Add_MemberMsg(MemberMessage);
                context.Response.Write("ok");
            }
        }

        //获取登录用户方法

        public bool IsReusable
        {
            get { return false; }
        }

        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }
    }
}