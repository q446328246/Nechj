<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <h2>
                <a target="_blank" href='<%#  "AnnouncementDetail.aspx?guid="+((DataRowView)Container.DataItem).Row["Guid"] %>'>
                    <%# ((DataRowView)Container.DataItem).Row["Title"] %></a>
                <%# ((DataRowView)Container.DataItem).Row["Remark"]%>
            </h2>
        </ItemTemplate>
    </asp:Repeater>
</div>
