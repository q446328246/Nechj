<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品搜索-唐江宝宝</title>
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
            <a href="default.aspx?category=1">首页</a> 》<a href="/Search_productlist.aspx">商品搜索</a></div>
        <div class="article_cont">
            <div class="list_left fl">
                <!--商品三级分类 全部分类-->
                <ShopNum1:ProductThreeCategory ID="ProductThreeCategory1" runat="server" SkinFilename="ProductThreeCategory.ascx"
                    ShowCountOne="16" ShowCountTwo="5" />
                <!--推荐商品-->
                <%--  <shopnum1:productiscategoryshow id="ProductIsCategoryShow3" runat="server" skinfilename="ProductByProp.ascx"
                    showcount="5" producttype="IsShopRecommend" />--%>
                <ShopNum1:ZtcGoods ID="ZtcGoods" runat="server" SkinFilename="ZtcGoods.ascx" startNum="1"
                    endNum="6" />
                <div class="tuijianpro">
                    <h1>
                        浏览历史</h1>
                    <div class="tuijiancont" id="MyHistory">
                    </div>
                </div>
            </div>
            <div class="list_right fr">
                <!-- 热销商品-->
                <ShopNum1:ProductIsCategoryShow ID="ProductIsCategoryShow4" runat="server" SkinFilename="ProductByProperty.ascx"
                    ShowCount="4" ProductType="IsHot" Title="热销商品" />
                <!--商品属性-->
                <ShopNum1:ProductAttribute ID="ProductAttribute1" runat="server" SkinFilename="ProductAttribute.ascx" />
                <!--商品展示-->
                <ShopNum1:Search_productlistNew_V8_2 ID="Search_productlistNew_V8_2" runat="server"
                    ShowCount="30" CityShowCount="10" SkinFilename="Search_productlistNew_V8_2.ascx" />
                <%-- <shopnum1:search_productlist id="ProductSearch" showcount="30" cityshowcount="10" 
                    runat="server" skinfilename="Search_productlist.ascx" />--%>
            </div>
        </div>
    </div>
    <!--//main End-->
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("img").each(function () { $(this).attr("src", $(this).attr("original")); });
        });
    </script>
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>
