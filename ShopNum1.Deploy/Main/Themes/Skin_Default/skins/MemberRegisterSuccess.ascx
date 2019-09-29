<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberRegisterSuccess.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.skins.MemberRegisterSuccess" %>
<script type="text/javascript">
    if (top.location != location) top.location.href = location.href;
</script>
<!--邮箱找回-->
<asp:Panel ID="PanelYes" runat="server" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
        height: 180px; text-align: center">
        <tr style="height: 76px; line-height: 70px;">
            <td style="text-align: right; width: 40%">
                <img src="Themes/Skin_Default/Images/dagou.gif" />
            </td>
            <td style="color: #029900; font-size: 26px; font-weight: bold; text-align: left;
                width: 60%">
                邮箱验证成功！
            </td>
        </tr>
        <tr style="height: 76px; line-height: 70px; text-align: center">
            <td style="font-size: 12px; text-align: left; text-align: center" colspan="2">
                请点击<asp:LinkButton ID="LinkButtonLogin" runat="server" ForeColor="Red">【登录】</asp:LinkButton>进入登录界面
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
                很遗憾！该链接已经失效。
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PanelSan" runat="server" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
        height: 190px; text-align: center">
        <tr style="height: 100px; line-height: 100px;">
            <td style="text-align: right; width: 30%">
                <img src="Themes/Skin_Default/Images/dagou.gif" />
            </td>
            <td style="color: Green; font-size: 26px; font-weight: bold; text-align: left; width: 70%">
                恭喜您，注册成功！
            </td>
        </tr>
        <tr style="height: 23px; text-align: center">
            <td style="width: 30%;">
            </td>
            <td style="font-size: 12px; text-align: left; vertical-align: text-top; width: 70%"
                colspan="2">
                您登陆本商城的用户名为：<asp:Label ID="LabelUserName" runat="server" Text="" Font-Bold="true"></asp:Label>,用户编号为：<asp:Label ID="LabelUserNo" runat="server" Text="" Font-Bold="true"></asp:Label>，您随时可以使用此用户名享受便宜又放心的购物乐趣。
            </td>
        </tr>
        <tr style="height: 67px; line-height: 67px; text-align: center">
            <td style="width: 30%;">
            </td>
            <td style="font-size: 12px; text-align: left; vertical-align: text-top; width: 70%"
                colspan="2">
                <a href='<%=ShopUrlOperate.RetUrl("main/account/A_Index") %>'><img src="Themes/Skin_Default/Images/aaa.jpg" /></a>
                <a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'>
                    <img src="Themes/Skin_Default/Images/entermember.gif" /></a>&nbsp;&nbsp;&nbsp;<a
                        href='<%=ShopUrlOperate.RetUrl("default") %>'><img src="Themes/Skin_Default/Images/20120912112746_07.gif" /></a><br/>
                        <div style="color:Red; font-size:17px;">*请注意，需要设置了帐号安全设置才能购买商品</div>
            </td>
            
        </tr>
        
    </table>
</asp:Panel>
<asp:Panel ID="PanelMobile" runat="server" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
        height: 190px; text-align: center">
        <tr style="height: 100px; line-height: 100px;">
            <td style="text-align: right; width: 30%">
                <img src="Themes/Skin_Default/Images/dagou.gif" />
            </td>
            <td style="color: Green; font-size: 26px; font-weight: bold; text-align: left; width: 70%">
                恭喜您 手机注册成功！
            </td>
        </tr>
        <tr style="height: 23px; text-align: center">
            <td style="width: 30%;">
            </td>
            <td style="font-size: 12px; text-align: left; vertical-align: text-top; width: 70%"
                colspan="2">
                您可直接使用手机：<asp:Label ID="LabelMobile" runat="server" Text="" Font-Bold="true"></asp:Label>登陆，您随时可以使用此用户名享受便宜又放心的购物乐趣。
            </td>
        </tr>
        <tr style="height: 67px; line-height: 67px; text-align: center">
            <td style="width: 30%;">
            </td>
            <td style="font-size: 12px; text-align: left; vertical-align: text-top; width: 70%"
                colspan="2">
                <a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'>
                    <img src="Themes/Skin_Default/Images/entermember.gif" /></a>&nbsp;&nbsp;&nbsp;<a
                        href='<%=ShopUrlOperate.RetUrl("default") %>'><img src="Themes/Skin_Default/Images/20120912112746_07.gif" /></a>
            </td>
        </tr>
    </table>
</asp:Panel>
