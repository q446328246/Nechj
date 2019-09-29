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
        })

        $("#NewRepassword").blur(function () {
            if ($(this).val() != $("#Newpassword").val()) {
                $("#spanErrRePwd").text("两次密码不一致！");
                $("#HiddenRePwd").val("0");
            } else {
                $("#spanErrRePwd").html("<img style='width:14px;height:14px;' src='themes/skin_default/images/pwdstrength.gif'\/>");
                $("#HiddenRePwd").val("1");
            }
        })


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

                $("#spanErruserBind_userName").text("用户名不能为空!")
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
                        $("#spanErruserBind_userName").text("该用户不存在!")


                    }
                }
            });


        });

        $("#seconduserBind_password").blur(function () {

            if ($(this).val == "") {
                $("#spanErruserBind_password").text("密码不能为空!")
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
                            $("#spanErrUserName").text("用户名已存在")
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
<div class="bind_title" style="display: none;">
    <asp:Literal ID="LiteralUserName" runat="server"></asp:Literal>
    您好！您已经用<asp:Literal ID="LiteralAccountType" runat="server"></asp:Literal>成功登录Shopnum1商城系统</div>
<div class="bind_detail">
    <div class="content1" id="Divcontent1" runat="server" visible="false">
        <div class="bind_re bind_re1">
            <input type="radio" name="signuped" value="1" autocomplete="off" class="f-radio"
                checked="checked" />已经注册过Shopnum1商城系统（绑定<asp:Literal ID="LiteralAccount" runat="server"></asp:Literal>和Shopnum1商城账户）
        </div>
        <div class="regesiterd regesiterd1">
            <table class="enter-account">
                <tr>
                    <td style="width: 100px;">
                        用户名：
                    </td>
                    <td>
                        <input type="text" id="seconduserBind_userName" name="seconduserBind_userName" class="f-text"
                            value="" />
                        <span style="color: red">*</span> <span id="spanErruserBind_userName" style="color: Red">
                        </span>未注册Shopnum1账号，请点击<asp:LinkButton ID="LinkButton2" runat="server" Text="这里">这里</asp:LinkButton>绑定
                    </td>
                </tr>
                <tr>
                    <td>
                        密码：
                    </td>
                    <td>
                        <input type="password" id="seconduserBind_password" name="seconduserBind_password"
                            class="f-text" />
                        <span style="color: red">*</span> <span id="spanErruserBind_password" style="color: Red">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="commit">
                        <input type="button" value="绑定" class="formbutton" onclick="CheckMemLogin()" />
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
    </div>
    <div class="content2" id="Divcontent2" runat="server">
        <div class="bind_re bind_re2">
            <input type="radio" name="signuped" value="0" autocomplete="off" class="f-radio"
                id="otherRadio" checked="checked" />未注册过的用户由此登录
        </div>
        <div class="regesiterd regesiterd2">
            <table class="enter-account">
                <tr>
                    <td style="width: 100px;">
                        用户名：
                    </td>
                    <td>
                        <input type="text" id="seconduserBind_userName_c" name="seconduserBind_userName_c"
                            class="f-text" value="" onblur="CheckMemLogin1(this)" />
                        <span style="color: red">*</span> <span id="spanErrUserName" style="color: Red">
                        </span><span id="spanContent1" style="color: Red"></span>已经注册Shopnum1账号，请点击<asp:LinkButton
                            ID="LinkButton1" runat="server" Text="这里">这里</asp:LinkButton>绑定
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        邮箱：
                    </td>
                    <td>
                        <input type="text" id="email" name="seconduserBind_email" class="f-text" value=""
                            onblur="existemail(this)" />
                        <span style="color: red">*</span> <span id="spanErrEmail" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        密码：
                    </td>
                    <td>
                        <input type="password" id="Newpassword" name="seconduserBind_Newpassword" class="f-text" />
                        <span style="color: red">*</span> <span style="color: Red" id="spanErrPwd"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        确认密码：
                    </td>
                    <td>
                        <input type="password" id="NewRepassword" name="seconduserBind_NewRepassword" class="f-text" />
                        <span style="color: red">*</span> <span id="spanErrRePwd" style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="commit">
                        <input type="button" value="创建" class="formbutton" onclick="MemberRegist();SecondBind('BtnCreate')" />
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
