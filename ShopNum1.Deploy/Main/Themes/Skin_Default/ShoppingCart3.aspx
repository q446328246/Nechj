<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>


<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register src="skins/ShoppingCart3.ascx" tagname="ShoppingCart3" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">    
  <!--
        javascript: window.history.forward(1);    
  -->    
    </script>
</head>
<body>
    <form id="from1" runat="server" autocomplete="off" method="post">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--head end-->
    <!--main start-->
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a>订单确认</a></div>
        <div class="chengthee clearfix">
            <%--<ShopNum1:ShoppingCart3 ID="ShoppingCart1" runat="server" SkinFilename="ShoppingCart3.ascx" />--%>
            <uc1:ShoppingCart3 ID="ShoppingCart31" runat="server" />
        </div>
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
