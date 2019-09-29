<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!--邮箱找回-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
    height: auto;">
    <tr style="height: 100px; line-height: 100px;">
        <td style="text-align: right; width: 30%">
            <img src="Themes/Skin_Default/Images/dagou.gif" />
        </td>
        <td style="color: #029900; font-size: 26px; font-weight: bold; text-align: left;
            width: 70%">
            <asp:Label ID="LabelMessage2" runat="server" Visible="true">找回密码邮件发送成功！</asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 30%; height: 60px;">
        </td>
        <td style="width: 70%; vertical-align: top; font-size: 13px;">
            邮件已经发送至您的邮箱，请您立即<asp:LinkButton ID="LinkButtonEmail" runat="server" Font-Bold="true">登录该邮箱</asp:LinkButton>并按信中提示修改密码。
        </td>
    </tr>
</table>
