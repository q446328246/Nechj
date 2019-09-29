<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateShoping.aspx.cs" Inherits="ShopNum1.Deploy.Main.UpdateShoping" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.3.1.js" type="text/javascript"></script>
    <script type="text/javascript">
    
     function checkBox(cb) {
var oOne = document.getElementById("one");
var oTwo = document.getElementById("two");
var oDiv1 = document.getElementById("div1");
var oDiv2 = document.getElementById("div2");
            if (cb.id=="one") {
                    oTwo.checked= false;        
                    oDiv2.style.display="none"
                    if (cb.checked) {
                            oDiv1.style.display="block";
                            } else {
                             oDiv1.style.display="none";
                    }        
            } else if (cb.id=="two") {
                    oDiv1.checked = false;
                    if (cb.checked) {
                       oDiv2.style.display="block";
                    } else {
                        oDiv2.style.display="none";
                    }
                    oDiv1.style.display="none";
            }
    }
    
    </script>
</head>
<body>
   
    
    <input type="checkbox" id="one" onClick="checkBox(this);"/><label for="">111111</label><br />
 
 <input type="checkbox" id="two" onClick="checkBox(this);"/><label for="">22222222222</label><br />

<form name="myform">
  <div align="center">选框 1 
    <input type="checkbox"  id="div1chkbox" name="div1chkbox" onClick="checkBoxValidate(this);" >
    <div id="div1" style="display:none;width:100px;height:100px;border:solid 1px red;">
            我是div1    
    </div>


    选框 2 
    <input type="checkbox"  id="div2chkbox" name="div2chkbox" onClick="checkBoxValidate(this);">
    <div id="div2" style="display:none;width:160px;height:100px;border:solid 1px red; position:absolute; left:100px; top:100px;">
            我是div2
    </div>


  
   
    </form>
</body>
</html>
