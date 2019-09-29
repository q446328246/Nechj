
  
function changeProduct(value){
     
	 for (var i=1;i<5;i++){
	   if (i == value){
	     document.getElementById("lp" + i).style.background="url(Themes/Skin_Default/Images/tab_bg2.gif) center no-repeat";
	     
		 document.getElementById("div"+i).style.display="block";
	   }
	   else{
	   
	   document.getElementById("lp" + i).style.background="none";
	  
	   document.getElementById("div"+i).style.display="none";
	      
	   }
	 }
  }
  
  function changeCategory(value){
	
     for(var i =1;i<5;i++){
       if(i == value){
      
             document.getElementById("lc"+i).style.background="url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat";
             
             document.getElementById("lac"+i).style.color="#FFFFFF";
              document.getElementById("divc"+i).style.display="block";
             }
         
           else{
             document.getElementById("lc"+i).style.background="none";
            
             document.getElementById("lac"+i).style.color="#d40000";
              document.getElementById("divc"+i).style.display="none";
           }
     }
  }
  function changeGq(value)
  {
     for(var i =1;i<5;i++){
       if(i == value){
       if( document.getElementById("divd"+i)!=null)
       {
             document.getElementById("ld"+i).style.background="url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat";
             document.getElementById("lad" + i).style.color="#FFFFFF";
             
              document.getElementById("divd"+i).style.display="block";
             }
           }
           else{
             document.getElementById("ld"+i).style.background="none";
             document.getElementById("lad" + i).style.color="#D40000";
              document.getElementById("divd"+i).style.display="none";
           }
     }
  }
  function changeAC(value)
  {
     for(var i =1;i<5;i++){
       if(i == value){
      
             document.getElementById("le"+i).style.background="url(Themes/Skin_Default/Images/tabbg2.gif) center no-repeat";
             document.getElementById("lae" + i).style.color="#FFFFFF";
              document.getElementById("dive"+i).style.display="block";
             
           }
           else{
             document.getElementById("le"+i).style.background="none";
             document.getElementById("lae" + i).style.color="#D40000";
              document.getElementById("dive"+i).style.display="none";
           }
     }
  }
  function changeSC(value)
  {
     for(var i =1;i<5;i++){
       if(i == value){
      
             document.getElementById("lf"+i).style.background="#d40000";
             document.getElementById("lf" + i).style.color="#FFFFFF";
              document.getElementById("divf"+i).style.display="block";
             
           }
           else{
             document.getElementById("lf"+i).style.background="none";
             document.getElementById("lf" + i).style.color="#d40000";
              document.getElementById("divf"+i).style.display="none";
           }
     }
  }

