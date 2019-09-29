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
     <%
        string Category = "1";
        if (Page.Request.QueryString["category"] != null)
        {
            Category = Page.Request.QueryString["category"];
        }
        else if (Page.Request.Cookies["category"] !=null)
        {
            Category = Page.Request.Cookies["category"].Value;
        }
        
        
         %>
         <%
             if (Category=="1"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_bule.css' /> 
         <%}%>  
    <%
        if (Category=="3"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_Green.css' /> 
         <%}%>  
         <%
             if (Category=="2"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_JinSe.css' /> 
         <%}%>   
         <%
             if (Category=="4"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
         <%}%> 
         <%
             if (Category =="5"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
         <%}%> 
         <%
             if (Category =="6"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
         <%}%> 
         <%
             if (Category =="7"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
         <%}%> 

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
                    <%--<ShopNum1Shop:ShopCollect ID="ShopCollect" runat="server" SkinFilename="ShopCollect.ascx" />--%>
                    <!--店内搜索-->
                    <ShopNum1Shop:ProduceSearch ID="ProduceSearch1" runat="server" SkinFilename="ProduceSearch.ascx" />
                    <!--商品分类-->
                    <ShopNum1Shop:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                    <!-- 宝贝排行-->
                    <div class="ks_panel">
                        <div class="storn_hd">
                            <h3>商品排行</h3>
                            <p class="gd_more"></p>
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
                    <ShopNum1Shop:ProductDetail ID="ProductDetail" runat="server" SkinFilename="ProductDetail.ascx" />
                    <!-- tab 切换 -->
                    <div class="tab_qh">
                        <ul>
                            <!-- 注意这里是点了以后的样式,恢复后的就是默认的请看样式看tab_qh ul li -->
                           
                            <li id="current1" class="selected"><a onclick="changeTab(4,1);">商品详细</a></li>
                            <li id="current2"><a onclick="changeTab(4,2);">商品评论</a></li>
                            <li id="current3"><a onclick="changeTab(4,3);">订单记录</a></li>
                            <li id="current4"><a onclick="changeTab(4,4);">在线留言</a></li>
                        </ul>
                    </div>
                    <div class="content tab_con" id="content1" style="display:block;">
                        <!--商品详细-->
                        <div class="aBox11 clearfix">
                            <div class="content">
                                <ShopNum1ShopNew:ProductProp_V82 ID="ProductProp_V82" runat="server" SkinFilename="ProductProp_V82.ascx" />
                            </div>
                        </div>
                    </div>
                    <div class="content tab_con" id="content2">
                        <!--商品评论-->
                        <ShopNum1Shop:ProductCommentList ID="ProductCommentList" Type="1" runat="server" SkinFilename="ProductCommentList.ascx" PageCount="1" />
                    </div>
                    <div class="content tab_con" id="content3">
                        <!--订单记录-->
                        <ShopNum1Shop:ProductOrderRecord ID="ProductOrderRecord" runat="server" SkinFilename="ProductOrderRecord.ascx"
                            PageCount="10" />
                    </div>
                    <div class="content  tab_con" id="content4">
                        <!-- 在线留言 -->
                        <ShopNum1Shop:ProductConsultList ID="ProductConsultList" ShowCount="5" runat="server" SkinFilename="ProductConsultList.ascx" />
                        <ShopNum1Shop:ProductConsultListAdd ID="ProductConsultListAdd" runat="server" SkinFilename="ProductConsultListAdd.ascx" />
                    </div>
                </div>
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
</body>
</html>
