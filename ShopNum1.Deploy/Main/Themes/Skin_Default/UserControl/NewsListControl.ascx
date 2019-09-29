<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ OutputCache Duration="120" Shared="true" VaryByParam="none" %>
<!--家纺资讯 Start-->
<div class="wap_bg clearfix">
    <div class="new_leftborder fl">
        <div id="m_2" class="modbox">
            <div id="m_2_h">
            </div>
            <!--家纺咨询 子分类 more-->
            <ShopNum1:AriticlekeyWords ID="AriticlekeyWords" runat="server" CateforyID="41" ShowCount="10"
                SkinFilename="AriticlekeyWords.ascx" />
        </div>
        <div class="plate">
            <div id="m_3" class="modbox">
                <div id="m_3_h">
                </div>
                <div class="ad fl">
                    <%--       <asp:Image ID="Image3" runat="server" ImageUrl="~/Main/Themes/Skin_Default/Images/new_leftad.png"
                        Width="277" Height="373" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="88" SkinFilename="AdSimpleImage.ascx" />
                </div>
            </div>
            <div class="content fr">
                <div id="m_4" class="modbox">
                    <div id="m_4_h">
                    </div>
                    <!--国内资讯头条-->
                    <ShopNum1:ArticleByCategoryIdInOrder Sort="CreateTime" ArticleCategoryID="41" ShowCount="4"
                        ID="ArticleByCategoryIdInOrder" runat="server" SkinFilename="ArticleByCategoryIdInOrder.ascx" />
                </div>
                <div id="m_5" class="modbox">
                    <div id="m_5_h">
                    </div>
                    <!--国内资讯资讯推荐-->
                    <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend1" runat="server"
                        ISType="IsRecommend" CateforyID="41" ShowCount="6" SkinFilename="AriticleIsHotorIsRecommend.ascx" />
                </div>
            </div>
        </div>
    </div>
    <div class="new_rightborder fr father">
        <div id="m_6" class="modbox">
            <div id="m_6_h">
            </div>
            <!--国内热点资讯-->
            <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend2" runat="server"
                ISType="IsHot" CateforyID="41" ShowCount="10" SkinFilename="AriticleIsHotorIsRecommend1.ascx" />
        </div>
    </div>
</div>
<!--//家纺资讯 End-->
<!--广告位 Start-->
<div id="m_7" class="modbox">
    <div id="m_7_h">
    </div>
    <div class="index_ad01">
        <div id="AD20100821191908">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="29" SkinFilename="AdSimpleImage.ascx" />
        </div>
    </div>
</div>
<!--//广告位 End-->
<!--女装资讯 Start-->
<div class="wap_bg clearfix">
    <div class="new_leftborder fl father">
        <div id="m_8" class="modbox">
            <div id="m_8_h">
            </div>
            <!--开店技巧关键字-->
            <ShopNum1:AriticlekeyWords ID="AriticlekeyWords1" runat="server" CateforyID="44"
                ShowCount="10" SkinFilename="AriticlekeyWords1.ascx" />
        </div>
        <div class="plate">
            <div id="m_9" class="modbox">
                <div id="m_9_h">
                </div>
                <div class="ad1 fl">
                    <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/Main/Themes/Skin_Default/Images/new_leftad1.png"
                         Width="277" Height="373" BorderWidth="0px" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="89" SkinFilename="AdSimpleImage.ascx" />
                </div>
            </div>
            <div class="content fr">
                <div id="m_10" class="modbox">
                    <div id="m_10_h">
                    </div>
                    <!--开店技巧头条-->
                    <ShopNum1:ArticleByCategoryIdInOrder Sort="CreateTime" ArticleCategoryID="44" ShowCount="4"
                        ID="ArticleByCategoryIdInOrder1" runat="server" SkinFilename="ArticleByCategoryIdInOrder1.ascx" />
                </div>
                <div id="m_11" class="modbox">
                    <div id="m_11_h">
                    </div>
                    <!--开店技巧资讯推荐-->
                    <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend3" runat="server"
                        ISType="IsRecommend" CateforyID="44" ShowCount="6" SkinFilename="AriticleIsHotorIsRecommend01.ascx" />
                </div>
            </div>
        </div>
    </div>
    <div class="new_rightborder fr father">
        <div id="m_12" class="modbox">
            <div id="m_12_h">
            </div>
            <!--开店技巧热点资讯-->
            <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend4" runat="server"
                ISType="IsHot" CateforyID="44" ShowCount="10" SkinFilename="AriticleIsHotorIsRecommend11.ascx" />
        </div>
    </div>
</div>
<!--//女装资讯 End-->
<!--广告位 Start-->
<div id="m_13" class="modbox">
    <div id="m_13_h">
    </div>
    <div class="index_ad01">
        <div id="Div1">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="30" SkinFilename="AdSimpleImage.ascx" />
        </div>
    </div>
</div>
<!--//广告位 End-->
<!--男装资讯 Start-->
<div class="wap_bg clearfix">
    <div class="new_leftborder fl father">
        <div id="m_14" class="modbox">
            <div id="m_14_h">
            </div>
            <!--系统分类关键字-->
            <ShopNum1:AriticlekeyWords ID="AriticlekeyWords2" runat="server" CateforyID="45"
                ShowCount="10" SkinFilename="AriticlekeyWords2.ascx" />
        </div>
        <div class="plate">
            <div id="m_15" class="modbox">
                <div id="m_15_h">
                </div>
                <div class="ad2 fl">
                    <%-- <asp:Image ID="Image2" runat="server" ImageUrl="~/Main/Themes/Skin_Default/Images/new_leftad2.png"
                         Width="277" Height="373" BorderWidth="0px" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage87" runat="server" AdImgId="87" SkinFilename="AdSimpleImage.ascx" />
                </div>
            </div>
            <div class="content fr">
                <div id="m_16" class="modbox">
                    <div id="m_16_h">
                    </div>
                    <!--系统分类头条-->
                    <ShopNum1:ArticleByCategoryIdInOrder Sort="CreateTime" ArticleCategoryID="45" ShowCount="4"
                        ID="ArticleByCategoryIdInOrder2" runat="server" SkinFilename="ArticleByCategoryIdInOrder2.ascx" />
                </div>
                <div id="m_17" class="modbox">
                    <div id="m_17_h">
                    </div>
                    <!--系统分类资讯推荐-->
                    <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend5" runat="server"
                        ISType="IsRecommend" CateforyID="45" ShowCount="6" SkinFilename="AriticleIsHotorIsRecommend02.ascx" />
                </div>
            </div>
        </div>
    </div>
    <div class="new_rightborder fr father">
        <div id="m_18" class="modbox">
            <div id="m_18_h">
            </div>
            <!--系统分类热点资讯-->
            <ShopNum1:AriticleIsHotorIsRecommend ID="AriticleIsHotorIsRecommend6" runat="server"
                ISType="IsHot" CateforyID="45" ShowCount="10" SkinFilename="AriticleIsHotorIsRecommend12.ascx" />
        </div>
    </div>
</div>
<!--//男装资讯 End-->
