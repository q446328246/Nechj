<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberRegister.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.skins.MemberRegister" %>
<script src="Themes/Skin_Default/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
<!--第三方登录-->
<script type="text/javascript">
//<![CDATA[
    var theForm = document.forms[0];
    if (!theForm) {
        theForm = document.form1;
    }


    function SecondLogin(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.secondEVENTTARGET.value = eventTarget;
            theForm.secondEVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }

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

</script>
<script type="text/javascript">

    function Showtips(name, showvalue) {
        document.getElementById(name).innerHTML = showvalue; ;
        document.getElementById(name).className = "onTips";
    }  
</script>
<!--开始注册-->
<script type="text/javascript">

    //开始注册
    //<![CDATA[
    //验证用户名

    function existmemname() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxMemLoginID.ClientID%>").val();
        var context = document.getElementById("spanName");

        var reg = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,20}$/;
        if (inputcontrol != "") {
            if (reg.test(inputcontrol)) {
                context.innerHTML = "数据查询中..";
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: encodeURI("type=userisexist&UserID=" + inputcontrol + ""), //中文编码
                    success: function (result) {
                        if (result != null) {
                            if (result == "true") {
                                // context.innerHTML = "帐号已存在,请直接<a href='Login.aspx' target='_blank'>登录</a>"; 
                                context.innerHTML = "帐号已存在,请直接<a href='Login.aspx' >登录</a>";
                                context.className = "onError";
                                boolresult = false;
                            } else {
                                context.innerHTML = "用户名可以使用";
                                context.className = "onCorrect";
                                boolresult = true;
                            }
                        } else {
                            boolresult = false;
                        }
                    }
                });
            }
            else {
                context.innerHTML = "用户名格式不正确";
                context.className = "onError";
                
                boolresult = false;
            }
        }
        else {

            context.innerHTML = "用户名不能为空";
            context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

    //验证emall是否存在
    function existemail() {
        var boolresult = true;
        var inputcontrol = $("#<%=txtMemberName.ClientID%>").val();
        var context = document.getElementById("spanMemberName");
        if (inputcontrol != "") {
//            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
//            if (reg.test(inputcontrol)) {
//                context.innerHTML = "数据查询中..";
//                $.ajax({
//                    url: "/api/CheckMemberLogin.ashx",
//                    data: "type=emailisexist&Email=" + inputcontrol + "",
//                    success: function (result) {
//                        if (result != null) {
//                            if (result == "true") {
//                                context.innerHTML = "邮箱已存在,请直接<a href='Login.aspx' >登录</a>";
//                                context.className = "onError";
//                                boolresult = false;
//                            } else {
                                context.innerHTML = "用户姓名可以使用";
                                context.className = "onCorrect";
                                boolresult = true;
//                            }
//                        } else {
//                            boolresult = false;
//                        }
//                    }
//                });
//            }
//            else {
//                context.innerHTML = "电子邮箱格式不正确";
//                context.className = "onError";
//                boolresult = false;
//            }
        }
        else {
            context.innerHTML = "用户姓名不能为空";
            context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

    //验证手机号码是否使用
    function existMobile() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxMobile.ClientID%>").val();
        var context = document.getElementById("spanMobile");
        if (inputcontrol != "") {
            var reg = /^1[2|3|4|5|6|7|8|9][0-9]\d{8}$/;
            if (reg.test(inputcontrol)) {
                context.innerHTML = "数据查询中..";
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: "type=mobileisexist&Mobile=" + inputcontrol + "",
                    success: function (result) {
                        if (result != null) {
                            if (result == "true") {
                                context.innerHTML = "手机号码已经存在,请直接<a href='Login.aspx' >登录</a>";
                                context.className = "onError";
                                boolresult = false;
                            } else {

                                context.innerHTML = "手机可以使用";
                                context.className = "onCorrect";
                                boolresult = true;
                            }
                        } else {
                            boolresult = false;
                        }
                    }
                });
            }
            else {
                context.innerHTML = "手机格式不正确";
                context.className = "onError";
                boolresult = false;
            }
        }
        else {
            context.innerHTML = "手机不能为空";
            context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

    //验证身份证号码是否使用
    function existIdentityCard() {
        var boolresult = true;
        var inputcontrol = $("#<%=txtIdentityCard.ClientID%>").val();
        var context = document.getElementById("spanIdentityCard");
        if (inputcontrol != "") {
            var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
            if (reg.test(inputcontrol)) {
                context.innerHTML = "数据查询中..";
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: "type=identifycardisexist2&identifyCard=" + inputcontrol + "",
                    success: function (result) {
                        if (result != null) {
                            if (result == "true") {
                                context.innerHTML = "身份证号码可以使用";
                                context.className = "onCorrect";
                                boolresult = true;
                            } else {

                                context.innerHTML = "身份证号码可以使用";
                                context.className = "onCorrect";
                                boolresult = true;
                           }
                        } else {
                            boolresult = true;
                        }
                    }
                });
            }
            else {

                context.innerHTML = "身份证号码可以使用";
                context.className = "onCorrect";
                boolresult = true;
            }
        }
        else {

            context.innerHTML = "身份证号码可以使用";
            context.className = "onCorrect";
            boolresult = true;
        }
        return boolresult;
    }

    //验证密码
    function existepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxPwd.ClientID%>").val();
        var context = document.getElementById("spanPwd");
        if (inputcontrol != "") {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                var hid = document.getElementById("HiddenExistPwd");
                hid.value = "true";
                context.innerHTML = "密码正确"; context.className = "onCorrect";
                boolresult = true;
            }
            else {
                context.innerHTML = "密码格式不正确"; context.className = "onError";
                boolresult = false;
            }
        }
        else {
            context.innerHTML = "密码不能为空"; context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

    //验证确认密码
    function existesurepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxRePwd.ClientID%>").val();
        var context = document.getElementById("spanSurePwd");
        var pwd = $("#<%=TextBoxPwd.ClientID%>").val();
        if (inputcontrol == pwd) {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                context.innerHTML = "确认密码正确";
                context.className = "onCorrect";
                boolresult = true;
            }
            else {
                context.innerHTML = "确认密码格式不正确"; context.className = "onError";
                boolresult = false;
            }
        }
        else {
            context.innerHTML = "两次密码不一致"; context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

    //验证码
    function existcode() {

        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxCode.ClientID%>").val();
        var context = document.getElementById("spanCode");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=getverifycode&code=" + inputcontrol + "",
                success: function (result) {
                    if (result == "true") {
                        context.innerHTML = "验证码正确";
                        context.className = "onCorrect";
                        boolresult = true;

                    } else {
                        context.innerHTML = "验证码错误";
                        context.className = "onError";
                        boolresult = false;
                    }
                }
            });
        }
        else {
            context.innerHTML = "验证码不能为空";
            context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }</script>
<script type="text/javascript">

    $(document).ready(function () {
        $(".login").show();
        $(".login_info").hide();
    });

    function reloadcode() {
        var verify = document.getElementById('Img1');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    function agreement() {

        var ss = false;
        var check = document.getElementById("<%= CheckBoxIfAgree.ClientID %>");
        if (check.checked) {

            //&&existpublishmemlogid()  推荐会员的检查 
            document.getElementById("spanIfAgree").innerHTML = "";
            var HiddenBarBoxValue = $("#HiddenBarBoxUL").val();

            if (HiddenBarBoxValue == "0") {
                if (!existmemname()) {
                    ss = false;
                }
            }

            if (HiddenBarBoxValue == "1") {

                if (!existMobile()) {
                    ss = false;
                }

            }

            if (HiddenBarBoxValue == "2") {

                if (!existemail()) {
                    ss = false;
                }
            }

        if ((existepwd() && existesurepwd() && existcode()) && (existmemname() && existMobile() && existemail() && existIdentityCard())) {
                ss = true;
            }
            else {
                ss = false;
            }
        }
        else {
            document.getElementById("spanIfAgree").innerHTML = "<font color=red>还没接受用户协议</font>";
            ss = false;
        }
        if (ss == true) {
            $(".login").hide();
            $(".logininfo").show();
        }
        return ss;
    }

    function Showtips(name, showvalue) {
        document.getElementById(name).innerHTML = showvalue;
        document.getElementById(name).className = "onTips";
    }
</script>
<!--未登录时显示-->
<div class="wrapBox">
    <div id="divregester" runat="server" class="fregist">
        <div class="fcon">
            <div class="form form1 fl">
                <!--用户名快速注册-->
                <div class="LoginWays" style="display: block;">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr class="item" id="Reg3">
                            <td class="label">
                                用户名：
                            </td>
                            <td id="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="text"  
                                        onblur="existmemname()" onfocus='Showtips("spanName","请填写您的用户名")' 
                                        Enabled="False" ></asp:TextBox>
                                    <span class="null" id="spanName"></span><i class="i1"></i>
                                </div>
                            </td>
                        </tr>
                        <tr class="item" id="Reg0">
                            <td class="label">
                                用户姓名：
                            </td>
                            <td class="td2 tl">
                                <%--<asp:TextBox ID="txtMemberName" runat="server" CssClass="text"></asp:TextBox>--%>
                                <div style="position: relative;">
                                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="text" MaxLength="40" onblur="existemail()"
                                        onfocus='Showtips("spanMemberName","请填写您的用户姓名")'>
                                    </asp:TextBox>
                                    <span id="spanMemberName" class="null"></span><i class="i3"></i>
                                </div>
                            </td>
                        </tr>
                        <tr class="item" id="Reg4">
                            <td class="label">
                                身份证号：
                            </td>
                            <td class="td2 tl">
                                <div style="position: relative;">
                                <asp:TextBox ID="txtIdentityCard" runat="server" CssClass="text"  onblur="existIdentityCard()"
                                    onfocus='Showtips("spanIdentityCard","请填写您的身份证号码")'></asp:TextBox> 
                                <span id="spanIdentityCard" class="null"></span><i class="i4"></i>
                                    </div>
                            </td>
                        </tr>
                        <tr class="item" id="Reg1">
                            <td class="label">
                                手机号码：
                            </td>
                            <td class="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="text" TextMode="SingleLine" MaxLength="100"  onblur="existMobile()"
                                        onfocus='Showtips("spanMobile","请填写您常用的手机号码，以便找回密码等服务")'>
                                    </asp:TextBox>
                                    <span id="spanMobile" class="null"></span><i class="i2"></i>
                                </div>
                            </td>
                        </tr>
                        <tr class="item" id="Reg2" >
                            <td class="label">
                                电子邮箱：
                            </td>
                            <td class="td2 tl">
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="text"></asp:TextBox>
                                <%--<div style="position: relative;">
                                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="text" MaxLength="40" onblur="existemail()"
                                        onfocus='Showtips("spanEmail","请填写您常用的邮箱地址，以便找回密码等服务")'>
                                    </asp:TextBox>
                                    <span id="spanEmail" class="null"></span><i class="i3"></i>
                                </div>--%>
                            </td>
                        </tr>
                        <tr class="item">
                            <td class="label">
                                密码：
                            </td>
                            <td class="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="text" MaxLength="15" TextMode="Password"
                                        onblur="existepwd()" onfocus='Showtips("spanPwd","6-15个英文字母或数字，字母区分大小写")'></asp:TextBox>
                                    <span id="spanPwd" class="null"></span><s></s>
                                </div>
                            </td>
                        </tr>
                        <tr class="item">
                            <td class="label">
                                确认密码：
                            </td>
                            <td class="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxRePwd" CssClass="text" onkeydown="if(event.keyCode==13){document.getElementById('<%=ButtonConfirm.ClientID %>').focus();document.getElementById('<%=ButtonConfirm.ClientID %>').click();}"
                                        runat="server" MaxLength="15" TextMode="Password" onblur="existesurepwd()" onfocus='Showtips("spanSurePwd","再次输入密码")'></asp:TextBox>
                                    <span id="spanSurePwd" class="null"></span><s></s>
                                </div>
                            </td>
                        </tr>
                        <tr class="item" id="VerifyCode" runat="server">
                            <td class="label">
                                验证码：
                            </td>
                            <td class="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxCode" CssClass="text textcode" onkeydown="if(event.keyCode==13){document.getElementById('<%=ButtonConfirm.ClientID %>').focus();document.getElementById('<%=ButtonConfirm.ClientID %>').click();}"
                                        runat="server" onblur="existcode()" onfocus='Showtips("spanCode","请输入验证码")'>
                                    </asp:TextBox>
                                    <img src="/imagecode.aspx" id="Img1" onclick="reloadcode()" alt="看不清?点一下" class="code_img" />
                                    <a onclick="reloadcode()">看不清楚？点一下</a> <span id="spanCode" class="null"></span>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 10px;">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr class="item" style="height: 30px;">
                            <td>
                                <p align="center">
                                    &nbsp;</p>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxIfAgree" Checked="true" runat="server" Text="" />我已看过并接受
                                <a href='<%= ShopUrlOperate.RetUrl("MemberRegProtocol") %>' target="_blank">《用户注册协议》</a>
                                <br />
                                <span id="spanIfAgree" visible="false"></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                            </td>
                            <td>
                                <div class="login">
                                    <asp:Button ID="ButtonConfirm" runat="server" OnClientClick="return agreement();"
                                        class="btn-img btn-regist2" value="同意以上协议" Text="注册" OnClick="ButtonConfirm_Click" />
                                </div>
                                <div class="logininfo" style="display: none">
                                    <img src="/main/themes/skin_default/Images/LoginBtn.png" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                        <div class="BarBox fr">
                <div>
                    <%--<ul>
                        <li class="cur0"><a href="javascript:;">
                            <img src="Themes/Skin_Default/Images/Registericon3.jpg" />
                            <span>用户名快速注册</span> </a></li>
                        <li class="other"><a href="javascript:;">
                            <img src="Themes/Skin_Default/Images/Registericon1.jpg" />
                            <span>手机快速注册</span> </a></li>
                        <li><a href="javascript:;">
                            <img src="Themes/Skin_Default/Images/Registericon2.jpg" />
                            <span>邮箱快速注册</span> </a></li>
                    </ul>--%>
                </div>
                <div class="yzhuce">
                    已经注册过的用户，现在就 <a href="Login.aspx">登录</a>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<!--登录后显示-->
<div id="divAgainregester" runat="server" class="regester">
    <div class="regester_con">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="lmf_padd">
                    <div class="lmf_gth">
                        <span>您好！您已经成功登录！</span>
                    </div>
                    <div class="member_text">
                        您登录本商城的用户名为： <span>
                            <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，您随时可以使用此用户名享受便宜又放心的购物乐趣。
                    </div>
                    <div class="lmf_member lmf_member1">
                        <a href='<%=ShopUrlOperate.RetMemberUrl("m_index") %>'>进入会员中心</a></div>
                    <div class="lmf_member">
                        <a href='<%=ShopUrlOperate.RetUrl("default") %>'>立刻去购物</a></div>
                </td>
            </tr>
        </table>
    </div>
</div>
<input id="HiddenExistMemLoginID" type="hidden" value="false" />
<input id="HiddenExistEmail" type="hidden" value="false" />
<input id="HiddenExistPwd" type="hidden" value="false" />
<input id="HiddenExistSurePwd" type="hidden" value="false" />
<input id="HiddenExistPublishMemlogid" type="hidden" value="false" />
<input id="HiddenBarBoxUL" type="hidden" value="0" />
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('.BarBox ul').autoTab();
    });
    jQuery.fn.extend({
        // 自动切换
        autoTab: function () {
            if (this.length <= 0) {
                return false;
            }
            var main = this;
            var ctrls = main.children();
            var target = $('.BarBox').prev().children();
            ctrls.bind({
                click: function (e) {
                    var $this = $(this);
                    var index = ctrls.index($this);

                    for (var i = 0; i < 3; i++) {
                        ctrls.removeClass('cur' + i);
                        $("#Reg" + i).hide();
                    }
                    $this.addClass('cur' + index);
                    $("#Reg" + index).show();
                    $("#HiddenBarBoxUL").val(index);
                    if (index == "0") {
                        $("#<%=TextBoxMobile.ClientID%>").val("");
                        $("#<%=TextBoxEmail.ClientID%>").val("");
                    }
                    if (index == "1") {
                        $("#<%=TextBoxEmail.ClientID%>").val("");
                        $("#<%=TextBoxMemLoginID.ClientID%>").val("");
                    }
                    if (index == "2") {
                        $("#<%=TextBoxMobile.ClientID%>").val("");
                        $("#<%=TextBoxMemLoginID.ClientID%>").val("");
                    }
                    $("#<%=TextBoxPwd.ClientID%>").val("");
                    $("#<%=TextBoxRePwd.ClientID%>").val("");
                    $("#<%=TextBoxCode.ClientID%>").val("");
                    reloadcode();
                }
            });
        }
    });
</script>
