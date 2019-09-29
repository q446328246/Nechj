using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy
{
    public class PageBase : AdminPage
    {
        protected DataTable dataTableRole = null;
        /// <summary>
        /// 
        /// </summary>
        public PageBase()
        {
            
            //base.Error += PageBase_Error;

        }
      

        public void BindCookies()
        {
            if (Page.Request.QueryString["category"] != null)
            {
                HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(Page.Request.QueryString["category"]).ToString());
                cookie.Domain = ShopSettings.CookieDomain;
                cookie.Path = @"/";
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

            }
            
        }

        public string CurrentPageName { get; private set; }

        protected string ShopNum1LoginID { get; private set; }

        protected string ShopNum1UserGuid { get; private set; }

        protected string strDomain { get; private set; }


     

      
        /// <summary>
        /// 检测是否是admin用户
        /// </summary>
        /// <returns></returns>
        public bool checkadmin() {
            bool isadmin = false;
            try
            {
                if (ShopNum1UserGuid.ToUpper() == "452EADE0-D412-4544-A15C-F465FDAD3B21")
                {
                    isadmin = true;
                }
            }
            catch (Exception)
            {
                isadmin = false;
            }
            return isadmin;
        }



        protected void CheckLogin()
        {
            var action = (ShopNum1_PreventIp_Action)LogicFactory.CreateShopNum1_PreventIp_Action();
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            if (!action.CheckedUser(HttpContext.Current.Request.UserHostAddress, "2"))
            {
                base.Response.Redirect("~/404.aspx");
            }
            else if (cookie2.Values["LoginID"] == null)
            {
                base.Response.Redirect("Login.aspx");
            }
            else
            {

                ShopNum1UserGuid = cookie2.Values["Guid"];
                ShopNum1LoginID = cookie2.Values["LoginID"];

             

                CurrentPageName = PageOperator.GetCurrentPageName();

                if (CheckPage(CurrentPageName) <= 0)
                {
                    base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
                }
                else
                {
                    OperatePageControl(Page);
                }
            }
        }

        protected void CheckNoPowerLogin()
        {
            var action = (ShopNum1_PreventIp_Action)LogicFactory.CreateShopNum1_PreventIp_Action();

            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            
            if (!action.CheckedUser(HttpContext.Current.Request.UserHostAddress, "2"))
            {
                base.Response.Redirect("~/404.aspx");
            }
            //Session["AdminLoginCookie"]
            else if (cookie2.Values["LoginID"] == null)
            {

                base.Response.Redirect("Login.aspx");
            }
            else
            {
                
                ShopNum1UserGuid = cookie2.Values["Guid"];

              


                ShopNum1LoginID = cookie2.Values["LoginID"];
                CurrentPageName = PageOperator.GetCurrentPageName();
                if (CheckPage(CurrentPageName) <= 0)
                {
                    if (!(CurrentPageName == "index.aspx"))
                    {
                        base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
                    }
                }
                else
                {
                    OperatePageControl(Page);
                }
            }
        }

        protected int CheckPage(string pageName)
        {
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            if (HttpSecureCookie.Decode(cookie).Values["PeopleType"] == "0")
            {
                return 1;
            }
            var action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
            return action.CheckOperatePage(ShopNum1UserGuid, pageName);
        }

        public void ClientDomainCheck()
        {
            //var check = new ControlCheck();
            //string str = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            //string domain = ConfigurationManager.AppSettings["DoMain"];
            //if (str != domain)
            //{
            //    FK();
            //    base.Response.Redirect("~/Main/Admin/Html/Nopower.htm");
            //}
            //if (check.CheckCertificationModificate(domain) != 2)
            //{
            //    FK();
            //}
            //else
            //{
            //    string str4 = string.Empty;
            //    string contDes = string.Empty;
            //    if (check.CheckCetificationA(out str4, out contDes) != 2)
            //    {
            //        FK();
            //    }
            //    else if (!check.CheckFirstMd5(str4, domain, contDes.ToLower()))
            //    {
            //        FK();
            //    }
            //    else if (!check.CheckSecondDes(contDes.ToLower()))
            //    {
            //        FK();
            //    }
            //}
        }

        protected void FK()
        {
            string str = "";
            HttpContext current = HttpContext.Current;
            str = current.Request.ServerVariables["SERVER_NAME"];
            if (str != "localhost")
            {
                string str2 = "YES";
                if (str2 != "YES")
                {
                    if (str2 == "FKENDDATE")
                    {
                        current.Response.Redirect("http://www.T.com/Mallbuy.html");
                    }
                    else
                    {
                        current.Response.Redirect("http://www.T.com/Mallshouldbuy.html");
                    }
                }
            }
        }

        protected void GetControlOperate(string pageName)
        {
            dataTableRole =
                ((ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action()).GetOperateControl(ShopNum1UserGuid,
                                                                                                       pageName);
        }

        protected string HeaderInfo(string secondTitle)
        {
            var builder = new StringBuilder();
            if (secondTitle == "")
            {
                builder.Append("<title>后台管理</title>\r\n");
            }
            else
            {
                builder.Append("<title>系统后台管理-" + secondTitle + "</title>\r\n");
            }
            return builder.ToString();
        }

        private string method_1(string string_4)
        {
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            request = WebRequest.Create(string_4);
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

        private string method_4(string string_4)
        {
            string str = string.Empty;
            StreamReader reader = null;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            WebRequest request = null;
            WebResponse response = null;
            request = WebRequest.Create(string_4);
            try
            {
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), encoding);
                str = reader.ReadToEnd();
                reader.Close();
                if (response != null)
                {
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                str = "";
                //throw ex;
            }
            return str;
        }

        protected int OperateLog(ShopNum1_OperateLog operateLog)
        {
            var action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
            return action.Add(operateLog);
        }

        public void OperatePageControl(Page currentPage)
        {
            foreach (System.Web.UI.Control control in currentPage.Controls)
            {
                if (control.HasControls())
                {
                    method_2(control);
                }
                method_3(control);
            }
        }

        private void method_2(System.Web.UI.Control ctrl)
        {
            foreach (System.Web.UI.Control control in ctrl.Controls)
            {
                if (control.HasControls())
                {
                    method_2(control);
                }
                method_3(control);
            }
        }



        private void method_3(System.Web.UI.Control ctrl)
        {
            bool flag = false;
            bool flag2 = true;
            bool flag3 = true;

            GetControlOperate(CurrentPageName);

            try
            {
                if ((dataTableRole == null) || (dataTableRole.Rows.Count <= 0))
                {
                    return;
                }

                foreach (DataRow datarow in dataTableRole.Rows)
                {
                    if (datarow["ControlID"].ToString() == ctrl.ID)
                    {
                        if (datarow["IsShow"].ToString() == "0")
                        {
                            flag3 = false;
                        }

                        if (datarow["IsUse"].ToString() == "0")
                        {
                            flag2 = false;
                        }

                        break;
                    }
                }

                flag = true;

                //using (IEnumerator enumerator = this.dataTableRole.Rows.GetEnumerator())
                //{
                //    IEnumerator enumerator = dataTableRole.Rows.GetEnumerator();
                //    DataRow current;
                //    while (enumerator.MoveNext())
                //    {
                //        current = (DataRow)enumerator.Current;
                //        if (current["ControlID"].ToString() == ctrl.ID)
                //        {
                //            goto Label_0086;
                //        }
                //    }
                //    goto Label_00CB;
                //Label_0086:
                //    if (current["IsShow"].ToString() == "0")
                //    {
                //        flag3 = false;
                //    }
                //    flag = true;
                //}
            }
            catch
            {
                flag = false;
            }

            //Label_00CB:
            if (flag)
            {
                if (!flag3)
                {
                    ctrl.Visible = flag3;
                }
                else
                {
                    string fullName = ctrl.GetType().FullName;
                    if (fullName != null)
                    {
                        if (fullName != "System.Web.UI.WebControls.Button")
                        {
                            if (!(fullName == "System.Web.UI.WebControls.LinkButton"))
                            {
                                if (fullName == "System.Web.UI.WebControls.ImageButton")
                                {
                                    var button3 = ctrl as ImageButton;
                                    if (!flag2)
                                    {
                                        button3.Enabled = flag2;
                                    }
                                }
                            }
                            else
                            {
                                var button = ctrl as LinkButton;
                                if (!flag2)
                                {
                                    button.Enabled = flag2;
                                }
                            }
                        }
                        else
                        {
                            var button2 = ctrl as Button;
                            if (!flag2)
                            {
                                button2.Enabled = flag2;
                            }
                        }
                    }
                }
            }
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
            method_1(
                "http://www.T.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&OffendingUrl=" +
                str + "&ErrorSouce= " + source + " &Message=" + message + "&StackTrace= " + stackTrace + "&MainDomain=" +
                str5);
            current.Server.ClearError();
            ErrorShow.Show(stackTrace);
        }

        public int CookieCustomerCategory
        {
            get
            {
                if (Page.Request.QueryString["category"] != null && Page.Request.QueryString["category"] != "")
                {
                    HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(Page.Request.QueryString["category"]).ToString());
                    cookie.Domain = ".t.com";
                    cookie.Path = @"/";
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Page.Response.Cookies.Add(cookie);
                    return Convert.ToInt32(Page.Request.QueryString["category"]);
                }
                if (Page.Request.Cookies["category"] != null)
                {
                    return Convert.ToInt32(Page.Request.Cookies["category"]);
                }

                return Convert.ToInt32(CustomerCategory.大唐专区);
            }

        }
    }
}