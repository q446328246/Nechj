<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto1" runat="server" SkinFilename="SetMeta.ascx" />
    
     <script type="text/javascript">
function show_date_time(time, element){
        window.setTimeout("show_date_time('"+time+"','"+element+"')", 1000);       
        BirthDay = new Date(time);
        today=new Date(); 
        timeold=(BirthDay.getTime()-today.getTime()); 
        sectimeold=timeold/1000 
        secondsold=Math.floor(sectimeold); 
        msPerDay=24*60*60*1000 
        e_daysold=timeold/msPerDay 
        daysold=Math.floor(e_daysold); 
        e_hrsold=(e_daysold-daysold)*24; 
        hrsold=Math.floor(e_hrsold); 
        e_minsold=(e_hrsold-hrsold)*60; 
        minsold=Math.floor((e_hrsold-hrsold)*60); 
        seconds=Math.floor((e_minsold-minsold)*60);     
        if(daysold<0)
        {       
         document.getElementById(element).innerHTML="0天0小时0分0秒";
        }else{
        document.getElementById(element).innerHTML=daysold+"天"+hrsold+"小时"+minsold+"分"+seconds+"秒" ;
        }
}
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
   <skm:Form ID="Form1" method="post" runat="server">
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="content">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <!--main start-->
            <!--left is start-->
            <div class="sidebar leftn_hot">
                <!--自定义导航-->
                <!--店铺信息-->
                <ShopNum1Shop:ShopInfo ID="ShopInfo1" runat="server" SkinFilename="ShopInfo.ascx" />
                <!--商品搜索-->
                <ShopNum1Shop:ProduceSearch ID="ProduceSearch1" runat="server" SkinFilename="ProduceSearch.ascx" />
                <!--商品分类-->
                <ShopNum1Shop:ProductCategory ID="ProductCategory1" runat="server" SkinFilename="ProductCategory.ascx" />
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
                <div class="intge">
                   <ShopNum1Shop:Advertisements ID="topadvertisement" runat="server" SkinFilename="Advertisements.ascx" PageName="ProductIsPanic_List.aspx"/>
                </div>
                <!--抢购商品-->
                <ShopNum1ShopNew:ProductIsPanic_List ID="ProductIsPanic_List1" runat="server" ShowCount="12"
                    SkinFilename="ProductIsPanic_ListNew.ascx" />
            </div>
            <!--is the end-->
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
   </skm:Form>
</body>
</html>
