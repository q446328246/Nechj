<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script src="/Main/Themes/Skin_Default/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
<link href="../Style/index-black.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
   function agreement() 
   {        
            
        var ss=false;
        var check = document.getElementById("<%= CheckBoxIfAgree.ClientID %>");
        if(check.checked) 
        {

            //&&existpublishmemlogid()  推荐会员的检查 
            document.getElementById("spanIfAgree").innerHTML = "";
            var HiddenBarBoxValue=$("#HiddenBarBoxUL").val();
            if(HiddenBarBoxValue=="0")
            {
              if(!existmemname())
              {
             
                 ss=false;
              }
              if(!existemail())
              {
                 ss=false;
              }
            }
           
            if(existepwd()&&existesurepwd()&&existcode()&&existmemname())
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
            document.getElementById("spanIfAgree").innerHTML = "<font color=red>还没接受用户协议</font>";
            ss=false;
        }
        if(ss==true)
        {
            $(".login").hide();
            $(".logininfo").show();
        }
        return ss;
    }
     
function existmemname() 
{

    var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxMemLoginID1").val();
  
    var context = document.getElementById("spanName");
  
    var reg = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{6,12}$/
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
                                context.innerHTML = "帐号已存在,请直接<a href='Login.aspx' target='_blank'>登录</a>";  
                         
                                context.className="onError2";
                                boolresult=false;

                              }
                              else
                              {
                                 context.innerHTML = "用户名可以使用"; 
                                 context.className="onCorrect2";
                                 boolresult=true;
                                 
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
            context.innerHTML = "长度必须是6到12位字符或数字";
            context.className="onError2";
            boolresult=false;
        }
    }
    else 
    { 
   
        context.innerHTML = "用户名不能为空";
        context.className="onError2";
        boolresult=false;
    }
    return boolresult;
}

 function Showtips(name,showvalue) 
 {
         document.getElementById(name).innerHTML=showvalue;;
         document.getElementById(name).className="onTips3";
 }
  function Showtips1(name,showvalue) 
 {
         document.getElementById(name).innerHTML=showvalue;;
         document.getElementById(name).className="onTips2";
 }
//验证emall是否存在
function existemail() 
{   var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxEmail").val();
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
                             context.className="onError2";
                             boolresult==false;
                          }
                          else
                          {
                               context.innerHTML = "邮箱可以使用"; 
                               context.className="onCorrect2";
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
            context.className="onError2";
            boolresult=false;
        }
    }
    else 
    { 
        context.innerHTML = "电子邮箱不能为空";
        context.className="onError2" ;
        boolresult=false;
    }
    return boolresult;
}



//验证码
function existcode() 
{

   var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxCode1").val();
    var context = document.getElementById("spanCode1");
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
                    context.className="onCorrect2";
                    boolresult=true;
                    
                }
                else
                {
                    context.innerHTML="验证码错误";
                    context.className="onError2";
                    boolresult=false;
                }
            }
        })
    }
    else 
    {
        context.innerHTML = "验证码不能为空";
        context.className="onError2";
        boolresult=false;
    }
    return boolresult;
}


//验证码
function existcodedelu() 
{

   var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxCode").val();
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
                    context.className="onCorrect2";
                    boolresult=true;
                    
                }
                else
                {
                    context.innerHTML="验证码错误";
                    context.className="onError2";
                    boolresult=false;
                }
            }
        })
    }
    else 
    {
        context.innerHTML = "验证码不能为空";
        context.className="onError2";
        boolresult=false;
    }
    return boolresult;
}





//验证密码
function existepwd() 
{
   var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxPwd1").val();
    var context = document.getElementById("spanPwd1");
    if(inputcontrol != "") 
    {
        var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
        if(reg.test(inputcontrol)) 
        {
            var hid = document.getElementById("HiddenExistPwd");
            hid.value = "true";
            context.innerHTML = "密码正确";context.className="onCorrect2";
boolresult=true;
        }
        else 
        { 
            context.innerHTML = "密码格式不正确"; context.className="onError2";
boolresult=false;
        }
    }
    else 
    { 
        context.innerHTML = "密码不能为空"; context.className="onError2";
        boolresult=false;
    }
    return boolresult;
}

//验证确认密码
function existesurepwd() 
{
   var boolresult=true;
    var inputcontrol=$("#poplogin_ctl00_TextBoxRePwd").val();
    var context = document.getElementById("spanSurePwd");
    var pwd =$("#poplogin_ctl00_TextBoxPwd1").val();
    if(inputcontrol == pwd) 
    {
        var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
        if(reg.test(inputcontrol)) 
        {
            context.innerHTML = "确认密码正确";
            context.className="onCorrect2";
            boolresult=true;
        }
        else 
        { 
            context.innerHTML = "确认密码格式不正确";context.className="onError2";
            boolresult=false;
         }
    }
    else 
    {
        context.innerHTML = "两次密码不一致"; context.className="onError2";
        boolresult=false;
    }
    return boolresult;
}


</script>
<script type="text/javascript">
//鼠标进入文本框 
function trun()
{
    var inputcontrol=$("#<%=TextBoxMemLoginID.ClientID %>").val();
    if(inputcontrol=="用户名/邮箱/手机")
    {
        $("#<%=TextBoxMemLoginID.ClientID %>").val("");
    }
}
//移出文本 
function CheckIsEmalOrMobile()
{
     var inputcontrol=$("#<%=TextBoxMemLoginID.ClientID %>").val();
     if(inputcontrol=="")
     {
        $("#<%=TextBoxMemLoginID.ClientID %>").val("用户名/邮箱/手机");
     }else{
        document.getElementById("spanMemLogin").style.display="none";
     }
     
     var inputcontrol1=$("#<%=TextBoxPwd.ClientID %>").val();
     if(inputcontrol1!="")
     {
        document.getElementById("spanPwd").style.display="none";
     }
}
</script>
<div class="login_mod">
    <div class="NavTab clearfix">
        <a class="cur" href="javascript:;">登录</a>
        <a href="javascript:;">注册</a>
    </div>
    <div class="content">
        <!--登录-->
        <div>
            <div class="LoginBox1 clearfix">
                <dl>
                    <dt>用户名：</dt>
                    <dd>
                        <asp:TextBox ID="TextBoxMemLoginID" CssClass="logtxt" runat="server" onfocus='trun()'
                            onblur="CheckIsEmalOrMobile()">用户名/邮箱/手机</asp:TextBox><br />
                        <span id="spanMemLogin" class="null"></span>
                    </dd>
                </dl>
                <dl>
                    <dt>密码：</dt>
                    <dd>
                        <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="logtxt" TextMode="Password" onblur="CheckIsEmalOrMobile()"
                         onkeydown="if(event.keyCode==13){(document.getElementById('<%=ButtonLogin.CilentID %>')).focus();(document.getElementById('<%=ButtonLogin.CilentID %>')).click(); }"></asp:TextBox>
                         <br /><span id="spanPwd" class="null"></span>
                    </dd>
                    <dd><a href="http://<%=ShopNum1.Common.ShopSettings.siteDomain %>/FindBackPassword.aspx" class="forget">忘记密码?</a></dd>
                </dl>
                <dl id="VerifyCode" runat="server">
                    <dt>验证码：</dt>
                    <dd>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBoxCode" onkeydown="if(event.keyCode==13){document.getElementById('Login_ctl00_ButtonLogin').focus();document.getElementById('Login_ctl00_ButtonLogin').click();}"
                                     onblur="existcodedelu()"   runat="server" CssClass="logtxt" Width="80"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="/imagecode.aspx?javascript:Math.random()" id="safecode" border="0" onclick="reloadcode()"
                                          alt="看不清,换一下" style="cursor: hand; vertical-align: middle; margin-left: 10px;" />
                                    <a style="cursor: pointer" onclick="reloadcode()">看不清,换一下</a>
                                </td>
                            </tr>
                            <tr>
                                <td><span id="spanCode" class="null"></span></td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <div class="lbtn">
                    <asp:Button ID="ButtonLogin" class="lobtn" Text="登录" runat="server"  OnClientClick="return checkLoginID();" />
                新用户？ <a href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>' target="_blank"  class="register">立即注册</a>
                    <asp:Label ID="LabelLoginInfo" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="cooperate">使用合作网站账号登录：</div>
           <div class="san_caborate">
                <ShopNum1:SecondLogin ID="SecondLogin" runat="server" SkinFilename="SecondLogin1.ascx" />
            </div>
        </div>
        <!--注册-->
        <div class="hidden">
            <div class="LoginBox1 clearfix PopRegisterBox">
                <dl>
                    <dt>用户名：</dt>
                    <dd>
                         <asp:TextBox ID="TextBoxMemLoginID1" runat="server" CssClass="logtxt" MaxLength="20"
                            onfocus='Showtips("spanName","由英文字母、数字或下划线组成，长度在2-12位.")' onblur="existmemname()"
                            autocomplete="off">                             
                        </asp:TextBox>
                        &nbsp;&nbsp;<span class="null" id="spanName"></span>
                    </dd>
                </dl>
                   <dl>
                    <dt>邮箱：</dt>
                    <dd>
                         <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="logtxt" MaxLength="20"
                            onfocus='Showtips("spanEmail","请填写您常用的邮箱地址，以便找回密码等服务.")' onblur="existemail()"
                            autocomplete="off">
                        </asp:TextBox>
                        &nbsp;&nbsp;<span class="null" id="spanEmail"></span>
                    </dd>
                </dl>
                <dl>
                    <dt>登录密码：</dt>
                    <dd>
                         <asp:TextBox ID="TextBoxPwd1" runat="server" CssClass="logtxt" MaxLength="15" TextMode="Password"
                            onblur="existepwd()" onfocus='Showtips("spanPwd1","6-15个英文字母或数字，字母区分大小写")'></asp:TextBox>
                       &nbsp;&nbsp;<span class="null" id="spanPwd1"></span>
                    </dd>
                </dl>
                <dl>
                    <dt>确认密码：</dt>
                    <dd>
                         <asp:TextBox ID="TextBoxRePwd" CssClass="logtxt" onkeydown="if(event.keyCode==13){document.getElementById('<%=ButtonConfirm.ClientID %>').focus();document.getElementById('<%=ButtonConfirm.ClientID %>').click();}"
                            runat="server" MaxLength="15" TextMode="Password" onblur="existesurepwd()" onfocus='Showtips1("spanSurePwd","再次输入密码")'></asp:TextBox>
                        &nbsp;&nbsp;<span class="null" id="spanSurePwd"></span>
                    </dd>
                </dl>
             
                <dl id="Dl1" runat="server">
                    <dt>验证码：</dt>
                    <dd>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBoxCode1" onkeydown="if(event.keyCode==13){document.getElementById('Login_ctl00_ButtonLogin').focus();document.getElementById('Login_ctl00_ButtonLogin').click();}"
                                    onblur="existcode()"      runat="server" CssClass="logtxt" Width="80"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="/imagecode.aspx?javascript:Math.random()" id="safecode1" border="0" onclick="reloadcode()1"
                                        alt="看不清,换一下" style="cursor: hand; vertical-align: middle; margin-left: 10px;" />
                                    <a style="cursor: pointer" onclick="reloadcode1()">看不清,换一下</a>
                                    &nbsp;&nbsp;<span id="spanCode1" class="null"></span>
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <div class="zhucexieyi">
                    <asp:CheckBox ID="CheckBoxIfAgree" Checked="true" runat="server" Text="" />我已看过并接受
                    <a href='<%= ShopUrlOperate.RetUrl("MemberRegProtocol") %>' target="_blank">《用户注册协议》</a>
                    <br />
                    <span id="spanIfAgree" visible="false"></span>
                </div>
                <div class="lbtn">
                   <%-- <asp:Button ID="ButtonTwo" class="lobtn" Text="注册" runat="server"  OnClientClick="return checkLoginID();" />--%>
                   <asp:Button ID="ButtonTwo" runat="server" OnClientClick="return agreement();"
                                        class="lobtn" value="同意以上协议"  Text="注册"/>
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>    
<script language="javascript" type="text/javascript">
function SecondLoginUrl(id)
{
$.ajax
({
  url:"/api/SecondLogin.ashx",
  data:"type=secondlogin&SecondID="+id+"",
  success:function(url){
  if(url!="")
  {
  window.open(url);
 window.close();
//    window.location.href=url;
  }
  }
})
}
//登录验证码
function reloadcode()
{
var verify=document.getElementById('safecode');
verify.setAttribute('src','/imagecode.aspx?'+Math.random());
}
//注册验证码
function reloadcode1()
{
var verify1=document.getElementById('safecode1');
verify1.setAttribute('src','/imagecode.aspx?'+Math.random());
}

function checkLoginID()
{
$("#<%=LabelLoginInfo.ClientID%>").html("");
   var loginid=document.getElementById('<%=TextBoxMemLoginID.ClientID %>').value;
   var password=document.getElementById('<%=TextBoxPwd.ClientID %>').value;
    document.getElementById("spanMemLogin").innerHTML=="";
     document.getElementById("spanPwd").innerHTML="";
   var errc=0;
   if(loginid=="用户名/邮箱/手机")
   {
     document.getElementById("spanMemLogin").innerHTML="请输入用户名";
     document.getElementById("spanMemLogin").className="onError2";
     errc=1;
   }
     var regUser = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,12}$/
     if(regUser.test(loginid)) 
     { 
        //是会员名
        $("#<%=HiddenFieldLoginType.ClientID %>").val("1");
     }
     //邮箱验证
     var regEmail =/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/; 
     if(regEmail.test(loginid)) 
     { 
        //是邮箱
       $("#<%=HiddenFieldLoginType.ClientID %>").val("2");
     }
   if(password=="")
   {
    
    document.getElementById("spanPwd").innerHTML="密码不能为空";
         document.getElementById("spanPwd").className="onError2";
    
    errc=1;
   }
   if(errc==1)
   {
     return false;
   }
    $(".login").hide();
   $(".login_info").show();
   return true;
}
</script>

<script language="javascript" type="text/javascript">
$(document).ready(function(){
    $('.NavTab').autoTab();
});
jQuery.fn.extend({
	// 自动切换
	autoTab: function(){
		if(this.length <= 0){
			return false;
		}
		var main = this;
		var ctrls = main.children();
		var target = main.next().children();
		ctrls.bind({
		    click: function(e){
		        var $this = $(this);
		        var index = ctrls.index($this);
		        ctrls.removeClass('cur');
				$this.addClass('cur');
				target.hide().eq(index).show();
		    }
		});
	}
});
</script>

<asp:HiddenField ID="HiddenFieldLoginType" runat="server" />
<input id="HiddenExistMemLoginID" type="hidden" value="false" />
<input id="HiddenExistEmail" type="hidden" value="false" />
<input id="HiddenExistPwd" type="hidden" value="false" />
<input id="HiddenExistSurePwd" type="hidden" value="false" />
<input id="HiddenExistPublishMemlogid" type="hidden" value="false" />
<input id="HiddenBarBoxUL" type="hidden" value="0" />
