// JavaScript Document
	$(document).ready(function() {
	    var clothFrame = $("#changeLeft", parent.document.body);
	    $(".toggle1").toggle(
	        function() {
	            $(this).html("展开菜单");
	            clothFrame.attr("cols", "0,*");
	        },
	        function() {
	            $(this).html("关闭菜单");
	            clothFrame.attr("cols", "210,*");
	        }
	    );
	    $(".category dt").toggle(
	        function() {
	            $(this).find("img").attr("src", "images/icon_list_up.gif");
	            $(this).parent().children("dd").show();
	        }, function() {
	            $(this).find("img").attr("src", "images/icon_list_down.gif");
	            $(this).parent().children("dd").hide();
	        }
	    );
	    $("#tab li").each(function(i) {
	        $(this).click(
	            function() {
	                $(this).addClass("cur").siblings().removeClass();
	                $("#content li").eq(i).show().siblings().hide();
	            }
	        );
	    });
	    $.fn.extend({
	        tab: function() {
	            $(this).children().each(function(i) {
	                $(this).click(function() {
	                    $(this).addClass("activedTab").siblings().removeClass("activedTab");
	                    $(this).parent().next().children().eq(i).show().siblings().hide();
	                });
	            });
	        }
	    });
	    $(".title").tab();
	})