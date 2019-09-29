<%@ Control Language="C#" %>
<asp:Panel ID="PanelType1" runat="server">
    <div id="divregester" runat="server" style="height: 400px; line-height: 400px; font-size: 19px;
        font-weight: bold;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
            height: 300px; text-align: center">
            <tr style="height: 200px; line-height: 200px;">
                <td style="text-align: right; width: 16%">
                    <img src="Themes/Skin_Default/Images/honggouogu.gif" />
                </td>
                <td style="color: #fc8506; font-size: 26px; font-weight: bold; text-align: left;
                    width: 84%">
                    <asp:Label ID="LabelMessage2" runat="server" Visible="true">谢谢您的注册，注册尚未完成！请在24小时内完成邮箱验证。</asp:Label>
                </td>
            </tr>
            <tr style="height: 100px; line-height: 40px; font-size: 17px">
                <td style="text-align: right; width: 16%">
                </td>
                <td style="text-align: left; width: 84%">
                    <div>
                        邮件已经发送至您的邮箱<asp:Label ID="LabelEmail" runat="server" Text="823854566@qq.com"></asp:Label>，请您立即<asp:LinkButton
                            ID="LinkButtonEmail" runat="server" ForeColor="Red">登录该邮箱</asp:LinkButton>并按信中提示激活账号。</div>
                    <div>
                        如果未收到邮件，请点击<asp:LinkButton ID="LinkButtonSend" runat="server" ForeColor="Red">再次发送邮件</asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
