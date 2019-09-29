<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_Protection.aspx.cs" Inherits="ShopNum1.Deploy.Main.Account.A_Protection" %>
<%@ Register Src="Skin/A_Protection_SMS.ascx" TagName="A_Protection_SMS" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <link href="style/Msafe_uc-base-css.css" rel="stylesheet" type="text/css" />
    <link href="style/Mpassport_safe_center_css.css" rel="stylesheet" type="text/css" />
    <script src="js/Common.js" type="text/javascript"></script>
<script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><a href="A_PwdSer.aspx">账户安全设置</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">验证手机开启资金保护</span></p>
        <form id="fromBindMobile" runat="server">
              <%--<ShopNum1Account:A_BindEmail ID="A_BindEmail" runat="server" SkinFilename="Skin/A_BindEmail.ascx" />--%>
       <uc1:A_Protection_SMS ID="A_Protection_SMS1" runat="server" />
        </form>
    </div>
</body>
</html>
