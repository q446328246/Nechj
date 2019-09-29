using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using QQWry.NET;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;

namespace ShopNum1.Deploy
{
    public class ShopNum1MultiHttpModule : IHttpModule
    {
        private QQWryLocator qqwryLocator_0 =
            new QQWryLocator(HttpContext.Current.Server.MapPath("~/App_Data/QQWry.Dat"));

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.Application_BeginRequest);
            context.PreSendRequestHeaders += new EventHandler(this.Application_PreSendRequestHeaders);
            context.EndRequest += new EventHandler(this.Application_EndRequest);
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string absoluteUrl = context.Request.Url.AbsoluteUri.ToLower();
            //AbsoluteUri 属性包括 Uri 实例中存储的整个 URI，包括所有的片段和查询字符串
            Regex regex =
                new Regex(
                    "^http://([a-z0-9-]{2,20}\\.)?([a-z0-9-]{1,40}\\.)?[a-z0-9-]{1,40}\\.[a-z]{2,3}(\\.[a-z]{2,3})?/(\\w{1,40}/)*(.{1,100}\\.(html|shtml|htm|aspx)(\\?.+)?)?$");

            string strHost = context.Request.Url.Host;
            string strPath = context.Request.Path;

            if (string.IsNullOrEmpty(ShopSettings.siteDomain))
            {
                context.RewritePath("~/Main/404.aspx");
            }
            else
            {
                string rawUrl = HttpContext.Current.Request.RawUrl.ToLower();
                //原始 URL 定义为 URL 中域信息之后的部分。在 URL 字符串 http://www.contoso.com/articles/recent.aspx 中，原始 URL 为 /articles/recent.aspx。原始 URL 包括查询字符串（如果存在）。
                if (rawUrl.EndsWith(".xml"))
                {
                    if (!rawUrl.Contains("/fckeditor"))
                    {
                        context.RewritePath("~/Main/404.aspx");
                    }
                }
                else
                {
                    if ("www." + HttpContext.Current.Request.Url.Host.ToLower() == ShopSettings.siteDomain.ToLower())
                    {
                        context.Response.Status = "301 Moved Permanently";
                        context.Response.AddHeader("Location", "http://" + ShopSettings.siteDomain);
                    }
                    string text3 = ShopSettings.siteDomain.Contains("http://")
                                       ? ShopSettings.siteDomain
                                       : ("http://" + ShopSettings.siteDomain);
                    string iPAddress = Globals.IPAddress;

                    if (absoluteUrl == text3 + "/default.aspx")
                    {
                        IPLocation iPLocation = this.qqwryLocator_0.Query(iPAddress);
                        object agentDomainByAddressName = this.GetAgentDomainByAddressName(iPLocation.Country);
                        if (agentDomainByAddressName == null)
                        {
                            context.RewritePath("~/Main/default.aspx");
                            return;
                        }
                        context.Response.Status = "301 Moved Permanently";
                        context.Response.AddHeader("Location", agentDomainByAddressName.ToString());
                    }
                    
                    

                    if (absoluteUrl.IndexOf("/install/install.aspx") == -1)
                    {
                        if (absoluteUrl.IndexOf("/404.aspx") != -1)
                        {
                            context.RewritePath("~/Main/404.aspx");
                        }
                        else
                        {
                            if (absoluteUrl.IndexOf("/imgupload/") != -1 || absoluteUrl.IndexOf("/upload/") != -1)
                            {
                                context.Response.Write("<script> window.alert(\"执行操作非法！\");  window.location.href='" +
                                                       GetPageName.RetUrl("default") + "'</script>");
                                context.Response.End();
                            }
                            else
                            {
                                string path = "~/Main/404.aspx";
                                if (text3.IndexOf("http://localhost") == -1 && regex.IsMatch(absoluteUrl) &&
                                    absoluteUrl.Split(new char[]
                                        {
                                            '/'
                                        }).Length < 6 && absoluteUrl.IndexOf("/main/") == -1 &&
                                    absoluteUrl.IndexOf("/admin/") == -1 && absoluteUrl.IndexOf("/fckeditor/") == -1 &&
                                    absoluteUrl.IndexOf("/api/") == -1 && absoluteUrl.IndexOf("/payreturn/") == -1 && absoluteUrl.IndexOf("/gzweixinpay/") == -1 )
                                {
                                    ShopNum1_PreventIp_Action shopNum1_PreventIp_Action =
                                        (ShopNum1_PreventIp_Action)LogicFactory.CreateShopNum1_PreventIp_Action();
                                    if (!shopNum1_PreventIp_Action.CheckedUser(iPAddress, "0"))
                                    {
                                        context.RewritePath("~/Main/404.aspx");
                                    }
                                    else
                                    {
                                        if (HttpContext.Current.Request.Url.Host ==
                                            ShopSettings.siteDomain.Replace("/", ""))
                                        {
                                            path = "~/Default.aspx";
                                        }
                                        bool arg_399_0;
                                        if (absoluteUrl.IndexOf(ShopSettings.siteDomain) != -1)
                                        {
                                            if (HttpContext.Current.Request.Url.Host.Split(new char[]
                                                {
                                                    '.'
                                                }).Length != 4)
                                            {
                                                arg_399_0 = true;
                                                goto IL_399;
                                            }
                                        }
                                        arg_399_0 = (absoluteUrl.IndexOf("http://www.") != -1);
                                    IL_399:
                                        if (!arg_399_0)
                                        {
                                            path = this.method_6(absoluteUrl);
                                        }
                                        else
                                        {
                                            if (absoluteUrl.IndexOf("http://www") != -1 ||
                                                absoluteUrl.IndexOf(ShopSettings.siteDomain) != -1)
                                            {
                                                path = this.method_5(absoluteUrl);
                                            }
                                        }
                                        context.RewritePath(path);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string method_5(string input)
        {
            input = input.Replace("http://", "");
            string host = HttpContext.Current.Request.Url.Host;
            input = input.Substring(input.IndexOf('/') + 1);
            if (input == "")
            {
                input = "default.aspx";
            }
            string result;
            if (host == ShopSettings.siteDomain)
            {
                string text2;
                if (input.IndexOf('/') != -1)
                {
                    string[] array = input.Split(new char[]
                        {
                            '/'
                        });
                    string text = array[0];
                    switch (text)
                    {
                        case "categorylist":
                            text2 = "~/Main/CategoryListSearch.aspx?code=" +
                                    array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "supplylist":
                            text2 = "~/Main/SupplyDemandListSearch.aspx?code=" +
                                    array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "productlist":
                            text2 = "~/Main/ProductListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "shoplist":
                            text2 = "~/Main/ShopListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "allarticle":
                            text2 = "~/Main/ArticleListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "articlelist":
                            text2 = "~/Main/ArticleListSearch.aspx?ID=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "allbrandlist":
                            text2 = "~/Main/AllBrandList.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "search_product":
                            text2 = "~/Main/search_product.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
                            goto IL_2DC;
                        case "gzweixinpay":
                            text2 = "~/gzweixinpay/WxPayNotify.aspx";
                            goto IL_2DC;
                        case "kceservice":
                            text2 = "~/kceservice/KceApi.asmx";
                            goto IL_2DC;
                    }
                    text2 = "~/Main/" + array[0] + ".aspx?guid=" + array[1].Substring(0, array[1].IndexOf('.'));
                }
                else
                {
                    string str = input.Substring(0, input.IndexOf('.'));
                    text2 = "~/Main/" + str + ".aspx";
                    if (input.IndexOf('?') != -1)
                    {
                        text2 = text2 + "?" + input.Substring(input.IndexOf('?') + 1);
                    }
                }
            IL_2DC:
                result = text2;
            }
            else
            {
                DataTable dataTable = this.UrlWriteDoMain(host);
                //if (dataTable != null && dataTable.Rows.Count > 0)
                //{
                string text3 = dataTable.Rows[0]["ShopID"].ToString();
                string text4 = dataTable.Rows[0]["MemberType"].ToString();
                string s = dataTable.Rows[0]["OpenTime"].ToString();
                string text = text4;
                if (text != null && text == "1")
                {
                    result = "~/Main/404.aspx";
                }
                else
                {
                    string text2 = "~/Shop/Shop/";
                    string text5 = text2;
                    text2 = string.Concat(new string[]
                            {
                                text5,
                                DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
                                "/",
                                ShopSettings.GetValue("PersonShopUrl"),
                                text3,
                                "/"
                            });
                    if (input.IndexOf('/') != -1)
                    {
                        string[] array = input.Split(new char[]
                                {
                                    '/'
                                });
                        text = array[0];
                        if (text != null && text == "")
                        {
                            text2 = "";
                        }
                        else
                        {
                            text5 = text2;
                            text2 = string.Concat(new string[]
                                    {
                                        text5,
                                        array[0],
                                        ".aspx?guid=",
                                        array[1].Substring(0, array[1].IndexOf('.')),
                                        "&ShopID=",
                                        text3
                                    });
                        }
                    }
                    else
                    {
                        string str = input.Substring(0, input.IndexOf('.'));
                        text2 = text2 + str + ".aspx?ShopID=" + text3;
                        if (input.IndexOf('?') != -1)
                        {
                            text2 = text2 + "&" + input.Substring(input.IndexOf('?') + 1);
                        }
                    }
                    result = text2;
                }
                //}
                //else
                //{
                //    result = "~/Main/NoPowerDomain.aspx";
                //}
            }
            return result;
        }

        //根据URL获取对应店铺
        private string method_6(string input)
        {
            input = input.Replace("http://", "");
            input = input.Substring(input.IndexOf('/') + 1);
            if (input == "")
            {
                input = "default.aspx";
            }
            string string_ = HttpContext.Current.Request.Url.Host.Split(new char[]
                {
                    '.'
                })[0];
            //string_ = string_ + ".bb";
            DataTable dataTable = this.method_7(string_);
            string result;
            string text2;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int num = Convert.ToInt32(dataTable.Rows[0]["IsExpires"]);
                int num2 = Convert.ToInt32(dataTable.Rows[0]["IsClose"]);
                string s = dataTable.Rows[0]["OpenTime"].ToString();
                string text = dataTable.Rows[0]["ShopID"].ToString();
                if (num2 == 1 || num == 1)
                {
                    result = "~/main/ShopError.aspx";
                    return result;
                }
                text2 = "~/Shop/Shop/";
                string text3 = text2;
                text2 = string.Concat(new string[]
                    {
                        text3,
                        DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
                        "/",
                        ShopSettings.GetValue("PersonShopUrl"),
                        text,
                        "/"
                    });
                string text4 = string.Concat(new string[]
                    {
                        "~/Shop/Shop/",
                        DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
                        "/",
                        ShopSettings.GetValue("PersonShopUrl"),
                        text
                    });
                string path = HttpContext.Current.Server.MapPath(text4);
                if (!Directory.Exists(path))
                {
                    result = "~/main/ShopNegation.aspx";
                    return result;
                }
                string path2 = text4 + "/Themes/Skin_Default/Style";
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(path2)))
                {
                    result = "~/main/ShopNegation.aspx";
                    return result;
                }
                if (input.IndexOf('/') != -1)
                {
                    string[] array = input.Split(new char[]
                        {
                            '/'
                        });
                    string text5 = array[0];
                    if (text5 != null && text5 == "")
                    {
                        text2 = "";
                    }
                    else
                    {
                        text3 = text2;
                        text2 = string.Concat(new string[]
                            {
                                text3,
                                array[0],
                                ".aspx?guid=",
                                array[1].Substring(0, array[1].IndexOf('.')),
                                "&ShopID=",
                                text
                            });
                        if (input.IndexOf('?') != -1)
                        {
                            text2 = text2 + "&" + input.Substring(input.IndexOf('?') + 1);
                        }
                    }
                }
                else
                {
                    string str = input.Substring(0, input.IndexOf('.'));
                    text2 = text2 + str + ".aspx?ShopID=" + text;
                    if (input.IndexOf('?') != -1)
                    {
                        text2 = text2 + "&" + input.Substring(input.IndexOf('?') + 1);
                    }
                }
            }
            else
            {
                text2 = "~/Main/ShopNegation.aspx";
            }
            result = text2;
            return result;
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {

        }

        private void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            try
            {
                HttpApplication httpApplication = sender as HttpApplication;
                if (httpApplication != null && httpApplication.Request != null && httpApplication.Context != null &&
                    null != httpApplication.Context.Response)
                {
                    NameValueCollection headers = httpApplication.Context.Response.Headers;
                    if (null != headers)
                    {
                        headers.Remove("Server");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void method_2(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string url = "~/404.aspx";
            if (context.Request.QueryString != null)
            {
                for (int i = 0; i < context.Request.QueryString.Count; i++)
                {
                    string text = context.Request.QueryString.Keys[i];
                    string text2 = context.Request.QueryString[text];
                    if (!this.method_3(text2) && text2.Length < 150)
                    {
                        context.Response.Redirect(url);
                        context.Response.End();
                        break;
                    }
                }
            }
            if (context.Request.Form != null)
            {
                for (int i = 0; i < context.Request.Form.Count; i++)
                {
                    string text = context.Request.Form.Keys[i];
                    string text2 = context.Request.Form[i];
                    if (!(text == "__VIEWSTATE") && (!this.method_3(text2) && text2.Length < 300))
                    {
                        context.Response.Redirect(url);
                        context.Response.End();
                        break;
                    }
                }
            }
        }

        private bool method_3(string input)
        {
            bool result = true;
            if (input.Trim() != "")
            {
                string text = ConfigurationManager.AppSettings["SQLChar"].ToString();
                string[] array = text.Split(new char[]
                    {
                        '|'
                    });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string value = array2[i];
                    if (input.ToLower().IndexOf(value) >= 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private DataTable method_7(string input)
        {
            string[] array = new string[1];
            string[] array2 = new string[1];
            array[0] = "@ShopUrl";
            array2[0] = input;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShop", array, array2);
        }

        public DataTable UrlWriteDoMain(string domain)
        {
            string[] array = new string[1];
            string[] array2 = new string[1];
            array[0] = "@domain";
            array2[0] = domain;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", array, array2);
        }

        public object GetAgentDomainByAddressName(string address)
        {
            string[] array = new string[1];
            string[] array2 = new string[1];
            array[0] = "@addressname";
            array2[0] = address;
            return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteGetDomainByAddress", array, array2);
        }
    }
}