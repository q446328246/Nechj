<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_UpPwd.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_UpPwd" %>
<div id="content">
    <div>
        <table id="T_UpPwd" border="0" cellspacing="0" cellpadding="0" class="tabbiao" runat="server">
            <tr>
                <td class="tab_r">
                    旧密码：
                </td>
                <td style="width: 150px;">
                    <input name="name_OldPwd" type="password" class="textwb" id="Input_OldPwd" runat="server"
                        maxlength="15" onblur="existOldPwd()" />
                </td>
                <td>
                    <span id="span_OldPwd"></span>
                </td>
            </tr>
            <tr>
                <td class="tab_r">
                    <span style="color: red;">*</span>新密码：
                </td>
                <td>
                    <input name="name_NowPwd" type="password" class="textwb" id="Input_NewPwd" runat="server"
                        maxlength="15" onblur="existepwd()" />
                </td>
                <td>
                    <span id="span_NewPwd"></span>
                </td>
            </tr>
            <tr>
                <td class="tab_r">
                    <span style="color: red;">*</span>确认新密码：
                </td>
                <td>
                    <input name="name_RNowPwd" type="password" class="textwb" id="Input_NewSecondPwd"
                        runat="server" maxlength="15" onblur="existesurepwd()" />
                </td>
                <td>
                    <span id="span_NewSecondPwd"></span>
                </td>
            </tr>
            <tr>
                <td class="tab_r">
                    &nbsp;
                </td>
                <td style="padding: 10px 0px 10px 0px;">
                    <asp:Button ID="btn_UpPwd" runat="server" Text="修改" CssClass="querbtn" OnClientClick=" return CheckSumbit()" OnClick="btn_UpPwd_Click" />
                    <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" OnClick="btn_Back_Click" />
                    <input id="hid_Count" type="hidden" runat="server" value="5" />
                </td>
            </tr>
        </table>
    </div>
</div>
<script type="text/javascript" language="javascript">

    $(function() {
        $("#<%= Input_NewPwd.ClientID %>").focus(function() {
            var context = document.getElementById("span_NewPwd");
            context.innerHTML = "请输入6~15位登录密码";
            context.className = "onTips1";
        });
        $("#<%= Input_NewSecondPwd.ClientID %>").focus(function() {
            var context = document.getElementById("span_NewSecondPwd");
            context.innerHTML = "请输入6~15位登录密码";
            context.className = "onTips1";
        });
        $("#<%= Input_OldPwd.ClientID %>").focus(function() {
            var context = document.getElementById("span_OldPwd");
            context.innerHTML = "请输入6~15位旧密码";
            context.className = "onTips1";
        });
    });

    function existOldPwd() {
        var context = document.getElementById("span_OldPwd");
        if ($("#<%= Input_OldPwd.ClientID %>").val() == "") {
            context.innerHTML = "请输入旧密码";
            context.className = "onError1";
            return false;
        }
        else {
            context.innerHTML = "";
            context.className = "onCorrect1";
            return true;
        }
    }

    //验证密码
    function existepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%= Input_NewPwd.ClientID %>").val();
        var context = document.getElementById("span_NewPwd");
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
        var inputcontrol = $("#<%= Input_NewSecondPwd.ClientID %>").val();
        var context = document.getElementById("span_NewSecondPwd");
        var pwd = $("#<%= Input_NewPwd.ClientID %>").val();
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

    function CheckSumbit() {
        if (existepwd() & existesurepwd() & existOldPwd()) {
            return true;
        }
        return false;
    }

</script>
