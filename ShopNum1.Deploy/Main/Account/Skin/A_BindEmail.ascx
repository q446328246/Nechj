<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_BindEmail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_BindEmail" %>
<script type="text/javascript">
    var timerId;
    var $thisid;
    $(function () {
        $("#a1").click(function () {
            if (ExistEmail()) {
                $.get("/Api/CheckInfo.ashx?type=12&Email=" + $("#J_UserEmail").val(), null, function (data) {
                    var bflag = false;
                   
                        $("#step1").hide();
                        $("#step2").show();
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".next");
                        $("#li_GetCode").addClass(".first current");
                        $("#nextEmail").html($("#J_UserEmail").val());
                    
                    
                });
            }
        });

        $("#J_cannot_receive").click(function () {+
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });

        $("#J_ver_btn").click(function () {
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID  %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            $("#spanYZMIsSend").get(0).className = "onCorrect1";
            $("#spanYZMIsSend").text("邮箱验证码已发送，请耐心等待...");
            $("#J_phone_msg_row").hide();
            timerId = setInterval("goTo()", 1000);
            $thisid = $(this);
            $.get("/Api/CheckInfo.ashx?type=4&Email=" + $("#nextEmail").text(), null, function (data) {
                if (data != "1") {
                    $("#spanYZMIsSend").get(0).className = "onError1";
                    $("#spanYZMIsSend").text("邮件发送出现异常，请重新验证");
                }
            });
        });

        $("#a2").click(function () {

            if ($("#<%= M_code.ClientID  %>").val() == "") {
                $("#spanYZMIsSend").get(0).className = "onError1";
                $("#spanYZMIsSend").text("请输入验证码");
                return false;
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#nextEmail").text(), null, function (data) {
                    if (data == "1") {
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".first current");
                        $("#li_GetCode").addClass(".next");
                        $("#li_Succuess").removeClass(".last");
                        $("#li_Succuess").addClass(".first current");
                        $("#span_email").text($("#nextEmail").text());
                        $("#step2").hide();
                        $("#step3").show();
                        $("#<%=hid_Email.ClientID%>").val($("#nextEmail").text());
                    } else {
                        $("#spanYZMIsSend").get(0).className = "onError1";
                        $("#spanYZMIsSend").text("验证码错误或已过期，请重新输入！");
                        return false;
                    }
                });
            }
        });

        $("#<%= M_code.ClientID  %>").blur(function () {
            if (this.value == "") {
                $("#spanYZMIsSend").get(0).className = "onError1";
                $("#spanYZMIsSend").text("请输入验证码");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#nextEmail").text(), null, function (data) {
                    if (data == "1") {
                        $("#spanYZMIsSend").get(0).className = "";
                        $("#spanYZMIsSend").text("");
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");
                    }
                    else {
                        $("#spanYZMIsSend").get(0).className = "onError1";
                        $("#spanYZMIsSend").text("验证码错误或已过期，请重新输入！");
                    }
                });
            }
        });

        $("#<%= M_code.ClientID  %>").focus(function () {
            $("#spanYZMIsSend").get(0).className = "onTips1";
            $("#spanYZMIsSend").text("验证码是4位字符");
            $("#spanConfirm").get(0).className = "";
        });
    });


    $(function () {
        if (window.location.search.indexOf('type=1') > 0) {
            $("#J_UserEmail").val($("#<%= hid_Email.ClientID %>").val());
        }

        if ($("#<%= hid_Email.ClientID %>").val() != "") {
            $("#spanEmailValue").text($("#<%= hid_Email.ClientID %>").val());
            $("#<%= hid_Email.ClientID %>").val("");
        }
    })

    //判断Email格式
    function ExistEmail() {
        var str = $("#J_UserEmail").val();
        var v_flag = false;
        if (str != "") {
            if (CheckEmailCommon(str)) {
                v_flag = true;
            }
            else {
                $("#span_emailValue").get(0).className = "onError1";
                $("#span_emailValue").text("邮箱格式不正确");
            }
        }
        else {
            $("#span_emailValue").get(0).className = "onError1";
            $("#span_emailValue").text("请输入邮箱");
        }
        return v_flag;
    }


    function checkEmailValue() {
        if (ExistEmail()) {
            $.get("/Api/CheckInfo.ashx?type=12&Email=" + $("#J_UserEmail").val(), null, function (data) {
                var bflag = false;
               
                    $("#span_emailValue").get(0).className = "onCorrect1";
                    $("#span_emailValue").text("");
               
            });
        }
    }

    var i = 60;
    function goTo() {
        i--;
        $thisid.val("已发送验证码(" + i + "秒)");
        if (i == 0) {
            $thisid.val("免费获取验证码");
            clearInterval(timerId);
            $("#J_ver_btn").removeAttr("disabled");
            i = 60;
        }
    }

    function BtnSubmit() {
        if ($("#<%= hid_Email.ClientID %>").val() == "") {
            return false;
        }
        return true;
    }
 
 
</script>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right" style="float: none;">
        <div class="ps_width clearfix" style="margin-left: 5px;">
            <h1 class="bw h1c">
            </h1>
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span class="f14 bw rw notify_correct_text">完成绑定邮箱，可以有效防止账户被盗后的损失。 </span>
                    <ul>
                        <li>邮箱账号绑定后可以登录商城登陆，交易密码修改等操作。</li>
                        <li>商城会对您的信息严格保密。</li>
                    </ul>
                </div>
            </div>
            <div class="pp_steps three_steps">
                <ol>
                    <li class="first current" id="li_Select"><span>1.输入邮箱</span> </li>
                    <li class="next" id="li_GetCode"><span>2.填写邮箱验证码</span> </li>
                    <li class="last" id="li_Succuess"><span>3.成功</span> </li>
                </ol>
            </div>
            <div class="form_top" id="step1">
                <div class="form_row" id="divProEmail" runat="server">
                    <span class="form_left">已验证邮箱： </span>
                    <div class="form_right" style="position: relative;">
                        <span class="star" id="spanEmailValue"></span>
                    </div>
                </div>
                <div class="form_row">
                    <span class="form_left">请输入邮箱： </span>
                    <div class="form_right" style="position: relative;">
                        <span id="J_m_77cbc1f75a" style="display: none; position: absolute; left: 0px; top: -42px;"
                            class="mf"></span>
                        <input type="text" name="Email" id="J_UserEmail" class="intext nullv tov" autocomplete="off"
                            maxlength="50" onblur="checkEmailValue()">
                        <span class="star" id="span_emailValue">*</span>
                        <%-- <i class="safe_center_saftey_icon"></i>--%>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <a href="javascript:void(0)" id="a1" class="btn btn-green J_ftrack">确认绑定</a>
                    </div>
                </div>
            </div>
            <div class="form_top" style="display: none" id="step2">
                <div class="form_row">
                    <span class="form_left">绑定的邮箱： </span><span class="form_right f14" id="nextEmail">
                    </span>
                </div>
                <input type="hidden" value="" name="mobile" class="tov">
                <div class="form_row">
                    <span class="form_left">验证码： </span>
                    <div class="form_right">
                        <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                            style="width: 150px;" />
                        <input type="text" id="M_code" name="code" data-tip="验证码" disabled="disabled" maxlength="8"
                            class="intext intext_short nullv tov vfb" autocomplete="off" runat="server" />
                        <div>
                            <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到邮箱验证码？
                            </a><span id="spanConfirm"></span>
                            <div style="display: none;" class="tooltip cp_tooltip">
                                邮箱验证码发送后30分钟内均可使用。邮件收不到验证码，可能是你邮箱进行了反垃圾设置，防止陌生邮件的原因，重新设置即可正常接收邮件。
                            </div>
                        </div>
                        <span class="vc vf" id="yzMsg" style="display: none">
                            <%--请输入验证码--%>
                        </span>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
                        <%-- 验证码是8位数字--%>
                        <span id="spanYZMIsSend"></span></span>
                </div>
                <div id="J_phone_msg_row" class="form_row form_height_auto_row nice_info_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <div class="phone_info">
                            <div id="J_phone_info">
                                <span class="l">邮箱验证码发送后30分钟内均可使用 </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <a data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli" href="javascript:void(0)"
                            id="a2" class="J_ftrack btn btn-green">确认绑定 </a><span id="spanShow"></span>
                    </div>
                </div>
            </div>
            <div id="step3" style="display: none;">
                <div style="padding: 20px; text-align: center;">
                    <font style="font-size: 16px; font-family: 微软雅黑; display: block; margin-bottom: 20px;">
                        <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>, 恭喜你,你的邮箱 <span
                            id="span_email"></span>绑定成功 </font>
                    <br />
                    <asp:Button ID="btn_Next" runat="server" Text="确定" data-tid="bindphone_uid_button068"
                        data-tprefix="/virtual/ucenter/myfanli" class="J_ftrack btn btn-green" runat="server"
                        OnClientClick="return BtnSubmit()" OnClick ="btn_Next_Click" />
                    <input type="hidden" name="Email" class="tov" runat="server" id="hid_Email">
                </div>
            </div>
            <div class="form_top">
                <div class="form_row form_height_auto_row clearfix">
                    <div class="bp_faq">
                        <h4 class="bw f16">
                            服务说明：
                        </h4>
                        <ul>
                            <li class="bw bp_q">该服务完全免费； </li>
                            <li>你绑定的邮箱，可进行登陆商城系统，修改交易密码等操作，我们会对你的信息进行严格的保密。 </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
