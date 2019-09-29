<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_AddMobilePlay.aspx.cs" Inherits="ShopNum1.Deploy.Main.Account.A_AddMobilePlay" %>
<%@ Register Src="Skin/A_AddMobilePlay.ascx" TagName="A_AdPayTransfer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>财务管理-人民币转账</title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
    <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">金币转账到闲时游</span></p>
        <form runat="server" id="fromA_AdPayTiXian">
        
        <uc1:A_AdPayTransfer ID="A_AdPayTransfer1" runat="server"  />
        </form>
    </div>
    
</body>
</html>