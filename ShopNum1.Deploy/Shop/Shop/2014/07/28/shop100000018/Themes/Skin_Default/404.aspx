<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveUrl(Globals.SkinPath+"/Style/index.css") %>' />
</head>
<body style="background:#f0f0f0;">
    <form id="from1" runat="server">

    <script type="text/javascript">
 var num = 10;
 var action = null;
 var autoDir = null;
 var actionLink = '';
 var actionName = '首页';
 function countDown() {
 if (!action) {
 action = document.getElementById("defaultAction");
 autoDir = document.getElementById('autoDir');
 if (!autoDir) return;
 actionLink = action.href;
 actionName = action.innerHTML;
 }
 if (num >= 0) {
 autoDir.innerHTML = '系统将在 <strong>' + num + '</strong> 秒后自动跳转首页<a href="' + actionLink + '"><strong>' + actionName + '</strong></a>';
 num--;
 setTimeout(countDown, 1000);
 } else {
 goNow();
 }
 }
 function goNow() {
 window.location.href = document.getElementById("defaultAction").href;
 }
 window.onload = countDown;
    </script>

    <div class="warp clearfix">
    <div style="background:#fff; border:1px solid #ccc; margin-top:40px; padding:10px 0; width:60%;">
        <table cellpadding="0" cellspacing="0" border="0" class="endtable" style="margin:auto;">
            <tr>
                <td>
                    <img src="Themes/Skin_Default/Images/registfail404.gif" />
                </td>
                <td>
                    <h2>
                        对不起!您所访问的页面不存在或者已删除。</h2>
                    <h3>
                        <a href='<%= "http://"+ System.Configuration.ConfigurationManager.AppSettings["DoMain"] +"/Default.html"%>' id="defaultAction"></a>
                        <div id="autoDir">
                        </div>
                    </h3>
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
