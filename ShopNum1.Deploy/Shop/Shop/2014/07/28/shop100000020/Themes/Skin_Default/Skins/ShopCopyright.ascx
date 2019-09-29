<%@ Control Language="C#" %>
<div>
    <asp:Label ID="labelCopyright" runat="server" />
    
    <asp:HyperLink ID="HyperLinkUrl" runat="server" Target="_blank">
        <asp:Label ID="labelPoweredBy" runat="server" />
    </asp:HyperLink>
</div>
<asp:HiddenField ID="HiddenFieldXmlPath" runat="server" Value="0" />
