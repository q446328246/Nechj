//shopnum1操作table（2011年8月4日）
document.onreadystatechange = function(){
if(document.readyState=="complete")
{
   var tables=document.getElementsByTagName("table");
 for(var i=0;i<tables.length;i++)
 {
   var tablerows=tables[i].rows;
   for(var j=0;j<tablerows.length;j++)
   {
      for(var k=0;k<tablerows[j].cells.length;k++)
      {
         var cel=tablerows[j].cells[k];
         if(cel.innerHTML=="")
         {
           cel.innerHTML="&nbsp;";
         }
      }
   }
 }
}
}

//火狐
if (document.addEventListener) 
{
document.addEventListener("DOMContentLoaded", function()
{
  var tables=document.getElementsByTagName("table");
 for(var i=0;i<tables.length;i++)
 {
   var tablerows=tables[i].rows;
   for(var j=0;j<tablerows.length;j++)
   {
      for(var k=0;k<tablerows[j].cells.length;k++)
      {
         var cel=tablerows[j].cells[k];
         if(cel.innerHTML=="")
         {
           cel.innerHTML="&nbsp;";
         }
      }
   }
 }
}, null);
} 