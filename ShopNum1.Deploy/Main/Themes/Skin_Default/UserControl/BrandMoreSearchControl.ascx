<%@ Control Language="C#" AutoEventWireup="true" %>
<div class="list_left fl">
    <!-- 推荐品牌 -->
    <div class="store_category_view">
        <ShopNum1:BrandListRecommend ID="BrandListRecommend1" runat="server" SkinFilename="BrandListRecommend.ascx"
            ShowCount="8" />
    </div>
    <!--推荐店铺-->
    <ShopNum1:DeShopEspecial ID="DeShopEspecial1" runat="server" SkinFilename="DeShopEspecially.ascx"
        ShopType="IsRecommend" ShowCount="6" />
    <!--商品销售排行-->
    <ShopNum1:DeProductOrder ID="DeProductOrder1" runat="server" SkinFilename="DeProductOrder.ascx"
        OrderType="SaleNumber" ShowCount="4" Title="销售排行" />
</div>
<div class="list_right fr">
    <!-- right -->
    <ShopNum1:BrandAllList ShowCountOne="5" ShowCountTwo="10" ID="BrandAllList" runat="server"
        SkinFilename="BrandAllList.ascx" />
    <!-- right end -->
</div>
