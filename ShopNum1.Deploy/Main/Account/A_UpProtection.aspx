<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_UpProtection.aspx.cs" Inherits="ShopNum1.Deploy.Main.Account.A_UpProtection" %>
<%@ Register Src="Skin/A_UpProtecion_Last.ascx" TagName="A_UpProtecion_Last" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <link type="text/css" href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <link href="style/Msafe_uc-base-css.css" rel="stylesheet" type="text/css" />
    <link href="style/Mpassport_safe_center_css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            账户管理<a href="#"></a> >> <a href="#">个人资料</a> >> <a href="#">账户安全设置</a></p>
        <form id="fromPwd" runat="server">
        
        <uc1:A_UpProtecion_Last ID="A_UpProtecion_Last" runat="server" />
        </form>
    </div>
</body>
</html>
