<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" runat="server" SkinFilename="SetMeta.ascx" />
    <script src="/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--main start-->
                <!--left is start-->
                <div>
                    <div class="sidebar leftn_hot">
                        <!--店铺信息-->
                        <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                    </div>
                    <div class="main">
                        <!--好评展现-->
                        <ShopNum1Shop:ShopCommentFavorableRate ID="ShopCommentFavorableRate" runat="server" SkinFilename="ShopCommentFavorableRate.ascx" />
                        <!--评价统计-->
                        <ShopNum1Shop:ShopCommentStatReport ID="ShopCommentStatReport" runat="server" SkinFilename="ShopCommentStatReport.ascx" />
                    </div>
                </div>
            </div>
            <div class="clear"></div>
            <div class="warp clearfix">
                <!--评论列表-->
                <ShopNum1ShopNew:ShopComment ID="ShopComment" runat="server" SkinFilename="ShopCommentNew.ascx" ShowCount="10" />
            </div>
            <div class="clear"></div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
<script type="text/javascript">
    DD_belatedPNG.fix('div, ul, img, li, input , a, a:hover');
</script>
<![endif]-->
</body>
</html>
