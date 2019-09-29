<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register src="Skin/A_UpPayPwdSucceed.ascx" tagname="A_UpPayPwdSucceed" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <link type="text/css" href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
    <link href="style/Msafe_uc-base-css.css" rel="stylesheet" type="text/css" />
    <link href="style/Mpassport_safe_center_css.css" rel="stylesheet" type="text/css" />
    

</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a> >> <a href="A_MemInfo.aspx">个人资料</a> >> <a href="#">
                账户安全设置</a></p>
        <form id="fromPwd" runat="server">
      <%--  <ShopNum1Account:A_UpPayPwdSucceed ID="A_UpPayPwdSucceed" runat="server" SkinFilename="Skin/A_UpPayPwdSucceed.ascx" />--%>
        <uc1:A_UpPayPwdSucceed ID="A_UpPayPwdSucceed1" runat="server" />
        </form>
    </div>
</body>
</html>
