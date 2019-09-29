<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    function OnButtonSumit() {

        var pwd = document.getElementById("TextBoxPwd").value;
        var pwd2 = document.getElementById("TextBoxPwd2").value;
        var err = 0;
        document.getElementById("spanPwd").innerHTML = "";
        document.getElementById("spanPwd2").innerHTML = "";

        if (pwd == "") {
            document.getElementById("spanPwd").innerHTML = "请输入密码";
            err = 1;
        }
        if (pwd2 == "") {
            document.getElementById("spanPwd2").innerHTML = "请输入确认密码";
            err = 1;
        }
        if (err == 1) {
            return false;
        }

        if (pwd.length < 6 || pwd.length > 15) {
            document.getElementById("spanPwd").innerHTML = "密码长度为6~15";
            err = 1;
        }

        if (pwd != pwd2) {
            document.getElementById("spanPwd2").innerHTML = "密码输入不一致";
            err = 1;
        }
        if (err == 1) {
            return false;
        }

        _EmailPostBack('ButtonFindPwdSubmit', '');

    }
</script>
<script type="text/javascript">
//<![CDATA[
    var theForm = document.forms[0];
    if (!theForm) {
        theForm = document.form1;
    }

    function _EmailPostBack(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.__EmailEVENTTARGET.value = eventTarget;
            //  theForm.secondEVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
//]]>


</script>
<input type="hidden" name="__EmailEVENTTARGET" id="__EmailEVENTTARGET" value="" />
<!--邮箱找回-->
<asp:Panel ID="PanelOK" runat="server">
    <table id="TableEmail" runat="server" width="600" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <div align="right">
                    重设密码
                </div>
            </td>
            <td>
                <input type="password" id="TextBoxPwd" name="TextBoxPwd" style="width: 170px; border: #C42327 1px solid;" />
                <span class="red2" id="spanPwd">*</span>
            </td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    重设密码确认
                </div>
            </td>
            <td>
                <input type="password" id="TextBoxPwd2" name="TextBoxPwd2" style="width: 170px; border: #C42327 1px solid;" />
                <span class="red2" id="spanPwd2">*</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <input type="button" value="确定" onclick="OnButtonSumit()" class="submit submit_fire" />
                <input id="inputReset" class="submit submit_fire" runat="server" type="reset" value="重置" />
                <input type="hidden" id="HiddenExistEmail" value="false" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PanelNO" runat="server" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
        height: 180px; text-align: center">
        <tr style="height: 76px; line-height: 70px;">
            <td style="text-align: right; width: 30%">
                <img src="Themes/Skin_Default/Images/cancel.gif" />
            </td>
            <td style="color: Red; font-size: 26px; font-weight: bold; text-align: left; width: 70%">
                很遗憾！该链接已经失效.
            </td>
        </tr>
    </table>
</asp:Panel>
