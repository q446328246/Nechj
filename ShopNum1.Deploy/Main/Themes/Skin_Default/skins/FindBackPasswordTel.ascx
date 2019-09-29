<%@ Control Language="C#" %>
<script type="text/javascript">
    if (top.location != location) top.location.href = location.href;
    function checkMobile() {

        var reg = /^(1[3|5|7|8][0-9])\d{8}$/;

        var Mobile = document.getElementById("<%=TextBoxMobile.ClientID %>").value;
        var hmoblie = document.getElementById("HiddenExistMobile").value;
        var errc = 0
        if (Mobile == "") {
            document.getElementById("spanMobile").innerHTML = "请输入手机号码";
            errc == 1;
        }
        if (errc == 1) {
            return false;
        }

        if (!reg.test(Mobile)) {
            document.getElementById("spanMobile").innerHTML = "手机号码格式不正确";
            return false;
        }
        else {
            return true;

        }
    }

    function ReceiveServerMobileData(result, context) {
        var hid = document.getElementById("HiddenExistMobile");
        if (result == "0") {
            hid.value = "false";
            context.innerHTML = "×手机不存在";
        }
        else {
            hid.value = "true";
            context.innerHTML = "";
        }
    }
</script>
<table width="600" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <div align="right">
                手机号码：</div>
        </td>
        <td>
            <asp:TextBox ID="TextBoxMobile" runat="server" Width="170" Style="border: #ccc 1px solid;
                height: 20px;" onblur="existmobile(this)"></asp:TextBox>
            <span class="red2" id="spanMobile">*</span>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="ButtonConfirm" OnClientClick="return checkMobile()" runat="server"
                Text="确定" class="submit" ToolTip="Submit" />
            <input id="inputReset" runat="server" type="reset" value="重置" class="submit" />
            <input value="false" type="hidden" id="HiddenExistMobile" />
        </td>
    </tr>
</table>
