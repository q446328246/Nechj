<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<ul>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <li><a href='<%# ((DataRowView)Container.DataItem).Row["LinkAddress"] %>' target='<%# TopNavigation.ShowIsOpen( ((DataRowView)Container.DataItem).Row["IfOpen"].ToString())%>'>
                <%# ((DataRowView)Container.DataItem).Row["Name"] %></a> </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
