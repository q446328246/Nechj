<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ProductCategoryMeto ID="ProductCategoryMeto" runat="server" SkinFilename="ProductCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
<style type="text/css">
    .ThrCategory_fwr
    {
        z-index: 111;
    }
    #FlowCate
    {
        top: 0;
    }
    a.nextpage
    {
        width: 60px;
    }
    a.nextpage:hover
    {
        width: 60px;
    }
</style>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="article_cont">
            <div class="list_left fl">
                <!--商品分类-->
                <ShopNum1:ProductOneTwoCategory ID="ProductOneTwoCategory1" runat="server" SkinFilename="ProductOneTwoCategory.ascx"
                    ShowCountOne="10" ShowCountTwo="500" />
                <!--推荐商品-->
                <ShopNum1:ProductIsCategoryShow ID="ProductIsCategoryShow3" runat="server" SkinFilename="ProductByProp.ascx"
                    ShowCount="5" ProductType="IsShopRecommend" />
                <!--广告-->
                <div class="leftimg">
                    <a href="#">
                        <img src="Themes/Skin_Default/Images/seach01.jpg" width="220" height="325" /></a>
                </div>
            </div>
            <div class="list_right fr">
                <!--商品属性-->
                <ShopNum1:ProductAttribute ID="ProductAttribute1" runat="server" SkinFilename="ProductAttribute.ascx" />
                <!--商品展示-->
                <ShopNum1:ProductSearch ID="ProductSearch" ShowCount="5" CityShowCount="10" runat="server"
                    SkinFilename="ProductSearch.ascx" />
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
