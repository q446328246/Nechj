<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!-- ajax 验证 邮箱 手机 是否存在 -->
<script type="text/javascript">
    //鼠标进入文本框 
    function trun() {
        $("#<%=TextBoxUser.ClientID %>").attr("class", "findinput1");
        var inputcontrol = $("#<%=TextBoxUser.ClientID %>").val();
        if (inputcontrol == "已验证手机/邮箱") {
            //字体变样式
            $("#<%=TextBoxUser.ClientID %>").val("");
        }
    }
    function trun2() {
        $("#<%=TextBoxUserNmae.ClientID %>").attr("class", "findinput1");
        var inputcontrol = $("#<%=TextBoxUserNmae.ClientID %>").val();
        if (inputcontrol == "用户编号") {
            //字体变样式
            $("#<%=TextBoxUserNmae.ClientID %>").val("");
        }

    }
    function CheckIsUserName() {
        var inputcontrol = $("#<%=TextBoxUserNmae.ClientID %>").val();
        var context = document.getElementById("spanUser3");
        if (inputcontrol == "") {
            $("#<%=TextBoxUserNmae.ClientID %>").val("用户编号");
            context.className = "onError1";

            context.innerHTML = "用户编号不能为空";

             $("#<%=TextBoxUserNmae.ClientID %>").attr("class", "findinput");
         }
         else {
             context.className = "onCorrect1";
             context.innerHTML = "";
         }
    }
    
    //移出文本 
    function CheckIsEmalOrMobile() {
        var inputcontrol = $("#<%=TextBoxUser.ClientID %>").val();
        var context = document.getElementById("spanUser");
        if (inputcontrol == "") {
            $("#<%=TextBoxUser.ClientID %>").val("已验证手机/邮箱");
            context.className = "onError1";
            $("#spanUser").attr("state", "0");
            context.innerHTML = "不能为空";
            $("#<%=TextBoxUser.ClientID %>").attr("class", "findinput");
        }
        else {
            $("#<%=TextBoxUser.ClientID %>").attr("class", "findinput1");
            //邮箱验证
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            if (reg.test(inputcontrol)) {
                //是邮箱
                $("#<%=sign.ClientID %>").val("1");
                boolresult = existemail();
            }
            var regModel = /^(1[3|5|7|8|9][0-9])\d{8}$/;
            if (regModel.test(inputcontrol)) {
                //是手机
                $("#<%=sign.ClientID %>").val("2");
                boolresult = existMobile();
            }
            //不是邮箱 手机
            if (reg.test(inputcontrol) == false && regModel.test(inputcontrol) == false) {
                context.className = "onError1";
                $("#spanUser").attr("state", "0");
                context.innerHTML = "格式不正确";
            }
        }

    }
    //从第一步到第二步
    function Button1Click() {
        reloadcode2();
        var inputcontrol = $("#<%=TextBoxUser.ClientID %>").val();
        var context = document.getElementById("spanUser");
        var username = $("#<%=TextBoxUserNmae.ClientID %>").val();
        if (inputcontrol == "" || inputcontrol == "已验证手机/邮箱") {
            $("#<%=TextBoxUser.ClientID %>").val("已验证手机/邮箱");
            context.className = "onError1";
            $("#spanUser").attr("state", "0");
            context.innerHTML = "邮箱/手机不能为空";
        }

        var context = $("#spanUser").attr("state");
        var contextCode = $("#spanCode").attr("state");
        var email = $("#<%=TextBoxUser.ClientID %>").val().toLowerCase();

        if (context == "0" || contextCode == "0") {
            return false;
        }
        else {
            $("#Button1").attr("disabled", "disabled");
            var sign = $("#<%=sign.ClientID %>").val();
            if (sign == "1") {
                //发送邮箱
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: "type=sendemailv&Email=" + email  + "&User=" + username,
                    success: function (result) {
                        if (result != null) {
                            if (result == "true") {
                                //验证通过 进入第2步骤                                    
                                $("#findpwd1").hide();
                                $("#findpwd2Email").show();
                                $("#trEmailCencel").hide();
                            }
                            if (result == "false") {
                                $("#findpwd1").hide();
                                $("#findpwd2Email").show();
                                $("#trEmailCencel").show();
                                $("#trEmailEnter").hide();
                                return;
                            }
                        } else {

                        }
                    }
                });
            }

            if (sign == "2")//2手机
            {
                //验证通过 进入第2步骤
                $("#findpwd1").hide();
                $("#findpwd2").show();
                $("#spanUser2").html($("#HiddenFieldMemID").val());
                $("#spanMobile2").html(email);
            }
        }
    }

    //更新验证码
    function reloadcode() {
        var verify = document.getElementById('Img2');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    function reloadcode2() {
        var verify = document.getElementById('ImgX');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    //验证emall是否存在
    function existemail() {
        var inputcontrol = $("#<%=TextBoxUser.ClientID %>").val();
        var username = $("#<%=TextBoxUserNmae.ClientID %>").val();
        var context = document.getElementById("spanUser");
        context.innerHTML = "数据查询中..";
        $.ajax({
            url: "/api/CheckMemberLogin.ashx",
            type: "GET",
            data: "type=emailisexistfindv&Email=" + inputcontrol + "&User=" + username, //type=mobileisexistfind&Mobile=
            success: function(result) {
                if (result != null) {
                    var arr = new Array();
                    arr = result.split(',');
                    $("#HiddenFieldMemID").val(arr[1]);
                    if (arr[0] == "true") {
                        context.innerHTML = "";
                        context.className = "onCorrect1";
                        $("#spanUser").attr("state", "1");
                    }
                    if (result == "false") {
                        context.innerHTML = "邮箱不存在";
                        context.className = "onError1";
                        $("#spanUser").attr("state", "0");
                    }
                } else {
                    $("#spanUser").attr("state", "0");
                }
            }
        });
    }

    //验证Mobile是否存在
    function existMobile() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxUser.ClientID %>").val();
        var username = $("#<%=TextBoxUserNmae.ClientID %>").val();
        var context = document.getElementById("spanUser");
        context.innerHTML = "数据查询中..";
        $.ajax({
            url: "/api/CheckMemberLogin.ashx",
            data: "type=mobileisexistfindv&Mobile=" + inputcontrol + "" + "&User=" + username,
            success: function(result) {
                if (result != null) {
                    if (result != "false") {
                        var arr = new Array();
                        arr = result.split(',');
                        //context.innerHTML = "手机号存在";
                        context.innerHTML = "";
                        context.className = "onCorrect1";
                        $("#spanUser").attr("state", "2");
                        $("#spanUser2").text(arr[1]);
                        $("#<%=HiddenFieldMemID.ClientID %>").val(arr[1]);
                    } else {
                        context.innerHTML = "手机号不存在";
                        context.className = "onError1";
                        $("#spanUser").attr("state", "0");
                    }
                } else {
                    $("#spanUser").attr("state", "0");
                }
            }
        });
    }
    //验证码
    function existcodex() {
        var boolresult = false;
        var inputcontrol = $("#CodeShow").val();
        var context = document.getElementById("spanSendYZM");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                success: function(result) {
                    if (result == "true") {
                        context.innerHTML = "";
                        context.className = "onCorrect1";
                        $("#spanSendYZM").attr("state", "1");
                        boolresult = true;
                    } else {
                        boolresult = false;
                        context.innerHTML = "验证码错误";
                        context.className = "onError1";
                        $("#spanSendYZM").attr("state", "0");
                    }
                }
            });
        }
        return boolresult;
    }

    //验证码
    function existcode() {
        var boolresult = true;
        var inputcontrol = $("#<%=TextBoxCode.ClientID %>").val();
        var context = document.getElementById("spanCode");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                success: function(result) {
                    if (result == "true") {
                        context.innerHTML = "";
                        context.className = "onCorrect1";
                        $("#spanCode").attr("state", "1");
                        boolresult = true;
                    } else {
                        boolresult = false;
                        context.innerHTML = "验证码错误";
                        context.className = "onError1";
                        $("#spanCode").attr("state", "0");
                    }
                }
            });
        }
        else {
            context.innerHTML = "验证码不能为空";
            $("#spanUser").attr("state", "0");
            context.className = "onError1";
            boolresult = false;
        }
        return boolresult;
    }

    //第三步 重写密码
    $(function() {
        var type = $("#<%=HiddenFieldType.ClientID %>").val();
        if (type == "0" || type == "1") {
            $("#findpwd1").hide();
            $("#findpwd3").show();
        }
        if (type == "4") {
            $("#findpwd1").hide();
            $("#findpwd4").show();
        }
        //获取手机验证码
        $("#butGetCode").click(function () {
            var username = $("#<%=TextBoxUserNmae.ClientID %>").val();
            var mobileCode = $("#CodeShow").val();
            var yzCode = document.getElementById("spanSendYZM");
            if (mobileCode == "") {
                yzCode.innerHTML = "验证码不存在!";
                return false;
            }
            if ($("#spanSendYZM").attr("state") == "0") {
                yzCode.innerHTML = "验证码不正确!";
                return false;
            }
            $("#PasswordReminderUrl_ctl00_TextBox3").removeAttr("disabled");
            var inputcontrol = $("#spanMobile2").html();
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=sendemobilev&Mobile=" + inputcontrol + "" + "&User=" + username,
                success: function(result) {
                    $("#spanSendYZM").get(0).className = "onCorrect1";
                    $("#spanSendYZM").text("验证码已发送，请查收！");
                }
            });
            $("#butGetCode").attr("disabled", "disabled");
            TimeId = setInterval("ReduceCheck()", 1000);
        });

        $("#<%= TextBoxPwd.ClientID %>").focus(function() {
            var content = $("#spanPwd").get(0);
            content.innerHTML = "请输入6~15位登录密码";
            content.className = "onTips1";
        });
        $("#<%= TextBoxPwd2.ClientID %>").focus(function() {
            var content = $("#spanSurePwd").get(0);
            content.innerHTML = "请输入6~15位登录密码";
            content.className = "onTips1";
        });
    });

    // 第二步 手机找回密码
    var i = 60;
    function ReduceCheck() {
        i--;
        $("#butGetCode").val(i + "秒后可以重新发送");
        if (i == 0) {
            $("#butGetCode").removeAttr("disabled");
            $("#butGetCode").val("免费获取验证码");
            clearInterval(TimeId);
            i = 60;
        }
    }
    //获得验证码 进行验证
    function MemberMobileExec() {
        var inputcontrol = $("#<%=TextBox3.ClientID %>").val();
        if (inputcontrol == "") {
            $("#spanYZM").get(0).className = "onError1";
            $("#spanYZM").text("请输入短信验证码！");
            boolresult = false;
        }
        else {
            $.ajax
            ({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=membermobileexec&MobileCode=" + inputcontrol + "&tel=" + $("#spanMobile2").text() + "",
                success: function (result) {
                    if (result == "1") {
                        $("#<%=HiddenFieldType.ClientID %>").val("5");
                        $("#findpwd2").hide();
                        $("#findpwd3").show();
                        $("#<%= HdFieldMobile.ClientID %>").val($("#spanMobile2").text());

                        boolresult = true;
                    }
                    else {
                        $("#spanYZM").get(0).className = "onError1";
                        $("#spanYZM").text("验证码错误或已过期，请重新输入！");
                        boolresult = false;
                    }
                }
            })
        }
    }

    //验证密码
    function existepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%= TextBoxPwd.ClientID %>").val();
        var context = document.getElementById("spanPwd");
        if (inputcontrol != "") {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                context.innerHTML = "";
                context.className = "onCorrect1";
                boolresult = true;
            }
            else {
                context.innerHTML = "密码格式不正确";
                context.className = "onError1";
                boolresult = false;
            }
        }
        else {
            context.innerHTML = "密码不能为空";
            context.className = "onError1";
            boolresult = false;
        }
        return boolresult;
    }

    //验证确认密码
    function existesurepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%= TextBoxPwd2.ClientID %>").val();
        var context = document.getElementById("spanSurePwd");
        var pwd = $("#<%= TextBoxPwd.ClientID %>").val();
        if (inputcontrol != "") {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                context.innerHTML = "";
                context.className = "onCorrect1";
                boolresult = true;
            }
            else {
                context.innerHTML = "确认密码格式不正确";
                context.className = "onError1";
                boolresult = false;
                return boolresult;
            }
        }
        else {
            context.innerHTML = "密码不能为空";
            context.className = "onError1";
            boolresult = false;
            return boolresult;
        }

        if (inputcontrol != pwd) {
            context.innerHTML = "两次密码不一致";
            context.className = "onError1";
            boolresult = false;
        }
        return boolresult;
    }

    //提交验证
    function OnButtonSumit() {
        if (existepwd() && existesurepwd()) {
            return true;
        }
        return false;
    }

</script>
<script type="text/javascript">
   
</script>
<!-- 第一步 填写账户名 -->
<div class="findpwd" id="findpwd1">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd1.jpg" width="866" height="30" /></p>
        <div class="findtable">
            <table border="0" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td align="right">
                        用户编号：
                    </td>
                    <td align="left" class="midtd">
                        <asp:TextBox ID="TextBoxUserNmae" runat="server" Text="用户编号" CssClass="findinput" onblur="CheckIsUserName()" onfocus='trun2()'></asp:TextBox>
                    </td>
                    <td align="left" class="lasttd">
                        <span id="spanUser3" state="0" class="red2" style="display: block;"></span>
                    </td>
                    </tr>
                <tr>
               
                    <td align="right">
                        邮箱/手机：
                    </td>
                    <td align="left" class="midtd">
                        <asp:TextBox ID="TextBoxUser" runat="server" Text="已验证手机/邮箱" CssClass="findinput"
                            onfocus='trun()' onblur="CheckIsEmalOrMobile()"></asp:TextBox>
                    </td>
                    <td align="left" class="lasttd">
                        <span id="spanUser" state="0" class="red2" style="display: block;"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        验证码：
                    </td>
                    <td align="left" class="midtd">
                        <asp:TextBox ID="TextBoxCode" runat="server" MaxLength="6" onblur="existcode()" CssClass="findyanzhen"></asp:TextBox>
                        <img src="/imagecode.aspx?javascript:Math.random()" id="Img2" border="0" onclick="reloadcode()"
                            alt="看不清?点一下" />
                        <a onclick="reloadcode()">看不清楚？</a>
                    </td>
                    <td align="left" class="lasttd">
                        <span id="spanCode" class="red2" style="display: block;"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left" colspan="2">
                        <input id="Button1" type="button" value="下一步" class="finbtn" onclick="Button1Click();" />(相同手机号一天获取验证码最大数量(3-5条)
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd" id="findpwd2" style="display: none">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd2.jpg" width="866" height="30" /></p>
        <div class="findtable">
            <table border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td align="right">
                        用户编号：
                    </td>
                    <td align="left">
                        <span class="trspan" id="spanUser2"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        已验证手机：
                    </td>
                    <td align="left">
                        <span class="trspan" id="spanMobile2"></span>
                        <input type="text" id="CodeShow" class="findyanzhen" onblur="existcodex()" />
                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                            alt="看不清?点一下" />
                        <a onclick="reloadcode2()">看不清楚？</a>
                        <input type="button" id="butGetCode" class="btn_graylong" value="免费获取验证码" />
                        <span id="spanSendYZM" state="0"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信验证码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox3" Enabled="false" MaxLength="8" runat="server" CssClass="findyanzhen"></asp:TextBox>(相同手机号一天获取验证码最大数量(3-5条))
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <input id="Button2" type="button" onclick="MemberMobileExec()" class="finbtn" value="下一步" />
                        <span id="spanYZM"></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd" id="findpwd2Email" style="display: none">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd2.jpg" width="866" height="30" /></p>
        <div class="findtable">
            <table border="0" cellpadding="0" cellspacing="0" align="center">
                <tr class="trsrucee" id="trEmailEnter">
                    <td align="right">
                        <img src="Themes/Skin_Default/Images/ban_prompt.gif" />
                    </td>
                    <td align="left">
                        <p class="yellow1">
                            验证邮件已发送，请登录邮箱完成验证！</p>
                    </td>
                </tr>
                <tr id="trEmailCencel" class="trsrucee" style="display: none;">
                    <td align="right">
                        <img src="Themes/Skin_Default/Images/cancel.gif" />
                    </td>
                    <td align="left">
                        <p class="yellow1">
                            <a style="text-decoration: none;" href="javascript:window.location.href = window.location.href;">
                                验证邮件发送失败,请点击重新完成验证！</a>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd" id="findpwd3" style="display: none">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd3.jpg" width="866" height="30" /></p>
        <!--邮箱找回-->
        <asp:Panel ID="PanelOK" runat="server">
            <div class="findtable">
                <table border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td align="right">
                            新密码：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPwd" runat="server" MaxLength="100" CssClass="findinput"
                                TextMode="Password" onblur="existepwd()"></asp:TextBox>
                        </td>
                        <td align="left">
                            <span id="spanPwd"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            确认新密码：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPwd2" runat="server" MaxLength="100" CssClass="findinput"
                                TextMode="Password" onblur="existesurepwd()"></asp:TextBox>
                        </td>
                        <td align="left">
                            <span id="spanSurePwd"></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="ButtonFindPwdSubmit" OnClientClick="return OnButtonSumit()" runat="server"
                                Text="提交" CssClass="finbtn" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelNO" runat="server" Visible="false">
            <table class="failed" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="failed_img" style="">
                        <img src="Themes/Skin_Default/Images/cancel.gif" />
                    </td>
                    <td class="failed_text">
                        很遗憾！该链接已经失效！
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</div>
<div class="findpwd" id="findpwd4" style="display: none">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd4.jpg" width="866" height="30" /></p>
        <div class="findtable">
            <table border="0" cellpadding="0" cellspacing="0" align="center">
                <tr class="trsrucee">
                    <td align="right">
                        <img src="Themes/Skin_Default/Images/ban_prompt.gif" />
                    </td>
                    <td align="left">
                        <p class="green">
                            新密码设置成功！</p>
                        <p class="yellow1">
                            请牢记您新设置的密码。<a href='<%= ShopUrlOperate.RetUrl("Default") %>'>返回首页</a></p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldType" runat="server" Value="-1" />
<!--4 表示修改完成 5表示手机验证成功-->
<asp:HiddenField ID="sign" runat="server" />
<!--邮箱验证还是手机验证 1邮箱 2手机-->
<asp:HiddenField ID="HiddenFieldMemID" runat="server" />
<!--手机验证时存手机号码-->
<asp:HiddenField ID="HdFieldMobile" runat="server" />
