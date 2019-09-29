<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<ul>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <a href='<%# ((DataRowView)Container.DataItem).Row["ID"]%>' target="_blank">
                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"]%>' />
            <asp:DataList ID="RepeaterDataTitle" runat="server">
                <ItemTemplate>
                    <a target="_blank">
                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                </ItemTemplate>
            </asp:DataList>
        </ItemTemplate>
    </asp:Repeater>
</ul>
