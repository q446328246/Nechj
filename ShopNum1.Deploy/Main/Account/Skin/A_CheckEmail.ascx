<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_CheckEmail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_CheckEmail" %>
<script type="text/javascript">
    var timerId;
    var $thisid;
    $(function () {
        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });

        $("#J_ver_btn").click(function () {
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            $("#spanShowMsg").get(0).className = "onCorrect1";
            $("#spanShowMsg").text("邮件已发送，请耐心等待...");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=4&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
                //alert("邮件已发送，请耐心等待......");
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("邮件发送出现异常，请重新验证");
                }
            });
        });

        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("验证码是8位字符");
            $("#spanConfirm").get(0).className = "";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
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
            clearInterval(timerId);
            i = 60;
            $thisid.removeAttr("disabled");
        }
    }
</script>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right">
        <div class="ps_width clearfix">
            <div class="zhszmian1">
                <ul class="mimbz">
                    <li class="bzone" id="li_send">1.发送验证码</li>
                    <li class="bztwo" id="li_get">2.输入新的交易密码</li>
                    <li class="bzthree" id="li_succuess">3.交易密码设置成功 </li>
                </ul>
            </div>
            <div style="clear: both;">
            </div>
            <div class="form_top" id="step2">
                <div class="form_row">
                    <span class="form_left">绑定邮箱账号： </span>
                    <asp:Label ID="nextEmail" runat="server" CssClass="orm_right f14"></asp:Label>
                </div>
                <div class="form_row">
                    <span class="form_left">验证码： </span>
                    <div class="form_right">
                        <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                            style="width: 150px;" />
                        <input type="text" id="M_code" name="code" data-tip="验证码" maxlength="8" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled">
                        <div>
                            <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到邮件验证码？
                            </a><span id="spanConfirm"></span>
                            <div style="display: none;" class="tooltip cp_tooltip">
                                邮箱验证码发送后30分钟内均可使用。邮件收不到验证码，可能是你邮箱进行了反垃圾设置，防止陌生邮件的原因，重新设置即可正常接收邮件。
                            </div>
                        </div>
                        <%--<span class="vc vf" id="yzMsg" style="display:none">
                        请输入验证码
                    </span>--%>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
                        <%--验证码是8位数字--%>
                        <span id="spanShowMsg"></span></span>
                </div>
                <div id="J_phone_msg_row" class="form_row form_height_auto_row nice_info_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right" style="line-height: 20px; height: 40px;">
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
                        <input type="button" class="querbtn" data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli"
                            onclick="checkkey()" value="确定" />
                    </div>
                </div>
            </div>
        </div>
        <div id="step3" style="display: none; line-height: 20px;">
            <center>
                <div style="height: 30px; line-height: 30px; margin-top: 10px;">
                    <font style="font-size: 16px; font-family: 微软雅黑; display: block; margin-bottom: 20px;">
                        <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>, 邮箱成功</font>
                </div>
                <br />
                <input type="btn_Next" style="width: 60px" class="J_ftrack btn btn-green" data-tid="bindphone_uid_button068"
                    data-tprefix="/virtual/ucenter/myfanli" value="下一步" onclick="goNext()" />
            </center>
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

        $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpPayPwd.aspx?Email=" + $("#<%=nextEmail.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
            }
        });
    }
</script>
