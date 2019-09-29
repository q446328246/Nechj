<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="AriticleChrildCategory">
    <div class="top_keyword">
        <asp:Repeater ID="RepeaterCategory" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"]%>' />
                <a href='<%# ShopUrlOperate.RetUrl("articlelist",((DataRowView)Container.DataItem).Row["ID"]) %>'
                    target="_self">
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</span>