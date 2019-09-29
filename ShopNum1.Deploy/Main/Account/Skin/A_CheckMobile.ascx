<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_CheckMobile.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_CheckMobile" %>
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

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });
        $("#J_ver_btn").click(function () {
            if ($("#txtMCode").val() == "") {
                $("#spanShowMsg").text("验证码不能为空！"); return false;
            }
            if ($("#spanShowMsg").attr("state") == "0") {
                $("#spanShowMsg").text("验证码不正确！"); return false;
            }
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            // $("#spanShowMsg").get(0).className="onCorrect1";
            $("#spanShowMsg").text("短信已发送，请耐心等待...");
            $("#spanShowMsg").attr("style", "color:green; padding-left:10px;");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=2&Mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
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
            $("#spanConfirm").get(0).className = "";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
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
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right">
        <div class="ps_width clearfix">
            <div class="zhszmian1">
                <ul class="mimbz">
                    <li class="bzone" id="li_send">1.发送验证码 </li>
                    <li class="bztwo" id="li_get">2.输入新的交易密码</li>
                    <li class="bzthree" id="li_succuess">3.交易密码设置成功 </li>
                </ul>
            </div>
            <div style="clear: both;">
            </div>
            <div class="form_top" id="step2">
                <div class="form_row">
                    <span class="form_left">绑定手机号码： </span>
                    <asp:Label ID="nextmobile" runat="server" Text="" CssClass="orm_right f14" runat="server">
                
                    </asp:Label>
                </div>
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
                            <input type="text" id="M_code" name="code" data-tip="验证码" maxlength="6" class="intext intext_short nullv tov vfb"
                                autocomplete="off" runat="server" disabled="disabled" />
                            <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到短信验证码？
                            </a><span id="spanConfirm"></span>
                            <div style="display: none;" class="tooltip cp_tooltip">
                                短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                            </div>
                        </div>
                        <span class="vc vf" id="yzMsg" style="display: none">请输入验证码 </span>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
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
                <div class="form_row form_height_auto_row clearfix" style="margin-top: 23px;">
                    <input type="button" class="querbtn" data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli"
                        onclick="checkkey()" value="确定" /><span id="spanShowMsg" state="0" style="color: Red;
                            padding-left: 10px;"></span>(手机号码一天获取验证码最大数量(3-5条))
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    function checkkey() {
        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("请输入验证码");
            return;
        }

        $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpPayPwd.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
            }
        });
    }

    function GoURL() {
        window.location.href = "A_UpPayPwd.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val() + "&type=Email";
    };
    function goNext() {
        setTimeout(GoURL, 1000);
    }

</script>
