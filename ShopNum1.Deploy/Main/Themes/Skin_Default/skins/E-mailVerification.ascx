<%@ Control Language="C#" %>
<div class="gmcg">
    <div class="chengcg">
        谢谢您的注册，注册尚未完成！请在24小时内完成邮箱验证</div>
    <div class="mailaver">
        <p>
            邮件已经发送至您的邮箱
            <asp:Label ID="LabelEmail" runat="server" Text="" CssClass="mailadd"></asp:Label>
            ，请您立即
            <asp:LinkButton ID="LinkButtonEmail" runat="server" CssClass="maillogin">
            登录
            </asp:LinkButton>
            该邮箱并按信息中提示激活帐号。</p>
        <p>
            如果未收到邮件，请点击
            <asp:LinkButton ID="LinkButtonSend" runat="server" CssClass="maillogin">
            再次发送邮件
            </asp:LinkButton>
        </p>
        <div>
            <asp:Button ID="Button1" runat="server" Text="返回首页" CssClass="emialbtn" PostBackUrl="~/Default.aspx" /></div>
    </div>
    <div class="clear">
    </div>
</div>
