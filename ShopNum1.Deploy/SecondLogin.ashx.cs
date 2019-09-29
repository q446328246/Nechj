using System;
using System.Configuration;
using System.Data;
using System.Web;
using ShopNum1.Second;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// SecondLogin 的摘要说明
    /// </summary>
    public class SecondLogin : IHttpHandler
    {

        private string agenturl_0 = "";
        private string strAction = "";


        public void ProcessRequest(HttpContext context)
        {
            strAction = context.Request["type"];
            agenturl_0 = context.Request["agenturl"] == null ? "" : context.Request["agenturl"];
            if (strAction == null)
            {
                return;
            }

            //switch (strAction.ToLower())
            //{  
            //    case "secondlogin":
            //string strid = context.Request["SecondID"] = null ? "" : context.Request["SecondID"].ToString();

            string strid = context.Request["SecondID"] == null ? "" : context.Request["SecondID"];

            context.Response.Write(CheckSecondLogin(strid));
            // context.Response.
            //    default:
            //        break;
            //}
        }

        public string CheckSecondLogin(string strID)
        {
            string url = string.Empty;
            DataTable seconddataTable = null;
            var secondTypeAction = new ShopNum1_SecondTypeBussiness(); //第三方另外的项目此处没有经过工厂生成 
            switch (strID)
            {
                case "1":
                    //qq
                    seconddataTable = secondTypeAction.GetModel(1);
                    if (seconddataTable != null && seconddataTable.Rows.Count != 0)
                    {
                        url = ShopNum1_QzoneCommonClient.GetAuthorizationUrl(seconddataTable.Rows[0]["AppID"].ToString(),
                                                                             "http://" +
                                                                             ConfigurationManager.AppSettings["Domain"] +
                                                                             "/Main/Second/Qzone/QzoneReturn.aspx");
                        //return url;
                    }
                    break;
                case "2":
                    //百度
                    seconddataTable = secondTypeAction.GetModel(2);
                    if (seconddataTable != null && seconddataTable.Rows.Count != 0)
                    {
                        url =
                            (new ShopNum1_BaiduOAuthClient()).GetAuthorizationUrl(
                                seconddataTable.Rows[0]["AppID"].ToString(),
                                "http://" + ConfigurationManager.AppSettings["Domain"] +
                                "/Main/Second/Baidu/BaiduReturn.aspx");
                        //return url;
                    }

                    break;
                case "3":
                    //新浪
                    seconddataTable = secondTypeAction.GetModel(3);
                    if (seconddataTable != null && seconddataTable.Rows.Count != 0)
                    {
                        url =
                            (new ShopNum1_XinlanOAuthClient()).GetAuthorizationUrl(
                                seconddataTable.Rows[0]["AppID"].ToString(),
                                "http://" + ConfigurationManager.AppSettings["Domain"] +
                                "/Main/Second/Xinlan/XinlanReturn.aspx");
                        //return url;
                    }
                    break;
                case "4":
                    //支付宝 
                    var alipayconfig = new ShopNum1_Alipay_config();
                    //(new ShopNum1_AlipayOAuthClient(alipayconfig.Partner, alipayconfig.Return_url,"",alipayconfig.Key,alipayconfig.Input_charset,alipayconfig.Sign_type)).GetAuthorizationCode();
                    url = (new ShopNum1_AlipayOAuthClient(alipayconfig)).GetAuthorizationUrl();
                    //return url;
                    break;
                case "5":
                    //淘宝 
                    seconddataTable = secondTypeAction.GetModel(6);
                    url = (new ShopNum1_TaobaoOAuthClient()).GetAuthorizationUrl(
                        seconddataTable.Rows[0]["AppID"].ToString(),
                        "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Taobao/TaobaoReturn.aspx");
                    //return url;
                    break;
                default:
                    seconddataTable = secondTypeAction.GetModel(6);
                    url = (new ShopNum1_TaobaoOAuthClient()).GetAuthorizationUrl(
                        seconddataTable.Rows[0]["AppID"].ToString(),
                        "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Taobao/TaobaoReturn.aspx");
                    break;
            }
            return url;
        }

        #region IHttpHandler Members

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}