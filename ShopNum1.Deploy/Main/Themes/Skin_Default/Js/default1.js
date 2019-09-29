// JavaScript Document
	$(document).ready(function(){
	    var clothFrame= $("#changeLeft",parent.document.body)
		$(".toggle1").toggle(
			function(){
				$(this).aspx("展开菜单")
				clothFrame.attr("cols","0,*")
				
			},
			function(){
				$(this).aspx("关闭菜单")
				clothFrame.attr("cols","210,*")
				
			}
	)

		$(".category2 dt").toggle(
			function(){
				$(this).find("img").attr("src","Themes/Skin_Default/images/icon_list_up.gif")
				$(this).parent().children("dd").show()
			}
			,function(){
				$(this).find("img").attr("src","Themes/Skin_Default/images/icon_list_down.gif")
				$(this).parent().children("dd").hide()
			}
		)
		


        $("#tab li").each(function(i){
		 					$(this).click(
								function(){
									$(this).addClass("cur").siblings().removeClass()
									$("#content li").eq(i).show().siblings().hide()
								}

							)
				})


 $.fn.extend({
				 	tab:function(){
						$(this).children().each(function(i){
							$(this).click(function(){
								$(this).addClass("activedTab").siblings().removeClass("activedTab")
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
	})