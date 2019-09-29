<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ProductCategoryMeto ID="ProductCategoryMeto" runat="server" SkinFilename="ProductCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a href="/Search_productlist.aspx">热卖商品</a></div>
        <div class="article_cont">
            <div class="list_left fl">
                <!--商品三级分类 全部分类-->
                <ShopNum1:ProductThreeCategory ID="ProductThreeCategory1" runat="server" SkinFilename="ProductThreeCategory.ascx"
                    ShowCountOne="10" ShowCountTwo="5" />
                <!--推荐商品-->
                <ShopNum1:ProductIsCategoryShow ID="ProductIsCategoryShow3" runat="server" SkinFilename="ProductByProp.ascx"
                    ShowCount="5" ProductType="IsShopRecommend" />
            </div>
            <div class="list_right fr">
                <!-- 热销商品-->
                <ShopNum1:ProductIsCategoryShow ID="ProductIsCategoryShow4" runat="server" SkinFilename="ProductByProperty.ascx"
                    ShowCount="4" ProductType="IsHot" Title="热销商品" />
                <!--商品属性-->
                <ShopNum1:ProductAttribute ID="ProductAttribute1" runat="server" SkinFilename="ProductAttribute.ascx" />
                <!--商品展示-->
                <ShopNum1:Search_productlist ID="ProductSearch" ShowCount="30" CityShowCount="10"
                    runat="server" SkinFilename="ProductListHot.ascx" />
            </div>
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>
