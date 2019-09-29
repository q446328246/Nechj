<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <%--<ShopNum1:ShopCategoryMeto ID="ShopCategoryMeto" runat="server" SkinFilename="ShopCategoryMeto.ascx" />--%>
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#FlowCate").mouseover(function () {
                $("#ThrCategory").show();
                $("#ThrCategory").focus();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });

            $("#ThrCategory").mouseover(function () {
                $("#ThrCategory").show();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!-- main Start -->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx?category=1">首页</a> 》<a href="/ShopListSearch.aspx?category=9">店铺</a></div>
        <div class="shopsearch">
            <!--店铺分类 店铺类目-->
            <ShopNum1:ShopCategoryCount ID="ShopCategoryCount2" runat="server" SkinFilename="ShopCategoryCount.ascx"
                ShowCountOne="60" />
            <!--店铺搜索结果-->
            <ShopNum1:ShopListSearch ID="ShopListSearch1" ShowCount="15" runat="server" SkinFilename="ShopListSearch.ascx"
                ShowRelatedProduct="-1" />
        </div>
    </div>
    <!-- //main End -->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>
