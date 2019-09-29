// JavaScript Document
//Ê×Ò³ËÑË÷ÇÐ»»JS
<script type="text/javascript" language="javascript"> 
  function chang(value){
     
	 for (var i=1;i<6;i++){
	   if (i == value){
	     document.getElementById("hh" + i).style.background="url(Images/search_01.gif)";
		 document.getElementById("hh" + i).style.width="81px"
	   }
	   else{
	   
	   document.getElementById("hh" + i).style.background="none";
	   document.getElementById("hh" + i).style.width="72px"
	      
	   }
	 }
  }
</script>//by april
