using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.MultiBaseWebControl
{
    [ParseChildren(true)]
    public abstract class BaseWebControl : WebControl, INamingContainer
    {
        private string _skinFilename = string.Empty;
        private string _skinName = string.Empty;

        public string SkinFilename
        {
            get { return _skinFilename; }
            set { _skinFilename = value; }
        }

        protected string SkinName
        {
            get { return _skinName; }
            set { _skinName = value; }
        }

        protected override void CreateChildControls()
        {
            Control skin = LoadSkin();
            InitializeSkin(skin);
            Controls.Add(skin);
        }

        protected abstract void InitializeSkin(Control skin);

        protected Control LoadSkin()
        {
            Control control;
            if (SkinFilename == null)
            {
                SkinFilename = _skinFilename;
            }
            string virtualPath = "Themes/Skin_Default/Skins/" + SkinFilename.TrimStart(new[] {'/'});
            try
            {
                //Page.Error += PageBase_Error;
                control = Page.LoadControl(virtualPath);
            }
            catch (FileNotFoundException)
            {
                throw new Exception(virtualPath + "用户控件文件未找到");
            }
            return control;
        }

        protected void PageBase_Error(object sender, EventArgs e)
        {
            HttpContext current = HttpContext.Current;
            Exception lastError = current.Server.GetLastError();
            string str = current.Request.Url.ToString();
            string source = lastError.Source;
            string message = lastError.Message;
            string stackTrace = lastError.StackTrace;
            string str5 = current.Request.ServerVariables["SERVER_NAME"];
            //method_0(
            //    "http://www.T.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&&OffendingUrl=" +
            //    str + "&&ErrorSouce= " + source + " &&Message=" + message + "&&StackTrace= " + stackTrace +
            //    "&&MainDomain=" + str5);
            //File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/log.txt"),
            //                   str + "&&ErrorSouce= " + source + " &&Message=" + message + "&&StackTrace= " +
            //                   stackTrace + "&&MainDomain=" + str5 + " " + DateTime.Now.ToString() + "\r\n");
            Thread.Sleep(50);
            current.Server.ClearError();
            current.Response.Redirect("~/404.aspx");
        }

        private string method_0(string string_2)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_2);
            try
            {
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string method_1(string string_2)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_2);
            try
            {
                reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void FK()
        {
            //var check = new ControlCheck();
            //string str = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            //string domain = ConfigurationManager.AppSettings["DoMain"];
            //if (str != domain)
            //{
            //    FKPost();
            //}
            //else if (check.CheckCertificationModificate(domain) != 2)
            //{
            //    FKPost();
            //}
            //else
            //{
            //    string str4 = string.Empty;
            //    string contDes = string.Empty;
            //    if (check.CheckCetificationA(out str4, out contDes) != 2)
            //    {
            //        FKPost();
            //    }
            //    else if (!check.CheckFirstMd5(str4, domain, contDes.ToLower()))
            //    {
            //        FKPost();
            //    }
            //    else if (!check.CheckSecondDes(contDes.ToLower()))
            //    {
            //        FKPost();
            //    }
            //}
        }

        protected void FKPost()
        {
            string str = "";
            HttpContext current = HttpContext.Current;
            str = ConfigurationManager.AppSettings["DoMain"];
            if (str != "localhost")
            {
                switch (
                    method_1(
                        "http://www.T.com/ShopNum1MallDomainVerfiy/ShopNum1Verfify.aspx?shopnum1verfify=FKshopnum1verfify&&FkDomin=" +
                        str))
                {
                    case "YES":
                        return;

                    case "FKENDDATE":
                        current.Response.Redirect("http://www.T.com/Mallbuy.html");
                        return;
                }
                current.Response.Redirect("http://www.T.com/Mallshouldbuy.html");
            }
        }
        private string _cookieCustomerCategory = string.Empty;
        public int CookieCustomerCategory
        {
            get 
            {
                if (Page.Request.QueryString["category"] != null && Page.Request.QueryString["category"] != "")
                {
                    
                    HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(Page.Request.QueryString["category"]).ToString());
                    cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    cookie.Path = @"/";
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Page.Response.Cookies.Add(cookie);
                    return Convert.ToInt32(Page.Request.QueryString["category"]);
                }
                //string CategroyType=.ToString();
                if (Page.Request.Cookies["category"] != null)
                {
                    return Convert.ToInt32(Page.Request.Cookies["category"].Value);
                    
                }
                return Convert.ToInt32(CustomerCategory.大唐专区);
                
            }
            set
            {
                _cookieCustomerCategory = value.ToString();
                
                
            }

        }

        public string CookieCategoryString
        {
            get
            {
                if (Page.Request.QueryString["category"] != null && Page.Request.QueryString["category"] != "")
                {

                    HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(Page.Request.QueryString["category"]).ToString());
                    cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    cookie.Path = @"/";
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Page.Response.Cookies.Add(cookie);
                    return Page.Request.QueryString["category"];
                }
                //string CategroyType=.ToString();
                if (Page.Request.Cookies["category"] != null)
                {
                    return Page.Request.Cookies["category"].Value;

                }
                return Convert.ToInt32(CustomerCategory.大唐专区).ToString();

            }
           

        }
    }
}