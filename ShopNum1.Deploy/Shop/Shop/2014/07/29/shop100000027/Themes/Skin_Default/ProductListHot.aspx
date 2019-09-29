<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
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
         <%if (Category=="1"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_bule.css' /> 
         <%}%>  
    <%if (Category=="3"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_Green.css' /> 
         <%}%>  
         <%if (Category=="2"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red_JinSe.css' /> 
         <%}%>  
         <%if (Category=="8"){%>
           
              <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
         <%}%> 
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeta" runat="server" SkinFilename="SetMeta.ascx" />
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
    <skm:Form ID="from1" runat="server" method="post">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--main start-->
                <!--left is start-->
                <div>
                    <div class="sidebar leftn_hot">
                        <!--店铺信息-->
                        <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                        <!--商品搜索-->
                        <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
                        <!--商品分类-->
                        <ShopNum1Shop:ProductCategory ID="productCategory" runat="server" SkinFilename="ProductCategory.ascx" />
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
                    <div class="main">
                        <div class="str_advt">
                            <ShopNum1Shop:Advertisements ID="topadvertisement" runat="server" SkinFilename="Advertisements.ascx" PageName="ProductListHot.aspx"/>
                        </div>
                        <!--商品列表-->
                        <ShopNum1ShopNew:ProductListIsHotMore ID="ProductListIsHotMore" runat="server"  ShowCount="12"
                            SkinFilename="ProductListIsHotMoreNew.ascx" />
                    </div>
                </div>
            </div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </skm:Form>
</body>
</html>
