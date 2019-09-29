<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>404错误提示 </title>
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var num = 60;
        var timeInterv = window.setInterval(function onTime1() {
            var spanTimeValue = document.getElementById("spanTime").innerHTML;
            if (parseInt(spanTimeValue) <= 0) {
                window.clearInterval(timeInterv);
                window.location.href = '<%=ShopUrlOperate.GetSiteDomain() %>';
            } else {
                document.getElementById("spanTime").innerHTML = parseInt(spanTimeValue) - 1;
            }

        }, 1000);
    </script>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButtonLoginOut_Click(null, null);
        }

        private void LinkButtonLoginOut_Click(object sender, EventArgs e)
        {

            ///本地清除cookie
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
                shopnum1Cookie.Domain = "jyhbbs.t.com";
                Page.Response.Cookies.Add(shopnum1Cookie);
            }
        }
 
  
    </script>
</head>
<body style="background: none;">
    <form id="from1" runat="server">
    <div class="clearmiddle">
        <div class="errorbox">
            <div class="errorsession">
                对不起，您访问的页面可能已被删除、名称被更改或不存在……</div>
            <div class="errorcontrol">
                现在，您可以进行如下操作</div>
            <div class="errorcontrol">
                1.<span id="spanTime" style="color: Red;">60</span>秒后跳转到本商城首页
            </div>
            <div class="errorcontrol">
                2.返回<a href="javascript:void(0)" onclick="window.history.go(-1)">上一页</a>
            </div>
            <div class="errorcontrol">
                3.进入<a href='<%=ShopUrlOperate.GetSiteDomain()%>'>商城首页</a>。
            </div>
        </div>
    </div>
    </form>
</html>
