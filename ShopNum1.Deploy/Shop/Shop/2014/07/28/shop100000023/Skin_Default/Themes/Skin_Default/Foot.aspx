<div id="footer">
    <div class="lmf_all_foot">
        <ShopNum1:HelpListButtom ID="HelpListButtom" ShowCount="6" runat="server" SkinFilename="HelpListButtom.ascx" />
    </div>
    <div class="copyright">
        <ShopNum1:DomainCopyright ID="DomainCopyright" runat="server" SkinFilename="DomainCopyright.ascx" />
    </div>
</div>

<!--在线客服 start-->
<ShopNum1Shop:OnLineFootService ID="OnLineFootService" runat="server" SkinFilename="OnLineFootService.ascx" ShowCount="5" />
<!--//在线客服 end-->

<!--返回顶部 start-->
<div id="fixed-bottom" onclick="pageScroll()" style="display: none;" onmouseover="ChangeImageIn()" onmouseout="ChangeImageOut()">
    <img id="fixed-bottom_zhiding" src="Themes/Skin_Default/Images/myzhiding.png" />
</div>
<!--//返回顶部 end-->

<!--微信、建议、返回顶部 start-->
<div id="fixed-weixin" class="weixin">
    <div class="ShouJi js-change-img"><img src="Themes/Skin_Default/Images/shouji.png" /></div>
    <div class="MicroInfo js-change-img"><img src="Themes/Skin_Default/Images/MicroInfo.png" /></div>
    <div class="ReturnTop js-change-img" onclick="pageScroll()"><img src="Themes/Skin_Default/Images/ReturnTop.png" /></div>
    <div class="erwei">
        <p><img src='<%=ShopNum1.Common.ShopSettings.GetValue("MicroEWM") %>' /></p>
        <p>扫一扫，加我为微信好友吧!</p>
    </div>
    <div class="ShouJi_erwei">
        <p><img src='<%=ShopNum1.Common.ShopSettings.GetValue("PhoneEWM") %>' /></p>
        <p>扫一扫，快速进入商城!</p>
    </div>
</div>
<!--微信、建议、返回顶部 end-->

<!--[if lte IE 6]>
<style type="text/css">
    *html, *htmlbody
    {
        background-image: url(about:blank);
        background-attachment: fixed;
    }
    /*修正IE6振动bug*/#fixed-weixin /* IE6 底部固定*/
    {
        position: absolute;
        bottom: auto;
        top: expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop, 10)||0)-(parseInt(this.currentStyle.marginBottom, 10)||0)));
        right: auto;
        left: expression(eval(document.documentElement.scrollLeft+document.documentElement.clientWidth-this.offsetWidth)-(parseInt(this.currentStyle.marginLeft, 10)||0)-(parseInt(this.currentStyle.marginRight, 10)||0));
    }
</style>
<![endif]-->

<script type="text/javascript">
    window.onscroll = function() {
        var st = document.documentElement.scrollTop + document.body.scrollTop; //滚去的高度
        if (st > 460) {
            //var imgWeight=document.getElementById("fixed-bottom_zhiding").width;
            document.getElementById("fixed-weixin").style.display = "block";            
            document.getElementById("fixed-weixin").style.left= (document.body.clientWidth/2+510)+"px";
        }
        else {
            document.getElementById("fixed-weixin").style.display = "none";
        }
    }

    function pageScroll() {
        window.scrollBy(0, -1000000);
    }

    function ChangeImageIn() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding1.png";
    }
    function ChangeImageOut() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding.png";
    }
</script>

<!--[if lte IE 6]>
<script src="Themes/Skin_Default/JS/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
<script type="text/javascript">
    DD_belatedPNG.fix('*');
</script>
<![endif]-->

<script type="text/javascript">  
$(window).resize(function(){
 $('.sp_dialog_out').css({
  position:'absolute',
  left: ($(window).width() - $('.sp_dialog_out').outerWidth())/2,
   top: ($(window).height() - $('.sp_dialog_out').outerHeight())/2
 });
});
//初始化函数
$(window).resize();

</script>


<script type="text/javascript">
$(document).ready(function(){
    //鼠标滑过二维码显示隐藏
    $('div.ShouJi').MouseShow($('div.ShouJi_erwei'));
    $('div.MicroInfo').MouseShow($('div.erwei'));
    
    //鼠标滑过图片更换
    $('div.js-change-img img').ChangeImg();
});
jQuery.fn.extend({
    
    //鼠标滑过二维码显示隐藏
    MouseShow: function(item){
        if(this.length <= 0){
            return false;
        }
        var main = this;
        return main.bind({
            mouseover: function(e){
                item.show();
            },
            mouseout: function(e){
                item.hide();
            }
         });
         
    },
    
    //鼠标滑过图片更换
    ChangeImg: function(){
        if(this.length <= 0){
            return false;
        }
        var main = this;
        return main.bind({
            mouseover: function(e){
               var original = $(this).attr('src');
               var nowSrc = original.substring(0,original.length-4)+1+'.png';
               $(this).attr('src',nowSrc);
            },
            mouseout: function(e){
               var original = $(this).attr('src');
               var nowSrc = original.substring(0,original.length-5)+'.png';
               $(this).attr('src',nowSrc);
            }
         });
    }
});
</script>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>
<script type="text/javascript" language="javascript">
//百度地图和二维码切换
function changes(value){
    if(value=="1")
    {
        $("#map1").show();	$("#dz1").addClass("current");
        $("#map2").hide();	$("#dz2").removeClass("current");	
        var Longitude=$("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLongitude").val();
        var Latitude=$("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLatitude").val();
        var map = new BMap.Map("map1");
        var point = new BMap.Point(Longitude,Latitude);
        var marker  = new BMap.Marker(point);
        map.addOverlay(marker);
        
        var marker  = new BMap.Marker(point);
        map.addOverlay(marker);
        marker.addEventListener("click",function(e){
        this.openInfoWindow(infoWindow,map.getCenter());      // 打开信息窗口
});
        //创建信息窗口
        var opts = { 
            width : 150,     // 信息窗口宽度 
            height: 50,     // 信息窗口高度 
            title : $("#hfShopName").val()  // 信息窗口标题 
        } 
        var infoWindow = new BMap.InfoWindow($("#hfAddress").val(), opts);  // 创建信息窗口对象 
        
        map.centerAndZoom(new BMap.Point(Longitude,Latitude), 14);
        map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL}));  //右上角，仅包含平移和缩放按钮
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN}));  //左下角，仅包含平移按钮
        map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM}));  //右下角，仅包含缩放按钮
   }
   else
   {
         $("#map2").attr("style","height:255px");$("#map2").show();
         $("#dz2").addClass("current");
         $("#map1").hide(); $("#map1").attr("style","");
         $("#dz1").removeClass("current");	        
   }
}
</script>

