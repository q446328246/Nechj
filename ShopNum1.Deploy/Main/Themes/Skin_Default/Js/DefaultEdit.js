
//选择单图
   function openSingleChild()
    { 
        var k = window.showModalDialog("Main/Admin/Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if(k != null) 
        {
          var strLen=k.length;
          var lastIndex=k.lastIndexOf('/');
          document.getElementById("textImgSrc").value ="/ImgUpload/"+ k.substring(lastIndex+1,strLen); 
         document.getElementById("contentImg").src = k; 
        }
    } 
  ///操作div
  function  ImgOperateDiv(dobj)
  {
   
    document.getElementById('AllDiv').style.display='block';
   document.getElementById("AllDiv").style.display="block";
   document.getElementById('ContentDiv').style.display='block';
   var  adImg=dobj.parentNode.parentNode.getElementsByTagName("img")[0];
   var  adlink=adImg.parentNode;
   document.getElementById("contentImg").src=adImg.src;
    document.getElementById("textImgSrc").value=adImg.src;
   document.getElementById("textImgID").value=adImg.title;
   document.getElementById("textImgName").value=adlink.title;
   document.getElementById("textImgLink").value=adlink.getAttribute("adlink");
   ///广告的尺寸
   document.getElementById("spanImgSize").innerHTML=adImg.width+"x"+adImg.height;
   document.getElementById("DivImgMsg").innerHTML="";
   
  }
  
  //关闭图片窗口
  function  CloseImgWindow()
  {
   //隐藏div
   document.getElementById('AllDiv').style.display='none';
   document.getElementById('ContentDiv').style.display='none';
   
   //清空内容
   document.getElementById("contentImg").src="";
   document.getElementById("textImgID").value="";
   document.getElementById("textImgName").value="";
   document.getElementById("textImgLink").value="";
   ///广告的尺寸
   document.getElementById("spanImgSize").innerHTML="";
   //window.location.replace(window.location.href);
  
  }
  
  ///移动到图片的时候
  function  DivAdImgOver(dobj)
  {

    dobj.setAttribute("style","background-color: #777; filter: progid:DXImagesTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75);opacity: 0.6;");
    dobj.getElementsByTagName("div")[0].style.display="block";

        
  }
  ///图片移开的时候
  function  DivAdImgOut(dimg)
  {
   var dobj=dimg.parentNode;
   dobj.setAttribute("style","");
    dobj.getElementsByTagName("div")[0].style.display="none";
  
  }
///保存图片广告
  function saveAdImgInfo()
{

    //获取接受返回信息层
    var msg = document.getElementById("DivImgMsg");

    //获取表单adimg 信息
    var f = document.forms[0];    
    var ImgTitle = f.textImgName.value;
    var ImgLink = f.textImgLink.value;
    var imgID=f.textImgID.value;
    var imgSrc= f.textImgSrc.value;
    //接收表单的URL地址
    var url = "Main/Admin/AdImgHander.ashx";    
    //需要POST的值，把每个变量都通过&来联接
    var postStr ="imgID="+imgID+"&ImgTitle="+ ImgTitle +"&ImgLink="+ ImgLink+"&ImgSrc="+imgSrc;

       var ajax = null;
     try {
     ajax = new XMLHttpRequest();
     } catch (trymicrosoft) {
     try {
       ajax = new ActiveXObject("Msxml2.XMLHTTP");
     } catch (othermicrosoft) {
       try {
         ajax = new ActiveXObject("Microsoft.XMLHTTP");
       } catch (failed) {
         ajax = false;
       }  
     }
   }
   if (!ajax)
   alert("Error initializing XMLHttpRequest!");

    //通过Post方式打开连接
    ajax.open("POST", url, true);
    //定义传输的文件HTTP头信息
    ajax.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
    //发送POST数据
    ajax.send(postStr);

    //返回数据的处理函数
    ajax.onreadystatechange = function(){
        if (ajax.readyState == 4)
            {
            if(ajax.status == 200)
             {
               if(ajax.responseText=="success")
               {
                  msg.innerHTML = "success";
               }
               else
               {
               msg.innerHTML = ajax.responseText;
               }
              
             }
             else
              {
                 msg.innerHTML="server error";
              }
            }
       
      }
    
}