<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="B_MemberRegProtocol.ascx.cs" Inherits="ShopNum1.Deploy.Main.Bourse.Skin.B_MemberRegProtocol" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="regester" style="background: none; border: 1px solid #ccc; padding: 0;">
    <div class="regester_tit">
        用户协议</div>
    <div class="agreement">
        <div class="agreement_detail">
            
            <asp:Label ID="labelRegProtocol" runat="server" />
            </div>
        <div style="text-align: center;">

         <asp:Button ID="Button1" runat="server" Text="同意" onclick="Button1_Click" class="baocbtn"/>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="拒绝" onclick="Button2_Click" class="baocbtn"/>
        </div>
       

        <%-- <div class="yhzcxy">
            <input type="image" src='Themes/Skin_Default/Images/close_ShopRegProtocol.gif' onfocus="this.blur();window.close()" /></div>
    </div>--%>
    </div>
</div>
