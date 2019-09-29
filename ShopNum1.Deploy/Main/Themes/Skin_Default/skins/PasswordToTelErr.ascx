<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!--邮箱找回-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
    height: 180px; text-align: center" onload="funTime()">
    <tr style="height: 76px; line-height: 70px;">
        <td style="text-align: right; width: 30%">
            <img src="Themes/Skin_Default/Images/cancel.gif" />
        </td>
        <td style="color: Red; font-size: 26px; font-weight: bold; text-align: left; width: 70%">
            <asp:Label ID="LabelMessage2" runat="server" Visible="true">很遗憾，该链接已经失效！</asp:Label>
        </td>
    </tr>
</table>
