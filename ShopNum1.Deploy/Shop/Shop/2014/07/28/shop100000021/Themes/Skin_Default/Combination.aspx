<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if lt IE 7]> <html class="ie6 oldie" lang="en"> <![endif]-->
<!--[if IE 7]>    <html class="ie7 oldie" lang="en"> <![endif]-->
<!--[if IE 8]>    <html class="ie8 oldie" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/qzoom.css' />
    <ShopNum1Shop:ShopProductDetailMeto ID="ShopProductDetailMeto" runat="server" SkinFilename="ShopProductDetailMeto.ascx" />
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--left is start-->
                <div class="sidebar leftn_hot">
                    <!--店铺信息-->
                    <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                    <!--图片-->
                    <ShopNum1Shop:ShopCollect ID="ShopCollect" runat="server" SkinFilename="ShopCollect.ascx" />
                    <!--店内搜索-->
                    <ShopNum1Shop:ProduceSearch ID="ProduceSearch1" runat="server" SkinFilename="ProduceSearch.ascx" />
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
                </div>
                <!--main start-->
               
               <div class="main">
                    <ShopNum1Shop:CombinationDetail ID="CombinationDetail" runat="server" SkinFilename="CombinationDetail.ascx" />
                </div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
    <!--js-->
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/zoom.js"></script> 
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/ShopDetail.js"></script>
    <script type="text/javascript" language="javascript">
    jQuery(function($){
	    $('ul.thumb').autoTab();
    });

    jQuery.fn.extend({
	    // 自动切换
	    autoTab: function(){
		    if(this.length <= 0){
			    return false;
		    }
		    var main = this;
		    var ctrls = main.children();
		    var target = main.prev().children();
		    ctrls.bind({
		        mouseover: function(e){
		            var $this = $(this);
		            var index = ctrls.index($this);
		            var Img=$(this).attr("lang");
		            $("#boothPic").html('<img src="'+Img+'_300x300.jpg" style="width:222px;height:222px;" onerror="javascript:this.src=Themes/Skin_Default/Images/noImage.gif" jqimg="'+Img+'" />');
		            ctrls.removeClass('selected');
				    $this.addClass('selected');
				    target.hide().eq(index).show();
		        }
		    });
	    }
    })
    </script>
</body>
</html>
