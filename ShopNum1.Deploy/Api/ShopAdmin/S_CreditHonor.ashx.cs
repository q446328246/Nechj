using System;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_CreditHonor 的摘要说明
    /// </summary>
    public class S_CreditHonor : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (ShopNum1.Common.Common.ReqStr("type") == "sendReply")
            {
                string strbuyer = ShopNum1.Common.Common.ReqStr("buyerc");
                string strpguid = ShopNum1.Common.Common.ReqStr("pguid");
                string strreply = ShopNum1.Common.Common.ReqStr("reply");
                var ProductComment_Action =
                    (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
                ProductComment_Action.UpdateComment(strpguid, strreply, DateTime.Now.ToString(), strbuyer);
                context.Response.Write("ok");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}