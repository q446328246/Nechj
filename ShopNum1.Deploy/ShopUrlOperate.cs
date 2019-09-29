using System;
using System.Data;
using System.Web;
using QQWry.NET;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.Interface;

public static class ShopUrlOperate
{
    private static readonly IShopNum1_ShopInfoList_Action ishopNum1_ShopInfoList_Action_0 =
        LogicFactory.CreateShopNum1_ShopInfoList_Action();

    public static string GetDeShopUrl(string ShopCode)
    {
        string shopURLByShopCode = GetShopURLByShopCode(ShopCode);
        ShopCode = ShopCode.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (shopURLByShopCode == "")
        {
            return "javascript:void(0)";
        }
        return ("http://" + shopURLByShopCode + str2);
    }

    public static string GetOverrideUrlName()
    {
        if (ShopSettings.IsOverrideUrl)
        {
            return ShopSettings.overrideUrlName;
        }
        return ".aspx";
    }

    public static string GetRedirectProductDetailByShopUrl(string Guid, string ShopUrl, string isSpell, string isPanic)
    {
        string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            if (isSpell == "1")
            {
                return ("http://" + ShopUrl + str + "/ProductIsSpell_Detail/" + Guid + ShopSettings.overrideUrlName);
            }
            if (isPanic == "1")
            {
                return ("http://" + ShopUrl + str + "/ProductIsPanic_Detail/" + Guid + ShopSettings.overrideUrlName);
            }
            return ("http://" + ShopUrl + str + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName);
        }
        if (isSpell == "1")
        {
            return ("http://" + ShopUrl + str + "/ProductIsSpell_Detail/" + Guid + ".aspx");
        }
        if (isPanic == "1")
        {
            return ("http://" + ShopUrl + str + "/ProductIsPanic_Detail/" + Guid + ".aspx");
        }
        return ("http://" + ShopUrl + str + "/ProductDetail/" + Guid + ".aspx");
    }

    public static string GetShopCommentUrl(string ShopID)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str2 + "/ShopComment" + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopURLByShopID + str2 + "/ShopComment.aspx");
    }

    public static string GetShopDomainByUrl(string shopUrl)
    {
        string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopUrl + str);
        }
        return ("http://" + shopUrl + str);
    }

    public static string GetShopLoginGoBack()
    {
        string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
        string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
        return ("http://" + ShopSettings.siteDomain + "/Login" + str + "?goback=" +
                HttpContext.Current.Server.UrlEncode(s));
    }

    public static string GetShopMessageBoardUrl(string ShopID)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str2 + "/ShopMessageBoard" + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopURLByShopID + str2 + "/ShopMessageBoard.aspx");
    }

    public static string GetShopPath()
    {
        string[] strArray;
        string[] strArray2;
        string str5;
        string str6;
        string str7;
        string host = HttpContext.Current.Request.Url.Host;
        string str2 = host.Split(new[] {'.'})[0];
        string str3 = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
        string str4 = string.Empty;
        if (str3.IndexOf("http://www") == -1)
        {
            strArray = new string[1];
            strArray2 = new string[1];
            strArray[0] = "@ShopUrl";
            strArray2[0] = str2;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShop", strArray,
                                                                          strArray2);
            if ((table != null) && (table.Rows.Count > 0))
            {
                str5 = table.Rows[0]["OpenTime"].ToString();
                str6 = table.Rows[0]["ShopID"].ToString();
                str4 = "~/Shop/Shop/";
                str7 = str4;
                str4 = str7 + DateTime.Parse(str5).ToString("yyyy-MM-dd").Replace('-', '/') + "/" +
                       ShopSettings.GetValue("PersonShopUrl") + str6 + "/";
            }
            return str4;
        }
        strArray = new string[1];
        strArray2 = new string[1];
        strArray[0] = "@domain";
        strArray2[0] = host;
        DataTable table2 = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", strArray,
                                                                       strArray2);
        if ((table2 != null) && (table2.Rows.Count > 0))
        {
            str6 = table2.Rows[0]["ShopID"].ToString();
            str5 = table2.Rows[0]["OpenTime"].ToString();
            str4 = "~/Shop/Shop/";
            str7 = str4;
            str4 = str7 + DateTime.Parse(str5).ToString("yyyy-MM-dd").Replace('-', '/') + "/" +
                   ShopSettings.GetValue("PersonShopUrl") + str6 + "/";
        }
        return str4;
    }

    public static string GetShopProductHref(string Guid, string shopurl)
    {
        string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopurl + str + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopurl + str + "/ProductDetail/" + Guid + ".aspx");
    }

    public static string GetShopProductImgByUrl(string imgurl, string shopurl)
    {
        if ((imgurl == string.Empty) || (imgurl == null))
        {
            return "";
        }
        string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        return ("http://" + shopurl + str + "/" + imgurl.Substring(1));
    }

    public static object GetShopUrl(object object_0)
    {
        throw new NotImplementedException();
    }

    public static string GetShopUrl(string ShopID)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        ShopID = ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        return ("http://" + shopURLByShopID + str2);
    }
    public static string GetShopUrlcenter(string ShopID,string shop_category_id)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        ShopID = ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        return ("http://" + shopURLByShopID + str2 + "?category=" + shop_category_id);
    }

    public static string GetShopUrl(string ShopID, string string_0)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str2 + "/" + string_0 + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopURLByShopID + str2 + "/" + string_0 + ".aspx");
    }

    public static string GetShopURLByShopCode(string shopCode)
    {
        shopCode = shopCode.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
        return ishopNum1_ShopInfoList_Action_0.GetShopURLByAddressCode(shopCode);
    }

    public static string GetShopURLByShopID(string shopID)
    {
        shopID = shopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
        return ishopNum1_ShopInfoList_Action_0.GetShopURLByShopID(shopID);
    }

    public static string GetSiteDomain()
    {
        return ("http://" + ShopSettings.siteDomain);
    }

    public static string GetUserCity()
    {
        var locator = new QQWryLocator(HttpContext.Current.Server.MapPath("~/App_Data/QQWry.Dat"));
        string iPAddress = Globals.IPAddress;
        return locator.Query(iPAddress).Country;
    }

    public static string ProductSearch(string search, object name)
    {
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + ShopSettings.siteDomain + "/Search_productlist" + ShopSettings.overrideUrlName +
                    "?Search=" + search + "&Name=" + name);
        }
        return ("http://" + ShopSettings.siteDomain + "/Search_productlist.aspx?Search=" + search + "&Name=" + name);
    }

    public static string RedirectProductDetailByMemloginID(string Guid, string memloginId, string isSpell,
                                                           string isPanic)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(memloginId);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            if (isSpell == "1")
            {
                return ("http://" + str + str2 + "/ProductIsSpell_Detail/" + Guid + ShopSettings.overrideUrlName);
            }
            if (isPanic == "1")
            {
                return ("http://" + str + str2 + "/ProductIsPanic_Detail/" + Guid + ShopSettings.overrideUrlName);
            }
            return ("http://" + str + str2 + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName);
        }
        if (isSpell == "1")
        {
            return ("http://" + str + str2 + "/ProductIsSpell_Detail/" + Guid + ".aspx");
        }
        if (isPanic == "1")
        {
            return ("http://" + str + str2 + "/ProductIsPanic_Detail/" + Guid + ".aspx");
        }
        return ("http://" + str + str2 + "/ProductDetail/" + Guid + ".aspx");
    }

    public static string RedirectProductDetailByShopID(string Guid, string ShopID, string isSpell, string isPanic)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            if (isSpell == "1")
            {
                return ("http://" + shopURLByShopID + str2 + "/ProductIsSpell_Detail/" + Guid +
                        ShopSettings.overrideUrlName);
            }
            if (isPanic == "1")
            {
                return ("http://" + shopURLByShopID + str2 + "/ProductIsPanic_Detail/" + Guid +
                        ShopSettings.overrideUrlName);
            }
            return ("http://" + shopURLByShopID + str2 + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName);
        }
        if (isSpell == "1")
        {
            return ("http://" + shopURLByShopID + str2 + "/ProductIsSpell_Detail/" + Guid + ".aspx");
        }
        if (isPanic == "1")
        {
            return ("http://" + shopURLByShopID + str2 + "/ProductIsPanic_Detail/" + Guid + ".aspx");
        }
        return ("http://" + shopURLByShopID + str2 + "/ProductDetail/" + Guid + ".aspx");
    }

    public static string RetMemberUrl(string pagename)
    {
        return ("http://" + ShopSettings.siteDomain + "/main/Member/" + pagename + ".aspx");
    }

    public static string RetMultiUrl(string pagename, object pvalue)
    {
        string str = "http://" + ShopSettings.siteDomain + "/" + pagename +
                     (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
        if (pvalue != null)
        {
            str = str + "?" + pvalue;
        }
        return str;
    }

    public static string RetShopadminUrl(string pagename)
    {
        return ("http://" + ShopSettings.siteDomain + "/shop/shopadmin/" + pagename + ".aspx");
    }

    public static string RetShopUrl(string pagename)
    {
        return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + ShopSettings.overrideUrlName);
    }

    public static string RetShopUrl(string pagename, object value)
    {
        return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + "/" + value +
                ShopSettings.overrideUrlName);
    }

    public static string RetShopUrl(string pagename, object value, string args)
    {
        return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + ShopSettings.overrideUrlName + "?" +
                args + "=" + value);
    }

    public static string RetShopUrlcenter(string pagename, object value, string args,int category)
    {
        return ("http://" + HttpContext.Current.Request.Url.Host + "/" + pagename + ShopSettings.overrideUrlName + "?" +
                args + "=" + value + "&category="+category);
    }

    public static string RetUrl(string pagename)
    {
        return ("http://" + ShopSettings.siteDomain + "/" + pagename +
                (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"));
    }
    public static string RetUrlcenter(string pagename, object value,string category)
    {
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ShopSettings.overrideUrlName + "?category=" + category);
        }
        return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ".aspx?category=" + category);
    }

    public static string RetUrl(string pagename, object value)
    {
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ShopSettings.overrideUrlName);
        }
        return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ".aspx");
    }

    public static string RetUrl(string pagename, object value, string args)
    {
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ShopSettings.overrideUrlName);
        }
        return ("http://" + ShopSettings.siteDomain + "/" + pagename + "/" + value + ".aspx");
    }

    public static string RetUrl(string pagename, string value, string args)
    {

        string str = "http://" + ShopSettings.siteDomain + "/" + pagename +
                     (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
        if (args != null)
        {
            string str3 = str;
            str = str3 + "?" + args + "=" + value;
        }
        return str;
    }
 

    public static string RetUrlAspx(string pagename)
    {
        return ("http://" + ShopSettings.siteDomain + "/" + pagename);
    }

    public static string RetUrlForSearch(string pagename, string value, string args)
    {
        string str = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.AbsolutePath;
        string query = HttpContext.Current.Request.Url.Query;
        if (string.IsNullOrEmpty(query))
        {
            str = str + string.Format("?{0}={1}", args, value);
        }
        else
        {
            string str3 = string.Empty;
            if (query.IndexOf('&') != -1)
            {
                string[] strArray = query.Split(new[] {'&'});
                if (strArray.Length == 2)
                {
                    if (query.StartsWith("?search"))
                    {
                        str3 = strArray[1];
                    }
                    else
                    {
                        str3 = strArray[0];
                    }
                }
                else
                {
                    str3 = query;
                }
            }
            else
            {
                str3 = query;
            }
            query = str3;
            query = "&" + query.Substring(1);
            if (query.IndexOf("&" + args) == -1)
            {
                query = query + string.Format("&{0}={1}", args, value);
            }
            else
            {
                int index = query.IndexOf("&" + args);
                query = query.Substring(0, index + 1) + args + "=" + value;
            }
            query = "?" + query.TrimStart(new[] {'&'});
        }
        return (str + query);
    }

    public static string RetUrlForSearch(string string_0, string urlCanshu, string value, string args)
    {
        string str = string_0;
        if (str.IndexOf(args) == -1)
        {
            string str4;
            if ((urlCanshu == null) || (urlCanshu == ""))
            {
                if (args != null)
                {
                    str4 = str;
                    str = str4 + "?" + args + "=" + value;
                }
                return str;
            }
            if (args != null)
            {
                str4 = str;
                str = str4 + "&" + args + "=" + value;
            }
            return str;
        }
        int index = str.IndexOf(args);
        return (str.Substring(0, index) + args + "=" + value);
    }

    public static string shopDetailHref(string Guid, string MemLoginID, string string_0)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + str + str2 + "/" + string_0 + "/" + Guid + ShopSettings.overrideUrlName);
        }
        return ("http://" + str + str2 + "/" + string_0 + "/" + Guid + ".aspx");
    }
    public static string shopDetailHrefcenter(string Guid, string MemLoginID, string string_0, string shop_category_id)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + str + str2 + "/" + string_0 + "/" + Guid + ShopSettings.overrideUrlName + "?category=" + shop_category_id);
        }
        return ("http://" + str + str2 + "/" + string_0 + "/" + Guid + ".aspx" + "?category=" + shop_category_id);
    }
    public static string shopDetailHrefByShopID(string Guid, string ShopID, string string_0)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str2 + "/" + string_0 + "/" + Guid + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopURLByShopID + str2 + "/" + string_0 + "/" + Guid + ".aspx");
    }

    public static string shopDetailHrefByShopIDcenter(string Guid, string ShopID, string string_0,string shop_category_id)
    {
        string shopURLByShopID = GetShopURLByShopID(ShopID);
        string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str2 + "/" + string_0 + "/" + Guid + ShopSettings.overrideUrlName + "?category=" + shop_category_id);
        }
        return ("http://" + shopURLByShopID + str2 + "/" + string_0 + "/" + Guid + ".aspx" + "?category=" + shop_category_id);
    }

    public static string shopHref(string MemLoginID)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        string str = string.Empty;
        string str2 = string.Empty;
        if (shopIDByMemLoginID.Rows.Count > 0)
        {
            str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
            str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        }
        return ("http://" + str + str2);
    }
    public static string shopHrefcenter(string Guid, string MemLoginID, string shop_category_id)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string shopURLByShopID = GetShopURLByShopID(shopIDByMemLoginID.Rows[0]["ShopID"].ToString());
        string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName + "?category=" + shop_category_id);
        }
        return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid + ".aspx" + "?category=" + shop_category_id);
    }

    public static string shopHref(string Guid, string MemLoginID)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string shopURLByShopID = GetShopURLByShopID(shopIDByMemLoginID.Rows[0]["ShopID"].ToString());
        string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName);
        }
        return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid  + ".aspx");
    }

    public static string shopHref_two(string Guid, string MemLoginID, int shop_category_id)
    {
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string shopURLByShopID = GetShopURLByShopID(shopIDByMemLoginID.Rows[0]["ShopID"].ToString());
        string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (ShopSettings.IsOverrideUrl)
        {
            return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid + ShopSettings.overrideUrlName+"?category="+shop_category_id);
        }
        return ("http://" + shopURLByShopID + str3 + "/ProductDetail/" + Guid + ".aspx" + "?category=" + shop_category_id);
    }


    public static string ShopProductImg(string imgurl, string MemLoginID)
    {
        if ((imgurl == string.Empty) || (imgurl == null))
        {
            return "";
        }
        DataTable shopIDByMemLoginID = ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
        if ((shopIDByMemLoginID == null) || (shopIDByMemLoginID.Rows.Count == 0))
        {
            return "";
        }
        string shopURLByShopID = GetShopURLByShopID(shopIDByMemLoginID.Rows[0]["ShopID"].ToString());
        string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        return ("http://" + shopURLByShopID + str3 + "/" + imgurl.Substring(1));
    }
}