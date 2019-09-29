<%@ Control Language="C#" %>
<script type="text/javascript">
    if (top.location != location) top.location.href = location.href;
    function OnButtonSumit() {
        var reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        var Email = document.getElementById("TextBoxEmail").value;
        var hid = document.getElementById("HiddenExistEmail").value;
        var err = 0;
        document.getElementById("spanEmail").innerHTML = "";


        if (Email == "") {
            document.getElementById("spanEmail").innerHTML = "请输入邮箱";
            err = 1;
        }
        if (err == 1) {
            return false;
        }
        if (!reg.test(Email)) {
            document.getElementById("spanEmail").innerHTML = "邮箱格式不正确";
            err = 1;
        }

        if (err == 1) {
            return false;
        }
        if (hid == "false") {
            document.getElementById("spanEmail").innerHTML = "×邮箱不存在";
        }
        else {
            __doPostBack('ButtonFindPwdSubmit', '');
        }

    }

    function ReceiveServerData(result, context) {
        var hid = document.getElementById("HiddenExistEmail");
        if (result == "0") {
            hid.value = "false";
            context.innerHTML = "×邮箱不存在";
        }
        else {
            hid.value = "true";
            context.innerHTML = "";

        }
    }
</script>
<div class="findpwd">
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
                    <td align="left">
                        <asp:TextBox ID="TextBoxUser" runat="server" Text="用户编号/邮箱/已验证手机" CssClass="findinput"></asp:TextBox>
                        <span id="spanUser" class="red2" style="display: block;"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        验证码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="findyanzhen"></asp:TextBox><img
                            src="Themes/Skin_Default/Images/imagecode.gif" /><a href="#">看不清楚？点一下</a>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button1" runat="server" Text="下一步" CssClass="finbtn" />(相同手机号一天获取验证码最大数量(3-5条))
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd">
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
                        <span class="trspan">llmf****0</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        已验证手机：
                    </td>
                    <td align="left">
                        <span class="trspan">150****437</span>
                        <img src="Themes/Skin_Default/Images/findyanz.jpg" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信验证码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="findyanzhen"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button2" runat="server" Text="下一步" CssClass="finbtn" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd">
    <h1>
        找回密码</h1>
    <div class="findcont">
        <p class="findimg">
            <img src="Themes/Skin_Default/Images/findpwd3.jpg" width="866" height="30" /></p>
        <div class="findtable">
            <table border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td align="right">
                        新登录密码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="findinput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认信密码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="findinput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button3" runat="server" Text="提交" CssClass="finbtn" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="findpwd">
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
                            请牢记您新设置的密码。<a href="#">返回首页</a></p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
