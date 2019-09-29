<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page language="C#" %>
<%@ Register src="Skin/A_PwdSer.ascx" tagname="A_PwdSer" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    

</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">账户安全设置</span>
        </p>
        <form id="fromPwd" runat="server">
       <%-- <ShopNum1Account:A_PwdSer ID="A_PwdSer" runat="server" SkinFilename="Skin/A_PwdSer.ascx" />--%>
        <uc1:A_PwdSer ID="A_PwdSer1" runat="server" />
        </form>
    </div>
</body>
</html>
