﻿<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>红包订单详细</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ScoreOrder_List.aspx">红包订单</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">红包订单详细</span></p>
        <ShopNum1ShopAdmin:S_ScoreOrder_Edit ID="S_ScoreOrder_Edit" runat="server" SkinFilename="skin/S_ScoreOrder_Edit.ascx" />
    </div>
    </form>
</body>
</html>
