<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<strong>热门搜索：</strong>
<asp:Repeater ID="RepeaterKeyWords" runat="server">
    <ItemTemplate>
        <a href='/Search_productlist.aspx?search=<%#((DataRowView)Container.DataItem).Row["Name"]%>'>
            <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>&nbsp</ItemTemplate>
</asp:Repeater>
