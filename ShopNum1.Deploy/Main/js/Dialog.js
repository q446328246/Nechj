  /*
  fromName 是要打开的窗口,子窗体的名称
  text是父窗体text的id
  img是父窗体img的id
  */
  function openDialog(formName,text,img){ 
    var k = window.showModalDialog(formName,window,"dialogWidth:800px;status:no;dialogHeight:800px"); 
    if(k != null) 
    document.getElementById(text).value = k; 
   document.getElementById(img).src=k; 
   //document.getElementById("img1").v 
    } 













////打开模式对话框（图片选择）
//function OpenDialog(ObjID){
//    if (navigator.appVersion.indexOf("MSIE") == -1){
//        this.returnAction=function(strResult){
//            if(strResult!=null && document.getElementById(ObjID)){
//                document.getElementById(ObjID).value = strResult;
//                if(document.getElementById(ObjID + "View")){
//                    document.getElementById(ObjID + "View").src = "../" + strResult;
//                    document.getElementById(ObjID + "View").style.display = "block";
//                }
//            }
//        }
////        window.open('Picture_Picture_Manage_Dialog.aspx?d=' + Date(),'newWin','modal=yes,width=620,height=620,top=200,left=300,resizable=no,scrollbars=no');
// window.open('Admin/Image_List_Dialog.aspx','newWin','modal=yes,width=620,height=620,top=200,left=300,resizable=no,scrollbars=no');
//        return;
//    }else{
////        var GetValue = showModalDialog('Image_List.aspx?d=' + Date(),'','dialogWidth:620px;dialogHeight:620px;')
// var GetValue = showModalDialog('Admin/Image_List_Dialog.aspx','dialogWidth:620px;dialogHeight:620px;')
//        if (GetValue != null && document.getElementById(ObjID)) {
//            document.getElementById(ObjID).value = GetValue;
//            if(document.getElementById(ObjID + "View")){
//                document.getElementById(ObjID + "View").src = "../" + GetValue;
//                document.getElementById(ObjID + "View").style.display = "block";
//            }
//        } 
//    }
//}
////将选中的图片放入父窗体的控件中
////function InitPicture(obj){
////    if (navigator.appVersion.indexOf("MSIE") == -1){
////        window.opener.returnAction(obj.title.replace("双击选择该图片，图片地址是",""));
////        window.close();
////    }else{
////        window.returnValue = obj.title.replace("双击选择该图片，图片地址是","");
////        window.close();
////    }
////}

////将选中的图片放入父窗体的控件中
//function InitPicture(txt){
//    if (navigator.appVersion.indexOf("MSIE") == -1){
//        window.opener.returnAction(txt);
//        window.close();
//    }else{
//        window.returnValue = txt;
//        window.close();
//    }
//}