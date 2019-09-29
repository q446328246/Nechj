<%@ Control Language="C#" %>
<script src="Themes/Skin_Default/Js/TelRegiste.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var TimeId;
    $(function () {
        $("#butGetCode").click(function () {
            $phone = $("#TelRegister_ctl00_TextBoxMemLoginID").val();
            if (existmemname()) {
                $("#txtcode").removeAttr("disabled");
                $.get("/api/CheckMemberLogin.ashx?tel=" + $phone + "&type=insertcode", null, function (data) { });
                TimeId = setInterval("ReduceCheck()", 2000);
                $("#butGetCode").attr("disabled", "disabled");
            }
        });
    });
    var i = 120;
    function ReduceCheck() {
        i--;
        $("#butGetCode").val(i + "秒后可以重新发送");
        if (i == 0) {
            $("#butGetCode").removeAttr("disabled");
            $("#butGetCode").val("免费获取验证码");
            clearInterval(TimeId);
            i = 120;
        }
    }

    function CheckMobileCode() {
        if ($("#txtcode").val().length == 6) {
            $.get("/api/CheckMemberLogin.ashx?tel=" + $("#TelRegister_ctl00_TextBoxMemLoginID").val() + "&key=" + $("#txtcode").val() + "&type=checkexistcode", null, function (data) {
                if (data == "1") {
                    $("#TelRegister_ctl00_ButtonConfirm").removeAttr("disabled");
                    $(".msg-content").show().html("验证码已发送，请查收！");
                    return true;
                }
                else { $(".msg-content").show().html("验证码不对！"); return false; }
            });
        } else { return false; }
    }

    function existmobilecode() {
        if ($("#txtcode").val().length == 6) {
            $.get("/api/CheckMemberLogin.ashx?tel=" + $("#TelRegister_ctl00_TextBoxMemLoginID").val() + "&key=" + $("#txtcode").val() + "&type=checkexistcode", null, function (data) {
                if (data == "1") {
                    return true;
                }
                else { $(".msg-content").show().html("验证码不合法！"); return false; }
            });
        } else { return false; }
    }
</script>
<!--未登录时显示-->
<div class="article_cont" style="border: 1px solid #CCCCCC; width: 1188px;">
    <div id="divregester" runat="server" class="fregist">
        <div class="ftitle">
            <h1>
                注册新用户</h1>
            <%--<%= ShopUrlOperate.RetUrl("Login") %>--%>
            <span>我已经注册，现在就<a href="<%= ShopUrlOperate.RetUrl("Login") %>">登录</a></span>
        </div>
        <div class="fcon">
            <div class="form fl">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr class="item">
                        <td class="label">
                            手机号码：
                        </td>
                        <td align="left" style="width: 220px;">
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="text" MaxLength="12"
                                Style="" onfocus='Showtips("spanName","请输入正确的手机号码，长度为11位.")' onblur="existmemname()"
                                autocomplete="off"></asp:TextBox>
                        </td>
                        <td align="left">
                            <span class="null" id="spanName">请输入手机号码 </span>
                        </td>
                    </tr>
                    <%-- <tr class="item">
                        <td class="label">
                            电子邮箱：
                        </td>
                        <td align="left" style="width: 220px;">
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="text" MaxLength="100" Style=""
                                onblur="existemail()" onfocus='Showtips("spanEmail","请填写您常用的邮箱地址，以便找回密码等服务")'></asp:TextBox>
                        </td>
                        <td align="left">
                            <span id="spanEmail" class="null">请输入电子邮箱</span>
                        </td>
                    </tr>--%>
                    <tr class="item">
                        <td class="label">
                            密码：
                        </td>
                        <td align="left" style="width: 220px;">
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="text" MaxLength="15" TextMode="Password"
                                onblur="existepwd()" onfocus='Showtips("spanPwd","6-15个英文字母或数字，字母区分大小写")'></asp:TextBox>
                        </td>
                        <td align="left">
                            <span id="spanPwd" class="null">请输入密码</span>
                        </td>
                    </tr>
                    <tr class="item">
                        <td class="label">
                            确认密码：
                        </td>
                        <td align="left" style="width: 220px;">
                            <asp:TextBox ID="TextBoxRePwd" Enabled="false" CssClass="text" runat="server" MaxLength="15"
                                TextMode="Password" onblur="existesurepwd()" onfocus='Showtips("spanSurePwd","再次输入密码")'></asp:TextBox>
                        </td>
                        <td align="left">
                            <span id="spanSurePwd" class="null">请再次输入密码</span>
                        </td>
                    </tr>
                    <tr class="item" id="VerifyCode" runat="server">
                        <td class="label">
                            验证码：
                        </td>
                        <td align="left" style="width: 220px;">
                            <input type="text" id="txtcode" onblur="return CheckMobileCode()" class="text textcode"
                                disabled="disabled" onfocus='Showtips("spanCode","请输入验证码")' width="60" />
                            <input type="button" id="butGetCode" disabled="disabled" class="btn_graylong" value="免费获取验证码" /><br />
                            <span class="msg-content" style="display: none">验证码已发送，请查收！</span>
                        </td>
                        <td>
                            <span id="spanCode" class="null">请输入验证码</span>
                        </td>
                    </tr>
                    <tr class="item">
                        <td>
                            <p align="center">
                                &nbsp;</p>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxIfAgree" Checked="true" runat="server" Text="" /><a href='<%= ShopUrlOperate.RetUrl("MemberRegProtocol") %>'
                                target="_blank" style="color: #666;">我已看过并接受《用户协议》</a>
                            <br />
                            <span id="spanIfAgree" style="color: Red;" visible="false"></span>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                        </td>
                        <td>
                            <div class="login">
                                <asp:Button ID="ButtonConfirm" Enabled="false" OnClientClick="return existmobilecode();"
                                    runat="server" class="btn-img btn-regist2" value="同意以上协议，提交" /></div>
                            <div class="logininfo" style="display: none">
                                <img src="../../../../Images/greepgdengl.png" /></div>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="threelogin">
                <div class="yilogin">
                    已经注册过的用户？</div>
                <div class="newlogin">
                    <asp:Button ID="Button1" runat="server" Text="现在登录" CssClass="xzdl" PostBackUrl="../../../Login.aspx" />
                </div>
                <div class="otherlogin">
                    <p>
                        您可也以通过以下方式登录:</p>
                    <ShopNum1:SecondLogin ID="SecondLoginRegistr" runat="server" SkinFilename="SecondLoginRegistr.ascx" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</div>
<!--登录后显示-->
<div class="article_cont" style="width: 1190px; margin-top: -2px;">
    <div id="divAgainregester" runat="server" class="regester" style="background: #f3f3f3;
        padding: 5px; border: 0;">
        <div style="border: 1px solid #dfdfdf; background: #ffffff;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
                height: 80px;">
                <tr style="height: 50px; line-height: 50px;">
                    <td class="lmf_padd">
                        <div class="lmf_gth">
                            <span>您好！您已经成功登陆！</span>
                        </div>
                        <div class="member_text">
                            您登陆本商城的手机号码为：<span style="font-weight: bold; color: #ff6600;">
                                <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，您随时可以使用此用户名享受便宜又放心的购物乐趣。
                        </div>
                        <div class="lmf_member" style="margin-left: 80px;">
                            <a href='<%=ShopUrlOperate.RetUrl("index") %>'>进入会员中心</a></div>
                        <div class="lmf_member">
                            <a href='<%=ShopUrlOperate.RetUrl("default") %>'>立刻去购物</a></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<input id="HiddenExistMemLoginID" type="hidden" value="false" />
<input id="HiddenExistEmail" type="hidden" value="false" />
<input id="HiddenExistPwd" type="hidden" value="false" />
<input id="HiddenExistSurePwd" type="hidden" value="false" />
<input id="HiddenExistPublishMemlogid" type="hidden" value="false" />
