<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>网站编辑模式</title>
    <ShopNum1:DefaultAdminCheck ID="DefaultAdminCheck" runat="server" SkinFilename="DefaultAdminCheck.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="head.aspx" -->
    <div id="AllDiv" style="position: absolute; z-index: 2; left: 0; top: 0; right: 0;
        background-color: #777; filter: Alpha(Opacity=60); opacity: 0.6; -moz-opacity: 0.6;
        margin: 1px 1px; display: none; width: 100%; height: 100%; text-align: center;">
    </div>
    <div id="ContentDiv" style="position: absolute !important; overflow: hidden; left: 30%;
        top: 0px; z-index: 3; background-color: #fff; margin: 100px auto; padding: 0px;
        display: none; width: 360px; height: 320px; text-align: left; padding: 20px;
        background: url(Themes/Skin_Default/Images/tckbg.png); _background: url(Themes/Skin_Default/Images/tckbg.gif);">
        <div style="float: right; width: 100%; text-align: right; margin-bottom: 10px; _margin-bottom: 2px;">
            <a style="position: relative; top: -5px" href="javascript:void(0)" onclick="CloseImgWindow()">
                <img src="Themes/Skin_Default/Images/clo1.jpg" /></a></div>
        <div style="clear: both; position: relative; _top: -15px;">
            <img id="contentImg" src="" width="150" height="100" />
        </div>
        <div class="tabledsa" style="position: relative; _top: -13px;">
            <table>
                <tr>
                    <td align="right">
                        广告ID：
                    </td>
                    <td>
                        <input id="textImgID" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        广告尺寸(长*宽)：
                    </td>
                    <td>
                        <span id="spanImgSize"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        名称：
                    </td>
                    <td>
                        <input id="textImgName" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        链接地址：
                    </td>
                    <td>
                        <input type="text" id="textImgLink" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        图片：
                    </td>
                    <td>
                        <input type="text" value="" id="textImgSrc" />
                        <input type="button" value="上传" onclick="openSingleChild()" />
                    </td>
                </tr>
                <tr>
                    <td colspan="20">
                        <div style="display: inline;">
                            <input type="button" style="border: none; background: #000; color: #FFF; padding: 5px;
                                position: relative; top: -5px;" value="保存" onclick="saveAdImgInfo()" /></div>
                        <div id="DivImgMsg" style="font-size: 13px; position: relative; top: -8px; color: #D40000;
                            display: inline;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clearmiddle" style="padding: 10px; width: 960px;">
        <!-- left -->
        <div class="left fl">
            <!--广告列表-->
            <!-- 切换广告 -->
            <ShopNum1:DefaultAdvertisement ID="DefaultAdvertisement" runat="server" SkinFilename="DefaultAdvertisement.ascx" />
            <!-- 资讯和自定义栏 -->
            <div class="infolist fr">
                <ShopNum1:ArticleNewList ID="ArticleNewList" runat="server" SkinFilename="ArticleNewList.ascx" />
                <ShopNum1:ArticleList ID="ArticleList1" runat="server" SkinFilename="ArticleList.ascx" />
            </div>
            <div style="clear: both; width: 715px; height: 8px; line-height: 8px; overflow: hidden;">
            </div>
            <!-- 最新，热卖，推荐，精品 -->
            <div class="four01">
                <div class="four01_top">
                    <div class="four01_top_left fl">
                        <ul>
                            <li id="lp1" onmouseover="changeProduct(1)" style="background: url(Themes/Skin_Default/Images/tab_bg2.gif) center no-repeat">
                                <a href="javascript:void(0)">最新商品</a></li>
                            <li id="lp2" onmouseover="changeProduct(2)"><a href="javascript:void(0)">热卖商品</a></li>
                            <li id="lp3" onmouseover="changeProduct(3)"><a href="javascript:void(0)">推荐商品</a></li>
                            <li id="lp4" onmouseover="changeProduct(4)"><a href="javascript:void(0)">精品商品</a></li>
                        </ul>
                    </div>
                    <div class="new_info_title_right fr">
                        <a href='<%=ShopUrlOperate.RetUrl("ProductListSearch")%>'>更多>></a></div>
                </div>
                <!-- tab最新商品 -->
                <div id="div1">
                    <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach1" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                        ProductType="IsShopNew" ShowCount="14" />
                </div>
                <!-- tab热卖商品 -->
                <div id="div2" style="display: none">
                    <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach2" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                        ProductType="IsShopHot" ShowCount="14" />
                </div>
                <!-- tab推荐商品 -->
                <div id="div3" style="display: none">
                    <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach3" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                        ProductType="IsShopRecommend" ShowCount="14" />
                </div>
                <!-- tab精品商品 -->
                <div id="div4" style="display: none">
                    <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach4" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                        ProductType="IsShopGood" ShowCount="14" />
                </div>
            </div>
            <!-- adv01 -->
            <div style="clear: both; width: 715px; padding-top: 8px;">
                <a href="javascript:void(0)">
                    <img width="715" height="80" src="Themes/Skin_Default/Images/adv1.jpg" /></a>
            </div>
            <!--四大分类 -->
            <div class="supply">
                <div class="supply_top">
                    <div class="supply_top_left fl">
                        <ul>
                            <li id="lc1" onmouseover="changeCategory(1)" style="background: url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat;">
                                <a href="javascript:void(0)" id="lac1" style="color: #FFFFFF">商品分类</a></li>
                            <li id="lc2" onmouseover="changeCategory(2)"><a href="javascript:void(0)" id="lac2">
                                店铺分类</a></li>
                            <li id="lc3" onmouseover="changeCategory(3)"><a href="javascript:void(0)" id="lac3">
                                供求分类</a></li>
                            <li id="lc4" onmouseover="changeCategory(4)"><a href="javascript:void(0)" id="lac4">
                                信息分类</a></li>
                        </ul>
                    </div>
                    <div class="new_info_title_right fr">
                    </div>
                </div>
                <!--商品分类-->
                <div id="divc1" style="display: block;">
                    <ShopNum1:DeProductCategory ID="DeProductCategory" runat="server" SkinFilename="DeProductCategory.ascx"
                        ShowCountOne="9" ShowCountTwo="5" />
                </div>
                <!--店铺分类-->
                <div id="divc2" style="display: none;">
                    <ShopNum1:DeShopCategory ID="DeShopCategory" runat="server" SkinFilename="DeShopCategory.ascx"
                        ShowCountOne="9" ShowCountTwo="5" />
                </div>
                <!--供求分类-->
                <div id="divc3" style="display: none;">
                    <ShopNum1:DeSupplyDemandCategory ID="DeSupplyDemandCategory" runat="server" SkinFilename="DeSupplyDemandCategory.ascx"
                        ShowCountOne="9" ShowCountTwo="5" />
                </div>
                <!--信息分类-->
                <div id="divc4" style="display: none;">
                    <ShopNum1:DeCategoryInfoCategory ID="DeCategoryInfoCategory" runat="server" SkinFilename="DeCategoryInfoCategory.ascx"
                        ShowCountOne="9" ShowCountTwo="5" />
                </div>
            </div>
            <!-- 	供求分类 -->
            <div class="supply">
                <div class="supply_top">
                    <div class="supply_top_left fl">
                        <ul>
                            <li id="ld1" onmouseover="changeGq(1)" style="background: url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat">
                                <a href="javascript:void(0)" id="lad1" style="color: #FFFFFF">交易市场</a></li>
                            <li id="ld2" onmouseover="changeGq(2)"><a href="javascript:void(0)" id="lad2">求购市场</a></li>
                            <li id="ld3" onmouseover="changeGq(3)"><a href="javascript:void(0)" id="lad3">租房市场</a></li>
                            <li id="ld4" onmouseover="changeGq(4)"><a href="javascript:void(0)" id="lad4">供货市场</a></li>
                        </ul>
                    </div>
                    <div class="new_info_title_right fr">
                        <a href='<%=ShopUrlOperate.RetUrl("SupplyDemandListSearch")%>'>更多>></a></div>
                </div>
                <!-- 供求四大分类 -->
                <div class="supply_demand" id="divd1" style="display: block">
                    <ShopNum1:DeSupplyDemandDetail ID="DeSupplyDemandDetail1" runat="server" ShowCount="6"
                        SkinFilename="DeSupplyDemandDetail.ascx" code="004" />
                </div>
                <div class="supply_demand" id="divd2">
                    <ShopNum1:DeSupplyDemandDetail ID="DeSupplyDemandDetail2" runat="server" ShowCount="6"
                        SkinFilename="DeSupplyDemandDetail.ascx" code="005" />
                </div>
                <div class="supply_demand" id="divd3">
                    <ShopNum1:DeSupplyDemandDetail ID="DeSupplyDemandDetail3" runat="server" ShowCount="6"
                        SkinFilename="DeSupplyDemandDetail.ascx" code="008" />
                </div>
                <div class="supply_demand" id="divd4">
                    <ShopNum1:DeSupplyDemandDetail ID="DeSupplyDemandDetail4" runat="server" ShowCount="6"
                        SkinFilename="DeSupplyDemandDetail.ascx" code="007" />
                </div>
            </div>
            <!-- 	资讯分类 -->
            <div class="supply">
                <div class="supply_top">
                    <div class="supply_top_left fl">
                        <ul>
                            <li id="le1" onmouseover="changeAC(1)" style="background: url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat">
                                <a href="javascript:void(0)" id="lae1" style="color: #FFFFFF">资讯分类一</a></li>
                            <li id="le2" onmouseover="changeAC(2)"><a href="javascript:void(0)" id="lae2">资讯分类二</a></li>
                            <li id="le3" onmouseover="changeAC(3)"><a href="javascript:void(0)" id="lae3">资讯分类三</a></li>
                            <li id="le4" onmouseover="changeAC(4)"><a href="javascript:void(0)" id="lae4">资讯分类四</a></li>
                        </ul>
                    </div>
                    <div class="new_info_title_right fr">
                        <a href='<%=ShopUrlOperate.RetUrl("ArticleListSearch")%>'>更多>></a></div>
                </div>
                <div class="supply_demand" id="dive1" style="display: block;">
                    <ShopNum1:DeArticleCategoryDetail ID="DeArticleCategoryDetail1" runat="server" SkinFilename="DeArticleCategoryDetail.ascx"
                        CategoryID="41" />
                </div>
                <div class="supply_demand" id="dive2">
                    <ShopNum1:DeArticleCategoryDetail ID="DeArticleCategoryDetail2" runat="server" SkinFilename="DeArticleCategoryDetail.ascx"
                        CategoryID="44" />
                </div>
                <div class="supply_demand" id="dive3">
                    <ShopNum1:DeArticleCategoryDetail ID="DeArticleCategoryDetail3" runat="server" SkinFilename="DeArticleCategoryDetail.ascx"
                        CategoryID="45" />
                </div>
                <div class="supply_demand" id="dive4">
                    <ShopNum1:DeArticleCategoryDetail ID="DeArticleCategoryDetail4" runat="server" SkinFilename="DeArticleCategoryDetail.ascx"
                        CategoryID="60" />
                </div>
            </div>
        </div>
        <!-- right -->
        <div class="right fr">
            <!-- 会员登陆 -->
            <div class="menber">
                <div class="menber2">
                    <div class="menber_top">
                        <span class="fl">
                            <img src="Themes/Skin_Default/Images/login1.jpg" /></span><a class="fr" href='<%=ShopUrlOperate.RetUrl("Login")%>'><img
                                src="Themes/Skin_Default/Images/login2.jpg" /></a></div>
                    <div class="login1">
                        <ul class="title">
                            <li class="marginLeft cur"><a href='<%=ShopUrlOperate.RetUrl("MemberRegister") %>'>个人注册</a></li>
                            <li><a href='<%=ShopUrlOperate.RetUrl("login") %>'>个人登录</a></li>
                        </ul>
                        <ul class="content">
                            <li class="cur1" style="display: block"><a href='<%=ShopUrlOperate.RetUrl("MemberRegister") %>'>
                                轻松亲历生活网上行</a></li>
                            <li class="cur2"><a href='<%=ShopUrlOperate.RetUrl("login") %>'>发信息 做点评，精彩无限！</a></li>
                        </ul>
                        <ul class="title">
                            <li class="marginLeft"><a href='<%=ShopUrlOperate.RetUrl("MemberRegister") %>'>商家注册</a></li>
                            <li><a href='<%=ShopUrlOperate.RetUrl("login") %>'>商家登录</a></li>
                        </ul>
                        <ul class="content">
                            <li class="cur1"><a href='<%=ShopUrlOperate.RetUrl("MemberRegister") %>'>立马获得网商通行证</a></li>
                            <li class="cur2"><a href='<%=ShopUrlOperate.RetUrl("login") %>'>发商机 立信用，商机无限！</a></li>
                        </ul>
                        <ul class="title">
                            <li class="marginLeft"><a href='<%=ShopUrlOperate.RetUrl("login") %>'>推广公司</a></li>
                            <li><a href='<%=ShopUrlOperate.RetUrl("login") %>'>发布商机</a></li>
                        </ul>
                        <ul class="content">
                            <li class="cur1"><a href='<%=ShopUrlOperate.RetUrl("login") %>'>一站式电子商务解决方案</a></li>
                            <li class="cur2"><a href='<%=ShopUrlOperate.RetUrl("login") %>'>便捷发商机，轻松拿订单</a></li>
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <!-- 最新公告 -->
            <ShopNum1:AnnouncementNewList ID="AnnouncementNewList" runat="server" SkinFilename="AnnouncementNewList.ascx" />
            <!-- 明星店铺 -->
            <div class="announcements">
                <div class="announ_top">
                    <ul>
                        <li id="lf1" onmouseover="changeSC(1)" style="background: #d40000; color: #FFFFFF;">
                            明星店铺</li>
                        <li id="lf2" onmouseover="changeSC(2)">最新 </li>
                        <li id="lf3" onmouseover="changeSC(3)">人气</li>
                        <li id="lf4" onmouseover="changeSC(4)">推荐</li>
                    </ul>
                </div>
                <div id="divf1" style="display: block">
                    <ShopNum1:DeShopEspecialSearch ID="DeShopEspecialSearch1" runat="server" SkinFilename="DeShopEspeciallySearch.ascx"
                        ShopType="IsHot" />
                </div>
                <div id="divf2" style="display: none">
                    <ShopNum1:DeShopIsNew ID="DeShopIsNew" runat="server" SkinFilename="DeShopIsNew.ascx" />
                </div>
                <div id="divf3" style="display: none">
                    <ShopNum1:DeShopEspecialSearch ID="DeShopEspecialSeach2" runat="server" SkinFilename="DeShopEspeciallySearch.ascx"
                        ShopType="IsVisits" />
                </div>
                <div id="divf4" style="display: none">
                    <ShopNum1:DeShopEspecialSearch ID="DeShopEspecialSeach3" runat="server" SkinFilename="DeShopEspeciallySearch.ascx"
                        ShopType="IsRecommend" />
                </div>
            </div>
            <!-- advertisement -->
            <div class="adv2 cle" style="padding-bottom: 0;">
                <a href="javascript:void(0)">
                    <img width="239" height="121" src="Themes/Skin_Default/Images/adv2.jpg" />
                </a>
            </div>
            <!-- 推荐品牌 -->
            <div class="announcements" style="padding-bottom: 0;">
                <div class="brand_best">
                    <img width="55" height="55" src="Themes/Skin_Default/Images/brandbest.gif" /></div>
                <div class="announ_top">
                    <div class="fl">
                        <img src="Themes/Skin_Default/Images/brand1.jpg" /></div>
                    <div class="fr" style="padding-top: 9px; padding-right: 45px;">
                        <a href='<%=ShopUrlOperate.RetUrl("BrandMoreSearch")%>'>更多>></a></div>
                </div>
                <ShopNum1:DeBrandList ID="DeBrandList1" runat="server" SkinFilename="DeBrandList.ascx" />
            </div>
            <!-- advertisement -->
            <div class="adv3">
                <img width="240" height="158" src="Themes/Skin_Default/Images/adv03.jpg" /></div>
        </div>
        <!-- 兼容性隔开 -->
        <div style="clear: both; height: 8px; line-height: 8px; font-size: 8px; overflow: hidden;
            width: 960px;">
        </div>
        <!-- bottom advertisement -->
        <div class="adv4 cle" style="clear: both;">
            <img src="Themes/Skin_Default/Images/adv4.jpg" /></div>
        <!-- 二手 房屋 交友 工作 -->
        <div class="four_supply cle fl">
            <!-- 二手 -->
            <div class="secondhand fl">
                <div class="secondhand1">
                    <div class="secondhand_top">
                        <div class="fl">
                            <img src="Themes/Skin_Default/Images/line_bg02.gif" /></div>
                        <div class="fr more1">
                            <a href="CategoryListSearch.aspx">更多</a>>></div>
                    </div>
                    <div class="secondhand_content">
                        <img width="215" height="102" src="Themes/Skin_Default/Images/adv5.jpg" /><br />
                        <center>
                            <a href="javascript:void(0)">[线上活动]分享好用的护肤化妆品</a></center>
                        <ShopNum1:DeCategoryDetail ID="DeCategoryDetail1" runat="server" SkinFilename="DeCategoryDetail.ascx"
                            code="001" ShowCount="4" />
                    </div>
                </div>
            </div>
            <!-- 房屋 -->
            <div class="secondhand fl">
                <div class="secondhand1">
                    <div class="secondhand_top">
                        <div class="fl">
                            <img src="Themes/Skin_Default/Images/line_bg03.gif" /></div>
                        <div class="fr more1">
                            <a href='<%=ShopUrlOperate.RetUrl("CategoryListSearch")%>'>更多</a>>></div>
                    </div>
                    <div class="secondhand_content">
                        <ShopNum1:DeCategoryDetail ID="DeCategoryDetail2" runat="server" SkinFilename="DeCategoryDetail.ascx"
                            code="006" ShowCount="4" />
                        <div class="secondhand_img fl">
                            <img width="95" height="116" src="Themes/Skin_Default/Images/adv6.jpg" /><div class="secondhand_img_font">
                                <a href="javascript:void(0)">清爽北欧风</a></div>
                        </div>
                        <div class="secondhand_img fr">
                            <img width="95" height="116" src="Themes/Skin_Default/Images/adv7.jpg" /><div class="secondhand_img_font">
                                <a href="javascript:void(0)">清爽北欧风</a></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- 交友 -->
            <div class="secondhand fl">
                <div class="secondhand1">
                    <div class="secondhand_top">
                        <div class="fl">
                            <img src="Themes/Skin_Default/Images/line_bg04.gif" /></div>
                        <div class="fr more1">
                            <a href='<%=ShopUrlOperate.RetUrl("CategoryListSearch")%>'>更多</a>>></div>
                    </div>
                    <div class="secondhand_content">
                        <img width="215" height="102" src="Themes/Skin_Default/Images/adv5.jpg" /><br />
                        <center>
                            <a href="javascript:void(0)">[线上活动]分享好用的护肤化妆品</a></center>
                        <ShopNum1:DeCategoryDetail ID="DeCategoryDetail3" runat="server" SkinFilename="DeCategoryDetail.ascx"
                            code="007" ShowCount="4" />
                    </div>
                </div>
            </div>
            <!-- 工作 -->
            <div class="secondhand fl" style="padding-right: 0;">
                <div class="secondhand1">
                    <div class="secondhand_top">
                        <div class="fl">
                            <img src="Themes/Skin_Default/Images/line_bg05.gif" /></div>
                        <div class="fr more1">
                            <a href="<%=ShopUrlOperate.RetUrl("CategoryListSearch")%>">更多</a>>></div>
                    </div>
                    <div class="secondhand_content">
                        <img width="215" height="102" src="Themes/Skin_Default/Images/adv8.jpg" /><br />
                        <center>
                            <a href="javascript:void(0)">[线上活动]分享好用的护肤化妆品</a></center>
                        <ShopNum1:DeCategoryDetail ID="DeCategoryDetail4" runat="server" SkinFilename="DeCategoryDetail.ascx"
                            code="008" ShowCount="4" />
                    </div>
                </div>
            </div>
        </div>
        <!-- help list -->
        <!-- help list end -->
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
    <!--js-->
    <ShopNum1:DeCategoryDetail ID="DeCategoryDetail5" runat="server" SkinFilename="DeCategoryDetail.ascx" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="Themes/Skin_Default/js/defaultDivChange.js" type="text/javascript"></script>
    <script src="Themes/Skin_Default/js/Default.js" type="text/javascript"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/DefaultEdit.js"></script>
</body>
</html>
