<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="style/style.css" />
    <title>商品访问统计</title>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
</head>
<body class="right_body">
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">商品访问统计</span></p>
        <!--商品访问统计-->
        <ShopNum1ShopAdmin:S_SeeBuyRate ID="SeeBuyRate" runat="server" SkinFilename="skin/S_SeeBuyRate.ascx"
            ShowCount="10" />
    </div>
    </form>
</body>
</html>
