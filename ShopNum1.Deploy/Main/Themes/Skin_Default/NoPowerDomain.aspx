<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>域名未授权</title>
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: none;">
    <form id="from1" runat="server">
    <%--<div class="clearmiddle" style="padding-top:80px; margin:0 auto; width: 800px; overflow:hidden;">
      <div class="errorbox">
      <img src="Themes/Skin_Default/Images/errorlogo.jpg" />
      <div class="errorsession">
      对不起，您的域名可能未被授权
      </div>
 
      <div class="errorcontrol">
   
      </div>
      </div>
      <div style="clear:both; padding-top:20px;"></div>
       
<!-- bottom -->
    </div>--%>
    <div class="warp clearfix grantor">
        <div class="nopower">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="notd">
                        尊敬的用户：<br />
                        您好！<br />
                        您的网站目前暂时无法访问，可能域名没有被授权或者<br />
                        IP被禁止访问了，欲了解详情，请尽快联系我司客服人员。<br />
                        感谢您长期以来对<a href="http://www.T.com" target="_blank" style="color: #cc3300;">武汉唐江国际有限公司</a>的信赖和支持！<br />
                        <br />
                        <p>
                            联系电话：<span>400-691-8851</span></p>
                        <p>
                            E-mail:<a href="mailto:manager@shopnum1.com?subject=Hello" target="_blank">manager@shopnum1.com</a></p>
                        <p>
                            网址：<a href="http://www.T.com" target="_blank">www.T.com</a></p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</html>
