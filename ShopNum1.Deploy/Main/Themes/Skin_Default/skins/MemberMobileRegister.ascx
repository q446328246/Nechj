<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberMobileRegister.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.skins.MemberMobileRegister" %>
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
    var timerId;
    var $thisid;
    $(function () {

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });
        $("#J_ver_btn").click(function () {
            if ($("#spanName").text() != "手机账号可以使用") {
                return alert("手机号码不可用"); ;
            }

            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");

            $("#spanConfirm").get(0).className="";
            $("#spanConfirm").attr("className", "");
            // $("#spanShowMsg").get(0).className="onCorrect1";
            $("#spanShowMsg").text("短信已发送，请耐心等待...");
            $("#spanShowMsg").attr("style", "color:green; padding-left:10px;");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/MemberMobileRegister.ashx?type=2&Mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").val(), null, function (data) {
                //alert("手机短信验证码已发送，请耐心等待......");
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("短信发送出现异常，请重新验证");
                }
            });
        });

        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("验证码是6位字符");
            $("#spanConfirm").get(0).className="";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            }
            else {
                $.get("/Api/MemberMobileRegister.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").val(), null, function (data) {
                    if (data == "1") {
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");
                        $("#spanShowMsg").get(0).className = "";
                        $("#spanShowMsg").text("");
                       
                    }
                    else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
                        
                    }
                });
            }
        });
    });

    var i = 60;
    function goTo() {
        i--;
        $thisid.val("已发送验证码(" + i + "秒)");
        if (i == 0) {
            $thisid.val("免费获取验证码");
            clearInterval(timerId); i = 60;
            $thisid.removeAttr("disabled");
        }
    }
</script>
<script type="text/javascript" language="javascript">
    function checkkey() {
        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("请输入验证码");
            return;
        }

        $.get("/Api/MemberMobileRegister.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").val(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpPayPwd.aspx?Mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").val() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
            }
        });
    }

    function GoURL() {
        window.location.href = "A_UpPayPwd.aspx?Mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val() + "&type=Email";
    };
    function goNext() {
        setTimeout(GoURL, 1000);
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
                                context.innerHTML = "手机账号已存在,请直接<a href='Login.aspx' >登录</a>";
                                context.className = "onError";
                                boolresult = false;
                            } else {
                                context.innerHTML = "手机账号可以使用";
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
                context.innerHTML = "手机账号有误";
                context.className = "onError";

                boolresult = false;
            }
        }
        else {

            context.innerHTML = "手机账号不能为空";
            context.className = "onError";
            boolresult = false;
        }
        return boolresult;
    }

</script>
<script type="text/javascript">

    $(document).ready(function () {
        $(".login").show();
        $(".login_info").hide();
    });


    function agreement() {


        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("请输入验证码");
            return;
        }

        $.get("/Api/MemberMobileRegister.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").val(), null, function (data) {
            if (data == "1") {
//                window.location.href = "A_UpPayPwd.aspx?Mobile=" + $("#<%=TextBoxMemLoginID.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
            }
        });
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
            if (existmemname()) {
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
                                手机号码：
                            </td>
                            <td id="td2 tl">
                                <div style="position: relative;">
                                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="text" onblur="existmemname()"
                                        onfocus='Showtips("spanName","请输入您的手机号码")'>
                                    </asp:TextBox>
                                    <span class="null" id="spanName"></span><i class="i2"></i>
                                </div>
                            </td>
                        </tr>
                        <tr class="item" id="VerifyCode" runat="server">
                            <td class="label">
                                验证码：
                            </td>
                            <td class="td2 tl">
                                <div style="margin-top: 10px;">
                                    <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                                        style="width: 150px;" />
                                    <input type="text" id="M_code" name="code" data-tip="验证码" maxlength="6" class="intext intext_short nullv tov vfb"
                                        autocomplete="off" runat="server" disabled="disabled" />
                                    <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到短信验证码？
                                    </a><span id="spanConfirm"></span>
                                    <div style="display: none;" class="tooltip cp_tooltip">
                                        短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                                    </div>
                                </div>
                                <span class="vc vf" id="yzMsg" style="display: none">请输入验证码 </span>
                                <div class="form_row form_text_row">
                                    <span class="form_left"><span id="spanShowMsg"
                                        state="0" style="color: Red; padding-left: 20px;text-align:right;"></span></span><span class="form_right gw">
                                        <%--验证码是6位数字--%>
                                    </span>
                                </div>
                                
                                <div id="J_phone_msg_row" class="form_row form_height_auto_row nice_info_row clearfix">
                                    <span class="form_left"></span>
                                    <div class="form_right">
                                        <div class="phone_info">
                                            <div id="J_phone_info">
                                                <span class="l">短信验证码发送后30分钟内均可使用 </span>
                                            </div>
                                        </div>
                                    </div>
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
                                    <asp:Button ID="buttoninfo" runat="server" OnClientClick="return agreement();" class="btn-img btn-regist2"
                                        value="同意以上协议" Text="注册" onclick="buttoninfo_Click" />
                                </div>
                                <div class="logininfo" style="display: none">
                                    <img src="/main/themes/skin_default/Images/LoginBtn.png" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
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

                    }
                    if (index == "1") {

                        $("#<%=TextBoxMemLoginID.ClientID%>").val("");
                    }
                    if (index == "2") {

                        $("#<%=TextBoxMemLoginID.ClientID%>").val("");
                    }

                    reloadcode();
                }
            });
        }
    });
</script>
