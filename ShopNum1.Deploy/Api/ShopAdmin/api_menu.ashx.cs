using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using ShopNum1.Common;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinCommon;
using ShopNum1.WeiXinCommon.Enum;
using ShopNum1.WeiXinCommon.model;
using ShopNum1.WeiXinInterface;


namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// api_menu 的摘要说明
    /// </summary>
    public class api_menu : IHttpHandler
    {

        private string api_create = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
        private string api_delete = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
        private string api_get = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"] ?? string.Empty;
            string shopmemloginid = GetMemLoginId(context);

            //登录验证
            if (string.IsNullOrEmpty(shopmemloginid))
            {
                context.Response.Write("{\"errcode\":-2,\"errmsg\":\"无用户登录!\"}");
                return;
            }

            switch (type.ToLower())
            {
                case "menu_add":
                    string menu_json = context.Request.QueryString["menu_json"] ?? string.Empty;
                    List<MenuButton> menus = StringHelper.ReturnListFromJson<MenuButton>(menu_json);

                    //屏蔽关键字
                    foreach (MenuButton menu in menus)
                    {
                        menu.Name = Operator.FilterString(menu.Name);
                        menu.Value = Operator.FilterString(menu.Value);

                        foreach (MenuButton item in menu.SubButton)
                        {
                            item.Name = Operator.FilterString(item.Name);
                            item.Value = Operator.FilterString(item.Value);
                        }
                    }

                    IShopNum1_Weixin_ShopMenu_Active shopnum1_weixin_shopmenu_active = new ShopNum1_Weixin_ShopMenu_Active();
                    if (shopnum1_weixin_shopmenu_active.Add_Menu(menus, shopmemloginid))
                    {
                        context.Response.Write("{\"errcode\":0,\"errmsg\":\"保存成功!\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"保存失败!\"}");
                    }

                    break;

                case "menu_create":
                    context.Response.Write(MenuOperating(MenuType.create, shopmemloginid));
                    break;
                case "menu_close":
                    context.Response.Write(MenuOperating(MenuType.delete, shopmemloginid));
                    break;
            }
        }

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

        /// <summary>
        ///   自定义菜单操作
        /// </summary>
        /// <param name="menutype"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string MenuOperating(MenuType menutype, string shopmemloginid)
        {
            //自定义菜单接口
            string posturl = string.Empty;
            //请求方式
            //string method = "POST";
            //微信接口Access_token
            string access_token = GetAccess_token(shopmemloginid);


            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            string content = string.Empty;
            switch (menutype)
            {
                case MenuType.create:
                    posturl = string.Format(api_create, access_token);

                    byte[] data = encoding.GetBytes(Get_MenuJson(shopmemloginid));
                    // 准备请求...
                    try
                    {
                        // 设置参数
                        request = WebRequest.Create(posturl) as HttpWebRequest;
                        var cookieContainer = new CookieContainer();
                        request.CookieContainer = cookieContainer;
                        request.AllowAutoRedirect = true;
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = data.Length;
                        outstream = request.GetRequestStream();
                        outstream.Write(data, 0, data.Length);
                        outstream.Close();
                        //发送请求并获取相应回应数据
                        response = request.GetResponse() as HttpWebResponse;
                        //直到request.GetResponse()程序才开始向目标网页发送Post请求
                        instream = response.GetResponseStream();
                        sr = new StreamReader(instream, encoding);
                        //返回结果网页（html）代码
                        content = sr.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        return "{\"errcode\":-2,\"errmsg\":\"" + ex.Message + "\"}";
                    }
                    break;
                case MenuType.get:
                    try
                    {
                        posturl = string.Format(api_get, access_token);

                        request = WebRequest.Create(posturl) as HttpWebRequest;
                        request.Method = "GET";
                        response = (HttpWebResponse)request.GetResponse();
                        sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        content = sr.ReadToEnd();
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        return "{\"errcode\":-2,\"errmsg\":\"" + ex.Message + "\"}";
                    }

                    break;
                case MenuType.delete:
                    posturl = string.Format(api_delete, access_token);
                    try
                    {
                        request = WebRequest.Create(posturl) as HttpWebRequest;
                        request.Method = "GET";
                        response = (HttpWebResponse)request.GetResponse();
                        sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        content = sr.ReadToEnd();
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        return "{\"errcode\":-2,\"errmsg\":\"" + ex.Message + "\"}";
                    }
                    break;
            }

            return content;
        }

        /// <summary>
        ///   获取微信接口Access_token
        /// </summary>
        /// <returns></returns>
        private string GetAccess_token(string shopmemloginid)
        {
            //查询店铺 Token
            IShopNum1_Weixin_ShopWeiXinConfig_Active shopnum1_weixin_shopweixinconfig_active =
                new ShopNum1_Weixin_ShopWeiXinConfig_Active();
            DataTable dt = shopnum1_weixin_shopweixinconfig_active.GetWeixinConfig(shopmemloginid);

            //微信接口AppId
            string appid = dt.Rows[0]["AppId"].ToString();
            //微信接口AppSecret
            string secret = dt.Rows[0]["AppSecret"].ToString();
            ;

            string url =
                string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",
                              appid, secret);

            var myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            var myResponse = (HttpWebResponse)myRequest.GetResponse();
            var reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content.Split(',')[0].Split(':')[1].Replace("\"", "");
        }


        /// <summary>
        ///   获取微信接口Access_token
        /// </summary>
        /// <returns></returns>
        private string GetAccess_tokenShow(string shopmemloginid)
        {
            //查询店铺 Token
            IShopNum1_Weixin_ShopWeiXinConfig_Active shopnum1_weixin_shopweixinconfig_active =
                new ShopNum1_Weixin_ShopWeiXinConfig_Active();
            DataTable dt = shopnum1_weixin_shopweixinconfig_active.GetWeixinConfig(shopmemloginid);
            return dt.Rows[0]["Token"].ToString();
        }

        public string Get_MenuJson(string shopmemloginid)
        {
            IShopNum1_Weixin_ShopMenu_Active shopnum1_weixin_shopmenu_active = new ShopNum1_Weixin_ShopMenu_Active();
            DataTable menu_dt = shopnum1_weixin_shopmenu_active.Select_AllMenu(shopmemloginid);

            var menu_list = new List<MenuButton>();
            MenuButton menu;
            MenuButton menu_chirld;
            foreach (DataRow dr in menu_dt.Select("pid = '0'"))
            {
                menu = new MenuButton();
                menu.Name = dr["name"].ToString();
                menu.Value = dr["Value"].ToString();

                foreach (DataRow childmenu in menu_dt.Select(string.Format("pid = '{0}'", dr["id"])))
                {
                    menu_chirld = new MenuButton();
                    menu_chirld.Name = childmenu["name"].ToString();
                    menu_chirld.Value = childmenu["Value"].ToString();
                    menu.SubButton.Add(menu_chirld);
                }
                menu_list.Add(menu);
            }
            return ButtonStr(menu_list);
        }

        // <summary>
        /// 拼接自定义菜单Json
        /// </summary>
        /// <param name="menubutton"></param>
        /// <returns></returns>
        private string ButtonStr(List<MenuButton> menubutton)
        {
            var menuStr = new StringBuilder();
            menuStr.Append("{\"button\":[");

            for (int nI = 0; nI < menubutton.Count; nI++)
            {
                if (nI != 0)
                    menuStr.Append(",");

                if (menubutton[nI].SubButton.Count == 0)
                {
                    if (menubutton[nI].Value.IndexOf("http://") == 0)
                        menuStr.Append("{\"type\":\"view\",\"name\":\"" + menubutton[nI].Name + "\",\"url\":\"" +
                                       menubutton[nI].Value + "\"}");
                    else
                        menuStr.Append("{\"type\":\"click\",\"name\":\"" + menubutton[nI].Name + "\",\"key\":\"" +
                                       menubutton[nI].Value + "\"}");
                }
                else
                {
                    menuStr.Append("{\"name\":\"" + menubutton[nI].Name + "\",\"sub_button\":[");

                    for (int nJ = 0; nJ < menubutton[nI].SubButton.Count; nJ++)
                    {
                        if (nJ != 0)
                            menuStr.Append(",");

                        if (menubutton[nI].SubButton[nJ].Value.IndexOf("http://") == 0)
                            menuStr.Append("{\"type\":\"view\",\"name\":\"" + menubutton[nI].SubButton[nJ].Name +
                                           "\",\"url\":\"" + menubutton[nI].SubButton[nJ].Value + "\"}");
                        else
                            menuStr.Append("{\"type\":\"click\",\"name\":\"" + menubutton[nI].SubButton[nJ].Name +
                                           "\",\"key\":\"" + menubutton[nI].SubButton[nJ].Value + "\"}");
                    }


                    menuStr.Append("]}");
                }
            }
            menuStr.Append("]}");
            return menuStr.ToString();
        }
    }
}