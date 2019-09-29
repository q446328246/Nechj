<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" charset="utf-8" />
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
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <!--站点地图-->
    <!-- middle -->
    <div class="FlowCat_cont">
        <div class="article_cont">
            <!-- left -->
            <div class="list_left fl">
                <!--商品分类-->
                <%--   <ShopNum1:ProductCategoryControl ID="ProductCategoryControl" runat="server" />--%>
                <ShopNum1:ProductThreeCategory ID="ProductThreeCategory1" runat="server" SkinFilename="ProductThreeCategory.ascx"
                    ShowCountOne="10" ShowCountTwo="5" />
            </div>
            <!-- right -->
            <div class="list_right fr">
                <%--    <!--商品属性 -->
            <ShopNum1:ProductAttribute ID="ProductAttribute1" runat="server" SkinFilename="ProductAttribute.ascx" />--%>
                <%-- 商品搜索列表--%>
                <ShopNum1:ProductSearch3 ID="ProductSearch" runat="server" SkinFilename="ProductSearch.ascx"
                    PageCount="10" ShowCount="10" />
            </div>
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
