<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>库存报表</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link rel="stylesheet" type="text/css" href="style/style.css" />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
</head>
<body class="right_body">
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">库存报表</span></p>
        <!--库存报表-->
        <ShopNum1ShopAdmin:S_StockReport ID="StockReport" runat="server" ShowCount="5" SkinFilename="skin/S_StockReport.ascx" />
    </div>
    </form>
</body>
</html>
