<%@ Control Language="C#" EnableViewState="false" %>
<asp:Image ID="ImageBig" runat="server"  Width="400px" Height="400px"/>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <asp:Image ID="ImageMore" runat="server"  ImageUrl='<%# Eval("Images")%>' Width="100px" Height="100px"/>
    </ItemTemplate>
</asp:Repeater>

