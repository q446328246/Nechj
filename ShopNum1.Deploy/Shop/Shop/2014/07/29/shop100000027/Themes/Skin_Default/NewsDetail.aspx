<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Page Language="C#" %>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" SkinFilename="SetMeta.ascx" runat="server" />
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
            <div class="sidebar leftn_hot">
                <!--资讯分类-->
                <ShopNum1Shop:NewsCategoryList ID="NewsCategoryList" runat="server" SkinFilename="NewsCategoryList.ascx" />
                <!--最新资讯-->
                <ShopNum1Shop:NewsListBestNew ID="NewsListBestNew" ShowCount="15" runat="server"
                    SkinFilename="NewsListBestNew.ascx" />
                <!--商品分类-->
                <ShopNum1Shop:ProductCategory ID="productCategory" runat="server" SkinFilename="ProductCategory.ascx" />
            </div>
            <div class="main">
                <!--资讯详细-->
                <ShopNum1Shop:NewsDetail ID="NewsDetail" runat="server" ShowCount="10" SkinFilename="NewsDetail.ascx" />
                 <ShopNum1Shop:ShopArticleCommentList ID="ShopArticleCommentList" runat="server" ShowCount="10" SkinFilename="ShopArticleCommentList.ascx" />
                <ShopNum1Shop:ShopArticleCommentAdd ID="ShopArticleCommentAdd1" runat="server" ShowCount="10" SkinFilename="ShopArticleCommentAdd.ascx" />
            </div>
        </div>
    </div>
    
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
 </ShopNum1:Form>

    <script src='Themes/Skin_Default/js/jquery-1.2.6.pack.js' type="text/javascript"></script>

    <script src='Themes/Skin_Default/js/changeUrl.js' type="text/javascript"></script>

</body>
</html>
