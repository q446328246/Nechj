 var  smallImgs=null;
  var  smallImgCount=0;
  var  imgStart=0;
  ///ie加载完成以后进行图片数量的判断
  document.onreadystatechange = function(){
if(document.readyState=="complete")
{
 if(document.getElementById("divSmallImg")!=null)
  {
   smallImgs=document.getElementById("divSmallImg").getElementsByTagName("img");
   if(smallImgs==null)
   return;
   smallImgCount=smallImgs.length;
      if(smallImgs[0]!=null)
   document.getElementById("AdBigImg").src=smallImgs[0].src;
  }
 document.body.onload=bigImgOnload();
 
}
} 
//解决火狐元素加载的问题
if (document.addEventListener) 
{
document.addEventListener("DOMContentLoaded", function()
{
   smallImgs=document.getElementById("divSmallImg").getElementsByTagName("img");
   smallImgCount=smallImgs.length;
    if(smallImgs[0]!=null)
   document.getElementById("AdBigImg").src=smallImgs[0].src;
  document.body.onload=bigImgOnload();
}, null);
} 
 var vInterv=window.setInterval(AutoImgChange,2000);
 
var vOne=window.setTimeout(bigImgOnload,1);
 
 ///图片定时事件
 function ImgInterv(iobj)
 {
 vInterv=window.setInterval(AutoImgChange,2000);
 iobj.setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
 }
 

  ///小图点击效果
  function SmallMover(iobj)
  {
  
     window.clearInterval(vInterv);
     document.getElementById("AdBigImg").src=iobj.src;
     document.getElementById("smallImgName").innerHTML=iobj.title;
      for(var i=0;i<smallImgCount;i++)
      {
       if(smallImgs[i]!=null)
       smallImgs[i].className="smallImgOver";
       smallImgs[i].setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
     
      }
       iobj.setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
  }
 
  ///小图片自动切换
  function AutoImgChange()
  {
  ///还原样式
      for(var i=0;i<smallImgCount;i++)
      {
       if(smallImgs[i]!=null)
       smallImgs[i].className="smallImgOver";
       smallImgs[i].setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");

      }
    
     if(imgStart==smallImgCount)
     {
        imgStart=0;
        document.getElementById("AdBigImg").src=smallImgs[imgStart].src;
        document.getElementById("smallImgName").innerHTML=smallImgs[imgStart].title;
         smallImgs[imgStart].setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
     }
     else
     {
        document.getElementById("AdBigImg").src=smallImgs[imgStart].src;
        document.getElementById("smallImgName").innerHTML=smallImgs[imgStart].title;
        smallImgs[imgStart].setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
     }
     imgStart++;
  }


  function  bigImgOnload()
  {
   var  Imgs=document.getElementById("divSmallImg").getElementsByTagName("img");
    if(Imgs[0]!=null)
    if(document.getElementById("AdBigImg").src=="Images/hd1.jpg")
    {
      document.getElementById("AdBigImg").src=Imgs[0].src;
    }
  }