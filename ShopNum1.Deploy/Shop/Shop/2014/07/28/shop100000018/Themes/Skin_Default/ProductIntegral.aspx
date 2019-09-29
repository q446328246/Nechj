<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/qzoom.css' />
    <ShopNum1Shop:ScoreProductDetailMeto ID="ScoreProductDetailMeto" runat="server" SkinFilename="ScoreProductDetailMeto.ascx" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--left is start-->
                <div class="sidebar leftn_hot">
                    <!--商品信息-->
                    <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                    <!--商品搜索-->
                    <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
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
                    <!--商品详细-->
                    <ShopNum1Shop:ProductIntegral ID="ProductIntegral" runat="server" SkinFilename="ProductIntegral.ascx" />
                    <!-- tab 切换 -->
                    <div class="tab_qh cp_nvet">
                        <ul>
                            <!-- 注意这里是点了以后的样式,恢复后的就是默认的请看样式看tab_qh ul li -->
                            <li class="selected"><a style="cursor: pointer;" onclick="changeTab(6,1);">
                                商品详细</a></li>
                        </ul>
                    </div>
                    <div class="content" style="clear: both; color:#666666;" runat="server">
                        <!--商品详细-->
                        <ShopNum1Shop:ProductDetailScoreInfo ID="ProductDetailInfo" runat="server" SkinFilename="ProductDetailInfo.ascx" />
                    </div>
                </div>
            </div>
        </div>
        
        
        
        
        <div class="sp_dialog sp_dialog_out" style="display:none;" id="sp_dialog_outDiv">
<!-----积分------>
    <div class="sp_dialog_cont" style="display:none;" id="sp_dialog_contDiv">
        <div class="sp_close">
            <a href="javascript:void(0)" onclick="funClose()"></a>
        </div>
        <ShopNum1Shop:ScoreOrder ID="ScoreOrder" runat="server" SkinFilename="ScoreOrder.ascx" />
    </div>

</div>
<div class="sp_overlay"  style=" display:none" id="sp_overlayDiv">
</div>
        

        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
    <!--js-->

    <script src="Themes/Skin_Default/js/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="Themes/Skin_Default/js/zoom.js" type="text/javascript"></script>

    <script type="text/javascript">
                       	$(document).ready(function(){
			$(function(){			
			   $(".jqzoom").jqueryzoom({
					xzoom:400,
					yzoom:400,
					offset:10,
					position:"right",
					preload:1,
					lens:1
				});
				$("#spec-list").jdMarquee({
					deriction:"left",
					width:300,
					height:67,
					step:2,
					speed:4,
					delay:10,
					control:true,
					_front:"#spec-right",
					_back:"#spec-left"
				});
				$("#spec-list img").bind("mouseover",function(){
					var src=$(this).attr("src");
					$("#spec-n1 img").eq(0).attr({
						src:src.replace("\/n5\/","\/n1\/"),
						jqimg:src.replace("\/n5\/","\/n0\/")
					});
					$(this).css({
						"border":"2px solid #ff6600",
						"padding":"1px"
					});
				}).bind("mouseout",function(){
					$(this).css({
						"border":"1px solid #ccc",
						"padding":"2px"
					});
				});	
				$("#fitting-list").jdMarquee({
					deriction:"left",
					width:(screen.width>=1280)?930:710,
					height:154,
					step:2,
					speed:4,
					delay:10,
					control:true,
					_front:"#fitting-right",
					_back:"#fitting-left"
				});			
			})
			    	
	})
    </script>

    

</body>
</html>
