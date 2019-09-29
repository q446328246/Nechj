<%@ Control Language="C#" %>
<script type="text/javascript">

    function ReceiveServerEmailData(result, context) {
        var HiddenEmail = document.getElementById("HiddenEmail");
        if (result == "0") {
            HiddenEmail.value = "1";
            context.innerHTML = "";
        }
        else {
            HiddenEmail.value = "0";
            context.innerHTML = "×邮箱已经存在";
        }
    }

    function ReceiveServerData(result, context) {

        if (result == "1") {

            SecondBind("BtnBind");
        }
        else if (result == "-1") {

            context.innerHTML = "您不能绑定该账户，该账户已经被禁用了!";
        }
        else {
            context.innerHTML = "账户或者密码错误!";
        }

    }

    $(function () {
        $("#Newpassword").blur(function () {
            if ($(this).val() == "") {
                $("#spanErrPwd").text("密码不能为空！");
                $("#HiddenPwd").val("0");
            } else {
                if ($(this).val().length < 6) {
                    $("#spanErrPwd").text("密码长度不能小于6！");
                    $("#HiddenPwd").val("0");
                } else {
                    $("#spanErrPwd").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
                    $("#HiddenPwd").val("1");
                }
            }
        });

        $("#NewRepassword").blur(function () {
            if ($(this).val() != $("#Newpassword").val()) {
                $("#spanErrRePwd").text("两次密码不一致！");
                $("#HiddenRePwd").val("0");
            } else {
                $("#spanErrRePwd").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
                $("#HiddenRePwd").val("1");
            }
        });


        $("#email").blur(function () {

            if ($(this).val() == "") {
                $("#spanErrEmail").text("邮箱不能为空！");
                $("#HiddenEmail").val("0");
            } else {
                var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
                var code = $("#email").val();
                if (reg.test(code)) {
                    $.ajax({
                        url: "/api/CheckMemberLogin.ashx",

                        data: "type=emailisexist&Email=" + code + "",

                        success: function (result) {

                            if (result != null) {

                                if (result == "true") {

                                    // regEmailpass=false ;

                                    $("#spanErrEmail").text("邮箱已存在");

                                } else {
                                    // regEmailpass=true ;
                                    $("#spanErrEmail").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");

                                }
                            } else {
                            }
                        }
                    });
                } else {
                    $("#spanErrEmail").text("格式不正确！");

                }
            }
        });
        $("#seconduserBind_userName").blur(function () {
            if ($(this).val() == "") {

                $("#spanErruserBind_userName").text("用户名不能为空!");
                return;
            }
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=userisexist&UserID=" + $(this).val() + "",
                success: function (result) {
                    if (result == "true") {
                        $("#spanErruserBind_userName").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
                        return;
                    } else {
                        $("#spanErruserBind_userName").text("该用户不存在!");
                    }
                }
            });
        });
        $("#seconduserBind_password").blur(function () {
            if ($(this).val == "") {
                $("#spanErruserBind_password").text("密码不能为空!");
            } else {
                $("#spanErruserBind_password").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
            }
        });

        $("#seconduserBind_userName_c").blur(function () {
            var memidpass = true;
            if (memidpass) {
                var memid = $("#seconduserBind_userName_c").val();
                if (memid == "") {
                    $("#spanErrUserName").text("用户名不能为空！");
                    return;
                }
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: "type=userisexist&UserID=" + memid + "",
                    success: function (result) {

                        if (result == "true") {
                            $("#spanErrUserName").text("用户名已存在");
                            return;
                        } else {
                            $("#spanErrUserName").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
                        }
                    }
                });
            }
        });
    });

    //未注册用户创建
    var regMempass = false; //用户名是否通过
    var regEmailpass = false; //邮箱是否通过
    function MemberRegist() {
        if (!regMempass) {
            Userisexist(); //账号验证

        }

        if (!regEmailpass) {
            Emailisexist(); //邮箱验证

        }
        if (regMempass && regEmailpass) {
            return true;
        }
    }

    function Userisexist() {
        var code = $("#seconduserBind_userName_c").val();
        if (code == "") {
            regMempass = false;
            $("#spanErrUserName").text("用户名不能为空！");
        }
        else {
            regMempass = true;

        }
    }

    function Emailisexist() {
        if ($("#email").val() == "") {
            $("#spanErrEmail").text("邮箱不能为空！");
            $("#HiddenEmail").val("0");
        }
        else {
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            var code = $("#email").val();
            if (reg.test(code)) {
                regEmailpass = true;

            }
            else {
                regEmailpass = false;
                $("#spanErrEmail").text("格式不正确！");

            }
        }

    }
   
</script>
<script type="text/javascript">
//<![CDATA[
    var theFormSecond = document.forms[0];
    if (!theFormSecond) {
        theFormSecond = document.form1;
    }
    function SecondBind(eventTarget) {

        if ($("#otherRadio").check == true) {
            if ($("#HiddenEmail").val() == "0") {
                return false;
            }

            if ($("#HiddenPwd").val() == "0") {
                return false;
            }

            if ($("#HiddenRePwd").val() == "0") {
                return false;
            }
        }

        if (!theFormSecond.onsubmit || (theFormSecond.onsubmit() != false)) {
            theFormSecond.secondUserEVENTTARGET.value = eventTarget;
            theFormSecond.submit();
        }
    }
//]]>
</script>
<div class="threedenglu">
    <div class="threetit">
        <asp:Literal ID="LiteralUserName" runat="server"></asp:Literal>您好！您已经用
        <asp:Literal ID="LiteralAccountType" runat="server"></asp:Literal>成功登录本商城
    </div>
    <div class="threecon clearfix">
        <div class="threecheck">
            <p class="checkp">
                <input type="radio" name="signuped" value="1" autocomplete="off" class="f-radio"
                    checked="checked" />已经注册过本商城的用户？ <i>（绑定<asp:Literal ID="LiteralAccount" runat="server"></asp:Literal>本商城账户名）</i>
            </p>
            <table border="0" cellpadding="0" cellspacing="0" class="cheaktable">
                <tr>
                    <td align="right" style="width: 100px;">
                        用户名：
                    </td>
                    <td>
                        <input type="text" id="seconduserBind_userName" name="seconduserBind_userName" class="inputcheck"
                            value="" />
                        <span style="color: red">*</span> <span id="spanErruserBind_userName" style="color: Red">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密码：
                    </td>
                    <td>
                        <input type="password" id="seconduserBind_password" name="seconduserBind_password"
                            class="inputcheck" />
                        <span style="color: red">*</span> <span id="spanErruserBind_password" style="color: Red">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="commit">
                        <input type="button" value="绑定" class="bangdingbtn" onclick="CheckMemLogin()" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <span id="spanContent" style="color: Red;"></span>
                    </td>
                </tr>
            </table>
        </div>
        <div class="threecheck">
            <p class="checkp">
                <input type="radio" name="signuped" value="0" autocomplete="off" class="f-radio"
                    id="otherRadio" checked="checked" />
                还没有注册过的用户？<i>（创建一个账户）</i>
            </p>
            <table border="0" cellpadding="0" cellspacing="0" class="cheaktable">
                <tr>
                    <td align="right" style="width: 100px;">
                        用户名：
                    </td>
                    <td>
                        <input type="text" id="seconduserBind_userName_c" name="seconduserBind_userName_c"
                            class="inputcheck" value="" />
                        <span style="color: red">*</span> <span id="spanErrUserName" style="color: Red">
                        </span><span id="spanContent1" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px;">
                        邮箱：
                    </td>
                    <td>
                        <input type="text" id="email" name="seconduserBind_email" class="inputcheck" value=""
                            onblur="existemail(this)" />
                        <span style="color: red">*</span> <span id="spanErrEmail" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密码：
                    </td>
                    <td>
                        <input type="password" id="Newpassword" name="seconduserBind_Newpassword" class="inputcheck" />
                        <span style="color: red">*</span> <span style="color: Red" id="spanErrPwd"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认密码：
                    </td>
                    <td>
                        <input type="password" id="NewRepassword" name="seconduserBind_NewRepassword" class="inputcheck" />
                        <span style="color: red">*</span> <span id="spanErrRePwd" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="commit">
                        <input type="button" value="创建" class="bangdingbtn" onclick="if( MemberRegist()) {SecondBind('BtnCreate')} else { return false;}" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <span id="span1" style="color: Red;"></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<input type="hidden" name="secondUserEVENTTARGET" id="secondUserEVENTTARGET" value="" />
<input type="hidden" name="reg" id="reg" value="0" />
<input type="hidden" name="email" id="HiddenEmail" value="0" />
<input type="hidden" name="pwd" id="HiddenPwd" value="0" />
<input type="hidden" name="rePwd" id="HiddenRePwd" value="0" />
