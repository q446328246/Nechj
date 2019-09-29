<%@ Page Language="C#" %>

<%@ Import Namespace="System.Threading" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButtonLoginOut_Click(null, null);
    }

    private void LinkButtonLoginOut_Click(object sender, EventArgs e)
    {

        //本地清除cookie
        if (Page.Request.Cookies["category"] != null) 
        {
            HttpCookie shopnum1Cookie = Page.Request.Cookies["category"];
            shopnum1Cookie.Values.Clear();
            shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
            shopnum1Cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
            Page.Response.Cookies.Add(shopnum1Cookie);
        }
        if (Page.Request.Cookies["MemberLoginCookie"] != null)
        {

            HttpCookie shopnum1Cookie = Page.Request.Cookies["MemberLoginCookie"];
            shopnum1Cookie.Values.Clear();
            shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
            shopnum1Cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
            Page.Response.Cookies.Add(shopnum1Cookie);
        }
        if (Page.Request.Cookies["dnt"] != null)
        {

            HttpCookie shopnum1Cookie = Page.Request.Cookies["dnt"];
            shopnum1Cookie.Values.Clear();
            shopnum1Cookie.Expires = Convert.ToDateTime(System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss"));
            shopnum1Cookie.Domain = ConfigurationManager.AppSettings["DiscuzCookieDomain"].ToString();
            Page.Response.Cookies.Add(shopnum1Cookie);
        }
        
      
    }
 
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>退出成功</title>
    <link href="/Main/Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function getcookie(name) {
            var cookie_start = document.cookie.indexOf(name);
            var cookie_end = document.cookie.indexOf(";", cookie_start);
            return cookie_start == -1 ? '' : unescape(document.cookie.substring(cookie_start + name.length + 1, (cookie_end >
cookie_start ? cookie_end : document.cookie.length)));
        }
        function setcookie(cookieName, cookieValue, seconds, path, domain, secure) {
            var expires = new Date();
            expires.setTime(expires.getTime() + seconds * 1000);
            domain = !domain ? cookiedomain : domain;
            path = !path ? cookiepath : path;
            document.cookie = escape(cookieName) + '=' + escape(cookieValue)
		+ (expires ? '; expires=' + expires.toGMTString() : '')
		+ (path ? '; path=' + path : '/')
		+ (domain ? '; domain=' + domain : '')
		+ (secure ? '; secure' : '');
        }
        setcookie('dnt', '', 0, '/', 'BBS.t.com', '');


        function setLoginout() {
            location.href = "Default.aspx";
        }
        setTimeout("setLoginout()", 2000);  
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!--//head end-->
    <!--main start-->
    <br />
    <br />
    <h2 style="font-size: large; color: Green;">
        <center>
            恭喜您退出成功！</center>
    </h2>
    <center style="display: none">
        <span id="loadtime">5</span></center>
    <center>
        正在<a href="/">返回首页</a>...</center>
    <br />
    <br />
    <!--//main end-->
    <!--foot start-->
    
    <iframe src='<%=System.Configuration.ConfigurationSettings.AppSettings["Domain"] %>' height="0" width="0"
        visible="false"></iframe>
    <!--foot end-->
    <!--js-->
    </form>
</body>
</html>
