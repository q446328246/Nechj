<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ OutputCache Duration="120" Shared="true" VaryByParam="none" %>
<!-- 推荐 广告 注册 -->
<div class="rec">
    <!-- 推荐店铺 -->
    <ShopNum1:ShopThreeRecommend ID="ShopThreeRecommend1" runat="server" SkinFilename="ShopThreeRecommend.ascx"
        ShowCount="3" ShopType="IsRecommend" />
    <!-- 播放幻灯 -->
    <ShopNum1:AdvertisementPPT ID="AdvertisementPPT" runat="server" SkinFilename="AdvertisementPPTTwo.ascx"
        AdID="ad1" AdType="2" />
    <!-- 右边注册新闻 -->
    <div class="re_new">
        <!-- regesit -->
        <div class="re_new_re">
            <ul>
                <li class="fl"><a href="<%=ShopUrlOperate.RetUrl("MemberRegister")%>">会员注册</a></li>
                <li class="fr"><a href="<%=ShopUrlOperate.RetUrl("Login")%>">会员登陆</a></li>
                <li class="fl"><a href='<%=ShopUrlOperate.RetUrl("index")%>'>我要开店</a></li>
                <li class="fr"><a href='<%=ShopUrlOperate.RetUrl("ArticleDetail","4a65781b-283e-4a37-a511-e27df5d9bd05")%>'
                    target="_blank">如何开店</a></li>
            </ul>
        </div>
        <div class="re_new_adv">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="15" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <!-- 商城公告 -->
        <ShopNum1:ShopAnnouncement ID="ShopAnnouncement" runat="server" SkinFilename="ShopAnnouncement.ascx"
            ShowCategory="15" />
    </div>
    <div style="clear: both; width: 900px; height: 1px; line-height: 1px; overflow: hidden;
        font-size: 1px;">
    </div>
</div>
<!-- product -->
<ShopNum1:ShopShowRecommendCategory ID="ShopShowRecommendCategory1" runat="server"
    SkinFilename="ShopShowRecommendCategory.ascx" ShowCountOne="5" ShowCountTwo="3" />
<div class="adv5" style="clear: both">
    <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="14" SkinFilename="AdSimpleImage.ascx" />
</div>
<!-- 最新推荐店铺 -->
<ShopNum1:ShopIsNewShowDiff ID="ShopIsNewShowDiff" runat="server" SkinFilename="ShopIsNewShowDiff.ascx"
    ShowCount="8" />
<!-- right end -->
<div class="adv5 cle" style="clear: both">
    <ShopNum1:AdSimpleImage ID="AdSimpleImage4" runat="server" AdImgId="17" SkinFilename="AdSimpleImage.ascx" />
    <!-- 知名店铺 -->
    <div class="nsnp">
        <div class="nsnp_de" style="float: left; border: 3px solid #226C0D;">
            <ShopNum1:ShopIsCategoryShow ID="ShopIsCategoryShow1" runat="server" SkinFilename="ShopIsHotShow.ascx"
                ShowCount="8" ShowType="IsHot" />
            <ShopNum1:ShopIsCategoryShowDiff ID="ShopIsCategoryShowDiff2" runat="server" SkinFilename="ShopIsHotShowDiff.ascx"
                ShowCount="12" ShowType="IsHot" />
        </div>
        <div class="adv9" style="float: right; padding-left: 8px; padding-right: 0;">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="16" SkinFilename="AdSimpleImage.ascx" />
        </div>
    </div>
    <!-- right end -->
    <!-- 隔开 -->
    <div class="cle" style="width: 960px; margin: 0 auto; height: 8px; clear: both; line-height: 8px;
        overflow: hidden; font-size: 8px;">
    </div>
    <!-- right -->
</div>
