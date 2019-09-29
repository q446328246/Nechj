<%@ Control Language="C#" %>
<script type="text/javascript">
    if (top.location != location) top.location.href = location.href;
</script>
<asp:Panel ID="PanelType1" runat="server">
    <div id="divregester" runat="server" style="height: 400px; line-height: 400px; font-size: 19px;
        font-weight: bold;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
            height: 260px; text-align: center">
            <tr style="height: 160px; line-height: 160px;">
                <td style="text-align: right; width: 16%">
                    <img src="Themes/Skin_Default/Images/honggouogu.gif" />
                </td>
                <td style="color: #fc8506; font-size: 26px; font-weight: bold; text-align: left;
                    width: 84%">
                    <asp:Label ID="LabelMessage2" runat="server" Visible="true">谢谢您的注册，注册尚未完成！请在24小时内完成邮箱验证。</asp:Label>
                </td>
            </tr>
            <tr style="height: 100px;">
                <td colspan="2" valign="top">
                    邮件已经发送至您的邮箱823854566@qq.com，请您立即<asp:LinkButton ID="LinkButtonEmail" runat="server"
                        ForeColor="Red">登录该邮箱</asp:LinkButton>并按信中提示激活账号。<br />
                    如果未收到邮件，请点击<a>再次发送邮件</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
