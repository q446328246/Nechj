﻿<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="Themes/Skin_Default/style/index.css" />
    <title>商品访问统计</title>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
</head>
<body class="right_body">
    <form id="form1" runat="server">
    <!--商品访问统计-->
    <ShopNum1ShopAdmin:S_SeeBuyRate_Report ID="SeeBuyRate_Report1" runat="server" SkinFilename="skin/S_SeeBuyRate_Report.ascx" />
    </form>
</body>
</html>
