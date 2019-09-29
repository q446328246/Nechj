<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<span id="SpanQQ" runat="server">&nbsp;QQ客服
    <asp:Repeater EnableViewState="False" ID="RepeaterQQ" runat="server">
        <ItemTemplate>
            <a href="http://wpa.qq.com/msgrd?V=1&Uin=<%# Eval("ServiceAccount") %>&Menu=yes"
                target="blank" class="left">
                <img border="0" src="/Main/Themes/Skin_Default/Images/qq.gif" alt="不在线点击即可以留言请留言"></a>
        </ItemTemplate>
    </asp:Repeater>
</span><span id="SpanMSN" runat="server">&nbsp;MSN客服
    <asp:Repeater EnableViewState="False" ID="RepeaterMSN" runat="server">
        <ItemTemplate>
            <a target="_blank" href="http://settings.messenger.live.com/Conversation/IMMe.aspx?invitee=<%# Eval("ServiceAccount") %>&mkt=zh-cn">
                <img border="0" src="/Main/Themes/Skin_Default/Images/msn.gif" width="16" height="16" /></a>
        </ItemTemplate>
    </asp:Repeater>
</span>