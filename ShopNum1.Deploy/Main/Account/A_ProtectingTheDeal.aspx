<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_ProtectingTheDeal.aspx.cs" Inherits="ShopNum1.Deploy.Main.Account.A_ProtectingTheDeal1" %>
<%@ Register Src="Skin/A_ProtectingTheDeal_SMS.ascx" TagName="A_ProtectingTheDeal_SMS" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><a href="A_PwdSer.aspx">账户安全设置</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">设置资金保护</span></p>
        <form id="fromBindMobile" runat="server">
        <%--        <ShopNum1Account:A_ChangePwdWay ID="A_ChangePwdWay" runat="server" SkinFilename="Skin/A_ChangePwdWay.ascx" />--%>
        <uc1:A_ProtectingTheDeal_SMS ID="A_ProtectingTheDeal_SMS1" runat="server" />
        </form>
    </div>
</body>
</html>
