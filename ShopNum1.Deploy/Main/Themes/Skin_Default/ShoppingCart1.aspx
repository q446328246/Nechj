<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register Src="skins/ShoppingCart1.ascx" TagName="ShoppingCart1" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <%--<link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">    
  <!--
        javascript: window.history.forward(1);    
  -->    
    </script>
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a>我的购物车</a></div>
        <%--购物流程--%>
        <%--<ShopNum1:ShoppingCart1 ID="ShoppingCart1" runat="server" SkinFilename="ShoppingCart1.ascx" />--%>
        <uc1:ShoppingCart1 ID="ShoppingCart11" runat="server" />
    </div>
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/ShopDetail.js"></script>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    <script type="text/javascript" language="javascript">
        var shoppath = '<%=ShopUrlOperate.GetShopPath() %>'; //店铺路径
        var ycity = '<%=ShopUrlOperate.GetUserCity() %>';
        var locurl = 'http://<%=ShopNum1.Common.ShopSettings.siteDomain %>/poplogin.aspx?vj=shopcar&backurl=' + encodeURIComponent('http://<%=Request.Url.Host %>/productdetail.aspx?guid=<%=Request.QueryString["guid"] %>');
    </script>
    <div id="loginbox" style="display: none;">
        <div class="box_mod">
        </div>
        <div class="box_area" style="top: 200px; margin-left: -260px;">
            <h3>
                <span class="b_dl">您尚未登录</span> <span class="b_colse">close</span>
            </h3>
            <iframe id="mylogingo" src="" width="100%" height="400" frameborder="0" scrolling="no">
            </iframe>
        </div>
    </div>
    </form>
</body>
</html>
