<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href="Themes/Skin_Default/Style/jqzoom.css" />
    <ShopNum1Shop:ProductIsPanicMeta ID="ProductIsPanicMeta" runat="server" SkinFilename="SetMeta.ascx" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

function show_date_time(time, element){
window.setInterval("show_date_time('"+time+"','"+element+"')", 1500);     
//AJAX获取服务器数据
//因程序执行耗费时间,所以时间并不十分准确,误差大约在2000毫秒以下
var xmlHttp = false;
//获取服务器时间
try {xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");} catch (e) {
try {xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");} catch (e2) {xmlHttp = false;}
}
if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
    xmlHttp = new XMLHttpRequest();
}
xmlHttp.open("GET", "/Api/newtime.txt?date="+(-new Date), false);
xmlHttp.setRequestHeader("Range", "bytes=-1");
xmlHttp.send(null);
var severtime = new Date(xmlHttp.getResponseHeader("Date"));//服务器时间
 
        BirthDay = new Date(time);
        today=new Date(severtime);  
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
    <ShopNum1:Form ID="Form1" method="post" runat="server">
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="content">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <%--<ShopNum1Shop:ShopPageaddress ID="ShopPageaddress" runat="server" SkinFilename="ShopPageaddress.ascx" />--%>
            <!--main start-->
            <!--left is start-->
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
            <div class="main">
                <!--抢购商品-->
                <ShopNum1ShopNew:ProductIsPanicDetail ID="ProductIsPanicDetail" runat="server" SkinFilename="ProductIsPanicDetailNew.ascx" />
            </div>
            <!--is the end-->
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
   </ShopNum1:Form>
    <!--js-->
    <script src="/main/js/shop1/zoom.js" type="text/javascript"></script>
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
				 	
				 	
				$("#tb_gallery").jdMarquee({
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
				    
				$("#tb_gallery img").bind("mouseover",function(){
					var src=$(this).attr("lang");
					$("#spec-n1 img").eq(0).attr({
						src:src.replace("\/n5\/","\/n1\/"),
						jqimg:src.replace("\/n5\/","\/n0\/")
					});
					$(this).parent().parent().parent().addClass("tb_selected");
				}).bind("mouseout",function(){
		            $(this).parent().parent().parent().removeClass("tb_selected");
				});	
		
			})
			    	
	})
    </script>

    <script type="text/javascript">
    function changeTab(count,index)
    {
    
        for (var i = 1; i <= count; i++)
        {
          document.getElementById('content' + i).style.display ="none";
          document.getElementById("current" + i).style.background="";
          document.getElementById("current" + i).style.color="";
          document.getElementById("current" + i).className="";
        }
       document.getElementById('content' + index).style.display ="block";
       document.getElementById('current'+index).className="selected";
    }
 
    </script>

</body>
</html>
