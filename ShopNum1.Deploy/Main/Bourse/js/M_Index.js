// <!--控制右边框架高度为100%的JS代码-->
   
    function reinitIframe()
    { 
        var height=0;
        var iframe = document.getElementById("mainFrame");  
       if(window.ActiveXObject)
       {
          
            try
            { 
                var bHeight = iframe.contentWindow.document.body.scrollHeight; 
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight; 
                height = Math.max(bHeight, dHeight); 
                iframe.height = height; 
                if(iframe.height=="1469")
                {
                   iframe.height=1495;
                }
                
            }catch (ex){} 
        }
        else
        {
            try
            { 
                var bHeight = iframe.contentWindow.document.body.scrollHeight; 
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight; 
                var height = Math.max(bHeight, dHeight); 
                iframe.height = height; 
            }catch (ex){} 
        }
    } 
    window.onload=function(){window.setInterval("reinitIframe()", 500);}
    //window.setInterval("reinitIframe()", 15); 
//<!--左边菜单展开折叠效果的JS代码-->
function te_show(f,o)
{
    var oti=document.getElementById("ti0"+f);
    var ote=document.getElementById("te0"+f);
    $("#ti0"+f).find("a").eq(0).addClass("current");
    if(ote.style.display=="none")
    {
    ote.style.display="block";
    }
    else
    {
    ote.style.display="none";
    }
}
//<!--左边菜单项点击菜单项页面置顶JS和鼠标点击选中效果-->
function subItem(o)
 {
     //document.getElementById("mainFrame").style.height="100%";
     $(o).addClass("current").siblings().removeClass("current");
     $(o).parent().siblings().find("a").removeClass("current");
     window.scrollTo(0,0);
 }
// $(function(){
//     $("#mainFrame").attr("src","M_Welcome.aspx");  window.scrollTo(0,0);
// });
  $(function(){
                  window.scrollTo(0,0);
             });
//<!--划过下拉框显示效果-->
(function($){
	$.fn.hoverForIE6=function(option){
		var s=$.extend({current:"hover",delay:10},option||{});
		$.each(this,function(){
			var timer1=null,timer2=null,flag=false;
			$(this).bind("mouseover",function(){
				if (flag){
					clearTimeout(timer2);
				}else{
					var _this=$(this);
					timer1=setTimeout(function(){
						_this.addClass(s.current);
						flag=true;
					},s.delay);
				}
			}).bind("mouseout",function(){
				if (flag){
					var _this=$(this);timer2=setTimeout(function(){
						_this.removeClass(s.current);
						flag=false;
					},s.delay);
				}else{
					clearTimeout(timer1);
				}
			})
		})
	}
})(jQuery);
$(function(){
    $(".allsort").hoverForIE6({current:"allsorthover",delay:200});
    $(".allsort .item").hoverForIE6({delay:150});
});
    
    
    