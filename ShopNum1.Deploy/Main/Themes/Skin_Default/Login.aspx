<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.Login" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="content-type" content="no-cache, must-revalidate" />
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <script src="Themes/Skin_Default/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="~/main/Themes/Skin_Default/inc/style/common.css" rel="stylesheet" type="text/css" />
    <link href="~/main/Themes/Skin_Default/inc/style/login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            height: 100%;
        }
        body
        {
            background: #ebebeb;
        }
    </style>
    <script type="text/javascript">

        document.onkeydown = function (e) {
            var keyCode;
            var element;
            /*ie support event&keyCode*/
            keyCode = event.keyCode;
            element = event.srcElement;
            if (keyCode == 13 && element.type == 'text') {
                document.getElementById("<%=ButtonLogin.ClientID %>").click();
            }
        }
        
    </script>
    <%--    <script type="text/javascript">
        $(document).ready(function () {
            if ($("#Login_ctl00_LabelMemLoginID").text() != "") {
                document.getElementById('denglu').style.display = "none";

            }
            $("#FlowCate").mouseover(function () {
                $("#ThrCategory").show();
                $("#ThrCategory").focus();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });
            $("#ThrCategory").mouseover(function () {
                $("#ThrCategory").show();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });
        });
    </script>--%>
    <!--[if lte IE 6]>
    <script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a');
    </script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <div id="top">
        <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>'>
            <div class="top_box">
                <div class="logo_login">
                    塘江国际电子商务中心</div>
            </div>
        </a>
    </div>
    <!--//head End-->
    <!--main Start-->
    <div id="login_main">
        <script language="javascript" type="text/javascript">

            //验证码
            var boolresult = true;
            function existcode() {
                var inputcontrol = $("#<%= TextBoxCode.ClientID %>").text();
                ("#<%= TextBoxCode.ClientID %>").removeClass("login_text2");

                var context = document.getElementById("spanCode");
                if (inputcontrol != "") {
                    $.ajax({
                        url: "/api/CheckMemberLogin.ashx",
                        data: "type=getverifycode&code=" + inputcontrol + "",
                        success: function (result) {
                            if (result == "true") {
                                //                    context.innerHTML="验证码正确";
                                //                    context.className="onCorrect";
                                document.getElementById("spanCode").style.display = "none";
                                $("spanCode").removeClass("loginError1");
                                boolresult = true;

                            } else {
                                context.innerHTML = "验证码错误";
                                context.className = "loginError1";
                                boolresult = false;
                            }
                        }
                    });
                }
                else {
                    context.innerHTML = "验证码不能为空";
                    context.className = "loginError1";
                    boolresult = false;
                }
                return boolresult;
            }</script>
        <script type="text/javascript">
            var theForm = document.forms[0];
            if (!theForm) {
                theForm = document.form1;
            }
            function SecondLogin(eventTarget, eventArgument) {

                if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                    var SE = document.getElementById("secondEVENTTARGET");
                    SE = eventTarget;
                    theForm.secondEVENTTARGET.value = SE;
                    theForm.secondEVENTARGUMENT.value = eventArgument;

                    theForm.submit();
                }
            }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {

                //("#Login_ctl00_TextBoxMemLoginID").text("");
                $("#<%= LabelLoginInfo.ClientID %>").text("");
                $("#<%= TextBoxCode.ClientID %>").val("");


                if ($("#<%= LabelLoginInfo.ClientID %>").text() == "") {
                    $("#<%= LabelLoginInfo.ClientID %>").removeClass("loginError2");
                     $("#Login_ctl00_LabelLoginInfo").text("");
                    else{
                    $("#<%= LabelLoginInfo.ClientID %>").addClass("");
                }
                        $(".login").show();
                      $(".login_info").hide();
            });
            function SecondLoginUrl(id) {
                $.ajax({
                    url: "/api/SecondLogin.ashx",
                    data: "type=secondlogin&SecondID=" + id + "",
                    success: function (url) {
                        if (url != "") {
                            window.location.href = url;
                        }
                    }
                });
            }
            //鼠标进入文本框 
            function trun() {
                $("#<%= TextBoxMemLoginID.ClientID %>").addClass("login_text1");
                // document.getElementById("Login_ctl00_TextBoxMemLoginID").className="login_text1";
                var inputcontrol = $("#<%=TextBoxMemLoginID.ClientID %>").val();
                if (inputcontrol == "用户名/用户编号") {
                    $("#<%=TextBoxMemLoginID.ClientID %>").val("");
                }
            }
            //鼠标进入文本框 
            function trun1() {
                //  document.getElementById("Login_ctl00_TextBoxPwd").className="login_text1";
                $("#<%= TextBoxPwd.ClientID %>").addClass("login_text1");
            }
            //鼠标进入文本框 
            function trun2() {
                //document.getElementById("Login_ctl00_TextBoxCode").className="login_text2";
                $("#<%= TextBoxCode.ClientID %>").addClass("login_text2");
            }

            //移出文本 
            function CheckIsEmalOrMobile() {
                var inputcontrol = $("#<%=TextBoxMemLoginID.ClientID %>").val();
                if (inputcontrol == "") {
                    $("#<%= TextBoxMemLoginID.ClientID %>").removeClass("login_text1");

                    $("#<%=TextBoxMemLoginID.ClientID %>").val("用户名/用户编号");
                }
                else {
                    $("#<%= TextBoxMemLoginID.ClientID %>").removeClass("login_text1");
                    document.getElementById("spanMemLogin").style.display = "none";
                }

                var inputcontrol1 = $("#<%=TextBoxPwd.ClientID %>").val();
                if (inputcontrol1 != "") {
                    $("#<%= TextBoxPwd.ClientID %>").removeClass("login_text1");

                    //        document.getElementById("Login_ctl00_TextBoxPwd").className="text login_text";

                    document.getElementById("spanPwd").style.display = "none";
                } else {

                    $("#<%= TextBoxPwd.ClientID %>").removeClass("login_text1");
                }
            }
        </script>
        <!--未登录时显示-->
        <div class="login_style">
            <div class="img_box">
            </div>
            <div class="login">
                <p>
                    <asp:TextBox ID="TextBoxMemLoginID" CssClass="user" runat="server" onfocus='trun()'
                        MaxLength="20" onblur="CheckIsEmalOrMobile()"></asp:TextBox>
                </p>
                <p class="text_info" style="display: block">
                    <span id="spanMemLogin" class="null"></span><i class="i1"></i>
                </p>
                <p>
                    <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="password" onfocus='trun1()'
                        TextMode="Password" MaxLength="15" onblur="CheckIsEmalOrMobile()" onkeydown="if(event.keyCode==13){(document.getElementById('<%=ButtonLogin.CilentID %>')).focus();(document.getElementById('<%=ButtonLogin.CilentID %>')).click(); }"></asp:TextBox>
                </p>
                <p class="text_info" style="display: block">
                    <span id="spanPwd" class="null"></span><s></s>
                </p>
                <p>
                    <asp:TextBox ID="TextBoxCode" onblur="existcode()" onfocus='trun2()' onkeydown="if(event.keyCode==13){document.getElementById('Login_ctl00_ButtonLogin').focus();document.getElementById('Login_ctl00_ButtonLogin').click();}"
                        runat="server" CssClass="code"></asp:TextBox>
                    <span class="code_img">
                        <img src="imagecode.aspx?javascript:Math.random()" id="safecode" onclick="reloadcode()"
                            alt="看不清?点一下" /></span><span class="blue"> <a onclick="reloadcode()">看不清楚?点一下 </a>
                    </span>
                </p>
                <p class="text_info" style="display: block">
                    <span id="spanCode" class="null"></span>
                    <asp:Label ID="LabelLoginInfo" runat="server" Font-Size="15px" Text="" ForeColor="Red" class="loginError2"></asp:Label>
                </p>
                <p style="display: none">
                    <asp:DropDownList ID="LoginValidity" runat="server">
                        <asp:ListItem Value="" Selected="True">即时</asp:ListItem>
                        <asp:ListItem Value="1h">一小时</asp:ListItem>
                        <asp:ListItem Value="1d">一天</asp:ListItem>
                        <asp:ListItem Value="1w">一星期</asp:ListItem>
                        <asp:ListItem Value="1m">一个月</asp:ListItem>
                        <asp:ListItem Value="1y">一年</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p style="display: none">
                    <td>
                        <input type="checkbox" />记住用户名
                    </td>
                    <td>
                        <input type="checkbox" />自动登录
                    </td>
                </p>
                <p>
                    <asp:Button ID="ButtonLogin" class="btn_login" runat="server" UseSubmitBehavior="false"
                        OnClientClick="if(checkLoginID()){this.disabled='disabled';} else{return false;}"
                        OnClick="ButtonLogin_Click" />
                </p>
                <p class="bottom">
                    友情提示:<br />
                    <%--如果您还没有登录账号，请先<a target="_blank" class="blue" href="MemberRegister.aspx" class="RegisLink">申请店铺</a>或<a target="_blank" class="blue" href="MemberRegisterMandarin.aspx" class="RegisLink">注册用户</a>然后登录<br />--%>
                    如果您<a target="_blank" class="red" href="FindBackPassword.aspx" class="FindLink">忘了密码？</a>请申请找回密码
                </p>
            </div>
        </div>
        <!--登录后显示-->
        <div id="divAgainLogin" runat="server" class="regester" visible="False">
            <div class="regester_con">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="lmf_padd">
                            <div class="lmf_gth">
                                <span>您好！您已经成功登陆！</span>
                            </div>
                            <div class="member_text">
                                您登陆本商城的用户名为： <span>
                                    <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，您随时可以使用此用户名享受便宜又放心的购物乐趣。
                            </div>
                            <div class="lmf_member lmf_member1">
                                <a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'>进入会员中心</a></div>
                            <div class="lmf_member">
                                <a href='<%=ShopUrlOperate.RetUrl("default") %>'>立刻去购物</a></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
            <input type="hidden" name="secondEVENTARGUMENT" id="secondEVENTARGUMENT" value="" />
        </div>
        <script language="javascript" type="text/javascript">
            function reloadcode() {
                var verify = document.getElementById('safecode');
                verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
            }
            function checkLoginID() {

                //document.getElementById('HiddenFielddelu').value=1;
                $("#<%=LabelLoginInfo.ClientID%>").html("");
                var loginid = document.getElementById('<%=TextBoxMemLoginID.ClientID %>').value;
                var password = document.getElementById('<%=TextBoxPwd.ClientID %>').value;
                var BoxCode = document.getElementById('<%=TextBoxCode.ClientID %>').value;

                document.getElementById("spanMemLogin").innerHTML == "";
                document.getElementById("spanPwd").innerHTML = "";
                var errc = 0;

                if (BoxCode == "") {
                    document.getElementById("spanCode").innerHTML = "请输入验证码";
                    document.getElementById("spanCode").className = "loginError";
                    errc = 1;
                }
                if (loginid == "") {

                    document.getElementById("spanMemLogin").innerHTML = "请输入用户名";
                    document.getElementById("spanMemLogin").className = "loginError";
                    errc = 1;
                }

                //     var regUser = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,12}$/
                //     if(regUser.test(loginid)) 
                //     { 
                //        //是会员名
                //        $("#<%=HiddenFieldLoginType.ClientID %>").val("1");
                //     }
                //     //邮箱验证
                //     var regEmail =/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/; 
                //     if(regEmail.test(loginid)) 
                //     { 
                //        //是邮箱
                //       $("#<%=HiddenFieldLoginType.ClientID %>").val("2");
                //     }
                if (password == "") {

                    document.getElementById("spanPwd").innerHTML = "密码不能为空";
                    document.getElementById("spanPwd").className = "loginError";
                    errc = 1;
                }
                if (errc == 1) {
                    $("#<%= LabelLoginInfo.ClientID %>").removeClass("loginError2");
                    return false;
                }

                if (boolresult == false) {
                    return false;
                }
                $(".login").hide();
                $(".login_info").show();
                return true;
            }
        </script>
        <asp:HiddenField ID="HiddenFieldLoginType" runat="server" />
        <!--1 会员名 2 邮箱-->
        <input id="HiddenFielddelu" type="hidden" />
    </div>
    <!--//main End-->
    <!--foot Start-->
    <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />
    <!--//foot End-->
    </form>
</body>
</html>
