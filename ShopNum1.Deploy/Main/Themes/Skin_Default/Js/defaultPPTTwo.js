  var licout=0;
     $lis=$("#ul li");
     var wInter;
     //�Զ��л�
     function Shopauto(){
      licout<$lis.length-1?licout++:licout=0;
      var imgsrc=$lis.eq(licout).attr("title");
       $lis.eq(licout).siblings().animate({width:'10'},500);
        $lis.eq(licout).animate({width:'380'},800);
       
        $("#image_hdp").attr("src",imgsrc);
      }
      //��ʱ��
     wInter=window.setInterval(Shopauto,2000);
     $(document).ready(function(){      
         $lis=$("#ul li");
        $("#ul li").mouseover(
            function() {
				//$(this).css("width",'380');
			   window.clearInterval(wInter);
              $(this).animate({width:'380'},800);
              var imgsrc=$(this).attr("title");
              $("#image_hdp").attr("src",imgsrc);
              $(this).siblings().animate({width:'10'},500);
		    
            });
        $("#ul li").mouseout(
            function() {
				//$(this).css("width",'380');
			  wInter=window.setInterval(Shopauto,2000);
            
            });
		
   }); 