<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var id;
    $(document).ready(function () {
        id = setInterval(getLeftTime, 1000);
    });
    //得到剩余时间 
    var k = 300
    function getLeftTime() {
        if (k > 0) {
            k--;
            $("#time").text(k);
        }
        if (k == 0) {
            $("#<%=ButtonReturnSend.ClientID %>").removeAttr("disabled");
            clearInterval(id);
        }
    } 
</script>
<!--邮箱找回-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
    height: auto;" onload="funTime()">
    <tr style="height: 100px; line-height: 100px;">
        <td style="text-align: right; width: 30%">
            <img src="Themes/Skin_Default/Images/dagou.gif" />
        </td>
        <td style="color: #029900; font-size: 27px; font-weight: bold; text-align: left;
            width: 70%">
            <asp:Label ID="LabelMessage2" runat="server" Visible="true">短信已经发送成功！</asp:Label>
        </td>
    </tr>
    <tr style="height: 30px;">
        <td style="text-align: right; width: 30%">
        </td>
        <td style="width: 70%; vertical-align: top;">
            短信已经发送至您的手机，请您立即<asp:LinkButton ID="LinkButtonTel" runat="server" Font-Bold="true">登录</asp:LinkButton>网站并修改密码，
        </td>
    </tr>
    <tr style="height: 30px;">
        <td style="text-align: right; width: 30%">
        </td>
        <td style="width: 70%; vertical-align: top;">
            如果<span id="time" style="color: Red">60</span>秒后没有收到短信，请点击<asp:Button ID="ButtonReturnSend"
                runat="server" Text="再次发送" Height="21px" Enabled="false" />
        </td>
    </tr>
</table>
