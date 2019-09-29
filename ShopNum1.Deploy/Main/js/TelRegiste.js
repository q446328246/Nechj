//<!--第三方登录-->
//<![CDATA[
var theForm = document.forms[0];
if (!theForm) {
    theForm = document.form1;
}

function SecondLogin(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
    {
        theForm.secondEVENTTARGET.value = eventTarget;
        theForm.secondEVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//]]>


$(document).ready(function(){
      $(".login").show();
      $(".login_info").hide();
})

function SecondLoginUrl(id)
{
    $.ajax
    ({
          url:"/api/SecondLogin.ashx",
          data:"type=secondlogin&SecondID="+id+"",
          success:function(url){
              if(url!="")
              {
                window.location.href=url;
              }
          }
    })
}   

 function Showtips(name,showvalue) 
 {
     document.getElementById(name).innerHTML=showvalue;;
     document.getElementById(name).className="onTips";
 }
//开始注册
//<![CDATA[//验证用户名
function existmemname() 
{
    var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxMemLoginID").val();
    var context = document.getElementById("spanName");
    var reg = /^[\d+]{11}$/
     if(inputcontrol!="") 
     {
        if(reg.test(inputcontrol)) 
        {
            context.innerHTML = "数据查询中.."; 
                  $.ajax
                ({
                    url: "/api/CheckMemberLogin.ashx",
                    data: encodeURI("type=userisexist&UserID="+inputcontrol+""),//中文编码
                    success: function(result) 
                    {
                          if(result!=null)
                          {
                              if(result=="true")
                              {
                                context.innerHTML = "手机号码已存在"; 
                                context.className="onError";
                                boolresult=false;

                              }
                              else
                              {
                                 context.innerHTML = "手机号码可以使用"; 
                                 context.className="onCorrect";
                                 boolresult=true;
                                 $("#butGetCode").removeAttr("disabled");
                               }
                           }
                          else
                          {
                            boolresult=false;
                          }
                    }
                })
         }
        else 
        { 
            context.innerHTML = "手机号码格式不正确";
            context.className="onError";
            boolresult=false;
        }
    }
    else 
    { 
        context.innerHTML = "手机号码不能为空";
        context.className="onError" ;
        boolresult=false;
    }
    return boolresult;
}
//验证emall是否存在
function existemail() 
{   var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxEmail").val();
    var context = document.getElementById("spanEmail");
    if(inputcontrol!= "") 
    {
        var reg =/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;       
        if(reg.test(inputcontrol)) 
        {
            context.innerHTML = "数据查询中.."; 
            $.ajax
            ({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=emailisexist&Email="+inputcontrol+"",
                success: function(result) 
                {
                      if(result!=null)
                      {
                          if(result=="true")
                          {
                             context.innerHTML = "邮箱已存在"; 
                             context.className="onError";
                             boolresult==false;
                          }
                          else
                          {
                               context.innerHTML = "邮箱可以使用"; 
                               context.className="onCorrect";
                                boolresult==true;
                          }
                       }
                      else
                      {
                        boolresult=false;
                      }
                }
            })
        }
        else 
        { 
            context.innerHTML = "电子邮箱格式不正确";
            context.className="onError";
            boolresult=false;
        }
    }
    else 
    { 
        context.innerHTML = "电子邮箱不能为空";
        context.className="onError" ;
        boolresult=false;
    }
    return boolresult;
}

//验证密码
function existepwd() 
{
    var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxPwd").val();
    var context = document.getElementById("spanPwd");
    if(inputcontrol != "") 
    {
        var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
        if(reg.test(inputcontrol)) 
        {
            var hid = document.getElementById("HiddenExistPwd");
            hid.value = "true";
            context.innerHTML = "密码正确";context.className="onCorrect";boolresult=true;
            $("#TelRegister_ctl00_TextBoxRePwd").removeAttr("disabled");
        }
        else 
        { 
            context.innerHTML = "密码格式不正确"; context.className="onError";
boolresult=false;
        }
    }
    else 
    { 
        context.innerHTML = "密码不能为空"; context.className="onError";
        boolresult=false;
    }
    return boolresult;
}

//验证确认密码
function existesurepwd() 
{
   var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxRePwd").val();
    var context = document.getElementById("spanSurePwd");
    var pwd =$("#TelRegister_ctl00_TextBoxPwd").val();
    if(inputcontrol == pwd) 
    {
        var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
        if(reg.test(inputcontrol)) 
        {
            context.innerHTML = "确认密码正确";
            context.className="onCorrect";
            boolresult=true;
        }
        else 
        { 
            context.innerHTML = "确认密码格式不正确";context.className="onError";
            boolresult=false;
         }
    }
    else 
    {
        context.innerHTML = "两次密码不一致"; context.className="onError";
        boolresult=false;
    }
    return boolresult;
}


//推荐会员
function existpublishmemlogid() 
{

   var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxPublishMemloid").val();

    var context = document.getElementById("spanPublishName");
    var arg = "ExistMemLoginID|" + inputcontrol.value;
    var reg = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,12}$/
     if(inputcontrol != "")
     {
        if(reg.test(inputcontrol.value)) 
        {
            boolresult=true;
        }
        else 
        { 
            context.innerHTML = "推荐会员格式不正确";context.className="onError";
            boolresult=false;
        }
    }
    else 
    {
        context.innerHTML = "推荐会员的用户名";context.className="onShow";
        boolresult=true;
    }
    return boolresult;
}
//验证码
function existcode() 
{

   var boolresult=true;
    var inputcontrol=$("#TelRegister_ctl00_TextBoxCode").val();
    var context = document.getElementById("spanCode");
     if(inputcontrol != "")
     {
        $.ajax
        ({
            url:"/api/CheckMemberLogin.ashx",
            data:"type=getverifycode&code="+inputcontrol+"",
            success:function(result)
            {
                if(result=="true")
                {
                    context.innerHTML="验证码正确";
                    context.className="onCorrect";
                    boolresult=true;
                    
                }
                else
                {
                    context.innerHTML="验证码错误";
                    context.className="onError";
                    boolresult=false;
                }
            }
        })
    }
    else 
    {
        context.innerHTML = "验证码不能为空";
        context.className="onError";
        boolresult=false;
    }
    return boolresult;
}

$(document).ready(function(){
      $(".login").show();
      $(".login_info").hide();
})
    function reloadcode()
    {
        var verify=document.getElementById('Img1');
        verify.setAttribute('src','/imagecode.aspx?'+Math.random());
    }
   function agreement() 
   {        
            
        var ss=false;
        var check = document.getElementById("<%= CheckBoxIfAgree.ClientID %>");
        if(check.checked) 
        {

            document.getElementById("spanIfAgree").innerHTML = "";
            if(existmemname()&&existemail()&&existepwd()&&existesurepwd()&&existcode()&&existpublishmemlogid())
            {
               ss=true;
            }
            else
            {
                ss=false;
            }
        }
        else 
        {
            document.getElementById("spanIfAgree").innerHTML = "还没接受用户协议";
            ss=false;
        }
        if(ss==true)
        {
            $(".login").hide();
            $(".logininfo").show();
        }
        return ss;
    }
             
 
    
     function Showtips(name,showvalue) 
     {
         document.getElementById(name).innerHTML=showvalue;;
         document.getElementById(name).className="onTips";
     }