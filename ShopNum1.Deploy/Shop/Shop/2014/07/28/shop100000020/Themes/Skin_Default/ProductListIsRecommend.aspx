<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="false"%>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" runat="server" SkinFilename="SetMeta.ascx" />
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
      <skm:Form ID="Form1" method="post" runat="server">
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="content">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <!--main start-->
            <!--left is start-->
            <div class="sidebar leftn_hot">
                <!--店铺信息-->
                <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                <!--商品搜索-->
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
            </div>
            <!--Right start-->
            <div class="main">
                <div class="str_advt">
                     <ShopNum1Shop:Advertisements ID="topadvertisement" runat="server" SkinFilename="Advertisements.ascx" PageName="ProductListPromotion.aspx"/>
                </div>
                <!--热销商品列表-->
                <ShopNum1ShopNew:ProductListIsRecommendMoreNew ID="ProductListIsRecommendMoreNew" runat="server" SkinFilename="ProductListIsRecommendMoreNew.ascx" ShowCount="12" />
            </div>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
   </skm:Form>
</body>
</html>
