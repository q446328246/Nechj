<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div>
            <a href="#" target="_blank">
                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
        </div>
    </ItemTemplate>
</asp:Repeater>
