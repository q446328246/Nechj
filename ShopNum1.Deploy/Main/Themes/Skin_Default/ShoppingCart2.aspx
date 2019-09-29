<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableEventValidation="false" %>

<%@ Register Src="skins/ShoppingCart2_New.ascx" TagName="ShoppingCart2_New" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">    
  <!--
        javascript: window.history.forward(1);    
  -->    
    </script>
</head>
<body>
    <form id="from1" runat="server" method="post" autocomplete="off">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--head end-->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a>订单结算</a></div>
        <%--购物流程--%>
        <ShopNum1:ShoppingCart2_New ID="ShoppingCart2_New" runat="server" SkinFilename="ShoppingCart2_New.ascx" />
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
