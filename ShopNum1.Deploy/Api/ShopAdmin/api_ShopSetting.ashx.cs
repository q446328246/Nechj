using System;
using System.Collections.Generic;
using System.Web;
using ShopNum1.Common;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinCommon.Enum;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// api_ShopSetting 的摘要说明
    /// </summary>
    public class api_ShopSetting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"] ?? string.Empty;

            string shopnumloginid = GetMemLoginId(context);

            //登录验证
            if (string.IsNullOrEmpty(shopnumloginid))
            {
                context.Response.Write("{\"errcode\":-1,\"errmsg\":\"无用户登录!\"}");
                return;
            }

            ShopNum1_Weixin_ShopWeiXinConfig weixinconfig;
            IShopNum1_Weixin_ShopWeiXinConfig_Active shopnum1_weixin_shopweixinconfig_active =
                new ShopNum1_Weixin_ShopWeiXinConfig_Active();

            switch (type.ToLower())
            {
                case "shop_apiconfig":
                    weixinconfig = new ShopNum1_Weixin_ShopWeiXinConfig();
                    weixinconfig.ShopMemLoginId = shopnumloginid;
                    weixinconfig.TokenURL = context.Request.QueryString["tokenurl"] ?? string.Empty;
                    weixinconfig.TokenURL =
                        weixinconfig.TokenURL.Replace(
                            string.Format(string.Format("http://{0}/api/shopadmin/api_weixin.ashx?shopowner=",
                                                        HttpContext.Current.Request.Url.Host)), "");
                    weixinconfig.Token = Operator.FilterString(context.Request.QueryString["token"] ?? string.Empty);
                    weixinconfig.AppId = Operator.FilterString(context.Request.QueryString["appid"] ?? string.Empty);
                    weixinconfig.AppSecret = Operator.FilterString(context.Request.QueryString["appsecret"] ?? string.Empty);

                    if (shopnum1_weixin_shopweixinconfig_active.Add_TokenApp(weixinconfig))
                    {
                        context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
                    }
                    break;

                case "shop_defaultsetting":
                    weixinconfig = new ShopNum1_Weixin_ShopWeiXinConfig();
                    weixinconfig.ShopMemLoginId = shopnumloginid;
                    weixinconfig.AttenRepKeys =
                        Operator.FilterString(context.Request.QueryString["attenrepkeys"] ?? string.Empty);
                    weixinconfig.NotFindKeys =
                        Operator.FilterString(context.Request.QueryString["notfindkeys"] ?? string.Empty);
                    weixinconfig.IsOpenAtten = Convert.ToBoolean(context.Request.QueryString["isopenatten"] ?? "true");
                    weixinconfig.IsOpenNotFindKey =
                        Convert.ToBoolean(context.Request.QueryString["isopennotfindkey"] ?? "true");

                    if (shopnum1_weixin_shopweixinconfig_active.Add_DefaultSetting(weixinconfig))
                    {
                        context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
                    }
                    break;

                case "shop_configop":

                    string weixin = Operator.FilterString(context.Request.QueryString["weixin"] ?? string.Empty);
                    string mobile = Operator.FilterString(context.Request.QueryString["mobile"] ?? string.Empty);
                    string logo = context.Request.QueryString["logo"] ?? string.Empty;
                    string flash = context.Request.QueryString["flash"] ?? string.Empty;
                    string flashurl = context.Request.QueryString["flashurl"] ?? string.Empty;
                    string shopid = ShopNum1.Common.Common.GetNameById("ShopId", "shopnum1_shopinfo",
                                                       string.Format(" and memloginid='{0}'", shopnumloginid));

                    var configlist = new List<ShopNum1_Weixin_ShopConfig>();

                    //logo
                    var shopconfig = new ShopNum1_Weixin_ShopConfig();
                    shopconfig.ShopID = Convert.ToInt32(shopid);
                    shopconfig.Value = logo;
                    shopconfig.ConfigType = Convert.ToByte((int)ConfigType.logo);
                    configlist.Add(shopconfig);

                    //weixin
                    shopconfig = new ShopNum1_Weixin_ShopConfig();
                    shopconfig.ShopID = Convert.ToInt32(shopid);
                    shopconfig.Value = weixin;
                    shopconfig.ConfigType = Convert.ToByte((int)ConfigType.weixin);
                    configlist.Add(shopconfig);

                    //mobile
                    shopconfig = new ShopNum1_Weixin_ShopConfig();
                    shopconfig.ShopID = Convert.ToInt32(shopid);
                    shopconfig.Value = mobile;
                    shopconfig.ConfigType = Convert.ToByte((int)ConfigType.mobile);
                    configlist.Add(shopconfig);


                    string[] ImgSrc = flash.Split(',');
                    string[] ImgUrl = flashurl.Split(',');
                    for (int nI = 0; nI < ImgSrc.Length; nI++)
                    {
                        if (!string.IsNullOrEmpty(ImgSrc[nI]))
                        {
                            shopconfig = new ShopNum1_Weixin_ShopConfig();
                            shopconfig.ShopID = Convert.ToInt32(shopid);
                            shopconfig.Value = ImgSrc[nI];
                            shopconfig.Url = ImgUrl[nI];
                            shopconfig.ConfigType = Convert.ToByte((int)ConfigType.flash);
                            configlist.Add(shopconfig);
                        }
                    }


                    IShopNum1_Weixin_ShopConfig_Active shopconfig_active = new ShopNum1_Weixin_ShopConfig_Active();

                    if (shopconfig_active.Add(configlist, shopid))
                    {
                        context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
                    }
                    break;
            }
        }

        //获取登录用户方法

        public bool IsReusable
        {
            get { return false; }
        }

        private string GetMemLoginId(HttpContext context)
        {
            string name = string.Empty;
            HttpCookie cookies = context.Request.Cookies["MemberLoginCookie"];
            if (cookies != null)
            {
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookies);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }
    }
}