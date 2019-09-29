<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_BindMobile.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_BindMobile" %>
<script type="text/javascript">
    function reloadcode2() {
        var verify = document.getElementById('ImgX');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    //验证码
    function existcode() {
        var boolresult = true;
        var inputcontrol = $("#txtMCode").val();
        var context = document.getElementById("spanShowMsg");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                success: function (result) {
                    if (result == "true") {
                        context.innerHTML = "";
                        //context.className="onCorrect1";
                        $("#spanShowMsg").attr("state", "1");
                        boolresult = true;
                    } else {
                        boolresult = false;
                        context.innerHTML = "验证码错误";
                        //context.className="onError1";
                        $("#spanShowMsg").attr("state", "0");
                    }
                }
            });
        }
        else {
            context.innerHTML = "验证码不能为空";
            $("#spanShowMsg").attr("state", "0");
            //context.className="onError1";
            boolresult = false;
        }
        return boolresult;
    }

    var timerId;
    var $thisid;
    $(function () {
        $("#a1").click(function () {

            if (ExistMobile()) {
                $.get("/Api/CheckInfo.ashx?type=1&mobile=" + $("#J_cellphone").val(), null, function (data) {
                    if (data == "1") {
                        $("#step1").hide();
                        $("#nextmobile").html($("#J_cellphone").val());
                        $("#step2").show();
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".next");
                        $("#li_GetCode").addClass(".first current");
                    }
                    else {
                        $("#span_MobileValue").get(0).className = "onError1";
                        $("#span_MobileValue").text("手机号码已经被使用了");
                    }
                });
            }
        });

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);

        });
        $("#J_ver_btn").click(function () {
            if ($("#spanShowMsg").attr("state") == "0") {
                $("#spanShowMsg").text("验证码错误!"); return false;
            }
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            $("#spanShowMsg").get(0).className = "onCorrect1";
            $("#spanShowMsg").text("手机短信验证码已发送，请耐心等待...");
            $("#J_phone_msg_row").hide();
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=2&mobile=" + $("#nextmobile").text(), null, function (data) {
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("手机短信验证码发送异常，请重新验证");
                }
            });
        });
        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("验证码是6位字符");
            $("#spanConfirm").get(0).className = "";
        })
        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            } else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#nextmobile").text(), null, function (data) {
                    if (data == "1") {
                        $("#spanShowMsg").get(0).className = "";
                        $("#spanShowMsg").text("");
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");

                    } else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("验证码错误或已过期，请重新输入！");
                    }
                });
            }
        });

        $("#a2").click(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#nextmobile").text(), null, function (data) {
                    if (data == "1") {
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".first current");
                        $("#li_GetCode").addClass(".next");
                        $("#li_Succuess").removeClass(".last");
                        $("#li_Succuess").addClass(".first current");
                        $("#span_Mobile").text($("#nextmobile").text());
                        $("#step2").hide(); $("#step3").show();
                        $("#<%= hid_Mobile.ClientID %>").val($("#nextmobile").text());

                    }
                    else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("验证码错误或已过期，请重新输入！");
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
            clearInterval(timerId);
            i = 60;
            $thisid.removeAttr("disabled");
        }
    }

    function BtnSubmit() {
        if ($("#<%= hid_Mobile.ClientID %>").val() == "")
            return false;
        else
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
                    <span class="f14 bw rw notify_correct_text">完成绑定手机，可以有效防止账户被盗后的损失。 </span>
                    <ul>
                        <li>手机号码绑定后可以登录商城登陆，交易密码修改等操作。</li>
                        <li>商城会对您的信息严格保密。</li>
                    </ul>
                </div>
            </div>
            <div class="pp_steps three_steps">
                <ol>
                    <li class="first current" id="li_Select"><span>1.输入手机号码</span> </li>
                    <li class="next" id="li_GetCode"><span>2.填写短信验证码</span> </li>
                    <li class="last" id="li_Succuess"><span>3.绑定成功</span> </li>
                </ol>
            </div>
            <div class="form_top" id="step1">
                <div class="form_row" id="divProMobile" runat="server">
                    <span class="form_left">已验证手机： </span>
                    <div class="form_right" style="position: relative;">
                        <span class="star" id="spanMobileValue"></span>
                    </div>
                </div>
                <div class="form_row">
                    <span class="form_left">请输入手机号码： </span>
                    <div class="form_right" style="position: relative;">
                        <span id="J_m_77cbc1f75a" style="display: none; position: absolute; left: 0px; top: -42px;"
                            class="mf"></span>
                        <input type="text" name="mobile" maxlength="11" id="J_cellphone" class="intext nullv tov"
                            onblur="CheckMobile()">
                        <span id="span_MobileValue" class="star"></span><i class="safe_center_saftey_icon">
                        </i>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <a href="javascript:void(0)" id="a1" class="btn btn-green J_ftrack">确认绑定</a>(相同手机号一天获取验证码最大数量(3-5条))
                    </div>
                </div>
            </div>
            <div class="form_top" style="display: none" id="step2">
                <div class="form_row">
                    <span class="form_left">绑定手机号码： </span><span class="form_right f14" id="nextmobile">
                    </span>
                </div>
                <input type="hidden" value="13545281376" name="mobile" class="tov">
                <div class="form_row">
                    <span class="form_left">验证码： </span>
                    <div class="form_right">
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" id="txtMCode" style="border: 1px solid #CCCCCC; height: 20px;
                                            width: 80px;" onblur="existcode()" />
                                    </td>
                                    <td style="padding-left: 7px;">
                                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                                            alt="看不清?点一下" />
                                    </td>
                                    <td style="padding-left: 8px;">
                                        <a onclick="reloadcode2()">看不清楚？</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-top: 10px;">
                            <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                                style="width: 150px;" />
                            <input type="text" id="M_code" name="code" data-tip="验证码" disabled="disabled" maxlength="6"
                                class="intext intext_short nullv tov vfb" runat="server">
                            <div>
                                <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到短信验证码？
                                </a><span id="spanConfirm"></span>
                                <div style="display: none;" class="tooltip cp_tooltip">
                                    短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                                </div>
                            </div>
                            <span class="vc vf" id="yzMsg" style="display: none">请输入验证码 </span>
                        </div>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
                        <%-- 验证码是6位数字--%>
                        <span id="spanShowMsg"></span></span>
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
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right" style="text-align: right;">
                        <a data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli" href="javascript:void(0)"
                            id="a2" class="J_ftrack btn btn-green">确认绑定 </a><span id="spanShowMsg" state="0"
                                style="color: Red; padding-left: 10px;"></span>(相同手机号一天获取验证码最大数量(3-5条))
                    </div>
                </div>
            </div>
            <div id="step3" style="display: none">
                <center>
                    <font style="font-size: 16px; font-family: 微软雅黑; display: block; margin-bottom: 20px;
                        margin-top: 10px;">
                        <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label> 恭喜你，手机号码 <span
                            id="span_Mobile"></span>绑定成功 </font>
                    <br />
                    <asp:Button ID="btn_Next" runat="server" Text="确定" data-tid="bindphone_uid_button068"
                        data-tprefix="/virtual/ucenter/myfanli" class="J_ftrack btn btn-green" OnClientClick="return BtnSubmit()" onclick="btn_Next_Click"/>
                    <input type="hidden" name="mobile" class="tov" runat="server" id="hid_Mobile"  />
                </center>
            </div>
            <div class="form_top">
                <div class="form_row form_height_auto_row clearfix">
                    <div class="bp_faq">
                        <h4 class="bw f16">
                            服务说明：
                        </h4>
                        <ul>
                            <li class="bw bp_q">该服务完全免费； </li>
                            <li>你绑定的手机号码，可进行登陆商城系统，修改交易密码等操作，我们会对你的信息进行严格的保密。 </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {

        if (window.location.search.indexOf('type=1') > 0) {
            $("#J_cellphone").val($("#<%= hid_Mobile.ClientID %>").val());
        }

        if ($("#<%= hid_Mobile.ClientID %>").val() != "") {
            $("#spanMobileValue").text($("#<%= hid_Mobile.ClientID %>").val());
            $("#<%= hid_Mobile.ClientID %>").val("");
        }
    });

    function ExistMobile() {
        var v_flag = false;
        var str = $("#J_cellphone").val();
        if (str != "") {
            if (CheckMobileCommon(str)) {
                v_flag = true;
            }
            else {
                $("#span_MobileValue").get(0).className = "onError1";
                $("#span_MobileValue").text("请输入有效的手机号码");
            }
        }
        else {
            $("#span_MobileValue").get(0).className = "onError1";
            $("#span_MobileValue").text("请输入手机号码");
        }
        return v_flag;
    }

    function CheckMobile() {
        if (ExistMobile()) {

            $.ajax({
                url: "/api/CheckInfo.ashx",
                data: "type=1&mobile=" + $("#J_cellphone").val(),
                success: function (data) {
                    if (data == "1") {
                        $("#span_MobileValue").get(0).className = "onCorrect1";
                        $("#span_MobileValue").text("");
                    }
                    else {
                      $("#span_MobileValue").get(0).className = "onError1";
                        $("#span_MobileValue").text("手机号码已经被使用了");
                    }
                }
            });

                        $.get("/Api/CheckInfo.ashx?type=1&mobile=" + $("#J_cellphone").val(), null, function (data) {
                            if (data == "1") {
                                $("#span_MobileValue").get(0).className = "onCorrect1";
                                $("#span_MobileValue").text("");
                            }
                            else {
                                $("#span_MobileValue").get(0).className = "onError1";
                                $("#span_MobileValue").text("手机号码已经被使用了");
                            }
                        });
        }
    }
  
</script>
