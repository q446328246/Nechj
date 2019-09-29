<%@ Control Language="C#" AutoEventWireup="true" %>
<%--<%@ OutputCache Duration="600" Shared="true" VaryByParam="none" %>--%>
<!-- left -->
<div class="coupon_middlecontent">
    <!-- coupon left start -->
    <div class="coupon_left">
        <!-- 优惠活动 -->
        <ShopNum1:CouponSaleList ID="CouponSaleList" ShowCount="12" SkinFilename="CouponSaleList.ascx"
            runat="server" />
        <!-- 电子优惠券 -->
        <ShopNum1:Coupons ID="Coupons" ShowCount="3" SkinFilename="Coupons.ascx" runat="server" />
    </div>
    <!-- left end -->
    <!-- coupon right start -->
    <div class="coupon_right">
        <!-- 常见问题 -->
        <ShopNum1:CouponsIsHelp ID="CouponsIsHelp" ArticleCategoryID="154" ShowCount="10"
            SkinFilename="CouponsIsHelp.ascx" runat="server" />
        <!-- 每周人气排行榜 -->
        <div style="clear: both; width: 100%; height: 8px; line-height: 8px; font-size: 8px;
            overflow: hidden;">
        </div>
        <div class="fqa">
            <ShopNum1:CouponsIsHot ID="CouponsIsHot" ShowCount="10" SkinFilename="CouponsIsHot.ascx"
                runat="server" />
        </div>
    </div>
    <!-- right end -->
    <!-- 隔开 -->
    <div class="cle" style="width: 960px; margin: 0 auto; height: 8px; line-height: 8px;
        overflow: hidden; font-size: 8px;">
    </div>
</div>
