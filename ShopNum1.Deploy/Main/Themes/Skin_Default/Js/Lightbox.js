$(document).ready(function(){
		$.ajax({ 
  			type:'GET',
			cache:false,
  			url:'Themes/Skin_Default/Js/adImage.xml',
  			dataType:'XML',
			error: function(data){
				alert('Error loading XML document'+xml);
			}, 
			success:function(data){
				if($.browser.msie){
					var xml;  
					if (typeof data == "string") {  
						xml = new ActiveXObject("Microsoft.XMLDOM");  
						xml.async = false;  
						xml.loadXML(data);  
					} else {  
						xml = data;  
					}
					$(xml).find('adImage').each(function(i){
						var link = $(this).children('url').text();
						var ad = $(this).children('ad').text();
						if(i == 0){
						    if(link == "") {
						    $("#images").append("<img src="+ad+">");
						    }
						    else {
						        $("#images").append("<a class=cur href="+link+" target='_blank'><img src="+ad+"></a>");
						    }
							$("#btn").append("<div class='hov'>"+(i+ 1)+"</div> ");
						}
						else{
													    if(link == "") {
						    $("#images").append("<img src="+ad+">");
						    }
						    else {
						        $("#images").append("<a class=cur href="+link+" target='_blank'><img src="+ad+"></a>");
						    }
							$("#btn").append("<div>"+(i + 1)+"</div> ");
						}
				})
					
				}
 				else{
					$(data).find('adImage').each(function(i){
						var link = $(this).children('url').text();
						var ad = $(this).children('ad').text();
					if(i == 0){
						if(link == "") {
						    $("#images").append("<img src="+ad+">");
						    }
						else {
					        $("#images").append("<a class=cur href="+link+" target='_blank'><img src="+ad+"></a>");
						}
						$("#btn").append(" <div class='hov'>"+(i+ 1)+"</div> ");
						}
					else{
						if(link == "") {
						    $("#images").append("<img src="+ad+">");
						    }
						else {
					        $("#images").append("<a class=cur href="+link+" target='_blank'><img src="+ad+"></a>");
						}
						$("#btn").append(" <div>"+(i+ 1)+"</div> ");
						}
				})
				}

  			}
		})
		
/*run img*/
var index = 0;
 

$('#images').hover(function(){
			  if(MyTime){
				 clearInterval(MyTime);
			  }
},function(){
			  MyTime = setInterval(function(){
			    showImg(index)
				index++;
				if(index==$("#images a").length){index=0;}
			  } , 3200);
	 });

var MyTime = setInterval(function(){
		showImg(index)
		index++;
		if(index==$("#images a").length){index=0;}
	 } , 3200);
	 
/*show img*/
	function showImg(i){
		$("#images a")
			.eq(i).fadeIn()
			.siblings().hide();
		 $("#btn div")
			.eq(i).addClass("hov")
			.siblings().removeClass("hov");

	}
	
	})