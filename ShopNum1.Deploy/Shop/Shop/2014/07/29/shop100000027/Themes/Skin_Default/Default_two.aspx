<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="true" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <title>区代专区</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" SkinFilename="SetMeta.ascx" runat="server" />
    <script src="/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            document.title = $(".shopkper").text() + "  " + document.title;
            var defaultOpts = { interval: 5000, fadeInTime: 300, fadeOutTime: 200 };
            //Iterate over the current set of matched elements
            var _titles = $("div.suibian>ul>li");
            var _titles_bg = $("ul.op li");
            var _bodies = $("ul.slide-pic li");
            var _count = _titles.length;
            var _current = 0;
            var _intervalID = null;
            var stop = function () { window.clearInterval(_intervalID); };
            var slide = function (opts) {
                if (opts) {
                    _current = opts.current || 0;
                } else {
                    _current = (_current >= (_count - 1)) ? 0 : (++_current);
                };
                _bodies.filter(":visible").fadeOut(defaultOpts.fadeOutTime, function () {
                    _bodies.eq(_current).fadeIn(defaultOpts.fadeInTime);
                    _bodies.removeClass("cur").eq(_current).addClass("cur");
                });
                _titles.removeClass("cur").eq(_current).addClass("cur");
                _titles_bg.removeClass("cur").eq(_current).addClass("cur");
            }; //endof slide
            var go = function () {
                stop();
                _intervalID = window.setInterval(function () { slide(); }, defaultOpts.interval);
            }; //endof go
            var itemMouseOver = function (target, items) {
                stop();
                var i = $.inArray(target, items);
                slide({ current: i });
            }; //endof itemMouseOver
            _titles.hover(function () { if ($(this).attr('class') != 'cur') { itemMouseOver(this, _titles); } else { stop(); } }, go);
            //_titles_bg.hover(function() { itemMouseOver(this, _titles_bg); }, go);
            _bodies.hover(stop, go);
            //trigger the slidebox
            go();


        })

       
        $(function () {
            $("#divHot").click(function () {
                $("#IsHot_two").show();
                $("#istIsNew_two").hide();
                $("#IsPromotion_two").hide();
                $("#IsRecommend_two").hide();



                $("#divHot").removeClass("TabbedPanelsTab");
                $("#divNew").removeClass("TabbedPanelsTab"); ;
                $("#divPromotion").removeClass("TabbedPanelsTab");
                $("#divRecommend").removeClass("TabbedPanelsTab");

                $("#divHot").removeClass("TabbedPanelsTabSelected");
                $("#divNew").removeClass("TabbedPanelsTabSelected"); ;
                $("#divPromotion").removeClass("TabbedPanelsTabSelected");
                $("#divRecommend").removeClass("TabbedPanelsTabSelected");

                $("#divHot").addClass("TabbedPanelsTabSelected");
                $("#divNew").addClass("TabbedPanelsTab"); ;
                $("#divPromotion").addClass("TabbedPanelsTab");
                $("#divRecommend").addClass("TabbedPanelsTab");

                $("#divHot").removeClass("TabbedPanelsTabSelected2");
                $("#divNew").addClass("TabbedPanelsTabSelected2"); ;
                $("#divPromotion").addClass("TabbedPanelsTabSelected2");
                $("#divRecommend").addClass("TabbedPanelsTabSelected2");
               

               
            })
        })


    $(function () {
        $("#divNew").click(function () {
            $("#istIsNew_two").show();
     $("#IsHot_two").hide();
     $("#IsPromotion_two").hide();
     $("#IsRecommend_two").hide();


     $("#divHot").removeClass("TabbedPanelsTab");
     $("#divNew").removeClass("TabbedPanelsTab"); ;
     $("#divPromotion").removeClass("TabbedPanelsTab");
     $("#divRecommend").removeClass("TabbedPanelsTab");

     $("#divHot").removeClass("TabbedPanelsTabSelected");
     $("#divNew").removeClass("TabbedPanelsTabSelected"); ;
     $("#divPromotion").removeClass("TabbedPanelsTabSelected");
     $("#divRecommend").removeClass("TabbedPanelsTabSelected");

     $("#divHot").addClass("TabbedPanelsTab");
     $("#divNew").addClass("TabbedPanelsTabSelected"); ;
     $("#divPromotion").addClass("TabbedPanelsTab");
     $("#divRecommend").addClass("TabbedPanelsTab");

     $("#divHot").addClass("TabbedPanelsTabSelected2");
     $("#divNew").removeClass("TabbedPanelsTabSelected2"); ;
     $("#divPromotion").addClass("TabbedPanelsTabSelected2");
     $("#divRecommend").addClass("TabbedPanelsTabSelected2");

})
})

$(function () {
    $("#divPromotion").click(function () {
        $("#IsPromotion_two").show();
        $("#IsHot_two").hide();
        $("#istIsNew_two").hide();
        $("#IsRecommend_two").hide();

        $("#divHot").removeClass("TabbedPanelsTab");
        $("#divNew").removeClass("TabbedPanelsTab");;
        $("#divPromotion").removeClass("TabbedPanelsTab");
        $("#divRecommend").removeClass("TabbedPanelsTab");

        $("#divHot").removeClass("TabbedPanelsTabSelected");
        $("#divNew").removeClass("TabbedPanelsTabSelected"); ;
        $("#divPromotion").removeClass("TabbedPanelsTabSelected");
        $("#divRecommend").removeClass("TabbedPanelsTabSelected");

        $("#divHot").addClass("TabbedPanelsTab");
        $("#divNew").addClass("TabbedPanelsTab"); ;
        $("#divPromotion").addClass("TabbedPanelsTabSelected");
        $("#divRecommend").addClass("TabbedPanelsTab");

        $("#divHot").addClass("TabbedPanelsTabSelected2");
        $("#divNew").addClass("TabbedPanelsTabSelected2"); ;
        $("#divPromotion").removeClass("TabbedPanelsTabSelected2");
        $("#divRecommend").addClass("TabbedPanelsTabSelected2");
    })
})
       
        $(function () {
            $("#divRecommend").click(function () {
                $("#IsRecommend_two").show();
     $("#IsHot_two").hide();
     $("#istIsNew_two").hide();
     $("#IsPromotion_two").hide();

     $("#divHot").removeClass("TabbedPanelsTab");
     $("#divNew").removeClass("TabbedPanelsTab"); ;
     $("#divPromotion").removeClass("TabbedPanelsTab");
     $("#divRecommend").removeClass("TabbedPanelsTab");

     $("#divHot").removeClass("TabbedPanelsTabSelected");
     $("#divNew").removeClass("TabbedPanelsTabSelected"); ;
     $("#divPromotion").removeClass("TabbedPanelsTabSelected");
     $("#divRecommend").removeClass("TabbedPanelsTabSelected");

     $("#divHot").addClass("TabbedPanelsTab");
     $("#divNew").addClass("TabbedPanelsTab"); ;
     $("#divPromotion").addClass("TabbedPanelsTab");
     $("#divRecommend").addClass("TabbedPanelsTabSelected");

     $("#divHot").addClass("TabbedPanelsTabSelected2");
     $("#divNew").addClass("TabbedPanelsTabSelected2"); ;
     $("#divPromotion").addClass("TabbedPanelsTabSelected2");
     $("#divRecommend").removeClass("TabbedPanelsTabSelected2");



 })
})


    </script>
    <script type="text/javascript">
        function tab(selfid, targetid, index, count, selfclass, otherclass) {
            for (var i = 0; i < count; i++) {
                if (i == index) {
                    document.getElementById(selfid + i).className = selfclass;
                    document.getElementById(targetid + i).style.display = "block";
                }
                else {
                    document.getElementById(selfid + i).className = otherclass;
                    document.getElementById(targetid + i).style.display = "none";
                }
            }
        }
    </script>
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head Start-->
        <!-- #include file="AgentHead.aspx" -->
        <!--//head End-->
        <div id="content">
            <div id="nav" class="clearfix">
                <div class="nav_cs">
                    <ul>
                    </ul>
                </div>
            </div>
            <!--幻灯-->
            <div id="divflash" class="divflash" runat="server">
            </div>
            <div class="warp clearfix">
                <!--left is start-->
                <div class="sidebar">
                    <!--店铺信息-->
                    <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                    <%--<!--图片-->
                <ShopNum1Shop:ShopCollect ID="ShopCollect" runat="server" SkinFilename="ShopCollect.ascx" />--%>
                    <!--店内搜索-->
                    <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
                    <!--商品分类-->
                    <ShopNum1Shop:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                    <!-- 宝贝排行-->
                    <div class="ks_panel">
                        <div class="storn_hd">
                            <h3>
                                商品排行</h3>
                            <p class="gd_more">
                            </p>
                        </div>
                        <ul class="sellor">
                            <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')">热销宝贝排行</li>
                            <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')">热门收藏排行</li>
                        </ul>
                        <div class="ktlist">
                            <!--热销排行-->
                            <div id="b0" style="display: block">
                                <ShopNum1Shop:ProductListSaleRanking ID="ProductListSaleRanking" runat="server" SkinFilename="ProductListSaleRanking.ascx"
                                    ShowCount="10" />
                            </div>
                            <!--收藏排行-->
                            <div id="b1" style="display: none">
                                <ShopNum1Shop:ProductListCollectRanking ID="ProductListCollectRanking" runat="server"
                                    SkinFilename="ProductListCollectRanking.ascx" ShowCount="10" />
                            </div>
                        </div>
                    </div>
                    <!--友情链接-->
                    <ShopNum1Shop:ShopLink ID="ShopLink" ShowCount="10" runat="server" SkinFilename="ShopLink.ascx" />
                </div>
                <!--right is start-->
                <div class="main">
                    <!--最热-->
                    <%
                        HttpCookie cookie2 = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

                        string MemRankGuid = null;

                        //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
                        if (cookie2 != null)
                        {
                            MemRankGuid = cookie2.Values["MemRankGuid"].ToUpper();
                        }
                        else
                        {
                            MemRankGuid = ShopNum1.Common.ShopNum1.Common.MemberLevel.NORMAL_MEMBER_ID.ToUpper();
                        }

                    %>
                    <ul id="sidebar">
                   <%-- <%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper())
                      {%>
                    <li  id="divHot" class="TabbedPanelsTabSelected2">
                        区代首次</li >
                        <%}%>--%>

                        <%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper() | MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper())
                      {%>
                    <li  id="divNew" class="TabbedPanelsTabSelected2">
                        区代专区</li>
                        <%}%>

                        <%--<%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper())
                      {%>
                    <li  id="divPromotion" class="TabbedPanelsTabSelected2">
                        社区店首次</li >
                        <%}%>

                         <%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper() | MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper())
                      {%>

                    <div id="Div1" >
                    <li  id="divRecommend" class="TabbedPanelsTabSelected2">
                        社区店专区</li>
                        <%}%>--%>

                        </ul>
                        <%--区代首次数据绑定--%>
                   <%-- <%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper())
                      {%>
                    <div id="IsHot_two">
                        <ShopNum1Shop:ProductListIsHot_two ID="productListIsHot_two" ShowCount="1000" runat="server"
                            SkinFilename="productListIsHot_two.ascx" />
                    </div>
                    <%}%>--%>
                    <!--区代专区数据绑定-->
                    <%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper())
                      {%>
                    <div id="istIsNew_two">
                        <ShopNum1Shop:ProductListIsNew_two ID="productListIsNew_two" ShowCount="1000" runat="server"
                            SkinFilename="productListIsNew_two.ascx" />
                    </div>
                    <%}%>
                    <!--社区店专区数据绑定-->
                    <%--<%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper())
                      {%>
                    <div id="IsPromotion_two">
                        <ShopNum1Shop:ProductListIsPromotion_two ID="ProductListIsPromotion_two" runat="server"
                            ShowCount="1000" SkinFilename="ProductListIsPromotion_two.ascx" />
                    </div>
                    <%}%>--%>
                    <!--社区店专区数据绑定-->
                    <%--<%if (MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.AGENT_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper() || MemRankGuid == ShopNum1.Common.ShopNum1.Common.MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper())
                      {%>
                    <div id="IsRecommend_two">
                        <ShopNum1Shop:ProductListIsRecommend_two ID="ProductListIsRecommend_two" runat="server"
                            ShowCount="1000" SkinFilename="ProductListIsRecommend_two.ascx" />
                    </div>
                    <%}%>--%>
                </div>
            </div>
            <ShopNum1Shop:AdvertisementPPT ID="AdvertisementFlash" runat="server" SkinFilename="AdvertisementPPT.ascx"
                divflashid="divflash" flashheight="330" flashwidth="700" BackColor="White" />
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
    <!--[if lte IE 6]>
<script src="/Main/Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
</body>
</html>
