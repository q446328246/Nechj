<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" SkinFilename="SetMeta.ascx" runat="server" />
    <script src="/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(function(){
    document.title=$(".shopkper").text()+"  "+document.title;
var defaultOpts = { interval: 5000, fadeInTime: 300, fadeOutTime: 200 };
//Iterate over the current set of matched elements
	var _titles = $("div.suibian>ul>li");
	var _titles_bg = $("ul.op li");
	var _bodies = $("ul.slide-pic li");
	var _count = _titles.length;
	var _current = 0;
	var _intervalID = null;
	var stop = function() { window.clearInterval(_intervalID); };
	var slide = function(opts) {
		if (opts) {
			_current = opts.current || 0;
		} else {
			_current = (_current >= (_count - 1)) ? 0 : (++_current);
		};
		_bodies.filter(":visible").fadeOut(defaultOpts.fadeOutTime, function() {
			_bodies.eq(_current).fadeIn(defaultOpts.fadeInTime);
			_bodies.removeClass("cur").eq(_current).addClass("cur");
		});
		_titles.removeClass("cur").eq(_current).addClass("cur");
		_titles_bg.removeClass("cur").eq(_current).addClass("cur");
	}; //endof slide
	var go = function() {
		stop();
		_intervalID = window.setInterval(function() { slide(); }, defaultOpts.interval);
	}; //endof go
	var itemMouseOver = function(target, items) {
		stop();
		var i = $.inArray(target, items);
		slide({ current: i });
	}; //endof itemMouseOver
	_titles.hover(function() { if($(this).attr('class')!='cur'){itemMouseOver(this, _titles); }else{stop();}}, go);
	//_titles_bg.hover(function() { itemMouseOver(this, _titles_bg); }, go);
	_bodies.hover(stop, go);
	//trigger the slidebox
	go();


})
    </script>

    <script type="text/javascript">
        function tab(selfid,targetid,index,count,selfclass,otherclass) {
            for(var i=0;i<count;i++) {
                if(i == index) {
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
            <!-- #include file="head.aspx" -->
            
            <!--幻灯-->
            <div id="divflash" class="divflash" runat="server"></div>
            
            <div class="warp clearfix">            
            <!--left is start-->
            <div class="sidebar">
                <!--店铺信息-->
               <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                <!--图片-->
                <ShopNum1Shop:ShopCollect ID="ShopCollect" runat="server" SkinFilename="ShopCollect.ascx" />
                <!--店内搜索-->
                <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
                <!--商品分类-->
                <ShopNum1Shop:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                <!-- 宝贝排行-->
                <div class="ks_panel">
                    <div class="storn_hd">
                        <h3>商品排行</h3>
                        <p class="gd_more"><a href="/ProductSearchList.html">更多>></a></p>
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
                <ShopNum1Shop:ProductListIsHot ID="productListIsHot" ShowCount="8" runat="server"
                    SkinFilename="ProductListIsHot.ascx" />
                <!--最新-->
                <ShopNum1Shop:ProductListIsNew ID="productListIsNew" ShowCount="8" runat="server"
                    SkinFilename="ProductListIsNew.ascx" />
                <!--促销-->
                <ShopNum1Shop:ProductListIsPromotion ID="ProductListIsPromotion" runat="server" ShowCount="8"
                    SkinFilename="ProductListIsPromotion.ascx" />
                 <!--推荐-->
                <ShopNum1Shop:ProductListIsRecommend ID="ProductListIsRecommend" runat="server" ShowCount="8"
                    SkinFilename="ProductListIsRecommend.ascx" />
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
