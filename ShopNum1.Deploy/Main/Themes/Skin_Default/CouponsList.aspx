<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script src="Themes/Skin_Default/js/lt.js" type="text/javascript"></script>
    <script src="Themes/Skin_Default/js/Marquee.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a>优惠券</a></div>
        <div class="list_left fl">
            <!--优惠券 优惠活动-->
            <ShopNum1:CouponsList ID="CouponsList" runat="server" SkinFilename="CouponsList.ascx"
                ShowCount="7" />
            <!--商品 人气排行-->
            <ShopNum1:DeProductOrder ID="DeProductOrder1" runat="server" SkinFilename="DeProductOrder.ascx"
                OrderType="ClickCount" ShowCount="4" Title="人气排行" />
            <ShopNum1:ArticleNewList ID="ArticleNewList1" runat="server" SkinFilename="ArticleNew.ascx"
                ShowCount="10" />
            <div class="clear">
            </div>
        </div>
        <div class="list_right fr">
            <!--幻灯-->
            <div id="focus" class="yh_focus">
                <div id="Rleft">
                    <div id='ad7' runat='server'>
                    </div>
                    <ShopNum1:AdvertisementPPTStyle ID="AdvertisementPPTStyle" runat="server" SkinFilename="AdvertisementPPT.ascx"
                        AdID="ad7" AdType="2" />
                    <script src="Themes/Skin_Default/js/hp.js" type="text/javascript"></script>
                </div>
            </div>
            <!--电子优惠券 搜索-->
            <ShopNum1:CouponListSearch ID="CouponListSearch" runat="server" SkinFilename="CouponListSearch.ascx"
                ShowCount="20" />
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    <!--图片广告模块调用  幻灯片 -->
    <%--   <ShopNum1:AdvertisementPPT  AdID="ad6" runat="server" SkinFilename="AdvertisementPPTTwo.ascx" />--%>
    </form>
</body>
</html>
