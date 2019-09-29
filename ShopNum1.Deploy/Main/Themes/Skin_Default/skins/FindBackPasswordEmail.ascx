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
<!--邮箱找回-->
<table id="TableEmail" runat="server" style="display: block;" width="600" border="0"
    cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <div align="right">
                邮箱：
            </div>
        </td>
        <td>
            <input type="text" id="TextBoxEmail" name="TextBoxEmail" style="width: 170px; border: #ccc 1px solid;
                height: 20px;" onblur="existemail(this)" />
            <span class="red2" id="spanEmail">*</span>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input type="button" value="确定" onclick="OnButtonSumit()" class="submit" />
            <input id="inputReset" class="submit" runat="server" type="reset" value="重置" />
            <input type="hidden" id="HiddenExistEmail" value="false" />
        </td>
    </tr>
</table>
