<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:BrandMeto ID="BrandMeto" runat="server" SkinFilename="BrandMeto.ascx" />
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
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》品牌</div>
        <div class="article_cont">
            <!--left start-->
            <div class="list_left fl">
                <!-- 推荐品牌 -->
                <div class="store_category_view">
                    <ShopNum1:BrandListRecommend ID="BrandListRecommend2" runat="server" SkinFilename="BrandListRecommend.ascx"
                        ShowCount="8" />
                </div>
                <!--推荐店铺-->
                <ShopNum1:DeShopEspecial ID="DeShopEspecial1" runat="server" SkinFilename="DeShopEspecially.ascx"
                    ShopType="IsRecommend" ShowCount="5" />
                <!--商品销售排行-->
                <ShopNum1:DeProductOrder ID="DeProductOrder1" runat="server" SkinFilename="DeProductOrder.ascx"
                    OrderType="SaleNumber" ShowCount="4" Title="销售排行" />
            </div>
            <!-- right -->
            <div class="list_right fr brand_right">
                <ShopNum1:BrandDetail ID="BrandDetail1" runat="server" showcount="10" cityshowcount="10"
                    SkinFilename="BrandDetail.ascx" />
                <%-- <ShopNum1:BrandShowOrder ID="BrandShowOrder1" runat="server" SkinFilename="BrandShowOrder.ascx" PageShowCount="8" Visible="false" />     --%>
            </div>
            <div class="clear">
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
