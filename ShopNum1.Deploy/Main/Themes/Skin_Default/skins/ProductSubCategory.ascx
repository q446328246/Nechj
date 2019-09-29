<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="recommend_keyword fl">
    <asp:Repeater ID="RepeaterDataWenzi" runat="server">
        <ItemTemplate>
            <%#RepeaterDataWenzi.Items.Count == 0 ? "" : "|"%>
            <a href='/Search_productlist.aspx?code=<%#((DataRowView)Container.DataItem).Row["Code"] %>?category=1'target="_blank"> <%# ((DataRowView)Container.DataItem).Row["Name"]%>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="index_more"><asp:Literal ID="moreView_1" runat="server" Text="更多"></asp:Literal></div>